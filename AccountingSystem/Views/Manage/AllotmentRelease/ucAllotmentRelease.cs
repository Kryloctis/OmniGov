using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AllotmentRelease
{
    public partial class ucAllotmentRelease : UserControl
    {
        internal int aroId;
        internal int fppID;
        internal int? othersFPPId;
        internal int allotmentClassId;
        internal int fundId;
        internal DateTime dateIssued;
        private ucAllotmentReleaseMain ucAllotmentMain;

        public ucAllotmentRelease()
        {
            InitializeComponent();
        }

        internal void LoadReference(ucAllotmentReleaseMain ucAllotmentReleaseMain) 
        {
            ucAllotmentMain = ucAllotmentReleaseMain;
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[3];
            errorArray[0] = epAccount.GetError(cmbxAccount);
            errorArray[1] = epAmount.GetError(nudAmount);
            errorArray[2] = AllotmentReleaseExist() ? Tag.ToString() : string.Empty;

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private bool ShowErrorAppropriationExistOnList()
        {
            try
            {
                int budgetAppropriationId = Convert.ToInt32(cmbxAccount.SelectedValue);

                foreach (DataGridViewRow row in ucAllotmentMain.dgAllotmentRelease.Rows)
                {
                    int rowBudgetAppropriationId = Convert.ToInt32(row.Cells["budget_appropriation_id"].Value);
                    bool budgetAppropriationIdExist = rowBudgetAppropriationId == budgetAppropriationId ? true : false;

                    if (budgetAppropriationIdExist)
                    {
                        epAccount.SetError(cmbxAccount, "Account is already on the list.");
                        return true;
                    }
                }

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        internal void LoadAccounts() 
        {
            try
            {
                string accountName = Factory.AllotmentClassesRepository().GetRecordByID(allotmentClassId)["allotment_name"];

                if (Convert.ToInt32(allotmentClassId) == 4)
                    HelperLoadRecords.ObligationRequestAccountCombobox(Factory.GeneralLedgerAccountsRepository().GetAllViewRecords(), cmbxAccount, "ledger_name", "general_ledger_accounts_id");
                else
                    HelperLoadRecords.BudgetAppropriationsGeneralLedgerAccountsCombobox(Factory.GeneralLedgerAccountsRepository().GetViewRecordsByMajAccGroupName(accountName), cmbxAccount, "ledger_name", "general_ledger_accounts_id");

                cmbxAccount.Enabled = true;
                cmbxAccount.SelectedIndex = -1;
                cmbxAccount.SelectedValueChanged += new EventHandler(CmbxAccount_SelectedValueChanged);
                cmbxAccount.TextChanged += new EventHandler(CmbxAccount_TextChanged);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void CmbxAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void CmbxAccount_TextChanged(object sender, EventArgs e)
        {

        }

        private void DisplayBudgetAppropriationsDetails()
        {

        }

        private void ucAllotmentRelease_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadAccounts();
            }
        }

        internal bool AllotmentReleaseExist()
        {
            try
            {
                int budgetAppropriationId = Convert.ToInt32(cmbxAccount.SelectedValue);
                DateTime dateIssued = ucAllotmentMain.dtDateIssued.Value;

                var allotmentReleaseExist = Factory.AllotmentReleaseRepository().allotmentReleaseExist(budgetAppropriationId, dateIssued.ToString("yyyy-MM-dd"));

                if (allotmentReleaseExist)
                {
                    Tag = "Allotment Release already exist on the date it was issued.";
                    return true;
                }

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }


        #region Custom Validations

        private bool ShowErrorAmountExceeds(ErrorProvider ep, NumericUpDown numericUpDown)
        {
            try
            {
                int budgetAppropriationId = Convert.ToInt32(cmbxAccount.SelectedValue);

                var budgetAppropriationInfo = Factory.BudgetAppropriationsRepository().GetRecordByID(budgetAppropriationId);

                int accountId = Convert.ToInt32(budgetAppropriationInfo["general_ledger_accounts_id"]);
                var totalAllotmentRelease = Factory.AllotmentReleaseRepository().GetTotalAllotmentReleaseAmount(fundId, fppID, othersFPPId, allotmentClassId, accountId);

                decimal appropriatonAmount = Convert.ToDecimal(budgetAppropriationInfo["amount"]);

                decimal appropriationBalance = appropriatonAmount - totalAllotmentRelease;

                if (aroId == 0)
                {
                    if (numericUpDown.Value > appropriationBalance)
                    {
                        ep.SetError(numericUpDown, "Amount you entered, exceeds to the appropriate balance.");
                        return true;
                    }
                }

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool ShowAccountExist(ErrorProvider ep, ComboBox comboBox) 
        {
            try
            {
                if (comboBox.FindStringExact(comboBox.Text) < 0 && !string.IsNullOrEmpty(cmbxAccount.Text))
                {
                    ep.SetError(comboBox, "Account you entered. Doesn't exist in your record.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return true;
        }

        private bool ShowErrorAmountIsZero(ErrorProvider ep, NumericUpDown numericUpDown) 
        {
            try
            {
                if (numericUpDown.Value == 0)
                {
                    ep.SetError(numericUpDown, "Valuable Amount is required.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        #endregion Custom Validations


        #region Validations

        private void cmbxAccount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxAccount.Text))
                e.Cancel = Helper.ShowErrorComboBoxEmpty(epAccount, cmbxAccount, "FPP");
            else if (!ShowAccountExist(epAccount, cmbxAccount))
                e.Cancel = !ShowAccountExist(epAccount, cmbxAccount);
            else
                e.Cancel = ShowErrorAppropriationExistOnList();
        }

        private void cmbxAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAccount, cmbxAccount);
        }

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(nudAmount.Text))
                e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epAmount, nudAmount);
            else if (nudAmount.Value == 0)
                e.Cancel = ShowErrorAmountIsZero(epAmount, nudAmount);
            else
                e.Cancel = ShowErrorAmountExceeds(epAmount, nudAmount);
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }

        #endregion Validationses
    }
}
