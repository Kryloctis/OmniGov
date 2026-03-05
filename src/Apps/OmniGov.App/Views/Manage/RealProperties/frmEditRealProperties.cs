using OmniGov.App.Helpers;

using OmniGov.Treasury.Data.Factories;

namespace OmniGov.App.Views.Manage.RealProperties

{
    public partial class frmEditRealProperties : Form

    {
        private readonly frmRealProperties frmRealProperties;
        private readonly int rptId;
        private readonly ucRealProperties uc;

        public frmEditRealProperties(frmRealProperties frmRealProperties, int rptId)

        {
            InitializeComponent();

            Helper.LoadFormIcon(this);

            this.frmRealProperties = frmRealProperties;

            this.rptId = rptId;

            uc = ucRealProperties1;
        }

        private void btnUpdate_Click(object sender, EventArgs e)

        {
            if (UpdateRpt())
            {
                Helper.MessageBoxSuccess("Real property has been updated");
                frmRealProperties.LoadProperties();
                Close();
            }
        }

        private void frmEditRealProperties_KeyDown(object sender, KeyEventArgs e)

        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                if (UpdateRpt())
                {
                    Helper.MessageBoxSuccess("Real property has been updated.");
                    frmRealProperties.LoadProperties();
                    Close();
                }
            }
        }

        private void frmEditRealProperties_Load(object sender, EventArgs e)

        {
            uc.OnLoad(true, rptId);
            ActiveControl = uc;
        }

        private bool UpdateRpt()

        {
            if (!uc.ValidateChildren())

            {
                Helper.MessageBoxError(uc.GetFormError());

                return false;
            }

            var rptModel = uc.RealPropertiesModel();

            rptModel.Id = rptId;

            rptModel.UpdatedBy = UserHelper.loggedUser.Id;

            return TreasuryFactory.RealPropertiesRepository().UpdateWithPreviousAssessements(rptModel);
        }
    }
}