using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Journals
{
    public partial class frmCashDisbursementsJournalReport : Form
    {
        private readonly ReportViewer reportViewer;
        internal string fundName;
        internal string journalName;
        internal int fundId;
        internal DateTime date;

        public frmCashDisbursementsJournalReport()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
            Helper.LoadFormIcon(this);
        }


        private DataTable CashDisbursementsJournalDataTable()
        {
            var dtCashDisbursementsJournal = new dsLFS.CashDisbursementsJournalDataTable();
            var dtCashDisbursementFromDB = Factory.JEVAccountsRepository().GetViewRecordsByFundJournalDate(fundName, journalName, date);

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

            return dtCashDisbursementsJournal;
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var dictSignatory = Factory.SignatoriesHasReferencesRepository().GetSignatoryByReferenceAndDocumentName("Certified Correct", "Cash Disbursements Journal");
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
                var certifiedCorrectSignatoryTitle = string.Empty;
                ParseSignatory(dictSignatory, ref certifiedCorrectSignatory, ref certifiedCorrectSignatoryTitle);

                byte journalId = 4;

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
                    new ReportParameter("paramCertifiedCorrectSignatoryTitle", certifiedCorrectSignatoryTitle),
                    new ReportParameter("paramDefaultAccountCodeFirst", defaultAccountCodeFirst),
                    new ReportParameter("paramDefaultAccountCodeSecond", defaultAccountCodeSecond),
                    new ReportParameter("paramDefaultAccountCodeThird", defaultAccountCodeThird),
                    new ReportParameter("paramDefaultAccountIDFirst", defaultAccountIDFirst.ToString()),
                    new ReportParameter("paramDefaultAccountIDSecond", defaultAccountIDSecond.ToString()),
                    new ReportParameter("paramDefaultAccountIDThird", defaultAccountIDThird.ToString()),
                };

                report.ReportPath = $"{Application.StartupPath}\\Reports\\cash-disbursement-journal.rdlc";
                report.DataSources.Clear();

                report.DataSources.Add(new ReportDataSource("CashDisbursementsJournal", CashDisbursementsJournalDataTable()));
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

        private void frmCashDisbursementsJournalReport_Load(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }
    }
}
