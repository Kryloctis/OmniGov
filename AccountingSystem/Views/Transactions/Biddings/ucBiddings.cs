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

        private void dtpDate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void dtpDate_Validated(object sender, EventArgs e)
        {

        }

        private void txtAssignedBidderNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtAssignedBidderNo, "Bidder Assign No.");
            //insert bidder no. duplicate.
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
