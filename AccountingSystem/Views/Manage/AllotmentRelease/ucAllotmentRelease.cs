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
        internal int aroId = 0;
        internal int fppID = 0;
        internal int? othersFPPId = null;
        internal int allotmentClassId = 0;
        internal int fundId = 0;
        internal DateTime dateIssued = DateTime.Now;
        private ucAllotmentReleaseMain _ucAllotmentReleaseMain;

        public ucAllotmentRelease()
        {
            InitializeComponent();
        }

        internal void LoadReference(ucAllotmentReleaseMain ucAllotmentReleaseMain) 
        {
            _ucAllotmentReleaseMain = ucAllotmentReleaseMain;
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[2];
            errorArray[0] = epAccount.GetError(cmbxAccount);
            errorArray[1] = epAmount.GetError(nudAmount);

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private bool ShowErrorAppropriationExistOnList()
        {
            try
            {
                int budgetAppropriationId = Convert.ToInt32(cmbxAccount.SelectedValue);

                foreach (DataGridViewRow row in _ucAllotmentReleaseMain.dgAllotmentRelease.Rows)
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
                HelperLoadRecords.ComboboxBudgetAppropriations(Factory.BudgetAppropriationsRepository().GetViewRecordsByIds(fppID, allotmentClassId, othersFPPId, fundId, dateIssued.Year), cmbxAccount, "ledger_name", "budget_appropriations_id");
                cmbxAccount.SelectedValueChanged += new EventHandler(CmbxAccount_SelectedValueChanged);
                cmbxAccount.TextChanged += new EventHandler(CmbxAccount_TextChanged);
                cmbxAccount.SelectedIndex = -1;
                cmbxAccount.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void DisplayBudgetAppropriationsDetails()
        {
            int budgetAppropriationId = Convert.ToInt32(cmbxAccount.SelectedValue);
            var appropriationInfo = Factory.BudgetAppropriationsRepository().GetRecordByID(budgetAppropriationId);

            int accountId = Convert.ToInt32(appropriationInfo["general_ledger_accounts_id"]);
            var allotmentReleaseInfo = Factory.AllotmentReleaseRepository().GetTotalAllotmentReleaseAmount(fundId, fppID, othersFPPId,
                allotmentClassId, accountId, dateIssued);

            decimal appropriationAmount = Convert.ToDecimal(appropriationInfo["amount"]);
            decimal totalAllotmentRelease = Convert.ToDecimal(allotmentReleaseInfo["total_allotment_amount"]);

            decimal appropriationBalance = appropriationAmount - totalAllotmentRelease;

            txtAppropriation.Text = appropriationAmount.ToString("N2");
            txtBalance.Text = appropriationBalance.ToString("N2");
        }

        private void CmbxAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbxAccount.SelectedIndex > -1)
                {
                    DisplayBudgetAppropriationsDetails();
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        #region Custom Validations

        private bool ShowErrorAmountExceeds(ErrorProvider ep, NumericUpDown numericUpDown)
        {
            try
            {
                int budgetAppropriationId = Convert.ToInt32(cmbxAccount.SelectedValue);

                var budgetAppropriationInfo = Factory.BudgetAppropriationsRepository().GetRecordByID(budgetAppropriationId);

                int accountId = Convert.ToInt32(budgetAppropriationInfo["general_ledger_accounts_id"]);
                var totalAllotmentReleaseInfo = Factory.AllotmentReleaseRepository().GetTotalAllotmentReleaseAmount(fundId, fppID, othersFPPId, allotmentClassId, accountId, dateIssued);

                decimal appropriatonAmount = Convert.ToDecimal(budgetAppropriationInfo["amount"]);
                decimal totalAllotmentRelease = Convert.ToDecimal(totalAllotmentReleaseInfo["total_allotment_amount"]);

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

        private void ClearGroupboxError(ErrorProvider ep, GroupBox groupBox) 
        {
            ep.SetError(groupBox, string.Empty);
        }

        #endregion Custom Validations

        #region Validations

        private void cmbxAccount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxAccount.Text))
                e.Cancel = Helper.ShowErrorComboBoxEmpty(epAccount, cmbxAccount, "FPP");
            else
                e.Cancel = !ShowAccountExist(epAccount, cmbxAccount);
            e.Cancel = ShowErrorAppropriationExistOnList();
        }

        private void cmbxAccount_Validated(object sender, EventArgs e)
        {
            ClearGroupboxError(epAccount, groupBox1);
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

        private void ucAllotmentRelease_Load(object sender, EventArgs e)
        {
            if (!DesignMode) 
            {
                LoadAccounts();
            }
        }

        private void CmbxAccount_TextChanged(object sender, EventArgs e) 
        {
            if (!ShowAccountExist(epAccount, cmbxAccount) || string.IsNullOrEmpty(cmbxAccount.Text)) 
            {
                txtAppropriation.Text = string.Empty;
                txtBalance.Text = string.Empty;
            }
        }
    }
}
