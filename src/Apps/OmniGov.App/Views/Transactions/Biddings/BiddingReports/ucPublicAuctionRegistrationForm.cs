using Microsoft.Reporting.WinForms;

using OmniGov.App.Helpers;

using OmniGov.Treasury.Data.Factories;

using System.ComponentModel;

namespace OmniGov.App.Views.Transactions.Biddings.BiddingReports

{
    public partial class ucPublicAuctionRegistrationForm : UserControl

    {
        private int auctionId;

        private int bidderId;

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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)

        {
            var parameters = ((int auctionId, int bidderId))e.Argument;

            var tasks = new Dictionary<string, int>

            {
                { "Fetch Bidder", 50},

                { "Initialize Parameters", 100 },
            };

            int totalProgressCount = tasks.Sum(t => t.Value);

            int progressCount = 0;

            var dictBidder = TreasuryFactory.BiddersRepository().GetViewRecordByAuctionIdAndBidderId(parameters.auctionId, parameters.bidderId);

            List<ReportParameter> reportParameters = new List<ReportParameter>();

            progressCount += tasks["Initialize Parameters"];

            var isRepresentative = !string.IsNullOrEmpty(dictBidder["representative_registry_id"]);

            reportParameters.Add(new ReportParameter("paramIsRepresentative", isRepresentative.ToString()));

            reportParameters.Add(new ReportParameter("paramLGU", (ServerHelper.SelectedProfile?.Name ?? "")));

            reportParameters.Add(new ReportParameter("paramCompleteAddress", dictBidder["address"]));

            reportParameters.Add(new ReportParameter("paramAssignedBidderNo", dictBidder["bidder_no"]));

            reportParameters.Add(new ReportParameter("paramOfficialReceiptNoForIndividualBidder", dictBidder["receipt_no"]));

            reportParameters.Add(new ReportParameter("paramBidderName", dictBidder["name"]));

            reportParameters.Add(new ReportParameter("paramTelephoneNo", dictBidder["contact_info"]));

            reportParameters.Add(new ReportParameter("paramEmail", string.Empty));

            reportParameters.Add(new ReportParameter("paramCitizenship", string.Empty));

            reportParameters.Add(new ReportParameter("paramSex", string.Empty));

            e.Result = reportParameters;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)

        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

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
            localReport.ReportPath = $"{Application.StartupPath}Reports\\Ltom\\Ltom25PublicAuctionRegFrm.rdlc";
            localReport.SetParameters(parameters);
            localReport.Refresh();

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.FullPage;
            reportViewer1.Refresh();
        }

        private void LoadReport()

        {
            if (!backgroundWorker1.IsBusy)

            {
                progressBar1.Value = 0;

                backgroundWorker1.RunWorkerAsync((auctionId, bidderId));
            }
        }
    }
}