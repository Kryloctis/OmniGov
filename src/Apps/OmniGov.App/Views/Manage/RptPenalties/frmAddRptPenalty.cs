using OmniGov.App.Helpers;

using OmniGov.Treasury.Data.Factories;

using OmniGov.Treasury.Domain.Entities;

namespace OmniGov.App.Views.Manage.RptPenalties

{
    public partial class frmAddRptPenalty : Form

    {
        private readonly frmRptPenalties _frmRptPenalties;
        private ucRptPenalties uc;

        public frmAddRptPenalty(frmRptPenalties frmRptPenalties)

        {
            InitializeComponent();

            uc = ucRptPenalties1;

            _frmRptPenalties = frmRptPenalties;
        }

        private void btnSave_Click(object sender, EventArgs e)

        {
            if (Save())
            {
                Helper.MessageBoxSuccess("Penalty has been saved.");
                uc.ResetForm();
                _frmRptPenalties.LoadPenalties();
            }
        }

        private void frmRptAddPenalty_Load(object sender, EventArgs e)

        {
            uc.isEdit = false;
        }

        private bool Save()

        {
            if (!uc.ValidateChildren())

            {
                Helper.MessageBoxError(uc.GetFormErrors());

                return false;
            }

            var model = new RptPenaltiesModel()

            {
                Description = uc.txtDescription.Text.Trim(),

                Rate = uc.nudRate.Value,

                Frequency = uc.cmbxFrequency.Text.Trim()
            };

            return TreasuryFactory.RptPenaltiesRepository().Insert(model);
        }
    }
}