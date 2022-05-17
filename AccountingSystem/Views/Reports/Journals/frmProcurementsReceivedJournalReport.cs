using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Journals
{
    public partial class frmProcurementsReceivedJournalReport : Form
    {
        private readonly ReportViewer reportViewer;
        internal int fundId;
        internal string journalName;
        internal DateTime date;
        private byte journalId = 3;

        public frmProcurementsReceivedJournalReport()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }

        private DataTable ProcurementsReceivedJournalDataTable()
        {
            var dtProcurementsReceivedJournal = new dsLFS.ProcurementsReceivedJournalDataTable();
            var dictFund = Factory.FundsRepository().GetRecordByID(fundId);
            var dtProcurementsReceivedFromDB = Factory.JEVAccountsRepository().GetViewRecordsByFundJournalDate(dictFund["fund_name"], journalName, date);

            string jevNo;
            string particulars;

            foreach (DataRow item in dtProcurementsReceivedFromDB.Rows)
            {
                jevNo = item["jev_no"].ToString();
                particulars = item["explanation"].ToString();

                DataRow row = dtProcurementsReceivedJournal.NewRow();
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

                dtProcurementsReceivedJournal.Rows.Add(row);
            }

            return dtProcurementsReceivedJournal;
        }

        private Dictionary<string, string> GetDefaultAccount()
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("defaultAccIdDebit1", "0");
            dictionary.Add("defaultAccIdDebit2", "0");
            dictionary.Add("defaultAccCodeDebit1", string.Empty);
            dictionary.Add("defaultAccCodeDebit2", string.Empty);
            dictionary.Add("defaultAccIdCredit1", "0");
            dictionary.Add("defaultAccIdCredit2", "0");
            dictionary.Add("defaultAccCodeCredit1", string.Empty);
            dictionary.Add("defaultAccCodeCredit2", string.Empty);

            try
            {
                DataTable dtCreditDefaultAccounts = Factory.JournalsDefaultAccountsRepository().GetViewRecordsByJournalId(journalId, fundId, false);

                DataTable dtDebitDefaultAccounts = Factory.JournalsDefaultAccountsRepository().GetViewRecordsByJournalId(journalId, fundId, true);


                //Debit default Accounts

                dictionary["defaultAccIdDebit1"] = ParseDebitAccountIds(0).ToString();
                dictionary["defaultAccIdDebit2"] = ParseDebitAccountIds(1).ToString();

                int ParseDebitAccountIds(int row)
                {
                    if (dtDebitDefaultAccounts.Rows.Count < row + 1)
                        return 0;

                    return Convert.ToInt32(dtDebitDefaultAccounts.Rows[row]["general_ledger_accounts_id"]);
                }


                dictionary["defaultAccCodeDebit1"] = ParseDebitAccountCodes(0);
                dictionary["defaultAccCodeDebit2"] = ParseDebitAccountCodes(1);

                string ParseDebitAccountCodes(int row)
                {
                    if (dtDebitDefaultAccounts.Rows.Count < row + 1)
                        return string.Empty;

                    return dtDebitDefaultAccounts.Rows[row]["account_code"].ToString();
                }


                //Credit default Accounts

                dictionary["defaultAccIdCredit1"] = ParseCreditAccountIds(0).ToString();
                dictionary["defaultAccIdCredit2"] = ParseCreditAccountIds(1).ToString();

                int ParseCreditAccountIds(int row)
                {
                    if (dtCreditDefaultAccounts.Rows.Count < row + 1)
                        return 0;

                    return Convert.ToInt32(dtCreditDefaultAccounts.Rows[row]["general_ledger_accounts_id"].ToString());
                }


                dictionary["defaultAccCodeCredit1"] = ParseCreditAccountCodes(0);
                dictionary["defaultAccCodeCredit2"] = ParseCreditAccountCodes(1);

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

        private void LoadReport(LocalReport report)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var dictSignatory = Helper.GetSignatoryDataBy_Reference_DocumentName("Certified Correct", "Procurement Received Journal");
                static void ParseSignatory(Dictionary<string, string> dictSignatory, ref string signatoryName, ref string signatoryTitle)
                {
                    if (dictSignatory.Count > 0)
                    {
                        signatoryName = dictSignatory["signatories_full_name"];
                        signatoryTitle = dictSignatory["signatories_title"];
                    }
                }

                var lguDetails = Helper.LGUDetails();
                string certifiedCorrectSignatory = string.Empty;
                string certifiedCorrectSignatoryTitle = string.Empty;
                var dictFund = Factory.FundsRepository().GetRecordByID(fundId);
                ParseSignatory(dictSignatory, ref certifiedCorrectSignatory, ref certifiedCorrectSignatoryTitle);

                var parameters = new[] {
                    new ReportParameter("paramDate", date.ToString()),
                    new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                    new ReportParameter("paramFund", $"{dictFund["fund_code"]} - {dictFund["fund_name"]}"),
                    new ReportParameter("paramCertifiedCorrectSignatory", certifiedCorrectSignatory),
                    new ReportParameter("paramCertifiedCorrectSignatoryTitle", certifiedCorrectSignatoryTitle),
                    new ReportParameter("paramDefaultAccCodeDebit1", GetDefaultAccount()["defaultAccCodeDebit1"]),
                    new ReportParameter("paramDefaultAccCodeDebit2", GetDefaultAccount()["defaultAccCodeDebit2"]),
                    new ReportParameter("paramDefaultAccIdDebit1", GetDefaultAccount()["defaultAccIdDebit1"]),
                    new ReportParameter("paramDefaultAccIdDebit2", GetDefaultAccount()["defaultAccIdDebit2"]),
                    new ReportParameter("paramDefaultAccCodeCredit1", GetDefaultAccount()["defaultAccCodeCredit1"]),
                    new ReportParameter("paramDefaultAccCodeCredit2", GetDefaultAccount()["defaultAccCodeCredit2"]),
                    new ReportParameter("paramDefaultAccIdCredit1", GetDefaultAccount()["defaultAccIdCredit1"]),
                    new ReportParameter("paramDefaultAccIdCredit2", GetDefaultAccount()["defaultAccIdCredit2"]),
                };

                report.ReportPath = $"{Application.StartupPath}\\Reports\\procurements-received-journal.rdlc";
                report.DataSources.Clear();

                report.DataSources.Add(new ReportDataSource("ProcurementsReceivedJournal", ProcurementsReceivedJournalDataTable()));
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

        private void frmProcurementsReceivedJournalReport_Load(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }
    }
}
