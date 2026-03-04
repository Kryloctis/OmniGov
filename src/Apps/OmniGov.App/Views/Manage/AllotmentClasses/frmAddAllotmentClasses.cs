using OmniGov.App.Helpers;
using OmniGov.Core.Factories;

namespace OmniGov.App.Views.Manage.AllotmentClasses
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

        private void frmAllotmentClassesAdd_Load(object sender, EventArgs e)
        {
            uc.OnLoad(false, null);
        }

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            return Factory.AllotmentClassesRepository().Insert(uc.AllotmentClassesModel());
        }
    }
}