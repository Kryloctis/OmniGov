using Accounting.Data;
using LFS.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Manage.ChartOfAccounts
{
    public partial class ucGeneralLedgerAccountSearch : UserControl
    {
        public ucGeneralLedgerAccountSearch()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtAccounts = AccountingFactory.GeneralLedgerAccountsRepository().GetViewRecordsBySearch(cmbGeneralLedgerAccount.Text);

                if (dtAccounts.Rows.Count == 0 || string.IsNullOrWhiteSpace(cmbGeneralLedgerAccount.Text)) return;

                var accountDict = new Dictionary<int, string>();
                foreach (DataRow item in dtAccounts.Rows)
                {
                    int accountId = Convert.ToInt32(item["general_ledger_accounts_id"]);
                    string accountName = $"{item["account_code"]} - {item["ledger_name"]}";

                    accountDict.Add(accountId, accountName);
                }

                cmbGeneralLedgerAccount.DataSource = new BindingSource(accountDict, null);
                cmbGeneralLedgerAccount.DisplayMember = "value";
                cmbGeneralLedgerAccount.ValueMember = "key";
                cmbGeneralLedgerAccount.DroppedDown = true;

                Helper.ClearErrorComboBox(epAccount, cmbGeneralLedgerAccount);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool GeneralLedgerAccountValidated(ErrorProvider errorProvider, ComboBox comboBox)
        {
            int generalLedgerId = Convert.ToInt32(comboBox.SelectedValue);
            var idExist = AccountingFactory.GeneralLedgerAccountsRepository().IdExist(generalLedgerId);

            if (Helper.ShowErrorComboBoxEmpty(errorProvider, comboBox, "account"))
                return false;
            else if (!idExist)
            {
                errorProvider.SetError(comboBox, "Account does not exist.");
                return false;
            }
            return true;
        }

        private void cmbGeneralLedgerAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAccount, cmbGeneralLedgerAccount);
        }

        private void cmbGeneralLedgerAccount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                GeneralLedgerAccountValidated(epAccount, cmbGeneralLedgerAccount);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
