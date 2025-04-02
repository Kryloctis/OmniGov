using ACC.Data;
using ACC.Domain.Models;
using LFS;
using System;
using System.Windows.Forms;

namespace LFS.Views.Manage.FunctionProgramProject.FunctionalClassification
{
    public partial class frmFunctionalClassificationEdit : Form
    {
        private frmFunctionProgramProject frmFunctionProgramProject;
        private ucFunctionalClassification uc;

        public frmFunctionalClassificationEdit(frmFunctionProgramProject frmFunctionProgramProject, byte functionalClassificationId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucFunctionalClassification1;
            uc.functionalClassificationId = functionalClassificationId;
            this.frmFunctionProgramProject = frmFunctionProgramProject;
        }

        private void LoadSelectedRecord()
        {
            var functionalClassificationData = AccFactory.FunctionalClassificationRepository().GetRecordByID(uc.functionalClassificationId);

            uc.txtCode.Text = functionalClassificationData["sector_code"];
            uc.txtName.Text = functionalClassificationData["sector_name"];
        }

        private bool SaveData()
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

            return AccFactory.FunctionalClassificationRepository().Update(functionalClassificationModel);
        }

        private void frmFunctionalClassificationEdit_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSelectedRecord();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Functional Classification has been saved.");
                    frmFunctionProgramProject.LoadFunctionalClassifications();
                    frmFunctionProgramProject.LoadSectorComboBox();
                    Helper.DatagridViewRecordFinder(frmFunctionProgramProject.dgFunctionalClassification, "sector_code", uc.txtCode.Text);
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}