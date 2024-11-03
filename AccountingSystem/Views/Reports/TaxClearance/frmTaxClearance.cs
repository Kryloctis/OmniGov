using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.TaxClearance
{
    public partial class frmTaxClearance : Form
    {
        public frmTaxClearance()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            panel3.Controls.Add(reportViewer1);
            txtPropertyOwner.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtPropertyOwner.AutoCompleteMode = AutoCompleteMode.Suggest;
        }

        private void frmTaxClearance_Load(object sender, System.EventArgs e)
        {

        }

        private void btnRunReport_Click(object sender, System.EventArgs e)
        {
            try
            {
                LoadReport();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
        private void LoadReport()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbReport.Value = 0;
                ToogleRunButton(false);
                var rptDelinquencyNoticeId = cmbxOfficialReceipt.SelectedValue;
                backgroundWorker1.RunWorkerAsync(rptDelinquencyNoticeId);
            }
        }


        private void ToogleRunButton(bool isGenerated)
        {
            btnRunReport.Text = isGenerated ? "Run Report" : "Generating Report...";
            btnRunReport.Enabled = isGenerated;
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                if (txtPropertyOwner.Text == string.Empty)
                {
                    backgroundWorker1.CancelAsync();
                    e.Cancel = true;
                    return;
                }

                // Define tasks and their progress weights
                var tasks = new Dictionary<string, int>
                {
                    { "Fetch LGU Details", 10 },
                    { "Fetch Record", 20 },
                    { "Set Parameter Values", 40 },
                    { "Initialize Parameters", 30 },
                };

                int totalProgressCount = tasks.Sum(t => t.Value);
                int progressCount = 0;

                // Fetch LGU Details
                var lguDetails = Helper.LGUDetails();
                progressCount += tasks["Fetch LGU Details"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);


                progressCount += tasks["Fetch Record"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                // Initialize Parameters
                List<ReportParameter> reportParameters = new List<ReportParameter>();
                progressCount += tasks["Initialize Parameters"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);


                progressCount += tasks["Set Parameter Values"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                e.Result = reportParameters;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pbReport.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                {
                    reportViewer1.Clear();
                    pbReport.Value = 100;
                    return;
                }

                var parameters = (List<ReportParameter>)e.Result;
                reportViewer1.Clear();
                var localReport = reportViewer1.LocalReport;
                localReport.ReportPath = $"{Application.StartupPath}Reports\\certificate-of-tax-clearance.rdlc";
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
