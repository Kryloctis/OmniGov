using OmniGov.App.Helpers;
using OmniGov.Core.Factories;
using OmniGov.Treasury.Data.Factories;
using OmniGov.Treasury.Domain.Entities;
using System.ComponentModel;

namespace OmniGov.App.Views.Transactions.Auction
{
    public partial class ucAuctionEvents : UserControl
    {
        private int? auctionId;
        private bool isEdit;

        public ucAuctionEvents()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errors = new string[]
            {
                errorProvider1.GetError(dtpStartDate),
                errorProvider1.GetError(txtLocation),
            };

            return Factory.CreateErrors(errors).GenerateErrorMessage();
        }

        internal void OnLoad(bool isEdit, int? auctionId)
        {
            this.auctionId = auctionId;
            this.isEdit = isEdit;
            if (isEdit) LoadSelectedRecord(auctionId.Value); else ResetForm();
            errorProvider1.Clear();
        }

        private void LoadSelectedRecord(int auctionId)
        {
            var dictAuction = TreasuryFactory.AuctionRepository().GetRecordById(auctionId);

            dtpStartDate.Value = Convert.ToDateTime(dictAuction["start_date"]);
            dtpEndDate.Value = Convert.ToDateTime(dictAuction["end_date"]);
            txtLocation.Text = dictAuction["location"];
        }

        internal void ResetForm()
        {
            dtpStartDate.Value = Helper.GetCurrentDate();
            dtpEndDate.Value = Helper.GetCurrentDate();
            txtLocation.Text = string.Empty;
        }

        internal bool Save(ref bool isEdit)
        {
            isEdit = this.isEdit;

            if (!ValidateChildren())
            {
                Helper.MessageBoxError(GetFormErrors());
                return false;
            }

            return isEdit ? TreasuryFactory.AuctionRepository().Update(AuctionModel()) : TreasuryFactory.AuctionRepository().Insert(AuctionModel());
        }

        private AuctionModel AuctionModel()
        {
            var model = new AuctionModel()
            {
                StartDate = dtpStartDate.Value,
                EndDate = dtpEndDate.Value,
                Location = txtLocation.Text,
                CreatedBy = UserHelper.loggedUser.Id
            };

            if (isEdit) model.Id = auctionId.Value;

            return model;
        }

        private void ucAuction_Load(object sender, EventArgs e)
        {
        }

        #region Validation

        private void dtpStartDate_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorDateTimePickerRange(errorProvider1, dtpStartDate);
        }

        private void dtpStartDate_Validating(object sender, CancelEventArgs e)
        {
            var startDate = dtpStartDate.Value;
            var endDate = dtpEndDate.Value;

            bool invalidDate = endDate < startDate;

            if (invalidDate)
            {
                errorProvider1.SetError(dtpStartDate, "Start date.");
                e.Cancel = invalidDate;
            }
        }

        private void txtLocation_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtLocation);
        }

        private void txtLocation_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtLocation, "Location");
        }

        #endregion Validation

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.MinDate = dtpStartDate.Value;
        }
    }
}