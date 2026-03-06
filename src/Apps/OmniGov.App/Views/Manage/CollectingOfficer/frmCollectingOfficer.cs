using OmniGov.App.Helpers;
using OmniGov.App.Views.Manage.JobOrders;
using OmniGov.Treasury.Data.Factories;
using OmniGov.Treasury.Domain.Entities;
using System.ComponentModel;
using System.Data;

namespace OmniGov.App.Views.Manage.CollectingOfficer
{
    public partial class frmCollectingOfficer : Form
    {
        public frmCollectingOfficer()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgCollectingOfficer, true);
        }

        internal void LoadCollectingOfficers()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbLoadRecords.Value = 0;
                string searchKey = txtSearch.Text.Trim();
                backgroundWorker1.RunWorkerAsync(searchKey);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument is not string searchKey)
                return;

            var dataTable = new DataTable();
            dataTable.Columns.AddRange(DataColumnsCollectingOfficers());
            DataTable dtCollectingOfficers = TreasuryFactory.CollectingOfficerRepository().GetRecordsBySearch(searchKey);

            int totalProgressCount = dtCollectingOfficers.Rows.Count;
            int progressCount = 0;

            foreach (DataRow row in dtCollectingOfficers.Rows)
            {
                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

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
            if (dataTable.Rows.Count < 1)
                pbLoadRecords.Value = 100;

            HelperLoadRecords.CollectingOfficerDatagridView(dataTable, dgCollectingOfficer);
            dgCollectingOfficer.CurrentCell = dgCollectingOfficer.FirstDisplayedCell;
            lblRecordCount.Text = dgCollectingOfficer.Rows.Count.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmCollectingOfficerAdd(this).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DeleteRecord())
                LoadCollectingOfficers();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int index = dgCollectingOfficer.CurrentRow.Index;
            int collectingOfficerId = Convert.ToInt32(dgCollectingOfficer.Rows[index].Cells["id"].Value);
            _ = new frmCollectingOfficerEdit(this, collectingOfficerId).ShowDialog();
        }

        private void btnJobOrder_Click(object sender, EventArgs e)
        {
            int index = dgCollectingOfficer.CurrentRow.Index;
            int collectingOfficerId = int.Parse(dgCollectingOfficer.Rows[index].Cells["id"].Value.ToString());
            _ = new frmJobOrder(collectingOfficerId).ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadCollectingOfficers();
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

        private bool DeleteRecord()
        {
            int selectedRowsCount = dgCollectingOfficer.SelectedRows.Count;

            if (selectedRowsCount > 0)
            {
                if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                {
                    var modelList = new List<CollectingOfficerModel>();
                    foreach (DataGridViewRow row in dgCollectingOfficer.SelectedRows)
                    {
                        int collectingOfficerID = Convert.ToInt16(row.Cells["id"].Value.ToString());
                        if (!TreasuryFactory.ReceiptsIssuedRepository().CollectingOfficerHasReceiptAssigned(collectingOfficerID))
                            modelList.Add(new CollectingOfficerModel() { Id = collectingOfficerID });
                    }
                    return TreasuryFactory.CollectingOfficerRepository().Delete(modelList);
                }
            }
            return false;
        }

        private void dgCollectingOfficer_SelectionChanged(object sender, EventArgs e)
        {
            int selectedRowCount = dgCollectingOfficer.SelectedRows.Count;
            if (dgCollectingOfficer.SelectedRows.Count < 1)
                return;

            int id = int.Parse(dgCollectingOfficer.CurrentRow.Cells["id"].Value.ToString());
            byte[] columnIndexTimestamp = { 4, 5 };

            lblJOCount.Text = TreasuryFactory.CollectingOfficerRepository().CollectingOfficerJOCount(id).ToString();

            Helper.ShowRecordTimestamp(dgCollectingOfficer, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgCollectingOfficer, btnEdit, btnDelete);

            btnDelete.Enabled = TreasuryFactory.ReceiptsIssuedRepository().CollectingOfficerHasReceiptAssigned(id) ? false : true;
            btnJobOrder.Enabled = selectedRowCount == 1;
        }

        private void frmCollectingOfficer_Load(object sender, EventArgs e)
        {
            OnLoad();
        }

        private void OnLoad()
        {
            LoadCollectingOfficers();
        }
    }
}