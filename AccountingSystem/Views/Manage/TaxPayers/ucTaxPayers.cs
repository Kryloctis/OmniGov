using ACC.Data;
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

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private void LoadTaxPayersType()
        {
            var dtTaxpayerType = AccFactory.TaxpayerTypeRepository().GetRecords();

            cmbxTaxPayerType.DataSource = dtTaxpayerType;
            cmbxTaxPayerType.ValueMember = "id";
            cmbxTaxPayerType.DisplayMember = "taxpayer_type";
        }

        internal void ResetForm()
        {
            txtTIN.Clear();
            txtName.Clear();
            txtContact.Clear();
            txtStreet.Clear();
            txtBarangay.Clear();
            txtMunicipality.Clear();
            txtProvince.Clear();
            chckIsActive.Checked = true;
            isEdit = false;
            taxPayerId = 0;
        }

        private void ucTaxPayers_Load(object sender, EventArgs e)
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
                LoadTaxPayersType();
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtName, "Name");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtName);
        }
    }
}