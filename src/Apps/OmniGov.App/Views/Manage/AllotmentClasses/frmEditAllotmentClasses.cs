using OmniGov.App.Helpers;
using OmniGov.Core.Factories;

namespace OmniGov.App.Views.Manage.AllotmentClasses
{
    public partial class frmEditAllotmentClasses : Form
    {
        private int allotmentClassId;
        private frmAllotmentClasses frmAllotmentClasses;
        private ucAllotmentClasses uc;

        public frmEditAllotmentClasses(frmAllotmentClasses frmAllotmentClasses, int allotmentClassId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.allotmentClassId = allotmentClassId;
            this.frmAllotmentClasses = frmAllotmentClasses;
            uc = ucAllotmentClasses1;
        }

        private void frmAllotmentClassesEdit_Load(object sender, EventArgs e)
        {
            uc.OnLoad(true, allotmentClassId);
        }

        private bool UpdateData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var allotmentModel = uc.AllotmentClassesModel();
            allotmentModel.Id = allotmentClassId;

            return Factory.AllotmentClassesRepository().Update(allotmentModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UpdateData())
            {
                Helper.MessageBoxSuccess("Allotment class has been updated.");
                frmAllotmentClasses.LoadRecords();
                Close();
            }
        }

        private void frmEditAllotmentClasses_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                if (UpdateData())
                {
                    Helper.MessageBoxSuccess("Allotment class has been updated.");
                    frmAllotmentClasses.LoadRecords();
                    Close();
                }
            }
        }
    }
}