using AccountingSystem.Views.Dashboard.BudgetDashboard.BudgetSummary;
using AccountingSystem.Views.Manage.AllotmentRelease;
using AccountingSystem.Views.Manage.BudgetAppropriations;
using AccountingSystem.Views.Transactions.ObligationRequest;
using System;
using System.Windows.Forms;
using AccountingSystem.Views.Reports.Saaob;
using AccountingSystem.Views.Reports.Saaobb;
using LFS;

namespace AccountingSystem.Views.Dashboard.Budget
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