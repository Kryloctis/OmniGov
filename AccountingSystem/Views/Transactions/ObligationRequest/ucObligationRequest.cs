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
        internal int allotmentClassId = 0;

        public ucObligationRequest()
        {
            InitializeComponent();
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
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void cmbxAccount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epAccount, cmbxAccount, "Account");
        }

        private void cmbxAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAccount, cmbxAccount);
        }

        private bool AmmountIsZero(ErrorProvider ep, NumericUpDown numericUpDown) 
        {
            try
            {
                if(nudAmount.Value == 0)
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

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(nudAmount.Text))
                e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epAmount, nudAmount, "Amount");
            else
                e.Cancel = AmmountIsZero(epAmount, nudAmount);

        }

        private void ucObligationRequest_Load(object sender, EventArgs e)
        {
            if (!DesignMode) 
            {
                LoadAccounts();
            }
        }
    }
}
