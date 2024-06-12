using ACC.Data;
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
                LoadAuctionSchedule();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadAuctionSchedule()
        {
            var dtAuctionSchedules = AccFactory.AuctionRepository().GetAuctionSchedule();
            HelperLoadRecords.AuctionScheduleCombobox(dtAuctionSchedules, cmbxAuctionSchedule, "date", "id");
        }
    }
}
