using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.ReleasedAndUnReleasedChecks
{
    public partial class frmReleasedAndUnreleaseChecks : Form
    {
        private DataTable releasedAndUnreleasedDT;

        public frmReleasedAndUnreleaseChecks()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgReleasedAndUnreleaseCheques, false);
        }

        private void frmReleasedAndUnreleaseChecks_Load(object sender, EventArgs e)
        {
            LoadBanks();
            LoadFunds();
        }

        internal void LoadBanks()
        {
            try
            {
                var bankRepository = AccFactory.BanksRepository();
                var dtBank = bankRepository.GetRecords();
                cmbxBanks.ComboBox.DataSource = dtBank;
                cmbxBanks.ComboBox.ValueMember = "id";
                cmbxBanks.ComboBox.DisplayMember = "bank_name";
                LoadBankAccounts();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadBankAccounts()
        {
            int bankID = Convert.ToInt32(cmbxBanks.ComboBox.SelectedValue);
            DataTable dtBankAccounts = AccFactory.BankAccountsRepository().GetBankAccountsByBankID(bankID);

            cmbxBankAccounts.ComboBox.DataSource = dtBankAccounts;
            cmbxBankAccounts.ComboBox.ValueMember = "id";
            cmbxBankAccounts.ComboBox.DisplayMember = "account_no";
        }

        private void LoadFunds()
        {
            var dtFunds = AccFactory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds.ComboBox, "fund_name", "id");
        }



        private DataColumn[] ReleasedAndUnreleaseChequesColumn()
        {
            var dataColumns = new DataColumn[]
            {
                new DataColumn("rci_id", typeof(string)),
                new DataColumn("cheques_id", typeof(string)),
                new DataColumn("bank_accounts_id", typeof(string)),
                new DataColumn("funds_id", typeof(string)),
                new DataColumn("cheque_no", typeof(string)),
                new DataColumn("cheque_date", typeof(DateTime)),
                new DataColumn("cheque_amount", typeof(decimal)),
                new DataColumn("fund_code", typeof(string)),
                new DataColumn("fund_name", typeof(string)),
                new DataColumn("dv_no", typeof(string)),
                new DataColumn("payee", typeof(string)),
                new DataColumn("nature_of_payment", typeof(string)),
                new DataColumn("released_date", typeof(string)),
                new DataColumn("status", typeof(string)),
        };

            return dataColumns;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgReleasedAndUnreleaseCheques.SelectedRows.Count == 0)
                return;

            if (Helper.MessageBoxConfirmCancel("Release Cheque?"))
            {
                if (ReleasedCheque())
                {
                    Helper.MessageBoxSuccess("Cheque has been released.");
                }
            }

            return;
        }

        private bool ReleasedCheque()
        {
            try
            {
                int selectedrowindex = dgReleasedAndUnreleaseCheques.SelectedCells[0].RowIndex;
                int RCIID = Convert.ToInt32(dgReleasedAndUnreleaseCheques.Rows[selectedrowindex].Cells["rci_id"].Value);
                int chequeID = Convert.ToInt32(dgReleasedAndUnreleaseCheques.Rows[selectedrowindex].Cells["cheques_id"].Value);

                var releasedChequesModel = new ReleasedChequesModel()
                {
                    RCIID = RCIID,
                    DateReleased = DateTime.Now,
                };

                var releasedChequesRepository = AccFactory.ReleasedChequesRepository();
                return releasedChequesRepository.Insert(releasedChequesModel);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            return false;
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadRecords()
        {
            if (!bgwListOfScheduleReleasedChecks.IsBusy)
            {
                pbLoadRecords.Value = 0;
                DateTime searchDateIssued = dtpDateIssued.Value;
                string searchText = txtSearch.Text.Trim();
                int bankAccountID = Convert.ToInt32(cmbxBankAccounts.ComboBox.SelectedValue);
                int fundId = Convert.ToInt32(cmbxFunds.ComboBox.SelectedValue);
                bgwListOfScheduleReleasedChecks.RunWorkerAsync((bankAccountID, fundId, searchText, cbxShowReleasedChecks.Checked));
            }
        }

        private void bgwListOfScheduleReleasedChecks_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((int bankAccountId, int fundsID, string txtSearch, bool showAll))e.Argument;

                var releasedChequesRepo = AccFactory.ReleasedChequesRepository();
                var dtViewReleasedCheques = releasedChequesRepo.GetViewRecords(parameters.bankAccountId, parameters.fundsID, parameters.txtSearch, parameters.showAll);

                int totalProgressCount = dtViewReleasedCheques.Rows.Count;
                int progressCount = 0;

                releasedAndUnreleasedDT = new DataTable();
                releasedAndUnreleasedDT.Columns.AddRange(ReleasedAndUnreleaseChequesColumn());

                foreach (DataRow row in dtViewReleasedCheques.Rows)
                {
                    var newRow = releasedAndUnreleasedDT.NewRow();

                    string id = row["rci_id"].ToString();
                    string chquesID = row["cheques_id"].ToString();
                    string bankAccountsID = row["bank_accounts_id"].ToString();
                    string fundID = row["funds_id"].ToString();
                    string chequeNo = row["cheque_no"].ToString();
                    string chequeDate = row["cheque_date"].ToString();
                    decimal amount = Convert.ToDecimal(row["cheque_amount"]);
                    string fundCode = row["fund_code"].ToString();
                    string fundName = row["fund_name"].ToString();
                    string dvNo = row["dv_no"].ToString();
                    string payee = row["payee"].ToString();
                    string natureOfPayment = row["nature_of_payment"].ToString();
                    string releasedDate = string.IsNullOrEmpty(row["date_released"].ToString()) ? string.Empty : row["date_released"].ToString();
                    string status = string.IsNullOrEmpty(row["released_cheques_id"].ToString()) ? "Unreleased" : "Released";

                    newRow["rci_id"] = id;
                    newRow["cheques_id"] = chquesID;
                    newRow["bank_accounts_id"] = bankAccountsID;
                    newRow["funds_id"] = fundID;
                    newRow["cheque_no"] = chequeNo;
                    newRow["cheque_date"] = chequeDate;
                    newRow["cheque_amount"] = amount;
                    newRow["fund_code"] = fundCode;
                    newRow["fund_name"] = fundName;
                    newRow["dv_no"] = dvNo;
                    newRow["payee"] = payee;
                    newRow["nature_of_payment"] = natureOfPayment;
                    newRow["released_date"] = releasedDate;
                    newRow["status"] = status;

                    releasedAndUnreleasedDT.Rows.Add(newRow);

                    progressCount++;
                    Helper.ProgressCounter(bgwListOfScheduleReleasedChecks, totalProgressCount, progressCount);
                }

                e.Result = releasedAndUnreleasedDT;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void bgwListOfScheduleReleasedChecks_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void bgwListOfScheduleReleasedChecks_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result is not DataTable dataTable)
                {
                    pbLoadRecords.Value = 100;
                    return;
                }

                if (dataTable.Rows.Count < 1)
                    pbLoadRecords.Value = 100;


                HelperLoadRecords.RCIReleasedAndUnreleasedDatagridView(releasedAndUnreleasedDT, dgReleasedAndUnreleaseCheques);
                lblRecordCount.Text = dgReleasedAndUnreleaseCheques.Rows.Count.ToString();

                //Helper.EnableDisableToolStripButtons(dgReleasedAndUnreleaseCheques, btnAdd, null);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}