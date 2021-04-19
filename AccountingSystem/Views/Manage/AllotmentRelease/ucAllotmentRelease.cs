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
        internal int fppID = 0;
        internal int? othersFPPId = null;
        internal int allotmentClassId = 0;
        internal int fundId = 0;
        internal short year = Convert.ToInt16(DateTime.Now.Year);

        public ucAllotmentRelease()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[2];
            errorArray[0] = epAccount.GetError(groupBox1);
            errorArray[1] = epAmount.GetError(nudAmount);

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void LoadAccounts() 
        {
            try
            {
                HelperLoadRecords.ComboboxBudgetAppropriations(Factory.BudgetAppropriationsRepository().GetViewRecordsByIds(fppID, allotmentClassId, othersFPPId, fundId, year), cmbxAccount, "ledger_name", "budget_appropriations_id");
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

        private void CmbxAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmbxAccount.Text))
                {
                    int budgetAppropriationId = Convert.ToInt32(cmbxAccount.SelectedValue);
                    var appropriationRepo = Factory.BudgetAppropriationsRepository().GetRecordByID(budgetAppropriationId);

                    txtAppropriation.Text = Convert.ToDecimal(appropriationRepo["amount"]).ToString("N2");
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        #region Custom Validations

        private bool ShowErrorAccountEmpty(ErrorProvider ep, ComboBox comboBox, GroupBox groupBox) 
        {
            try
            {
                if (string.IsNullOrEmpty(comboBox.Text))
                {
                    ep.SetError(groupBox, "Appropriation is required.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool ShowAccountExist(ErrorProvider ep, ComboBox comboBox, GroupBox groupBox) 
        {
            try
            {
                if (comboBox.FindStringExact(comboBox.Text) < 0 && !string.IsNullOrEmpty(cmbxAccount.Text)) 
                {
                    ep.SetError(groupBox, "Account you entered. Doesn't exist in your record.");
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
                e.Cancel = ShowErrorAccountEmpty(epAccount, cmbxAccount, groupBox1);
            else
                e.Cancel = !ShowAccountExist(epAccount, cmbxAccount, groupBox1);
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
            if (!ShowAccountExist(epAccount, cmbxAccount, groupBox1)) 
            {
                txtAppropriation.Text = string.Empty;
                txtBalance.Text = string.Empty;
            }
        }
    }
}
