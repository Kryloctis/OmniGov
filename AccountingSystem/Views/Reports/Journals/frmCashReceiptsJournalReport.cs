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
                        row["collections_credt_amount"] = item["amount"];
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

        private void LoadReport(LocalReport report)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var dictSignatory = Factory.SignatoriesHasReferencesRepository().GetSignatoryByReferenceAndDocumentName("Certified Correct", "Cash Receipts Journal");
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

                var lguDetails = Helper.LGUDetails();
                var certifiedCorrectSignatory = string.Empty;
                var certifiedCorrectSinatoryTitle = string.Empty;
                ParseSignatory(dictSignatory, ref certifiedCorrectSignatory, ref certifiedCorrectSinatoryTitle);

                byte journalId = 2;

                DataTable defaultAccountsDataTable = Factory.JournalsDefaultAccountsRepository().GetViewRecordsByJournalId(journalId, fundId);


                string defaultAccountCode(int rowNo)
                {
                    if (defaultAccountsDataTable.Rows.Count - 1 < rowNo || defaultAccountsDataTable.Rows.Count == 0)
                        return string.Empty;

                    return defaultAccountsDataTable.Rows[rowNo]["account_code"].ToString();
                }

                int defaultAccountId(int rowNo)
                {
                    if (defaultAccountsDataTable.Rows.Count - 1 < rowNo || defaultAccountsDataTable.Rows.Count == 0)
                        return 0;

                    return Convert.ToInt32(defaultAccountsDataTable.Rows[rowNo]["general_ledger_accounts_id"]);
                }

                string defaultAccountCodeFirst = defaultAccountCode(0);
                string defaultAccountCodeSecond = defaultAccountCode(1);
                string defaultAccountCodeThird = defaultAccountCode(2);

                int defaultAccountIDFirst = defaultAccountId(0);
                int defaultAccountIDSecond = defaultAccountId(1);
                int defaultAccountIDThird = defaultAccountId(2);


                var parameters = new[] {
                    new ReportParameter("paramMonth", date.ToString()),
                    new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                    new ReportParameter("paramFund", fundName),
                    new ReportParameter("paramCertifiedCorrectSignatory", certifiedCorrectSignatory),
                    new ReportParameter("paramCertifiedCorrectSignatoryTitle", certifiedCorrectSinatoryTitle),
                    new ReportParameter("paramDefaultAccountCodeFirst", defaultAccountCodeFirst),
                    new ReportParameter("paramDefaultAccountCodeSecond", defaultAccountCodeSecond),
                    new ReportParameter("paramDefaultAccountCodeThird", defaultAccountCodeThird),
                    new ReportParameter("paramDefaultAccountIDFirst", defaultAccountIDFirst.ToString()),
                    new ReportParameter("paramDefaultAccountIDSecond", defaultAccountIDSecond.ToString()),
                    new ReportParameter("paramDefaultAccountIDThird", defaultAccountIDThird.ToString()),
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
