using ACC.Data;
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

        private void frmLtom27_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            cmbxAuctionSchedule.ResetText();
            cmbxBidders.ResetText();
            cmbxAuctionSchedule.SelectedIndex = -1;
            cmbxBidders.SelectedIndex = -1;

            LoadAuctionSchedule();
            LoadBidders();
        }

        private void LoadAuctionSchedule()
        {
            DataTable dtAuctionSchedule = AccFactory.AuctionRepository().GetAuctionSchedule();
            HelperLoadRecords.AuctionScheduleCombobox(dtAuctionSchedule, cmbxAuctionSchedule, "date", "id");
        }

        private void LoadBidders()
        {
            DataTable dtBidders = AccFactory.BiddersRepository().GetViewRecords();
            HelperLoadRecords.BiddersCombobox(dtBidders, cmbxBidders, "bidder", "id");
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
                int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
                int biddersId = Convert.ToInt32(cmbxBidders.SelectedValue);

                if (cmbxAuctionSchedule.SelectedIndex == -1 || cmbxBidders.SelectedIndex == -1)
                    return;

                ucUnderTakingAndWaiverOfBidders.OnLoad(auctionId, biddersId);

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
