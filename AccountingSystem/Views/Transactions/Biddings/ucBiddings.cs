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
                errorProvider1.GetError(txtAssignedBidderNo),
                errorProvider1.GetError(nudBidAmount),
            };

            return AccFactory.CreateErrors(errors).GenerateErrorMessage();
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


        internal void ResetForm()
        {
            dtpDate.Value = Helper.GetCurrentDate();
            txtOrdinanceNo.Clear();
            nudBidAmount.Value = 0;

            cmbxAuctionSchedule.ResetText();
            cmbxProperty.ResetText();
            cmbxAuctionSchedule.SelectedIndex = -1;
            cmbxProperty.SelectedIndex = -1;

            LoadAuctionSchedule();
            LoadProperties();
        }

        internal void OnLoad()
        {
            try
            {
                ResetForm();
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

        private void cmbxAuctionSchedule_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxAuctionSchedule, "Auction Schedule.");
        }

        private void cmbxAuctionSchedule_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxAuctionSchedule);
        }

        private void cmbxProperty_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxProperty, "Property.");
        }

        private void cmbxProperty_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxProperty);
        }

        private void txtOrdinanceNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtOrdinanceNo, "Ordinance No.");
        }

        private void txtOrdinanceNo_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtOrdinanceNo);
        }

        private bool AssignedBidderNoValidated(ErrorProvider errorProvider, TextBox textBox)
        {
            bool isValidated;
            int rptAuction = Convert.ToInt32(cmbxProperty.SelectedValue);
            string bidderNo = txtAssignedBidderNo.Text.Trim();

            bool bidderNoExist = AccFactory.BiddersRepository().BidderNoExist(rptAuction, bidderNo);

            isValidated = !Helper.ShowErrorTextBoxEmpty(errorProvider, textBox, "Assigned Bidder No.") && !bidderNoExist;
            errorProvider.SetError(textBox, bidderNoExist ? "Assigned Bidder No. Exist." : errorProvider.GetError(textBox));

            return isValidated;
        }

        private void txtAssignedBidderNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                e.Cancel = !AssignedBidderNoValidated(errorProvider1, txtAssignedBidderNo);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtAssignedBidderNo_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtAssignedBidderNo);
        }

        private void nudBidAmount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownZero(errorProvider1, nudBidAmount, "Bid Amount.");
        }

        private void nudBidAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudBidAmount);
        }

    }
}
