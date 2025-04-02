using ACC.Data;
using ACC.Domain.Models;
using LFS;
using System;
using System.Windows.Forms;

namespace LFS.Views.Manage.FunctionProgramProject.OthersFunctionProgramProject
{
    public partial class frmOthersFunctionProgramProjectAdd : Form
    {
        private frmOthersFunctionProgramProject _frmOthersFunctionProgramProject;
        private ucOthersFunctionProgramProject uc;

        public frmOthersFunctionProgramProjectAdd(frmOthersFunctionProgramProject frmOthersFunctionProgramProject)
        {
            InitializeComponent();
            uc = ucOthersFunctionProgramProject1;
            _frmOthersFunctionProgramProject = frmOthersFunctionProgramProject;
        }

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            // proceed to insert
            var othersFPPModel = new SubFPPModel()
            {
                functionProgramProjectId = uc.functionProgramProjectID,
                othersFPPCode = uc.txtCode.Text.Trim(),
                othersFPPName = uc.txtName.Text.Trim()
            };

            return AccFactory.SubFPPRepository().Insert(othersFPPModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    uc.ResetForm();
                    Helper.MessageBoxSuccess("Other Function, Program & Project has been saved.");
                    _frmOthersFunctionProgramProject.LoadRecords();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}