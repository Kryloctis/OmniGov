using ACC.Data;
using ACC.Domain.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AllotmentClasses
{
    public partial class ucAllotmentClasses : UserControl
    {
        internal int allotmentClassesId = 0;
        internal bool isEdit = false;

        public ucAllotmentClasses()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtName),
                errorProvider1.GetError(txtCode)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtName.Clear();
            txtCode.Clear();
        }

        private bool NameValidated()
        {
            if (Helper.ShowErrorTextBoxEmpty(errorProvider1, txtName, "Allotment class name"))
                return false;

            string allotmentName = txtName.Text.Trim();
            bool allotmentNameExist;

            if (!isEdit)
                allotmentNameExist = AccFactory.AllotmentClassesRepository().NameExist(allotmentName);
            else
                allotmentNameExist = AccFactory.AllotmentClassesRepository().NameExist(allotmentName, allotmentClassesId);

            if (allotmentNameExist)
            {
                errorProvider1.SetError(txtName, "Allotment class name already exist in your records.");
                return false;
            }
            return true;
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !NameValidated();
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtName);
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtCode, "Allotment class code");

            var allotmentClassesRepository = AccFactory.AllotmentClassesRepository();
            string allotmentCode = txtCode.Text.Trim();
            bool allotmentCodeExist;

            if (allotmentClassesId == 0)
                allotmentCodeExist = allotmentClassesRepository.CodeExist(allotmentCode); // add form
            else
                allotmentCodeExist = allotmentClassesRepository.CodeExist(allotmentCode, allotmentClassesId); // edit form

            if (allotmentCodeExist)
            {
                errorProvider1.SetError(txtCode, "Allotment class code already exist in your records.");
                e.Cancel = true;
            }
        }

        private void txtCode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtCode);
        }
    }
}