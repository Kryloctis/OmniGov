using ACC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using AccountingSystem.Views.Manage.ChartOfAccounts.Subsidiary;

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

        internal void LoadSubsidiary(ushort generalLedgerId)
        {
            try
            {
                DataTable dtSubsidiary = Factory.SubsidiaryLedgerAccountsRepository().GetRecordsByFundAndGeneralLedger(fundId, generalLedgerId);

                HelperLoadRecords.SubsidiaryLedgerComboBox(dtSubsidiary, cmbSubsidiary, "sub_name", "id");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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

            if (!string.IsNullOrWhiteSpace(cmbAccount.Text))
            {
                int generalLedgerId = Convert.ToInt32(cmbAccount.SelectedValue);

                var idExist = Factory.GeneralLedgerAccountsRepository().IdExist(generalLedgerId);

                if (!idExist)
                {
                    epAccount.SetError(cmbAccount, "Account does not exist.");
                    e.Cancel = true;
                }
            }
        }

        private void cmbAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAccount, cmbAccount);
        }

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epAmount, nudAmount, "amount");

            if (nudAmount.Value < 1)
            {
                epAmount.SetError(nudAmount, "Plase enter a non-zero amount.");
;            }
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }

        private void cmbAccount_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ushort generalLedgerId = Convert.ToUInt16(cmbAccount.SelectedValue);
            LoadSubsidiary(generalLedgerId);
            btnSubsidiaryLedger.Enabled = true;
        }

        private void cmbAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbAccount.Text.Length < 4) return;

            if (e.KeyCode == Keys.F1)
            {
                try
                {
                    DataTable dtAccounts = Factory.GeneralLedgerAccountsRepository().GetViewRecordsBySearch(cmbAccount.Text.Trim());

                    if (dtAccounts.Rows.Count == 0 || string.IsNullOrWhiteSpace(cmbAccount.Text.Trim())) return;

                    var accountDict = new Dictionary<int, string>();
                    foreach (DataRow item in dtAccounts.Rows)
                    {
                        int accountId = Convert.ToInt32(item["general_ledger_accounts_id"]);
                        string accountName = $"{item["account_code"]} - {item["ledger_name"]}";

                        accountDict.Add(accountId, accountName);
                    }

                    cmbAccount.DataSource = new BindingSource(accountDict, null);
                    cmbAccount.DisplayMember = "value";
                    cmbAccount.ValueMember = "key";
                    cmbAccount.DroppedDown = true;
                    Cursor.Current = Cursors.Default;

                    Helper.ClearErrorComboBox(epAccount, cmbAccount);
                }
                catch (Exception ex)
                {
                    Helper.MessageBoxError(ex.Message);
                }
            }
        }

        private void btnSubsidiaryLedger_Click(object sender, EventArgs e)
        {
            ushort accountId = Convert.ToUInt16(cmbAccount.SelectedValue);
            _ = new frmSubsidiary(accountId).ShowDialog();
        }
    }
}
