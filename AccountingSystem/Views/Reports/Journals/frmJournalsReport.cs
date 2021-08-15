using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Journals
{
    public partial class frmJournalsReport : Form
    {
        public frmJournalsReport()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void ChangeTabs()
        {
            if (radBtnGJ.Checked)
                tabControl1.SelectedTab = tabGJ;
            if (radBtnCRJ.Checked)
                tabControl1.SelectedTab = tabCRJ;
            if (radBtnPRJ.Checked)
                tabControl1.SelectedTab = tabPRJ;
            if (radBtnCashDJ.Checked)
                tabControl1.SelectedTab = tabCashDJ;
            if (radBtnCheckDJ.Checked)
                tabControl1.SelectedTab = tabCheckDJ;
            if (radBtnADADJ.Checked)
                tabControl1.SelectedTab = tabADADJ;
        }

        private void frmJournals_Load(object sender, System.EventArgs e)
        {
            ChangeTabs();
        }

        private void radBtnGJ_CheckedChanged(object sender, System.EventArgs e)
        {
            ChangeTabs();
        }

        private void radBtnCRJ_CheckedChanged(object sender, System.EventArgs e)
        {
            ChangeTabs();
        }

        private void radBtnPRJ_CheckedChanged(object sender, System.EventArgs e)
        {
            ChangeTabs();
        }

        private void radBtnCashDJ_CheckedChanged(object sender, System.EventArgs e)
        {
            ChangeTabs();
        }

        private void radBtnCheckDJ_CheckedChanged(object sender, System.EventArgs e)
        {
            ChangeTabs();
        }

        private void radBtnADADJ_CheckedChanged(object sender, System.EventArgs e)
        {
            ChangeTabs();
        }
    }
}
