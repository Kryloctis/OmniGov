using ACC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RealProperties
{
    public partial class ucRealProperties : UserControl
    {
        internal bool isEdit = false;
        internal int realPropertiesId = 0;

        public ucRealProperties()
        {
            InitializeComponent();
        }

        internal string GetFormError()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtArpNo),
                errorProvider1.GetError(txtBarangay),
                errorProvider1.GetError(txtMunicipality),
                errorProvider1.GetError(txtProvince),
                errorProvider1.GetError(nudEffectivityYear),
                errorProvider1.GetError(nudAssessedValue),
                errorProvider1.GetError(nudGrYear),
                errorProvider1.GetError(nudArea),
                errorProvider1.GetError(txtLotNo),
                errorProvider1.GetError(txtOwnerName),
                errorProvider1.GetError(txtClassificationCode),
                errorProvider1.GetError(txtClassificationName),
                errorProvider1.GetError(txtActualUseCode),
                errorProvider1.GetError(txtActualUseName)
            };

            IError error = AccFactory.CreateErrors(errorArray);
            return error.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            foreach (Control control in Controls.OfType<TextBox>())
            {
                control.Text = string.Empty;
            }

            foreach (NumericUpDown control in Controls.OfType<NumericUpDown>())
            {
                control.Value = decimal.MinValue;
            }

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
            e.Cancel = !ArpNoValidated();
        }

        private void txtArpNo_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtArpNo);
        }

        private void txtBarangay_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtBarangay, "Barangay");
        }

        private void txtBarangay_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtBarangay);
        }

        private void txtMunicipality_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtMunicipality, "Municipality");
        }

        private void txtMunicipality_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtMunicipality);
        }

        private void txtProvince_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtProvince, "Province");
        }

        private void txtProvince_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtProvince);
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

        private void txtOwnerName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtOwnerName, "Owner Name");
        }

        private void txtOwnerName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtOwnerName);
        }

        private void txtClassificationCode_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtClassificationCode, "Classification Code");
        }

        private void txtClassificationCode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtClassificationCode);
        }

        private void txtClassificationName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtClassificationName, "Classification Name");
        }

        private void txtClassificationName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtClassificationName);
        }

        private void txtActualUseCode_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtActualUseCode, "Actual Use Code");
        }

        private void txtActualUseCode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtActualUseCode);
        }

        private void txtActualUseName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtActualUseName, "Actual Use Name");
        }

        private void txtActualUseName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtActualUseName);
        }

        #endregion Validations
    }
}