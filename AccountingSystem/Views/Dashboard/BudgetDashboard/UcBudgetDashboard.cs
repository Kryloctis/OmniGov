using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Dashboard
{
    public partial class ucBudgetDashboard : UserControl
    {

        public ucBudgetDashboard()
        {
            InitializeComponent();
        }

        private void UcBudgetDashboard_Load(object sender, EventArgs e)
        {
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
