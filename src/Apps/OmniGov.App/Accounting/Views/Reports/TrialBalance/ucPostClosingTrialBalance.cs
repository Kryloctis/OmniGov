using Accounting.Data.Factories;
using Microsoft.Reporting.WinForms;
using OmniGov.App.Helpers;
using OmniGov.Core.Factories;
using System.Data;

namespace OmniGov.App.Accounting.Views.Reports.TrialBalance
{
    public partial class ucPostClosingTrialBalance : UserControl
    {
        private readonly ReportViewer reportViewer;

        public ucPostClosingTrialBalance()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panelReport.Controls.Add(reportViewer);
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            try
            {
                LoadReport(reportViewer.LocalReport);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void RecordsFilter(LocalReport report, byte hideZeroBalance)
        {
            var parameters = new[]
            {
                new ReportParameter("paramHideZeroBalance", hideZeroBalance.ToString())
            };

            report.SetParameters(parameters);
            reportViewer.RefreshReport();
        }

        private void GetDebitCredit(byte fundId, DateTime dateEntry, ushort generalLedgerId, out decimal balanceDebit, out decimal balanceCredit)
        {
            decimal beginningBalance;
            var dictBeginningBalance = AccountingFactory.BeginningBalancesRepository().GetSumBalancesBy_FundId_GenLedgId_Date_SubLedgId(fundId, generalLedgerId, dateEntry);
            var dictTransaction = AccountingFactory.JEVAccountsRepository().GetSumTransactionsByGenLedgerId(fundId, generalLedgerId, dateEntry);

            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];

            beginningBalance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;
            balanceDebit = totalBeginningAndTransDebit > totalBeginningAndTransCredit ? Math.Abs(beginningBalance) : 0;
            balanceCredit = totalBeginningAndTransDebit < totalBeginningAndTransCredit ? Math.Abs(beginningBalance) : 0;
        }

        private void GetGovernmentEquityDebitCredit(byte fundId, DateTime dateEntry, out decimal governmentEquityDebit, out decimal governmentEquityCredit)
        {
            int[] accountGroups = { 3, 4, 5 };
            decimal totalBeginningBalanceDebit = 0;
            decimal totalBeginningBalanceCredit = 0;
            decimal totalTransactionDebit = 0;
            decimal totalTransactionCredit = 0;

            foreach (int accountGroup in accountGroups)
            {
                var dictBeginningBalance = AccountingFactory.BeginningBalancesRepository().GetSumBeginningBalanceBy_FundId_AccGrpId_Date_SubLedgeId(fundId, (ushort)accountGroup, dateEntry);
                var dictTransaction = AccountingFactory.JEVAccountsRepository().GetSumTransactionsByAccGrpId(fundId, accountGroup, dateEntry);

                totalBeginningBalanceDebit += dictBeginningBalance["beginning_balance_debit"];
                totalBeginningBalanceCredit += dictBeginningBalance["beginning_balance_credit"];

                totalTransactionDebit += dictTransaction["debit"];
                totalTransactionCredit += dictTransaction["credit"];
            }

            decimal totalBeginningAndTransDebit = totalBeginningBalanceDebit + totalTransactionDebit;
            decimal totalBeginningAndTransCredit = totalBeginningBalanceCredit + totalTransactionCredit;

            decimal endingBalance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;
            governmentEquityDebit = totalBeginningAndTransDebit > totalBeginningAndTransCredit ? Math.Abs(endingBalance) : 0;
            governmentEquityCredit = totalBeginningAndTransDebit < totalBeginningAndTransCredit ? Math.Abs(endingBalance) : 0;
        }

        private DataTable DataTablePostTrialBalance()
        {
            var fundId = Convert.ToByte(cmbFund.SelectedValue);
            var dateAsOF = dtAsOf.Value;
            var dtPreTrialBalance = new dsLFS().dtTrialBalance;

            var dtGeneralLedgerAccounts = AccountingFactory.GeneralLedgerAccountsRepository().GetViewRecords();

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
                int genLedgAccId = Convert.ToInt32(row["general_ledger_accounts_id"]);
                string genLedgAccCode = row["account_code"].ToString();
                string genLedgAccName = row["ledger_name"].ToString();

                decimal balanceDebit, balanceCredit;

                if (genLedgAccName == "Government Equity")
                    GetGovernmentEquityDebitCredit(fundId, dateAsOF, out balanceDebit, out balanceCredit);
                else
                {
                    if (accountGroupId == 3 || accountGroupId == 4 || accountGroupId == 5) break;
                    GetDebitCredit(fundId, dateAsOF, (ushort)genLedgAccId, out balanceDebit, out balanceCredit);
                }

                var items = new object[]
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
                    genLedgAccId,
                    genLedgAccCode,
                    genLedgAccName,
                    balanceDebit,
                    balanceCredit
                };

                dtPreTrialBalance.Rows.Add(items);
            }

            return dtPreTrialBalance;
        }

        private void ParseSignatory(Dictionary<string, string> dictSignatory, ref string signatoryName, ref string signatoryTitle)
        {
            if (dictSignatory.Count > 0)
            {
                signatoryName = dictSignatory["signatories_full_name"];
                signatoryTitle = dictSignatory["signatories_title"];
            }
        }

        private void LoadReport(LocalReport report)
        {
            Cursor.Current = Cursors.WaitCursor;

            var dictSignatory = Helper.GetSigtryByRefDoc("Certified Correct", "Post Trial Balance");
            report.ReportPath = $"{Application.StartupPath}\\Reports\\post-trial-balance.rdlc";
            report.DataSources.Clear();

            report.DataSources.Add(new ReportDataSource("dtTrialBalance", DataTablePostTrialBalance()));

            var certifiedCorrectSignatory = string.Empty;
            var certifiedCorrectSignatoryTitle = string.Empty;
            ParseSignatory(dictSignatory, ref certifiedCorrectSignatory, ref certifiedCorrectSignatoryTitle);

            var fundName = cmbFund.Text;
            var asOfDate = dtAsOf.Value.ToString("MMMM dd, yyyy");

            var parameters = new ReportParameter[]
            {
                new("paramLGUName", (ServerHelper.SelectedProfile?.Name ?? "")),
                new("paramFund", fundName),
                new("paramCertifiedCorrectSignatory", certifiedCorrectSignatory),
                new("paramCertifiedCorrectSignatoryTitle", certifiedCorrectSignatoryTitle),
                new("paramAsOf", asOfDate),
            };

            cbHideZeroBalance.Enabled = true;
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;

            report.SetParameters(parameters);
            reportViewer.RefreshReport();
            Cursor.Current = Cursors.Default;
        }

        private void cbHideZeroBalance_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbHideZeroBalance.Checked)
                    RecordsFilter(reportViewer.LocalReport, 1);
                else
                    RecordsFilter(reportViewer.LocalReport, 0);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void OnLoad()
        {
            var dtFunds = Factory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbFund, "id", "fund_name");
        }
    }
}



