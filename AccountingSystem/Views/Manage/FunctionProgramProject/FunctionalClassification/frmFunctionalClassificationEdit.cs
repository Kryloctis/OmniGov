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

namespace AccountingSystem.Views.Manage.FunctionProgramProject.FunctionalClassification
{
    public partial class frmFunctionalClassificationEdit : Form
    {
        private frmFunctionProgramProject _frmFunctionProgramProject;
        public frmFunctionalClassificationEdit(frmFunctionProgramProject frmFunctionProgramProject, byte functionalClassificationId)
        {
            InitializeComponent();
            _frmFunctionProgramProject = frmFunctionProgramProject;
            ucFunctionalClassification1.functionalClassificationId = functionalClassificationId;

         
        }
        private void LoadSelectedRecord()
        {
            try
            {
                var uc = ucFunctionalClassification1;
                var functionalClassificationRepository = Factory.FunctionalClassificationRepository();
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
                var uc = ucFunctionalClassification1;


                // if error occurs, show messagebox error
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                // proceed to update
                var functionalClassificationModel = new FunctionalClassificationModel()
                {
                    Id = uc.functionalClassificationId,
                    SectorCode = uc.txtCode.Text.Trim(),
                    SectorName = uc.txtName.Text.Trim()
                };

                var functionalClassificationRepository = Factory.FunctionalClassificationRepository();
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
            this.Visible = true;
            Helper.LoadFormIcon(this);
            LoadSelectedRecord();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Allotment class has been saved.");
                _frmFunctionProgramProject.LoadFunctionalClassificationRecords();
                ucFunctionalClassification1.ResetForm();
            }
        }
    }
}
