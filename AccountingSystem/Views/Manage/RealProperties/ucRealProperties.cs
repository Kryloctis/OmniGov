using ACC.Domain.Interfaces;
using AccountingSystem.Views.Manage.RealProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.TaxPayers
{
    public partial class ucRealProperties : UserControl
    {
        internal bool isEdit = false;
        internal int realPropertiesId = 0;
        internal int taxpayerID;
        internal string propertyIdentifier = "0";

        public ucRealProperties()
        {
            InitializeComponent();
        }

        internal string GetFormError()
        {
            var errorArray = new string[9];

            errorArray[0] = errorProvider1.GetError(txtArpNo);
            errorArray[1] = errorProvider1.GetError(cmbxBarangays);
            errorArray[2] = errorProvider1.GetError(cmbxPropertyKind);
            errorArray[3] = errorProvider1.GetError(cmbxActualUse);
            errorArray[4] = errorProvider1.GetError(nudEffectivityYear);
            errorArray[5] = errorProvider1.GetError(nudAssessedValue);
            errorArray[6] = errorProvider1.GetError(nudGrYear);
            errorArray[7] = errorProvider1.GetError(nudArea);
            errorArray[8] = errorProvider1.GetError(txtLotNo);

            IError error = AccFactory.CreateErrors(errorArray);
            return error.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            if (isEdit)
                realPropertiesId = 0;

            txtArpNo.Clear();
            txtPropertyPin.Clear();
            txtLotNo.Clear();
            nudEffectivityQuarter.Value = 1;
            nudEffectivityYear.Value = Helper.GetCurrentDate().Year;
            nudAssessedValue.Value = 0;
            nudGrYear.Value = 0;
            nudOtherImprv.Value = 0;
            nudArea.Value = 0;
            cmbxPropertyKind.SelectedIndex = 0;
            chckTaxable.Checked = false;
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

        private void LoadPropertiesPreviousARPNumber()
        {

            try
            {
                var dt = AccFactory.RealPropertiesRepository().GetCancelledProperties();

                cmbxCompletePreviousARPNumber.DataSource = dt;
                cmbxCompletePreviousARPNumber.DisplayMember = "complete_arp_no";
                cmbxCompletePreviousARPNumber.ValueMember = "real_properties_id";
                cmbxCompletePreviousARPNumber.DropDownHeight = 200;


            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private DataTable DatatableAccounts()
        {
            if (string.IsNullOrEmpty(cmbxCompletePreviousARPNumber.Text))
                return AccFactory.RealPropertiesRepository().GetRecords();
            else
                return AccFactory.RealPropertiesRepository().GetRecordsByCompleteARP(cmbxCompletePreviousARPNumber.Text);
        }

        private void ucRealProperties_Load(object sender, EventArgs e)
        {
           LoadPropertyKind();
           LoadClassificationCodes();
           LoadActualUseCodes();
           LoadBarangay();
           LoadPropertiesPreviousARPNumber();
        }

        private void LoadBarangay()
        {
            var dt = AccFactory.BarangayRepository().GetRecords();

            cmbxBarangays.DataSource = dt;
            cmbxBarangays.ValueMember = "id";
            cmbxBarangays.DisplayMember = "name";
        }

        private void LoadActualUseCodes()
        {
            var dt = AccFactory.ActualUseCodesRepository().GetRecords();

            cmbxActualUse.DataSource = dt;
            cmbxActualUse.ValueMember = "id";
            cmbxActualUse.DisplayMember = "name";
        }

        private void LoadClassificationCodes()
        {
            var dt = AccFactory.ClassificationCodesRepository().GetRecords();

            cmbxClassification.DataSource = dt;
            cmbxClassification.ValueMember = "id";
            cmbxClassification.DisplayMember = "name";
        }



        private void cmbxPropertyKind_SelectedValueChanged(object sender, EventArgs e)
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

        private void btnSelectTaxpayer_Click(object sender, EventArgs e)
        {
            _ = new frmTaxpayersList(this).ShowDialog();
        }

        private void cmbxCompletePreviousARPNumber_TextChanged(object sender, EventArgs e)
        {
            //LoadPropertiesPreviousARPNumber();
        }

        private void cmbxCompletePreviousARPNumber_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string completeARPNo = cmbxCompletePreviousARPNumber.SelectedText;
            var previousAssessmentDict = AccFactory.RealPropertiesRepository().GetRecordByCompleteArpNo(completeARPNo);

            propertyIdentifier = previousAssessmentDict["property_identifier"];
            txtPreviousPin.Text = previousAssessmentDict["property_pin"];
            txtPreviousAssessedValue.Text = previousAssessmentDict["assessed_value"];
            txtPreviousOwner.Text = previousAssessmentDict["taxpayer_name"];
            txtPreviousEffectivityAssessment.Text = previousAssessmentDict["created_at"];
        }

        #region Validations

        private void txtArpNo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                string arpNo = txtArpNo.Text.Trim();
                bool arpNoExist;

                if (isEdit)
                    arpNoExist = AccFactory.RealPropertiesRepository().CompleteArpNoExist(arpNo, realPropertiesId);
                else
                    arpNoExist = AccFactory.RealPropertiesRepository().CompleteArpNoExist(arpNo);

                if (Helper.ShowErrorTextBoxEmpty(errorProvider1, txtArpNo, "ARP No."))
                    return;
                else if (arpNoExist)
                {
                    errorProvider1.SetError(txtArpNo, "ARP No. already exist.");
                    return;
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return;
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


        private void txtPreviousCompleteARP_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxCompletePreviousARPNumber, "Previous ARP Number.");

            string completeARPNumber = cmbxCompletePreviousARPNumber.Text;
            if (!AccFactory.RealPropertiesRepository().CompleteArpNoExist(completeARPNumber))
            {
                errorProvider1.SetError(cmbxCompletePreviousARPNumber, "Previous ARP Number doesnt exist.");
                e.Cancel = true; return;
            }
        }

        private void txtPreviousCompleteARP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxCompletePreviousARPNumber);
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

        private void cmbxCompletePreviousARPNumber_Validating(object sender, CancelEventArgs e)
        {

        }

        private void cmbxCompletePreviousARPNumber_Validated(object sender, EventArgs e)
        {

        }

        private void txtTaxpayers_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtTaxpayers_Validated(object sender, EventArgs e)
        {

        }

        #endregion Validations


    }
}