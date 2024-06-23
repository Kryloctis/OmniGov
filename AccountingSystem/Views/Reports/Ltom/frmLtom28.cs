using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Transactions.Biddings.BiddingReports;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Ltom
{
    public partial class frmLtom28 : Form
    {
        private ucRulesAndRegulation ucRulesAndRegulation;
        public frmLtom28()
        {
            InitializeComponent();
            ucRulesAndRegulation = ucRulesAndRegulation1;
        }

        private void ToogleRunButton(bool isGenerated)
        {
            btnRunReport.Text = isGenerated ? "Run Report" : "Generating Report...";
            btnRunReport.Enabled = isGenerated;
        }

        private void OnLoad()
        {
            LoadAuctionSchedule();
        }

        private void LoadProperties()
        {
            int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
            var rptAuctionModel = new RptAuctionModel() { AuctionId = auctionId };
            var auctionProperties = AccFactory.RptAuctionRepository().GetAuctionProperties(rptAuctionModel);

            cmbxProperty.ValueMember = "rpt_auction_id";
            cmbxProperty.DisplayMember = "complete_arp_no";
            cmbxProperty.DataSource = auctionProperties;
        }

        private void LoadAuctionSchedule()
        {
            DataTable dtAuctionSchedule = AccFactory.AuctionRepository().GetAuctionSchedule();
            HelperLoadRecords.AuctionScheduleCombobox(dtAuctionSchedule, cmbxAuctionSchedule, "date", "id");
        }

        private void LoadBidders()
        {
            int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
            int rptAuctionId = Convert.ToInt32(cmbxProperty.SelectedValue);

            var dtBidders = AccFactory.BiddersRepository().GetBiddersByAuctionIdAndRptId(auctionId, rptAuctionId);

            HelperLoadRecords.BiddersCombobox(dtBidders, cmbxBidders, "name", "id");
        }

        private void cmbxAuctionSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
                ToogleRunButton(false);
                int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
                int biddersId = Convert.ToInt32(cmbxBidders.SelectedValue);

                if (cmbxAuctionSchedule.SelectedIndex == -1 || cmbxBidders.SelectedIndex == -1)
                    return;

                ucRulesAndRegulation.OnLoad(auctionId, biddersId);
                ToogleRunButton(true);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmLtom28_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBidders();
        }

        private void cmbxAuctionSchedule_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
