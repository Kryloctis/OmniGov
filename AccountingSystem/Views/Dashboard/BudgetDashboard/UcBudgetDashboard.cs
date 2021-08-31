using AccountingSystem.Views.Dashboard.BudgetDashboard.BudgetSummary;
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
    }
}
