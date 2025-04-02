using LFS.Views.Dashboard.BudgetDashboard.BudgetSummary;
using LFS.Views.Manage.AllotmentRelease;
using LFS.Views.Manage.BudgetAppropriations;
using LFS.Views.Transactions.ObligationRequest;
using System;
using System.Windows.Forms;
using LFS.Views.Reports.Saaob;
using LFS.Views.Reports.Saaobb;
using LFS;

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

        internal void OnloadEvent()
        {
            if (!DesignMode)
            {
                ucBudgetSummary.OnLoad();
            }
        }

        private void appropriationsTStrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmBudgetAppropriations().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void allotmentReleaseTStrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmAllotmentReleaseMain().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void obligationsTStrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmObligationRequestMain().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}