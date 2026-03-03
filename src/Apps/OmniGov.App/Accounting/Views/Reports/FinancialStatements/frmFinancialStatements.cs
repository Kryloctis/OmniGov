using OmniGov.App.Helpers;

namespace OmniGov.App.Accounting.Views.Reports.FinancialStatements
{
    public partial class frmFinancialStatements : Form
    {
        private ucStatementOfFinancialPosition ucStatementOfFinancialPosition;
        private ucStatementOfFinancialPerformance ucStatementOfFinancialPerformance;
        private ucStatementOfChangesInNetAssetsEquity ucStatementOfChangesInNetAssetsEquity;
        private ucStatementOfCashFlows ucStatementOfCashFlows;

        public frmFinancialStatements()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            ucStatementOfFinancialPosition = ucStatementOfFinancialPosition1;
            ucStatementOfFinancialPerformance = ucStatementOfFinancialPerformance1;
            ucStatementOfChangesInNetAssetsEquity = ucStatementOfChangesInNetAssetsEquity1;
            ucStatementOfCashFlows = ucStatementOfCashFlows1;
        }

        private void frmFinancialStatements_Load(object sender, EventArgs e)
        {
            ToggleContents(tabControlFinancialStatements);
        }

        private void tabControlFinancialStatements_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToggleContents(tabControlFinancialStatements);
        }

        private void ToggleContents(TabControl tabControl)
        {
            switch (tabControl.SelectedTab.Name)
            {
                case "tabPageSfPosition":
                    ucStatementOfFinancialPosition.OnLoad();
                    break;

                case "tabPageSfPerformance":
                    ucStatementOfFinancialPerformance.OnLoad();
                    break;

                case "tabPageScf":
                    ucStatementOfCashFlows.OnLoad();

                    break;

                case "tabPageScnae":
                    ucStatementOfChangesInNetAssetsEquity.OnLoad();
                    break;
            }
        }
    }
}