using ACC.Domain.Interfaces;
using System;
using System.Data;
using System.Windows.Forms;


namespace AccountingSystem.Views.Manage.FunctionProgramProject.FunctonalClassificationService
{
    public partial class ucFunctionalClassificationServices : UserControl
    {
        internal byte serviceID = 0;
        public ucFunctionalClassificationServices()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                epSectorName.GetError(cmbSectorName),
            epName.GetError(txtName)
            };

            IError _errors = AccFactory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            LoadSectorNameComboBox();
            txtName.Clear();
        }

        public void LoadSectorNameComboBox()
        {
            try
            {
                DataTable dtSectorName = AccFactory.FunctionalClassificationRepository().GetRecords();
                HelperLoadRecords.SectorNameComboBox(dtSectorName, cmbSectorName, "sector_name", "id");
                byte id = Convert.ToByte(cmbSectorName.SelectedValue);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void cmbSectorName_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void ucFunctonalClassificationServices_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadSectorNameComboBox();
            }
        }

        #region  Validations

        private bool ServicesNameValidated(ErrorProvider errorProvider, TextBox textBox)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox.Text.Trim()))
                {
                    errorProvider.SetError(textBox, Helper.ErrorMessage("Service Name"));
                    return false;
                }

                bool nameExist = serviceID == 0 ? AccFactory.FunctionalClassificationServiceRepository().NameExist(textBox.Text.Trim()) :
                                                  AccFactory.FunctionalClassificationServiceRepository().NameExist(textBox.Text.Trim(), serviceID);
                if (nameExist)
                {
                    errorProvider.SetError(textBox, "Service Name already exist.");
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

        private void cmbSectorName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epSectorName, cmbSectorName, "sector name");
        }

        private void cmbSectorName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epSectorName, cmbSectorName);
        }

        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !ServicesNameValidated(epName, txtName);
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epName, txtName);
        }

        #endregion
    }
}
