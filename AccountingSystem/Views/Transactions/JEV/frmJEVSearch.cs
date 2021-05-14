using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ACC.Domain.Interfaces;

namespace AccountingSystem.Views.Transactions.JEV
{
    public partial class frmJEVSearch : Form
    {
        private readonly frmJEV frmJEV;
        public frmJEVSearch(frmJEV frmJEV)
        {
            InitializeComponent();
            this.frmJEV = frmJEV;
        }

        private void frmJEVSearch_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
        }

        private void CheckedFund(string fundName)
        {
            frmJEV.ucjev1.flowLayoutPanelFunds.Controls.OfType<RadioButton>().FirstOrDefault(r => (r.Text == fundName) ? r.Checked = true : r.Checked = false);
        }

        private void CheckedJournal(string journalName)
        {
            frmJEV.ucjev1.flowLayoutPanelJournals.Controls.OfType<RadioButton>().FirstOrDefault(r => (r.Text == journalName) ? r.Checked = true : r.Checked = false);
        }

        private void LoadJevAccounts()
        {
            var uc = frmJEV.ucjev1;

            DataTable dtJEV = Factory.JEVAccountsRepository().GetViewRecordsByJevId(uc.jevId);
            foreach (DataRow item in dtJEV.Rows)
            {
                string fppId = item["fpp_id"].ToString();
                string fppName = item["fpp_name"].ToString();
                string generalLedgerId = item["general_ledger_accounts_id"].ToString();
                string subsidiaryId = !string.IsNullOrWhiteSpace(item["subsidiary_ledger_accounts_id"].ToString()) ? item["subsidiary_ledger_accounts_id"].ToString() : null;
                string subsidiaryName = item["sub_name"].ToString();
                string generalLedgerName = item["ledger_name"].ToString();
                string accountCode = item["account_code"].ToString();
                decimal amount = Convert.ToDecimal(item["amount"]);
                bool isDebit = Convert.ToBoolean(item["is_debit"]);
                bool? isDeposit;

                if (!string.IsNullOrWhiteSpace(item["is_deposit"].ToString()))
                    isDeposit = Convert.ToBoolean(item["is_deposit"]);
                else
                    isDeposit = null;

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
                        generalLedgerName,
                        accountCode,
                        subsidiaryName,
                        amount.ToString("N2"),
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
                        $"     {generalLedgerName}",
                        accountCode,
                        subsidiaryName,
                        "",
                        amount.ToString("N2")
                    };
                }

                uc.dgAccounts.Rows.Add(accountRow);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var uc = frmJEV.ucjev1;
            try
            {
                bool jevExist = Factory.JEVRepository().JevNumberExist(txtJEV.Text.Trim());

                if (jevExist)
                {
                    string jevNo = txtJEV.Text;
                    string[] jevNoSplit = txtJEV.Text.Split("-");

                    uc.Enabled = true;
                    frmJEV.btnSave.Enabled = true;
                    frmJEV.btnDelete.Enabled = true;

                    frmJEV.ucjev1.txtFundsJevNo.Text = $"{jevNoSplit[0]}-{jevNoSplit[1]}-{jevNoSplit[2]}";
                    frmJEV.ucjev1.txtJEVNo.Text = jevNoSplit[3];

                    Dictionary<string, string> jevDict = Factory.JEVRepository().GetRecordByJEV(jevNo);
                    int jevId = Convert.ToInt32(jevDict["id"]);

                    LoadCheckDisbursementsDataIfExist(uc, jevId);
                    LoadCashReceiptsDataIfExist(uc, jevId);
                    uc.jevId = jevId;
                    uc.txtExplanation.Text = jevDict["explanation"];
                    uc.dtpDateEntry.Value = Convert.ToDateTime(jevDict["date_entry"]);
                    uc.fundId = Convert.ToByte(jevDict["funds_id"]);
                    uc.journalId = Convert.ToByte(jevDict["journals_id"]);
                    CheckedFund(jevDict["fund_name"]);
                    CheckedJournal(jevDict["journal_name"]);

                    uc.dgAccounts.Rows.Clear();
                    LoadJevAccounts();
                    uc.SumDebitCredit();

                    Close();
                    return;
                }

                Helper.MessageBoxError("JEV number doesn't exist.");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private static void LoadCheckDisbursementsDataIfExist(ucJEV uc, int jevId)
        {
            var checkDisbursementsRepository = Factory.CheckDisbursementsJournalRepository();

            if (checkDisbursementsRepository.JevIdExist(jevId))
            {
                Dictionary<string, string> checkDisbursementsData = checkDisbursementsRepository.GetRecordByJevID(jevId);

                uc.txtRCIORADA.Text = checkDisbursementsData["check_number"];
                uc.txtPayee.Text = checkDisbursementsData["payee"];
            }
        }

        private static void LoadCashReceiptsDataIfExist(ucJEV uc, int jevId)
        {
            var cashReceiptsJournalRepository = Factory.CashReceiptsJournalRepository();

            if (cashReceiptsJournalRepository.JevIdExist(jevId))
            {
                Dictionary<string, string> checkDisbursementsData = cashReceiptsJournalRepository.GetViewRecordByJevID(jevId);

                uc.txtRCIORADA.Text = checkDisbursementsData["rcd_number"];
                uc.cmbCollectingDisbursingOfficer.SelectedValue = checkDisbursementsData["collecting_officers_id"];
            }
        }
    }
}
