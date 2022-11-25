using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.ChartOfAccounts
{
    public partial class ucGeneralLedgerAccountSearch : UserControl
    {
        public ucGeneralLedgerAccountSearch()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            DataTable dtAccounts = AccFactory.GeneralLedgerAccountsRepository().GetViewRecordsBySearch(cmbGeneralLedgerAccount.Text);

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

        private void cmbGeneralLedgerAccount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epAccount, cmbGeneralLedgerAccount, "account");

            if (!string.IsNullOrWhiteSpace(cmbGeneralLedgerAccount.Text))
            {
                int generalLedgerId = Convert.ToInt32(cmbGeneralLedgerAccount.SelectedValue);

                var idExist = AccFactory.GeneralLedgerAccountsRepository().IdExist(generalLedgerId);

                if (!idExist)
                {
                    epAccount.SetError(cmbGeneralLedgerAccount, "Account does not exist.");
                    e.Cancel = true;
                }
            }
        }

        private void cmbGeneralLedgerAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAccount, cmbGeneralLedgerAccount);
        }
    }
}