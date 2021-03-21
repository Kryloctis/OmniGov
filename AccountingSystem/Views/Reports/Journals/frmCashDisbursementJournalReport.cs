using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Journals
{
    public partial class frmCashDisbursementJournalReport : Form
    {
        private readonly ReportViewer reportViewer;

        public frmCashDisbursementJournalReport()
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

        private DataTable CashDisbursementsJournalDataTable()
        {
            byte fundId = (byte)cmbFunds.SelectedValue;
            byte journalId = 4;
            var dateYearMonth = dtpMonth.Value;

            var dtCashDisbursementsJournal = new dsLFS.CashDisbursementsJournalDataTable();
            var dtCashDisbursementFromDB = Factory.JEVAccountsRepository().GetViewRecordsByFundJournalDate(fundId, journalId, dateYearMonth);

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
                    row["account_code_debit"] = item["account_code"];
                    row["debit"] = item["amount"];
                }
                else
                {
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
                var lguDetails = Helper.LGUDetails();
                var fundName = cmbFunds.Text;
                var signatory = "MARY MAGDALYN T. REGANION, CPA";

                var parameters = new[] {
                    new ReportParameter("paramMonth", dtpMonth.Value.ToString()),
                    new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                    new ReportParameter("paramFund", fundName),
                    new ReportParameter("paramSignatory", signatory)
                };

                report.ReportPath = $"{Application.StartupPath}\\Reports\\cash-disbursement-journal.rdlc";
                report.DataSources.Clear();

                report.DataSources.Add(new ReportDataSource("CashDisbursementsJournal", CashDisbursementsJournalDataTable()));
                report.SetParameters(parameters);

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void frmCashDisbursementJournalReport_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIconAccounting(this);
            LoadFunds();
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }
    }
}
