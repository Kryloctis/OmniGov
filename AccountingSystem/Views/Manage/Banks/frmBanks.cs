using ACC.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Banks
{
    public partial class frmBanks : Form
    {
        public frmBanks()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgBanks, true);
        }

        private void frmBanks_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmAddBanks(this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var index = dgBanks.CurrentRow.Index;
                int bankId = Convert.ToInt32(dgBanks.Rows[index].Cells["id"].Value);
                _ = new frmEditBank(this, bankId).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool DeleteRecords()
        {
            int selectedRowsCount = dgBanks.SelectedRows.Count;

            if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
            {
                var banksModelList = new List<BanksModel>();
                foreach (DataGridViewRow row in dgBanks.SelectedRows)
                {
                    int bankId = Convert.ToInt16(row.Cells[0].Value.ToString());
                    banksModelList.Add(new BanksModel() { Id = bankId });
                }

                return AccFactory.BanksRepository().Delete(banksModelList);
            }

            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteRecords())
                {
                    Helper.MessageBoxSuccess("Bank successfully deleted.");
                    LoadRecords();
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                    Helper.MessageBoxError("Can't delete bank. The record/s has been used as referenced to another record.");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgBanks_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                byte[] columnIndexTimestamp = { 4, 5 };
                Helper.ShowRecordTimestamp(dgBanks, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
                Helper.EnableDisableToolStripButtons(dgBanks, btnEdit, btnDelete);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private DataColumn[] BanksDataColumns()
        {
            var dataColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("bank_code", typeof(string)),
                new DataColumn("bank_name", typeof(string)),
                new DataColumn("bank_branch", typeof(string)),
                new DataColumn("created_at", typeof(string)),
                new DataColumn("updated_at", typeof(string)),
            };

            return dataColumns;
        }

        private Dictionary<string, string> LoadBanksParameters()
        {
            var dictionary = new Dictionary<string, string>();

            var searchKey = txtSearch.Text.Trim();
            dictionary.Add("search_key", searchKey);

            return dictionary;
        }

        internal void LoadRecords()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbLoadRecords.Value = 0;
                backgroundWorker1.RunWorkerAsync(LoadBanksParameters());
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument is not Dictionary<string, string> dictParameters)
                return;

            var dataTable = new DataTable();
            DataTable dtBankFromDB = AccFactory.BanksRepository().GetRecordsBySearch(dictParameters["search_key"]);
            dataTable.Columns.AddRange(BanksDataColumns());

            if (dtBankFromDB.Rows.Count < 1)
            {
                backgroundWorker1.ReportProgress(100);
                e.Result = dataTable;
                return;
            }

            int totalProgressCount = dtBankFromDB.Rows.Count;
            int progressCount = 0;

            foreach (DataRow row in dtBankFromDB.Rows)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                var newRow = dataTable.NewRow();
                int id = Convert.ToInt32(row["id"]);
                string bankCode = row["bank_code"].ToString();
                string bankName = row["bank_name"].ToString();
                string bankBranch = row["bank_branch"].ToString();
                string createdAt = row["created_at"].ToString();
                string updatedAt = row["updated_at"].ToString();

                newRow["id"] = id;
                newRow["bank_code"] = bankCode;
                newRow["bank_name"] = bankName;
                newRow["bank_branch"] = bankBranch;
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

            HelperLoadRecords.BanksDatagridView(dataTable, dgBanks);
            dgBanks.CurrentCell = dgBanks.FirstDisplayedCell;
            lblRecordCount.Text = dgBanks.Rows.Count.ToString();
        }

        private void frmBanks_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                backgroundWorker1.CancelAsync();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}