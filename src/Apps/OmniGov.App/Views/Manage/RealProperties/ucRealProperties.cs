using OmniGov.App.Helpers;
using OmniGov.Core.Entities;
using OmniGov.Core.Factories;
using OmniGov.Treasury.Data.Factories;
using OmniGov.Treasury.Domain.Entities;
using System.ComponentModel;
using System.Data;

namespace OmniGov.App.Views.Manage.RealProperties
{
    public partial class ucRealProperties : UserControl
    {
        private bool isEdit;
        private int rptId;

        public ucRealProperties()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);
            ActiveControl = txtArpNo;
        }

        internal void OnLoad(bool isEdit, int rptId = 0)
        {
            LoadPropertyKind();
            LoadClassifications();
            LoadActualUseCodes();
            LoadBarangay();
            LoadTaxpayers();
            LoadPreviousAssessments();
            LoadRealProperties();

            this.isEdit = isEdit;
            this.rptId = isEdit ? rptId : 0;
            if (isEdit)
                LoadSelectedRecord();
        }

        private void LoadSelectedRecord()
        {
            var dictRpt = TreasuryFactory.RealPropertiesRepository().GetViewRecordById(rptId);
            var dtPrevRptDb = TreasuryFactory.RptPreviousAssessmentRepository().GetRecordsByRptId(rptId);

            chckTaxable.Checked = (dictRpt["is_taxable"] == "1");
            chckCancelled.Checked = (dictRpt["is_cancelled"] == "1");
            txtArpNo.Text = dictRpt["complete_arp_no"];
            txtPropertyPin.Text = dictRpt["property_pin"];
            cmbxPropertyKind.SelectedValue = dictRpt["property_kind"];
            cmbxBarangays.SelectedValue = dictRpt["barangays_id"];
            cmbxClassification.SelectedValue = dictRpt["classification_codes_id"];
            cmbxActualUse.SelectedValue = dictRpt["actual_use_codes_id"];
            nudEffectivityQuarter.Text = dictRpt["effectivity_quarter"];
            nudEffectivityYear.Text = dictRpt["effectivity_year"];
            nudAssessedValue.Value = Convert.ToDecimal(dictRpt["assessed_value"]);
            nudGrYear.Text = dictRpt["gr_year"];
            nudOtherImprv.Text = dictRpt["other_improvements"];
            nudArea.Text = dictRpt["area"];
            txtLotNo.Text = dictRpt["lot_no"];
            cmbxTaxpayer.SelectedValue = dictRpt["taxpayers_id"];

            var dtPrevRpt = (DataTable)dataGridView1.DataSource;
            foreach (DataRow row in dtPrevRptDb.Rows)
            {
                var newRow = dtPrevRpt.NewRow();
                newRow["real_property_id"] = Convert.ToInt32(row["real_properties_id"]);
                newRow["complete_arp_no"] = row["complete_arp_no"];
                newRow["taxpayers_id"] = row["taxpayers_id"];
                newRow["taxpayer"] = row["complete_arp_no"];
                newRow["pin"] = row["pin"];
                newRow["assessed_value"] = row["assessed_value"];
                newRow["date_of_entry"] = row["date_of_entry"];
                newRow["effectivity_quarter"] = row["effectivity_quarter"];
                newRow["effectivity_year"] = row["effectivity_year"];
                newRow["gr_year"] = row["gr_year"];
                newRow["recording_person"] = row["recording_person"];
                newRow["is_taxable"] = row["is_taxable"];
                newRow["is_cancelled"] = row["is_cancelled"];

                dtPrevRpt.Rows.Add(newRow);
            }

            HelperLoadRecords.RptPreviousDatagridView(dataGridView1, dtPrevRpt);
        }

        internal RealPropertiesModel RealPropertiesModel()
        {
            return new RealPropertiesModel()
            {
                IsTaxable = chckTaxable.Checked,
                IsCancelled = chckCancelled.Checked,
                CompleteArpNo = txtArpNo.Text.Trim(),
                PropertyPin = txtPropertyPin.Text.Trim(),
                PropertyKind = cmbxPropertyKind.Text.ToUpper()[0],
                Street = txtStreet.Text.Trim(),
                BarangayModel = new BarangayModel() { Id = Convert.ToInt32(cmbxBarangays.SelectedValue) },
                ClassificationCodesModel = new ClassificationCodesModel() { Id = Convert.ToInt32(cmbxClassification.SelectedValue) },
                ActualUseCodesModel = new ActualUseCodesModel() { Id = Convert.ToInt32(cmbxActualUse.SelectedValue) },
                EffectivityQuarter = (int)nudEffectivityQuarter.Value,
                EffectivityYear = (int)nudEffectivityYear.Value,
                AssessedValue = (int)nudAssessedValue.Value,
                GrYear = (int)nudGrYear.Value,
                OtherImprovements = (int)nudOtherImprv.Value,
                Area = (int)nudArea.Value,
                LotNo = txtLotNo.Text.Trim(),
                TaxpayersModel = new TaxpayersModel() { Id = (int)cmbxTaxpayer.SelectedValue },
                RptPreviousAssessmentModels = RptPreviousAssessmentModels()
            };
        }

        private List<RptPreviousAssessmentModel> RptPreviousAssessmentModels()
        {
            var rptPrevAssessmentModels = new List<RptPreviousAssessmentModel>();
            var dtRptPreviousAssessment = (DataTable)dataGridView1.DataSource;

            foreach (DataRow row in dtRptPreviousAssessment.Rows)
            {
                int prevRptId = Convert.ToInt32(row["real_property_id"]);
                int prevTaxpayerId = Convert.ToInt32(row["taxpayers_id"]);
                var dictPrevRpt = TreasuryFactory.RealPropertiesRepository().GetViewRecordById(prevRptId);
                decimal assessedValue = Convert.ToDecimal(dictPrevRpt["assessed_value"]);
                decimal otherImprovements = Convert.ToDecimal(dictPrevRpt["other_improvements"]);

                var rptPrevAssessmentModel = new RptPreviousAssessmentModel
                {
                    RealPropertiesId = prevRptId,
                    TaxpayersModel = new TaxpayersModel { Id = prevTaxpayerId },
                    CompleteArpNo = dictPrevRpt["complete_arp_no"],
                    Pin = $"{dictPrevRpt["property_pin"]}",
                    AssessedValue = (assessedValue + otherImprovements),
                    DateOfEntry = Convert.ToDateTime(row["date_of_entry"]),
                    EffectivityQtr = dictPrevRpt["effectivity_quarter"],
                    EffectivityYear = dictPrevRpt["effectivity_year"],
                    GrYear = Convert.ToInt32(dictPrevRpt["gr_year"]),
                    RecordingPerson = row["recording_person"].ToString(),
                    IsCancelled = 0,
                    IsTaxable = 0,
                    CreatedBy = UserHelper.loggedUser.Id,
                };

                rptPrevAssessmentModels.Add(rptPrevAssessmentModel);
            }

            return rptPrevAssessmentModels;
        }

        internal string GetFormError()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtArpNo),
                errorProvider1.GetError(cmbxBarangays),
                errorProvider1.GetError(cmbxPropertyKind),
                errorProvider1.GetError(cmbxActualUse),
                errorProvider1.GetError(cmbxClassification),
                errorProvider1.GetError(nudEffectivityQuarter),
                errorProvider1.GetError(nudEffectivityYear),
                errorProvider1.GetError(nudAssessedValue),
                errorProvider1.GetError(nudGrYear),
                errorProvider1.GetError(nudArea),
                errorProvider1.GetError(cmbxTaxpayer)
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtArpNo.Clear();
            txtPropertyPin.Clear();
            LoadPropertyKind();
            LoadBarangay();
            LoadClassifications();
            LoadActualUseCodes();
            nudEffectivityQuarter.Value = 1;
            nudEffectivityYear.Value = Helper.GetCurrentDate().Year;
            nudAssessedValue.Value = 0;
            nudGrYear.Value = 0;
            nudOtherImprv.Value = 0;
            nudArea.Value = 0;
            txtLotNo.Clear();
            chckTaxable.Checked = true;
            chckCancelled.Checked = false;
            LoadPreviousAssessments();
            LoadRealProperties();
        }

        private void LoadPropertyKind()
        {
            var dataTable = new DataTable();

            var dataColumns = new DataColumn[]
            {
                new DataColumn(Name = "code", typeof(string)),
                new DataColumn(Name = "name", typeof(string)),
            };

            dataTable.Columns.AddRange(dataColumns);

            dataTable.Rows.Add("L", "Land");
            dataTable.Rows.Add("B", "Building");
            dataTable.Rows.Add("M", "Machinery");

            cmbxPropertyKind.DataSource = dataTable;
            cmbxPropertyKind.ValueMember = "code";
            cmbxPropertyKind.DisplayMember = "name";
        }

        private void LoadBarangay()
        {
            var dtBarangay = Factory.BarangayRepository().GetRecords();
            HelperLoadRecords.BarangaysCombobox(dtBarangay, cmbxBarangays, "name", "id");
        }

        private void LoadActualUseCodes()
        {
            var dtActualUse = Factory.ActualUseCodesRepository().GetRecords();
            HelperLoadRecords.ActualUseCombobox(dtActualUse, cmbxActualUse, "id", "name");
        }

        private void LoadClassifications()
        {
            var dtClassfications = Factory.ClassificationCodesRepository().GetRecords();
            HelperLoadRecords.ClassificationCombobox(dtClassfications, cmbxClassification, "id", "name");
        }

        private void LoadTaxpayers()
        {
            var dtTaxpayers = TreasuryFactory.TaxpayersRepository().GetRecords();
            HelperLoadRecords.SearchableCombobox2(dtTaxpayers, cmbxTaxpayer, "id", "name");
            HelperLoadRecords.SearchableCombobox2(dtTaxpayers, cmbxPreviousTaxpayer, "id", "name");
        }

        private void LoadSelectedTaxpayer(int taxpayerId)
        {
            var dictTaxpayer = TreasuryFactory.TaxpayersRepository().GetViewRecordById(taxpayerId);
            txtRepresentative.Text = dictTaxpayer["representative_name"];
        }

        private bool ArpNoValidated(bool isEdit, string arpNo, int rptId)
        {
            bool arpNoExist = isEdit ? TreasuryFactory.RealPropertiesRepository().CompleteArpNoExist(arpNo, rptId) : TreasuryFactory.RealPropertiesRepository().CompleteArpNoExist(arpNo);

            if (Helper.ShowErrorTextBoxEmpty(errorProvider1, txtArpNo, "ARP No."))
                return false;
            else if (arpNoExist)
            {
                errorProvider1.SetError(txtArpNo, "ARP No. already exist.");
                return false;
            }
            else
                return true;
        }

        private void LoadRealProperties()
        {
            var registryColumn = new DataColumn[]
            {
                new DataColumn(Name = "real_property_id", typeof(int)),
                new DataColumn(Name = "complete_arp_no", typeof(string))
            };

            var dataTable = new DataTable();
            dataTable.Columns.AddRange(registryColumn);

            var dtRealPropertiesFromDB = isEdit ? TreasuryFactory.RealPropertiesRepository().GetRecordNotExistedPreviousRpt(rptId) : TreasuryFactory.RealPropertiesRepository().GetRecordNotExistedPreviousRpt();

            foreach (DataRow row in dtRealPropertiesFromDB.Rows)
            {
                var newRow = dataTable.NewRow();

                int Id = Convert.ToInt32(row["real_property_id"]);
                string completeArpNo = $"{row["complete_arp_no"]}";

                newRow["real_property_id"] = Id;
                newRow["complete_arp_no"] = completeArpNo;

                dataTable.Rows.Add(newRow);
            }

            HelperLoadRecords.SearchableCombobox2(dataTable, cmbxPreviousRpt, "real_property_id", "complete_arp_no");
        }

        private void LoadPreviousAssessments()
        {
            var dataTable = new DataTable();

            var dataColumns = new DataColumn[]
            {
                new DataColumn(Name = "real_property_id", typeof(int)),
                new DataColumn(Name = "complete_arp_no", typeof(string)),
                new DataColumn(Name = "taxpayers_id", typeof(int)),
                new DataColumn(Name = "taxpayer", typeof(string)),
                new DataColumn(Name = "pin", typeof(string)),
                new DataColumn(Name = "assessed_value", typeof(decimal)),
                new DataColumn(Name = "date_of_entry", typeof(DateTime)),
                new DataColumn(Name = "effectivity_quarter", typeof(string)),
                new DataColumn(Name = "effectivity_year", typeof(string)),
                new DataColumn(Name = "gr_year", typeof(string)),
                new DataColumn(Name = "recording_person", typeof(string)),
                new DataColumn(Name = "is_taxable", typeof(bool)),
                new DataColumn(Name = "is_cancelled", typeof(bool)),
            };

            dataTable.Columns.AddRange(dataColumns);

            HelperLoadRecords.RptPreviousDatagridView(dataGridView1, dataTable);
        }

        private bool IsDuplicateRow(int rptId, DataTable dataTable)
        {
            // Use LINQ to check if a row with the same values exists
            var duplicateRows = from DataRow row in dataTable.AsEnumerable()
                                where row.Field<int>("real_property_id") == rptId
                                select row;

            return duplicateRows.Any();
        }

        private void cmbxPropertyKind_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string propertyKind = cmbxPropertyKind.Text;

                switch (propertyKind)
                {
                    case "Land":
                        nudOtherImprv.Enabled = true;
                        txtLotNo.Enabled = true;
                        nudArea.Enabled = true;
                        break;

                    case "Building":
                        nudOtherImprv.Enabled = false;
                        txtLotNo.Enabled = false;
                        nudArea.Enabled = true;
                        break;

                    default:
                        nudOtherImprv.Enabled = false;
                        txtLotNo.Enabled = false;
                        nudArea.Enabled = false;
                        break;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxTaxpayer_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    e.IsInputKey = true;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxTaxpayer_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (Control.ModifierKeys == Keys.Shift && e.KeyChar == (char)Keys.Enter)
                {
                    LoadTaxpayers();
                    cmbxTaxpayer.DroppedDown = cmbxTaxpayer.DroppedDown ? false : true;
                    cmbxTaxpayer.DroppedDown = true;
                    e.Handled = true;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxTaxpayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbxTaxpayer.SelectedValue is not int taxpayerId)
                    return;

                LoadSelectedTaxpayer(taxpayerId);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnDeleteRptPrev_Click(object sender, EventArgs e)
        {
            try
            {
                if (Helper.MessageBoxConfirmCancel("Confirm deletion of previous assessment?"))
                {
                    var dataSource = (DataTable)dataGridView1.DataSource;

                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        dataSource.Rows.RemoveAt(row.Index);
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxPreviousRpt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift && e.KeyChar == (char)Keys.Enter)

            {
                LoadRealProperties();
                cmbxPreviousRpt.DroppedDown = cmbxPreviousRpt.DroppedDown ? false : true;
                cmbxPreviousRpt.DroppedDown = true;
                e.Handled = true;
            }
        }

        private void btnAddPrevRpt_Click(object sender, EventArgs e)
        {
            try
            {
                var dataSource = (DataTable)dataGridView1.DataSource;
                int rptId = Convert.ToInt32(cmbxPreviousRpt.SelectedValue);

                if (IsDuplicateRow(rptId, dataSource))
                {
                    var errors = new string[] { "Real propertie already recorded to the list" };
                    var errorMessage = Factory.CreateErrors(errors).GenerateErrorMessage();

                    Helper.MessageBoxWarning(errorMessage);
                    return;
                }

                var newRow = dataSource.NewRow();
                newRow["real_property_id"] = rptId;
                newRow["complete_arp_no"] = cmbxPreviousRpt.Text;
                newRow["taxpayers_id"] = Convert.ToInt32(cmbxPreviousTaxpayer.SelectedValue);
                newRow["taxpayer"] = cmbxPreviousTaxpayer.Text;
                newRow["pin"] = txtPreviousPin.Text;
                newRow["assessed_value"] = nudPreviousAssessedValue.Text;
                newRow["date_of_entry"] = dtpDateOfEntry.Value;
                newRow["effectivity_quarter"] = nudPreviousEffectivityQuarter.Text;
                newRow["effectivity_year"] = nudPreviousEffectivityYear.Text;
                newRow["gr_year"] = nudPreviousGrYear.Text;
                newRow["recording_person"] = txtRecordingPerson.Text;
                newRow["is_taxable"] = cbxTaxable.Checked;
                newRow["is_cancelled"] = cbxCancelled.Checked;

                dataSource.Rows.Add(newRow);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtArpNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                string arpNo = txtArpNo.Text.Trim();
                e.Cancel = !ArpNoValidated(isEdit, arpNo, rptId);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtArpNo_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtArpNo);
        }

        private void nudEffectivityYear_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownEmpty(errorProvider1, nudEffectivityYear, "Effectivity Year");
        }

        private void nudEffectivityYear_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudEffectivityYear);
        }

        private void nudAssessedValue_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownZero(errorProvider1, nudAssessedValue, "Assessed Value");
        }

        private void nudAssessedValue_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudAssessedValue);
        }

        private void nudGrYear_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownZero(errorProvider1, nudGrYear, "GR Year");
        }

        private void nudGrYear_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudGrYear);
        }

        private void nudArea_Validating(object sender, CancelEventArgs e)
        {
            if (cmbxPropertyKind.Text == "Land")
                e.Cancel = Helper.ShowErrorNumericUpDownZero(errorProvider1, nudArea, "Area");
        }

        private void nudArea_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudArea);
        }

        private void txtLotNo_Validating(object sender, CancelEventArgs e)
        {
            if (cmbxPropertyKind.Text == "Land")
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtLotNo, "Lot No.");
        }

        private void txtLotNo_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtLotNo);
        }

        private void cmbxBarangays_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxBarangays, "Barangay");
        }

        private void cmbxBarangays_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxBarangays);
        }

        private void cmbxClassification_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxClassification, "Classification");
        }

        private void cmbxClassification_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxClassification);
        }

        private void cmbxActualUse_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxActualUse, "Actual Used");
        }

        private void cmbxActualUse_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxActualUse);
        }

        private bool TaxpayerValidated(ErrorProvider errorProvider, ComboBox comboBox)
        {
            if (Helper.ShowErrorComboBoxEmpty(errorProvider, comboBox, "Taxpayer"))
                return false;
            else if (comboBox.SelectedIndex < 0)
            {
                errorProvider.SetError(comboBox, "Taxpayer");
                return false;
            }

            return true;
        }

        private void cmbxTaxpayer_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !TaxpayerValidated(errorProvider1, cmbxTaxpayer);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxTaxpayer_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxTaxpayer);
        }

        private void cmbxPreviousTaxpayer_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (Control.ModifierKeys == Keys.Shift && e.KeyChar == (char)Keys.Enter)
                {
                    LoadTaxpayers();
                    cmbxPreviousTaxpayer.DroppedDown = cmbxPreviousTaxpayer.DroppedDown ? false : true;
                    cmbxPreviousTaxpayer.DroppedDown = true;
                    e.Handled = true;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}

