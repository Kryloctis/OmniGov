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

namespace AccountingSystem.Views.Transactions.ObligationRequest
{
    public partial class ucObligationRequest : UserControl
    {
        internal int fundId = 0;
        internal int fppId = 0;
        internal int? otherFPPId = null;
        internal int allotmentClassId = 0;
        internal DateTime dateIssued = DateTime.Now;

        public ucObligationRequest()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[2];
            errorArray[0] = epAccount.GetError(cmbxAccount);
            errorArray[1] = epAmount.GetError(nudAmount);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        private void LoadAccounts()
        {
            try
            {
                string accountName = Factory.AllotmentClassesRepository().GetRecordByID(allotmentClassId)["allotment_name"];

                if (Convert.ToInt32(allotmentClassId) == 4)
                {
                    HelperLoadRecords.ObligationRequestAccountCombobox(Factory.GeneralLedgerAccountsRepository().GetAllViewRecords(), cmbxAccount, "ledger_name", "general_ledger_accounts_id");
                }
                else
                {
                    HelperLoadRecords.BudgetAppropriationsGeneralLedgerAccountsCombobox(Factory.GeneralLedgerAccountsRepository().GetViewRecordsByMajAccGroupName(accountName), cmbxAccount, "ledger_name", "general_ledger_accounts_id");
                }

                cmbxAccount.Enabled = true;
                cmbxAccount.SelectedIndex = -1;
                cmbxAccount.SelectedValueChanged += new System.EventHandler(cmbxAccount_SelectedValueChanged);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void ucObligationRequest_Load(object sender, EventArgs e)
        {
            if (!DesignMode) 
            {
                LoadAccounts();
            }
        }

        private void cmbxAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            txtAllotmentBalance.Text = GetTotalAllotmentBalanceAmount().ToString("N2");
        }

        private decimal GetTotalAllotmentBalanceAmount()
        {
            if (cmbxAccount.SelectedIndex > -1) 
            {
                int accountId = Convert.ToInt32(cmbxAccount.SelectedValue);

                var totalAllotmentAmount = Factory.AllotmentReleaseRepository().GetTotalAllotmentReleaseAmount(fundId, fppId, otherFPPId, allotmentClassId, accountId, dateIssued);

                var totalObligationAmountByYear = Factory.ObligationRequestRepository().GetTotalObligationAmountByYear(fundId, fppId, otherFPPId, allotmentClassId, accountId, Convert.ToInt16(dateIssued.Year));

                var totalAllotmentBalanceAmount = Convert.ToDecimal(totalAllotmentAmount["total_allotment_amount"]) - Convert.ToDecimal(totalObligationAmountByYear["total_obligation_amount"]);

                return totalAllotmentBalanceAmount;
            }
            return 0;
        }

        #region Validations

        private bool AccountNotExist(ErrorProvider ep, ComboBox comboBox) 
        {
            try
            {
                if (cmbxAccount.FindStringExact(cmbxAccount.Text) < 0) 
                {
                    ep.SetError(comboBox, "Account Doesn't exist on the list.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void cmbxAccount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxAccount.Text))
                e.Cancel = Helper.ShowErrorComboBoxEmpty(epAccount, cmbxAccount, "Account");
            else
                e.Cancel = AccountNotExist(epAccount, cmbxAccount);
        }

        private void cmbxAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAccount, cmbxAccount);
        }

        private bool AmmountIsZero(ErrorProvider ep, NumericUpDown numericUpDown)
        {
            try
            {
                if (nudAmount.Value == 0)
                {
                    ep.SetError(numericUpDown, "Valuable amount is required.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool AmountExceeds(ErrorProvider ep, NumericUpDown numericUpDown) 
        {
            try
            {
                if (nudAmount.Value > GetTotalAllotmentBalanceAmount())
                {
                    ep.SetError(numericUpDown, "Amount you entered exceeds to the allotment balance");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(nudAmount.Text))
                e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epAmount, nudAmount, "Amount");
            else if (AmmountIsZero(epAmount, nudAmount))
                e.Cancel = AmmountIsZero(epAmount, nudAmount);
            else
                e.Cancel = AmountExceeds(epAmount, nudAmount);
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }

        #endregion Validations
    }
}
