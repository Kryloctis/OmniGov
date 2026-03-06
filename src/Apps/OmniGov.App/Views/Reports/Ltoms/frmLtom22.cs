using Microsoft.Reporting.WinForms;

using OmniGov.App.DataSets;

using OmniGov.App.Helpers;

using OmniGov.Treasury.Data.Factories;

using System.ComponentModel;

using System.Data;

namespace OmniGov.App.Views.Reports.Ltoms

{
    public partial class frmLtom22 : Form

    {
        public frmLtom22()

        {
            InitializeComponent();

            Helper.LoadFormIcon(this);

            splitContainer2.Panel1.Controls.Add(reportViewer1);

            splitContainer2.Panel2.Controls.Add(reportViewer2);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)

        {
            var date = (DateTime)e.Argument;
            // Define tasks and their progress weights
            var tasks = new Dictionary<string, int>
            {
                { "Fetch LGU Details", 10 },
                { "Initialize Parameters", 30 },
                { "Set Parameter Values", 40 }
            };

            var dtLtom22 = new dsTreasury.dtLtom22DataTable().Clone();
            var dtRptLevy = TreasuryFactory.RptLevyRepository().GetViewRecords(date);
            int totalProgressCount = tasks.Sum(t => t.Value) + dtRptLevy.Rows.Count;
            int progressCount = 0;

            // Fetch LGU Details
            progressCount += tasks["Fetch LGU Details"];
            Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

            // Initialize Parameters
            List<ReportParameter> reportParameters1 = new List<ReportParameter>();
            List<ReportParameter> reportParameters2 = new List<ReportParameter>();
            progressCount += tasks["Initialize Parameters"];
            Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

            // Set Parameter Values
            reportParameters1.Add(new ReportParameter("paramLgu", (ServerHelper.SelectedProfile?.Name ?? "")));
            reportParameters1.Add(new ReportParameter("paramReportDate", date.ToString()));
            reportParameters1.Add(new ReportParameter("paramSignatory", string.Empty));
            reportParameters1.Add(new ReportParameter("paramSignatoryTitle", string.Empty));

            reportParameters2.Add(new ReportParameter("paramLgu", (ServerHelper.SelectedProfile?.Name ?? "")));
            reportParameters2.Add(new ReportParameter("paramSignatory", string.Empty));
            reportParameters2.Add(new ReportParameter("paramSignatoryTitle", string.Empty));
            progressCount += tasks["Set Parameter Values"];
            Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

            foreach (DataRow dataRow in dtRptLevy.Rows)
            {
                var newRow = dtLtom22.NewRow();
                string fullAddress = Helper.GenerateFullAddress(string.Empty, dataRow["barangay_name"].ToString(), dataRow["municipalities_name"].ToString(), dataRow["provinces_name"].ToString());

                newRow["declared_owner"] = dataRow["taxpayers_name"];
                newRow["tax_dec_no"] = dataRow["complete_arp_no"];
                newRow["location_of_property"] = fullAddress;
                newRow["kind_of_property"] = dataRow["property_kind"];
                newRow["assessed_value"] = dataRow["assessed_value"];

                progressCount++;
                dtLtom22.Rows.Add(newRow);
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
            }

            e.Result = (reportParameters1, reportParameters2, dtLtom22);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)

        {
            pbReport.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

        {
            var parameters = ((List<ReportParameter> reportParameters1, List<ReportParameter> reportParameters2, DataTable dtRptLevy))e.Result;

            reportViewer1.Clear();
            var localReport = reportViewer1.LocalReport;
            localReport.ReportPath = $"{Application.StartupPath}Reports\\Ltoms\\Ltom22ReportOfLevy.rdlc";
            localReport.SetParameters(parameters.reportParameters1);
            localReport.Refresh();

            reportViewer2.Clear();
            var localReport2 = reportViewer2.LocalReport;
            localReport2.DataSources.Clear();
            localReport2.ReportPath = $"{Application.StartupPath}Reports\\Ltoms\\ListRptDelinquenciesWithLevy.rdlc";
            localReport2.DataSources.Add(new ReportDataSource("dtLtom22", parameters.dtRptLevy));
            localReport2.SetParameters(parameters.reportParameters2);
            localReport2.Refresh();

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.FullPage;
            reportViewer1.Refresh();

            reportViewer2.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer2.ZoomMode = ZoomMode.FullPage;
            reportViewer2.Refresh();
            ToogleRunButton(true);
        }

        private void btnRunReport_Click(object sender, EventArgs e)

        {
            LoadReport();
        }

        private void frmLtom22_Load(object sender, EventArgs e)

        {
        }

        private void LoadReport()

        {
            if (!backgroundWorker1.IsBusy)
            {
                var date = dateTimePicker1.Value;
                pbReport.Value = 0;
                ToogleRunButton(false);
                backgroundWorker1.RunWorkerAsync(date);
            }
        }

        private void ToogleRunButton(bool isGenerated)

        {
            btnRunReport.Text = isGenerated ? "Run Report" : "Generating Report...";

            btnRunReport.Enabled = isGenerated;
        }
    }
}