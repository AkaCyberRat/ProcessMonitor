using App.Core;
using System.Windows.Forms;

namespace App.Forms
{
    internal partial class MoreProcessForm : Form
    {
        public MoreProcessForm(Process process)
        {
            InitializeComponent();

            textBoxId.Text = process.Id;
            textBoxName.Text = process.Name;
            textBoxMachineName.Text = process.MachineName;
            textBoxPrioClass.Text = process.PriorityClass;
            textBoxStartTme.Text = process.StartTime.ToString();
        }

        private void OnButtonClick(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
