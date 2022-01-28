using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Journals
{
    public partial class frmCashReceiptsJournalReport : Form
    {
        private readonly ReportViewer reportViewer;
        internal string fundName;
        internal string journalName;
        internal int fundId;
        internal DateTime date;
        private byte journalId = 2;

        public frmCashReceiptsJournalReport()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
            Helper.LoadFormIcon(this);
        }

        private DataTable CashReceiptsJournalDataTable()
        {
            var dtCashReceiptsJournal = new dsLFS.CashReceiptsJournalDataTable();
            var dtCashReceiptsFromDB = Factory.JEVAccountsRepository().GetViewRecordsByFundJournalDate(fundName, journalName, date);

            int jevId;
            string jevNo;

            var cashReceiptsJournalRepository = Factory.CashReceiptsJournalRepository();
            foreach (DataRow item in dtCashReceiptsFromDB.Rows)
            {
                jevId = Convert.ToInt32(item["jev_id"]);
                jevNo = item["jev_no"].ToString();

                var cashReceiptsDict = cashReceiptsJournalRepository.GetViewRecordByJevID(jevId);
                DataRow row = dtCashReceiptsJournal.NewRow();
                row["date"] = item["date_entry"];
                row["rcd_no"] = cashReceiptsDict["rcd_no"];
                row["collecting_officer"] = cashReceiptsDict["full_name"];

                // if data is for collections columns
                if (!Convert.ToBoolean(item["is_deposit"]))
                {
                    row["collections_credit_account_code"] = item["account_code"];
                    if (Convert.ToBoolean(item["is_debit"]))
                    {
                        row["collections_debit_account_id"] = item["general_ledger_accounts_id"];
                        row["collections_debit_amount"] = item["amount"];
                    }
                    else
                    {
                        row["collections_credit_account_id"] = item["general_ledger_accounts_id"];
                        row["collections_credit_amount"] = item["amount"];
                    }
                }

                // if data is for deposits columns
                if (Convert.ToBoolean(item["is_deposit"]))
                {
                    row["deposit_debit_account_code"] = item["account_code"];
                    if (Convert.ToBoolean(item["is_debit"]))
                    {
                        row["deposit_debit_account_id"] = item["general_ledger_accounts_id"];
                        row["deposit_debit_amount"] = item["amount"];
                    }
                    else
                    {
                        row["deposit_credit_account_id"] = item["general_ledger_accounts_id"];
                        row["deposit_credit_amount"] = item["amount"];
                    }
                }



                dtCashReceiptsJournal.Rows.Add(row);
            }

            return dtCashReceiptsJournal;
        }

        private Dictionary<string, string> GetDefaultAccount()
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

            try
            {
                DataTable dtCreditDefaultAccounts = Factory.JournalsDefaultAccountsRepository().GetViewRecordsByJournalId(journalId, fundId, false);

                DataTable dtDebitDefaultAccounts = Factory.JournalsDefaultAccountsRepository().GetViewRecordsByJournalId(journalId, fundId, true);


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

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.StackTrace);
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

        private void LoadReport(LocalReport report)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var dictSignatory = Helper.GetSignatoryDataBy_Reference_DocumentName("Certified Correct", "Cash Receipts Journal");
                var lguDetails = Helper.LGUDetails();
                var certifiedCorrectSignatory = string.Empty;
                var certifiedCorrectSinatoryTitle = string.Empty;
                ParseSignatory(dictSignatory, ref certifiedCorrectSignatory, ref certifiedCorrectSinatoryTitle);

                var parameters = new[] {
                    new ReportParameter("paramMonth", date.ToString()),
                    new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                    new ReportParameter("paramFund", fundName),
                    new ReportParameter("paramCertifiedCorrectSignatory", certifiedCorrectSignatory),
                    new ReportParameter("paramCertifiedCorrectSignatoryTitle", certifiedCorrectSinatoryTitle),
                    new ReportParameter("paramDefaultAccCodeDebit1",GetDefaultAccount()["defaultAccCodeDebit1"]),
                    new ReportParameter("paramDefaultAccCodeDebit2",GetDefaultAccount()["defaultAccCodeDebit2"]),
                    new ReportParameter("paramDefaultAccCodeDebit3",GetDefaultAccount()["defaultAccCodeDebit3"]),
                    new ReportParameter("paramDefaultAccIdDebit1",GetDefaultAccount()["defaultAccIdDebit1"]),
                    new ReportParameter("paramDefaultAccIdDebit2",GetDefaultAccount()["defaultAccIdDebit2"]),
                    new ReportParameter("paramDefaultAccIdDebit3",GetDefaultAccount()["defaultAccIdDebit3"]),
                    new ReportParameter("paramDefaultAccCodeCredit1",GetDefaultAccount()["defaultAccCodeCredit1"]),
                    new ReportParameter("paramDefaultAccCodeCredit2",GetDefaultAccount()["defaultAccCodeCredit2"]),
                    new ReportParameter("paramDefaultAccCodeCredit3",GetDefaultAccount()["defaultAccCodeCredit3"]),
                    new ReportParameter("paramDefaultAccIdCredit1",GetDefaultAccount()["defaultAccIdCredit1"]),
                    new ReportParameter("paramDefaultAccIdCredit2",GetDefaultAccount()["defaultAccIdCredit2"]),
                    new ReportParameter("paramDefaultAccIdCredit3",GetDefaultAccount()["defaultAccIdCredit3"]),
                    new ReportParameter("paramDefaultAccountCodeCollectionsDebit", "1-01-01-010"),
                    new ReportParameter("paramDefaultAccountIdCollectionsDebit", "1"),
                    new ReportParameter("paramDefaultAccountCodeDepositsCredit", "1-01-01-010"),
                    new ReportParameter("paramDefaultAccountIdDepositsCredit", "1"),
                };

                report.ReportPath = $"{Application.StartupPath}\\Reports\\cash-receipts-journal.rdlc";
                report.DataSources.Clear();

                report.DataSources.Add(new ReportDataSource("CashReceiptsJournal", CashReceiptsJournalDataTable()));
                report.SetParameters(parameters);
                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;
                reportViewer.RefreshReport();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void frmCashReceiptsJournalReport_Load(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }
    }
}
