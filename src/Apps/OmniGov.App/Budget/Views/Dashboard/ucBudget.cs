using OmniGov.App.Budget.Views.AllotmentRelease.Old;
using OmniGov.App.Budget.Views.BudgetAppropriations;
using OmniGov.App.Budget.Views.Obligations;
using OmniGov.App.Helpers;

namespace OmniGov.App.Budget.Views.Dashboard
{
    public partial class ucBudget : UserControl
    {
        private ucBudgetSummary ucBudgetSummary;

        public ucBudget()
        {
            InitializeComponent();
            ucBudgetSummary = ucBudgetSummary1;
        }

        private void VerifyUserPrivileges()
        {
            tlStrpBtnAppropriations.Enabled = PrivilegesHelper.HasPrivilege(Privileges.MngBudgetApprops);
            tlStrpBtnAlltmntRelease.Enabled = PrivilegesHelper.HasPrivilege(Privileges.MngAllotReleases);
            tlStrpBtnObligationRequest.Enabled = PrivilegesHelper.HasPrivilege(Privileges.TransObligationReq);
        }

        internal void OnLoad()
        {
            if (!DesignMode)
            {
                ucBudgetSummary.OnLoad();
                VerifyUserPrivileges();
            }
        }

        private void tlStrpBtnAppropriations_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmBudgetAppropriations().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tlStrpBtnAlltmntRelease_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmAllotmentReleaseMain().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tlStrpBtnObligations_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmObligations().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}