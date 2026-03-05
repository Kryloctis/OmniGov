using OmniGov.App.Helpers;

using OmniGov.Core.Entities;

using OmniGov.Core.Factories;

namespace OmniGov.App.Views.Manage.FunctionProgramProject.OthersFunctionProgramProject

{
    public partial class frmOthersFunctionProgramProjectEdit : Form

    {
        private frmOthersFunctionProgramProject _frmOthersFunctionProgramProject;

        private ucOthersFunctionProgramProject uc;

        public frmOthersFunctionProgramProjectEdit(frmOthersFunctionProgramProject frmOthersFunctionProgramProject)

        {
            InitializeComponent();

            uc = ucOthersFunctionProgramProject1;

            _frmOthersFunctionProgramProject = frmOthersFunctionProgramProject;
        }

        private void btnSave_Click(object sender, EventArgs e)

        {
            if (UpdateData())
            {
                _frmOthersFunctionProgramProject.LoadRecords();
                Helper.MessageBoxSuccess("Update has been saved.");
                Close();
            }
        }

        private void frmOthersFunctionProgramProjectEdit_Load(object sender, EventArgs e)

        {
            OnLoad();
        }

        private void LoadSelected()

        {
            var dicOthersFPPRecord = Factory.SubFPPRepository().GetRecordByID(uc.othersFPPID);

            uc.txtCode.Text = dicOthersFPPRecord["others_fpp_code"];

            uc.txtName.Text = dicOthersFPPRecord["name"];
        }

        private void OnLoad()

        {
            LoadSelected();
        }

        private bool UpdateData()

        {
            if (!uc.ValidateChildren())

            {
                Helper.MessageBoxError(uc.GetFormErrors());

                return false;
            }

            var othersFPPModel = new SubFPPModel()

            {
                Id = uc.othersFPPID,

                othersFPPCode = uc.txtCode.Text.Trim(),

                othersFPPName = uc.txtName.Text.Trim()
            };

            return Factory.SubFPPRepository().Update(othersFPPModel);
        }
    }
}