using OmniGov.App.Helpers;
using OmniGov.Core.Entities;
using OmniGov.Core.Factories;
using System.ComponentModel;

namespace OmniGov.App.Views.Manage.AllotmentClasses
{
    public partial class ucAllotmentClasses : UserControl
    {
        private int allotmentClassId;
        private bool isEdit;

        public ucAllotmentClasses()
        {
            InitializeComponent();
        }

        internal AllotmentClassesModel AllotmentClassesModel()
        {
            return new AllotmentClassesModel()
            {
                AllotmentCode = txtCode.Text.Trim(),
                AllotmentName = txtName.Text.Trim(),
            };
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtName),
                errorProvider1.GetError(txtCode)
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void OnLoad(bool isEdit, int? allotmentClassId)
        {
            this.isEdit = isEdit;

            if (isEdit)
            {
                this.allotmentClassId = allotmentClassId.Value;
                LoadSelectedRecord();
            }
        }

        internal void ResetForm()
        {
            txtName.Clear();
            txtCode.Clear();
        }

        private bool CodeValidated()
        {
            if (Helper.ShowErrorTextBoxEmpty(errorProvider1, txtCode, "Allotment class code"))
                return false;

            string allotmentCode = txtCode.Text.Trim();
            bool allotmentCodeExist = isEdit ? Factory.AllotmentClassesRepository().CodeExist(allotmentCode, allotmentClassId) : Factory.AllotmentClassesRepository().CodeExist(allotmentCode);

            if (allotmentCodeExist)
            {
                errorProvider1.SetError(txtCode, "Code already exist.");
                return false;
            }

            return true;
        }

        private void LoadSelectedRecord()
        {
            var allotmentData = Factory.AllotmentClassesRepository().GetRecordByID(allotmentClassId);
            txtName.Text = allotmentData["allotment_name"];
            txtCode.Text = allotmentData["allotment_code"];
        }

        private bool NameValidated()
        {
            if (Helper.ShowErrorTextBoxEmpty(errorProvider1, txtName, "Name"))
                return false;

            string allotmentName = txtName.Text.Trim();
            bool allotmentNameExist = isEdit ? Factory.AllotmentClassesRepository().NameExist(allotmentName, allotmentClassId) : Factory.AllotmentClassesRepository().NameExist(allotmentName);

            if (allotmentNameExist)
            {
                errorProvider1.SetError(txtName, "Name already exist.");
                return false;
            }

            return true;
        }

        private void txtCode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtCode);
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !CodeValidated();
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtName);
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !NameValidated();
        }
    }
}