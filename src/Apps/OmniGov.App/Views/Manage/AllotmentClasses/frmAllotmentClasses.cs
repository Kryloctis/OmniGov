using OmniGov.App.Helpers;
using OmniGov.Core.Entities;
using OmniGov.Core.Factories;
using System.ComponentModel;
using System.Data;

namespace OmniGov.App.Views.Manage.AllotmentClasses
{
    public partial class frmAllotmentClasses : Form
    {
        public frmAllotmentClasses()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgAllotmentClasses, true);
        }

        internal void LoadRecords()
        {
            if (!backgroundWorker1.IsBusy)
            {
                string searchText = txtSearch.Text.Trim();
                int rowLimit = Convert.ToInt32(cmbxRowLimit.SelectedValue);
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync((rowLimit, searchText));
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var parameters = ((int rowLimit, string searchKey))e.Argument;

            var dtAllotmentClasses = Factory.AllotmentClassesRepository().GetRecordsBySearch(parameters.rowLimit, parameters.searchKey.Trim());
            int totalProgressCount = dtAllotmentClasses.Rows.Count;
            int progressCount = 0;

            dtAllotmentClasses.Rows.Cast<DataRow>().ToList().ForEach(row => { progressCount++; Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount); });

            e.Result = dtAllotmentClasses;
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
            {
                progressBar1.Value = 100;
            }

            HelperLoadRecords.AllotmentClassesDatagridView(dataTable, dgAllotmentClasses);
            dgAllotmentClasses.CurrentCell = dgAllotmentClasses.FirstDisplayedCell;
            lblRecordCount.Text = dgAllotmentClasses.Rows.Count.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddAllotmentClasses(this).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DeleteData())
            {
                Helper.MessageBoxError($"{dgAllotmentClasses.Rows.Count} record/s has been deleted.");
                LoadRecords();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = dgAllotmentClasses.CurrentRow.Index;
            int allotmentId = Convert.ToInt32(dgAllotmentClasses.Rows[rowIndex].Cells["id"].Value);

            _ = new frmEditAllotmentClasses(this, allotmentId).ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private bool DeleteData()
        {
            int selectedRowsCount = dgAllotmentClasses.SelectedRows.Count;

            if (selectedRowsCount < 1)
                return false;

            if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
            {
                var allotmentClassesModelList = new List<AllotmentClassesModel>();
                foreach (DataGridViewRow row in dgAllotmentClasses.SelectedRows)
                {
                    int allotmentId = Convert.ToInt16(row.Cells["id"].Value.ToString());
                    allotmentClassesModelList.Add(new AllotmentClassesModel() { Id = allotmentId });
                }

                return Factory.AllotmentClassesRepository().Delete(allotmentClassesModelList);
            }
            return false;
        }

        private void dgAllotmentClasses_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 3, 4 };
            Helper.ShowRecordTimestamp(dgAllotmentClasses, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgAllotmentClasses, btnEdit, btnDelete);
        }

        private void frmAllotmentClasses_Load(object sender, EventArgs e)
        {
            HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowLimit);
            LoadRecords();
        }
    }
}