using ACC.Data;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Manage.FunctionProgramProject.FunctionProgramProject
{
    public partial class ucFunctionProgramProject : UserControl
    {
        internal byte fppId = 0;

        public ucFunctionProgramProject()
        {
            InitializeComponent();
        }

        public void LoadServiceNameComboBox()
        {
            DataTable dtServiceName = new DataTable();

            dtServiceName.Columns.Add("id");
            dtServiceName.Columns.Add("service_name");

            foreach (DataRow item in AccFactory.FunctionalClassificationServiceRepository().GetViewRecords().Rows)
            {
                string serviceName = $"{item["functional_classifications_sector_code"]} - {item["service_name"]}";

                var items = new object[]
                {
                       item["id"],
                       serviceName
                };

                dtServiceName.Rows.Add(items);
            }
            ;

            HelperLoadRecords.ServicesNameComboBox(dtServiceName, cmbFunctionalClassificationService, "service_name", "id");
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                epCode.GetError(txtCode),
                epName.GetError(txtName),
                epServiceName.GetError(cmbFunctionalClassificationService)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            //  cmbSectorName.SelectedIndex = -1;
            txtCode.Clear();
            txtName.Clear();
        }

        private void cmbFunctionalClassificationService_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epServiceName, cmbFunctionalClassificationService);
        }

        private void cmbFunctionalClassificationService_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epServiceName, cmbFunctionalClassificationService, "Functional Classification Service");
        }

        private void cmbServiceName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                byte id = Convert.ToByte(cmbFunctionalClassificationService.SelectedValue);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool CodeValidated(ErrorProvider errorProvider, TextBox textBox)
        {
            bool codeExist = fppId == 0 ? AccFactory.FunctionProgramProjectRepository().CodeExist(textBox.Text.Trim()) : AccFactory.FunctionProgramProjectRepository().CodeExist(textBox.Text.Trim(), fppId);

            if (Helper.ShowErrorTextBoxEmpty(errorProvider, textBox, "Code"))
                return false;
            else if (codeExist)
            {
                errorProvider.SetError(textBox, "Code already exist.");
                return false;
            }
            return true;
        }

        private void txtCode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epCode, txtCode);
        }

        private void txtCode_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !CodeValidated(epCode, txtCode);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool NameValidated(ErrorProvider errorProvider, TextBox textBox)
        {
            int serviceId = Convert.ToInt32(cmbFunctionalClassificationService.SelectedValue);
            string fppName = txtName.Text.Trim();
            bool nameExist = fppId == 0 ? AccFactory.FunctionProgramProjectRepository().NameExist(fppName, serviceId) : AccFactory.FunctionProgramProjectRepository().NameExist(fppName, serviceId, fppId);

            if (Helper.ShowErrorTextBoxEmpty(errorProvider, textBox, "Name"))
                return false;
            else if (nameExist)
            {
                errorProvider.SetError(txtName, "Name already exist.");
                return false;
            }
            return true;
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epName, txtName);
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !NameValidated(epName, txtName);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ucFunctionProgramProject_Load(object sender, EventArgs e)
        {
        }
    }
}