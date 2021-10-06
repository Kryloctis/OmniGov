using AccountingSystem.Views.Dashboard.BudgetDashboard.BudgetSummary;
using AccountingSystem.Views.Manage.AllotmentRelease;
using AccountingSystem.Views.Manage.BudgetAppropriations;
using AccountingSystem.Views.Transactions.ObligationRequest;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Dashboard
{
    public partial class ucBudgetDashboard : UserControl
    {

        private ucBudgetSummary uc;

        public ucBudgetDashboard()
        {
            InitializeComponent();
            uc = ucBudgetSummary1;
        }

        private void UcBudgetDashboard_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                uc.LoadBudgetDashboardComboboxes();
                uc.LoadBudgetDashboardContents();
            }
        }

        private void chkbxDetailed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbxDetailed.Checked)
                tabControl1.SelectedTab = tabBudgetDetailed;
            else
                tabControl1.SelectedTab = tabBudgetSummary;
        }

        private void btnBudgetAppropriations_Click(object sender, EventArgs e)
        {
            _ = new frmBudgetAppropriations().ShowDialog();
        }

        private void btnAllotmentRelease_Click(object sender, EventArgs e)
        {
            _ = new frmAllotmentReleaseMain().ShowDialog();
        }

        private void btnObligationRequest_Click(object sender, EventArgs e)
        {
            _ = new frmObligationRequestMain().ShowDialog();
        }
    }
}
