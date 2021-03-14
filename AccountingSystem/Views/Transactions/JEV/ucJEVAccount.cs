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

namespace AccountingSystem.Views.Transactions.JEV
{
    public partial class ucJEVAccount : UserControl
    {
        internal byte fundId;

        public ucJEVAccount()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[3];
            errorArray[0] = epFPP.GetError(cmbFPP);
            errorArray[1] = epAccount.GetError(cmbAccount);
            errorArray[2] = epAmount.GetError(nudAmount);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();

        }

        internal void ResetForm()
        {
            nudAmount.Value = 0;

        }

        internal void LoadFPP()
        {
            try
            {
                DataTable dtFPP = Factory.FunctionProgramProjectRepository().GetRecords();

                HelperLoadRecords.FPPComboBox(dtFPP, cmbFPP, "fpp_name", "id");
                
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadGeneralLedgers()
        {
            try
            {
                this.cmbAccount.SelectedValueChanged -= cmbAccount_SelectedValueChanged;
                DataTable dtGeneralLedgers = Factory.GeneralLedgerAccountsRepository().GetRecords();

                HelperLoadRecords.GeneralLedgerComboBox(dtGeneralLedgers, cmbAccount, "ledger_name", "id");
                this.cmbAccount.SelectedValueChanged += cmbAccount_SelectedValueChanged;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadSubsidiary()
        {
            try
            {
                ushort generalLedgerId = Convert.ToUInt16(cmbAccount.SelectedValue);
                DataTable dtSubsidiary = Factory.SubsidiaryLedgerAccountsRepository().GetRecordsByFundAndGeneralLedger(fundId, generalLedgerId);

                HelperLoadRecords.SubsidiaryLedgerComboBox(dtSubsidiary, cmbSubsidiary, "sub_name", "id");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void cmbAccount_SelectedValueChanged(object sender, EventArgs e)
        { 
            LoadSubsidiary();
        }

        private void cmbFPP_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epFPP, cmbFPP, "FPP");
        }

        private void cmbFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epFPP, cmbFPP);
        }

        private void cmbAccount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epAccount, cmbAccount, "account");
        }

        private void cmbAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAccount, cmbAccount);
        }

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epAmount, nudAmount, "amount");
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }
    }
}
