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

        public frmCheckDisbursementsJournalReport()
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

        private DataTable CheckDisbursementsJournalDataTable()
        {
            byte fundId = (byte)cmbFunds.SelectedValue;
            byte journalId = 5;
            var dateYearMonth = dtpMonth.Value;

            var dtCheckDisbursementsJournal = new dsLFS.CheckDisbursementsJournalDataTable();
            var dtCheckDisbursementFromDB = Factory.JEVAccountsRepository().GetViewRecordsByFundJournalDate(fundId, journalId, dateYearMonth);

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
                    row["account_code_debit"] = item["account_code"];
                    row["debit"] = item["amount"];
                }
                else
                {
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
                var lguDetails = Helper.LGUDetails();
                var fundName = cmbFunds.Text;
                var signatory = "MARY MAGDALYN T. REGANION, CPA";

                var parameters = new[] {
                    new ReportParameter("paramMonth", dtpMonth.Value.ToString()),
                    new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                    new ReportParameter("paramFund", fundName),
                    new ReportParameter("paramSignatory", signatory)
                };

                report.ReportPath = $"{Application.StartupPath}\\Reports\\check-disbursements-journal.rdlc";
                report.DataSources.Clear();

                report.DataSources.Add(new ReportDataSource("CheckDisbursementsJournal", CheckDisbursementsJournalDataTable()));
                report.SetParameters(parameters);

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void frmCheckDisbursementsJournalReport_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
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
