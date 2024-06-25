using ACC.Data;
using AccountingSystem.Views.Transactions.Biddings.BiddingReports;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Ltom
{
    public partial class frmLtom33 : Form
    {
        private DataTable dtRpt;
        private ucCancellationOfWarrantOfLevy UcCancellationOfWarrantOfLevy;

        public frmLtom33()
        {
            InitializeComponent();
            panel1.Controls.Add(reportViewer1);
        }

        private void ToogleRunButton(bool isGenerated)
        {
            btnRunReport.Text = isGenerated ? "Run Report" : "Generating Report...";
            btnRunReport.Enabled = isGenerated;
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {

                if (cmbxWarrantLevy.SelectedIndex == -1)
                    return;

                LoadReport();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmLtom33_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRealProperties();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadIssuedWarrantLevy()
        {
            var rptId = dtRpt.AsEnumerable()
                               .Where(row => row.Field<string>("complete_arp_no") == txtRpt.Text)
                               .Select(row => row["real_property_id"])
                               .FirstOrDefault();

            if (rptId is not null)
            {
                var dtNoticeDelinquencies = AccFactory.RptLevyRepository().GetCancelledLevy(Convert.ToInt32(rptId));
                cmbxWarrantLevy.DataSource = dtNoticeDelinquencies;
                cmbxWarrantLevy.ValueMember = "rpt_levy_id";
                cmbxWarrantLevy.DisplayMember = "date_issued";
            }
        }

        private void LoadRealProperties()
        {
            dtRpt = AccFactory.RealPropertiesRepository().GetViewRecords();

            var autoCompleteSrc = dtRpt.AsEnumerable().Select(row => row.Field<string>("complete_arp_no")).ToList();
            var autoCom = new AutoCompleteStringCollection();
            autoCom.Clear();
            autoCom.AddRange(autoCompleteSrc.ToArray());
            txtRpt.AutoCompleteCustomSource = autoCom;
        }

        private void LoadReport()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
                ToogleRunButton(false);

                int warrantOfLevyId = Convert.ToInt32(cmbxWarrantLevy.SelectedValue);
                backgroundWorker1.RunWorkerAsync(warrantOfLevyId);
            }
        }
        private void txtRpt_TextChanged(object sender, EventArgs e)
        {
            LoadIssuedWarrantLevy();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                var warrantLevyId = e.Argument;

                if (warrantLevyId is null)
                {
                    backgroundWorker1.CancelAsync();
                    e.Cancel = true;
                    return;
                }

                // Define tasks and their progress weights
                var tasks = new Dictionary<string, int>
                {
                    { "Fetch LGU Details", 10 },
                    { "Fetch Warrant of Levy", 20 },
                    { "Set Parameter Values", 40 },
                    { "Initialize Parameters", 30 },
                };

                int totalProgressCount = tasks.Sum(t => t.Value);
                int progressCount = 0;

                // Fetch LGU Details
                var lguDetails = Helper.LGUDetails();
                progressCount += tasks["Fetch LGU Details"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                //Fetch Warrant of Levy.
                var dictWarrantLevy = AccFactory.RptLevyRepository().GetViewCancelledLevy(Convert.ToInt32(warrantLevyId));

                progressCount += tasks["Fetch Warrant of Levy"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                // Initialize Parameters
                List<ReportParameter> reportParameters = new List<ReportParameter>();
                progressCount += tasks["Initialize Parameters"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                // Set Parameter Values
                reportParameters.Add(new ReportParameter("paramLGU", lguDetails["municipality"]));
                reportParameters.Add(new ReportParameter("paramWarrantOfLevyDate", dictWarrantLevy["date_issued"]));
                reportParameters.Add(new ReportParameter("paramTaxDecNo", dictWarrantLevy["complete_arp_no"]));
                reportParameters.Add(new ReportParameter("paramTCTNo", "-"));
                reportParameters.Add(new ReportParameter("paramSignatoryTitle", string.Empty));
                reportParameters.Add(new ReportParameter("paramSignatory", string.Empty));

                progressCount += tasks["Set Parameter Values"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                e.Result = reportParameters;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                {
                    reportViewer1.Clear();
                    progressBar1.Value = 100;
                    return;
                }

                var parameters = (List<ReportParameter>)e.Result;
                reportViewer1.Clear();
                var localReport = reportViewer1.LocalReport;
                localReport.ReportPath = $"{Application.StartupPath}Reports\\Ltom\\Ltom33CancellationOfWarrantOfLevey.rdlc";
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