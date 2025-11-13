using ACC.Data;
using LFS.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LFS.Views.Transactions.JEV
{
    public partial class frmJevAccAdd : Form
    {
        private readonly ucJev ucJEV;
        internal readonly ucJEVAccount ucJEVAccount;
        private string journalName;

        public frmJevAccAdd(ucJev _ucJEV, string journalName)
        {
            InitializeComponent();
            ucJEV = _ucJEV;
            ucJEVAccount = ucjevAccount1;
            this.journalName = journalName;
            ucJEVAccount.journalName = journalName;
        }

        private bool AddAccount()
        {
            return false;
            //if (!ucJEVAccount.ValidateChildren())
            //{
            //    Helper.MessageBoxError(ucJEVAccount.GetFormErrors());
            //    return false;
            //}

            //string fppId = string.IsNullOrWhiteSpace(ucJEVAccount.cmbFPP.Text) ? string.Empty : ucJEVAccount.cmbFPP.SelectedValue.ToString();
            //string fppName = ucJEVAccount.cmbFPP.Text;
            //string generalLedgerId = ucJEVAccount.cmbxAccount.SelectedValue.ToString();
            //string subsidiaryId = !string.IsNullOrWhiteSpace(ucJEVAccount.cmbSubsidiary.Text) ? ucJEVAccount.cmbSubsidiary.SelectedValue.ToString() : null;
            //string subsidiaryName = ucJEVAccount.cmbSubsidiary.Text;
            //string obligationNo = ucJEVAccount.txtObligationNo.Text.Trim();
            //string amount = ucJEVAccount.nudAmount.Value.ToString("N2");
            //bool isDebit = ucJEVAccount.radDebit.Checked;
            //bool? isDeposit;

            //if (ucJEVAccount.radDeposits.Checked)
            //    isDeposit = true;
            //else if (ucJEVAccount.radCollections.Checked)
            //    isDeposit = false;
            //else
            //    isDeposit = null;

            //Dictionary<string, string> generalLedgerDict = AccFactory.GeneralLedgerAccountsRepository().GetViewRecordByID(Convert.ToUInt16(generalLedgerId));

            //object[] accountRow;
            //if (isDebit)
            //{
            //    // for debit row
            //    accountRow = new object[]
            //    {
            //        fppId,
            //        generalLedgerId,
            //        subsidiaryId,
            //        isDebit,
            //        fppName,
            //        $"{generalLedgerDict["account_code"]} - {generalLedgerDict["ledger_name"]}",
            //        subsidiaryName,
            //        obligationNo,
            //        amount,
            //        "",
            //        isDeposit
            //    };
            //}
            //else
            //{
            //    // for credit row
            //    accountRow = new object[]
            //    {
            //        fppId,
            //        generalLedgerId,
            //        subsidiaryId,
            //        isDebit,
            //        fppName,
            //        $"      {generalLedgerDict["account_code"]} - {generalLedgerDict["ledger_name"]}",
            //        subsidiaryName,
            //        obligationNo,
            //        "",
            //        amount,
            //        isDeposit
            //    };
            //}

            //ucJEV.dgAccounts.Rows.Add(accountRow);
            //ucJEV.SumDebitCredit();
            //return true;
        }

        private void frmJEVAccountAdd_Load(object sender, EventArgs e)
        {
            try
            {
                ucJEVAccount.OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (AddAccount())
                    ucJEVAccount.ResetForm();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}