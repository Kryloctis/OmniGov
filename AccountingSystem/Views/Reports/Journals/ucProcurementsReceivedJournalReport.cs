using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Journals
{
    public partial class ucProcurementsReceivedJournalReport : UserControl
    {
        private readonly ReportViewer reportViewer;

        public ucProcurementsReceivedJournalReport()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }

        private void LoadFunds()
        {
            cmbFunds.DataSource = Factory.FundsRepository().GetRecords();
            cmbFunds.ValueMember = "id";
            cmbFunds.DisplayMember = "fund_name";
        }

        private DataTable ProcurementsReceivedJournalDataTable()
        {
            byte fundId = (byte)cmbFunds.SelectedValue;
            byte journalId = 3;
            var dateYearMonth = dtpMonth.Value;

            var dtProcurementsReceivedJournal = new dsLFS.ProcurementsReceivedJournalDataTable();
            var dtProcurementsReceivedFromDB = Factory.JEVAccountsRepository().GetViewRecordsByFundJournalDate(fundId, journalId, dateYearMonth);

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

        private void LoadReport(LocalReport report)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var lguDetails = Helper.LGUDetails();
                var fundName = cmbFunds.Text;
                var signatory = "MARY MAGDALYN T. REGANION, CPA";
                byte journalId = 3;

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

                int defaultAccountIDFirst = defaultAccountId(0);
                int defaultAccountIDSecond = defaultAccountId(1);

                var parameters = new[] {
                    new ReportParameter("paramMonth", dtpMonth.Value.ToString()),
                    new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                    new ReportParameter("paramFund", fundName),
                    new ReportParameter("paramSignatory", signatory),
                    new ReportParameter("paramDefaultAccountCodeFirst", defaultAccountCodeFirst),
                    new ReportParameter("paramDefaultAccountCodeSecond", defaultAccountCodeSecond),
                    new ReportParameter("paramDefaultAccountIDFirst", defaultAccountIDFirst.ToString()),
                    new ReportParameter("paramDefaultAccountIDSecond", defaultAccountIDSecond.ToString()),
                };

                report.ReportPath = $"{Application.StartupPath}\\Reports\\procurements-received-journal.rdlc";
                report.DataSources.Clear();

                report.DataSources.Add(new ReportDataSource("ProcurementsReceivedJournal", ProcurementsReceivedJournalDataTable()));
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

        private void ucProcurementsReceivedJournalReport_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadFunds();
            }
        }
    }
}
