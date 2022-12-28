using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using App.Services.ProcessService;
using App.Core;

namespace App.Forms
{
    internal partial class MainForm : Form
    {
        const string _pauseText = "Pause";
        const string _continueText = "Continue";

        private readonly IProcessService _processService;
        private readonly ILogger _logger;
        private readonly Timer _timer;


        private int? _scrollPosition;
        private string _selectedRowId;
        private bool _isPaused;
        

        public MainForm(ILogger<MainForm> logger, IProcessService processService)
        {
            _logger = logger;
            _processService = processService;
            _timer = new Timer();

            InitializeComponent();
            InitIntervalComboBox();
            UpdateTableOnTick(null, null);

            _timer.Tick += UpdateTableOnTick;
            _timer.Enabled = true;
            _timer.Interval = (int)_comboBoxInterval.SelectedValue;

            _logger.LogInformation("Open main form.");
        }


        private void OnPauseButtonClick(object sender, EventArgs e)
        {
            if (!_isPaused)
            {
                _isPaused = true;
                _buttonPause.Text = _continueText;
            }
            else
            {
                _isPaused = false;
                _buttonPause.Text = _pauseText;
            }
        }

        private void UpdateTableOnTick(object sender, EventArgs e)
        {
            if (_isPaused)
                return;

            UpdateTable();
        }

        private void OnKillButtonClick(object sender, EventArgs e)
        {
            _logger.LogInformation($"Kill selected process. Id: {_selectedRowId}");

            ExceptionHandler(() =>
            {
                _processService.KillProcessById(_selectedRowId);
            });
            
            UpdateTable();
        }

        private void OnMoreButtonClick(object sender, EventArgs e)
        {

            _logger.LogInformation($"Show more info about process. Id: {_selectedRowId}");
            ExceptionHandler(() =>
            {
                var process = _processService.GetProcessById(_selectedRowId);
                new MoreProcessForm(process).Show();
            });
        }

        private void OnComboBoxIntervalChange(object sender, EventArgs e)
        {            
            if (_comboBoxInterval.SelectedValue is int val)
            {
                _logger.LogInformation($"Update interval changed to {val} ms.");
                _timer.Interval = val;
            }
        }
        
        private void OnTableClick(object sender, DataGridViewCellEventArgs e)
        {
            RememberSelectedRow();

            SwitchMoreKillButtonsIfShould();
        }

        private void OnTableScroll(object sender, ScrollEventArgs e)
        {
            RememberScrollPosition();
        }


        #region Helpers

        private void UpdateTable()
        {
            _logger.LogDebug("Update process list.");

            ExceptionHandler(async () =>
            {
                _timer.Enabled = false;

                RememberSelectedRow();


                // Get old and current data
                var oldProcesses = (ProcessCompact[]) _dataGridView.DataSource;
                var curProcesses = await Task.Run(() => { return _processService.GetActiveProcessesCompact(); });
                if (oldProcesses == null)
                {
                    oldProcesses = new ProcessCompact[] { };
                }


                // Get new and exited processes id's
                var newProcessesIds = curProcesses.Select(p => p.Id).Except(oldProcesses.Select(p => p.Id));
                var exitedProcessesIds = oldProcesses.Select(p => p.Id).Except(curProcesses.Select(p => p.Id));

                //Log new processes
                foreach (var id in newProcessesIds)
                {
                    _logger.LogDebug($"New process - Id:{id} Name:{curProcesses.First(p => p.Id == id).Name}");
                }

                //Log exited processes
                foreach (var id in exitedProcessesIds)
                {
                    _logger.LogDebug($"Stop process - Id:{id} Name:{oldProcesses.First(p => p.Id == id).Name}");
                }

                // Set new data source
                _dataGridView.DataSource = curProcesses;


                RecoverScrollPosition();
                RecoverSelectedRow();

                SwitchMoreKillButtonsIfShould();

                _timer.Enabled = true;
            });
        }
        
        private void ExceptionHandler(Action action)
        {
            try
            {
                action();
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                MessageBox.Show(caption: "Error!", text: e.Message, icon: MessageBoxIcon.Error, buttons: MessageBoxButtons.OK);
            }
        }

        private void SwitchMoreKillButtonsIfShould()
        {
            if (_dataGridView.SelectedRows.Count > 0)
            {
                _buttonKill.Enabled = true;
                _buttonMore.Enabled = true;
                return;
            }


            _buttonKill.Enabled = false;
            _buttonMore.Enabled = false;
        }

        private void RememberSelectedRow()
        {
            var selectedRows = _dataGridView.SelectedRows;

            _selectedRowId = selectedRows.Count > 0 ? selectedRows[0].Cells["Id"].Value as string : null;
        }

        private void RecoverSelectedRow()
        {
            // Try reselect old process
            if (_selectedRowId != null)
            {
                var row = _dataGridView.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.Cells["Id"].Value as string == _selectedRowId);
                if (row != null)
                {
                    row.Selected = true;
                    return;
                }
            }

            // Unselect all 
            foreach (DataGridViewRow row in _dataGridView.SelectedRows)
                row.Selected = false;
        }

        private void RememberScrollPosition()
        {
            _scrollPosition = _dataGridView.FirstDisplayedCell?.RowIndex;
        }

        private void RecoverScrollPosition()
        {
            if (_scrollPosition != null)
            {
                _dataGridView.FirstDisplayedScrollingRowIndex = (int)_scrollPosition;
            }
        }

        private void InitIntervalComboBox()
        {
            var dataSource = new[] {
                new{ ValueMember = 500, DisplayMember = "Update interval - 0.5s"},
                new{ ValueMember =  1000, DisplayMember = "Update interval - 1s"},
                new{ ValueMember = 5000, DisplayMember = "Update interval - 5s"},
                new{ ValueMember = 10000, DisplayMember = "Update interval - 10s"},
            };

            _comboBoxInterval.DataSource = dataSource;
            _comboBoxInterval.DisplayMember = "DisplayMember";
            _comboBoxInterval.ValueMember = "ValueMember";

            _comboBoxInterval.SelectedValue = 1000;
        }

        #endregion
    }
}

