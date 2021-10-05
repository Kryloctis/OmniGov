using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Journals
{
    public partial class ucADADisbursementsJournalReport : UserControl
    {
        private readonly ReportViewer reportViewer;
        internal string fundName;
        internal string journalName;
        internal DateTime date;

        public ucADADisbursementsJournalReport()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }

        private DataTable AuthorityToDebitAccountDisbursementsJournalDataTable()
        {

            var dtADADisbursementsJournal = new dsLFS.AuthorityToDebitAccountDisbursementsJournalDataTable();
            var dtADADisbursementsFromDB = Factory.JEVAccountsRepository().GetViewRecordsByFundJournalDate(fundName, journalName, date);

            int jevId;
            string jevNo;

            var aDADisbursementsJournalRepository = Factory.ADADisbursementsJournalRepository();
            foreach (DataRow item in dtADADisbursementsFromDB.Rows)
            {
                jevId = Convert.ToInt32(item["jev_id"]);
                jevNo = item["jev_no"].ToString();

                var aDADDisbursementsDict = aDADisbursementsJournalRepository.GetRecordByJevID(jevId);
                DataRow row = dtADADisbursementsJournal.NewRow();
                row["date"] = item["date_entry"];
                row["ada_no"] = aDADDisbursementsDict["ada_no"];
                row["ref_no"] = jevNo;
                row["particulars"] = item["explanation"];

                if (Convert.ToBoolean(item["is_debit"]))
                {
                    row["account_id_debit"] = item["general_ledger_accounts_id"];
                    row["account_code_debit"] = item["account_code"];
                    row["amount_debit"] = item["amount"];
                }
                else
                {
                    row["account_id_credit"] = item["general_ledger_accounts_id"];
                    row["account_code_credit"] = item["account_code"];
                    row["amount_credit"] = item["amount"];
                }

                dtADADisbursementsJournal.Rows.Add(row);
            }

            return dtADADisbursementsJournal;
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var lguDetails = Helper.LGUDetails();
                var signatory = "MARY MAGDALYN T. REGANION, CPA";
                byte journalId = 6;

                DataTable defaultAccountsDataTable = Factory.JournalsDefaultAccountsRepository().GetViewRecordsByJournalId(journalId);

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
                    new ReportParameter("paramSignatory", signatory),
                    new ReportParameter("paramDefaultAccountCodeFirst", defaultAccountCodeFirst),
                    new ReportParameter("paramDefaultAccountCodeSecond", defaultAccountCodeSecond),
                    new ReportParameter("paramDefaultAccountCodeThird", defaultAccountCodeThird),
                    new ReportParameter("paramDefaultAccountIDFirst", defaultAccountIDFirst.ToString()),
                    new ReportParameter("paramDefaultAccountIDSecond", defaultAccountIDSecond.ToString()),
                    new ReportParameter("paramDefaultAccountIDThird", defaultAccountIDThird.ToString()),
                };

                report.ReportPath = $"{Application.StartupPath}\\Reports\\authority-to-debit-account-disbursements.rdlc";
                report.DataSources.Clear();

                report.DataSources.Add(new ReportDataSource("AuthorityToDebitAccountDisbursementsJournal", AuthorityToDebitAccountDisbursementsJournalDataTable()));
                report.SetParameters(parameters);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.PageWidth;
            reportViewer.RefreshReport();
        }

        private void ucADADisbursementsJournalReport_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadFunds();
            }
        }
    }
}
