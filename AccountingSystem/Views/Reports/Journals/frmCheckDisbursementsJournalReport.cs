using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Journals
{
    public partial class frmCheckDisbursementsJournalReport : Form
    {
        private readonly ReportViewer reportViewer;
        internal int fundId;
        internal string fundName;
        internal string journalName;
        internal DateTime date;

        public frmCheckDisbursementsJournalReport()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }

        private DataTable CheckDisbursementsJournalDataTable()
        {
            var dtCheckDisbursementsJournal = new dsLFS.CheckDisbursementsJournalDataTable();
            var dtCheckDisbursementFromDB = Factory.JEVAccountsRepository().GetViewRecordsByFundJournalDate(fundName, journalName, date);

            int jevId;
            string jevNo;
            string particulars;

            var checkDisbursementsRepository = Factory.CheckDisbursementsJournalRepository();
            foreach (DataRow item in dtCheckDisbursementFromDB.Rows)
            {
                jevId = Convert.ToInt32(item["jev_id"]);
                jevNo = item["jev_no"].ToString();
                particulars = item["explanation"].ToString();

                var checkDisbursementDict = checkDisbursementsRepository.GetRecordByJevID(jevId);
                DataRow row = dtCheckDisbursementsJournal.NewRow();
                row["date"] = item["date_entry"];
                row["ref"] = checkDisbursementDict["check_no"];
                row["payee"] = checkDisbursementDict["payee"];

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

                dtCheckDisbursementsJournal.Rows.Add(row);
            }

            return dtCheckDisbursementsJournal;
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var dictSignatory = Factory.SignatoriesHasReferencesRepository().GetSignatoryByReferenceAndDocumentName("Certified Correct", "Check Disbursements Journal");
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

                byte journalId = 5;

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

                report.ReportPath = $"{Application.StartupPath}\\Reports\\check-disbursements-journal.rdlc";
                report.DataSources.Clear();



                report.DataSources.Add(new ReportDataSource("CheckDisbursementsJournal", CheckDisbursementsJournalDataTable()));
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

        private void frmCheckDisbursementsJournalReport_Load(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }
    }
}
