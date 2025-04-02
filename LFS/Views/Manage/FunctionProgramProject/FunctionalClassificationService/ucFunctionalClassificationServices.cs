using ACC.Data;
using LFS;
using System;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Manage.FunctionProgramProject.FunctonalClassificationService
{
    public partial class ucFunctionalClassificationServices : UserControl
    {
        internal byte serviceID = 0;

        public ucFunctionalClassificationServices()
        {
            InitializeComponent();
        }

        public void LoadSectorNameComboBox()
        {
            DataTable dtSectorName = AccFactory.FunctionalClassificationRepository().GetRecords();
            HelperLoadRecords.SectorNameComboBox(dtSectorName, cmbSectorName, "sector_name", "id");
            byte id = Convert.ToByte(cmbSectorName.SelectedValue);
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                epSectorName.GetError(cmbSectorName),
                epName.GetError(txtName)
            };
            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            LoadSectorNameComboBox();
            txtName.Clear();
        }

        private void ucFunctonalClassificationServices_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            if (!DesignMode)
            {
                LoadSectorNameComboBox();
            }
        }

        private void cmbSectorName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epSectorName, cmbSectorName);
        }

        private void cmbSectorName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epSectorName, cmbSectorName, "sector name");
        }

        private bool ServicesNameValidated(ErrorProvider errorProvider, TextBox textBox)
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

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epName, txtName);
        }

        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                e.Cancel = !ServicesNameValidated(epName, txtName);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}