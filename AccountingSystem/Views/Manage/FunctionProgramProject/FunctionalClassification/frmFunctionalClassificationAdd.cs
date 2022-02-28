using System;
using System.Windows.Forms;
using ACC.Domain.Models;

namespace AccountingSystem.Views.Manage.FunctionProgramProject.FunctionalClassification
{
    public partial class frmFunctionalClassificationAdd : Form
    {
        private frmFunctionProgramProject _frmFunctionProgramProject;
        public frmFunctionalClassificationAdd(frmFunctionProgramProject frmFunctionProgramProject)
        {
            InitializeComponent();
            _frmFunctionProgramProject = frmFunctionProgramProject;
        }


        private bool SaveData()
        {
            try
            {
                var uc = ucFunctionalClassification1;
                // if error occurs, show messagebox error
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                // proceed to insert
                var functionalClassificationModel = new FunctionalClassificationModel()
                {
                    SectorCode = uc.txtCode.Text.Trim(),
                    SectorName = uc.txtName.Text.Trim()
                };

                var functionalClassificationRepository = Factory.FunctionalClassificationRepository();
                return functionalClassificationRepository.Insert(functionalClassificationModel);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }

            return false;
        }

        private void frmFunctionalClassificationAdd_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Functional Classification has been saved.");
                _frmFunctionProgramProject.LoadFunctionalClassificationRecords();
                _frmFunctionProgramProject.LoadSectorComboBox();
                ucFunctionalClassification1.ResetForm();
            }
        }
    }
}
