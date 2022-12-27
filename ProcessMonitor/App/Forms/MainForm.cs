using App.Services.ProcessService;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Forms
{
    internal partial class MainForm : Form
    {
        private readonly IProcessService _processService;
        private readonly Timer _timer;

        public MainForm(IProcessService processService)
        {
            InitializeComponent();

            _processService = processService;

            _timer = new Timer();
            _timer.Tick += UpdateTable;
            _timer.Interval = 500;
            _timer.Enabled = true;
        }

        private async void UpdateTable(object sender, EventArgs e)
        {
            _timer.Enabled = false;

            var processes = await Task.Run(() => { return _processService.GetActiveProcesses(); });
            _dataGridView.DataSource = processes;

            _timer.Enabled = true;
        }


    }
}
