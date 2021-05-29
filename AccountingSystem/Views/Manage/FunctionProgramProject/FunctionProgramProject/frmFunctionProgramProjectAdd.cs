using System;
using System.Windows.Forms;
using ACC.Domain.Models;

namespace AccountingSystem.Views.Manage.FunctionProgramProject.FunctionProgramProject
{
    public partial class frmFunctionProgramProjectAdd : Form
    {
        private ucFunctionProgramProject uc;
        private frmFunctionProgramProject _frmFunctionProgramProject;
        public frmFunctionProgramProjectAdd(frmFunctionProgramProject frmFunctionProgramProject)
        {
            InitializeComponent();
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
                var uc = ucFunctionProgramProject1;
                // if error occurs, show messagebox error
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                // proceed to insert
                var functionProgramProjectModel = new FunctionProgramProjectModel()
                {
                    functionalClassificationServiceId = byte.Parse(uc.txtServiceId.Text.ToString()),
                    FppName = uc.txtName.Text.Trim(),
                    FppCode = uc.txtCode.Text.Trim()
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
                _frmFunctionProgramProject.cmbServiceName.SelectedValue = 0;
            }
        }
    }
}
