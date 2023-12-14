using ACC.Data;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using AccountingSystem.Views.Manage.TaxPayers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RealProperties
{
    public partial class frmRealProperties : Form
    {
        public frmRealProperties()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgRealProperties);
        }

        #region Private Methods

        private void OnLoad()
        {
            HelperLoadRecords.RowFilterCombobox(cmbxRowFilter);
            LoadProperties();
        }

        private bool DeleteRpt()
        {
            if (Helper.MessageBoxConfirmDelete(dgRealProperties.SelectedRows.Count))
            {
                var realPropertiesRepository = AccFactory.RealPropertiesRepository();
                var realPropertiesModels = new List<RealPropertiesModel>();

                foreach (DataGridViewRow row in dgRealProperties.SelectedRows)
                {
                    int realPropertiesID = int.Parse(row.Cells[0].Value.ToString());

                    var receiptIsUsed = AccFactory.ReceiptsIssuedRepository().ReceiptHasIssuance(realPropertiesID);

                    if (!receiptIsUsed)
                        realPropertiesModels.Add(new RealPropertiesModel() { Id = realPropertiesID });
                }
                return realPropertiesRepository.Delete(realPropertiesModels);
            }
            return false;
        }

        internal void LoadProperties()
        {
            if (!backgroundWorker1.IsBusy)
            {
                string searchKey = txtSearch.Text.Trim();
                int rowFilter = Convert.ToInt32(cmbxRowFilter.SelectedValue);
                bool showCancelled = chckShowCancelled.Checked;

                pbLoadRecords.Value = 0;
                backgroundWorker1.RunWorkerAsync((searchKey, showCancelled, rowFilter));
            }
        }

        private DataColumn[] RealPropertiesColumns()
        {
            var dataColumns = new DataColumn[] {
                new DataColumn("id", typeof(int)),
                new DataColumn("complete_arp_no", typeof(string)),
                new DataColumn("property_pin", typeof(string)),
                new DataColumn("property_kind", typeof(string)),
                new DataColumn("property_location", typeof(string)),
                new DataColumn("taxpayers_name", typeof(string)),
                new DataColumn("representative_name", typeof(string)),
                new DataColumn("classification_code", typeof(string)),
                new DataColumn("actual_use_code", typeof(string)),
                new DataColumn("effectivity_quarter_and_year", typeof(string)),
                new DataColumn("other_improvements", typeof(decimal)),
                new DataColumn("assessed_value", typeof(decimal)),
                new DataColumn("is_taxable", typeof(bool)),
                new DataColumn("is_cancelled", typeof(bool)),
                new DataColumn("created_at", typeof(string)),
                new DataColumn("updated_at", typeof(string)),
            };

            return dataColumns;
        }

        #endregion Private Methods

        #region Event Methods

        private void frmRealProperties_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((string searchKey, bool showCancelled, int rowFilter))e.Argument;

                var dataTable = new DataTable();
                dataTable.Columns.AddRange(RealPropertiesColumns());

                var dtRealPropertiesFromDB = AccFactory.RealPropertiesRepository().GetRecordsBySearch(parameters.searchKey, parameters.rowFilter, parameters.showCancelled);
                int totalProgressCount = dtRealPropertiesFromDB.Rows.Count;
                int progressCount = 0;

                foreach (DataRow row in dtRealPropertiesFromDB.Rows)
                {
                    var newRow = dataTable.NewRow();
                    string location = $"{row["street"]} {row["barangays_name"]} {row["municipalities_name"]} {row["provinces_name"]}";
                    string effectivityQuarterAndYear = $"{Helper.AddOrdinalSuffix((int)row["effectivity_quarter"])} Quarter - {row["effectivity_year"]}";

                    newRow["id"] = row["id"];
                    newRow["complete_arp_no"] = row["complete_arp_no"];
                    newRow["property_pin"] = row["property_pin"];
                    newRow["property_kind"] = row["property_kind"];
                    newRow["property_location"] = location;
                    newRow["taxpayers_name"] = row["taxpayers_name"];
                    newRow["representative_name"] = row["representative_name"];
                    newRow["classification_code"] = row["classification_code"];
                    newRow["actual_use_code"] = row["actual_use_code"];
                    newRow["effectivity_quarter_and_year"] = effectivityQuarterAndYear;
                    newRow["other_improvements"] = row["other_improvements"];
                    newRow["assessed_value"] = row["assessed_value"];
                    newRow["is_taxable"] = row["is_taxable"];
                    newRow["is_cancelled"] = row["is_cancelled"];
                    newRow["created_at"] = row["created_at"];
                    newRow["updated_at"] = row["updated_at"];

                    progressCount++;
                    dataTable.Rows.Add(newRow);

                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
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

            HelperLoadRecords.RealPropertiesDatagridView(dgRealProperties, dataTable);

            dgRealProperties.CurrentCell = dgRealProperties.FirstDisplayedCell;
            toolStripStatusLabelRecordCount.Text = dgRealProperties.Rows.Count.ToString();
        }

        private void cbxShowCanclled_CheckedChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void cmbxRowFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadProperties();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgRealProperties_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgRealProperties.Columns.Count < 1)
                    return;

                byte createdByIndex = (byte)dgRealProperties.Columns["created_at"].Index;
                byte updatedByIndex = (byte)dgRealProperties.Columns["updated_at"].Index;

                var indexes = new byte[] { createdByIndex, updatedByIndex };
                Helper.EnableDisableToolStripMenuItems(dgRealProperties, btnEdit, btnDelete);
                Helper.ShowRecordTimestamp(dgRealProperties, indexes, toolStripStatusLabelCreatedAt, toolStripStatusLabelUpdatedAt);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadProperties();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmAddRealProperties(this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dgRealProperties.CurrentCell.RowIndex;
                var rptId = Convert.ToInt32(dgRealProperties.Rows[rowIndex].Cells["id"].Value);
                _ = new frmEditRealProperties(this, rptId).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteRpt())
                {
                    LoadProperties();
                    Helper.MessageBoxSuccess("Real properties has been deleted.");
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        #endregion Event Methods
    }
}