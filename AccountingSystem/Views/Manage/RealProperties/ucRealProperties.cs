using ACC.Domain.Interfaces;
using AccountingSystem.Views.Manage.RealProperties;
using AccountingSystem.Views.Reports.RealPropertyTaxReports.RealPropertyTaxAccountRegister;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.TaxPayers
{
    public partial class ucRealProperties : UserControl
    {
        internal bool isEdit = false;
        internal int realPropertiesId = 0;
        internal int taxpayerID;
        internal int propertyIdentifier = 1;

        public ucRealProperties()
        {
            InitializeComponent();
        }

        internal string GetFormError()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtArpNo),
                errorProvider1.GetError(cmbxBarangays),
                errorProvider1.GetError(cmbxPropertyKind),
                errorProvider1.GetError(cmbxActualUse),
                errorProvider1.GetError(nudEffectivityYear),
                errorProvider1.GetError(nudAssessedValue),
                errorProvider1.GetError(nudGrYear),
                errorProvider1.GetError(nudArea),
                errorProvider1.GetError(txtLotNo),
            };

            IError error = AccFactory.CreateErrors(errorArray);
            return error.GenerateErrorMessage();
        }

        internal void LoadProperties()
        {

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

        private void ucRealProperties_Load(object sender, EventArgs e)
        {
            LoadPropertyKind();
            LoadClassificationCodes();
            LoadActualUseCodes();
            LoadBarangay();
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


        #region Validations

        private bool ArpNoValidated()
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
                    return false;
                else if (arpNoExist)
                {
                    errorProvider1.SetError(txtArpNo, "ARP No. already exist.");
                    return false;
                }
                else
                    return true;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void txtArpNo_Validating(object sender, CancelEventArgs e)
        {
            //e.Cancel = !ArpNoValidated();
            e.Cancel = false;
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

        #endregion Validations

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
    }
}