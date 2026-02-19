using OmniGov.App.Helpers;
using OmniGov.Core.Entities;
using OmniGov.Core.Factories;
using System.ComponentModel;

namespace OmniGov.App.Views.Manage.Barangay
{
    public partial class ucBarangay : UserControl
    {
        private int barangayId;
        private bool isEdit;

        public ucBarangay()
        {
            InitializeComponent();
        }

        private void LoadSelectedBarangay(int barangayId)
        {
            var dictBarangay = Factory.BarangayRepository().GetRecordByID(barangayId);
            txtCode.Text = dictBarangay["code"];
            txtName.Text = dictBarangay["name"];
        }

        internal BarangayModel BarangayModel()
        {
            return new BarangayModel()
            {
                Code = txtCode.Text.Trim(),
                Name = txtName.Text.Trim(),
                MunicipalityId = (ServerHelper.SelectedProfile?.Id ?? 0),
            };
        }

        internal void OnLoad(bool isEdit, int? barangayId)
        {
            this.isEdit = isEdit;

            if (isEdit)
            {
                this.barangayId = barangayId.Value;
                LoadSelectedBarangay(this.barangayId);
            }
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtCode),
                errorProvider1.GetError(txtName)
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtCode.Clear();
            txtName.Clear();
        }

        private bool BarangayCodeValidated(ErrorProvider errorProvider, TextBox textBox)
        {
            if (Helper.ShowErrorTextBoxEmpty(errorProvider, textBox, "Barangay Code"))
                return false;

            string barangayCode = textBox.Text.Trim();
            bool codeExist = isEdit ? Factory.BarangayRepository().CodeExist(barangayCode, barangayId) : Factory.BarangayRepository().CodeExist(barangayCode);

            if (codeExist)
            {
                errorProvider.SetError(textBox, "Code already exist.");
                return false;
            }

            return true;
        }

        private bool BarangayNameValidated(ErrorProvider errorProvider, TextBox textBox)
        {
            if (Helper.ShowErrorTextBoxEmpty(errorProvider, textBox, "Barangay Name"))
                return false;

            string barangayName = textBox.Text.Trim();
            bool nameExist = isEdit ? Factory.BarangayRepository().NameExist(barangayName, barangayId) : Factory.BarangayRepository().NameExist(barangayName);

            if (nameExist)
            {
                errorProvider.SetError(textBox, "Name already exist.");
                return false;
            }
            return true;
        }

        private void txtBarangay_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !BarangayNameValidated(errorProvider1, txtName);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtBarangay_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtName);
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !BarangayCodeValidated(errorProvider1, txtCode);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtCode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtCode);
        }
    }
}



