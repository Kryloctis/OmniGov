using ACC.Data;
using AccountingSystem.Views.Transactions.Auction;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Ltom
{
    public partial class frmLtom31 : Form
    {
        private ucReportOfSale ucReportOfSale;

        public frmLtom31()
        {
            InitializeComponent();
            ucReportOfSale = ucReportOfSale1;
        }

        private void btnRunReport_Click(object sender, System.EventArgs e)
        {
            try
            {
                int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
                if (cmbxAuctionSchedule.SelectedIndex == -1)
                    return;

                ucReportOfSale.OnLoad(auctionId);

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadAuctionSchedule()
        {
            DataTable dtAuctionSchedule = AccFactory.AuctionRepository().GetAuctionSchedule();
            HelperLoadRecords.AuctionScheduleCombobox(dtAuctionSchedule, cmbxAuctionSchedule, "date", "id");
        }

        private void OnLoad()
        {
            LoadAuctionSchedule();
        }

        private void frmLtom31_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
