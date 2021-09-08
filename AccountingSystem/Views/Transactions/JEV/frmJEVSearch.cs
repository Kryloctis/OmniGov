using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.JEV
{
    public partial class frmJEVSearch : Form
    {

        private frmJEV frmJEV;
        private readonly bool _isFromDashboard;

        public frmJEVSearch(bool isFromDashboard, frmJEV frmJEV = null)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.frmJEV = frmJEV;
            _isFromDashboard = isFromDashboard;

            foreach (var item in Helper.MonthsDatasource().Values)
                cbMonth.Items.Add(item);
            cbMonth.SelectedIndex = DateTime.Now.Month - 1;
        }

        private void frmJEVSearch_Load(object sender, EventArgs e)
        {
            Helper.DatagridDefaultStyle(dgJEV);
            LoadJEVList();
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

            foreach (DataRow row in dtJEV.Rows)
            {
                string fppId = row["fpp_id"].ToString();
                string fppName = row["fpp_name"].ToString();
                string generalLedgerId = row["general_ledger_accounts_id"].ToString();
                string subsidiaryId = !string.IsNullOrWhiteSpace(row["subsidiary_ledger_accounts_id"].ToString()) ? row["subsidiary_ledger_accounts_id"].ToString() : null;
                string subsidiaryName = row["subsidiary_ledger_accounts_name"].ToString();
                string obligationNo = row["obligation_no"].ToString();
                string generalLedgerName = row["general_ledger_accounts_name"].ToString();
                string accountCode = row["account_code"].ToString();
                decimal amount = Convert.ToDecimal(row["amount"]);
                bool isDebit = Convert.ToBoolean(row["is_debit"]);
                bool? isDeposit;

                if (!string.IsNullOrWhiteSpace(row["is_deposit"].ToString()))
                    isDeposit = Convert.ToBoolean(row["is_deposit"]);
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
                        obligationNo,
                        amount.ToString("N2"),
                        "",
                    };

                    uc.dgAccounts.Rows.Add(accountRow);
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
                        obligationNo,
                        "",
                        amount.ToString("N2")
                    };

                    uc.dgAccounts.Rows.Add(accountRow);
                }

            }
        }

        private void LoadSelectedJEV()
        {
            if (_isFromDashboard) 
                frmJEV = new frmJEV();

            var uc = frmJEV.ucjev1;
            try
            {
                if (dgJEV.SelectedRows.Count == 1)
                {
                    int rowIndex = dgJEV.CurrentCell.RowIndex;

                    string jevNo = dgJEV.Rows[rowIndex].Cells["jev_no"].Value.ToString();
                    string jevDateOfEntry = dgJEV.Rows[rowIndex].Cells["date_entry"].Value.ToString();
                    string jevFundCode = dgJEV.Rows[rowIndex].Cells["fund_code"].Value.ToString();

                    uc.Enabled = true;
                    frmJEV.btnSave.Enabled = true;
                    frmJEV.btnDelete.Enabled = true;
                    frmJEV.btnPrint.Enabled = true;
                    frmJEV.btnApprove.Enabled = true;
                    frmJEV.ucjev1.txtJEVNo.Text = jevNo;

                    Dictionary<string, string> jevDict = Factory.JEVRepository().GetRecordByJEV(jevNo);
                    int jevId = Convert.ToInt32(jevDict["id"]);

                    LoadCheckDisbursementsDataIfExist(uc, jevId);
                    LoadCashReceiptsDataIfExist(uc, jevId);
                    LoadADADisbursementDataIfExist(uc, jevId);
                    LoadCashDisbursementDataIfExist(uc, jevId);
                    LoadGeneralJournalDataIfExist(uc, jevId);

                    uc.jevId = jevId;
                    uc.fundId = Convert.ToByte(jevDict["funds_id"]);
                    uc.txtExplanation.Text = jevDict["explanation"];
                    uc.dtpDateEntry.Value = Convert.ToDateTime(jevDict["date_entry"]);
                    uc.txtRefNo.Text = jevDict["ref_no"];
                    uc.txtPayee.Text = jevDict["payee"];

                    uc.journalId = Convert.ToByte(jevDict["journals_id"]);
                    uc.oldJournalId = Convert.ToByte(jevDict["journals_id"]);
                    uc.isApproved = Convert.ToByte(jevDict["is_approved"]);
                    uc.isDisapproved = Convert.ToByte(jevDict["is_disapproved"]);
                    uc.isCancelled = Convert.ToByte(jevDict["is_cancelled"]);
                    uc.jevNo = jevDict["jev_no"];

                    CheckedFund(jevDict["fund_name"]);
                    CheckedJournal(jevDict["journal_name"]);

                    uc.ClearErrors();
                    frmJEV.CheckJevStatus(jevId);
                    frmJEV.btnSave.Text = "Update";

                    uc.dgAccounts.Rows.Clear();
                    LoadJevAccounts();

                    if (!frmJEV.Visible)
                    {
                        frmJEV.loadFromDashBoard = true;
                        frmJEV.btnSearch.Enabled = false;
                        frmJEV.ShowDialog();
                    }
                    else
                    {
                        uc.SumDebitCredit();
                        Close();
                    }

                    return;
                }

                Helper.MessageBoxError("JEV number doesn't exist.");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            LoadSelectedJEV();
        }

        private static void LoadCheckDisbursementsDataIfExist(ucJEV uc, int jevId)
        {
            var checkDisbursementsRepository = Factory.CheckDisbursementsJournalRepository();

            if (checkDisbursementsRepository.JevIdExist(jevId))
            {
                Dictionary<string, string> checkDisbursementsDict = checkDisbursementsRepository.GetRecordByJevID(jevId);

                uc.dtpCheckORPaid.Value = Convert.ToDateTime(checkDisbursementsDict["check_date"]);
                uc.txtCheckNo.Text = checkDisbursementsDict["check_no"];
                uc.txtDVRCDNo.Text = checkDisbursementsDict["dv_no"];
                uc.txtRCIORADA.Text = checkDisbursementsDict["rci_no"];
            }
        }

        private static void LoadCashReceiptsDataIfExist(ucJEV uc, int jevId)
        {
            var cashReceiptsJournalRepository = Factory.CashReceiptsJournalRepository();

            if (cashReceiptsJournalRepository.JevIdExist(jevId))
            {
                Dictionary<string, string> checkDisbursementsDict = cashReceiptsJournalRepository.GetViewRecordByJevID(jevId);

                uc.txtDVRCDNo.Text = checkDisbursementsDict["rcd_no"];
                uc.cmbCollectingDisbursingOfficer.SelectedValue = checkDisbursementsDict["collecting_officers_id"];
                uc.txtRCIORADA.Text = checkDisbursementsDict["or_no"];
                uc.dtpCheckORPaid.Value = Convert.ToDateTime(checkDisbursementsDict["or_date"]);
            }
        }

        private static void LoadADADisbursementDataIfExist(ucJEV uc, int jevId)
        {
            var aDADisbursementsJournalRepository = Factory.ADADisbursementsJournalRepository();

            if (aDADisbursementsJournalRepository.JevIdExist(jevId))
            {
                Dictionary<string, string> adaDisbursementsDict = aDADisbursementsJournalRepository.GetViewRecordByJevID(jevId);

                uc.txtDVRCDNo.Text = adaDisbursementsDict["dv_no"];
                uc.txtRCIORADA.Text = adaDisbursementsDict["ada_no"];
            }
        }

        private static void LoadCashDisbursementDataIfExist(ucJEV uc, int jevId)
        {
            var cashDisbursementsJournalRepository = Factory.CashDisbursementsJournalRepository();

            if (cashDisbursementsJournalRepository.JevIdExist(jevId))
            {
                Dictionary<string, string> cashDisbursementsDict = cashDisbursementsJournalRepository.GetViewRecordByJevID(jevId);

                uc.dtpCheckORPaid.Value = Convert.ToDateTime(cashDisbursementsDict["date_paid"]);
                uc.txtDVRCDNo.Text = cashDisbursementsDict["dv_no"];
                uc.cmbCollectingDisbursingOfficer.SelectedValue = Convert.ToInt32(cashDisbursementsDict["disbursing_officers_id"]);
            }
        }

        private static void LoadGeneralJournalDataIfExist(ucJEV uc, int jevId)
        {
            var generalJournalRepository = Factory.GeneralJournalRepository();

            if (generalJournalRepository.JevIdExist(jevId))
            {
                Dictionary<string, string> generalJournalDict = generalJournalRepository.GetViewRecordByJevID(jevId);

                uc.txtCheckNo.Text = generalJournalDict["check_no"];
                uc.txtDVRCDNo.Text = generalJournalDict["dv_no"];
                uc.txtRCIORADA.Text = generalJournalDict["or_no"];
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadJEVList();
        }


        internal void LoadJEVList()
        {
            byte jevStatus = (byte)cmbxJevStatus.SelectedIndex;
            string searchTxt = txtSearch.Text;
            short month = Convert.ToInt16(cbMonth.SelectedIndex + 1);
            short year = Convert.ToInt16(nudYear.Value);

            DataTable dtJEV = Factory.JEVRepository().FilterRecords(jevStatus, searchTxt, month, year);
            HelperLoadRecords.JEVDatagridView(dtJEV, dgJEV);
        }

        private void dgJEV_SelectionChanged(object sender, EventArgs e)
        {
            if (dgJEV.SelectedRows.Count == 1)
            {
                btnOK.Enabled = true;
                return;
            }

            btnOK.Enabled = false;
        }

        private void dgJEV_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            LoadSelectedJEV();
        }

        private void cmbxJevStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadJEVList();
        }

        private void cbMonth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadJEVList();
        }

        private void nudYear_ValueChanged(object sender, EventArgs e)
        {
            LoadJEVList();
        }
    }
}
