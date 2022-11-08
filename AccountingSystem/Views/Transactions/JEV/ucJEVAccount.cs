using ACC.Domain.Interfaces;
using AccountingSystem.Views.Manage.ChartOfAccounts.Subsidiary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.JEV
{
    public partial class ucJEVAccount : UserControl
    {
        internal byte fundId;
        internal string journalName;

        public ucJEVAccount()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                epFPP.GetError(cmbFPP),
                epAccount.GetError(cmbxAccount),
                epAmount.GetError(nudAmount),
                epObligationNo.GetError(txtObligationNo)
            };

            IError _errors = AccFactory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();

        }

        internal void ResetForm()
        {
            nudAmount.Value = 0;
        }

        private DataTable SubsidiaryLedgerDataTable()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("id", typeof(Int32));
            dataTable.Columns.Add("sub_name");
            ushort generalLedgerId = Convert.ToUInt16(cmbxAccount.SelectedValue);

            var dtSubsidiaryLedger = AccFactory.SubsidiaryLedgerAccountsRepository().GetRecordsByFundAndGeneralLedger(fundId, generalLedgerId);

            foreach (DataRow dataRow in dtSubsidiaryLedger.Rows)
            {
                string subsidiaryName = $"{dataRow["sub_code"]} - {dataRow["sub_name"]}";
                int subId = Convert.ToInt32(dataRow["id"]);

                dataTable.Rows.Add(subId, subsidiaryName);
            }

            return dataTable;
        }

        internal void LoadSubsidiary()
        {
            try
            {
                HelperLoadRecords.SubsidiaryLedgerComboBox(SubsidiaryLedgerDataTable(), cmbSubsidiary, "sub_name", "id");

                btnSubsidiaryLedger.Enabled = true;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ShowSubsidiaryLedger()
        {
            try
            {
                if (cmbxAccount.SelectedIndex == -1)
                {
                    Helper.MessageBoxError("Select an account.");
                    return;
                }

                ushort accountId = Convert.ToUInt16(cmbxAccount.SelectedValue);
                _ = new frmSubsidiary(null, fundId, accountId, 2021).ShowDialog();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void btnSubsidiaryLedger_Click(object sender, EventArgs e)
        {
            ShowSubsidiaryLedger();
        }

        private void ValidatePermissions()
        {
            if (!Helper.HasPermission("Manage > Subsidiary Ledger Account"))
                btnSubsidiaryLedger.Visible = false;
        }

        private void ucJEVAccount_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                ValidatePermissions();
                LoadAccounts();
                cmbxAccount.TextChanged += new EventHandler(CmbxLedgerAccout_TextChanged);
                Set_Default_Account_Of_CashReceiptsJournal();
            }
        }


        #region FPP

        private DataTable DataTableFPP()
        {
            DataTable dtFPP;

            if (string.IsNullOrEmpty(cmbFPP.Text))
                dtFPP = AccFactory.FunctionProgramProjectRepository().GetViewRecords();
            else
                dtFPP = AccFactory.FunctionProgramProjectRepository().GetRecordsByCodeName(cmbFPP.Text);

            return dtFPP;
        }

        internal void LoadFPP()
        {
            try
            {
                cmbFPP.DroppedDown = false;
                Cursor.Current = Cursors.Default;

                if (DataTableFPP().Rows.Count == 0) return;

                var fppDict = new Dictionary<int, string>();
                foreach (DataRow item in DataTableFPP().Rows)
                {
                    int fppId = Convert.ToInt32(item["id"]);
                    string fppName = $"{item["fpp_code"]} - {item["fpp_name"]}";

                    fppDict.Add(fppId, fppName);
                }

                cmbFPP.DataSource = new BindingSource(fppDict, null);
                cmbFPP.DisplayMember = "value";
                cmbFPP.ValueMember = "key";
                cmbFPP.DropDownHeight = 200;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void cmbxFPP_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbFPP.Text))
            {
                cmbFPP.TextChanged -= new EventHandler(cmbxFPP_TextChanged);
                LoadFPP();
                cmbFPP.SelectedIndex = -1;
                cmbFPP.TextChanged += new EventHandler(cmbxFPP_TextChanged);
            }

        }

        private void cmbxFPP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && !string.IsNullOrEmpty(cmbFPP.Text) && cmbFPP.Focused)
            {
                LoadFPP();
                cmbFPP.DroppedDown = true;
            }
        }

        #endregion

        #region General Ledger Accounts

        private DataTable DatatableAccounts()
        {
            if (string.IsNullOrEmpty(cmbxAccount.Text))
                return AccFactory.GeneralLedgerAccountsRepository().GetViewRecords();
            else
                return AccFactory.GeneralLedgerAccountsRepository().GetViewRecordsBySearch(cmbxAccount.Text);
        }

        private void Set_Default_Account_Of_CashReceiptsJournal()
        {
            if (journalName == "Cash Receipts Journal")
            {
                if (((radCollections.Checked && radDebit.Checked) || (radDeposits.Checked && radCredit.Checked)))
                {
                    cmbxAccount.SelectedIndex = 0;
                    cmbxAccount.Enabled = false;
                    epAccount.SetError(cmbxAccount, string.Empty);
                }
                else
                {
                    cmbxAccount.SelectedIndex = -1;
                    cmbxAccount.Enabled = true;
                }
            }
        }

        internal void LoadAccounts()
        {
            try
            {
                cmbxAccount.SelectedValueChanged -= new EventHandler(cmxbAccount_SelectedValueChanged);

                if (DatatableAccounts().Rows.Count == 0) return;

                var accountDict = new Dictionary<ushort, string>();
                foreach (DataRow item in DatatableAccounts().Rows)
                {
                    ushort accountId = Convert.ToUInt16(item["general_ledger_accounts_id"]);
                    string accountName = $"{item["account_code"]} - {item["ledger_name"]}";

                    accountDict.Add(accountId, accountName);
                }

                cmbxAccount.DataSource = new BindingSource(accountDict, null);
                cmbxAccount.DisplayMember = "value";
                cmbxAccount.ValueMember = "key";
                cmbxAccount.DropDownHeight = 200;
                cmbxAccount.SelectedValueChanged += new EventHandler(cmxbAccount_SelectedValueChanged);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

        }

        private void CmbxLedgerAccout_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxAccount.Text))
            {
                cmbxAccount.TextChanged -= new EventHandler(CmbxLedgerAccout_TextChanged);
                LoadAccounts();
                cmbxAccount.SelectedIndex = -1;
                Set_Default_Account_Of_CashReceiptsJournal();
                cmbxAccount.TextChanged += new EventHandler(CmbxLedgerAccout_TextChanged);
            }
        }

        private void cmxbAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadSubsidiary();
        }

        private void cmbxAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && !string.IsNullOrEmpty(cmbxAccount.Text) && cmbxAccount.Focused)
            {
                LoadAccounts();
                cmbxAccount.DroppedDown = true;
            }
        }

        #endregion

        private void radDebit_CheckedChanged(object sender, EventArgs e)
        {
            Set_Default_Account_Of_CashReceiptsJournal();
        }

        private void radCredit_CheckedChanged(object sender, EventArgs e)
        {
            Set_Default_Account_Of_CashReceiptsJournal();
        }

        private void radCollections_CheckedChanged(object sender, EventArgs e)
        {
            Set_Default_Account_Of_CashReceiptsJournal();
        }

        private void radDeposits_CheckedChanged(object sender, EventArgs e)
        {
            Set_Default_Account_Of_CashReceiptsJournal();
        }

        #region Validations

        private bool FPPNameNotExist()
        {
            string fppName = cmbFPP.Text.Trim();

            if (cmbFPP.FindStringExact(fppName) == -1 && !string.IsNullOrWhiteSpace(fppName))
            {
                epFPP.SetError(cmbFPP, "FPP you entered doesn't exist.");
                return true;
            }

            return false;
        }

        private void cmbFPP_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = FPPNameNotExist();
        }

        private void cmbFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epFPP, cmbFPP);
        }

        private void cmbxAccount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epAccount, cmbxAccount, "account");

            if (!string.IsNullOrWhiteSpace(cmbxAccount.Text))
            {
                int generalLedgerId = Convert.ToInt32(cmbxAccount.SelectedValue);

                var idExist = AccFactory.GeneralLedgerAccountsRepository().IdExist(generalLedgerId);

                if (!idExist)
                {
                    epAccount.SetError(cmbxAccount, "Account does not exist.");
                    e.Cancel = true;
                }
            }
        }

        private void cmbxAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAccount, cmbxAccount);
        }

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epAmount, nudAmount, "Amount");
            e.Cancel = Helper.ShowErrorNumericUpDownZero(epAmount, nudAmount, "Amount");
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }

        #endregion
    }
}
