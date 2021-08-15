using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.TrialBalance
{
    public partial class frmTrialBalance : Form
    {
        public frmTrialBalance()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void frmTrialBalance_Load(object sender, EventArgs e)
        {
        }

        private void ChangePanelDisplayForm()
        {
            if (radioPreTB.Checked)
            {
                tabTrialBalance.SelectedTab = tabPagePreTrial;
                radioPostTB.Image = null;
            }
            else
            {
                tabTrialBalance.SelectedTab = tabPagePostTrial;
                radioPreTB.Image = null;
            }
        }

        private void radioPostTB_CheckedChanged(object sender, EventArgs e)
        {
            ChangePanelDisplayForm();
        }

        private void radioPreTB_CheckedChanged(object sender, EventArgs e)
        {
            ChangePanelDisplayForm();
        }
    }
}
