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
            var errorArray = new string[1];
            errorArray[0] = epName.GetError(txtName);

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm() 
        {
            txtName.Clear();
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epName, txtName, "Name");

            string name = txtName.Text.Trim();
            bool nameExist;

            if (othersFPPID == 0) 
            {
                nameExist = Factory.OthersFPPRepository().NameExist(name);
            }
            else
            {
                nameExist = Factory.OthersFPPRepository().NameExist(othersFPPID, name);
            }

            if (nameExist) 
            {
                epName.SetError(txtName, "Name you entered is not allowed. Already exist on your record.");
                e.Cancel = true;
            }
            
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epName, txtName);
        }
    }
}
