using ACC.Data;
using System;
using System.Windows.Forms;

namespace LFS.Views.Manage.AllotmentClasses
{
    public partial class frmAddAllotmentClasses : Form
    {
        private frmAllotmentClasses frmAllotmentClasses;
        private ucAllotmentClasses uc;

        public frmAddAllotmentClasses(frmAllotmentClasses frmAllotmentClasses)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucAllotmentClasses1;
            this.frmAllotmentClasses = frmAllotmentClasses;
        }

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            return AccFactory.AllotmentClassesRepository().Insert(uc.AllotmentClassesModel());
        }

        private void frmAllotmentClassesAdd_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(false, null);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Allotment class has been saved.");
                frmAllotmentClasses.LoadRecords();
                uc.ResetForm();
            }
        }

        private void frmAddAllotmentClasses_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Control)
                {
                    if (SaveData())
                    {
                        Helper.MessageBoxSuccess("Allotment class has been saved.");
                        frmAllotmentClasses.LoadRecords();
                        uc.ResetForm();
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}