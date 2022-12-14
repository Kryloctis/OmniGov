using ACC.Domain.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.TaxPayers
{
    public partial class ucTaxPayers : UserControl
    {
        internal int taxPayerId;
        internal bool isEdit;

        public ucTaxPayers()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtName)
            };

            IError error = AccFactory.CreateErrors(errorArray);
            return error.GenerateErrorMessage();
        }

        private void LoadTaxPayersType()
        {
            try
            {
                var dtTaxpayerType = AccFactory.TaxpayerTypeRepository().GetRecords();

                cmbxTaxPayerType.DataSource = dtTaxpayerType;
                cmbxTaxPayerType.ValueMember = "id";
                cmbxTaxPayerType.DisplayMember = "taxpayer_type";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void ResetForm()
        {
            if (isEdit)
            {
                taxPayerId = 0;
                isEdit = false;
            }

            txtTIN.Clear();
            txtName.Clear();
            txtContact.Clear();
            txtStreet.Clear();
            txtBarangay.Clear();
            txtMunicipality.Clear();
            txtProvince.Clear();
            chckIsActive.Checked = true;
            LoadTaxPayersType();
        }

        private void ucTaxPayers_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadTaxPayersType();
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtName, "Name");
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtName);
        }
    }
}