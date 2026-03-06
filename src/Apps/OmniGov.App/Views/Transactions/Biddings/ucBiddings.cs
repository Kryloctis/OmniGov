using OmniGov.App.Helpers;
using OmniGov.Core.Factories;
using OmniGov.Treasury.Data.Factories;
using OmniGov.Treasury.Domain.Entities;

namespace OmniGov.App.Views.Transactions.Biddings
{
    public partial class ucBiddings : UserControl
    {
        internal bool isEdit = false;
        private int? biddingId;

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
                errorProvider1.GetError(txtAssignedBidderNo),
                errorProvider1.GetError(nudBidAmount),
            };

            return Factory.CreateErrors(errors).GenerateErrorMessage();
        }

        internal void OnLoad(bool isEdit, int? biddingId)
        {
            this.biddingId = biddingId;
            this.isEdit = isEdit;
            if (isEdit)
            {
                LoadSelectedRecord(biddingId.Value);
                nudBidAmount.Enabled = false;
            }
            else ResetForm();
            errorProvider1.Clear();
        }

        internal void ResetForm()
        {
            dtpDate.Value = Helper.GetCurrentDate();
            txtOrdinanceNo.Clear();
            nudBidAmount.Value = 0;
            txtAssignedBidderNo.Clear();

            cmbxAuctionSchedule.ResetText();
            cmbxProperty.ResetText();
            cmbxAuctionSchedule.SelectedIndex = -1;
            cmbxProperty.SelectedIndex = -1;

            nudBidAmount.Enabled = true;
            isEdit = false;

            LoadAuctionSchedule();
            LoadProperties();
        }

        internal bool ValidateInput()
        {
            if (!ValidateChildren())
            {
                Helper.MessageBoxError(GetFormErrors());
                return false;
            }

            return true;
        }

        private bool AssignedBidderNoValidated(ErrorProvider errorProvider, TextBox textBox)
        {
            bool isValidated;
            int rptAuction = Convert.ToInt32(cmbxProperty.SelectedValue);
            string bidderNo = txtAssignedBidderNo.Text.Trim();

            bool bidderNoExist = TreasuryFactory.BiddersRepository().BidderNoExist(rptAuction, bidderNo);

            isValidated = !Helper.ShowErrorTextBoxEmpty(errorProvider, textBox, "Assigned Bidder No.") && !bidderNoExist;
            errorProvider.SetError(textBox, bidderNoExist ? "Assigned Bidder No. Exist." : errorProvider.GetError(textBox));

            return isValidated;
        }

        private void cmbxAuctionSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void cmbxAuctionSchedule_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxAuctionSchedule);
        }

        private void cmbxAuctionSchedule_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxAuctionSchedule, "Auction Schedule.");
        }

        private void cmbxProperty_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxProperty);
        }

        private void cmbxProperty_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxProperty, "Property.");
        }

        private void LoadAuctionSchedule()
        {
            var dtAuctionSchedules = TreasuryFactory.AuctionRepository().GetAuctionSchedule();
            HelperLoadRecords.AuctionScheduleCombobox(dtAuctionSchedules, cmbxAuctionSchedule, "date", "id");
        }

        private void LoadProperties()
        {
            int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
            var rptAuctionModel = new RptAuctionModel() { AuctionId = auctionId };
            var auctionProperties = TreasuryFactory.RptAuctionRepository().GetAuctionProperties(rptAuctionModel);

            cmbxProperty.ValueMember = "rpt_auction_id";
            cmbxProperty.DisplayMember = "complete_arp_no";
            cmbxProperty.DataSource = auctionProperties;
        }

        private void LoadSelectedRecord(int biddingId)
        {
            var dictBid = TreasuryFactory.BidRepository().GetViewRecordById(biddingId);

            cmbxAuctionSchedule.SelectedValue = Convert.ToInt32(dictBid["auction_id"]);
            cmbxProperty.SelectedValue = Convert.ToInt32(dictBid["rpt_auction_id"]);
            dtpDate.Value = Convert.ToDateTime(dictBid["date"]);
            txtOrdinanceNo.Text = dictBid["ordinance_no"].ToString();
            txtAssignedBidderNo.Text = dictBid["bidder_no"].ToString();
            nudBidAmount.Value = Convert.ToDecimal(dictBid["bid_amount"]);
        }

        private void nudBidAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudBidAmount);
        }

        private void nudBidAmount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownZero(errorProvider1, nudBidAmount, "Bid Amount.");
        }

        private void nudBidAmount_ValueChanged(object sender, EventArgs e)
        {
        }

        private void txtAssignedBidderNo_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtAssignedBidderNo);
        }

        private void txtAssignedBidderNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !AssignedBidderNoValidated(errorProvider1, txtAssignedBidderNo);
        }

        private void txtOrdinanceNo_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtOrdinanceNo);
        }

        private void txtOrdinanceNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtOrdinanceNo, "Ordinance No.");
        }
    }
}