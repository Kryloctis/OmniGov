using ACC.Domain.Models;
using RPT.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RealProperties
{
    public partial class frmRealProperties : Form
    {
        public frmRealProperties()
        {
            Helper.LoadFormIcon(this);
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);
        }

        private DataTable RealPropertiesDataTable()
        {
            var dtRealProperties = AccFactory.RealPropertiesRepository().GetRecords();
            var dataTable = new DataTable();
            var selectedColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("property_identifier", typeof(string)),
                new DataColumn("complete_arp_no", typeof(string)),
                new DataColumn("property_kind", typeof(string)),
                new DataColumn("property_pin", typeof(string)),
                new DataColumn("owner_name", typeof(string)),
                new DataColumn("owner_tin", typeof(string)),
                new DataColumn("owner_address", typeof(string)),
                new DataColumn("owner_contact", typeof(string)),
                new DataColumn("barangay_name", typeof(string)),
                new DataColumn("municipality_name", typeof(string)),
                new DataColumn("province_name", typeof(string)),
                new DataColumn("assessed_value", typeof(decimal)),
                new DataColumn("is_cancelled", typeof(bool))
            };
            dataTable.Columns.AddRange(selectedColumns);

            foreach (DataRow row in dtRealProperties.Rows)
            {             
                var newRow = dataTable.NewRow();
                int rowId = Convert.ToInt32(row["id"]);
                string rowPropertyIdentifier = row["property_identifier"].ToString();
                string rowCompleteArpNo = row["complete_arp_no"].ToString();
                string rowPropertyKind = row["property_kind"].ToString();
                string rowPropertyPin = row["property_pin"].ToString();
                string rowOwnerName = row["owner_name"].ToString();
                string rowOwnerTin = row["owner_tin"].ToString();
                string rowOwnerAddress = row["owner_address"].ToString();
                string rowOwnerContact = row["owner_contact"].ToString();
                string rowBarangayName = row["barangay_name"].ToString();
                string rowMunicipalityName = row["municipality_name"].ToString();
                string rowProvinceName = row["province_name"].ToString();
                decimal rowAssessedValue = Convert.ToDecimal(row["assessed_value"]);
                bool rowIsCancelled = Convert.ToBoolean(row["is_cancelled"]);

                newRow["id"] = rowId;
                newRow["property_identifier"] = rowPropertyIdentifier;
                newRow["complete_arp_no"] = rowCompleteArpNo;
                newRow["property_kind"] = rowPropertyKind;
                newRow["property_pin"] = rowPropertyPin;
                newRow["owner_name"] = rowOwnerName;
                newRow["owner_tin"] = rowOwnerTin;
                newRow["owner_address"] = rowOwnerAddress;
                newRow["owner_contact"] = rowOwnerContact;
                newRow["barangay_name"] = rowBarangayName;
                newRow["municipality_name"] = rowMunicipalityName;
                newRow["province_name"] = rowProvinceName;
                newRow["assessed_value"] = rowAssessedValue;
                newRow["is_cancelled"] = rowIsCancelled;

                dataTable.Rows.Add(newRow);
            }

            return dataTable;
        }

        internal void LoadRealProperties()
        {
            try
            {
                HelperLoadRecords.RealPropertiesDatagridView(dataGridView1, RealPropertiesDataTable());
                lblRecordCount.Text = Helper.GetDatagridViewRecordCount(dataGridView1).ToString();
                dataGridView1.CurrentCell = dataGridView1.FirstDisplayedCell;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmRealProperties_Load(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
            LoadRealProperties();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddRealProperties(this).ShowDialog();
        }

        private void ShowEditRealPropertiesForm()
        {
            int rowIndex = dataGridView1.CurrentRow.Index;
            int realPropertiesId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["id"].Value);

            _ = new frmEditRealProperties(realPropertiesId, this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShowEditRealPropertiesForm();
        }

        private bool Delete()
        {
            try
            {
                var realPropertiesModelList = new List<RealPropertiesModel>();
                int rowCount = dataGridView1.SelectedRows.Count;

                if (Helper.MessageBoxConfirmDelete(rowCount))
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        int realPropertiesId = Convert.ToInt32(row.Cells["id"].Value);
                        var model = new RealPropertiesModel() { Id = realPropertiesId };
                        realPropertiesModelList.Add(model);
                    }

                    return AccFactory.RealPropertiesRepository().Delete(realPropertiesModelList);
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Delete())
            {
                Helper.MessageBoxSuccess("Real Properties has been deleted.");
                LoadRealProperties();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Delete())
            {
                Helper.MessageBoxSuccess("Real Properties has been deleted.");
                LoadRealProperties();
            }
        }

        #region Synchronize

        private void btnSynchronize_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                var realProperiesModelList = new List<RealPropertiesModel>();
                var dtPropertyAssessmentPosting = RptFactory.RealPropertiesRepository().GetViewPropertyAssessmentPostingRecords();
                int inputCount = 0;

                foreach (DataRow row in dtPropertyAssessmentPosting.Rows)
                {
                    string propertyIdentifier = row["real_properties_identifier"].ToString();
                    string completeArpNo = row["complete_arp_no"].ToString();
                    string pin = row["pin"].ToString();
                    string ownerName = row["owner_name"].ToString();
                    string ownerTin = row["owner_tin"].ToString();
                    string ownerAddress = row["owner_address"].ToString();
                    string ownerContact = row["owner_contact"].ToString();
                    string barangayName = row["barangays_name"].ToString();
                    string municipalityName = row["municipality_name"].ToString();
                    string provinceName = row["provinces_name"].ToString();
                    string propertyKind = row["property_kind"].ToString();
                    int effectivityQuarter = Convert.ToInt32(row["effectivity_quarter"]);
                    int effectivityYear = Convert.ToInt32(row["effectivity_year"]);
                    decimal otherImprovements = Convert.ToDecimal(row["other_improvements"]);
                    decimal assessedValue = Convert.ToDecimal(row["assessed_value"]);
                    decimal area = Convert.ToDecimal(row["land_area"]);
                    string lotNo = row["land_lot_no"].ToString();
                    string classificationCode = row["classification_code"].ToString();
                    string classificationName = row["classification_name"].ToString();
                    string actualUseCode = row["actual_use_code"].ToString();
                    string actualUseName = row["actual_use_name"].ToString();
                    int grYear = Convert.ToInt32(row["gryear"]);
                    bool isTaxable = Convert.ToBoolean(Convert.ToByte(row["is_taxable"]));
                    bool isCancelled = Convert.ToBoolean(Convert.ToByte(row["is_cancelled"]));

                    var realPropertiesModel = new RealPropertiesModel()
                    {
                        PropertyIdentifier = propertyIdentifier,
                        CompleteArpNo = completeArpNo,
                        Pin = pin,
                        OwnerName = ownerName,
                        OwnerTin = ownerTin,
                        OwnerAddress = ownerAddress,
                        OwnerContact = ownerContact,
                        BarangayName = barangayName,
                        MunicipalityName = municipalityName,
                        ProvinceName = provinceName,
                        PropertyKind = propertyKind,
                        EffectivityQuarter = effectivityQuarter,
                        EffectivityYear = effectivityYear,
                        OtherImprovements = otherImprovements,
                        AssessedValue = assessedValue,
                        Area = area,
                        LotNo = lotNo,
                        ClassificationCode = classificationCode,
                        ClassificationName = classificationName,
                        ActualUseCode = actualUseCode,
                        ActualUseName = actualUseName,
                        GrYear = grYear,
                        IsTaxable = isTaxable,
                        IsCancelled = isCancelled
                    };

                    realProperiesModelList.Add(realPropertiesModel);
                    int totalRows = dtPropertyAssessmentPosting.Rows.Count;
                    inputCount += 1;

                    backgroundWorker1.ReportProgress((inputCount * 100) / totalRows, "Sychronizing Data...");
                }

                AccFactory.RealPropertiesRepository().SynchronizeData(realProperiesModelList);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Visible = true;
            lblProgressStatus.Visible = true;

            toolStripProgressBar1.Value = e.ProgressPercentage;
            lblProgressStatus.Text = e.UserState.ToString();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (toolStripProgressBar1.Value == 100)
            {
                LoadRealProperties();
                lblProgressStatus.Text = "Done.";
                Helper.MessageBoxSuccess("Real Properties has been synchronized");
                lblProgressStatus.Visible = false;
                toolStripProgressBar1.Visible = false;
            }
        }

        #endregion Synchronize

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
            Helper.EnableDisableToolStripMenuItems(dataGridView1, updateToolStripMenuItem, deleteToolStripMenuItem);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1 && e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition);
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadRealProperties();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowEditRealPropertiesForm();
        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
        }
    }
}