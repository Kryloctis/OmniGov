using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.FunctionProgramProject.FunctionalClassification
{
    public partial class frmFunctionalClassificationEdit : Form
    {
        private frmFunctionProgramProject _frmFunctionProgramProject;
        ucFunctionalClassification uc;

        public frmFunctionalClassificationEdit(frmFunctionProgramProject frmFunctionProgramProject, byte functionalClassificationId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _frmFunctionProgramProject = frmFunctionProgramProject;
            uc = ucFunctionalClassification1;
            uc.functionalClassificationId = functionalClassificationId;
        }

        private void LoadSelectedRecord()
        {
            try
            {
                var functionalClassificationRepository = AccFactory.FunctionalClassificationRepository();
                var functionalClassificationData = functionalClassificationRepository.GetRecordByID(uc.functionalClassificationId);

                uc.txtCode.Text = functionalClassificationData["sector_code"];
                uc.txtName.Text = functionalClassificationData["sector_name"];

            }
            catch (Exception ex)
            {

                Helper.MessageBoxError(ex.Message);
            }
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

                var functionalClassificationModel = new FunctionalClassificationModel()
                {
                    Id = uc.functionalClassificationId,
                    SectorCode = uc.txtCode.Text.Trim(),
                    SectorName = uc.txtName.Text.Trim()
                };

                var functionalClassificationRepository = AccFactory.FunctionalClassificationRepository();
                return functionalClassificationRepository.Update(functionalClassificationModel);

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return false;
        }

        private void frmFunctionalClassificationEdit_Load(object sender, EventArgs e)
        {
            LoadSelectedRecord();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Functional Classification has been saved.");
                _frmFunctionProgramProject.LoadFunctionalClassifications();
                _frmFunctionProgramProject.LoadSectorComboBox();
                Helper.DatagridViewRecordFinder(_frmFunctionProgramProject.dgFunctionalClassification, "sector_code", uc.txtCode.Text);
                Close();
            }
        }
    }
}
