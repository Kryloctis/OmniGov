using OmniGov.App.Helpers;

using OmniGov.Treasury.Data.Factories;

using OmniGov.Treasury.Domain.Entities;

namespace OmniGov.App.Views.Manage.FeesChargesConfig.FeesCharges

{
    public partial class frmEditFeesCharges : Form

    {
        private readonly int feesChargesId;
        private readonly int feesClassificationId;
        private readonly frmFeesChargesConfig frmFeesChargesClassification;
        private readonly ucFeesCharges uc;

        public frmEditFeesCharges(int feesChargesId, int feesClassificationId, frmFeesChargesConfig frmFeesChargesClassification)

        {
            InitializeComponent();

            Helper.LoadFormIcon(this);

            uc = ucFeesCharges1;

            this.feesClassificationId = feesClassificationId;

            this.feesChargesId = feesChargesId;

            this.frmFeesChargesClassification = frmFeesChargesClassification;
        }

        private void btnSave_Click(object sender, EventArgs e)

        {
            if (Save())
            {
                this.frmFeesChargesClassification.LoadFeesCharges();
                Helper.MessageBoxSuccess("Fees & Charges has been updated");
                Close();
            }
        }

        private void frmEditFeesCharges_KeyDown(object sender, KeyEventArgs e)

        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                if (Save())
                {
                    this.frmFeesChargesClassification.LoadFeesCharges();
                    Helper.MessageBoxSuccess("Fees & Charges has been updated");
                    Close();
                }
            }
        }

        private void frmEditFeesCharges_Load(object sender, EventArgs e)

        {
            uc.OnLoad(true, feesChargesId);
        }

        private bool Save()

        {
            if (!uc.ValidateChildren())

            {
                Helper.MessageBoxError(uc.GetFormErrors());

                return false;
            }

            var feesChargesModel = new OtherPaymentRatesModel()

            {
                Id = feesChargesId,

                TaxTypeID = feesClassificationId,

                IsRateEditable = uc.chckEditableRate.Checked,

                Description = uc.txtDescription.Text.Trim(),

                Amount = uc.nudAmount.Value,

                StartingYear = (int)uc.nudStartingYear.Value,

                UpdatedBy = UserHelper.loggedUser.Id
            };

            return TreasuryFactory.OtherPaymentRatesRepository().Update(feesChargesModel);
        }
    }
}