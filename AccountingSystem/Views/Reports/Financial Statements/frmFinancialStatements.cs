using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Financial_Statements
{
    public partial class frmFinancialStatements : Form
    {
        public frmFinancialStatements()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void ChangeTabs()
        {
            if (radSFPosition.Checked)
                tabControlFinancialStatements.SelectedTab = tabPageSFPosition;
            if (radSFPerformance.Checked)
                tabControlFinancialStatements.SelectedTab = tabPageSFPerformance;
            if (radSCF.Checked)
                tabControlFinancialStatements.SelectedTab = tabPageSCF;
            if (radSCNAE.Checked)
                tabControlFinancialStatements.SelectedTab = tabPageSCNAE;
            if (radSCBAA.Checked)
                tabControlFinancialStatements.SelectedTab = tabPageSCBAA;
        }

        private void radSFPosition_CheckedChanged(object sender, System.EventArgs e)
        {
            ChangeTabs();
        }

        private void radSFPerformance_CheckedChanged(object sender, System.EventArgs e)
        {
            ChangeTabs();
        }

        private void radSCF_CheckedChanged(object sender, System.EventArgs e)
        {
            ChangeTabs();
        }

        private void radSCNAE_CheckedChanged(object sender, System.EventArgs e)
        {
            ChangeTabs();
        }

        private void radSCBAA_CheckedChanged(object sender, System.EventArgs e)
        {
            ChangeTabs();
        }

        private void frmFinancialStatements_Load(object sender, System.EventArgs e)
        {
            ChangeTabs();
        }
    }
}
