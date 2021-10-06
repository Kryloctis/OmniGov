using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Journals
{
    public partial class frmGeneralJournalReport : Form
    {
        private readonly ReportViewer reportViewer;
        internal string fundName;
        internal string journalName;
        internal DateTime date;

        public frmGeneralJournalReport()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }

        private DataTable DataTableGeneralJournal()
        {
            var dtGeneralJournal = new dsLFS.dtGeneralJournalDataTable();
            var dtGeneralJournalFromDB = Factory.JEVAccountsRepository().GetViewRecordsByFundJournalDate(fundName, journalName, date);

            string jevNo;
            string particulars;
            int jevId;
            byte i = 0;

            foreach (DataRow item in dtGeneralJournalFromDB.Rows)
            {
                jevNo = item["full_jev_no"].ToString();
                particulars = item["general_ledger_accounts_name"].ToString();

                DataRow row = dtGeneralJournal.NewRow();
                row["date_entry"] = item["date_entry"];
                row["jev_no"] = jevNo;
                row["account_code"] = item["account_code"];

                ValidateDebitCreditRow(particulars, item, row);

                dtGeneralJournal.Rows.Add(row);

                i++;
                jevId = Convert.ToInt32(item["jev_id"]);
                AddExplanationRow(dtGeneralJournal, jevNo, ref particulars, jevId, ref i, item);
            }

            return dtGeneralJournal;
        }

        private static void ValidateDebitCreditRow(string particulars, DataRow item, DataRow row)
        {
            if (Convert.ToBoolean(item["is_debit"]))
            {
                row["particulars"] = particulars;
                row["debit"] = item["amount"];
                row["credit"] = 0;
            }
            else
            {
                row["particulars"] = $"     {particulars}";
                row["debit"] = 0;
                row["credit"] = item["amount"];
            }
        }

        private static void AddExplanationRow(dsLFS.dtGeneralJournalDataTable dtGeneralJournal, string jevNo, ref string particulars, int jevId, ref byte i, DataRow item)
        {
            var countJevAccounts = Factory.JEVAccountsRepository().CountByJevId(jevId);
            if (i == countJevAccounts)
            {
                particulars = $"          {item["explanation"]}";

                DataRow explanationRow = dtGeneralJournal.NewRow();
                explanationRow["date_entry"] = item["date_entry"];
                explanationRow["jev_no"] = jevNo;
                explanationRow["particulars"] = particulars;
                explanationRow["debit"] = 0;
                explanationRow["credit"] = 0;

                i = 0;
                dtGeneralJournal.Rows.Add(explanationRow);
            }
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var lguDetails = Helper.LGUDetails();
                var signatory = "MARY MAGDALYN T. REGANION, CPA";

                var parameters = new[] {
                    new ReportParameter("paramMonth", date.ToString()),
                    new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                    new ReportParameter("paramFund", fundName),
                    new ReportParameter("paramSignatory", signatory)
                };
                report.ReportPath = $"{Application.StartupPath}\\Reports\\general-journal.rdlc";
                report.DataSources.Clear();

                report.DataSources.Add(new ReportDataSource("dtGeneralJournal", DataTableGeneralJournal()));
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

        private void frmGeneralJournalReport_Load(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }
    }
}
