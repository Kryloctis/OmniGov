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

namespace AccountingSystem.Views.Manage.FunctionProgramProject.FunctionProgramProject
{
    public partial class frmFunctionProgramProjectEdit : Form
    {
        private frmFunctionProgramProject _frmFunctionProgramProject;
        public frmFunctionProgramProjectEdit(frmFunctionProgramProject frmFunctionProgramProject, byte fppID)
        {
            InitializeComponent();
            _frmFunctionProgramProject = frmFunctionProgramProject;
            ucFunctionProgramProject1.FppID = fppID;
        }

        private void LoadSelectedRecord()
        {
            try
            {
                var uc = ucFunctionProgramProject1;
                var functionProgramProjectRepository = Factory.FunctionProgramProjectRepository();
                Dictionary<string, string> data = functionProgramProjectRepository.GetRecordByID(uc.FppID);

                uc.cmbServiceName.SelectedValue = data["functional_classification_services_id"];
                uc.txtCode.Text = data["fpp_code"];
                uc.txtName.Text = data["fpp_name"];
                uc.txtServiceId.Text = data["functional_classification_services_id"];
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }


        private bool SaveData()
        {
            try
            {
                var uc = ucFunctionProgramProject1;
                // if error occurs, show messagebox error
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                // proceed to insert
                var functionProgramProjectModel = new FunctionProgramProjectModel()
                {
                    Id = ucFunctionProgramProject1.FppID,
                    functionalClassificationServiceId = byte.Parse(uc.cmbServiceName.SelectedValue.ToString()),
                    FppName = uc.txtName.Text.Trim(),
                    FppCode = uc.txtCode.Text.Trim(),
                };

                return Factory.FunctionProgramProjectRepository().Update(functionProgramProjectModel);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }

            return false;
        }

        private void frmFunctionProgramProjectEdit_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            ucFunctionProgramProject1.LoadServiceNameComboBox();
            LoadSelectedRecord();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Function Program Project has been saved.");
                _frmFunctionProgramProject.LoadFunctionProgramProjectRecords();
               
            }
        }
    }
}
