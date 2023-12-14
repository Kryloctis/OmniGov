using ACC.Data;
using ACC.Domain.Interfaces;
using ACC.Domain.Models;
using AccountingSystem.Views.Shared;
using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.TaxPayers
{
    public partial class ucRealProperties : UserControl
    {
        private bool isEdit;
        private int rptId;

        public ucRealProperties()
        {
            InitializeComponent();
        }

        #region Private Methods

        internal void OnLoad(bool isEdit, int rptId = 0)
        {
            LoadPropertyKind();
            LoadClassifications();
            LoadActualUseCodes();
            LoadBarangay();
            LoadTaxpayers();


            this.isEdit = isEdit;
            this.rptId = isEdit? rptId : 0;
            if (isEdit)
                LoadSelectedRecord();
        }

        private void LoadSelectedRecord()
        {
            var dictRpt = AccFactory.RealPropertiesRepository().GetRecordByID(rptId);

            chckTaxable.Checked = bool.TryParse(dictRpt["is_taxable"], out bool isTaxable) ? isTaxable : false;
            chckCancelled.Checked = bool.TryParse(dictRpt["is_cancelled"], out bool isCancelled) ? isCancelled : false;
            txtArpNo.Text = dictRpt["complete_arp_no"];
            txtPropertyPin.Text = dictRpt["property_pin"];
            cmbxPropertyKind.SelectedText = dictRpt["property_kind"];
            cmbxBarangays.SelectedValue = dictRpt["barangays_id"];
            cmbxClassification.SelectedValue = dictRpt["classification_codes_id"];
            cmbxActualUse.SelectedValue = Convert.ToInt32(dictRpt["actual_use_codes_id"]);
            nudEffectivityQuarter.Text = dictRpt["effectivity_quarter"];
            nudEffectivityYear.Text = dictRpt["effectivity_year"];
            nudAssessedValue.Value = Convert.ToDecimal(dictRpt["assessed_value"]);
            nudGrYear.Text = dictRpt["gr_year"];
            nudOtherImprv.Text = dictRpt["other_improvements"];
            nudArea.Text = dictRpt["area"];
            txtLotNo.Text = dictRpt["lot_no"];
            cmbxTaxpayer.SelectedValue = int.TryParse(dictRpt["taxpayers_id"], out int taxpayerId) ? taxpayerId : DBNull.Value;
        }

        internal RealPropertiesModel RealPropertiesModel()
        {
            return new RealPropertiesModel()
            {
                IsTaxable = chckTaxable.Checked,
                IsCancelled = chckCancelled.Checked,
                CompleteArpNo = txtArpNo.Text.Trim(),
                PropertyPin = txtPropertyPin.Text.Trim(),
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
                TaxpayersModel = new TaxpayersModel() { Id = (int)cmbxTaxpayer.SelectedValue }
            };
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

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
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
        }

        private void LoadPropertyKind()
        {
            var dict = new Dictionary<string, string>();

            dict.Add("1", "Land");
            dict.Add("2", "Building");
            dict.Add("3", "Machinery");

            cmbxPropertyKind.DataSource = new BindingSource(dict.Values, null);
        }

        private void LoadBarangay()
        {
            var dtBarangay = AccFactory.BarangayRepository().GetRecords();
            HelperLoadRecords.BarangaysCombobox(dtBarangay, cmbxBarangays, "name", "id");
        }

        private void LoadActualUseCodes()
        {
            var dtActualUse = AccFactory.ActualUseCodesRepository().GetRecords();
            HelperLoadRecords.ActualUseCombobox(dtActualUse, cmbxActualUse, "id", "name");
        }

        private void LoadClassifications()
        {
            var dtClassfications = AccFactory.ClassificationCodesRepository().GetRecords();
            HelperLoadRecords.ClassificationCombobox(dtClassfications, cmbxClassification, "id", "name");
        }

        private void LoadTaxpayers()
        {
            var registryColumn = new DataColumn[]
            {
                new DataColumn(Name = "id", typeof(int)),
                new DataColumn(Name = "name", typeof(string))
            };

            var dataTable = new DataTable();
            dataTable.Columns.AddRange(registryColumn);

            var dtRegistry = AccFactory.TaxpayersRepository().GetRecords();

            foreach (DataRow row in dtRegistry.Rows)
            {
                var newRow = dataTable.NewRow();

                int Id = Convert.ToInt32(row["id"]);

                newRow["id"] = Id;
                newRow["name"] = row["name"];

                dataTable.Rows.Add(newRow);
            }

            HelperLoadRecords.SearchableCombobox2(dataTable, cmbxTaxpayer, "id", "name");
        }

        private void LoadSelectedTaxpayer(int taxpayerId)
        {
            var dictTaxpayer = AccFactory.TaxpayersRepository().GetViewRecordById(taxpayerId);
            txtRepresentative.Text = dictTaxpayer["representative_name"];
        }

        private bool ArpNoValidated(bool isEdit, string arpNo, int rptId)
        {
            bool arpNoExist = isEdit ? AccFactory.RealPropertiesRepository().CompleteArpNoExist(arpNo, rptId) : AccFactory.RealPropertiesRepository().CompleteArpNoExist(arpNo);

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

        #endregion Private Methods

        #region Event Methods

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
                if (e.KeyChar == (char)Keys.Enter)
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

        #region Validations

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
                e.Cancel = TaxpayerValidated(errorProvider1, cmbxTaxpayer);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxTaxpayer_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxTaxpayer);
        }

        #endregion Validations

        #endregion Event Methods
    }
}