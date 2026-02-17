using LFS.Helpers;
using OmniGov.Core.Entities;
using OmniGov.Core.Repositories;
using OmniGov.Core.Factories;
using System;
using System.Windows.Forms;

namespace LFS.Views.Manage.FunctionProgramProject.FunctionalClassification
{
    public partial class frmFunctionalClassificationAdd : Form
    {
        private frmFunctionProgramProject frmFunctionProgramProject;
        private ucFunctionalClassification uc;

        public frmFunctionalClassificationAdd(frmFunctionProgramProject frmFunctionProgramProject)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucFunctionalClassification1;

            this.frmFunctionProgramProject = frmFunctionProgramProject;
        }

        private bool SaveData()
        {
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

            return Factory.FunctionalClassificationRepository().Insert(functionalClassificationModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Functional Classification has been saved.");
                    frmFunctionProgramProject.LoadFunctionalClassifications();
                    frmFunctionProgramProject.LoadSectorComboBox();
                    Helper.DatagridViewRecordFinder(frmFunctionProgramProject.dgFunctionalClassification, "sector_code", uc.txtCode.Text);
                    uc.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}

