using LFS.Helpers;
using OmniGov.Core.Entities;
using OmniGov.Core.Repositories;
using System;
using System.Windows.Forms;

namespace LFS.Views.Manage.FunctionProgramProject.FunctionProgramProject
{
    public partial class frmFunctionProgramProjectAdd : Form
    {
        private ucFunctionProgramProject uc;
        private frmFunctionProgramProject _frmFunctionProgramProject;

        public frmFunctionProgramProjectAdd(frmFunctionProgramProject frmFunctionProgramProject)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _frmFunctionProgramProject = frmFunctionProgramProject;
            uc = ucFunctionProgramProject1;
        }

        private void frmFunctionProgramProjectAdd_Load(object sender, EventArgs e)
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
        }

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            int functionalClassificationServiceId = Convert.ToInt32(uc.cmbFunctionalClassificationService.SelectedValue);
            var functionProgramProjectModel = new FunctionProgramProjectModel()
            {
                functionalClassificationServiceId = functionalClassificationServiceId,
                FppName = uc.txtName.Text.Trim(),
                FppCode = uc.txtCode.Text.Trim(),
                IsSpecial = uc.chckboxSpecial.Checked ? true : false
            };

            return Factory.FunctionProgramProjectRepository().Insert(functionProgramProjectModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Function Program Project has been saved.");
                    _frmFunctionProgramProject.LoadFPP();
                    Helper.DatagridViewRecordFinder(_frmFunctionProgramProject.dgFunctionalProgramProject, "fpp_code", uc.txtCode.Text);
                    uc.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}