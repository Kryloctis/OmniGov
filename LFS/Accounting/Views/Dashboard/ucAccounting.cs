using LFS.Helpers;
using LFS.Views.Dashboard.AccountingDashboard;
using LFS.Views.Transactions.JEV;
using System;
using System.Windows.Forms;

namespace LFS.Views.Dashboard.Accounting
{
    public partial class ucAccounting : UserControl
    {
        private ucJevDashboard ucJevDashboard;
        private ucJournalsDashboard ucJournalsDashboard;

        public ucAccounting()
        {
            InitializeComponent();
            ucJevDashboard = ucJevDashboard1;
            ucJournalsDashboard = ucJournalsDashboard1;
        }

        internal void OnLoad()
        {
            ucJevDashboard.OnLoad();
            this.ucJournalsDashboard.Onload();
            ValidatePermissions();
        }

        private void ValidatePermissions()
        {
            ucJevDashboard.Enabled = PrivilegesHelper.HasPrivilege(Privileges.TransJEV);
        }
    }
}
