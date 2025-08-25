using ACC.Data;
using ACC.Domain.Models;
using LFS.Helpers;
using System;
using System.Windows.Forms;

namespace LFS.Views.Manage.FunctionProgramProject.OthersFunctionProgramProject
{
    public partial class frmOthersFunctionProgramProjectEdit : Form
    {
        private frmOthersFunctionProgramProject _frmOthersFunctionProgramProject;
        private ucOthersFunctionProgramProject uc;

        public frmOthersFunctionProgramProjectEdit(frmOthersFunctionProgramProject frmOthersFunctionProgramProject)
        {
            InitializeComponent();
            uc = ucOthersFunctionProgramProject1;
            _frmOthersFunctionProgramProject = frmOthersFunctionProgramProject;
        }

        private void LoadSelected()
        {
            var dicOthersFPPRecord = AccFactory.SubFPPRepository().GetRecordByID(uc.othersFPPID);
            uc.txtCode.Text = dicOthersFPPRecord["others_fpp_code"];
            uc.txtName.Text = dicOthersFPPRecord["name"];
        }

        private bool UpdateData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var othersFPPModel = new SubFPPModel()
            {
                Id = uc.othersFPPID,
                othersFPPCode = uc.txtCode.Text.Trim(),
                othersFPPName = uc.txtName.Text.Trim()
            };

            return AccFactory.SubFPPRepository().Update(othersFPPModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateData())
                {
                    _frmOthersFunctionProgramProject.LoadRecords();
                    Helper.MessageBoxSuccess("Update has been saved.");
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmOthersFunctionProgramProjectEdit_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            LoadSelected();
        }
    }
}