using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.OtherPaymentRates
{
    public partial class frmAddOtherPaymentRates : Form
    {
        private readonly ucOtherPaymentRates _ucOtherPaymentRates;
        private frmOtherPaymentRates _frmOtherPaymentRates;

        public frmAddOtherPaymentRates(frmOtherPaymentRates frmOtherPaymentRates)
        {
            InitializeComponent();
            _frmOtherPaymentRates = frmOtherPaymentRates;
            _ucOtherPaymentRates = ucOtherPaymentRates1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Other payment has been saved.");
                    _frmOtherPaymentRates.RunBackgroundWorker();
                    _ucOtherPaymentRates.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool SaveData()
        {
            if (!_ucOtherPaymentRates.ValidateChildren())
            {
                Helper.MessageBoxError(_ucOtherPaymentRates.GetFormError());
                return false;
            }
            int taxTypeID = Convert.ToInt32(_ucOtherPaymentRates.cmbxTaxType.SelectedValue);
            string description = _ucOtherPaymentRates.txtDescription.Text;
            decimal amount = _ucOtherPaymentRates.nudAmount.Value;
            int startingYear = Convert.ToInt32(_ucOtherPaymentRates.nudStartingYear.Value);
            bool isRateEditable = _ucOtherPaymentRates.cbIsRateEditable.Checked;

            var otherPaymentRatesModel = new OtherPaymentRatesModel()
            {
                TaxTypeID = taxTypeID,
                Description = description,
                Amount = amount,
                StartingYear = startingYear,
                IsRateEditable = isRateEditable,
                CreatedBy = Helper.UserId
            };

            return AccFactory.OtherPaymentRatesRepository().Insert(otherPaymentRatesModel);
        }

        private void frmAddOtherPaymentRates_Load(object sender, EventArgs e)
        {
        }
    }
}