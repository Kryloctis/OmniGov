using ACC.Data;
using ACC.Domain.Models;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Registry
{
    public partial class ucRegistry : UserControl
    {
        private int registryId;

        public ucRegistry()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errors = new string[]
            {
                errorProvider1.GetError(txtFirstName),
                errorProvider1.GetError(txtLastName),
                errorProvider1.GetError(txtNationality),
                errorProvider1.GetError(txtBarangay),
                errorProvider1.GetError(txtMunicipality),
                errorProvider1.GetError(txtProvince),
                errorProvider1.GetError(txtCountry)
            };

            return AccFactory.CreateErrors(errors).GenerateErrorMessage();
        }

        internal void ResetFields()
        {
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtLastName.Clear();
            radMale.Checked = true;
            txtNationality.Clear();
            txtContactInfo.Clear();
            dtBirthDate.Value = Helper.GetCurrentDate();
            txtStreet.Clear();
            txtBarangay.Clear();
            txtMunicipality.Clear();
            txtProvince.Clear();
            txtCountry.Clear();
        }

        internal RegistryModel RegistryModel()
        {
            return new RegistryModel()
            {
                FirstName = txtFirstName.Text.Trim(),
                MiddleName = txtMiddleName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Nationality = txtNationality.Text.Trim(),
                Sex = radMale.Checked ? "Male" : "Female",
                Street = txtNationality.Text.Trim(),
                BirthDate = dtBirthDate.Value,
                Barangay = txtBarangay.Text.Trim(),
                Municipality = txtMunicipality.Text.Trim(),
                Province = txtProvince.Text.Trim(),
                Country = txtCountry.Text.Trim(),
                ContactInfo = txtContactInfo.Text.Trim(),
            };
        }

        internal void OnLoad(bool isEdit, int registryId = 0)
        {
            if (isEdit)
            {
                this.registryId = registryId;
            }
            else
            {
            }
        }

        #region Validations

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtFirstName, "First Name");
        }

        private void txtFirstName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtFirstName);
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtLastName, "Last Name");
        }

        private void txtLastName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtLastName);
        }

        private void txtNationality_Validating(object sender, CancelEventArgs e)
        {
            Helper.ShowErrorTextBoxEmpty(errorProvider1, txtNationality, "Nationality");
        }

        private void txtNationality_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtNationality);
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

        private void txtCountry_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtCountry, "Country");
        }

        private void txtCountry_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtCountry);
        }

        #endregion Validations
    }
}