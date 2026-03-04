using OmniGov.App.Helpers;
using OmniGov.Core.Factories;
using System.ComponentModel;

namespace OmniGov.App.Views.Manage.FunctionProgramProject.OthersFunctionProgramProject
{
    public partial class ucOthersFunctionProgramProject : UserControl
    {
        internal int functionProgramProjectID = 0;
        internal int othersFPPID = 0;

        public ucOthersFunctionProgramProject()
        {
            InitializeComponent();
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
            txtName.Clear();
            txtCode.Clear();
        }

        private bool OthersFPPCodeValidated(ErrorProvider errorProvider, TextBox textBox)
        {
            string othersFPPCode = textBox.Text;
            bool codeExist = othersFPPID == 0 ? Factory.SubFPPRepository().CodeExist(othersFPPCode) : Factory.SubFPPRepository().CodeExist(othersFPPID, othersFPPCode);

            if (Helper.ShowErrorTextBoxEmpty(errorProvider, textBox, "Others FPP Code"))
                return false;
            else if (codeExist)
            {
                errorProvider.SetError(textBox, "Others FPP Code you entered already exist on you record.");
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
            e.Cancel = !OthersFPPCodeValidated(errorProvider1, txtCode);
        }

        private bool OthersFPPNameValidated(ErrorProvider errorProvider, TextBox textBox)
        {
            string name = textBox.Text.Trim();
            bool nameExist = othersFPPID == 0 ? Factory.SubFPPRepository().NameExist(name) : Factory.SubFPPRepository().NameExist(othersFPPID, name);

            if (Helper.ShowErrorTextBoxEmpty(errorProvider, textBox, "Name"))
                return false;
            else if (nameExist)
            {
                errorProvider.SetError(textBox, "Other FPP Name you entered already exist on your record.");
                return false;
            }
            return true;
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtName);
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !OthersFPPNameValidated(errorProvider1, txtName);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}

