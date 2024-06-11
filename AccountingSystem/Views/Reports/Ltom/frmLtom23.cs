using ACC.Data;
using AccountingSystem.Views.Transactions.Auction;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Ltom
{
    public partial class frmLtom23 : Form
    {

        private ucNoticeOfAuctionSaleOfDelinquentRealProperties ucNoticeOfAuctionSaleOfDelinquentRealProperties;

        public frmLtom23()
        {
            InitializeComponent();
            ucNoticeOfAuctionSaleOfDelinquentRealProperties = ucNoticeOfAuctionSaleOfDelinquentRealProperties1;
        }

        private void LoadAuctionSchedule()
        {
            var dtAuctionSchedule = AccFactory.AuctionRepository().GetAuctionSchedule();
            HelperLoadRecords.AuctionScheduleCombobox(dtAuctionSchedule, cmbxAuctionSchedule, "date", "id");
        }

        private void btnRunReport_Click(object sender, EventArgs e)
        {
            try
            {
                int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
                if (cmbxAuctionSchedule.SelectedIndex == -1)
                    return;

                ucNoticeOfAuctionSaleOfDelinquentRealProperties.OnLoad(auctionId);

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            LoadAuctionSchedule();
        }

        private void frmLtom23_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
