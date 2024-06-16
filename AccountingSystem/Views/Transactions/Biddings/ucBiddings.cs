using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Biddings
{
    public partial class ucBiddings : UserControl
    {
        public ucBiddings()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errors = new string[]
            {
                errorProvider1.GetError(cmbxAuctionSchedule),
                errorProvider1.GetError(cmbxProperty),
                errorProvider1.GetError(txtOrdinanceNo),
                errorProvider1.GetError(dtpDate),
                errorProvider1.GetError(nudBidAmount),
            };

            return AccFactory.CreateErrors(errors).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            dtpDate.Value = Helper.GetCurrentDate();
            txtOrdinanceNo.Clear();
            nudBidAmount.Value = 0;
            LoadAuctionSchedule();
        }

        private void ucBiddings_Load(object sender, EventArgs e)
        {
            OnLoad();
        }

        private void OnLoad()
        {
            try
            {
                cmbxAuctionSchedule.ResetText();
                cmbxProperty.ResetText();
                cmbxAuctionSchedule.SelectedIndex = -1;
                cmbxProperty.SelectedIndex = -1;

                LoadAuctionSchedule();
                LoadProperties();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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
            var dtAuctionSchedules = AccFactory.AuctionRepository().GetAuctionSchedule();
            HelperLoadRecords.AuctionScheduleCombobox(dtAuctionSchedules, cmbxAuctionSchedule, "date", "id");
        }

        private void cmbxAuctionSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void nudBidAmount_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
