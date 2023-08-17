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
                errorProvider1.GetError(cmbFPP),
                errorProvider1.GetError(cmbxAccount),
                errorProvider1.GetError(nudAmount),
                errorProvider1.GetError(txtObligationNo)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
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
                cmbxAccount.TextChanged += new EventHandler(CmbxAccout_TextChanged);
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

        #endregion FPP

        #region General Ledger Accounts

        private DataTable DatatableAccounts()
        {
            if (string.IsNullOrEmpty(cmbxAccount.Text))
                return AccFactory.GeneralLedgerAccountsRepository().GetViewRecords();
            else
                return AccFactory.GeneralLedgerAccountsRepository().GetViewRecordsBySearch(cmbxAccount.Text);
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

        private void CmbxAccout_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbxAccount.Text))
            {
                cmbxAccount.TextChanged -= new EventHandler(CmbxAccout_TextChanged);
                LoadAccounts();
                cmbxAccount.SelectedIndex = -1;
                cmbxAccount.TextChanged += new EventHandler(CmbxAccout_TextChanged);
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

        #endregion General Ledger Accounts

        #region Validations

        private bool FPPNameNotExist()
        {
            string fppName = cmbFPP.Text.Trim();

            if (cmbFPP.FindStringExact(fppName) == -1 && !string.IsNullOrWhiteSpace(fppName))
            {
                errorProvider1.SetError(cmbFPP, "FPP you entered doesn't exist.");
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
            Helper.ClearErrorComboBox(errorProvider1, cmbFPP);
        }

        private void cmbxAccount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxAccount, "account");

            if (!string.IsNullOrWhiteSpace(cmbxAccount.Text))
            {
                int generalLedgerId = Convert.ToInt32(cmbxAccount.SelectedValue);

                var idExist = AccFactory.GeneralLedgerAccountsRepository().IdExist(generalLedgerId);

                if (!idExist)
                {
                    errorProvider1.SetError(cmbxAccount, "Account does not exist.");
                    e.Cancel = true;
                }
            }
        }

        private void cmbxAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxAccount);
        }

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownEmpty(errorProvider1, nudAmount, "Amount");
            e.Cancel = Helper.ShowErrorNumericUpDownZero(errorProvider1, nudAmount, "Amount");
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudAmount);
        }

        #endregion Validations
    }
}