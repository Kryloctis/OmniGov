using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Transactions.Biddings.BiddingReports;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Ltom
{
    public partial class frmLtom25 : Form
    {
        private ucPublicAuctionRegistrationForm ucPublicAuctionRegistrationForm;

        public frmLtom25()
        {
            InitializeComponent();
            ucPublicAuctionRegistrationForm = ucPublicAuctionRegistrationForm1;
        }

        private void frmLtom25_Load(object sender, System.EventArgs e)
        {
            OnLoad();
        }

        private void LoadBidders()
        {
            int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
            int rptAuctionId = Convert.ToInt32(cmbxProperty.SelectedValue);
            var dtBidders = AccFactory.BiddersRepository().GetBiddersByAuctionIdAndRptId(auctionId, rptAuctionId);

            cmbxBidders.DisplayMember = "name";
            cmbxBidders.ValueMember = "id";
            cmbxBidders.DataSource = dtBidders;
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

        private void btnRunReport_Click(object sender, System.EventArgs e)
        {
            bool inValidFilter = cmbxAuctionSchedule.SelectedIndex == -1 || cmbxProperty.SelectedIndex == -1 || cmbxBidders.SelectedIndex == -1;

            if (inValidFilter)
                return;

            ucPublicAuctionRegistrationForm.OnLoad();
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
        }

        private void cmbxAuctionSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void cmbxProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBidders();
        }

    }
}
