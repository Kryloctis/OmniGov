using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.FunctionProgramProject.OthersFunctionProgramProject
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
            var errorArray = new string[2];
            errorArray[0] = epCode.GetError(txtCode);
            errorArray[1] = epName.GetError(txtName);

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm() 
        {
            txtName.Clear();
            txtCode.Clear();
        }

        private bool OthersFPPNameExsit() 
        {
            try
            {
                string name = txtName.Text.Trim();
                bool nameExist;

                if (othersFPPID == 0)
                    nameExist = Factory.OthersFPPRepository().NameExist(name);
                else
                    nameExist = Factory.OthersFPPRepository().NameExist(othersFPPID, name);

                if (nameExist)
                {
                    epName.SetError(txtName, "Other FPP Name you entered already exist on your record.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }


        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
                e.Cancel = Helper.ShowErrorTextBoxEmpty(epName, txtName, "Name");
            else if (OthersFPPNameExsit())
                e.Cancel = OthersFPPNameExsit();
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epName, txtName);
        }


        private bool OthersFPPCodeExist() 
        {
            try
            {
                string othersFPPCode = txtCode.Text;
                bool codeExist;

                if (othersFPPID == 0)
                    codeExist = Factory.OthersFPPRepository().CodeExist(othersFPPCode);
                else
                    codeExist = Factory.OthersFPPRepository().CodeExist(othersFPPID, othersFPPCode);

                if (codeExist)
                {
                    epCode.SetError(txtCode, "Others FPP Code you entered already exist on you record.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text))
                e.Cancel = Helper.ShowErrorTextBoxEmpty(epCode, txtCode, "Others FPP Code");
            else if (OthersFPPCodeExist())
                e.Cancel = OthersFPPCodeExist();
            
        }

        private void txtCode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epCode, txtCode);
        }
    }
}
