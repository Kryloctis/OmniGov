using ACC.Domain.Models;
using AccountingSystem.Views.Manage.RealProperties;
using AccountingSystem.Views.Manage.TaxPayers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            LoadSelectedOtherPaymentRates();
        }

        private void LoadSelectedOtherPaymentRates()
        {
            var dictOtherPaymentRates = AccFactory.OtherPaymentRatesRepository().GetRecordByID(_otherPaymentRatesID);

            _ucOtherPaymentRates.txtRateID.Text = dictOtherPaymentRates["rate_id"];
            _ucOtherPaymentRates.cmbxTaxType.SelectedValue = Convert.ToInt32(dictOtherPaymentRates["tax_type_id"]);
            _ucOtherPaymentRates.txtDescription.Text = dictOtherPaymentRates["description"];
            _ucOtherPaymentRates.nudAmount.Value = Convert.ToDecimal(dictOtherPaymentRates["amount"]);
            _ucOtherPaymentRates.nudStartingYear.Value = Convert.ToInt32(dictOtherPaymentRates["starting_year"]);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Update())
            {
                Helper.MessageBoxSuccess("Other payment rate has been updated.");
                _frmOtherPaymentRates.LoadOtherPaymentRates();
                Close();
            }
        }

        private bool Update()
        {
            try
            {
                if (!_ucOtherPaymentRates.ValidateChildren())
                {
                    Helper.MessageBoxError(_ucOtherPaymentRates.GetFormError());
                    return false;
                }

                int otherPaymentRateID = _otherPaymentRatesID;
                string rateID = _ucOtherPaymentRates.txtRateID.Text;
                int taxTypeID = Convert.ToInt32(_ucOtherPaymentRates.cmbxTaxType.SelectedValue);
                string description = _ucOtherPaymentRates.txtDescription.Text;
                decimal amount = _ucOtherPaymentRates.nudAmount.Value;
                int startingYear = Convert.ToInt32(_ucOtherPaymentRates.nudStartingYear.Value);

                var otherPaymentRatesModel = new OtherPaymentRatesModel()
                {
                    Id = otherPaymentRateID,
                    RateID = rateID,
                    TaxTypeID = taxTypeID,
                    Description = description,
                    Amount = amount,
                    StartingYear = startingYear,
                    CreatedBy = Helper.UserId
                };

                return AccFactory.OtherPaymentRatesRepository().Update(otherPaymentRatesModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }
    }
}
