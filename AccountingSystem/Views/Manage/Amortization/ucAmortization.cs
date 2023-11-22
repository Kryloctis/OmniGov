using ACC.Data;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Amortization
{
    public partial class ucAmortization : UserControl
    {
        internal bool isEdit;
        internal int amortizationId;

        public ucAmortization()
        {
            InitializeComponent();
        }

        internal void ResetForm()
        {
            txtBankName.Text = string.Empty;
            cmbxTerm.SelectedIndex = 0;
            nudInterest.Value = 0;
            nudAmountRelease.Value = 0;
        }

        internal bool SaveData()
        {
            try
            {
                if (!ValidateChildren())
                {
                    Helper.MessageBoxError(GetFormErrors());
                    return false;
                }

                string bankName = txtBankName.Text.Trim();
                string amortizationTerm = cmbxTerm.Text.Trim();
                int interest = (int)nudInterest.Value;
                decimal amountReleased = nudAmountRelease.Value;

                var amortizationModel = new AmortizationModel()
                {
                    BankName = bankName,
                    AmortizationTerm = amortizationTerm,
                    Interest = interest,
                    AmountReleased = amountReleased
                };

                if (isEdit)
                {
                    amortizationModel.Id = amortizationId;
                    return AccFactory.AmortizationRepository().Update(amortizationModel);
                }
                else
                    return AccFactory.AmortizationRepository().Insert(amortizationModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        internal void LoadSelectedAmortization()
        {
            try
            {
                var dicAmortizationRecord = AccFactory.AmortizationRepository().GetRecordByID(amortizationId);

                string bankName = dicAmortizationRecord["bank_name"];
                string amortizationTerm = dicAmortizationRecord["amortization_term"];
                decimal interest = Convert.ToDecimal(dicAmortizationRecord["interest"]);
                decimal amountReleased = Convert.ToDecimal(dicAmortizationRecord["amount_released"]);

                txtBankName.Text = bankName;
                cmbxTerm.Text = amortizationTerm;
                nudInterest.Value = interest;
                nudAmountRelease.Value = amountReleased;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[2];
            errorArray[0] = epBankName.GetError(txtBankName);
            errorArray[1] = epAmountRelease.GetError(nudAmountRelease);

            IError _errors = AccFactory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        private void txtBankName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epBankName, txtBankName, "Bank Name");
        }

        private void txtBankName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epBankName, txtBankName);
        }

        private void nudAmountRelease_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epAmountRelease, nudAmountRelease, "Amount Released") || Helper.ShowErrorNumericUpDownZero(epAmountRelease, nudAmountRelease, "Amount Released mus be non-zero");
        }

        private void nudAmountRelease_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmountRelease, nudAmountRelease);
        }

        private void OnLoad()
        {
            try
            {
                cmbxTerm.SelectedIndex = 0;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ucAmortization_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
            }
        }

        private void nudInterest_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epInterest, nudInterest, "Interest");
        }

        private void nudInterest_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epInterest, nudInterest);
        }
    }
}