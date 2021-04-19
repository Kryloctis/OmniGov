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
        internal int budgetAppropriationsId = 0;

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

        private void LoadObjecExpenditures() 
        {
            try
            {
                //int fppId = Convert.ToInt32(cmbxFPP.SelectedValue);
                //int? othersFPPId = string.IsNullOrEmpty(cmbxOtherFPP.Text) ? null : Convert.ToInt32(cmbxOtherFPP.SelectedValue);

                //HelperLoadRecords.ObjectExpendituresCombobox(cmbxObjectExpenditures, Factory.BudgetAppropriationsRepository().GetViewRecordsByIds(fppId,));
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
                if (budgetAppropriationsId == 0)
                {
                    if (!comboBox.Items.Contains(comboBox.Text)) 
                    {
                        ep.SetError(groupBox, "Account you entered. Doesn't exist in your record.");
                        return true;
                    }
                }
                else
                {
                    
                }
                
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool ShowErrorAmountIsZero(ErrorProvider ep, NumericUpDown numericUpDown) 
        {
            try
            {
                if (numericUpDown.Value == 0)
                {
                    ep.SetError(numericUpDown, "Valuable Amount is required.");
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
                e.Cancel = ShowAccountExist(epAccount, cmbxAccount, groupBox1);
        }

        private void cmbxAccount_Validated(object sender, EventArgs e)
        {
            ClearGroupboxError(epAccount, groupBox1);
        }

        #endregion Validationses

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(nudAmount.Text))
                e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epAmount, nudAmount);
            else if (nudAmount.Value == 0)
                e.Cancel = ShowErrorAmountIsZero(epAmount, nudAmount);
        }
    }
}
