using OmniGov.App.Helpers;
using OmniGov.Core.Factories;
using OmniGov.Treasury.Data.Factories;
using OmniGov.Treasury.Domain.Entities;
using System.ComponentModel;

namespace OmniGov.App.Views.Transactions.Payments.CattleTransferOfOwnership
{
    public partial class ucCattleTransfer : UserControl
    {
        public ucCattleTransfer()
        {
            InitializeComponent();
        }

        internal CattleOwnershipModel GetCattleOwnershipModel()
        {
            int cattleOwnerId = Convert.ToInt32(cmbxNewOwner.SelectedValue);

            return new CattleOwnershipModel()
            {
                TaxpayerId = cattleOwnerId,
                CreatedBy = UserHelper.loggedUser.Id,
                CattleAge = (int)nudCattleAge.Value,
                CattleYears = (int)nudCattleYears.Value,
                Description = txtDescription.Text.Trim(),
                CattleSex = radIsCattleMale.Checked == true ? "Male" : "Female",
                CattleName = cmbxCattle.Text,
            };
        }

        internal PrevCattleOwnershipModel GetPrevCattleOwnershipModel()
        {
            int prevCattleId = Convert.ToInt32(cmbxCattle.SelectedValue);

            return new PrevCattleOwnershipModel()
            {
                PreviousCattleOwnershipId = prevCattleId,
                CattlePrice = nudAmountOfPurchase.Value,
                TransferDate = dtTransfer.Value,
            };
        }

        internal (string oldOwnerName,
                string oldOwnerAddress,
                string oldOwnerMunicipality,
                string oldOwnerProvince,
                string newOwnerName,
                string newOwnerAddress,
                string newOwnerMunicipality,
                string newOwnerProvince,
                string cattleName,
                string cattleSex,
                int cattleAge,
                int cattleYears,
                string cattleDescripion,
                DateTime dateTransfer,
                decimal amountPurchase) GetCattleTransferReceiptContent()
        {
            var dictOldOwner = TreasuryFactory.TaxpayersRepository().GetViewRecordById(Convert.ToInt32(cmbxOldOwner.SelectedValue));
            var dictNewOwner = TreasuryFactory.TaxpayersRepository().GetViewRecordById(Convert.ToInt32(cmbxNewOwner.SelectedValue));

            return (oldOwnerName: dictOldOwner["taxpayers_name"],
                    oldOwnerAddress: dictOldOwner["taxpayers_address"],
                    oldOwnerMunicipality: dictOldOwner["taxpayers_municipality"],
                    oldOwnerProvince: dictOldOwner["taxpayers_province"],
                    newOwnerName: dictNewOwner["taxpayers_name"],
                    newOwnerAddress: dictNewOwner["taxpayers_address"],
                    newOwnerMunicipality: dictNewOwner["taxpayers_municipality"],
                    newOwnerProvince: dictNewOwner["taxpayers_province"],
                    cattleName: cmbxCattle.Text.Trim(),
                    cattleSex: radIsCattleMale.Checked ? "Male" : "Female",
                    cattleAge: (int)nudCattleAge.Value,
                    cattleYears: (int)nudCattleYears.Value,
                    cattleDescripion: txtDescription.Text.Trim(),
                    dateTransfer: dtTransfer.Value,
                    amountPurchase: nudAmountOfPurchase.Value);
        }

        internal void OnLoad()
        {
            LoadOwners(cmbxOldOwner);
            LoadOwners(cmbxNewOwner);
        }

        internal void ResetForm()
        {
            cmbxOldOwner.Text = string.Empty;
            cmbxNewOwner.Text = string.Empty;
            LoadOwners(cmbxOldOwner);
            LoadOwners(cmbxNewOwner);
            nudAmountOfPurchase.Value = 0;
            dtTransfer.Value = Helper.GetCurrentDate();
            radIsCattleMale.Checked = true;
            nudCattleAge.Value = 0;
            nudCattleYears.Value = 0;
            txtDescription.Clear();
        }

        internal string GetFormErrors()
        {
            var errors = new string[]
            {
                errorProvider1.GetError(cmbxOldOwner),
                errorProvider1.GetError(cmbxNewOwner),
                errorProvider1.GetError(cmbxCattle),
                errorProvider1.GetError(nudCattleAge),
                errorProvider1.GetError(nudCattleYears),
                errorProvider1.GetError(nudAmountOfPurchase)
            };

            return Factory.CreateErrors(errors).GenerateErrorMessage();
        }

        private bool ComboboxValueValidated(ErrorProvider errorProvider, ComboBox comboBox, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(comboBox.Text.Trim()) || comboBox.SelectedValue is null)
            {
                errorProvider.SetError(comboBox, Helper.ErrorMessage(fieldName));
                return false;
            }
            return true;
        }

        private void LoadOwners(ComboBox comboBox)
        {
            var dtOwners = TreasuryFactory.TaxpayersRepository().GetRecords();
            HelperLoadRecords.SearchableCombobox2(dtOwners, comboBox, "id", "name");
        }

        private void LoadCattles(int taxpayersId)
        {
            var dtCattle = TreasuryFactory.CattleOwnershipRepository().GetRecordByTaxpayerId(taxpayersId);
            HelperLoadRecords.SearchableCombobox2(dtCattle, cmbxCattle, "id", "cattle_name");
        }

        private void LoadCattleDetails(int id)
        {
            var dictCattle = TreasuryFactory.CattleOwnershipRepository().GetRecordByID(id);
            bool isMale = dictCattle["cattle_sex"] == "Male";
            int Age = Convert.ToInt32(dictCattle["cattle_age"]);
            int Years = Convert.ToInt32(dictCattle["cattle_years"]);

            radIsCattleMale.Checked = isMale;
            radIsCattleFemale.Checked = !isMale;
            nudCattleAge.Value = Age;
            nudCattleYears.Value = Years;
        }

        private void cmbxOldOwner_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !ComboboxValueValidated(errorProvider1, cmbxOldOwner, "Old Owner");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxOldOwner_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxOldOwner);
        }

        private void cmbxCattle_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !ComboboxValueValidated(errorProvider1, cmbxCattle, "Cattle");
            }
            catch (Exception ex) { Helper.MessageBoxError($"cattle {ex.Message}"); }
        }

        private void cmbxCattle_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxCattle);
        }

        private void nudCattleAge_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = Helper.ShowErrorNumericUpDownEmpty(errorProvider1, nudCattleAge, "Cattle Age");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void nudCattleAge_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudCattleAge);
        }

        private void nudCattleYears_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = Helper.ShowErrorNumericUpDownEmpty(errorProvider1, nudCattleYears, "Cattle Year");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void nudCattleYears_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudCattleYears);
        }

        private void cmbxNewOwner_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !ComboboxValueValidated(errorProvider1, cmbxNewOwner, "New Owner");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxNewOwner_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxNewOwner);
        }

        private void nudAmountOfPurchase_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = Helper.ShowErrorNumericUpDownEmpty(errorProvider1, nudAmountOfPurchase, "Amount of Purchase");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void nudAmountOfPurchase_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudAmountOfPurchase);
        }

        private void cmbxOldOwner_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && e.Modifiers == Keys.Shift)
                {
                    LoadOwners(cmbxOldOwner);
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxNewOwner_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && e.Modifiers == Keys.Shift)
                {
                    LoadOwners(cmbxNewOwner);
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxOldOwner_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbxOldOwner.SelectedValue is int oldOwnerId)
                    LoadCattles(oldOwnerId);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxCattle_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbxCattle.SelectedValue is not int cattleId)
                    return;

                LoadCattleDetails(cattleId);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}