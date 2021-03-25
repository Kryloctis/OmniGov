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

namespace AccountingSystem.Views.Manage.AllotmentClasses
{
    public partial class frmAllotmentClassesEdit : Form
    {
        private frmAllotmentClasses _frmAllotmentClasses;
        public frmAllotmentClassesEdit(frmAllotmentClasses frmAllotmentClasses, int allotmentId)
        {
            InitializeComponent();
            _frmAllotmentClasses = frmAllotmentClasses;
            ucAllotmentClasses1.allotmentId = allotmentId;
        }
        private void LoadSelectedRecord()
        {
            try
            {
                var uc = ucAllotmentClasses1;
                var allotmentClassesRepository = Factory.AllotmentClassesRepository();
                var allotmentData = allotmentClassesRepository.GetRecordByID(uc.allotmentId);

                uc.txtName.Text = allotmentData["allotment_name"];
                uc.txtCode.Text = allotmentData["allotment_code"];

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
                var uc = ucAllotmentClasses1;


                // if error occurs, show messagebox error
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                // proceed to update
                var allotmentModel = new AllotmentClassesModel()
                {
                    Id = uc.allotmentId,
                    AllotmentName = uc.txtName.Text.Trim(),
                    AllotmentCode = uc.txtCode.Text.Trim(),

                };

                var allotmentClassesRepository = Factory.AllotmentClassesRepository();
                return allotmentClassesRepository.Update(allotmentModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return false;
        }

        private void frmAllotmentClassesEdit_Load(object sender, EventArgs e)
        {
            this.Visible = true;
            Helper.LoadFormIcon(this);
            LoadSelectedRecord();

        }

     

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Allotment class has been saved.");
                _frmAllotmentClasses.LoadRecords();
                ucAllotmentClasses1.ResetForm();
            }
        }
    }
}
