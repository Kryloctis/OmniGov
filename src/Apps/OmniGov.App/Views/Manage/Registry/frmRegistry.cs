using OmniGov.App.Helpers;
using OmniGov.Core.Entities;
using OmniGov.Core.Factories;
using System.ComponentModel;
using System.Data;

namespace OmniGov.App.Views.Manage.Registry
{
    public partial class frmRegistry : Form
    {
        public frmRegistry()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);
        }

        internal void LoadRecords()
        {
            if (!backgroundWorker1.IsBusy)
            {
                string searchKey = txtSearch.Text.Trim();
                int limitRow = Convert.ToInt32(cmbxRowFilter.SelectedValue);
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync((limitRow, searchKey));
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var parameters = ((int limitCount, string searchKey))e.Argument;

            var dataColumns = new DataColumn[]
            {
                    new DataColumn("id", typeof(int)),
                    new DataColumn("name", typeof(string)),
                    new DataColumn("sex", typeof(string)),
                    new DataColumn("nationality", typeof(string)),
                    new DataColumn("birth_date", typeof(DateTime)),
                    new DataColumn("birth_place", typeof(string)),
                    new DataColumn("contact_info", typeof(string)),
                    new DataColumn("created_at", typeof(string)),
                    new DataColumn("updated_at", typeof(string)),
            };

            var dataTable = new DataTable();
            dataTable.Columns.AddRange(dataColumns);
            var dtRegistry = Factory.RegistryRepository().GetRecordsBySearh_Limit(parameters.searchKey, parameters.limitCount);

            int progressCount = 0;
            int totalProgressCount = dtRegistry.Rows.Count;

            foreach (DataRow row in dtRegistry.Rows)
            {
                var newRow = dataTable.NewRow();
                string middleName = row["middle_name"].ToString();
                string fullName = $"{row["first_name"]} {(!string.IsNullOrEmpty(middleName) ? $"{middleName.Substring(0, 1)}." : "")} {row["last_name"]}";

                newRow["id"] = row["id"];
                newRow["name"] = fullName;
                newRow["sex"] = row["sex"];
                newRow["nationality"] = row["nationality"];
                newRow["birth_place"] = $"{row["municipality"]}, {row["province"]}, {row["country"]}";
                newRow["birth_date"] = row["birth_date"];
                newRow["contact_info"] = row["contact_info"];
                newRow["created_at"] = row["created_at"];
                newRow["updated_at"] = row["updated_at"];

                dataTable.Rows.Add(newRow);
                progressCount++;
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
            }

            e.Result = dataTable;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is not DataTable dataTable)
                return;

            if (dataTable.Rows.Count < 1)
                progressBar1.Value = 100;

            HelperLoadRecords.DatagridViewRegistry(dataTable, dataGridView1);
            dataGridView1.CurrentCell = dataGridView1.FirstDisplayedCell;
            lblRecordCount.Text = dataGridView1.Rows.Count.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddRegistry(this).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedRows = dataGridView1.SelectedRows;
            if (DeleteRegistry(selectedRows))
            {
                Helper.MessageBoxSuccess($"{selectedRows.Count} Record/s has been deleted");
                LoadRecords();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            int registryId = Convert.ToInt32(dataGridView1.Rows[index].Cells["id"].Value);

            _ = new frmEditRegistry(registryId, this).ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void cmbxRowFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var stampIndex = new byte[] { 7, 8 };
            Helper.ShowRecordTimestamp(dataGridView1, stampIndex, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
        }

        private bool DeleteRegistry(DataGridViewSelectedRowCollection selectedRows)
        {
            if (Helper.MessageBoxConfirmDelete(selectedRows.Count))
            {
                var registryModels = new List<RegistryModel>();

                foreach (DataGridViewRow row in selectedRows)
                    registryModels.Add(new RegistryModel() { Id = Convert.ToInt32(row.Cells["id"].Value) });

                return Factory.RegistryRepository().Delete(registryModels);
            }
            return false;
        }

        private void frmRegistry_Load(object sender, EventArgs e)
        {
            HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowFilter);
            LoadRecords();
            Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
        }
    }
}