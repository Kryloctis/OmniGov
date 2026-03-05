using OmniGov.App.Helpers;

using OmniGov.Core.Factories;

using System.Data;

namespace OmniGov.App.Views.Manage.FunctionProgramProject.FunctionalClassificationService

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
            DataTable dtSectorName = Factory.FunctionalClassificationRepository().GetRecords();

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

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()

        {
            LoadSectorNameComboBox();

            txtName.Clear();
        }

        private void cmbSectorName_Validated(object sender, EventArgs e)

        {
            Helper.ClearErrorComboBox(epSectorName, cmbSectorName);
        }

        private void cmbSectorName_Validating(object sender, System.ComponentModel.CancelEventArgs e)

        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epSectorName, cmbSectorName, "sector name");
        }

        private void OnLoad()

        {
            if (!DesignMode)

            {
                LoadSectorNameComboBox();
            }
        }

        private bool ServicesNameValidated(ErrorProvider errorProvider, TextBox textBox)

        {
            if (string.IsNullOrWhiteSpace(textBox.Text.Trim()))

            {
                errorProvider.SetError(textBox, Helper.ErrorMessage("Service Name"));

                return false;
            }

            bool nameExist = serviceID == 0 ? Factory.FunctionalClassificationServiceRepository().NameExist(textBox.Text.Trim()) :

                                              Factory.FunctionalClassificationServiceRepository().NameExist(textBox.Text.Trim(), serviceID);

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
            e.Cancel = !ServicesNameValidated(epName, txtName);
        }

        private void ucFunctonalClassificationServices_Load(object sender, EventArgs e)

        {
            OnLoad();
        }
    }
}