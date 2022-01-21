using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.JEV
{
    public partial class frmJEVAccountAdd : Form
    {
        private readonly ucJEV ucJEV;
        internal readonly ucJEVAccount ucJEVAccount;

        public frmJEVAccountAdd(ucJEV _ucJEV)
        {
            InitializeComponent();
            ucJEV = _ucJEV;
            ucJEVAccount = ucjevAccount1;
            ucJEVAccount.fundId = ucJEV.fundId;
        }

        private bool AddAccount()
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
                string generalLedgerId = ucJEVAccount.cmbxAccount.SelectedValue.ToString();
                string subsidiaryId = !string.IsNullOrWhiteSpace(ucJEVAccount.cmbSubsidiary.Text) ? ucJEVAccount.cmbSubsidiary.SelectedValue.ToString() : null;
                string subsidiaryName = ucJEVAccount.cmbSubsidiary.Text;
                string obligationNo = ucJEVAccount.txtObligationNo.Text.Trim();
                string amount = ucJEVAccount.nudAmount.Value.ToString("N2");
                bool isDebit = ucJEVAccount.radDebit.Checked;
                bool? isDeposit;

                if (ucJEVAccount.radDeposits.Checked)
                    isDeposit = true;
                else if (ucJEVAccount.radCollections.Checked)
                    isDeposit = false;
                else
                    isDeposit = null;

                Dictionary<string, string> generalLedgerDict = Factory.GeneralLedgerAccountsRepository().GetViewRecordByID(Convert.ToUInt16(generalLedgerId));

                object[] accountRow;
                if (isDebit)
                {
                    // for debit row
                    accountRow = new object[]
                    {
                        fppId,
                        generalLedgerId,
                        subsidiaryId,
                        isDebit,
                        fppName,
                        generalLedgerDict["ledger_name"],
                        generalLedgerDict["account_code"],
                        subsidiaryName,
                        obligationNo,
                        amount,
                        "",
                        isDeposit
                    };
                }
                else
                {
                    // for credit row
                    accountRow = new object[]
                    {
                        fppId,
                        generalLedgerId,
                        subsidiaryId,
                        isDebit,
                        fppName,
                        $"      {generalLedgerDict["ledger_name"]}",
                        generalLedgerDict["account_code"],
                        subsidiaryName,
                        obligationNo,
                        "",
                        amount,
                        isDeposit
                    };
                }

                ucJEV.dgAccounts.Rows.Add(accountRow);
                ucJEV.SumDebitCredit();
                return true;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void frmJEVAccountAdd_Load(object sender, EventArgs e)
        {
            ucJEVAccount.LoadFPP();
            ucJEVAccount.cmbFPP.SelectedIndex = -1;
            ucJEVAccount.cmbFPP.TextChanged += new EventHandler(ucJEVAccount.cmbxFPP_TextChanged);
            ucJEVAccount.cmbxAccount.SelectedIndex = -1;
            ShowHideRadioButtons();
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (AddAccount())
                ucJEVAccount.ResetForm();
        }
    }
}
