using ACC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.TaxPayers
{
    public partial class ucTaxPayers : UserControl
    {
        public ucTaxPayers()
        {
            InitializeComponent();
        }


        internal string GetFormErrors()
        {
            var errorArray = new string[]
           {
                errorProvider1.GetError(txtTIN),
                errorProvider1.GetError(txtName),
                errorProvider1.GetError(cmbxTaxPayerType),
                errorProvider1.GetError(txtContact),
                errorProvider1.GetError(txtStreet),
                errorProvider1.GetError(txtBarangay),
                errorProvider1.GetError(txtMunicipality),
                errorProvider1.GetError(txtProvince),
           };

            IError error = AccFactory.CreateErrors(errorArray);
            return error.GenerateErrorMessage();
        }

        private void LoadTaxPayersType()
        {
            var dict = new Dictionary<string, string>();

            dict.Add("1", "Association");
            dict.Add("2", "Charitable");
            dict.Add("3", "Cooperative");
            dict.Add("4", "Corporation");
            dict.Add("5", "Educational");
            dict.Add("6", "Government");
            dict.Add("7", "Individual");
            dict.Add("8", "Multiple Owners");
            dict.Add("9", "Partnership");
            dict.Add("10", "Religious");

            cmbxTaxPayerType.DataSource = new BindingSource(dict.Values, null);
        }


        internal void ResetForm()
        {
            txtTIN.Clear();
            txtName.Clear();
            txtContact.Clear();
            txtBarangay.Clear();
            txtStreet.Clear();
            txtMunicipality.Clear();
            txtProvince.Clear();
        }

        private void ucTaxPayers_Load_1(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadTaxPayersType();
            }
        }

        private void txtTIN_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtTIN, "TIN");
        }

        private void txtTIN_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtTIN);
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtName, "Name");
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtName);
        }

        private void cmbxTaxPayerType_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxTaxPayerType, "Type");
        }

        private void cmbxTaxPayerType_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxTaxPayerType);
        }

        private void txtContact_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtContact, "Contact");
        }

        private void txtContact_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtContact);
        }

        private void txtStreet_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtStreet, "Street");
        }

        private void txtStreet_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtStreet);
        }

        private void txtBarangay_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtBarangay, "Barangay");
        }

        private void txtBarangay_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtBarangay);
        }

        private void txtMunicipality_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtMunicipality, "Municipality");
        }

        private void txtMunicipality_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtMunicipality);
        }

        private void txtProvince_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtProvince, "Province");
        }

        private void txtProvince_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtProvince);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddRealProperties().ShowDialog();
        }
    }
}
