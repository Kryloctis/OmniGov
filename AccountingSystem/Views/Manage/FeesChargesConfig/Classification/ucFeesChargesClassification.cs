using ACC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.FeesChargesConfig
{
    public partial class ucFeesChargesClassification : UserControl
    {
        private int? feesChargesClassificationId;
        private bool isEdit;

        public ucFeesChargesClassification()
        {
            InitializeComponent();
        }

        #region Private Methods

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtDesciption),
                errorProvider1.GetError(txtCode)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void OnLoad(bool isEdit, int? feesChargesClassificationId = null)
        {
            //Assign values to private variables
            this.isEdit = isEdit;
            this.feesChargesClassificationId = feesChargesClassificationId;

            //Load Contents
            LoadFunds();
            if (isEdit) LoadSelectedRecord(Convert.ToInt32(feesChargesClassificationId));
        }

        internal void LoadFunds()
        {
            var dtFunds = AccFactory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFund, "fund_name", "id");
        }

        internal void ResetForm()
        {
            txtCode.Clear();
            txtDesciption.Clear();
            txtCOAAccountCode.Clear();
            txtBLFGAccountCode.Clear();
        }

        private void EnableDisableFund()
        {
            if (chckBxFund.Checked)
                cmbxFund.Enabled = true;
            else
            {
                cmbxFund.Text = string.Empty;
                cmbxFund.Enabled = false;
            }
        }

        internal void LoadSelectedRecord(int feesChargesClassificationId)
        {
            var dictFeesChargesClassification = AccFactory.TaxTypesRepository().GetRecordByID(feesChargesClassificationId);
            txtCode.Text = dictFeesChargesClassification["code"];
            txtDesciption.Text = dictFeesChargesClassification["description"];

            //retrieve fund id
            string rawFundId = dictFeesChargesClassification["funds_id"];
            if (!string.IsNullOrWhiteSpace(rawFundId))
            {
                chckBxFund.Checked = true;
                cmbxFund.SelectedValue = Convert.ToInt32(rawFundId);
            }
            else
                chckBxFund.Checked = false;

            txtCOAAccountCode.Text = dictFeesChargesClassification["coa_account_code"];
            txtBLFGAccountCode.Text = dictFeesChargesClassification["blgf_account_code"];
        }

        #endregion Private Methods

        #region Event Methods

        #region Validations

        private void txtDesciption_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtDesciption, "Description.");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtDesciption_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtDesciption);
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtCode, "Code.");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtCode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtCode);
        }

        #endregion Validations

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                EnableDisableFund();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        #endregion Event Methods
    }
}