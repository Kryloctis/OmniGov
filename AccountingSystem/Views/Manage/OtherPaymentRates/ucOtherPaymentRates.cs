using ACC.Data;
using ACC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.OtherPaymentRates
{
    public partial class ucOtherPaymentRates : UserControl
    {
        public ucOtherPaymentRates()
        {
            InitializeComponent();
        }

        internal string GetFormError()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(cmbxTaxType),
                errorProvider1.GetError(txtDescription)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            cmbxTaxType.SelectedValue = -1;
            nudAmount.Value = 0.0m;
            nudStartingYear.Value = 2023;
            cbIsRateEditable.Checked = false;
            txtDescription.Clear();
        }

        private void ucOtherPaymentRates_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            if (!DesignMode)
            {
                LoadParentCode();
            }
        }

        private void LoadChildCode(int parent, ref Dictionary<int, string> dtSource)
        {
            //DataTable dtChildTaxTypes = AccFactory.TaxTypesRepository().GetChildNodesTaxTypes(parent);

            //if (dtChildTaxTypes.Rows.Count == 0)
            //    return;

            //foreach (DataRow row in dtChildTaxTypes.Rows)
            //{
            //    int id = Convert.ToInt32(row["id"]);
            //    string code = row["code"].ToString();
            //    string description = row["description"].ToString();
            //    string cmbDisplay = $"{code} - {description}";
            //    dtSource.Add(id, cmbDisplay);
            //    LoadChildCode(id, ref dtSource);
            //}
        }

        private void LoadParentCode()
        {
            //DataTable dtTaxTypesCodes = AccFactory.TaxTypesRepository().GetParentNodesTaxTypes();
            //if (dtTaxTypesCodes.Rows.Count == 0)
            //    return;

            //Dictionary<int, string> dtSource = new Dictionary<int, string>();
            //foreach (DataRow row in dtTaxTypesCodes.Rows)
            //{
            //    int id = Convert.ToInt32(row["id"]);
            //    string code = row["code"].ToString();
            //    string parent = row["parent"].ToString();
            //    string description = row["description"].ToString();
            //    string cmbDisplay = $"{code} - {description}";
            //    dtSource.Add(id, cmbDisplay);
            //    LoadChildCode(id, ref dtSource);
            //}

            //cmbxTaxType.DataSource = new BindingSource(dtSource, null); ;
            //cmbxTaxType.ValueMember = "Key";
            //cmbxTaxType.DisplayMember = "Value";
            //cmbxTaxType.SelectedIndex = -1;
        }

        #region Validations

        private void cmbxTaxType_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxTaxType, "Tax Type.");
        }

        private void cmbxTaxType_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxTaxType);
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtDescription, "Description.");
        }

        private void txtDescription_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtDescription);
        }

        #endregion Validations
    }
}