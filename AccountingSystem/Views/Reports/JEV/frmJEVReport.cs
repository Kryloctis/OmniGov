using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data;

namespace AccountingSystem.Views.Reports.JEV
{
    public partial class frmJEVReport : Form
    {
        private readonly ReportViewer reportViewer;

        public frmJEVReport()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                //var lguDetails = Helper.LGUDetails();
                //var fundName = cmbFunds.Text;
                //var signatory = "MARY MAGDALYN T. REGANION, CPA";

                var parameters = new[] {
                    new ReportParameter("paramSample", "SAMPLE TEXT"),
                };

                report.ReportPath = $"{Application.StartupPath}\\Reports\\journal-entry-voucher.rdlc";
                //report.DataSources.Clear();

                //report.DataSources.Add(new ReportDataSource("AuthorityToDebitAccountDisbursementsJournal", AuthorityToDebitAccountDisbursementsJournalDataTable()));
                //report.SetParameters(parameters);

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadJournals()
        {
            //cmbFunds.DataSource = Factory.FundsRepository().GetRecords();
            //cmbFunds.ValueMember = "id";
            //cmbFunds.DisplayMember = "fund_name";
        }

        private void frmJEVReport_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            LoadJournals();
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
