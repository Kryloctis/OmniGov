using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Transactions.Biddings.BiddingReports;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Ltom
{
    public partial class frmLtom27 : Form
    {
        private ucUnderTakingAndWaiverOfBidders ucUnderTakingAndWaiverOfBidders;
        public frmLtom27()
        {
            InitializeComponent();
            ucUnderTakingAndWaiverOfBidders = ucUnderTakingAndWaiverOfBidders1;
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
            cmbxProperties.ResetText();
            cmbxBidders.ResetText();

            cmbxAuctionSchedule.SelectedIndex = -1;
            cmbxProperties.SelectedIndex = -1;
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
            var rptAuctionModel = new RptAuctionModel() { AuctionId = auctionId };
            var auctionProperties = AccFactory.RptAuctionRepository().GetAuctionProperties(rptAuctionModel);

            cmbxProperties.ValueMember = "rpt_auction_id";
            cmbxProperties.DisplayMember = "complete_arp_no";
            cmbxProperties.DataSource = auctionProperties;
        }

        private void LoadAuctionSchedule()
        {
            DataTable dtAuctionSchedule = AccFactory.AuctionRepository().GetAuctionSchedule();
            HelperLoadRecords.AuctionScheduleCombobox(dtAuctionSchedule, cmbxAuctionSchedule, "date", "id");
        }

        private void LoadBidders()
        {
            int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
            int rptAuctionId = Convert.ToInt32(cmbxProperties.SelectedValue);

            var dtBidders = AccFactory.BiddersRepository().GetBiddersByAuctionIdAndRptId(auctionId, rptAuctionId);

            HelperLoadRecords.BiddersCombobox(dtBidders, cmbxBidders, "name", "id");
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
                ToogleRunButton(false);
                int rptAuctionId = Convert.ToInt32(cmbxProperties.SelectedValue);
                int biddersId = Convert.ToInt32(cmbxBidders.SelectedValue);

                if (cmbxAuctionSchedule.SelectedIndex == -1 || cmbxBidders.SelectedIndex == -1)
                    return;

                ucUnderTakingAndWaiverOfBidders.OnLoad(rptAuctionId, biddersId);
                ToogleRunButton(true);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxAuctionSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void cmbxProperties_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBidders();
        }
    }
}
