using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.FunctionProgramProject.FunctonalClassificationService
{
    public partial class frmFunctionalClassificationServiceEdit : Form
    {
        private frmFunctionProgramProject _frmFunctionProgramProject;
        public string AllotmentName;
        internal ucFunctionalClassificationServices uc;

        public frmFunctionalClassificationServiceEdit(frmFunctionProgramProject frmFunctionProgramProject, byte serviceID)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucFunctonalClassificationServices1;
            _frmFunctionProgramProject = frmFunctionProgramProject;
            ucFunctonalClassificationServices1.serviceID = serviceID;

        }

        private void LoadSelectedRecord()
        {
            try
            {
                var functionalClassificationServiceRepository = Factory.FunctionalClassificationServiceRepository();
                Dictionary<string, string> data = functionalClassificationServiceRepository.GetRecordByID(uc.serviceID);

                uc.cmbSectorName.SelectedValue = data["functional_classifications_id"];
                uc.txtName.Text = data["service_name"];
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool SaveData()
        {
            try
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
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }

            return false;
        }

        private void frmFunctonalClassificationServiceEdit_Load(object sender, EventArgs e)
        {
            LoadSelectedRecord();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Functional Classification Services has been updated.");
                _frmFunctionProgramProject.LoadFunctionClassificationServices();
                _frmFunctionProgramProject.LoadServiceNameComboBox();

            }
        }
    }
}
