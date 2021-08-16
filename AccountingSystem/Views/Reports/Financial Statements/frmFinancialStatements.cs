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
                tabControl1.SelectedTab = tabSFPosition;
            if (radSFPerformance.Checked)
                tabControl1.SelectedTab = tabSFPerformance;
            if (radSCF.Checked)
                tabControl1.SelectedTab = tabSCF;
            if (radSCNAE.Checked)
                tabControl1.SelectedTab = tabSCNAE;
            if (radSCBAA.Checked)
                tabControl1.SelectedTab = tabSCBAA;
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
