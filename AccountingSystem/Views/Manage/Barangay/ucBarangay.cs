using ACC.Domain.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Barangay
{
    public partial class ucBarangay : UserControl
    {
        internal int barangayId;
        internal bool isEdit;

        public ucBarangay()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtCode),
                errorProvider1.GetError(txtName)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtCode.Clear();
            txtName.Clear();
            txtCode.Focus();
        }

        private bool BarangayCodeValidated()
        {
            if (Helper.ShowErrorTextBoxEmpty(errorProvider1, txtCode, "Barangay Code"))
                return false;

            string barangayCode = txtCode.Text.Trim();
            bool codeExist;

            if (!isEdit)
                codeExist = AccFactory.BarangayRepository().CodeExist(barangayCode);
            else
                codeExist = AccFactory.BarangayRepository().CodeExist(barangayCode, barangayId);

            if (codeExist)
            {
                errorProvider1.SetError(txtCode, "Code already exist in your records.");
                return false;
            }

            return true;
        }

        private bool BarangayNameValidated()
        {
            if (Helper.ShowErrorTextBoxEmpty(errorProvider1, txtName, "Barangay Name"))
                return false;

            string barangayName = txtName.Text.Trim();
            bool nameExist;

            if (barangayId == 0)
                nameExist = AccFactory.BarangayRepository().NameExist(barangayName);
            else
                nameExist = AccFactory.BarangayRepository().NameExist(barangayName, barangayId);

            if (nameExist)
            {
                errorProvider1.SetError(txtName, "Name already exist in your records.");
                return false;
            }
            return true;
        }

        private void txtBarangay_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtName);
        }

        private void txtBarangay_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !BarangayNameValidated();
        }

        private void txtCode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtCode);
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !BarangayCodeValidated();
        }
    }
}