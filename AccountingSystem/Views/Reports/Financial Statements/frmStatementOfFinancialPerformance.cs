using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Financial_Statements
{
    public partial class frmStatementOfFinancialPerformance : Form
    {
        private readonly ReportViewer reportViewer;

        public frmStatementOfFinancialPerformance()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }

        private decimal GetBalances(int fundId, int generalLedgerAccountId, DateTime dateEntry)
        {
            decimal transactionDebit = Factory.JEVAccountsRepository().GetSumTransactionsByFundAndAccountAndIsDebitAndDateEntry(fundId, generalLedgerAccountId, true, dateEntry);
            decimal transactionCredit = Factory.JEVAccountsRepository().GetSumTransactionsByFundAndAccountAndIsDebitAndDateEntry(fundId, generalLedgerAccountId, false, dateEntry);

            decimal transactionBalance = Math.Max(transactionDebit, transactionCredit) - Math.Min(transactionDebit, transactionCredit);

            return transactionBalance;
        }


        private DataTable StatementOfFinancialPerformanceDatatable()
        {
            Cursor.Current = Cursors.WaitCursor;
            var dataSet = new dsLFS();
            var dtStatementOfFinancialPerformance = dataSet.dtStatementOfFinancialPerformance;
            int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
            var dateEnded = dtPickerDateEnds.Value;

            try
            {
                var dtGeneralLedgerAccounts = Factory.GeneralLedgerAccountsRepository().GetViewRecords();
                foreach (DataRow row in dtGeneralLedgerAccounts.Rows)
                {
                    var items = new object[]
                    {
                    null,
                    null,
                    null,
                    row["account_group_id"],
                    row["account_group_code"],
                    row["account_group_name"],
                    row["major_account_group_id"],
                    row["maj_acc_group_code"],
                    row["maj_acc_group_name"],
                    row["sub_major_account_group_id"],
                    row["sub_maj_acc_group_code"],
                    row["sub_maj_acc_group_name"],
                    row["general_ledger_accounts_id"],
                    row["account_code"],
                    row["ledger_name"],
                    null,
                    GetBalances(fundId, Convert.ToInt32(row["general_ledger_accounts_id"]), dateEnded)
                    };
                    dtStatementOfFinancialPerformance.Rows.Add(items);
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return dtStatementOfFinancialPerformance;
            Cursor.Current = Cursors.Default;
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
                DateTime dateEnded = dtPickerDateEnds.Value;


                report.ReportPath = $"{Application.StartupPath}\\Reports\\statement-of-financial-performance.rdlc";
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("dtStatementOfFinancialPerformance", StatementOfFinancialPerformanceDatatable()));

                var fundRepo = Factory.FundsRepository().GetRecordByID(fundId);
                var parameters = new[] {
                    new ReportParameter("paramFund", fundRepo["fund_name"]),
                    new ReportParameter("paramDateEnded", dateEnded.ToString("MMMM dd, yyyy")),
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

        private void frmStatementOfFinancialPerformance_Load(object sender, EventArgs e)
        {
            LoadFunds();
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }
    }
}
