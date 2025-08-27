using LFS.Helpers;
using LFS.Views.Manage.ChartOfAccounts;
using LFS.Views.Manage.Journals;
using System;
using System.Windows.Forms;

namespace LFS.Views.Dashboard.Accounting
{
    public partial class ucAccounting : UserControl
    {
        private ucJevDashboard ucJevDashboard;

        public ucAccounting()
        {
            InitializeComponent();
            ucJevDashboard = ucJevDashboard1;
        }

        internal void OnLoad()
        {
            ucJevDashboard.OnLoad();
            ValidatePermissions();
        }

        private void ValidatePermissions()
        {
            ucJevDashboard.Enabled = PrivilegesHelper.HasPrivilege(Privileges.TransJEV);
            chartOfAccountsTStrpMnuItm.Enabled = PrivilegesHelper.HasPrivilege(Privileges.MngChartAccounts);
            journalsTStrpMnuItm.Enabled = PrivilegesHelper.HasPrivilege(Privileges.MngJournals);
        }

        private void chartOfAccountsTStrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmChartOfAccounts().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void journalsTStrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmJournals().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}