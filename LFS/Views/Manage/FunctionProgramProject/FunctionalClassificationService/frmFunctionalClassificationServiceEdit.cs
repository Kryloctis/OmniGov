using LFS.Helpers;
using OmniGov.Core.Entities;
using OmniGov.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LFS.Views.Manage.FunctionProgramProject.FunctonalClassificationService
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
            Dictionary<string, string> data = Factory.FunctionalClassificationServiceRepository().GetRecordByID(uc.serviceID);

            uc.cmbSectorName.SelectedValue = data["functional_classifications_id"];
            uc.txtName.Text = data["service_name"];
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

        private void frmFunctonalClassificationServiceEdit_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            LoadSelectedRecord();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}