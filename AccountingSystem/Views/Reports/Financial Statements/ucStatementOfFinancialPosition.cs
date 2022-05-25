using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Financial_Statements
{
    public partial class ucStatementOfFinancialPosition : UserControl
    {
        private readonly ReportViewer reportViewer;

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

        private void GetDebitCredit(byte fundsId, DateTime dateEntry, ushort generalLedgerId, out decimal balanceDebit, out decimal balanceCredit)
        {
            var dictBeginningBalance = Factory.BeginningBalancesRepository().GetSumBalancesBy_FundId_GenLedgId_Date_SubLedgId(fundsId, generalLedgerId, dateEntry);
            var dictTransaction = Factory.JEVAccountsRepository().GetSumTransactionsByGenLedgerId(fundsId, generalLedgerId, dateEntry);

            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];

            decimal beginningBalance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;
            balanceDebit = totalBeginningAndTransDebit > totalBeginningAndTransCredit ? Math.Abs(beginningBalance) : 0;
            balanceCredit = totalBeginningAndTransDebit < totalBeginningAndTransCredit ? Math.Abs(beginningBalance) : 0;
        }

        private void GetGovernmentEquityDebitCredit(byte fundId, DateTime dateEntry, out decimal debit, out decimal credit)
        {
            int[] accountGroups = { 3, 4, 5 };
            decimal totalBeginningBalanceDebit = 0;
            decimal totalBeginningBalanceCredit = 0;
            decimal totalTransactionDebit = 0;
            decimal totalTransactionCredit = 0;

            foreach (int accountGroup in accountGroups)
            {
                var dictBeginningBalance = Factory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_AccGrpId_Date_SubLedgeId(fundId, (ushort)accountGroup, dateEntry);
                var dictTransaction = Factory.JEVAccountsRepository().GetSumTransactionsByAccGrpId(fundId, accountGroup, dateEntry);

                totalBeginningBalanceDebit += dictBeginningBalance["beginning_balance_debit"];
                totalBeginningBalanceCredit += dictBeginningBalance["beginning_balance_credit"];

                totalTransactionDebit += dictTransaction["debit"];
                totalTransactionCredit += dictTransaction["credit"];
            }

            decimal totalBeginningAndTransDebit = totalBeginningBalanceDebit + totalTransactionDebit;
            decimal totalBeginningAndTransCredit = totalBeginningBalanceCredit + totalTransactionCredit;

            decimal endingBalance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;
            debit = totalBeginningAndTransDebit > totalBeginningAndTransCredit ? Math.Abs(endingBalance) : 0;
            credit = totalBeginningAndTransDebit < totalBeginningAndTransCredit ? Math.Abs(endingBalance) : 0;
        }

        private DataTable StatementOfFinancialPositionReport()
        {
            var dataSet = new dsLFS();
            var dtStatementOfFinancialPosition = dataSet.dtStatementOfFinancialPosition;
            byte fundId = (byte)cmbxFunds.SelectedValue;
            var dateAsOf = dtAsOf.Value;
            var previousYearEnded = new DateTime(year: dateAsOf.Year - 1, month: 12, DateTime.DaysInMonth(dateAsOf.Year, 12));

            try
            {
                var dtGeneralLedgerAccounts = Factory.GeneralLedgerAccountsRepository().GetViewRecords();
                foreach (DataRow row in dtGeneralLedgerAccounts.Rows)
                {
                    int accGrpId = Convert.ToInt32(row["account_group_id"]);
                    string accGrpCode = row["account_group_code"].ToString();
                    string accGrpName = row["account_group_name"].ToString();
                    int majAccGrpId = Convert.ToInt32(row["major_account_group_id"]);
                    string majAccGrpCode = row["maj_acc_group_code"].ToString();
                    string majAccGrpName = row["maj_acc_group_name"].ToString();
                    int subMajAccGrpId = Convert.ToInt32(row["sub_major_account_group_id"]);
                    string subMajAccGrpCode = row["sub_maj_acc_group_code"].ToString();
                    string subMajAccGrpName = row["sub_maj_acc_group_name"].ToString();
                    ushort genLedgAccId = Convert.ToUInt16(row["general_ledger_accounts_id"]);
                    string genLedgAccCode = row["account_code"].ToString();
                    string genLedgAccName = row["ledger_name"].ToString();

                    decimal presentDebit;
                    decimal presentCredit;
                    decimal previousDebit;
                    decimal previousCredit;

                    if (genLedgAccName == "Government Equity")
                    {
                        GetGovernmentEquityDebitCredit(fundId, dateAsOf, out presentDebit, out presentCredit);
                        GetGovernmentEquityDebitCredit(fundId, previousYearEnded, out previousDebit, out previousCredit);
                    }
                    else
                    {
                        GetDebitCredit(fundId, dateAsOf, genLedgAccId, out presentDebit, out presentCredit);
                        GetDebitCredit(fundId, previousYearEnded, genLedgAccId, out previousDebit, out previousCredit);
                    }

                    decimal presentAmount = presentDebit - presentCredit;
                    decimal previousAmount = previousDebit - previousCredit;

                    var items = new object[]
                    {
                        accGrpId,
                        accGrpCode,
                        accGrpName,
                        majAccGrpId,
                        majAccGrpCode,
                        majAccGrpName,
                        subMajAccGrpId,
                        subMajAccGrpCode,
                        subMajAccGrpName,
                        genLedgAccId,
                        genLedgAccCode,
                        genLedgAccName,
                        presentAmount,
                        previousAmount
                    };

                    dtStatementOfFinancialPosition.Rows.Add(items);
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.StackTrace);
            }

            return dtStatementOfFinancialPosition;
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
                DateTime AsOf = dtAsOf.Value;

                Cursor = Cursors.WaitCursor;
                report.ReportPath = $"{Application.StartupPath}\\Reports\\statement-of-financial-position-report.rdlc";
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("dtStatementOfFinancialPosition", StatementOfFinancialPositionReport()));

                var fundRepo = Factory.FundsRepository().GetRecordByID(fundId);
                var parameters = new[] {
                    new ReportParameter("paramFundName", fundRepo["fund_name"]),
                    new ReportParameter("paramDate", AsOf.ToString("MMMM dd, yyyy")),
                };
                report.SetParameters(parameters);

                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;
                reportViewer.RefreshReport();
                Cursor = Cursors.Default;
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
