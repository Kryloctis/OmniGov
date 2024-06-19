using ACC.Data;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace AccountingSystem.Views.Transactions.Biddings.BiddingReports
{
    public partial class ucUnderTakingAndWaiverOfBidders : UserControl
    {
        private int rptAuctionId;
        private int bidderId;

        public ucUnderTakingAndWaiverOfBidders()
        {
            InitializeComponent();
            panel1.Controls.Add(reportViewer1);

        }

        internal void OnLoad(int rptAuctionId, int bidderId)
        {
            this.rptAuctionId = rptAuctionId;
            this.bidderId = bidderId;
            LoadReport();
        }

        private void LoadReport()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync((rptAuctionId, bidderId));
            }
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
            var dictBid = AccFactory.BidRepository().GetRecordByAuctionIdAndBidderId(rptAuctionId, bidderId);
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
            if (e.Cancelled)
            {
                reportViewer1.Clear();
                progressBar1.Value = 100;
                return;
            }

            var parameters = (List<ReportParameter>)e.Result;
            reportViewer1.Clear();
            var localReport = reportViewer1.LocalReport;
            localReport.ReportPath = $"{Application.StartupPath}Reports\\Ltom\\ltom-27-undertaking-and-waver-of-bidders.rdlc";
            localReport.SetParameters(parameters);
            localReport.Refresh();

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.FullPage;
            reportViewer1.Refresh();
            try
            {
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }
}
