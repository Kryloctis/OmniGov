using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AllotmentClasses
{
    public partial class frmAllotmentClassesAdd : Form
    {
        private frmAllotmentClasses _frmAllotmentClasses;

        public frmAllotmentClassesAdd(frmAllotmentClasses frmAllotmentClasses)
        {
            InitializeComponent();
            _frmAllotmentClasses = frmAllotmentClasses;
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

                // proceed to insert
                var allotmentModel = new AllotmentClassesModel()
                {
                    AllotmentName = uc.txtName.Text.Trim(),
                    AllotmentCode = uc.txtCode.Text.Trim(),
                };

                var allotmentClassesRepository = AccFactory.AllotmentClassesRepository();
                return allotmentClassesRepository.Insert(allotmentModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return false;
        }

        private void frmAllotmentClassesAdd_Load(object sender, EventArgs e)
        {
            this.Visible = true;
            Helper.LoadFormIcon(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
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