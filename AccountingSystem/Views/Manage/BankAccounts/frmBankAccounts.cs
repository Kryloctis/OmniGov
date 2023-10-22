using ACC.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.BankAccounts
{
    public partial class frmBankAccounts : Form
    {
        public frmBankAccounts()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgBankAccounts, true, true);
        }

        private void frmBankAccounts_Load(object sender, EventArgs e)
        {
            try
            {
                LoadBankAccounts();
                Helper.EnableDisableToolStripButtons(dgBankAccounts, btnEdit, btnDelete);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgBankAccounts_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgBankAccounts, btnEdit, btnDelete);
        }

        private bool DeleteData()
        {
            int selectedRowsCount = dgBankAccounts.SelectedRows.Count;

            if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
            {
                var bankAccountsModelList = new List<BankAccountsModel>();
                foreach (DataGridViewRow row in dgBankAccounts.SelectedRows)
                {
                    int bankAccountID = Convert.ToInt16(row.Cells["id"].Value.ToString());
                    bankAccountsModelList.Add(new BankAccountsModel() { ID = bankAccountID });
                }

                var bankAccountsRepository = AccFactory.BankAccountsRepository();
                return bankAccountsRepository.Delete(bankAccountsModelList);
            }
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteData())
                    LoadBankAccounts();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                    Helper.MessageBoxError("Can't delete bank account. The record/s has been used as referenced to another record.");
            }
            catch (Exception ex)
            { Helper.MessageBoxError(ex.Message); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmAddBankAccounts(this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dgBankAccounts.CurrentRow.Index;
                int bankAccountId = Convert.ToInt32(dgBankAccounts.Rows[index].Cells["id"].Value);
                _ = new frmEditBankAccounts(this, bankAccountId).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private DataColumn[] BankAccountsDataColumns()
        {
            var dataColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("banks_id", typeof(string)),
                new DataColumn("bank_name", typeof(string)),
                new DataColumn("bank_code", typeof(string)),
                new DataColumn("bank_branch", typeof(string)),
                new DataColumn("account_no", typeof(string)),
                new DataColumn("created_at", typeof(string)),
                new DataColumn("updated_at", typeof(string)),
            };

            return dataColumns;
        }

        private Dictionary<string, string> RecordParameters()
        {
            var dictParameters = new Dictionary<string, string>();
            string searchKey = txtSearch.Text.Trim();

            dictParameters.Add("search_key", searchKey);
            return dictParameters;
        }

        internal void LoadBankAccounts()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbLoadRecords.Value = 0;
                backgroundWorker1.RunWorkerAsync(RecordParameters());
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument is not Dictionary<string, string> dictParameters)
                return;

            DataTable dtBankAccountFromDb = AccFactory.BankAccountsRepository().GetViewRecordsBySearch(dictParameters["search_key"]);

            var dataTable = new DataTable();
            dataTable.Columns.AddRange(BankAccountsDataColumns());

            if (dtBankAccountFromDb.Rows.Count < 1)
            {
                backgroundWorker1.ReportProgress(100);
                e.Result = dataTable;
                return;
            }

            int totalProgressCount = dtBankAccountFromDb.Rows.Count;
            int progressCount = 0;

            foreach (DataRow row in dtBankAccountFromDb.Rows)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                var newRow = dataTable.NewRow();
                int id = Convert.ToInt32(row["id"]);
                int bankID = Convert.ToInt32(row["banks_id"]);
                string bankName = row["bank_name"].ToString();
                string bankCode = row["bank_code"].ToString();
                string bankBranch = row["bank_branch"].ToString();
                string bankAccount = row["account_no"].ToString();
                string createdAt = row["created_at"].ToString();
                string updatedAt = row["updated_at"].ToString();

                newRow["id"] = id;
                newRow["banks_id"] = bankID;
                newRow["bank_name"] = bankName;
                newRow["bank_code"] = bankCode;
                newRow["bank_branch"] = bankBranch;
                newRow["account_no"] = bankAccount;
                newRow["created_at"] = createdAt;
                newRow["updated_at"] = updatedAt;

                progressCount++;
                dataTable.Rows.Add(newRow);

                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
            }

            e.Result = dataTable;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;

            if (e.Result is not DataTable dataTable)
                return;

            HelperLoadRecords.DatagridViewBankAccounts(dataTable, dgBankAccounts);
            dgBankAccounts.CurrentCell = dgBankAccounts.FirstDisplayedCell;
            toolStripStatusLabelRecordCount.Text = dgBankAccounts.Rows.Count.ToString();
            Helper.EnableDisableToolStripButtons(dgBankAccounts, btnEdit, btnDelete);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadBankAccounts();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}