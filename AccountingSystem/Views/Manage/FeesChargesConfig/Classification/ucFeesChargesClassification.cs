using ACC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.FeesChargesConfig
{
    public partial class ucFeesChargesClassification : UserControl
    {
        public ucFeesChargesClassification()
        {
            InitializeComponent();
        }

        #region Private Methods

        private void LoadChildCode(int parent, ref Dictionary<int, string> dtSource)
        {
            DataTable dtChildTaxTypes = AccFactory.TaxTypesRepository().GetChildNodesTaxTypes(parent);

            foreach (DataRow row in dtChildTaxTypes.Rows)
            {
                //int id = Convert.ToInt32(row["id"]);
                //string code = row["code"].ToString();
                //string description = row["description"].ToString();
                //string cmbDisplay = $"{new string(' ', tabCount)}{code} - {description}";
                //dtSource.Add(id, cmbDisplay);
                //tabCount += 10;
                //LoadChildCode(id, ref dtSource);
            }
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

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtDesciption),
                errorProvider1.GetError(txtCode)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

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

        #endregion Private Methods

        private void EnableDisableFund()
        {
            if (chckBxFund.Checked)
                cmbxFund.Enabled = true;
            else
                cmbxFund.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                EnableDisableFund();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}