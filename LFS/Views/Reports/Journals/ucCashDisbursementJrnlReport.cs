using ACC.Data;
using LFS.Helpers;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Reports.Journals
{
    public partial class ucCashDisbursementJrnlReport : UserControl
    {
        public ucCashDisbursementJrnlReport()
        {
            InitializeComponent();
            reportViewer1.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer1);
        }

        internal void OnLoad()
        {
            LoadFunds();
        }

        private void LoadFunds()
        {
            var dtFunds = AccFactory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "fund_name", "id");
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
                LoadReport(reportViewer1);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private Dictionary<string, string> GetDefaultAccount(int journalId, int fundId)
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("defaultAccIdDebit1", "0");
            dictionary.Add("defaultAccIdDebit2", "0");
            dictionary.Add("defaultAccIdDebit3", "0");
            dictionary.Add("defaultAccCodeDebit1", string.Empty);
            dictionary.Add("defaultAccCodeDebit2", string.Empty);
            dictionary.Add("defaultAccCodeDebit3", string.Empty);
            dictionary.Add("defaultAccIdCredit1", "0");
            dictionary.Add("defaultAccIdCredit2", "0");
            dictionary.Add("defaultAccIdCredit3", "0");
            dictionary.Add("defaultAccCodeCredit1", string.Empty);
            dictionary.Add("defaultAccCodeCredit2", string.Empty);
            dictionary.Add("defaultAccCodeCredit3", string.Empty);

            DataTable dtCreditDefaultAccounts = AccFactory.JournalsDefaultAccountsRepository().GetViewRecordsByJournalId(journalId, fundId, false);

            DataTable dtDebitDefaultAccounts = AccFactory.JournalsDefaultAccountsRepository().GetViewRecordsByJournalId(journalId, fundId, true);

            //Debit default Accounts

            dictionary["defaultAccIdDebit1"] = ParseDebitAccountIds(0).ToString();
            dictionary["defaultAccIdDebit2"] = ParseDebitAccountIds(1).ToString();
            dictionary["defaultAccIdDebit3"] = ParseDebitAccountIds(2).ToString();

            int ParseDebitAccountIds(int row)
            {
                if (dtDebitDefaultAccounts.Rows.Count < row + 1)
                    return 0;

                return Convert.ToInt32(dtDebitDefaultAccounts.Rows[row]["general_ledger_accounts_id"]);
            }

            dictionary["defaultAccCodeDebit1"] = ParseDebitAccountCodes(0);
            dictionary["defaultAccCodeDebit2"] = ParseDebitAccountCodes(1);
            dictionary["defaultAccCodeDebit3"] = ParseDebitAccountCodes(2);

            string ParseDebitAccountCodes(int row)
            {
                if (dtDebitDefaultAccounts.Rows.Count < row + 1)
                    return string.Empty;

                return dtDebitDefaultAccounts.Rows[row]["account_code"].ToString();
            }

            //Credit default Accounts

            dictionary["defaultAccIdCredit1"] = ParseCreditAccountIds(0).ToString();
            dictionary["defaultAccIdCredit2"] = ParseCreditAccountIds(1).ToString();
            dictionary["defaultAccIdCredit3"] = ParseCreditAccountIds(2).ToString();

            int ParseCreditAccountIds(int row)
            {
                if (dtCreditDefaultAccounts.Rows.Count < row + 1)
                    return 0;

                return Convert.ToInt32(dtCreditDefaultAccounts.Rows[row]["general_ledger_accounts_id"].ToString());
            }

            dictionary["defaultAccCodeCredit1"] = ParseCreditAccountCodes(0);
            dictionary["defaultAccCodeCredit2"] = ParseCreditAccountCodes(1);
            dictionary["defaultAccCodeCredit3"] = ParseCreditAccountCodes(2);

            string ParseCreditAccountCodes(int row)
            {
                if (dtCreditDefaultAccounts.Rows.Count < row + 1)
                    return string.Empty;

                return dtCreditDefaultAccounts.Rows[row]["account_code"].ToString();
            }

            return dictionary;
        }

        private void ParseSignatory(Dictionary<string, string> dictSignatory, ref string signatory, ref string signatoryTitle)
        {
            if (dictSignatory.Count > 0)
            {
                signatory = dictSignatory["signatories_full_name"];
                signatoryTitle = dictSignatory["signatories_title"];
            }
        }

        private void LoadReport(ReportViewer reportViewer)
        {
            Cursor.Current = Cursors.WaitCursor;

            var localReport = reportViewer.LocalReport;
            int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
            var date = dateTimePicker1.Value;
            string journalName = "Cash Disbursements Journal";
            int journalId = 4;

            var dtCashDisbursementsJournal = new dsLFS.CashDisbursementsJournalDataTable();
            var dictFund = AccFactory.FundsRepository().GetRecordByID(fundId);
            var dtCashDisbursementFromDB = AccFactory.JEVAccountsRepository().GetViewRecordsByFundJournalDate(dictFund["fund_name"], journalName, date);

            string jevNo;
            string particulars;

            foreach (DataRow item in dtCashDisbursementFromDB.Rows)
            {
                jevNo = item["jev_no"].ToString();
                particulars = item["explanation"].ToString();

                DataRow row = dtCashDisbursementsJournal.NewRow();
                row["date"] = item["date_entry"];
                row["ref"] = jevNo;
                row["particulars"] = particulars;

                if (Convert.ToBoolean(item["is_debit"]))
                {
                    row["account_id_debit"] = item["general_ledger_accounts_id"];
                    row["account_code_debit"] = item["account_code"];
                    row["debit"] = item["amount"];
                }
                else
                {
                    row["account_id_credit"] = item["general_ledger_accounts_id"];
                    row["account_code_credit"] = item["account_code"];
                    row["credit"] = item["amount"];
                }

                dtCashDisbursementsJournal.Rows.Add(row);
            }

            var dictSignatory = Helper.GetSignatoryDataBy_Reference_DocumentName("Certified Correct", "Cash Disbursements Journal");
            var certifiedCorrectSignatory = string.Empty;
            var certifiedCorrectSignatoryTitle = string.Empty;
            ParseSignatory(dictSignatory, ref certifiedCorrectSignatory, ref certifiedCorrectSignatoryTitle);

            string lguName = $"{ServerHelper.selectedServer.MunicipalityName} - {ServerHelper.selectedServer.ProvinceName}";

            var parameters = new ReportParameter[]
            {
                new("paramDate", date.ToString()),
                new("paramLGUName", lguName),
                new("paramFund", $"{dictFund["fund_code"]} - {dictFund["fund_name"]}"),
                new("paramCertifiedCorrectSignatory", certifiedCorrectSignatory),
                new("paramCertifiedCorrectSignatoryTitle", certifiedCorrectSignatoryTitle),
                new("paramDefaultAccCodeDebit1",GetDefaultAccount(journalId, fundId)["defaultAccCodeDebit1"]),
                new("paramDefaultAccCodeDebit2",GetDefaultAccount(journalId, fundId)["defaultAccCodeDebit2"]),
                new("paramDefaultAccCodeDebit3",GetDefaultAccount(journalId, fundId)["defaultAccCodeDebit3"]),
                new("paramDefaultAccIdDebit1",GetDefaultAccount(journalId, fundId)["defaultAccIdDebit1"]),
                new("paramDefaultAccIdDebit2",GetDefaultAccount(journalId, fundId)["defaultAccIdDebit2"]),
                new("paramDefaultAccIdDebit3",GetDefaultAccount(journalId, fundId)["defaultAccIdDebit3"]),
                new("paramDefaultAccCodeCredit1",GetDefaultAccount(journalId, fundId)["defaultAccCodeCredit1"]),
                new("paramDefaultAccCodeCredit2",GetDefaultAccount(journalId, fundId)["defaultAccCodeCredit2"]),
                new("paramDefaultAccCodeCredit3",GetDefaultAccount(journalId, fundId)["defaultAccCodeCredit3"]),
                new("paramDefaultAccIdCredit1",GetDefaultAccount(journalId, fundId)["defaultAccIdCredit1"]),
                new("paramDefaultAccIdCredit2",GetDefaultAccount(journalId, fundId)["defaultAccIdCredit2"]),
                new("paramDefaultAccIdCredit3",GetDefaultAccount(journalId, fundId)["defaultAccIdCredit3"]),
            };

            localReport.ReportPath = $"{Application.StartupPath}\\Reports\\cash-disbursement-journal.rdlc";
            localReport.DataSources.Clear();

            localReport.DataSources.Add(new ReportDataSource("CashDisbursementsJournal", dtCashDisbursementsJournal.Clone()));
            localReport.SetParameters(parameters);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.PageWidth;
            reportViewer.RefreshReport();
            Cursor.Current = Cursors.Default;
        }
    }
}