using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.FunctionProgramProject.FunctonalClassificationService
{
    public partial class frmFunctonalClassificationServiceEdit : Form
    {
        private frmFunctionProgramProject _frmFunctionProgramProject;
        public string AllotmentName;
        public frmFunctonalClassificationServiceEdit(frmFunctionProgramProject frmFunctionProgramProject, byte serviceID)
        {
            InitializeComponent();
            _frmFunctionProgramProject = frmFunctionProgramProject;
            ucFunctonalClassificationServices1.serviceID = serviceID;

        }

        private void LoadSelectedRecord()
        {
            try
            {
                var uc = ucFunctonalClassificationServices1;
                var functionalClassificationServiceRepository = Factory.FunctionalClassificationServiceRepository();
                Dictionary<string, string> data = functionalClassificationServiceRepository.GetRecordByID(uc.serviceID);

                uc.cmbSectorName.SelectedValue = data["functional_classifications_id"];
                uc.txtName.Text = data["service_name"];
                uc.txtCode.Text = data["functional_classifications_id"];
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool SaveData()
        {
            try
            {
                var uc = ucFunctonalClassificationServices1;
                // if error occurs, show messagebox error
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                // proceed to insert
                var functionalClassificationServiceModel = new FunctionalClassificationServiceModel()
                {
                    Id = ucFunctonalClassificationServices1.serviceID,
                    functionalClassificationId = byte.Parse(uc.cmbSectorName.SelectedValue.ToString()),
                    ServiceName = uc.txtName.Text.Trim(),
                    //  MajorAccountGroupName = uc.txtName.Text.Trim()
                };

                return Factory.FunctionalClassificationServiceRepository().Update(functionalClassificationServiceModel);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }

            return false;
        }

        private void frmFunctonalClassificationServiceEdit_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            ucFunctonalClassificationServices1.LoadSectorNameComboBox();
            LoadSelectedRecord();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Functional Classification Services has been saved.");
                _frmFunctionProgramProject.LoadFunctionClassificationServices();
                _frmFunctionProgramProject.LoadServiceNameComboBox();

            }
        }
    }
}
