using OmniGov.App.Helpers;

using OmniGov.Core.Entities;

using OmniGov.Core.Factories;

namespace OmniGov.App.Views.Manage.FunctionProgramProject.FunctionalClassificationService

{
    public partial class frmFunctionalClassificationServiceAdd : Form

    {
        private frmFunctionProgramProject _frmFunctionProgramProject;

        private ucFunctionalClassificationServices uc;

        public frmFunctionalClassificationServiceAdd(frmFunctionProgramProject frmFunctionProgramProject)

        {
            InitializeComponent();

            Helper.LoadFormIcon(this);

            uc = ucFunctonalClassificationServices1;

            _frmFunctionProgramProject = frmFunctionProgramProject;
        }

        private void btnSave_Click(object sender, EventArgs e)

        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Functional Classification Service has been saved.");
                _frmFunctionProgramProject.LoadServiceNameComboBox();
                _frmFunctionProgramProject.LoadFunctionClassificationServices();
                Helper.DatagridViewRecordFinder(_frmFunctionProgramProject.dgFuntionalClassificationServices, "service_name", uc.txtName.Text);
                uc.ResetForm();
            }
        }

        private bool SaveData()

        {
            // if error occurs, show messagebox error

            if (!uc.ValidateChildren())

            {
                Helper.MessageBoxError(uc.GetFormErrors());

                return false;
            }

            // proceed to insert

            int functionClassificationsId = Convert.ToInt32(uc.cmbSectorName.SelectedValue);

            string serviceName = uc.txtName.Text.Trim();

            var functionalClassificationServiceModel = new FunctionalClassificationServiceModel()

            {
                functionalClassificationId = functionClassificationsId,

                ServiceName = serviceName
            };

            return Factory.FunctionalClassificationServiceRepository().Insert(functionalClassificationServiceModel);
        }
    }
}