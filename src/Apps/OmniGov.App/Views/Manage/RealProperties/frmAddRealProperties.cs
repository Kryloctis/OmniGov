using OmniGov.App.Helpers;

using OmniGov.Treasury.Data.Factories;

namespace OmniGov.App.Views.Manage.RealProperties

{
    public partial class frmAddRealProperties : Form

    {
        internal readonly ucRealProperties uc;
        private readonly frmRealProperties frmRealProperties;

        public frmAddRealProperties(frmRealProperties frmRealProperties)

        {
            InitializeComponent();

            this.frmRealProperties = frmRealProperties;

            uc = ucRealProperties1;
        }

        private void btnSave_Click(object sender, EventArgs e)

        {
            if (SaveRpt())
            {
                Helper.MessageBoxSuccess("Real property has been saved.");
                frmRealProperties.LoadProperties();
                uc.ResetForm();
            }
        }

        private void frmAddRealProperties_KeyDown(object sender, KeyEventArgs e)

        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                if (SaveRpt())
                {
                    Helper.MessageBoxSuccess("Real property has been saved.");
                    frmRealProperties.LoadProperties();
                    uc.ResetForm();
                }
            }
        }

        private void frmAddRealProperties_Load(object sender, EventArgs e)

        {
            uc.OnLoad(false);
            ActiveControl = uc;
        }

        private bool SaveRpt()

        {
            if (!uc.ValidateChildren())

            {
                Helper.MessageBoxError(uc.GetFormError());

                return false;
            }

            var rptModel = uc.RealPropertiesModel();

            rptModel.CreatedBy = UserHelper.loggedUser.Id;

            return TreasuryFactory.RealPropertiesRepository().InsertWithPreviousAssessments(rptModel);
        }
    }
}