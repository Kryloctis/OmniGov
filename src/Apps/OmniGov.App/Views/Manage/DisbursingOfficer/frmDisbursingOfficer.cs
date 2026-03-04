using OmniGov.App.Helpers;
using OmniGov.Treasury.Data.Factories;
using OmniGov.Treasury.Domain.Entities;
using System.Data;

namespace OmniGov.App.Views.Manage.DisbursingOfficer
{
    public partial class frmDisbursingOfficer : Form
    {
        public frmDisbursingOfficer()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgDisbursingOfficer, true);
        }

        private DataTable DataTableDisbursingOfficer(string searchText)
        {
            var dataTable = new DataTable();

            var dataColumns = new DataColumn[]
           {
                new DataColumn(Name = "id", typeof(int)),
                new DataColumn(Name = "full_name", typeof(string)),
                new DataColumn(Name = "job_title", typeof(string)),
                new DataColumn(Name = "created_at", typeof(string)),
                new DataColumn(Name = "updated_at", typeof(string)),
                new DataColumn(Name = "users_id", typeof(string))
           };

            dataTable.Columns.AddRange(dataColumns);
            DataTable dtDisbursingOfficers;

            if (searchText.Length < 2)
                dtDisbursingOfficers = TreasuryFactory.DisbursingOfficerRepository().GetRecords();
            else
                dtDisbursingOfficers = TreasuryFactory.DisbursingOfficerRepository().GetRecordsBySearch(searchText);

            foreach (DataRow row in dtDisbursingOfficers.Rows)
            {
                int rowId = Convert.ToInt32(row["id"]);
                string rowPrefix = row["prefix"].ToString();
                string rowFirstName = row["first_name"].ToString();
                string rowMiddleInitial = row["mid_initial"].ToString();
                string rowLastName = row["last_name"].ToString();
                string rowSuffix = row["suffix"].ToString();
                string rowJobTitle = row["job_title"].ToString();
                string rowCreatedAt = row["created_at"].ToString();
                string rowUpdatedAt = row["updated_at"].ToString();
                string rowUsersId = row["users_id"].ToString();

                var disbursingOfficerFullName = Helper.GenerateFullName(rowPrefix, rowFirstName, rowMiddleInitial, rowLastName, rowSuffix);

                var dtRow = dataTable.NewRow();
                dtRow["id"] = rowId;
                dtRow["full_name"] = disbursingOfficerFullName;
                dtRow["job_title"] = rowJobTitle;
                dtRow["created_at"] = rowCreatedAt;
                dtRow["updated_at"] = rowUpdatedAt;
                dtRow["users_id"] = rowUsersId;

                dataTable.Rows.Add(dtRow);
            }

            return dataTable;
        }

        internal void LoadRecords()
        {
            string searchText = txtBoxSearch.Text.Trim();
            HelperLoadRecords.DisbursingOfficerDatagridView(DataTableDisbursingOfficer(searchText), dgDisbursingOfficer);
            lblRecordCount.Text = dgDisbursingOfficer.Rows.Count.ToString();
            dgDisbursingOfficer.CurrentCell = dgDisbursingOfficer.FirstDisplayedCell;
        }

        private void frmDisbursingOfficer_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmDisbursingOfficerAdd(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgDisbursingOfficer.Rows.Count > 0)
            {
                int disbursingOfficerId = int.Parse(dgDisbursingOfficer.SelectedCells[0].Value.ToString());
                _ = new frmDisbursingOfficerEdit(this, disbursingOfficerId).ShowDialog();
            }
        }

        private bool DeleteData()
        {
            int selectedRowsCount = dgDisbursingOfficer.SelectedRows.Count;
            if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
            {
                var modelList = new List<DisbursingOfficerModel>();
                foreach (DataGridViewRow row in dgDisbursingOfficer.SelectedRows)
                {
                    int disbursingOfficerId = Convert.ToInt16(row.Cells[0].Value.ToString());
                    modelList.Add(new DisbursingOfficerModel() { Id = disbursingOfficerId });
                }

                return TreasuryFactory.DisbursingOfficerRepository().Delete(modelList);
            }
            return false;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int selectedRows = dgDisbursingOfficer.SelectedRows.Count;

            if (DeleteData())
            {
                Helper.MessageBoxSuccess($"{selectedRows} record/s has been deleted");
                LoadRecords();
            }
        }

        private void dgDisbursingOfficer_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 3, 4 };
            Helper.ShowRecordTimestamp(dgDisbursingOfficer, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgDisbursingOfficer, btnEdit, btnDelete);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRecords();
        }
    }
}