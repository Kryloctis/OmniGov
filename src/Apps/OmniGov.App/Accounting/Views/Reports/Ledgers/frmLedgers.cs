using OmniGov.App.Helpers;

namespace OmniGov.App.Accounting.Views.Reports.Ledgers
{
    public partial class frmLedgers : Form
    {
        private ucGeneralLedger ucGeneralLedger;
        private ucSummarySubsidiaryLedger ucSummarySubsidiaryLedger;
        private ucSubsidiaryLedger ucSubsidiaryLedger;
        private ucTransactionLog ucTransactionLog;

        public frmLedgers()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            ucGeneralLedger = ucGeneralLedger1;
            ucSummarySubsidiaryLedger = ucSummarySubsidiaryLedger1;
            ucSubsidiaryLedger = ucSubsidiaryLedger1;
            ucTransactionLog = ucTransactionLog1;
        }

        private void frmLedgers_Load(object sender, EventArgs e)
        {
            var selectedtTabPage = tabControlLedgers.SelectedTab;
            ToggleReport(selectedtTabPage);
        }

        private void ToggleReport(TabPage tabPage)
        {
            switch (tabPage.Name)
            {
                case "tabPageGeneralLedger":
                    ucGeneralLedger.OnLoad();

                    break;

                case "tabPageSubLedger":
                    ucSubsidiaryLedger.OnLoad();

                    break;

                case "tabPageSumSubLedger":
                    ucSummarySubsidiaryLedger.OnLoad();

                    break;

                case "tabPageTransactionLog":
                    ucTransactionLog.OnLoad();

                    break;
            }
        }

        private void tabControlLedgers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedtTabPage = tabControlLedgers.SelectedTab;
            ToggleReport(selectedtTabPage);
        }
    }
}