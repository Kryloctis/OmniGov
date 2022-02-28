using ACC.Domain.Models;
using System;
using System.Windows.Forms;


namespace AccountingSystem.Views.Manage.FunctionProgramProject.FunctonalClassificationService
{
    public partial class frmFunctionalClassificationServiceAdd : Form
    {
        private frmFunctionProgramProject _frmFunctionProgramProject;

        private ucFunctionalClassificationServices uc;

        public frmFunctionalClassificationServiceAdd(frmFunctionProgramProject frmFunctionProgramProject)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucFunctonalClassificationServices1;
            _frmFunctionProgramProject = frmFunctionProgramProject;
        }

        private bool SaveData()
        {
            try
            {
                // if error occurs, show messagebox error
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                // proceed to insert
                int functionClassificationsId = Convert.ToInt32(uc.cmbSectorName.SelectedValue);
                string serviceName = uc.txtName.Text.Trim();

                var functionalClassificationServiceModel = new FunctionalClassificationServiceModel()
                {
                    functionalClassificationId = functionClassificationsId,
                    ServiceName = serviceName
                };

                return Factory.FunctionalClassificationServiceRepository().Insert(functionalClassificationServiceModel);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }

            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Functional Classification Service has been saved.");
                uc.ResetForm();
                _frmFunctionProgramProject.LoadFunctionClassificationServices();
                _frmFunctionProgramProject.LoadServiceNameComboBox();
            }
        }
    }
}
