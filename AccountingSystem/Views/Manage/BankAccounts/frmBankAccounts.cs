using ACC.Data;
using ACC.Domain.Models;
using LFS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
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
                HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowLimit);
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgBankAccounts_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var columnIndex = new byte[] { 6, 7 };
                Helper.ShowRecordTimestamp(dgBankAccounts, columnIndex, lblCreatedAt, lblUpdatedAt);

                Helper.EnableDisableToolStripButtons(dgBankAccounts, btnEdit, btnDelete);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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
                    bankAccountsModelList.Add(new BankAccountsModel() { Id = bankAccountID });
                }

                return AccFactory.BankAccountsRepository().Delete(bankAccountsModelList);
            }
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteData())
                {
                    Helper.MessageBoxError($"{dgBankAccounts.SelectedRows.Count} record/s has been deleted.");
                    LoadRecords();
                }
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
                int rowIndex = dgBankAccounts.CurrentRow.Index;
                int bankAccountId = Convert.ToInt32(dgBankAccounts.Rows[rowIndex].Cells["id"].Value);
                _ = new frmEditBankAccounts(this, bankAccountId).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadRecords()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbLoadRecords.Value = 0;
                int rowLimit = Convert.ToInt32(cmbxRowLimit.SelectedValue);
                string searchKey = txtSearch.Text.Trim();
                backgroundWorker1.RunWorkerAsync((rowLimit, searchKey));
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var parameters = ((int rowLimit, string searchKey))e.Argument;

            var dtBankAccount = AccFactory.BankAccountsRepository().GetViewRecordsBySearch(parameters.rowLimit, parameters.searchKey.Trim());
            int totalProgressCount = dtBankAccount.Rows.Count;
            int progressCount = 0;

            dtBankAccount.Rows.Cast<DataRow>().ToList().ForEach(x =>
            {
                progressCount++;
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
            });

            e.Result = dtBankAccount;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is not DataTable dataTable)
                return;

            if (dataTable.Rows.Count < 1)
                pbLoadRecords.Value = 100;

            HelperLoadRecords.DatagridViewBankAccounts(dataTable, dgBankAccounts);
            dgBankAccounts.CurrentCell = dgBankAccounts.FirstDisplayedCell;
            toolStripStatusLabelRecordCount.Text = dgBankAccounts.Rows.Count.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxRowLimit_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}