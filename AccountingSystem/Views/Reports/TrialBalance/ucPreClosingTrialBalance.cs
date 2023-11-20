using ACC.Data;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.TrialBalance
{
    public partial class ucPreClosingTrialBalance : UserControl
    {
        private readonly ReportViewer reportViewer;
        private decimal beginningBalance;

        public ucPreClosingTrialBalance()
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

        private void GetDebitCredit(byte fundId, DateTime dateEntry, ushort generalLedgerId, out decimal balanceDebit, out decimal balanceCredit)
        {
            beginningBalance = 0;
            var dictBeginningBalance = AccFactory.BeginningBalancesRepository().GetSumBalancesBy_FundId_GenLedgId_Date_SubLedgId(fundId, generalLedgerId, dateEntry);
            var dictTransaction = AccFactory.JEVAccountsRepository().GetSumTransactionsByGenLedgerId(fundId, generalLedgerId, dateEntry);

            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];

            beginningBalance = (totalBeginningAndTransDebit - totalBeginningAndTransCredit);
            balanceDebit = totalBeginningAndTransDebit > totalBeginningAndTransCredit ? Math.Abs(beginningBalance) : 0;
            balanceCredit = totalBeginningAndTransDebit < totalBeginningAndTransCredit ? Math.Abs(beginningBalance) : 0;
        }

        private DataTable DataTablePreTrialBalance()
        {
            var fundId = Convert.ToByte(cmbFund.SelectedValue);
            var dateAsOF = dtAsOf.Value;
            var dtPreTrialBalance = new dsLFS().dtTrialBalance;

            var dtGeneralLedgerAccounts = AccFactory.GeneralLedgerAccountsRepository().GetViewRecords();

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

                decimal balanceDebit, balanceCredit;
                GetDebitCredit(fundId, dateAsOF, (ushort)accountId, out balanceDebit, out balanceCredit);

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

            var dictSignatory = Helper.GetSignatoryDataBy_Reference_DocumentName("Certified Correct", "Pre Trial Balance");
            var lguDict = Helper.LGUDetails();
            report.ReportPath = $"{Application.StartupPath}\\Reports\\pre-trial-balance.rdlc";
            report.DataSources.Clear();

            report.DataSources.Add(new ReportDataSource("dtTrialBalance", DataTablePreTrialBalance()));

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
            report.SetParameters(parameters);
            Cursor.Current = Cursors.Default;

            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
            cbHideZeroBalance.Enabled = true;
        }

        private void RecordsFilter(LocalReport report, byte hideZeroBalance)
        {
            var parameters = new[] {
                new ReportParameter("paramHideZeroBalance", hideZeroBalance.ToString())
            };

            reportViewer.LocalReport.SetParameters(parameters);
            reportViewer.RefreshReport();
        }

        private void cbHideZeroBalance_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHideZeroBalance.Checked)
                RecordsFilter(reportViewer.LocalReport, 1);
            else
                RecordsFilter(reportViewer.LocalReport, 0);
        }

        private void OnLoad()
        {
            if (!DesignMode)
            {
                var dtFunds = AccFactory.FundsRepository().GetRecords();
                HelperLoadRecords.FundsComboBox(dtFunds, cmbFund, "fund_name", "id");
            }
        }

        private void ucPreClosingTrialBalance_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}