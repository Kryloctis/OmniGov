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
    public partial class frmOthersFunctionProgramProjectAdd : Form
    {
        public frmOthersFunctionProgramProjectAdd()
        {
            InitializeComponent();
        }

        private bool SaveData()
        {
            try
            {
                var uc = ucOthersFunctionProgramProject1;

                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                // proceed to insert
                var othersFPPModel = new OthersFPPModel()
                {
                    Name = uc.txtName.Text.Trim(),
                    functionProgramProjectId = uc.functionProgramProjectID
                };

                return Factory.OthersFPPRepository().Insert(othersFPPModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var uc = ucOthersFunctionProgramProject1;

            if (SaveData()) 
            {
                uc.ResetForm();
            }
        }

        private void frmOthersFunctionProgramProjectAdd_Load(object sender, EventArgs e)
        {
        }
    }
}
