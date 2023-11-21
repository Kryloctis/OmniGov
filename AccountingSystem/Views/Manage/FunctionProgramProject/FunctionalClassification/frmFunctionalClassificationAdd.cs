using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.FunctionProgramProject.FunctionalClassification
{
    public partial class frmFunctionalClassificationAdd : Form
    {
        private frmFunctionProgramProject _frmFunctionProgramProject;
        private ucFunctionalClassification uc;

        public frmFunctionalClassificationAdd(frmFunctionProgramProject frmFunctionProgramProject)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _frmFunctionProgramProject = frmFunctionProgramProject;
            uc = ucFunctionalClassification1;
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

            return AccFactory.FunctionalClassificationRepository().Insert(functionalClassificationModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Functional Classification has been saved.");
                    _frmFunctionProgramProject.LoadFunctionalClassifications();
                    _frmFunctionProgramProject.LoadSectorComboBox();
                    Helper.DatagridViewRecordFinder(_frmFunctionProgramProject.dgFunctionalClassification, "sector_code", uc.txtCode.Text);
                    uc.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}