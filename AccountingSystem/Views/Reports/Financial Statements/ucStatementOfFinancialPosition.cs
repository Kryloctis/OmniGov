using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Financial_Statements
{
    public partial class ucStatementOfFinancialPosition : UserControl
    {
        private readonly ReportViewer reportViewer;

        decimal currentEndingBalance = 0;
        decimal previousYearEndingBalance = 0;

        public ucStatementOfFinancialPosition()
        {
            InitializeComponent();

            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }

        private void LoadFunds()
        {
            try
            {
                var dtFunds = Factory.FundsRepository().GetRecords();

                HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "fund_name", "id");

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private DataTable StatementOfFinancialPositionReport()
        {
            var dataSet = new dsLFS();
            var dtStatementOfFinancialPosition = dataSet.dtStatementOfFinancialPosition;
            int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
            DateTime dateAsOf = dtAsOf.Value;
            var dtAccountGroup = Factory.AccountGroupRepository().GetRecords();

            foreach (DataRow row in dtAccountGroup.Rows)
            {
                int accountGroupId = Convert.ToInt32(row["id"]);
                string accountGroupCode = row["account_group_code"].ToString();
                string accountGroupName = row["account_group_name"].ToString();
                var dtMajorAccountGroup = Factory.MajorAccountGroupRepository().GetViewRecordsByAccountGroupId((byte)accountGroupId);
                if (accountGroupId == 1 || accountGroupId == 2)
                {
                    GetAssetsAndLiabilities(dtStatementOfFinancialPosition, fundId, dateAsOf, accountGroupId, accountGroupCode, accountGroupName, dtMajorAccountGroup);
                }
                else if (accountGroupId == 3 || accountGroupId == 4 || accountGroupId == 5)
                {
                    GetRevenuesExpenses(fundId, dateAsOf, accountGroupId, accountGroupCode, accountGroupName, dtMajorAccountGroup);
                }
            }

            return dtStatementOfFinancialPosition;

            static void GetAssetsAndLiabilities(dsLFS.dtStatementOfFinancialPositionDataTable dtStatementOfFinancialPosition, int fundId, DateTime dateAsOf, int accountGroupId, string accountGroupCode, string accountGroupName, DataTable dtMajorAccountGroup)
            {
                foreach (DataRow rowMajorAccountGroup in dtMajorAccountGroup.Rows)
                {
                    int majorAccountGroupId = Convert.ToInt32(rowMajorAccountGroup["maj_acc_group_id"]);
                    string majorAccountGroupCode = rowMajorAccountGroup["maj_acc_group_code"].ToString();
                    string majorAccountGroupName = rowMajorAccountGroup["maj_acc_group_name"].ToString();

                    decimal currentDebitAmount = Factory.JEVRepository().GetSumByMajorAccountGroup(fundId, majorAccountGroupId, 1, dateAsOf);
                    decimal currentCreditAmoubt = Factory.JEVRepository().GetSumByMajorAccountGroup(fundId, majorAccountGroupId, 0, dateAsOf);
                    decimal currentEndingBalacnce = currentDebitAmount - currentCreditAmoubt;

                    decimal previousYearDebitAmount = Factory.JEVRepository().GetSumPreviousYearTransactionsByFundIdAndMajAccountGroupId(fundId, majorAccountGroupId, 1, dateAsOf);
                    decimal previousYearCreditAmount = Factory.JEVRepository().GetSumPreviousYearTransactionsByFundIdAndMajAccountGroupId(fundId, majorAccountGroupId, 0, dateAsOf);
                    decimal previousYearEndingBalance = previousYearDebitAmount - previousYearCreditAmount;

                    var items = new object[]
                    {
                            //account_group_id
                            accountGroupId, 
                            //account_group_code
                            accountGroupCode,
                            //account_group_name
                            accountGroupName,
                            //major_account_group_id
                            majorAccountGroupId,
                            //major_account_group_code
                            majorAccountGroupCode,
                            //major_account_group_name
                            majorAccountGroupName,
                            //current_amount
                            currentEndingBalacnce,
                            //last_year_amount
                            previousYearEndingBalance,
                            //is_current
                            1
                    };
                    dtStatementOfFinancialPosition.Rows.Add(items);
                }
            }
        }

        private void GetRevenuesExpenses(int fundId, DateTime dateAsOf, int accountGroupId, string accountGroupCode, string accountGroupName, DataTable dtMajorAccountGroup)
        {
            foreach (DataRow rowMajorAccountGroup in dtMajorAccountGroup.Rows)
            {
                int majorAccountGroupId = Convert.ToInt32(rowMajorAccountGroup["maj_acc_group_id"]);

                decimal currentDebitAmount = Factory.JEVRepository().GetSumByMajorAccountGroup(fundId, majorAccountGroupId, 1, dateAsOf);
                decimal currentCreditAmoubt = Factory.JEVRepository().GetSumByMajorAccountGroup(fundId, majorAccountGroupId, 0, dateAsOf);
                currentEndingBalance += currentDebitAmount - currentCreditAmoubt;

                decimal previousYearDebitAmount = Factory.JEVRepository().GetSumPreviousYearTransactionsByFundIdAndMajAccountGroupId(fundId, majorAccountGroupId, 1, dateAsOf);
                decimal previousYearCreditAmount = Factory.JEVRepository().GetSumPreviousYearTransactionsByFundIdAndMajAccountGroupId(fundId, majorAccountGroupId, 0, dateAsOf);
                previousYearEndingBalance += previousYearDebitAmount - previousYearCreditAmount;
            }
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
                DateTime AsOf = dtAsOf.Value;


                report.ReportPath = $"{Application.StartupPath}\\Reports\\statement-of-financial-position-report.rdlc";
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("dtStatementOfFinancialPosition", StatementOfFinancialPositionReport()));

                var fundRepo = Factory.FundsRepository().GetRecordByID(fundId);
                var parameters = new[] {
                    new ReportParameter("paramFundName", fundRepo["fund_name"]),
                    new ReportParameter("paramDate", AsOf.ToString("MMMM dd, yyyy")),
                    new ReportParameter("paramGovernmentEquityCurrentAmount", currentEndingBalance.ToString("N2")),
                    new ReportParameter("paramGovernmentEquityLastYearAmount", previousYearEndingBalance.ToString("N2")),
                };
                report.SetParameters(parameters);

                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }

        private void ucStatementOfFinancialPosition_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadFunds();
            }
        }
    }
}
