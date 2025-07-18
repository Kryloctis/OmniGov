using System;
using System.Windows.Forms;

namespace LFS.Views.Reports.Financial_Statements
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
            try
            {
                ToggleContents(tabControlFinancialStatements);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tabControlFinancialStatements_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ToggleContents(tabControlFinancialStatements);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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