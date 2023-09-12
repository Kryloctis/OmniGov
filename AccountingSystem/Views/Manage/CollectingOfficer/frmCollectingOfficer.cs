using ACC.Domain.Models;
using AccountingSystem.Views.Manage.JobOrders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.CollectingOfficer
{
    public partial class frmCollectingOfficer : Form
    {
        public frmCollectingOfficer()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgCollectingOfficer, true);
        }

        private DataColumn[] DataColumnsCollectingOfficers()
        {
            return new DataColumn[]
            {
                new DataColumn(Name = "id", typeof(int)),
                new DataColumn(Name = "full_name", typeof(string)),
                new DataColumn(Name = "job_title", typeof(string)),
                new DataColumn(Name = "is_deleted", typeof(bool)),
                new DataColumn(Name = "created_at", typeof(string)),
                new DataColumn(Name = "updated_at", typeof(string))
            };
        }

        private DataTable DataTableCollectingOfficer()
        {
            string textSearch = txtSearch.Text.Trim();
            DataTable dataTable = new DataTable();
            dataTable.Columns.AddRange(DataColumnsCollectingOfficers());
            DataTable dtCollectingOfficers;

            if (string.IsNullOrWhiteSpace(textSearch) || textSearch.Length < 2)
                dtCollectingOfficers = AccFactory.CollectingOfficerRepository().GetRecords();
            else
                dtCollectingOfficers = AccFactory.CollectingOfficerRepository().GetRecordsBySearch(textSearch);

            int rowCount = 0;
            int recordCount = dtCollectingOfficers.Rows.Count;

            foreach (DataRow row in dtCollectingOfficers.Rows)
            {
                var newRow = dataTable.NewRow();
                int rowId = Convert.ToInt32(row["id"]);
                string rowPrefix = row["prefix"].ToString();
                string rowFirstName = row["first_name"].ToString();
                string rowMidInitial = row["mid_initial"].ToString();
                string rowLastName = row["last_name"].ToString();
                string rowSuffix = row["suffix"].ToString();
                string rowFullName = Helper.GenerateFullName(rowPrefix, rowFirstName, rowMidInitial, rowLastName, rowSuffix);
                string rowJobTitle = row["job_title"].ToString();
                bool rowIsDeleted = Convert.ToBoolean(row["is_deleted"]);
                string rowCreatedAt = row["created_at"].ToString();
                string rowUpdatedAt = row["updated_at"].ToString();

                newRow["id"] = rowId;
                newRow["full_name"] = rowFullName;
                newRow["job_title"] = rowJobTitle;
                newRow["is_deleted"] = rowIsDeleted;
                newRow["created_at"] = rowCreatedAt;
                newRow["updated_at"] = rowUpdatedAt;

                rowCount++;
                int progressBarPercentage = (rowCount * 100) / recordCount;
                backgroundWorker1.ReportProgress(progressBarPercentage);

                dataTable.Rows.Add(newRow);
            }

            return dataTable;
        }

        internal void LoadCollectingOfficers()
        {
            HelperLoadRecords.CollectingOfficerDatagridView(DataTableCollectingOfficer(), dgCollectingOfficer);
            lblRecordCount.Text = dgCollectingOfficer.Rows.Count.ToString();
        }

        private void frmCollectingOfficer_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmCollectingOfficerAdd(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgCollectingOfficer.Rows.Count > 0)
            {
                int collectingOfficerId = Convert.ToInt32(dgCollectingOfficer.SelectedCells[0].Value);
                _ = new frmCollectingOfficerEdit(this, collectingOfficerId).ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgCollectingOfficer.SelectedRows.Count;
            try
            {
                if (selectedRowsCount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                    {
                        var issuedReceiptRepo = AccFactory.ReceiptsIssuedRepository();

                        var repository = AccFactory.CollectingOfficerRepository();
                        var modelList = new List<CollectingOfficerModel>();
                        foreach (DataGridViewRow row in dgCollectingOfficer.SelectedRows)
                        {
                            int collectingOfficerID = Convert.ToInt16(row.Cells["id"].Value.ToString());
                            if (!issuedReceiptRepo.CollectingOfficerHasReceiptAssigned(collectingOfficerID))
                                modelList.Add(new CollectingOfficerModel() { Id = collectingOfficerID });
                        }
                        _ = repository.Delete(modelList);
                        LoadRecords();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void dgCollectingOfficer_SelectionChanged(object sender, EventArgs e)
        {
            int selectedRowCount = dgCollectingOfficer.SelectedRows.Count;
            if (dgCollectingOfficer.SelectedRows.Count < 1)
                return;

            int id = int.Parse(dgCollectingOfficer.CurrentRow.Cells["id"].Value.ToString());
            byte[] columnIndexTimestamp = { 4, 5 };

            lblJOCount.Text = AccFactory.CollectingOfficerRepository().CollectingOfficerJOCount(id).ToString();

            Helper.ShowRecordTimestamp(dgCollectingOfficer, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgCollectingOfficer, btnEdit, btnDelete);

            var receiptIssuedRepo = AccFactory.ReceiptsIssuedRepository();

            btnDelete.Enabled = receiptIssuedRepo.CollectingOfficerHasReceiptAssigned(id) ? false : true;
            btnJobOrder.Enabled = selectedRowCount == 1;
        }


        private void btnJobOrder_Click(object sender, EventArgs e)
        {
            int collectingOfficerId = int.Parse(dgCollectingOfficer.SelectedCells[0].Value.ToString());
            _ = new frmJobOrder(collectingOfficerId).ShowDialog();
        }

        internal void LoadRecords()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbLoadRecords.Value = 0;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                LoadCollectingOfficers();
            });
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRecords();
        }
    }
}