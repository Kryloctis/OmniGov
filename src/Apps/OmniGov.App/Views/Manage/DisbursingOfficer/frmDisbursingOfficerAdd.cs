using OmniGov.App.Helpers;

using OmniGov.Treasury.Data.Factories;

using OmniGov.Treasury.Domain.Entities;

namespace OmniGov.App.Views.Manage.DisbursingOfficer

{
    public partial class frmDisbursingOfficerAdd : Form

    {
        private frmDisbursingOfficer frmDisbursingOfficer;
        private ucDisbursingOfficer uc;

        public frmDisbursingOfficerAdd(frmDisbursingOfficer _frmDisbursingOfficer)

        {
            InitializeComponent();

            Helper.LoadFormIcon(this);

            frmDisbursingOfficer = _frmDisbursingOfficer;

            uc = ucDisbursingOfficer1;
        }

        private void btnSave_Click(object sender, EventArgs e)

        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Disbursing office has been saved.");
                frmDisbursingOfficer.LoadRecords();
                uc.ResetForm();
            }
        }

        private bool SaveData()

        {
            if (!uc.ValidateChildren())

            {
                Helper.MessageBoxError(uc.GetFormErrors());

                return false;
            }

            var disbursingOfficerModel = new DisbursingOfficerModel()

            {
                Prefix = uc.txtPrefix.Text.Trim(),

                FirstName = uc.txtFirstName.Text.Trim(),

                MiddleInitial = uc.txtMidInitial.Text.Trim(),

                LastName = uc.txtLastName.Text.Trim(),

                Suffix = uc.txtSuffix.Text.Trim(),

                JobTitle = uc.txtJobTitle.Text.Trim(),

                UserId = uc.UserId
            };

            return TreasuryFactory.DisbursingOfficerRepository().Insert(disbursingOfficerModel);
        }
    }
}