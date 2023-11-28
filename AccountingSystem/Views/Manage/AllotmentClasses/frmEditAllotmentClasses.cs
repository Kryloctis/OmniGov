using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AllotmentClasses
{
    public partial class frmEditAllotmentClasses : Form
    {
        private frmAllotmentClasses _frmAllotmentClasses;
        private ucAllotmentClasses uc;

        public frmEditAllotmentClasses(frmAllotmentClasses frmAllotmentClasses, int allotmentId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _frmAllotmentClasses = frmAllotmentClasses;
            uc = ucAllotmentClasses1;
            uc.allotmentClassesId = allotmentId;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateData())
                {
                    Helper.MessageBoxSuccess("Allotment class has been saved.");
                    _frmAllotmentClasses.LoadRecords();
                    this.Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmAllotmentClassesEdit_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSelectedRecord();
                uc.isEdit = true;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadSelectedRecord()
        {
            var allotmentClassesRepository = AccFactory.AllotmentClassesRepository();
            var allotmentData = allotmentClassesRepository.GetRecordByID(uc.allotmentClassesId);

            uc.txtName.Text = allotmentData["allotment_name"];
            uc.txtCode.Text = allotmentData["allotment_code"];
        }

        private bool UpdateData()
        {
            // if error occurs, show messagebox error
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            // proceed to update
            var allotmentModel = new AllotmentClassesModel()
            {
                Id = uc.allotmentClassesId,
                AllotmentName = uc.txtName.Text.Trim(),
                AllotmentCode = uc.txtCode.Text.Trim(),
            };

            return AccFactory.AllotmentClassesRepository().Update(allotmentModel);
        }
    }
}