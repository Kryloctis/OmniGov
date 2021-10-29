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
            var errorArray = new string[2];
            errorArray[0] = epCode.GetError(txtCode);
            errorArray[1] = epName.GetError(txtName);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            //  cmbSectorName.SelectedIndex = -1;
            // txtCode.Clear();
            txtName.Clear();
        }

        private void txtCode_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epCode, txtCode, "code");
        }


        public void LoadSectorNameComboBox()
        {
            try
            {
                DataTable dtSectorName = Factory.FunctionalClassificationRepository().GetRecords();
                HelperLoadRecords.SectorNameComboBox(dtSectorName, cmbSectorName, "sector_name", "id");
                byte id = Convert.ToByte(cmbSectorName.SelectedValue);
                txtCode.Text = Convert.ToString(id);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }


        }


        private void cmbSectorName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //e.Cancel = Helper.ShowErrorComboBoxEmpty(epSectorName, cmbSectorName, "sector name");

            //int id = Convert.ToByte(cmbSectorName.SelectedValue);
            //bool idExist = Factory.FunctionalClassificationServiceRepository().IdExist(id);

            //if (!idExist)
            //{
            //    epSectorName.SetError(cmbSectorName, "Invalid  sector name. Please select on the list.");
            //    e.Cancel = true;
            //}

        }
        private void cmbSectorName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epSectorName, cmbSectorName);

        }

        private void txtCode_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epCode, txtName);
        }


        private void txtName_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epName, txtName);
        }


        private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epName, txtName, "name");
        }


        private void cmbSectorName_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void cmbSectorName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                byte id = Convert.ToByte(cmbSectorName.SelectedValue);
                txtCode.Text = Convert.ToString(id);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
