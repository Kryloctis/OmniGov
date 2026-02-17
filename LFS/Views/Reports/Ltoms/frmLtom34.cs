using LFS.Helpers;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Treasury.Data;

namespace LFS.Views.Reports.Ltoms
{
    public partial class frmLtom34 : Form
    {
        private int taxpayerId;
        private int rptId;
        private DataTable dtRpt;

        public frmLtom34()
        {
            InitializeComponent();
            panel1.Controls.Add(reportViewer1);
        }

        private void ToogleRunButton(bool isGenerated)
        {
            btnRunReport.Text = isGenerated ? "Run Report" : "Generating Report...";
            btnRunReport.Enabled = isGenerated;
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
                progressBar1.Value = 0;
                ToogleRunButton(false);

                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (taxpayerId == 0)
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
                progressCount += tasks["Fetch LGU Details"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                //Fetch Record
                var dictBid = TreasuryFactory.BidRepository().GetBidderWinnerAndBidDetails(taxpayerId, rptId);

                var dictPropertyDetails = TreasuryFactory.RealPropertiesRepository().GetViewRecordById(rptId);

                progressCount += tasks["Fetch Record"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                // Initialize Parameters
                List<ReportParameter> reportParameters = new List<ReportParameter>();
                progressCount += tasks["Initialize Parameters"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                // Set Parameter Values
                reportParameters.Add(new ReportParameter("paramLGU", ServerHelper.selectedServer.MunicipalityName));
                reportParameters.Add(new ReportParameter("paramSignatoryTitle", string.Empty));
                reportParameters.Add(new ReportParameter("paramSignatory", string.Empty));

                //property details

                reportParameters.Add(new ReportParameter("paramTaxDecNo", dictPropertyDetails["complete_arp_no"]));
                reportParameters.Add(new ReportParameter("paramArp", dictPropertyDetails["complete_arp_no"]));
                reportParameters.Add(new ReportParameter("paramPin", dictPropertyDetails["property_pin"]));
                reportParameters.Add(new ReportParameter("paramDateOfSale", dictBid["date"]));

                reportParameters.Add(new ReportParameter("paramYearsOfDelinquent", string.Empty));
                reportParameters.Add(new ReportParameter("paramTaxDue", string.Empty));

                //bid and auction details
                reportParameters.Add(new ReportParameter("paramDateOfAuction", dictBid["start_date"]));
                reportParameters.Add(new ReportParameter("paramBidder", dictBid["name"]));
                reportParameters.Add(new ReportParameter("paramBidAmount", dictBid["bid_amount"]));

                //payment details
                reportParameters.Add(new ReportParameter("paramOfficialReceiptNo", dictBid["receipt_no"]));
                reportParameters.Add(new ReportParameter("paramOfficialReceiptDate", dictBid["date"]));
                reportParameters.Add(new ReportParameter("paramTreasurer", string.Empty));

                progressCount += tasks["Set Parameter Values"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                e.Result = reportParameters;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                localReport.ReportPath = $"{Application.StartupPath}Reports\\Ltoms\\Ltom34FinalDeedOfSale.rdlc";
                localReport.SetParameters(parameters);
                localReport.Refresh();

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.FullPage;
                reportViewer1.Refresh();
                ToogleRunButton(true);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LoadBidderWinner()
        {
            var rptId = dtRpt.AsEnumerable()
                               .Where(row => row.Field<string>("complete_arp_no") == txtRpt.Text)
                               .Select(row => row["real_property_id"])
                               .FirstOrDefault();

            if (rptId is not null)
            {
                var dtHighestBidder = TreasuryFactory.BidRepository().GetHighestBidderByRptId(Convert.ToInt32(rptId));
                cmbxBidders.DataSource = dtHighestBidder;
                cmbxBidders.ValueMember = "taxpayers_id";
                cmbxBidders.DisplayMember = "name";

                this.rptId = Convert.ToInt32(rptId);
                taxpayerId = Convert.ToInt32(cmbxBidders.SelectedValue);
            }
        }

        private void frmLtom34_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRealProperties();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadRealProperties()
        {
            dtRpt = TreasuryFactory.RealPropertiesRepository().GetViewRecords();

            var autoCompleteSrc = dtRpt.AsEnumerable().Select(row => row.Field<string>("complete_arp_no")).ToList();
            var autoCom = new AutoCompleteStringCollection();
            autoCom.Clear();
            autoCom.AddRange(autoCompleteSrc.ToArray());
            txtRpt.AutoCompleteCustomSource = autoCom;
        }

        private void txtRpt_TextChanged(object sender, EventArgs e)
        {
            LoadBidderWinner();
        }
    }
}
