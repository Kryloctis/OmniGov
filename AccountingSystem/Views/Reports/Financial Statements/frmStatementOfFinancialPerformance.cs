using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Financial_Statements
{
    public partial class frmStatementOfFinancialPerformance : Form
    {
        private readonly ReportViewer reportViewer;

        public frmStatementOfFinancialPerformance()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }

        private DataTable StatementOfFinancialPerformanceDatatable()
        {
            var dataSet = new dsLFS();
            var dtStatementOfFinancialPerformance = dataSet.dtStatementOfFinancialPerformance;

            return dtStatementOfFinancialPerformance;
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
                DateTime dateEnded = dtPickerDateEnds.Value;


                report.ReportPath = $"{Application.StartupPath}\\Reports\\statement-of-financial-performance.rdlc";
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("dtStatementOfFinancialPerformance", StatementOfFinancialPerformanceDatatable()));

                var fundRepo = Factory.FundsRepository().GetRecordByID(fundId);
                var parameters = new[] {
                    new ReportParameter("paramFund", fundRepo["fund_name"]),
                    new ReportParameter("paramDateEnded", dateEnded.ToString("MMMM dd, yyyy")),
                };
                report.SetParameters(parameters);

                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadFunds()
        {
            try
            {
                var dtFunds = Factory.FundsRepository().GetRecords();

                HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "fund_name", "id");

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void frmStatementOfFinancialPerformance_Load(object sender, EventArgs e)
        {
            LoadFunds();
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }
    }
}
