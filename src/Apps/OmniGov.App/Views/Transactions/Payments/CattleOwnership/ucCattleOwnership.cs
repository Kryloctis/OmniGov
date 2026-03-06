using OmniGov.App.Helpers;
using OmniGov.Core.Factories;
using OmniGov.Treasury.Data.Factories;
using OmniGov.Treasury.Domain.Entities;
using System.ComponentModel;

namespace OmniGov.App.Views.Transactions.Payments.CattleOwnership
{
    public partial class ucCattleOwnership : UserControl
    {
        public ucCattleOwnership()
        {
            InitializeComponent();
        }

        internal CattleOwnershipModel CattleOwnershipModel()
        {
            return new CattleOwnershipModel()
            {
                TaxpayerId = Convert.ToInt32(cmbxOwner.SelectedValue),
                CattleAge = (int)nudAge.Value,
                CattleName = cmbxType.Text.Trim(),
                CattleSex = radCattleMale.Checked ? "Male" : "Female",
                CattleYears = (int)nudAge.Value,
                Description = txtDescription.Text.Trim(),
                CreatedBy = UserHelper.loggedUser.Id,
            };
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(cmbxType),
                errorProvider1.GetError(txtDescription),
                errorProvider1.GetError(nudYears),
                errorProvider1.GetError(cmbxOwner),
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
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
            nudAge.Value = nudAge.Minimum;
            nudYears.Value = nudYears.Minimum;
            radCattleMale.Checked = true;
            txtDescription.Clear();
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

        private void cmbxOwner_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxOwner);
        }

        private void cmbxOwner_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !OwnerValidated(errorProvider1, cmbxOwner);
        }

        private void cmbxType_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxType);
        }

        private void cmbxType_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxType, "Type");
        }

        private void LoadCattle()
        {
            var dataTable = TreasuryFactory.CattleOwnershipRepository().GetRecords();
            HelperLoadRecords.SearchableCombobox2(dataTable, cmbxType, "id", "cattle_name");
        }

        private void LoadOwners()
        {
            var dtRegistry = TreasuryFactory.TaxpayersRepository().GetRecords();
            HelperLoadRecords.SearchableCombobox2(dtRegistry, cmbxOwner, "id", "name");
        }

        private void nudYears_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudYears);
        }

        private void nudYears_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownEmpty(errorProvider1, nudYears, "Price");
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
    }
}