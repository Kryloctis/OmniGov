using ACC.Domain.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.MarriageLicense
{
    public partial class ucMarriageLicense : UserControl
    {
        public ucMarriageLicense()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtRegistrationNumber),
                errorProvider1.GetError(txtHusbandName),
                errorProvider1.GetError(nudHusbandAgeYear),
                errorProvider1.GetError(nudHusbandAgeMonth),
                errorProvider1.GetError(txtHusbandStreet),
                errorProvider1.GetError(cmbxHusbandProvince),
                errorProvider1.GetError(cmbxHusbandMunicipality),
                errorProvider1.GetError(cmbxHusbandBarangay),
                errorProvider1.GetError(txtWifeName),
                errorProvider1.GetError(nudWifeAgeYear),
                errorProvider1.GetError(nudWifeAgeMonth),
                errorProvider1.GetError(txtWifeStreet),
                errorProvider1.GetError(cmbxWifeProvince),
                errorProvider1.GetError(cmbxWifeMunicipality),
                errorProvider1.GetError(cmbxWifeBarangay),
            };

            IError error = AccFactory.CreateErrors(errorArray);
            return error.GenerateErrorMessage();
        }

        private void ucMarriageLicense_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadProvince();
                LoadBarangay();
                LoadMunicipality();
            }
        }

        private void LoadProvince()
        {
            var dtProvince = AccFactory.ProvincesRepository().GetRecords();
            HelperLoadRecords.ProvinceCombobox(dtProvince, cmbxHusbandProvince, "name", "id");
            HelperLoadRecords.ProvinceCombobox(dtProvince, cmbxWifeProvince, "name", "id");
        }

        private void LoadMunicipality()
        {
            var dtMunicipalities = AccFactory.MunicipalitiesRepository().GetRecords();
            HelperLoadRecords.MunicipalitiesCombobox(dtMunicipalities, cmbxWifeMunicipality, "name", "id");
            HelperLoadRecords.MunicipalitiesCombobox(dtMunicipalities, cmbxHusbandMunicipality, "name", "id");
        }

        private void LoadBarangay()
        {
            var dtBarangays = AccFactory.BarangayRepository().GetRecords();
            HelperLoadRecords.BarangaysCombobox(dtBarangays, cmbxHusbandBarangay, "name", "id");
            HelperLoadRecords.BarangaysCombobox(dtBarangays, cmbxWifeBarangay, "name", "id");
        }

        #region Validation

        private void txtRegistrationNumber_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtRegistrationNumber, "Registration Number.");
        }

        private void txtRegistrationNumber_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtRegistrationNumber);
        }

        private void txtHusbandName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtHusbandName, "Husband Name.");
        }

        private void txtHusbandName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtHusbandName);
        }

        private void nudHusbandAgeYear_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownZero(errorProvider1, nudHusbandAgeYear, "Husband Age.");
        }

        private void nudHusbandAgeYear_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudHusbandAgeYear);
        }

        private void nudHusbandAgeMonth_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownZero(errorProvider1, nudHusbandAgeMonth, "Husband Age In month.");
        }

        private void nudHusbandAgeMonth_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudHusbandAgeMonth);
        }

        private void txtHusbandStreet_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtHusbandStreet, "Husband Street.");
        }

        private void txtHusbandStreet_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtHusbandStreet);
        }

        private void cmbxHusbandProvince_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxHusbandProvince, "Husband Province.");
        }

        private void cmbxHusbandProvince_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxHusbandProvince);
        }

        private void cmbxHusbandMunicipality_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxHusbandMunicipality, "Husband Municipality.");
        }

        private void cmbxHusbandMunicipality_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxHusbandMunicipality);
        }

        private void cmbxHusbandBarangay_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxHusbandBarangay, "Husband Barangay.");
        }

        private void cmbxHusbandBarangay_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxHusbandBarangay);
        }

        private void txtWifeName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtWifeName, "Wife Name.");
        }

        private void txtWifeName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtWifeName);
        }

        private void nudWifeAgeYear_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownZero(errorProvider1, nudWifeAgeYear, "Wife Age.");
        }

        private void nudWifeAgeYear_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudWifeAgeYear);
        }

        private void nudWifeAgeMonth_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownZero(errorProvider1, nudWifeAgeMonth, "Wife Age in Month.");
        }

        private void nudWifeAgeMonth_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudWifeAgeMonth);
        }

        private void txtWifeStreet_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtWifeStreet, "Wife Street.");
        }

        private void txtWifeStreet_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtWifeStreet);
        }

        private void cmbxWifeProvince_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxWifeProvince, "Wife Province.");
        }

        private void cmbxWifeProvince_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxWifeProvince);
        }

        private void cmbxWifeMunicipality_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxWifeMunicipality, "Wife Municipality.");
        }

        private void cmbxWifeMunicipality_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxWifeMunicipality);
        }

        private void cmbxWifeBarangay_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxWifeBarangay, "Wife Barangay.");
        }

        private void cmbxWifeBarangay_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxWifeBarangay);
        }

        #endregion Validation
    }
}