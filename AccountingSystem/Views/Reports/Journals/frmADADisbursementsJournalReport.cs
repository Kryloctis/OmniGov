using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data;


namespace AccountingSystem.Views.Reports.Journals
{
    public partial class frmADADisbursementsJournalReport : Form
    {
        private readonly ReportViewer reportViewer;

        public frmADADisbursementsJournalReport()
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

        private DataTable AuthorityToDebitAccountDisbursementsJournalDataTable()
        {
            byte fundId = (byte)cmbFunds.SelectedValue;
            byte journalId = 6;
            var dateYearMonth = dtpMonth.Value;

            var dtADADisbursementsJournal = new dsLFS.AuthorityToDebitAccountDisbursementsJournalDataTable();
            var dtADADisbursementsFromDB = Factory.JEVAccountsRepository().GetViewRecordsByFundJournalDate(fundId, journalId, dateYearMonth);

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
                    row["account_code_debit"] = item["account_code"];
                    row["amount_debit"] = item["amount"];
                }
                else
                {
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
                var lguDetails = Helper.LGUDetails();
                var fundName = cmbFunds.Text;
                var signatory = "MARY MAGDALYN T. REGANION, CPA";

                var parameters = new[] {
                    new ReportParameter("paramMonth", dtpMonth.Value.ToString()),
                    new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                    new ReportParameter("paramFund", fundName),
                    new ReportParameter("paramSignatory", signatory)
                };

                report.ReportPath = $"{Application.StartupPath}\\Reports\\authority-to-debit-account-disbursements.rdlc";
                report.DataSources.Clear();

                report.DataSources.Add(new ReportDataSource("AuthorityToDebitAccountDisbursementsJournal", AuthorityToDebitAccountDisbursementsJournalDataTable()));
                report.SetParameters(parameters);

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void frmADADisbursementsJournalReport_Load(object sender, EventArgs e)
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
