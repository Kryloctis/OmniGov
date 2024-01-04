using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Shared;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.CattleOwnership
{
    public partial class ucCattleOwnership : UserControl
    {
        public ucCattleOwnership()
        {
            InitializeComponent();
        }

        internal void OnLoad()
        {
            LoadOwners();
            LoadCattle();
        }

        internal void ResetForm()
        {
            LoadOwners();
            LoadCattle();
            nudAge.Value = 0;
            radCattleMale.Checked = true;
            txtDescription.Clear();
            nudPrice.Value = 0;
        }

        internal CattleOwnershipModel CattleOwnershipModel()
        {
            return new CattleOwnershipModel()
            {
                TaxpayerId = Convert.ToInt32(cmbxOwner.SelectedValue),
                CattleAge = (int)nudAge.Value,
                CattleName = cmbxType.Text.Trim(),
                CattleSex = radCattleMale.Checked ? "Male" : "Female",
                CattlePrice = nudPrice.Value,
                Description = txtDescription.Text.Trim(),
                CreatedBy = Helper.UserId,
            };
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(cmbxType),
                errorProvider1.GetError(txtDescription),
                errorProvider1.GetError(nudPrice),
                errorProvider1.GetError(cmbxOwner),
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private void LoadOwners()
        {
            var dtRegistry = AccFactory.TaxpayersRepository().GetRecords();
            HelperLoadRecords.SearchableCombobox2(dtRegistry, cmbxOwner, "id", "name");
        }

        private void LoadCattle()
        {
            var dataTable = AccFactory.CattleOwnershipRepository().GetRecords();
            HelperLoadRecords.SearchableCombobox2(dataTable, cmbxType, "id", "cattle_name");
        }

        private void cmbxType_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxType, "Type");
        }

        private void cmbxType_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxType);
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtDescription, "Description");
        }

        private void txtDescription_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtDescription);
        }

        private void nudPrice_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownEmpty(errorProvider1, nudPrice, "Price") || Helper.ShowErrorNumericUpDownZero(errorProvider1, nudPrice, "Price");
        }

        private void nudPrice_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudPrice);
        }

        private bool OwnerValidated(ErrorProvider errorProvider, ComboBox comboBox)
        {
            if (Helper.ShowErrorComboBoxEmpty(errorProvider, comboBox, "Taxpayer"))
                return false;
            else if (comboBox.SelectedIndex < 0)
            {
                errorProvider.SetError(comboBox, "Taxpayer");
                return false;
            }

            return true;
        }

        private void cmbxOwner_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !OwnerValidated(errorProvider1, cmbxOwner);
        }

        private void cmbxOwner_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxOwner);
        }

        private void cmbxOwner_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && (Control.ModifierKeys & Keys.Shift) != 0)
            {
                LoadOwners();
                cmbxOwner.DroppedDown = cmbxOwner.DroppedDown ? false : true;
                e.Handled = true;
            }
        }
    }
}