using ACC.Domain.Interfaces;
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

        public ucJEVAccount()
        {
            InitializeComponent();
            cmbAccount.DropDownHeight = 200;
        }


        internal string GetFormErrors()
        {
            var errorArray = new string[4];
            errorArray[0] = epFPP.GetError(cmbFPP);
            errorArray[1] = epAccount.GetError(cmbAccount);
            errorArray[2] = epAmount.GetError(nudAmount);
            errorArray[3] = epObligationNo.GetError(txtObligationNo);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();

        }

        internal void ResetForm()
        {
            nudAmount.Value = 0;

        }

        internal void LoadSubsidiary()
        {
            try
            {
                ushort generalLedgerId = Convert.ToUInt16(cmbAccount.SelectedValue);
                DataTable dtSubsidiary = Factory.SubsidiaryLedgerAccountsRepository().GetRecordsByFundAndGeneralLedger(fundId, generalLedgerId);

                HelperLoadRecords.SubsidiaryLedgerComboBox(dtSubsidiary, cmbSubsidiary, "sub_name", "id");

                btnSubsidiaryLedger.Enabled = true;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSubsidiaryLedger_Click(object sender, EventArgs e)
        {
            //ushort accountId = Convert.ToUInt16(cmbAccount.SelectedValue);
            //_ = new frmSubsidiary(fundId, accountId, 2021).ShowDialog();
        }

        private void ucJEVAccount_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                // validate if it has permission
                if (!Helper.HasPermission("Manage Subsidiary Ledger Account"))
                    btnSubsidiaryLedger.Visible = false;

                //ACCOUNTS
                LoadAccounts();
                cmbAccount.SelectedIndex = -1;
                cmbAccount.TextChanged += new EventHandler(CmbxLedgerAccout_TextChanged);
            }
        }


        //FPP
        private DataTable DataTableFPP()
        {
            DataTable dtFPP;

            if (string.IsNullOrEmpty(cmbFPP.Text))
                dtFPP = Factory.FunctionProgramProjectRepository().GetRecords();
            else
                dtFPP = Factory.FunctionProgramProjectRepository().GetRecordsByCodeName(cmbFPP.Text);

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
            if (e.KeyCode == Keys.F1 && cmbFPP.FindStringExact(cmbFPP.Text) == -1 && !string.IsNullOrEmpty(cmbFPP.Text))
            {
                LoadFPP();
                cmbFPP.DroppedDown = true;
            }
        }



        //ACCOUNT COMBOBOX
        private DataTable DatatableAccounts()
        {
            DataTable dtAccounts;

            if (string.IsNullOrEmpty(cmbAccount.Text))
            {
                dtAccounts = Factory.GeneralLedgerAccountsRepository().GetViewRecords();
            }
            else
            {
                dtAccounts = Factory.GeneralLedgerAccountsRepository().GetViewRecordsBySearch(cmbAccount.Text);
            }

            return dtAccounts;
        }

        private void LoadAccounts()
        {
            try
            {
                cmbAccount.SelectedValueChanged -= new EventHandler(cmxbAccount_SelectedValueChanged);

                if (DatatableAccounts().Rows.Count == 0) return;

                var accountDict = new Dictionary<ushort, string>();
                foreach (DataRow item in DatatableAccounts().Rows)
                {
                    ushort accountId = Convert.ToUInt16(item["general_ledger_accounts_id"]);
                    string accountName = $"{item["account_code"]} - {item["ledger_name"]}";

                    accountDict.Add(accountId, accountName);
                }

                cmbAccount.DataSource = new BindingSource(accountDict, null);
                cmbAccount.DisplayMember = "value";
                cmbAccount.ValueMember = "key";
                cmbAccount.SelectedValueChanged += new EventHandler(cmxbAccount_SelectedValueChanged);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

        }

        private void CmbxLedgerAccout_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbAccount.Text))
            {
                cmbAccount.TextChanged -= new EventHandler(CmbxLedgerAccout_TextChanged);
                LoadAccounts();
                cmbAccount.SelectedIndex = -1;
                cmbAccount.TextChanged += new EventHandler(CmbxLedgerAccout_TextChanged);
            }
        }

        private void cmxbAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadSubsidiary();
        }


        //VALIDATIONS

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
                ;
            }
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }

        private void txtObligationNo_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epObligationNo, txtObligationNo, "Obligation No.");
        }

        private void txtObligationNo_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epObligationNo, txtObligationNo);
        }
    }
}
