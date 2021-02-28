using ACC.Domain.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;


namespace AccountingSystem.Views.Manage.FunctionProgramProject.FunctionalClassification
{
    public partial class ucFunctionalClassification : UserControl
    {
        internal byte functionalClassificationId = 0;
        IFunctionalClassificationRepository _functionalClassificationRepository;
        public ucFunctionalClassification()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[2];
            errorArray[0] = epCode.GetError(txtCode);
            errorArray[1] = epName.GetError(txtName);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtCode.Clear();
            txtName.Clear();
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epCode, txtCode, "code");

            _functionalClassificationRepository = Factory.FunctionalClassificationRepository();
            string functionalClassificationCode = txtCode.Text.Trim();
            bool codeExist;

            if (functionalClassificationId == 0)
                codeExist = _functionalClassificationRepository.CodeExist(functionalClassificationCode);
            else
                codeExist = _functionalClassificationRepository.CodeExist(functionalClassificationCode, functionalClassificationId);

            if (codeExist)
            {
                epCode.SetError(txtCode, $"Code you entered is not allowed. Already exist in your record.");
                e.Cancel = true;
            }
        }

        private void txtCode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epCode, txtCode);
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epName, txtName, "name");

            _functionalClassificationRepository = Factory.FunctionalClassificationRepository();
            string functionalClassificationName = txtName.Text.Trim();
            bool nameExist;

            if (functionalClassificationId == 0)
                nameExist = _functionalClassificationRepository.NameExist(functionalClassificationName);
            else
                nameExist = _functionalClassificationRepository.NameExist(functionalClassificationName, functionalClassificationId);

            if (nameExist)
            {
                epName.SetError(txtName, $"Name you entered is not allowed. Already exist in your record.");
                e.Cancel = true;
            }
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epName, txtName);
        }
    }
}
