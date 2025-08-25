using ACC.Data;
using ACC.Domain.Models;
using LFS.Helpers;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LFS.Views.Manage.AllotmentClasses
{
    public partial class ucAllotmentClasses : UserControl
    {
        private int allotmentClassId;
        private bool isEdit;

        private void LoadSelectedRecord()
        {
            var allotmentData = AccFactory.AllotmentClassesRepository().GetRecordByID(allotmentClassId);
            txtName.Text = allotmentData["allotment_name"];
            txtCode.Text = allotmentData["allotment_code"];
        }

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

        internal void OnLoad(bool isEdit, int? allotmentClassId)
        {
            this.isEdit = isEdit;

            if (isEdit)
            {
                this.allotmentClassId = allotmentClassId.Value;
                LoadSelectedRecord();
            }
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
            if (Helper.ShowErrorTextBoxEmpty(errorProvider1, txtName, "Name"))
                return false;

            string allotmentName = txtName.Text.Trim();
            bool allotmentNameExist = isEdit ? AccFactory.AllotmentClassesRepository().NameExist(allotmentName, allotmentClassId) : AccFactory.AllotmentClassesRepository().NameExist(allotmentName);

            if (allotmentNameExist)
            {
                errorProvider1.SetError(txtName, "Name already exist.");
                return false;
            }

            return true;
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !NameValidated();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtName);
        }

        private bool CodeValidated()
        {
            if (Helper.ShowErrorTextBoxEmpty(errorProvider1, txtCode, "Allotment class code"))
                return false;

            string allotmentCode = txtCode.Text.Trim();
            bool allotmentCodeExist = isEdit ? AccFactory.AllotmentClassesRepository().CodeExist(allotmentCode, allotmentClassId) : AccFactory.AllotmentClassesRepository().CodeExist(allotmentCode);

            if (allotmentCodeExist)
            {
                errorProvider1.SetError(txtCode, "Code already exist.");
                return false;
            }

            return true;
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !CodeValidated();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtCode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtCode);
        }
    }
}