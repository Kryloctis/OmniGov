using OmniGov.App.Helpers;

using OmniGov.Core.Entities;

using OmniGov.Core.Factories;

namespace OmniGov.App.Views.Manage.FunctionProgramProject.FunctionalClassificationService

{
    public partial class frmFunctionalClassificationServiceEdit : Form

    {
        public string AllotmentName;
        internal ucFunctionalClassificationServices uc;
        private frmFunctionProgramProject _frmFunctionProgramProject;

        public frmFunctionalClassificationServiceEdit(frmFunctionProgramProject frmFunctionProgramProject, byte serviceID)

        {
            InitializeComponent();

            Helper.LoadFormIcon(this);

            uc = ucFunctonalClassificationServices1;

            _frmFunctionProgramProject = frmFunctionProgramProject;

            ucFunctonalClassificationServices1.serviceID = serviceID;
        }

        private void btnSave_Click(object sender, EventArgs e)

        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Functional Classification Services has been updated.");
                _frmFunctionProgramProject.LoadServiceNameComboBox();
                _frmFunctionProgramProject.LoadFunctionClassificationServices();
                Helper.DatagridViewRecordFinder(_frmFunctionProgramProject.dgFuntionalClassificationServices, "service_name", uc.txtName.Text);
                Close();
            }
        }

        private void frmFunctonalClassificationServiceEdit_Load(object sender, EventArgs e)

        {
            OnLoad();
        }

        private void LoadSelectedRecord()

        {
            Dictionary<string, string> data = Factory.FunctionalClassificationServiceRepository().GetRecordByID(uc.serviceID);

            uc.cmbSectorName.SelectedValue = data["functional_classifications_id"];

            uc.txtName.Text = data["service_name"];
        }

        private void OnLoad()

        {
            LoadSelectedRecord();
        }

        private bool SaveData()

        {
            if (!uc.ValidateChildren())

            {
                Helper.MessageBoxError(uc.GetFormErrors());

                return false;
            }

            // proceed to insert

            int functionClassificationId = Convert.ToInt32(uc.cmbSectorName.SelectedValue);

            string serviceName = uc.txtName.Text.Trim();

            var functionalClassificationServiceModel = new FunctionalClassificationServiceModel()

            {
                Id = uc.serviceID,

                functionalClassificationId = functionClassificationId,

                ServiceName = serviceName,
            };

            return Factory.FunctionalClassificationServiceRepository().Update(functionalClassificationServiceModel);
        }
    }
}