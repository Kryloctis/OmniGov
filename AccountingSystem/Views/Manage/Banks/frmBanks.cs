using ACC.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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


        private DataColumn[] BanksDataColumns()
        {
            var dataColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("bank_code", typeof(string)),
                new DataColumn("bank_name", typeof(string)),
                new DataColumn("bank_branch", typeof(string)),
                new DataColumn("created_at", typeof(DateTime)),
                new DataColumn("updated_at", typeof(DateTime)),
            };

            return dataColumns;
        }

        internal void LoadBanks()
        {
            DataTable dtBanks = new();
            DataTable dtBankFromDB;
            dtBanks.Columns.AddRange(BanksDataColumns());

            var searchKey = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(searchKey))
                dtBankFromDB = AccFactory.BanksRepository().GetRecordsBySearch(searchKey);
            else
                dtBankFromDB = AccFactory.BanksRepository().GetRecords();


            int recordCount = dtBankFromDB.Rows.Count;
            int rowCount = 0;

            foreach (DataRow row in dtBankFromDB.Rows)
            {
                var newRow = dtBanks.NewRow();

                int id = Convert.ToInt32(row["id"]);
                string bankCode = row["bank_code"].ToString();
                string bankName = row["bank_name"].ToString();
                string bankBranch = row["bank_branch"].ToString();

                newRow["id"] = id;
                newRow["bank_code"] = bankCode;
                newRow["bank_name"] = bankName;
                newRow["bank_branch"] = bankBranch;

                rowCount++;
                int progressBarPercentage = (rowCount * 100) / recordCount;
                backgroundWorker1.ReportProgress(progressBarPercentage);
                dtBanks.Rows.Add(newRow);
            }

            HelperLoadRecords.BanksDatagridView(dtBanks, dgBanks);
            lblRecordCount.Text = AccFactory.BanksRepository().CountRecords().ToString();
        }

        internal void LoadRecords()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbLoadRecords.Value = 0;
                backgroundWorker1.RunWorkerAsync();
            }
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
            _ = new frmAddBanks(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int bankId = Convert.ToInt32(dgBanks.SelectedRows[0].Cells["id"].Value);
            _ = new frmEditBank(this, bankId).ShowDialog();
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
            byte[] columnIndexTimestamp = { 4, 5 };
            Helper.ShowRecordTimestamp(dgBanks, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgBanks, btnEdit, btnDelete);
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                LoadBanks();
            });
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

        }
    }
}