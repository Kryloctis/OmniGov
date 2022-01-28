using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.TrialBalance
{
    public partial class ucPostClosingTrialBalance : UserControl
    {

        private readonly ReportViewer reportViewer;
        private decimal beginningBalance;

        public ucPostClosingTrialBalance()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panelReport.Controls.Add(reportViewer);
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }

        private void RecordsFilter(LocalReport report, byte hideZeroBalance)
        {
            var parameters = new[] {
                        new ReportParameter("paramHideZeroBalance", hideZeroBalance.ToString())
                };

            reportViewer.LocalReport.SetParameters(parameters);
            reportViewer.RefreshReport();
        }

        private void GetDebitCredit(byte fundId, DateTime dateEntry, ushort generalLedgerId, out decimal balanceDebit, out decimal balanceCredit)
        {
            beginningBalance = 0;
            var dictBeginningBalance = Factory.BeginningBalancesRepository().GetSumBalances(fundId, generalLedgerId, dateEntry);
            var dictTransaction = Factory.JEVAccountsRepository().GetSumTransactions(fundId, generalLedgerId, dateEntry);

            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["transaction_debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["transaction_credit"];

            beginningBalance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;
            balanceDebit = totalBeginningAndTransDebit > totalBeginningAndTransCredit ? Math.Abs(beginningBalance) : 0;
            balanceCredit = totalBeginningAndTransDebit < totalBeginningAndTransCredit ? Math.Abs(beginningBalance) : 0;
        }

        private void GetGovernmentEquityDebitCredit(byte fundId, DateTime dateEntry, out decimal governmentEquityDebit, out decimal governmentEquityCredit)
        {
            beginningBalance = 0;
            int[] accountGroups = { 3, 4, 5 };
            decimal totalBeginningBalanceDebit = 0;
            decimal totalTransactionDebit = 0;
            decimal totalBeginningBalanceCredit = 0;
            decimal totalTransactionCredit = 0;

            foreach (int item in accountGroups)
            {
                var dictBeginningBalance = Factory.BeginningBalancesRepository().GetSumBalancesByAccountGroup(fundId, (ushort)item, dateEntry);
                var dictTransaction = Factory.JEVAccountsRepository().GetSumTransactionsByAccountGroup(fundId, item, dateEntry);

                totalBeginningBalanceDebit += dictBeginningBalance["beginning_balance_debit"];
                totalBeginningBalanceCredit += +dictBeginningBalance["beginning_balance_credit"];

                totalTransactionDebit += dictTransaction["transaction_debit"];
                totalTransactionCredit += +dictTransaction["transaction_credit"];
            }

            decimal totalBeginningAndTransDebit = totalBeginningBalanceDebit + totalTransactionDebit;
            decimal totalBeginningAndTransCredit = totalBeginningBalanceCredit + totalTransactionCredit;

            beginningBalance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;
            governmentEquityDebit = totalBeginningAndTransDebit > totalBeginningAndTransCredit ? Math.Abs(beginningBalance) : 0;
            governmentEquityCredit = totalBeginningAndTransDebit < totalBeginningAndTransCredit ? Math.Abs(beginningBalance) : 0;
        }

        private DataTable DataTablePostTrialBalance()
        {
            var fundId = Convert.ToByte(cmbFund.SelectedValue);
            var dateAsOF = dtAsOf.Value;
            var dtPreTrialBalance = new dsLFS().dtTrialBalance;

            var dtGeneralLedgerAccounts = Factory.GeneralLedgerAccountsRepository().GetViewRecords();

            foreach (DataRow row in dtGeneralLedgerAccounts.Rows)
            {
                int accountGroupId = Convert.ToInt32(row["account_group_id"]);
                string accountGroupCode = row["account_group_code"].ToString();
                string accountGroupName = row["account_group_name"].ToString();
                int majorAccountGroupId = Convert.ToInt32(row["major_account_group_id"]);
                string majorAccountGroupCode = row["maj_acc_group_code"].ToString();
                string majorAccountGroupName = row["maj_acc_group_name"].ToString();
                int subMajorAccountGroupId = Convert.ToInt32(row["sub_major_account_group_id"]);
                string subMajorAccountGroupCode = row["sub_maj_acc_group_code"].ToString();
                string subMajorAccountGroupName = row["sub_maj_acc_group_name"].ToString();
                int accountId = Convert.ToInt32(row["general_ledger_accounts_id"]);
                string accountCode = row["account_code"].ToString();
                string accountName = row["ledger_name"].ToString();

                if (accountId == 331)
                {
                    decimal governmentEquityDebit, governmentEquityCredit;
                    GetGovernmentEquityDebitCredit(fundId, dateAsOF, out governmentEquityDebit, out governmentEquityCredit);

                    dtPreTrialBalance.Rows.Add(new object[]
                    {
                            accountGroupId,
                            accountGroupCode,
                            accountGroupName,
                            majorAccountGroupId,
                            majorAccountGroupCode,
                            majorAccountGroupName,
                            subMajorAccountGroupId,
                            subMajorAccountGroupCode,
                            subMajorAccountGroupName,
                            accountId,
                            accountCode,
                            accountName,
                            governmentEquityDebit,
                            governmentEquityCredit
                    });
                }

                //
                decimal balanceDebit, balanceCredit;
                GetDebitCredit(fundId, dateAsOF, (ushort)accountId, out balanceDebit, out balanceCredit);

                if (accountGroupId == 3 || accountGroupId == 4 || accountGroupId == 5) break;

                dtPreTrialBalance.Rows.Add(new object[]
                {
                        accountGroupId,
                        accountGroupCode,
                        accountGroupName,
                        majorAccountGroupId,
                        majorAccountGroupCode,
                        majorAccountGroupName,
                        subMajorAccountGroupId,
                        subMajorAccountGroupCode,
                        subMajorAccountGroupName,
                        accountId,
                        accountCode,
                        accountName,
                        balanceDebit,
                        balanceCredit
                });
            }



            return dtPreTrialBalance;
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var dictSignatory = Factory.SignatoriesHasReferencesRepository().GetSignatoryBy_Reference_DocumentName("Certified Correct", "Post Trial Balance");
                static void ParseSignatory(Dictionary<string, string> dictSignatory, ref string signatory, ref string signatoryTitle)
                {
                    if (dictSignatory.Count > 0)
                    {
                        string prefix = dictSignatory["signatories_prefix"].ToString();
                        string firstName = dictSignatory["signatories_first_name"].ToString();
                        char middleInitial = Convert.ToChar(dictSignatory["signatories_middle_initial"]);
                        string lastName = dictSignatory["signatories_last_name"].ToString();
                        string suffix = dictSignatory["signatories_suffix"].ToString();

                        string signatoryName = $"{(string.IsNullOrEmpty(prefix) ? string.Empty : $"{prefix}.")} {firstName} {middleInitial}. {lastName}{(string.IsNullOrEmpty(suffix) ? string.Empty : $", {suffix}")}";

                        signatory = signatoryName;
                        signatoryTitle = dictSignatory["signatories_title"];
                    }
                }

                var lguDict = Helper.LGUDetails();
                report.ReportPath = $"{Application.StartupPath}\\Reports\\post-trial-balance.rdlc";
                report.DataSources.Clear();

                report.DataSources.Add(new ReportDataSource("dtTrialBalance", DataTablePostTrialBalance()));

                var certifiedCorrectSignatory = string.Empty;
                var certifiedCorrectSignatoryTitle = string.Empty;
                ParseSignatory(dictSignatory, ref certifiedCorrectSignatory, ref certifiedCorrectSignatoryTitle);

                var fundName = cmbFund.Text;
                var asOfDate = dtAsOf.Value.ToString("MMMM dd, yyyy");

                var parameters = new[] {
                        new ReportParameter("paramLGUName", lguDict["lgu_name"]),
                        new ReportParameter("paramFund", fundName),
                        new ReportParameter("paramCertifiedCorrectSignatory", certifiedCorrectSignatory),
                        new ReportParameter("paramCertifiedCorrectSignatoryTitle", certifiedCorrectSignatoryTitle),
                        new ReportParameter("paramAsOf", asOfDate),
                      };

                cbHideZeroBalance.Enabled = true;
                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;

                report.SetParameters(parameters);
                reportViewer.RefreshReport();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void cbHideZeroBalance_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHideZeroBalance.Checked)
                RecordsFilter(reportViewer.LocalReport, 1);
            else
                RecordsFilter(reportViewer.LocalReport, 0);
        }

        private void ucPostClosingTrialBalance_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                var dtFunds = Factory.FundsRepository().GetRecords();
                HelperLoadRecords.FundsComboBox(dtFunds, cmbFund, "fund_name", "id");
            }
        }
    }
}
