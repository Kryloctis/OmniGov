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
            decimal beginningBalance;
            var dictBeginningBalance = Factory.BeginningBalancesRepository().GetSumBalances(fundsId, generalLedgerId, dateEntry);
            var dictTransaction = Factory.JEVAccountsRepository().GetSumTransactionsByGenLedgerId(fundsId, generalLedgerId, dateEntry);

            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];

            beginningBalance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;
            balanceDebit = totalBeginningAndTransDebit > totalBeginningAndTransCredit ? Math.Abs(beginningBalance) : 0;
            balanceCredit = totalBeginningAndTransDebit < totalBeginningAndTransCredit ? Math.Abs(beginningBalance) : 0;
        }

        private DataTable StatementOfFinancialPositionReport()
        {
            var dataSet = new dsLFS();
            var dtStatementOfFinancialPerformance = dataSet.dtStatementOfFinancialPerformance;
            byte fundId = (byte)cmbxFunds.SelectedValue;
            var dateAsOf = dtAsOf.Value;
            var previousYearEnded = new DateTime(year: dateAsOf.Year - 1, month: 12, DateTime.DaysInMonth(dateAsOf.Year, 12));

            try
            {
                var dtJEVAccounts = Factory.JEVAccountsRepository().GetViewRecordsByLedgerAccounts();
                foreach (DataRow row in dtJEVAccounts.Rows)
                {
                    ushort accountId = Convert.ToUInt16(row["general_ledger_accounts_id"]);
                    decimal balanceDebit = 0;
                    decimal balanceCredit = 0;
                    decimal previousBalanceDebit = 0;
                    decimal previousBalanceCredit = 0;

                    GetDebitCredit(fundId, dateAsOf, accountId, out balanceDebit, out balanceCredit);
                    GetDebitCredit(fundId, previousYearEnded, accountId, out previousBalanceDebit, out previousBalanceCredit);

                    decimal currentAmount = balanceDebit - balanceCredit;
                    decimal previousAmount = previousBalanceDebit - previousBalanceCredit;

                    var items = new object[]
                    {
                    row["account_group_id"],
                    row["account_group_code"],
                    row["account_group_name"],
                    row["maj_acc_group_id"],
                    row["maj_acc_group_code"],
                    row["maj_acc_group_name"],
                    row["sub_maj_acc_group_id"],
                    row["sub_maj_acc_group_code"],
                    row["sub_maj_acc_group_name"],
                    row["general_ledger_accounts_id"],
                    row["account_code"],
                    row["general_ledger_accounts_name"],
                    currentAmount,
                    previousAmount
                    };

                    dtStatementOfFinancialPerformance.Rows.Add(items);
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return dtStatementOfFinancialPerformance;
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
