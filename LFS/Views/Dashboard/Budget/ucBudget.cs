using LFS.Helpers;
using LFS.Views.Dashboard.BudgetDashboard.BudgetSummary;
using LFS.Views.Manage.AllotmentRelease;
using LFS.Views.Manage.BudgetAppropriations;
using LFS.Views.Transactions.CheckIssuance.Obligations;
using LFS.Views.Transactions.ObligationRequest;
using LFS.Views.Transactions.Obligations;
using System;
using System.Windows.Forms;

namespace LFS.Views.Dashboard.Budget
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
            tlStrpBtnObligations.Enabled = PrivilegesHelper.HasPrivilege(Privileges.TransObligationReq);
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