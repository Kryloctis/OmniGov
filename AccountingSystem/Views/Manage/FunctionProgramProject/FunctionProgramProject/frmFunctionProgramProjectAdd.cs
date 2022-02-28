using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.FunctionProgramProject.FunctionProgramProject
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
            Helper.LoadFormIcon(this);
            ucFunctionProgramProject1.LoadServiceNameComboBox();

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

                int functionalClassificationServiceId = Convert.ToInt32(uc.cmbFunctionalClassificationService.SelectedValue);

                var functionProgramProjectModel = new FunctionProgramProjectModel()
                {
                    functionalClassificationServiceId = functionalClassificationServiceId,
                    FppName = uc.txtName.Text.Trim(),
                    FppCode = uc.txtCode.Text.Trim(),
                    IsSpecial = uc.chckboxSpecial.Checked ? true : false
                };

                var functionProgramProjectRepository = Factory.FunctionProgramProjectRepository();
                return functionProgramProjectRepository.Insert(functionProgramProjectModel);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }

            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Function Program Project has been saved.");
                ucFunctionProgramProject1.ResetForm();
                int serviceId = Convert.ToInt32(uc.cmbFunctionalClassificationService.SelectedValue);
                _frmFunctionProgramProject.cmbServiceName.SelectedValue = serviceId;
                _frmFunctionProgramProject.LoadFPP();
            }
        }
    }
}
