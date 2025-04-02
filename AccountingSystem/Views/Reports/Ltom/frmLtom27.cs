using ACC.Data;
using ACC.Domain.Models;
using LFS;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Ltom
{
    public partial class frmLtom27 : Form
    {
        private int auctionId;
        private int bidderId;
        private int rptAuctionId;
        private DataTable dtAuctionRpt;

        public frmLtom27()
        {
            InitializeComponent();
            panel1.Controls.Add(reportViewer1);
        }

        private void ToogleRunButton(bool isGenerated)
        {
            btnRunReport.Text = isGenerated ? "Run Report" : "Generating Report...";
            btnRunReport.Enabled = isGenerated;
        }

        private void frmLtom27_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ResetForm()
        {
            cmbxAuctionSchedule.ResetText();
            cmbxBidders.ResetText();

            cmbxAuctionSchedule.SelectedIndex = -1;
            cmbxBidders.SelectedIndex = -1;
        }

        private void OnLoad()
        {
            LoadAuctionSchedule();
            LoadProperties();
            LoadBidders();
        }

        private void LoadProperties()
        {
            int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
            dtAuctionRpt = AccFactory.RptAuctionRepository().GetAuctionProperties(new RptAuctionModel() { AuctionId = auctionId });

            var autoCompleteSrc = dtAuctionRpt.AsEnumerable().Select(row => row.Field<string>("complete_arp_no")).ToList();
            var autoCom = new AutoCompleteStringCollection();
            autoCom.Clear();
            autoCom.AddRange(autoCompleteSrc.ToArray());
            txtRpt.AutoCompleteCustomSource = autoCom;
        }

        private void LoadAuctionSchedule()
        {
            DataTable dtAuctionSchedule = AccFactory.AuctionRepository().GetAuctionSchedule();
            HelperLoadRecords.AuctionScheduleCombobox(dtAuctionSchedule, cmbxAuctionSchedule, "date", "id");
        }

        private void LoadBidders()
        {
            rptAuctionId = Convert.ToInt32(dtAuctionRpt.AsEnumerable()
                                   .Where(row => row.Field<string>("complete_arp_no") == txtRpt.Text)
                                   .Select(row => row["rpt_auction_id"])
                                   .FirstOrDefault());

            if (rptAuctionId is not 0)
            {
                int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
                var dtBidders = AccFactory.BiddersRepository().GetBiddersByAuctionIdAndRptId(auctionId, rptAuctionId);

                cmbxBidders.DisplayMember = "name";
                cmbxBidders.ValueMember = "id";
                cmbxBidders.DataSource = dtBidders;
            }
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
                bool inValidFilter = cmbxAuctionSchedule.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtRpt.Text.Trim()) || cmbxBidders.SelectedIndex == -1;

                if (inValidFilter)
                    return;

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

                bidderId = Convert.ToInt32(cmbxBidders.SelectedValue);
                backgroundWorker1.RunWorkerAsync((rptAuctionId, bidderId));
            }
        }

        private void cmbxAuctionSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var parameters = ((int rptAuctionId, int bidderId))e.Argument;

            // Define tasks and their progress weights
            var tasks = new Dictionary<string, int>
            {
                { "Fetch LGU Details", 10 },
                { "Generate Bidder and Bidding Information", 20 },
                { "Initialize Parameters", 30 },
                { "Set Parameter Values", 40 }
            };

            int totalProgressCount = tasks.Sum(t => t.Value);
            int progressCount = 0;

            // Fetch LGU Details
            var lguDetails = Helper.LGUDetails();
            progressCount += tasks["Fetch LGU Details"];
            Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

            //Generate Bidder and Bidding Information
            var dictBid = AccFactory.BidRepository().GetRecordByAuctionIdAndBidderId(parameters.rptAuctionId, parameters.bidderId);
            string nameOfBidder = dictBid["name"].ToString();
            string bidderCompleteAddress = dictBid["address"].ToString();
            string dateOfPublicAuction = $"{Convert.ToDateTime(dictBid["start_date"]).ToString("MMMM dd yyyy")} - {Convert.ToDateTime(dictBid["end_date"]).ToString("MMMM dd yyyy")}";
            string placeOfPublicAuction = dictBid["location"];

            progressCount += tasks["Generate Bidder and Bidding Information"];
            Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

            // Initialize Parameters
            List<ReportParameter> reportParameters = new List<ReportParameter>();
            progressCount += tasks["Initialize Parameters"];
            Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

            // Set Parameter Values
            reportParameters.Add(new ReportParameter("paramLGU", lguDetails["municipality"]));
            reportParameters.Add(new ReportParameter("paramNameOfBidder", nameOfBidder));
            reportParameters.Add(new ReportParameter("paramCompleteAddressOfBidder", bidderCompleteAddress));
            reportParameters.Add(new ReportParameter("paramSignatory", string.Empty));
            reportParameters.Add(new ReportParameter("paramSignatoryTitle", string.Empty));
            reportParameters.Add(new ReportParameter("paramActualDateOfPublicAuction", dateOfPublicAuction));
            reportParameters.Add(new ReportParameter("paramPlaceOfPublicAuction", placeOfPublicAuction));
            progressCount += tasks["Set Parameter Values"];
            Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

            e.Result = reportParameters;
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
                localReport.ReportPath = $"{Application.StartupPath}Reports\\Ltom\\Ltom27UndertakingAndWaiverOfBidders.rdlc";
                localReport.SetParameters(parameters);
                localReport.Refresh();

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.FullPage;
                reportViewer1.Refresh();
                ToogleRunButton(true);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void txtRpt_TextChanged(object sender, EventArgs e)
        {
            LoadBidders();
        }
    }
}