using ACC.Data;
using ACC.Domain.Interfaces;
using AccountingSystem.DataSets;
using AccountingSystem.Views.Shared;
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

namespace AccountingSystem.Views.Reports.Ltom
{
    public partial class frmLtom22 : Form
    {
        public frmLtom22()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            panel3.Controls.Add(reportViewer1);
        }

        private void frmLtom22_Load(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ToogleRunButton(bool isGenerated)
        {
            btnRunReport.Text = isGenerated ? "Run Report" : "Generating Report...";
            btnRunReport.Enabled = isGenerated;
        }

        private void LoadReport()
        {
            try
            {
                if (!backgroundWorker1.IsBusy)
                {
                    var date = dateTimePicker1.Value;
                    pbReport.Value = 0;
                    ToogleRunButton(false);
                    backgroundWorker1.RunWorkerAsync(date);
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.StackTrace); }
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
                LoadReport();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var date = (DateTime)e.Argument;

                // Define tasks and their progress weights
                var tasks = new Dictionary<string, int>
                {
                    { "Fetch LGU Details", 10 },
                    { "Initialize Parameters", 30 },
                    { "Set Parameter Values", 40 }
                };

                int totalProgressCount = tasks.Sum(t => t.Value);
                int progressCount = 0;

                // Fetch LGU Details
                var lguDetails = Helper.LGUDetails();
                progressCount += tasks["Fetch LGU Details"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                // Initialize Parameters
                List<ReportParameter> reportParameters = new List<ReportParameter>();
                progressCount += tasks["Initialize Parameters"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                // Set Parameter Values
                reportParameters.Add(new ReportParameter("paramLgu", lguDetails["lgu_name"]));
                reportParameters.Add(new ReportParameter("paramReportDate", date.ToString()));
                reportParameters.Add(new ReportParameter("paramSignatory", string.Empty));
                reportParameters.Add(new ReportParameter("paramSignatoryTitle", string.Empty));
                progressCount += tasks["Set Parameter Values"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                e.Result = reportParameters;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbReport.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                var parameters = (List<ReportParameter>)e.Result;
                reportViewer1.Clear();
                var localReport = reportViewer1.LocalReport;
                localReport.ReportPath = $"{Application.StartupPath}Reports\\Ltom\\ltom-22-report-of-levy.rdlc";
                localReport.SetParameters(parameters);
                localReport.Refresh();

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.FullPage;
                reportViewer1.Refresh();
                ToogleRunButton(true);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}