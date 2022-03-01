using ACC.Domain.Interfaces;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.FunctionProgramProject.FunctionProgramProject
{
    public partial class ucFunctionProgramProject : UserControl
    {
        internal byte FppID = 0;
        public ucFunctionProgramProject()
        {
            InitializeComponent();
        }


        internal string GetFormErrors()
        {
            var errorArray = new string[3];
            errorArray[0] = epCode.GetError(txtCode);
            errorArray[1] = epName.GetError(txtName);
            errorArray[2] = epServiceName.GetError(cmbFunctionalClassificationService);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            //  cmbSectorName.SelectedIndex = -1;
            txtCode.Clear();
            txtName.Clear();
        }

        private void cmbFunctionalClassificationService_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epServiceName, cmbFunctionalClassificationService, "Functional Classification Service");
        }

        private void cmbFunctionalClassificationService_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epServiceName, cmbFunctionalClassificationService);
        }

        public void LoadServiceNameComboBox()
        {
            try
            {
                DataTable dtServiceName = new DataTable();

                dtServiceName.Columns.Add("id");
                dtServiceName.Columns.Add("service_name");

                foreach (DataRow item in Factory.FunctionalClassificationServiceRepository().GetViewRecords().Rows)
                {
                    string serviceName = $"{item["functional_classifications_sector_code"]} - {item["service_name"]}";

                    var items = new object[]
                    {
                       item["id"],
                       serviceName
                    };

                    dtServiceName.Rows.Add(items);
                };

                HelperLoadRecords.ServicesNameComboBox(dtServiceName, cmbFunctionalClassificationService, "service_name", "id");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void ucFunctionProgramProject_Load(object sender, EventArgs e)
        {

        }

        private void cmbServiceName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                byte id = Convert.ToByte(cmbFunctionalClassificationService.SelectedValue);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        #region Validations

        private bool CodeValidated(ErrorProvider errorProvider, TextBox textBox)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox.Text.Trim()))
                {
                    errorProvider.SetError(textBox, Helper.ErrorMessage("Code"));
                    return false;
                }

                bool codeExist = FppID == 0 ? Factory.FunctionProgramProjectRepository().CodeExist(textBox.Text.Trim()) :
                                              Factory.FunctionProgramProjectRepository().CodeExist(textBox.Text.Trim(), FppID);

                if (codeExist)
                {
                    errorProvider.SetError(textBox, "Code already exist.");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool NameValidated(ErrorProvider errorProvider)
        {
            try
            {
                int serviceId = Convert.ToInt32(cmbFunctionalClassificationService.SelectedValue);
                string fppName = txtName.Text.Trim();

                if (string.IsNullOrWhiteSpace(fppName))
                {
                    errorProvider.SetError(txtName, Helper.ErrorMessage("Name"));
                    return false;
                }

                bool nameExist = FppID == 0 ? Factory.FunctionProgramProjectRepository().NameExist(fppName, serviceId) :
                                              Factory.FunctionProgramProjectRepository().NameExist(fppName, serviceId, FppID);

                if (nameExist)
                {
                    errorProvider.SetError(txtName, "Name already exist.");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void txtCode_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !CodeValidated(epCode, txtCode);
        }

        private void txtCode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epCode, txtCode);
        }

        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !NameValidated(epName);
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epName, txtName);
        }

        #endregion

    }
}
