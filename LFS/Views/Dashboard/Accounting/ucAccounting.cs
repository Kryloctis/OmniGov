using LFS.Helpers;
using LFS.Views.Manage.ChartOfAccounts;
using LFS.Views.Manage.Journals;
using LFS.Views.Transactions.JEV;
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
        }

        private void btnRecordJev_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmJevList(ucJevDashboard).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}