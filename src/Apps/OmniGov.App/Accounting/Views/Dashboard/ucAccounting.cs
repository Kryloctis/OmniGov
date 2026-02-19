using OmniGov.App.Helpers;

namespace OmniGov.App.Accounting.Views.Dashboard
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
