using LFS.Helpers;
using System;
using System.Windows.Forms;

namespace LFS.Views.Reports.TrialBalance
{
    public partial class frmTrialBalance : Form
    {
        private ucPreClosingTrialBalance ucPreClosingTrialBalance;
        private ucPostClosingTrialBalance ucPostClosingTrialBalance;

        public frmTrialBalance()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            ucPreClosingTrialBalance = ucPreClosingTrialBalance1;
            ucPostClosingTrialBalance = ucPostClosingTrialBalance1;
        }

        private void ToggleContents(TabControl tabControl)
        {
            switch (tabControl.SelectedTab.Name)
            {
                case "tabPagePreTb":
                    ucPreClosingTrialBalance.OnLoad();
                    break;

                case "tabPagePosTb":
                    ucPostClosingTrialBalance.OnLoad();
                    break;

                default:
                    break;
            }
        }

        private void frmTrialBalance_Load(object sender, EventArgs e)
        {
            try
            {
                ToggleContents(tabControlTrialBalance);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tabControlTrialBalance_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ToggleContents(tabControlTrialBalance);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
