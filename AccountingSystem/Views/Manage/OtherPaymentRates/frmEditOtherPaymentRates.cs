using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.OtherPaymentRates
{
    public partial class frmEditOtherPaymentRates : Form
    {
        private frmOtherPaymentRates _frmOtherPaymentRates;
        private int _otherPaymentRatesID;
        private ucOtherPaymentRates _ucOtherPaymentRates;

        public frmEditOtherPaymentRates(frmOtherPaymentRates frmOtherPaymentRates, int otherPaymentRatesID)
        {
            InitializeComponent();
            _frmOtherPaymentRates = frmOtherPaymentRates;
            _otherPaymentRatesID = otherPaymentRatesID;
            _ucOtherPaymentRates = ucOtherPaymentRates1;
        }

        private void frmEditOtherPaymentRates_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            LoadSelectedOtherPaymentRates();
        }

        private void LoadSelectedOtherPaymentRates()
        {
            var dictOtherPaymentRates = AccFactory.OtherPaymentRatesRepository().GetRecordByID(_otherPaymentRatesID);

            int taxTypeId = Convert.ToInt32(dictOtherPaymentRates["tax_type_id"]);
            string description = dictOtherPaymentRates["description"];
            decimal amount = Convert.ToDecimal(dictOtherPaymentRates["amount"]);
            int startingYear = Convert.ToInt32(dictOtherPaymentRates["starting_year"]);
            bool isRateEditable = Convert.ToBoolean(int.Parse(dictOtherPaymentRates["is_rate_editable"]));

            _ucOtherPaymentRates.cmbxTaxType.SelectedValue = taxTypeId;
            _ucOtherPaymentRates.txtDescription.Text = description;
            _ucOtherPaymentRates.nudAmount.Value = amount;
            _ucOtherPaymentRates.nudStartingYear.Value = startingYear;
            _ucOtherPaymentRates.cbIsRateEditable.Checked = isRateEditable;

            _ucOtherPaymentRates.nudAmount.Enabled = isRateEditable;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateData())
                {
                    Helper.MessageBoxSuccess("Other payment rate has been updated.");
                    _frmOtherPaymentRates.RunBackgroundWorker();
                    _ucOtherPaymentRates.ResetForm();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool UpdateData()
        {
            if (!_ucOtherPaymentRates.ValidateChildren())
            {
                Helper.MessageBoxError(_ucOtherPaymentRates.GetFormError());
                return false;
            }

            int otherPaymentRateID = _otherPaymentRatesID;
            int taxTypeID = Convert.ToInt32(_ucOtherPaymentRates.cmbxTaxType.SelectedValue);
            string description = _ucOtherPaymentRates.txtDescription.Text;
            decimal amount = _ucOtherPaymentRates.nudAmount.Value;
            int startingYear = Convert.ToInt32(_ucOtherPaymentRates.nudStartingYear.Value);
            bool isRateEditable = Convert.ToBoolean(_ucOtherPaymentRates.cbIsRateEditable.Checked);

            var otherPaymentRatesModel = new OtherPaymentRatesModel()
            {
                Id = otherPaymentRateID,
                TaxTypeID = taxTypeID,
                Description = description,
                Amount = amount,
                StartingYear = startingYear,
                IsRateEditable = isRateEditable,
                CreatedBy = Helper.UserId
            };

            return AccFactory.OtherPaymentRatesRepository().Update(otherPaymentRatesModel);
        }
    }
}