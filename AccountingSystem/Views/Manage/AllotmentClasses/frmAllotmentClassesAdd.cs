using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AllotmentClasses
{
    public partial class frmAllotmentClassesAdd : Form
    {
        private frmAllotmentClasses _frmAllotmentClasses;
        private ucAllotmentClasses uc;

        public frmAllotmentClassesAdd(frmAllotmentClasses frmAllotmentClasses)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucAllotmentClasses1;
            _frmAllotmentClasses = frmAllotmentClasses;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Allotment class has been saved.");
                _frmAllotmentClasses.LoadRecords();
                uc.ResetForm();
            }
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
            var allotmentModel = new AllotmentClassesModel()
            {
                AllotmentName = uc.txtName.Text.Trim(),
                AllotmentCode = uc.txtCode.Text.Trim(),
            };

            return AccFactory.AllotmentClassesRepository().Insert(allotmentModel);
        }

        private void frmAllotmentClassesAdd_Load(object sender, EventArgs e)
        {
            uc.isEdit = false;
        }
    }
}