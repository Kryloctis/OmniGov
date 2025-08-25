using ACC.Data;
using ACC.Domain.Models;
using LFS.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LFS.Views.Manage.FunctionProgramProject.FunctionProgramProject
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
            uc = ucFunctionProgramProject1;
            uc.fppId = fppID;
        }

        private void LoadSelectedRecord()
        {
            Dictionary<string, string> dicfunctionProgramProject = AccFactory.FunctionProgramProjectRepository().GetRecordByID(uc.fppId);
            uc.cmbFunctionalClassificationService.SelectedValue = dicfunctionProgramProject["functional_classification_services_id"];
            uc.txtCode.Text = dicfunctionProgramProject["fpp_code"];
            uc.txtName.Text = dicfunctionProgramProject["fpp_name"];
            uc.chckboxSpecial.Checked = Convert.ToByte(dicfunctionProgramProject["is_special"]) == 0 ? false : true;
        }

        private bool UpdateData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            int functionalClassificationServiceId = Convert.ToInt32(uc.cmbFunctionalClassificationService.SelectedValue);

            var functionProgramProjectModel = new FunctionProgramProjectModel()
            {
                Id = ucFunctionProgramProject1.fppId,
                functionalClassificationServiceId = functionalClassificationServiceId,
                FppName = uc.txtName.Text.Trim(),
                FppCode = uc.txtCode.Text.Trim(),
                IsSpecial = uc.chckboxSpecial.Checked ? true : false
            };

            return AccFactory.FunctionProgramProjectRepository().Update(functionProgramProjectModel);
        }

        private void frmFunctionProgramProjectEdit_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            ucFunctionProgramProject1.LoadServiceNameComboBox();
            LoadSelectedRecord();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}