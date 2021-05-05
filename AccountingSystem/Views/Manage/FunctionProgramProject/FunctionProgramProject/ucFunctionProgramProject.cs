using System;
using System.Data;
using ACC.Domain.Interfaces;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.FunctionProgramProject.FunctionProgramProject
{
    public partial class ucFunctionProgramProject : UserControl
    {
        internal byte FppID = 0;
        IFunctionProgramProjectRepository _functionProgramProjectRepository;
        public ucFunctionProgramProject()
        {
            InitializeComponent();
        }

      

        internal string GetFormErrors()
        {
            var errorArray = new string[3];
            errorArray[0] = epCode.GetError(txtCode);
            errorArray[1] = epName.GetError(txtName);
            errorArray[2] = epName.GetError(txtServiceId);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            //  cmbSectorName.SelectedIndex = -1;
            txtCode.Clear();
            txtName.Clear();
        }

        private void cmbServiceName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epServiceName, cmbServiceName);
        }

        private void txtCode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epCode, txtCode);
        }

        private void txtCode_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epCode, txtCode, "code");
        }

        public void LoadServiceNameComboBox()
        {           

            try
            {
                DataTable dtServiceName = Factory.FunctionalClassificationServiceRepository().GetRecords();
                HelperLoadRecords.ServicesNameComboBox(dtServiceName, cmbServiceName, "service_name", "id");
                byte id = Convert.ToByte(cmbServiceName.SelectedValue);
                txtServiceId.Text = Convert.ToString(id);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epName, txtName);
        }

        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epName, txtName, "name");
        }

        private void txtServiceId_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epServiceId, txtServiceId);
        }

        private void txtServiceId_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epServiceId, txtServiceId, "code");
        }

        private void ucFunctionProgramProject_Load(object sender, EventArgs e)
        {

        }

        private void cmbServiceName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                byte id = Convert.ToByte(cmbServiceName.SelectedValue);
                txtServiceId.Text = Convert.ToString(id);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }
    }
}
