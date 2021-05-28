using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.FunctionProgramProject.OthersFunctionProgramProject
{
    public partial class frmOthersFunctionProgramProjectEdit : Form
    {

        private frmOthersFunctionProgramProject _frmOthersFunctionProgramProject;
        public frmOthersFunctionProgramProjectEdit(frmOthersFunctionProgramProject frmOthersFunctionProgramProject)
        {
            InitializeComponent();
            _frmOthersFunctionProgramProject = frmOthersFunctionProgramProject;
        }

        private void LoadSelected()
        {
            try
            {
                var uc = ucOthersFunctionProgramProject1;
                var dicOthersFPPRecord = Factory.OthersFPPRepository().GetRecordByID(uc.othersFPPID);
                uc.txtCode.Text = dicOthersFPPRecord["others_fpp_code"];
                uc.txtName.Text = dicOthersFPPRecord["name"];
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

        }

        private bool UpdateData() 
        {
            try
            {
                var uc = ucOthersFunctionProgramProject1;

                if (!uc.ValidateChildren()) 
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                var othersFPPModel = new OthersFPPModel()
                {
                    Id = uc.othersFPPID,
                    othersFPPCode = uc.txtCode.Text.Trim(),
                    othersFPPName = uc.txtName.Text.Trim()
                };

                return Factory.OthersFPPRepository().Update(othersFPPModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UpdateData()) 
            {
                _frmOthersFunctionProgramProject.LoadRecords();
                Helper.MessageBoxSuccess("Update has been saved.");
                Close();
            }
        }

        private void frmOthersFunctionProgramProjectEdit_Load(object sender, EventArgs e)
        {
            LoadSelected();
        }

    }
}
