using OmniGov.App.Helpers;
using OmniGov.Core.Factories;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace OmniGov.App.Views.Manage.FunctionProgramProject.FunctionalClassification
{
    public partial class ucFunctionalClassification : UserControl
    {
        internal byte functionalClassificationId = 0;

        public ucFunctionalClassification()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                epCode.GetError(txtCode),
                epName.GetError(txtName)
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtCode.Clear();
            txtName.Clear();
        }

        private void txtCode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epCode, txtCode);
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(epCode, txtCode, "code");

                string functionalClassificationCode = txtCode.Text.Trim();
                bool codeExist;

                if (functionalClassificationId == 0)
                    codeExist = Factory.FunctionalClassificationRepository().CodeExist(functionalClassificationCode);
                else
                    codeExist = Factory.FunctionalClassificationRepository().CodeExist(functionalClassificationCode, functionalClassificationId);

                if (codeExist)
                {
                    epCode.SetError(txtCode, $"Code you entered is not allowed. Already exist in your record.");
                    e.Cancel = true;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epName, txtName);
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(epName, txtName, "name");

                string functionalClassificationName = txtName.Text.Trim();
                bool nameExist;

                if (functionalClassificationId == 0)
                    nameExist = Factory.FunctionalClassificationRepository().NameExist(functionalClassificationName);
                else
                    nameExist = Factory.FunctionalClassificationRepository().NameExist(functionalClassificationName, functionalClassificationId);

                if (nameExist)
                {
                    epName.SetError(txtName, $"Name you entered is not allowed. Already exist in your record.");
                    e.Cancel = true;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}

