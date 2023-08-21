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
        internal int realPropertiesID;
        internal int taxpayerID;

        public frmRealProperties()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgRealProperties);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddRealProperties(this).ShowDialog();
        }

        private bool Delete()
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Delete())
                {
                    LoadProperties();
                    Helper.MessageBoxSuccess("Real properties has been deleted.");
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dgRealProperties.CurrentCell.RowIndex;
                realPropertiesID = Convert.ToInt32(dgRealProperties.Rows[rowIndex].Cells["real_properties_id"].Value);
                taxpayerID = Convert.ToInt32(dgRealProperties.Rows[rowIndex].Cells["real_taxpayers_id"].Value);
                _ = new frmEditRealProperties(this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private DataColumn[] RealPropertiesColumn()
        {
            var dataColumns = new DataColumn[] {
                new DataColumn("real_properties_id", typeof(int)),
                new DataColumn("property_identifier", typeof(string)),
                new DataColumn("complete_arp_no", typeof(string)),
                new DataColumn("property_pin", typeof(string)),
                new DataColumn("real_taxpayers_id", typeof(int)),
                new DataColumn("real_taxpayers_tin", typeof(string)),
                new DataColumn("real_taxpayers_name", typeof(string)),
                new DataColumn("real_taxpayers_contact_info", typeof(string)),
                new DataColumn("real_taxpayers_street", typeof(string)),
                new DataColumn("real_taxpayers_is_active", typeof(bool)),
                new DataColumn("taxpayer_tin", typeof(string)),
                new DataColumn("taxpayer_name", typeof(string)),
                new DataColumn("taxpayer_contact_info", typeof(string)),
                new DataColumn("taxpayer_address", typeof(string)),
                new DataColumn("real_properties_street", typeof(string)),
                new DataColumn("real_properties_barangays_id", typeof(int)),
                new DataColumn("real_properties_barangays_code", typeof(string)),
                new DataColumn("real_properties_barangays_name", typeof(string)),
                new DataColumn("real_properties_municipalities_id", typeof(int)),
                new DataColumn("real_properties_municipalities_code", typeof(string)),
                new DataColumn("real_properties_municipalities_name", typeof(string)),
                new DataColumn("real_properties_provinces_id", typeof(int)),
                new DataColumn("real_properties_provinces_code", typeof(string)),
                new DataColumn("real_properties_provinces_name", typeof(string)),
                new DataColumn("real_properties_location", typeof(string)),
                new DataColumn("classification_codes_id", typeof(int)),
                new DataColumn("classification_codes", typeof(string)),
                new DataColumn("classification_codes_name", typeof(string)),
                new DataColumn("classification_codes_is_special", typeof(string)),
                new DataColumn("actual_use_codes_id", typeof(int)),
                new DataColumn("actual_use_codes", typeof(string)),
                new DataColumn("actual_use_codes_name", typeof(string)),
                new DataColumn("actual_use_codes_is_government", typeof(bool)),
                new DataColumn("property_kind", typeof(string)),
                new DataColumn("effectivity_quarter", typeof(int)),
                new DataColumn("effectivity_year", typeof(int)),
                new DataColumn("effectivity_quarter_and_year", typeof(string)),
                new DataColumn("other_improvements", typeof(decimal)),
                new DataColumn("assessed_value", typeof(decimal)),
                new DataColumn("area", typeof(decimal)),
                new DataColumn("lot_no", typeof(string)),
                new DataColumn("gr_year", typeof(int)),
                new DataColumn("is_taxable", typeof(bool)),
                new DataColumn("is_cancelled", typeof(bool)),
                new DataColumn("created_at", typeof(string)),
                new DataColumn("updated_at", typeof(string)),
            };

            return dataColumns;
        }

        private void frmRealProperties_Load(object sender, EventArgs e)
        {
            try
            {
                LoadProperties();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private DataTable DataTableRealProperties()
        {
            string searchValue = txtSearch.Text.Trim();
            bool showCancelled = cbxShowCanclled.Checked;

            var dtRealProperties = new DataTable();
            dtRealProperties.Columns.AddRange(RealPropertiesColumn());

            DataTable dtRealPropertiesFromDB = AccFactory.RealPropertiesRepository().GetRecordsBySearch(searchValue, showCancelled);
            int recordsCount = dtRealPropertiesFromDB.Rows.Count;
            int rowCount = 0;

            foreach (DataRow row in dtRealPropertiesFromDB.Rows)
            {
                var newRow = dtRealProperties.NewRow();

                string location = $"{row["real_properties_street"]} {row["real_properties_barangays_name"]} {row["real_properties_municipalities_name"]} {row["real_properties_provinces_name"]}";
                string effectivityQuarterAndYear = $"{row["effectivity_quarter"]} / {row["effectivity_year"]}";

                dtRealProperties.Rows.Add(new object[]
                {
                    row["real_properties_id"],
                    row["property_identifier"],
                    row["complete_arp_no"],
                    row["property_pin"],
                    row["real_taxpayers_id"],
                    row["real_taxpayers_tin"],
                    row["real_taxpayers_name"],
                    row["real_taxpayers_contact_info"],
                    row["real_taxpayers_street"],
                    row["real_taxpayers_is_active"],
                    row["taxpayer_tin"],
                    row["taxpayer_name"],
                    row["taxpayer_contact_info"],
                    row["taxpayer_address"],
                    row["real_properties_street"],
                    row["real_properties_barangays_id"],
                    row["real_properties_barangays_code"],
                    row["real_properties_barangays_name"],
                    row["real_properties_municipalities_id"],
                    row["real_properties_municipalities_code"],
                    row["real_properties_municipalities_name"],
                    row["real_properties_provinces_id"],
                    row["real_properties_provinces_code"],
                    row["real_properties_provinces_name"],
                    location,
                    row["classification_codes_id"],
                    row["classification_codes"],
                    row["classification_codes_name"],
                    row["classification_codes_is_special"],
                    row["actual_use_codes_id"],
                    row["actual_use_codes"],
                    row["actual_use_codes_name"],
                    row["actual_use_codes_is_government"],
                    row["property_kind"],
                    row["effectivity_quarter"],
                    row["effectivity_year"],
                    effectivityQuarterAndYear,
                    row["other_improvements"],
                    row["assessed_value"],
                    row["area"],
                    row["lot_no"],
                    row["gr_year"],
                    row["is_taxable"],
                    row["is_cancelled"],
                    row["created_at"],
                    row["updated_at"],
                });

                rowCount++;
                int progressBarPercentage = (rowCount * 100) / recordsCount;
                backgroundWorker1.ReportProgress(progressBarPercentage);
            }

            return dtRealProperties;
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                HelperLoadRecords.RealPropertiesDatagridView(dgRealProperties, DataTableRealProperties());
            });
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void cbxShowCanclled_CheckedChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }

        internal void LoadProperties()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbLoadRecords.Value = 0;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgRealProperties.CurrentCell = dgRealProperties.FirstDisplayedCell;
            toolStripStatusLabelRecordCount.Text = dgRealProperties.Rows.Count.ToString();
        }
    }
}