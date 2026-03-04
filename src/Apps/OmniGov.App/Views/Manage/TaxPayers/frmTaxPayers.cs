using OmniGov.App.Helpers;
using OmniGov.Treasury.Data.Factories;
using OmniGov.Treasury.Domain.Entities;
using System.ComponentModel;
using System.Data;

namespace OmniGov.App.Views.Manage.TaxPayers
{
    public partial class frmTaxpayers : Form
    {
        public frmTaxpayers()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgTaxpayers, true);
        }

        private void OnLoad()
        {
            HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowFilter);
            LoadTaxpayers();
            Helper.EnableDisableToolStripButtons(dgTaxpayers, btnEdit, btnDelete);
        }

        private bool Delete(DataGridViewSelectedRowCollection dataGridViewSelectedRowCollection)
        {
            var taxpayerModelList = new List<TaxpayersModel>();
            var selectedRowCount = dataGridViewSelectedRowCollection.Count;

            if (Helper.MessageBoxConfirmDelete(selectedRowCount))
            {
                foreach (DataGridViewRow row in dgTaxpayers.SelectedRows)
                {
                    int taxpayerId = Convert.ToInt32(row.Cells["taxpayers_id"].Value);
                    var model = new TaxpayersModel() { Id = taxpayerId };
                    taxpayerModelList.Add(model);
                }
            }

            return TreasuryFactory.TaxpayersRepository().Delete(taxpayerModelList);
        }

        private void ShowEditForm()
        {
            int index = dgTaxpayers.CurrentCell.RowIndex;
            var taxpayerId = Convert.ToInt32(dgTaxpayers.Rows[index].Cells["taxpayers_id"].Value);
            _ = new frmEditTaxpayers(taxpayerId, this).ShowDialog();
        }

        internal void LoadTaxpayers()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbLoadRecords.Value = 0;
                backgroundWorker1.RunWorkerAsync(LoadTaxpayerParameters());
            }
        }

        private (string searchKey, bool showInactive, int rowFilter) LoadTaxpayerParameters()
        {
            string searchKey = txtSearch.Text.Trim();
            bool showInactive = chckBxInactiveTaxpayers.Checked;
            int rowFilter = Convert.ToInt32(cmbxRowFilter.SelectedValue);

            return (searchKey, showInactive, rowFilter);
        }

        private DataColumn[] TaxpayersColumns()
        {
            return new DataColumn[]
            {
                new DataColumn("taxpayers_id", typeof (int)),
                new DataColumn("taxpayers_name", typeof(string)),
                new DataColumn("taxpayer_type", typeof(string)),
                new DataColumn("taxpayers_tin", typeof(string)),
                new DataColumn("taxpayers_address", typeof(string)),
                new DataColumn("taxpayers_contact_info", typeof(string)),
                new DataColumn("representative_name", typeof(string)),
                new DataColumn("is_active", typeof(bool)),
                new DataColumn("created_at", typeof(string)),
                new DataColumn("updated_at", typeof(string))
            };
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((string searchKey, bool showInactive, int rowFilter))e.Argument;

                var dataTable = new DataTable();
                var dtTaxpayers = TreasuryFactory.TaxpayersRepository().GetViewRecordsByParameters(parameters.searchKey, parameters.showInactive, parameters.rowFilter);
                dataTable.Columns.AddRange(TaxpayersColumns());

                int progressCount = 0;
                int totalProgressCount = dtTaxpayers.Rows.Count;

                if (dtTaxpayers.Rows.Count < 1) { backgroundWorker1.ReportProgress(100); e.Result = dataTable; return; }

                foreach (DataRow row in dtTaxpayers.Rows)
                {
                    var newRow = dataTable.NewRow();
                    int taxpayerId = Convert.ToInt32(row["taxpayers_id"]);
                    string taxpayerTin = $"{row["taxpayers_tin"]}";
                    string taxpayerName = $"{row["taxpayers_name"]}";
                    string taxpayerTypeCode = $"{row["taxpayer_type"]}";
                    string representativeName = string.IsNullOrWhiteSpace($"{row["representative_name"]}") ? "None" : $"{row["representative_name"]}";
                    string address = $"{row["taxpayers_address"]}";
                    string municipality = $"{row["taxpayers_municipality"]}";
                    string province = $"{row["taxpayers_province"]}";
                    string taxpayerAddress = $"{address}, {municipality}, {province}";
                    string taxpayerContactInfo = $"{row["taxpayers_contact_info"]}";
                    bool isActive = Convert.ToBoolean(Convert.ToByte(row["is_active"]));
                    string createdAt = $"{row["created_at"]}";
                    string updatedAt = $"{row["updated_at"]}";

                    newRow["taxpayers_id"] = taxpayerId;
                    newRow["taxpayer_type"] = taxpayerTypeCode;
                    newRow["taxpayers_tin"] = taxpayerTin;
                    newRow["taxpayers_name"] = taxpayerName;
                    newRow["taxpayers_address"] = taxpayerAddress;
                    newRow["taxpayers_contact_info"] = taxpayerContactInfo;
                    newRow["representative_name"] = representativeName;
                    newRow["is_active"] = isActive;
                    newRow["created_at"] = createdAt;
                    newRow["updated_at"] = updatedAt;

                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                    dataTable.Rows.Add(newRow);
                }

                e.Result = dataTable;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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

            HelperLoadRecords.TaxpayerDatagridView(dgTaxpayers, dataTable);

            dgTaxpayers.CurrentCell = dgTaxpayers.FirstDisplayedCell;
            toolStripStatusLabelRecordCount.Text = dgTaxpayers.Rows.Count.ToString();
        }

        private void dgTaxpayers_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var indexes = new byte[] { 8, 9 };
                Helper.EnableDisableToolStripButtons(dgTaxpayers, btnEdit, btnDelete);
                Helper.ShowRecordTimestamp(dgTaxpayers, indexes, toolStripStatusLabelCreatedAt, toolStripStatusLabelUpdatedAt);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void chckBxInactiveTaxpayers_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LoadTaxpayers();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmTaxPayers_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmAddTaxpayers(this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ShowEditForm();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = dgTaxpayers.SelectedRows;

                if (Delete(selectedRows))
                {
                    Helper.MessageBoxError($"{selectedRows.Count} record/s has been deleted.");
                    LoadTaxpayers();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadTaxpayers();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxRowFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadTaxpayers();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
