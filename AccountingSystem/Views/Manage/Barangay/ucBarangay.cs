using ACC.Domain.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Barangay
{
    public partial class ucBarangay : UserControl
    {
        internal int barangayId = 0;

        public ucBarangay()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtCode),
                errorProvider1.GetError(txtBarangay)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtCode.Clear();
            txtBarangay.Clear();
            txtCode.Focus();
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtCode, "Barangay Code");

            var barangayRepo = AccFactory.BarangayRepository();

            bool resBrgy;

            if (barangayId == 0)
                resBrgy = barangayRepo.CodeExist(txtCode.Text.Trim());
            else
                resBrgy = barangayRepo.CodeExist(txtCode.Text.Trim(), barangayId);

            if (resBrgy)
            {
                errorProvider1.SetError(txtCode, "Code already exist in your records.");
                e.Cancel = true;
            }
        }

        private void txtCode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtCode);
        }

        private void txtBarangay_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtBarangay, "Barangay Name");

            var brgyRepo = AccFactory.BarangayRepository();

            bool resBrgy;

            if (barangayId == 0)
                resBrgy = brgyRepo.NameExist(txtBarangay.Text.Trim()); // add form
            else
                resBrgy = brgyRepo.NameExist(txtBarangay.Text.Trim(), barangayId); // edit form

            if (resBrgy)
            {
                errorProvider1.SetError(txtBarangay, "Name already exist in your records.");
                e.Cancel = true;
            }
        }

        private void txtBarangay_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtBarangay);
        }

        private void ucBarangay_Load(object sender, EventArgs e)
        {
        }
    }
}