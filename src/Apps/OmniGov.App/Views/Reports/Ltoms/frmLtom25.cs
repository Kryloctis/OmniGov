using Microsoft.Reporting.WinForms;

using OmniGov.App.Helpers;

using OmniGov.Core.Factories;

using OmniGov.Treasury.Data.Factories;

using OmniGov.Treasury.Domain.Entities;

using System.Data;

namespace OmniGov.App.Views.Reports.Ltoms

{
    public partial class frmLtom25 : Form

    {
        private int auctionId;

        private int bidderId;

        private DataTable dtAuctionRpt;
        private int rptAuctionId;

        public frmLtom25()

        {
            InitializeComponent();

            panel1.Controls.Add(reportViewer1);
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)

        {
            var parameters = ((int auctionId, int bidderId))e.Argument;

            var tasks = new Dictionary<string, int>

            {
                { "Fetch Bidder", 30},

                { "Initialize Parameters", 20 },

                { "Set Parameter Values", 40 },
            };

            int totalProgressCount = tasks.Sum(t => t.Value);

            int progressCount = 0;

            var dictBidder = TreasuryFactory.BiddersRepository().GetViewRecordByAuctionIdAndBidderId(parameters.auctionId, parameters.bidderId);

            progressCount += tasks["Fetch Bidder"];

            Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

            List<ReportParameter> reportParameters = new List<ReportParameter>();

            progressCount += tasks["Initialize Parameters"];

            Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

            var isRepresentative = !string.IsNullOrEmpty(dictBidder["representative_registry_id"]);

            reportParameters.Add(new ReportParameter("paramIsRepresentative", isRepresentative.ToString()));

            reportParameters.Add(new ReportParameter("paramLGU", (ServerHelper.SelectedProfile?.Name ?? "")));

            reportParameters.Add(new ReportParameter("paramCompleteAddress", dictBidder["address"]));

            reportParameters.Add(new ReportParameter("paramAssignedBidderNo", dictBidder["bidder_no"]));

            reportParameters.Add(new ReportParameter("paramOfficialReceiptNoForIndividualBidder", dictBidder["receipt_no"]));

            reportParameters.Add(new ReportParameter("paramBidderName", dictBidder["name"]));

            reportParameters.Add(new ReportParameter("paramTelephoneNo", dictBidder["contact_info"]));

            reportParameters.Add(new ReportParameter("paramEmail", string.Empty));

            if (isRepresentative)

            {
                var dictRegistry = Factory.RegistryRepository().GetRecordByID(Convert.ToInt32(dictBidder["representative_registry_id"]));

                reportParameters.Add(new ReportParameter("paramCitizenship", dictRegistry["nationality"]));

                reportParameters.Add(new ReportParameter("paramSex", dictRegistry["sex"]));
            }

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
                ToogleRunButton(true);
                return;
            }

            var parameters = (List<ReportParameter>)e.Result;
            reportViewer1.Clear();
            var localReport = reportViewer1.LocalReport;
            localReport.ReportPath = $"{Application.StartupPath}Reports\\Ltoms\\Ltom25PublicAuctionRegFrm.rdlc";
            localReport.SetParameters(parameters);
            localReport.Refresh();

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.FullPage;
            reportViewer1.Refresh();

            ToogleRunButton(true);
        }

        private void btnRunReport_Click(object sender, System.EventArgs e)

        {
            bool inValidFilter = cmbxAuctionSchedule.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtRpt.Text.Trim()) || cmbxBidders.SelectedIndex == -1;

            if (inValidFilter)
                return;

            LoadReport();
        }

        private void cmbxAuctionSchedule_SelectedIndexChanged(object sender, EventArgs e)

        {
            LoadProperties();
        }

        private void frmLtom25_Load(object sender, System.EventArgs e)

        {
            OnLoad();
        }

        private void LoadAuctionSchedule()

        {
            DataTable dtAuctionSchedule = TreasuryFactory.AuctionRepository().GetAuctionSchedule();

            HelperLoadRecords.AuctionScheduleCombobox(dtAuctionSchedule, cmbxAuctionSchedule, "date", "id");
        }

        private void LoadBidder()

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

                int bidderId = Convert.ToInt32(cmbxBidders.SelectedValue);

                auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);

                backgroundWorker1.RunWorkerAsync((auctionId, bidderId));
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
            LoadBidder();
        }
    }
}