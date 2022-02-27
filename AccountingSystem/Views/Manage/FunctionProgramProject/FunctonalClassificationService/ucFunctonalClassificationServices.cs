using ACC.Domain.Interfaces;
using System;
using System.Data;
using System.Windows.Forms;


namespace AccountingSystem.Views.Manage.FunctionProgramProject.FunctonalClassificationService
{
    public partial class ucFunctonalClassificationServices : UserControl
    {
        internal byte serviceID = 0;
        public ucFunctonalClassificationServices()
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

            IError _errors = Factory.CreateErrors(errorArray);
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
                DataTable dtSectorName = Factory.FunctionalClassificationRepository().GetRecords();
                HelperLoadRecords.SectorNameComboBox(dtSectorName, cmbSectorName, "sector_name", "id");
                byte id = Convert.ToByte(cmbSectorName.SelectedValue);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
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
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epName, txtName, "name");
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epName, txtName);
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
    }
}
