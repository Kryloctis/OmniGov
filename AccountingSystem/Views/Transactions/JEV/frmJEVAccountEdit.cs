using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.JEV
{
    public partial class frmJEVAccountEdit : Form
    {
        private readonly ucJEV ucJEV;

        public frmJEVAccountEdit(ucJEV ucJEV)
        {
            InitializeComponent();
            this.ucJEV = ucJEV;
            this.ucjevAccount1.fundId = ucJEV.fundId;
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
                MessageBox.Show("Collections");
                uc.radioCollections.Checked = true;
                return;
            }

            MessageBox.Show("Deposits");
            uc.radioDeposits.Checked = true;
        }

        private void LoadSelectedRecord()
        {
            var uc = ucjevAccount1;
            int rowIndex = ucJEV.dgAccounts.CurrentCell.RowIndex;

            object fppId = ucJEV.dgAccounts.Rows[rowIndex].Cells["FPPId"].Value;
            object generalLedgerId = ucJEV.dgAccounts.Rows[rowIndex].Cells["GeneralLedgerId"].Value;
            object subsidiaryLedgerId = ucJEV.dgAccounts.Rows[rowIndex].Cells["SubsidiaryLedgerId"].Value;
            bool isDebit = (bool)ucJEV.dgAccounts.Rows[rowIndex].Cells["IsDebit"].Value;
            bool? isDeposit = (bool?)ucJEV.dgAccounts.Rows[rowIndex].Cells["IsDeposit"].Value;
            decimal amount = GetAmountDebitCredit(isDebit);

            uc.cmbFPP.SelectedValue = fppId;
            uc.cmbAccount.SelectedValue = generalLedgerId;
            CheckedDebitCredit(isDebit);
            CheckedCollectionsDeposits(isDeposit);

            uc.nudAmount.Value = amount;

            // load subsidiaries and select item
            ucjevAccount1.LoadSubsidiary(Convert.ToUInt16(generalLedgerId));
            if (subsidiaryLedgerId != null) uc.cmbSubsidiary.SelectedValue = subsidiaryLedgerId;
        }

        private void UpdateAccount()
        {
            try
            {
                var uc = ucjevAccount1;

                string fppId = uc.cmbFPP.SelectedValue.ToString();
                string fppName = uc.cmbFPP.Text;
                string generalLedgerId = uc.cmbAccount.SelectedValue.ToString();
                string subsidiaryId = !string.IsNullOrWhiteSpace(uc.cmbSubsidiary.Text) ? uc.cmbSubsidiary.SelectedValue.ToString() : null;
                string subsidiaryName = uc.cmbSubsidiary.Text;
                string generalLedgerName = uc.cmbAccount.Text;
                string amount = uc.nudAmount.Value.ToString("N2");
                bool isDebit = uc.radioDebit.Checked;
                bool? isDeposit;

                if (uc.radioDeposits.Checked)
                    isDeposit = true;
                else if (uc.radioCollections.Checked)
                    isDeposit = false;
                else
                    isDeposit = null;

                Dictionary<string, string> accountData = Factory.GeneralLedgerAccountsRepository().GetRecordByID(Convert.ToInt32(generalLedgerId));

                int rowIndex = ucJEV.dgAccounts.CurrentCell.RowIndex;

                ucJEV.dgAccounts.Rows[rowIndex].Cells["FPPId"].Value = fppId;
                ucJEV.dgAccounts.Rows[rowIndex].Cells["GeneralLedgerId"].Value = generalLedgerId;
                ucJEV.dgAccounts.Rows[rowIndex].Cells["SubsidiaryLedgerId"].Value = subsidiaryId;
                ucJEV.dgAccounts.Rows[rowIndex].Cells["IsDebit"].Value = isDebit;
                ucJEV.dgAccounts.Rows[rowIndex].Cells["IsDeposit"].Value = isDeposit;
                ucJEV.dgAccounts.Rows[rowIndex].Cells["FPP"].Value = fppName;
                ucJEV.dgAccounts.Rows[rowIndex].Cells["AccountName"].Value = generalLedgerName;
                ucJEV.dgAccounts.Rows[rowIndex].Cells["AccountCode"].Value = accountData["account_code"];
                ucJEV.dgAccounts.Rows[rowIndex].Cells["Subsidiary"].Value = subsidiaryName;

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
            var uc = ucjevAccount1;
            Helper.LoadFormIcon(this);
            uc.LoadFPP();
            uc.LoadGeneralLedgers();
            LoadSelectedRecord();

            if (ucJEV.journalName != "Cash Receipts Journal")
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

            UpdateAccount();
            Close();
        }
    }
}
