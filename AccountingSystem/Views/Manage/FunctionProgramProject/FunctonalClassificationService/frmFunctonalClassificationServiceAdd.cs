using ACC.Domain.Models;
using System;
using System.Windows.Forms;


namespace AccountingSystem.Views.Manage.FunctionProgramProject.FunctonalClassificationService
{
    public partial class frmFunctonalClassificationServiceAdd : Form
    {
        private frmFunctionProgramProject _frmFunctionProgramProject;
        public frmFunctonalClassificationServiceAdd(frmFunctionProgramProject frmFunctionProgramProject)
        {
            InitializeComponent();
            _frmFunctionProgramProject = frmFunctionProgramProject;
        }





        private void frmFunctonalClassificationServiceAdd_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            ucFunctonalClassificationServices1.LoadSectorNameComboBox();
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
                    functionalClassificationId = byte.Parse(uc.txtCode.Text.ToString()),
                    ServiceName = uc.txtName.Text.Trim()
                };

                var functionalClassificationServiceRepository = Factory.FunctionalClassificationServiceRepository();
                return functionalClassificationServiceRepository.Insert(functionalClassificationServiceModel);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }

            return false;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Functional Classification Service has been saved.");
                ucFunctonalClassificationServices1.ResetForm();
                _frmFunctionProgramProject.LoadFunctionClassificationServices();
                _frmFunctionProgramProject.LoadServiceNameComboBox();
            }
        }
    }
}
