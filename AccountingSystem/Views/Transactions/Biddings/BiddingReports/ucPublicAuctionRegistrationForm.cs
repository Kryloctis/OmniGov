using ACC.Data;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Biddings.BiddingReports
{
    public partial class ucPublicAuctionRegistrationForm : UserControl
    {
        int auctionId;
        int bidderId;

        public ucPublicAuctionRegistrationForm()
        {
            InitializeComponent();
            panel1.Controls.Add(reportViewer1);
        }
        internal void OnLoad(int auctionId, int bidderId)
        {
            this.auctionId = auctionId;
            this.bidderId = bidderId;
            LoadReport();
        }

        private void LoadReport()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync((auctionId, bidderId));
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var parameters = ((int auctionId, int bidderId))e.Argument;

            var tasks = new Dictionary<string, int>
            {
                { "Fetch Bidder", 50},
                { "Initialize Parameters", 100 },
            };

            int totalProgressCount = tasks.Sum(t => t.Value);
            int progressCount = 0;

            var dictBidder = AccFactory.BiddersRepository().GetViewRecordByAuctionIdAndBidderId(parameters.auctionId, parameters.bidderId);


            List<ReportParameter> reportParameters = new List<ReportParameter>();
            progressCount += tasks["Initialize Parameters"];

            reportParameters.Add(new ReportParameter("paramLGU", "asd"));
            reportParameters.Add(new ReportParameter("paramOfficialReceiptNoForIndividualBidder", dictBidder["receipt_no"]));
            reportParameters.Add(new ReportParameter("paramBidderName", dictBidder["name"]));

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
                localReport.ReportPath = $"{Application.StartupPath}Reports\\Ltom\\ltom-25-public-auction-registration-form.rdlc";
                localReport.SetParameters(parameters);
                localReport.Refresh();

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.FullPage;
                reportViewer1.Refresh();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
