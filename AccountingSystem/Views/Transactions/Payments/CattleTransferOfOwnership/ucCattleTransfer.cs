using ACC.Data;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.CattleTransferOfOwnership
{
    public partial class ucCattleTransfer : UserControl
    {
        public ucCattleTransfer()
        {
            InitializeComponent();
        }

        internal void OnLoad()
        {
            LoadOwners(cmbxOldOwner);
            LoadOwners(cmbxNewOwner);
        }

        internal void ResetForm()
        {
            LoadOwners(cmbxOldOwner);
            LoadOwners(cmbxNewOwner);
            nudAmountOfPurchase.Value = 0;
            dtTransfer.Value = Helper.GetCurrentDate();
            radIsCattleMale.Checked = true;
            nudCattleAge.Value = 0;
            nudCattleYears.Value = 0;
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

            return AccFactory.CreateErrors(errors).GenerateErrorMessage();
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

        private void ucCattleTransferOfOwnership_Load(object sender, EventArgs e)
        {
        }

        private void LoadOwners(ComboBox comboBox)
        {
            var dtOwners = AccFactory.TaxpayersRepository().GetRecords();
            HelperLoadRecords.SearchableCombobox2(dtOwners, comboBox, "id", "name");
        }

        private void LoadCattles(int taxpayersId)
        {
            var dtCattle = AccFactory.CattleOwnershipRepository().GetRecordByTaxpayerId(taxpayersId);
            HelperLoadRecords.SearchableCombobox2(dtCattle, cmbxCattle, "id", "cattle_name");
        }

        private void LoadCattleDetails(int id)
        {
            var dictCattle = AccFactory.CattleOwnershipRepository().GetRecordByID(id);
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
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxCattle_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxCattle);
        }

        private void nudCattleAge_Validating(object sender, CancelEventArgs e)
        {
            Helper.ShowErrorNumericUpDownEmpty(errorProvider1, nudCattleAge, "Cattle Age");
        }

        private void nudCattleAge_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudCattleAge);
        }

        private void nudCattleYears_Validating(object sender, CancelEventArgs e)
        {
            Helper.ShowErrorNumericUpDownEmpty(errorProvider1, nudCattleYears, "Cattle Year");
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
            e.Cancel = Helper.ShowErrorNumericUpDownEmpty(errorProvider1, nudAmountOfPurchase, "Amount of Purchase");
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
                if (cmbxCattle.SelectedValue is int cattleId)
                    LoadCattleDetails(cattleId);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}