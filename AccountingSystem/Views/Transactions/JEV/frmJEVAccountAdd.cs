using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.JEV
{
    public partial class frmJEVAccountAdd : Form
    {
        private readonly ucJEV ucJEV;

        public frmJEVAccountAdd(ucJEV ucJEV)
        {
            InitializeComponent();
            this.ucJEV = ucJEV;
            this.ucjevAccount1.fundId = ucJEV.fundId;
        }

        private void AddAccount()
        {
            var uc = ucjevAccount1;

            string fppId = uc.cmbFPP.SelectedValue.ToString();
            string fppName = uc.cmbFPP.Text;
            string generalLedgerId = uc.cmbAccount.SelectedValue.ToString();
            string subsidiaryId = !string.IsNullOrWhiteSpace(uc.cmbSubsidiary.Text) ? uc.cmbSubsidiary.SelectedValue.ToString() : null;
            string subsidiaryName = uc.cmbSubsidiary.Text;
            string obligationNo = uc.txtObligationNo.Text.Trim();
            string amount = uc.nudAmount.Value.ToString("N2");
            bool isDebit = uc.radioDebit.Checked;
            bool? isDeposit;

            if (uc.radioDeposits.Checked)
                isDeposit = true;
            else if (uc.radioCollections.Checked)
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
                    isDeposit,
                    fppName,
                    generalLedgerDict["ledger_name"],
                    generalLedgerDict["account_code"],
                    subsidiaryName,
                    obligationNo,
                    amount,
                    "",
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
                    isDeposit,
                    fppName,
                    $"     {generalLedgerDict["ledger_name"]}",
                    generalLedgerDict["account_code"],
                    subsidiaryName,
                    obligationNo,
                    "",
                    amount,
                };
            }

            ucJEV.dgAccounts.Rows.Add(accountRow);
            ucJEV.SumDebitCredit();
        }

        private void frmJEVAccountAdd_Load(object sender, EventArgs e)
        {
            var uc = ucjevAccount1;
            uc.LoadFPP();
            uc.cmbFPP.SelectedIndex = -1;
            uc.cmbFPP.TextChanged += new EventHandler(uc.cmbxFPP_TextChanged);
            uc.cmbAccount.SelectedIndex = -1;


            if (ucJEV.journalName == "Cash Receipts Journal")
            {
                uc.pnlCollectionsDeposits.Visible = true;
                uc.radioCollections.Checked = true;
            }
            else
            {
                uc.pnlCollectionsDeposits.Visible = false;
                uc.radioDeposits.Checked = false;
                uc.radioCollections.Checked = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var uc = ucjevAccount1;
            // show error kung naa
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return;
            }

            AddAccount();
            uc.ResetForm();
        }
    }
}
