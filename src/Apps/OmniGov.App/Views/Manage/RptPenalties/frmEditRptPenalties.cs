using OmniGov.App.Helpers;

using OmniGov.Treasury.Data.Factories;

using OmniGov.Treasury.Domain.Entities;

namespace OmniGov.App.Views.Manage.RptPenalties

{
    public partial class frmEditRptPenalties : Form

    {
        private readonly frmRptPenalties _frmRptPenalties;

        private ucRptPenalties uc;

        public frmEditRptPenalties(int rptPenaltiesId, frmRptPenalties frmRptPenalties)

        {
            InitializeComponent();

            _frmRptPenalties = frmRptPenalties;

            uc = ucRptPenalties1;

            uc.rptPenaltiesId = rptPenaltiesId;

            Helper.LoadFormIcon(this);
        }

        private void btnUpdate_Click(object sender, EventArgs e)

        {
            if (Save())
            {
                Helper.MessageBoxSuccess("Penalty has been updated.");
                _frmRptPenalties.LoadPenalties();
                Close();
            }
        }

        private void frmEditRptPenalties_Load(object sender, EventArgs e)

        {
            uc.isEdit = true;
            LoadRecord();
        }

        private void LoadRecord()

        {
            var dictRptDiscounts = TreasuryFactory.RptPenaltiesRepository().GetRecordByID(uc.rptPenaltiesId);

            decimal rate = Convert.ToDecimal(dictRptDiscounts["rate"]);

            uc.txtDescription.Text = dictRptDiscounts["description"];

            uc.nudRate.Value = (rate * 100);

            uc.cmbxFrequency.Text = dictRptDiscounts["frequency"];
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
                Id = uc.rptPenaltiesId,

                Description = uc.txtDescription.Text.Trim(),

                Rate = uc.nudRate.Value,

                Frequency = uc.cmbxFrequency.Text.Trim()
            };

            return TreasuryFactory.RptPenaltiesRepository().Update(model);
        }
    }
}