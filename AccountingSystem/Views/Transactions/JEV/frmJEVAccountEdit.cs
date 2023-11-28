using ACC.Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.JEV
{
    public partial class frmJEVAccountEdit : Form
    {
        private readonly ucJEV ucJEV;
        internal readonly ucJEVAccount ucJEVAccount;

        public frmJEVAccountEdit(ucJEV ucJEV)
        {
            Helper.LoadFormIcon(this);
            InitializeComponent();
            this.ucJEV = ucJEV;
            ucJEVAccount = ucjevAccount1;
            ucJEVAccount.fundId = ucJEV.fundId;
        }

        private void ShowHideRadioButtons()
        {
            if (ucJEV.journalName == "Cash Receipts Journal")
            {
                ucJEVAccount.pnlCollectionsDeposits.Visible = true;
                ucJEVAccount.radCollections.Checked = true;
            }
            else
            {
                ucJEVAccount.pnlCollectionsDeposits.Visible = false;
                ucJEVAccount.radDeposits.Checked = false;
                ucJEVAccount.radCollections.Checked = false;
            }
        }

        private decimal GetAmountDebitCredit(bool isDebit)
        {
            int rowIndex = ucJEV.dgAccounts.CurrentCell.RowIndex;
            if (isDebit)
                return Convert.ToDecimal(ucJEV.dgAccounts.Rows[rowIndex].Cells["Debit"].Value);
            else
                return Convert.ToDecimal(ucJEV.dgAccounts.Rows[rowIndex].Cells["Credit"].Value);
        }

        private void CheckedDebitCredit(bool isDebit)
        {
            if (isDebit)
                ucJEVAccount.radDebit.Checked = true;
            else
                ucJEVAccount.radCredit.Checked = true;
        }

        private void CheckedCollectionsDeposits(bool? isDeposit)
        {
            if (!Convert.ToBoolean(isDeposit))
                ucJEVAccount.radCollections.Checked = true;
            else
                ucJEVAccount.radDeposits.Checked = true;
        }

        private void LoadSelectedRecord()
        {
            int rowIndex = ucJEV.dgAccounts.CurrentCell.RowIndex;

            dynamic fppId = ucJEV.dgAccounts.Rows[rowIndex].Cells["FPPId"].Value;
            ushort generalLedgerId = Convert.ToUInt16(ucJEV.dgAccounts.Rows[rowIndex].Cells["GeneralLedgerId"].Value);
            dynamic subsidiaryLedgerId = ucJEV.dgAccounts.Rows[rowIndex].Cells["SubsidiaryLedgerId"].Value;
            string obligationNo = ucJEV.dgAccounts.Rows[rowIndex].Cells["obligationNo"].Value.ToString();
            bool isDebit = (bool)ucJEV.dgAccounts.Rows[rowIndex].Cells["IsDebit"].Value;
            bool? isDeposit = (bool?)ucJEV.dgAccounts.Rows[rowIndex].Cells["IsDeposit"].Value;
            decimal amount = GetAmountDebitCredit(isDebit);

            ucJEVAccount.txtObligationNo.Text = obligationNo;
            ucJEVAccount.cmbFPP.SelectedValue = string.IsNullOrEmpty(fppId.ToString()) ? 0 : Convert.ToInt32(fppId);

            CheckedDebitCredit(isDebit);
            CheckedCollectionsDeposits(isDeposit);
            ucJEVAccount.cmbxAccount.SelectedValue = generalLedgerId;

            ucJEVAccount.nudAmount.Value = amount;

            ucjevAccount1.LoadSubsidiary();
            if (subsidiaryLedgerId != null) ucJEVAccount.cmbSubsidiary.SelectedValue = subsidiaryLedgerId;
        }

        private bool UpdateAccount()
        {
            try
            {
                if (!ucJEVAccount.ValidateChildren())
                {
                    Helper.MessageBoxError(ucJEVAccount.GetFormErrors());
                    return false;
                }

                string fppId = string.IsNullOrWhiteSpace(ucJEVAccount.cmbFPP.Text) ? string.Empty : ucJEVAccount.cmbFPP.SelectedValue.ToString();
                string fppName = ucJEVAccount.cmbFPP.Text;
                ushort generalLedgerId = Convert.ToUInt16(ucJEVAccount.cmbxAccount.SelectedValue);
                string subsidiaryId = !string.IsNullOrWhiteSpace(ucJEVAccount.cmbSubsidiary.Text) ? ucJEVAccount.cmbSubsidiary.SelectedValue.ToString() : null;
                string subsidiaryName = ucJEVAccount.cmbSubsidiary.Text;
                string obligationNo = ucJEVAccount.txtObligationNo.Text;
                string amount = ucJEVAccount.nudAmount.Value.ToString("N2");
                bool isDebit = ucJEVAccount.radDebit.Checked;
                bool? isDeposit;

                if (ucJEVAccount.radDeposits.Checked)
                    isDeposit = true;
                else if (ucJEVAccount.radCollections.Checked)
                    isDeposit = false;
                else
                    isDeposit = null;

                Dictionary<string, string> accountDict = AccFactory.GeneralLedgerAccountsRepository().GetViewRecordByID(generalLedgerId);

                int rowIndex = ucJEV.dgAccounts.CurrentCell.RowIndex;

                ucJEV.dgAccounts.Rows[rowIndex].Cells["FPPId"].Value = fppId;
                ucJEV.dgAccounts.Rows[rowIndex].Cells["GeneralLedgerId"].Value = generalLedgerId;
                ucJEV.dgAccounts.Rows[rowIndex].Cells["SubsidiaryLedgerId"].Value = subsidiaryId;
                ucJEV.dgAccounts.Rows[rowIndex].Cells["IsDebit"].Value = isDebit;
                ucJEV.dgAccounts.Rows[rowIndex].Cells["IsDeposit"].Value = isDeposit;
                ucJEV.dgAccounts.Rows[rowIndex].Cells["FPP"].Value = fppName;
                ucJEV.dgAccounts.Rows[rowIndex].Cells["AccountCode"].Value = accountDict["account_code"];
                ucJEV.dgAccounts.Rows[rowIndex].Cells["Subsidiary"].Value = subsidiaryName;
                ucJEV.dgAccounts.Rows[rowIndex].Cells["obligationNo"].Value = obligationNo;

                if (isDebit)
                {
                    ucJEV.dgAccounts.Rows[rowIndex].Cells["AccountName"].Value = accountDict["ledger_name"];
                    ucJEV.dgAccounts.Rows[rowIndex].Cells["Debit"].Value = amount;
                    ucJEV.dgAccounts.Rows[rowIndex].Cells["Credit"].Value = "";
                }
                else
                {
                    ucJEV.dgAccounts.Rows[rowIndex].Cells["AccountName"].Value = $"     {accountDict["ledger_name"]}";
                    ucJEV.dgAccounts.Rows[rowIndex].Cells["Debit"].Value = "";
                    ucJEV.dgAccounts.Rows[rowIndex].Cells["Credit"].Value = amount;
                }

                ucJEV.SumDebitCredit();
                return true;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void frmJEVAccountEdit_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                ShowHideRadioButtons();
                ucJEVAccount.LoadFPP();
                ucJEVAccount.LoadAccounts();
                LoadSelectedRecord();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (UpdateAccount())
                Close();
        }
    }
}