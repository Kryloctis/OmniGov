using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.JEV
{
    public partial class frmJEVAccountEdit : Form
    {
        private readonly ucJEV ucJEV;
        private readonly ucJEVAccount ucJEVAccount;

        public frmJEVAccountEdit(ucJEV ucJEV)
        {
            InitializeComponent();
            this.ucJEV = ucJEV;
            ucJEVAccount = ucjevAccount1;
            ucJEVAccount.fundId = ucJEV.fundId;
        }

        private decimal GetAmountDebitCredit(bool isDebit)
        {
            int rowIndex = ucJEV.dgAccounts.CurrentCell.RowIndex;
            if (isDebit)
            {
                return Convert.ToDecimal(ucJEV.dgAccounts.Rows[rowIndex].Cells["Debit"].Value);
            }

            return Convert.ToDecimal(ucJEV.dgAccounts.Rows[rowIndex].Cells["Credit"].Value);
        }

        private void CheckedDebitCredit(bool isDebit)
        {
            var uc = ucjevAccount1;
            if (isDebit)
            {
                uc.radioDebit.Checked = true;
                return;
            }

            uc.radioCredit.Checked = true;
        }

        private void CheckedCollectionsDeposits(bool? isDeposit)
        {
            var uc = ucjevAccount1;
            if (Convert.ToBoolean(isDeposit))
            {
                uc.radioCollections.Checked = true;
                return;
            }

            uc.radioDeposits.Checked = true;
        }

        private void LoadSelectedGeneralLedgerAccount(ushort accountId, string accountCode, string accountName)
        {
            var accountDict = new Dictionary<int, string>();
            var concatAccountName = $"{accountCode} - {accountName}";
            accountDict.Add(accountId, concatAccountName);

            ucJEVAccount.cmbAccount.DataSource = new BindingSource(accountDict, null);
            ucJEVAccount.cmbAccount.DisplayMember = "value";
            ucJEVAccount.cmbAccount.ValueMember = "key";
        }

        private void LoadSelectedRecord()
        {
            int rowIndex = ucJEV.dgAccounts.CurrentCell.RowIndex;

            object fppId = ucJEV.dgAccounts.Rows[rowIndex].Cells["FPPId"].Value;
            ushort generalLedgerId = Convert.ToUInt16(ucJEV.dgAccounts.Rows[rowIndex].Cells["GeneralLedgerId"].Value);
            string accountCode = ucJEV.dgAccounts.Rows[rowIndex].Cells["AccountCode"].Value.ToString();
            string accountName = ucJEV.dgAccounts.Rows[rowIndex].Cells["AccountName"].Value.ToString();
            object subsidiaryLedgerId = ucJEV.dgAccounts.Rows[rowIndex].Cells["SubsidiaryLedgerId"].Value;
            string obligationNo = ucJEV.dgAccounts.Rows[rowIndex].Cells["obligationNo"].Value.ToString();
            bool isDebit = (bool)ucJEV.dgAccounts.Rows[rowIndex].Cells["IsDebit"].Value;
            bool? isDeposit = (bool?)ucJEV.dgAccounts.Rows[rowIndex].Cells["IsDeposit"].Value;
            decimal amount = GetAmountDebitCredit(isDebit);

            ucJEVAccount.txtObligationNo.Text = obligationNo;
            ucJEVAccount.cmbFPP.SelectedValue = string.IsNullOrEmpty(fppId.ToString()) ? 0 : Convert.ToInt32(fppId);
            LoadSelectedGeneralLedgerAccount(generalLedgerId, accountCode, accountName);
            CheckedDebitCredit(isDebit);
            CheckedCollectionsDeposits(isDeposit);

            ucJEVAccount.nudAmount.Value = amount;

            // load subsidiaries and select item
            ucjevAccount1.LoadSubsidiary();
            if (subsidiaryLedgerId != null) ucJEVAccount.cmbSubsidiary.SelectedValue = subsidiaryLedgerId;
        }

        private void UpdateAccount()
        {
            try
            {
                var uc = ucjevAccount1;

                string fppId = string.IsNullOrWhiteSpace(uc.cmbFPP.Text) ? string.Empty : uc.cmbFPP.SelectedValue.ToString();
                string fppName = uc.cmbFPP.Text;
                ushort generalLedgerId = Convert.ToUInt16(uc.cmbAccount.SelectedValue);
                string subsidiaryId = !string.IsNullOrWhiteSpace(uc.cmbSubsidiary.Text) ? uc.cmbSubsidiary.SelectedValue.ToString() : null;
                string subsidiaryName = uc.cmbSubsidiary.Text;
                string obligationNo = uc.txtObligationNo.Text;
                string amount = uc.nudAmount.Value.ToString("N2");
                bool isDebit = uc.radioDebit.Checked;
                bool? isDeposit;

                if (uc.radioDeposits.Checked)
                    isDeposit = true;
                else if (uc.radioCollections.Checked)
                    isDeposit = false;
                else
                    isDeposit = null;

                Dictionary<string, string> accountDict = Factory.GeneralLedgerAccountsRepository().GetViewRecordByID(generalLedgerId);

                int rowIndex = ucJEV.dgAccounts.CurrentCell.RowIndex;

                ucJEV.dgAccounts.Rows[rowIndex].Cells["FPPId"].Value = fppId;
                ucJEV.dgAccounts.Rows[rowIndex].Cells["GeneralLedgerId"].Value = generalLedgerId;
                ucJEV.dgAccounts.Rows[rowIndex].Cells["SubsidiaryLedgerId"].Value = subsidiaryId;
                ucJEV.dgAccounts.Rows[rowIndex].Cells["IsDebit"].Value = isDebit;
                ucJEV.dgAccounts.Rows[rowIndex].Cells["IsDeposit"].Value = isDeposit;
                ucJEV.dgAccounts.Rows[rowIndex].Cells["FPP"].Value = fppName;
                ucJEV.dgAccounts.Rows[rowIndex].Cells["AccountName"].Value = accountDict["ledger_name"];
                ucJEV.dgAccounts.Rows[rowIndex].Cells["AccountCode"].Value = accountDict["account_code"];
                ucJEV.dgAccounts.Rows[rowIndex].Cells["Subsidiary"].Value = subsidiaryName;
                ucJEV.dgAccounts.Rows[rowIndex].Cells["obligationNo"].Value = obligationNo;

                if (isDebit)
                {
                    ucJEV.dgAccounts.Rows[rowIndex].Cells["Debit"].Value = amount;
                    ucJEV.dgAccounts.Rows[rowIndex].Cells["Credit"].Value = "";
                }
                else
                {
                    ucJEV.dgAccounts.Rows[rowIndex].Cells["Debit"].Value = "";
                    ucJEV.dgAccounts.Rows[rowIndex].Cells["Credit"].Value = amount;
                }

                ucJEV.SumDebitCredit();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmJEVAccountEdit_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            ucJEVAccount.LoadFPP();
            LoadSelectedRecord();
            ucJEVAccount.cmbFPP.TextChanged += new EventHandler(ucJEVAccount.cmbxFPP_TextChanged);

            if (ucJEV.journalName != "Cash Receipts Journal")
            {
                ucJEVAccount.pnlCollectionsDeposits.Visible = false;
                ucJEVAccount.radioDeposits.Checked = false;
                ucJEVAccount.radioCollections.Checked = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // show error kung naa
            if (!ucJEVAccount.ValidateChildren())
            {
                Helper.MessageBoxError(ucJEVAccount.GetFormErrors());
                return;
            }

            UpdateAccount();
            Close();
        }
    }
}
