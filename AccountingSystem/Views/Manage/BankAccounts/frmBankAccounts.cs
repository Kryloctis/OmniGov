using ACC.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
                new DataColumn("created_at", typeof(DateTime)),
                new DataColumn("updated_at", typeof(DateTime)),
            };

            return dataColumns;
        }

        internal void LoadRecords()
        {
            DataTable dtBankAccount = new();
            DataTable dtBankAccountFromDB;
            dtBankAccount.Columns.AddRange(BankAccountsDataColumns());

            var searchText = txtSearch.Text.Trim();

            if (searchText.Length > 2)
                dtBankAccountFromDB = AccFactory.BankAccountsRepository().GetViewRecordsBySearch(searchText);
            else
                dtBankAccountFromDB = AccFactory.BankAccountsRepository().GetViewRecords();


            int recordCount = dtBankAccountFromDB.Rows.Count;
            int rowCount = 0;

            foreach (DataRow row in dtBankAccountFromDB.Rows)
            {
                var newRow = dtBankAccount.NewRow();

                int id = Convert.ToInt32(row["id"]);
                int bankID = Convert.ToInt32(row["banks_id"]);
                string bankName = row["bank_name"].ToString();
                string bankCode = row["bank_code"].ToString();
                string bankBranch = row["bank_branch"].ToString();
                string bankAccount = row["account_no"].ToString();

                newRow["id"] = id;
                newRow["banks_id"] = bankID;
                newRow["bank_name"] = bankName;
                newRow["bank_code"] = bankCode;
                newRow["bank_branch"] = bankBranch;
                newRow["account_no"] = bankAccount;

                rowCount++;
                int progressBarPercentage = (rowCount * 100) / recordCount;
                backgroundWorker1.ReportProgress(progressBarPercentage);
                dtBankAccount.Rows.Add(newRow);
            }

            HelperLoadRecords.DatagridViewBankAccounts(dtBankAccount, dgBankAccounts);

            toolStripStatusLabelRecordCount.Text = dgBankAccounts.Rows.Count.ToString();
        }

        internal void LoadBankAccounts()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbLoadRecords.Value = 0;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void dgBankAccounts_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgBankAccounts, btnEdit, btnDelete);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadBankAccounts();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void DeleteData()
        {
            int selectedRowsCount = dgBankAccounts.SelectedRows.Count;

            if (selectedRowsCount > 0)
            {
                if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                {
                    var bankAccountsModelList = new List<BankAccountsModel>();
                    foreach (DataGridViewRow row in dgBankAccounts.SelectedRows)
                    {
                        int bankAccountID = Convert.ToInt16(row.Cells["id"].Value.ToString());
                        bankAccountsModelList.Add(new BankAccountsModel() { ID = bankAccountID });
                    }

                    var bankAccountsRepository = AccFactory.BankAccountsRepository();
                    _ = bankAccountsRepository.Delete(bankAccountsModelList);
                    LoadBankAccounts();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteData();
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
            _ = new frmAddBankAccounts(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int bankAccountId = Convert.ToInt32(dgBankAccounts.SelectedRows[0].Cells["id"].Value);
            _ = new frmEditBankAccounts(this, bankAccountId).ShowDialog();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                LoadRecords();
            });
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }
    }
}