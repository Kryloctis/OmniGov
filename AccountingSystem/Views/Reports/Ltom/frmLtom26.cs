using ACC.Data;
using AccountingSystem.Views.Transactions.Biddings.BiddingReports;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Ltom
{
    public partial class frmLtom26 : Form
    {
        private ucListOfRegisteredBidders ucListOfRegisteredBidders;
        public frmLtom26()
        {
            InitializeComponent();
            ucListOfRegisteredBidders = ucListOfRegisteredBidders1;
        }

        private void btnRunReport_Click(object sender, System.EventArgs e)
        {
            try
            {
                int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
                if (cmbxAuctionSchedule.SelectedIndex == -1)
                    return;

                ucListOfRegisteredBidders.OnLoad(auctionId);

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            cmbxAuctionSchedule.ResetText();
            cmbxAuctionSchedule.SelectedIndex = -1;

            LoadAuctionSchedule();
        }

        private void LoadAuctionSchedule()
        {
            DataTable dtAuctionSchedule = AccFactory.AuctionRepository().GetAuctionSchedule();
            HelperLoadRecords.AuctionScheduleCombobox(dtAuctionSchedule, cmbxAuctionSchedule, "date", "id");
        }


        private void frmLtom26_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
