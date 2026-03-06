using Microsoft.Reporting.WinForms;

using OmniGov.App.Helpers;

using OmniGov.Treasury.Data.Factories;

using OmniGov.Treasury.Domain.Entities;

using System.ComponentModel;

using System.Data;

namespace OmniGov.App.Views.Reports.Ltoms

{
    public partial class frmLtom28 : Form

    {
        private int auctionId;

        private int bidderId;

        private DataTable dtAuctionRpt;
        private int rptAuctionId;

        public frmLtom28()

        {
            InitializeComponent();

            panel1.Controls.Add(reportViewer1);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)

        {
            var parameters = ((int rptAuctionId, int bidderId))e.Argument;

            var tasks = new Dictionary<string, int>

            {
                { "Initialize Parameters", 50 },

                { "Fetch LGU Details", 50 }
            };

            int totalProgressCount = tasks.Sum(t => t.Value);

            int progressCount = 0;

            // Fetch LGU Details

            progressCount += tasks["Fetch LGU Details"];

            Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

            List<ReportParameter> reportParameters = new List<ReportParameter>();

            reportParameters.Add(new ReportParameter("paramLGU", "Titay"));

            reportParameters.Add(new ReportParameter("paramLGU", (ServerHelper.SelectedProfile?.Name ?? "")));

            progressCount += tasks["Initialize Parameters"];

            Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

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
                ToogleRunButton(true);
                return;
            }

            var parameters = (List<ReportParameter>)e.Result;
            reportViewer1.Clear();
            var localReport = reportViewer1.LocalReport;
            localReport.ReportPath = $"{Application.StartupPath}Reports\\Ltoms\\Ltom28RulesAndRegulationOfPublicAuction.rdlc";
            localReport.SetParameters(parameters);
            localReport.Refresh();

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.FullPage;
            reportViewer1.Refresh();

            ToogleRunButton(true);
        }

        private void btnRunReport_Click(object sender, EventArgs e)

        {
            int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
            int biddersId = Convert.ToInt32(cmbxBidders.SelectedValue);

            if (cmbxAuctionSchedule.SelectedIndex == -1 || cmbxBidders.SelectedIndex == -1)
                return;

            LoadReport();
        }

        private void cmbxAuctionSchedule_SelectedIndexChanged(object sender, EventArgs e)

        {
            LoadProperties();
        }

        private void frmLtom28_Load(object sender, EventArgs e)

        {
            OnLoad();
        }

        private void LoadAuctionSchedule()

        {
            DataTable dtAuctionSchedule = TreasuryFactory.AuctionRepository().GetAuctionSchedule();

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

                var dtBidders = TreasuryFactory.BiddersRepository().GetBiddersByAuctionIdAndRptId(auctionId, rptAuctionId);

                cmbxBidders.DisplayMember = "name";

                cmbxBidders.ValueMember = "id";

                cmbxBidders.DataSource = dtBidders;
            }
        }

        private void LoadProperties()

        {
            int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);

            dtAuctionRpt = TreasuryFactory.RptAuctionRepository().GetAuctionProperties(new RptAuctionModel() { AuctionId = auctionId });

            var autoCompleteSrc = dtAuctionRpt.AsEnumerable().Select(row => row.Field<string>("complete_arp_no")).ToList();

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

                int biddersId = Convert.ToInt32(cmbxBidders.SelectedValue);

                backgroundWorker1.RunWorkerAsync((rptAuctionId, biddersId));
            }
        }

        private void OnLoad()

        {
            LoadAuctionSchedule();
        }

        private void ToogleRunButton(bool isGenerated)

        {
            btnRunReport.Text = isGenerated ? "Run Report" : "Generating Report...";

            btnRunReport.Enabled = isGenerated;
        }

        private void txtRpt_TextChanged(object sender, EventArgs e)

        {
            LoadBidders();
        }
    }
}