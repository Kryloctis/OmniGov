using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.FunctionProgramProject.FunctionProgramProject
{
    public partial class frmFunctionProgramProjectEdit : Form
    {
        private ucFunctionProgramProject uc;
        private frmFunctionProgramProject _frmFunctionProgramProject;

        public frmFunctionProgramProjectEdit(frmFunctionProgramProject frmFunctionProgramProject, byte fppID)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _frmFunctionProgramProject = frmFunctionProgramProject;
            ucFunctionProgramProject1.FppID = fppID;
            uc = ucFunctionProgramProject1;
        }

        private void LoadSelectedRecord()
        {
            try
            {
                var functionProgramProjectRepository = Factory.FunctionProgramProjectRepository();
                Dictionary<string, string> dicfunctionProgramProject = functionProgramProjectRepository.GetRecordByID(uc.FppID);

                uc.cmbFunctionalClassificationService.SelectedValue = dicfunctionProgramProject["functional_classification_services_id"];
                uc.txtCode.Text = dicfunctionProgramProject["fpp_code"];
                uc.txtName.Text = dicfunctionProgramProject["fpp_name"];
                uc.chckboxSpecial.Checked = Convert.ToByte(dicfunctionProgramProject["is_special"]) == 0 ? false : true;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool UpdateData()
        {
            try
            {
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                int functionalClassificationServiceId = Convert.ToInt32(uc.cmbFunctionalClassificationService.SelectedValue);

                var functionProgramProjectModel = new FunctionProgramProjectModel()
                {
                    Id = ucFunctionProgramProject1.FppID,
                    functionalClassificationServiceId = functionalClassificationServiceId,
                    FppName = uc.txtName.Text.Trim(),
                    FppCode = uc.txtCode.Text.Trim(),
                    IsSpecial = uc.chckboxSpecial.Checked ? true : false
                };

                return Factory.FunctionProgramProjectRepository().Update(functionProgramProjectModel);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }

            return false;
        }

        private void frmFunctionProgramProjectEdit_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            ucFunctionProgramProject1.LoadServiceNameComboBox();
            LoadSelectedRecord();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UpdateData())
            {
                Helper.MessageBoxSuccess("Function Program Project has been saved.");
                bool isSpecial = uc.chckboxSpecial.Checked;
                _frmFunctionProgramProject.chckbxSpecial.Checked = isSpecial;
                _frmFunctionProgramProject.LoadFPP();
                Helper.DatagridViewRecordFinder(_frmFunctionProgramProject.dgFunctionalProgramProject, "fpp_code", uc.txtCode.Text);
                Close();
            }
        }
    }
}
