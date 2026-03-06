using OmniGov.App.Helpers;

using OmniGov.Treasury.Data.Factories;

using OmniGov.Treasury.Domain.Entities;

namespace OmniGov.App.Views.Manage.RptTaxRates

{
    public partial class frmAddRptTaxRate : Form

    {
        private readonly frmRptTaxRates _frmRptTaxRates;

        private ucRptTaxRates uc;

        public frmAddRptTaxRate(frmRptTaxRates frmRptTaxRates)

        {
            InitializeComponent();

            uc = ucRptTaxRates1;

            _frmRptTaxRates = frmRptTaxRates;
        }

        private void btnSave_Click(object sender, EventArgs e)

        {
            if (Save())
            {
                Helper.MessageBoxSuccess("Tax Rate has been saved.");
                _frmRptTaxRates.LoadTaxRates();
                uc.ResetForm();
            }
        }

        private bool Save()

        {
            if (!uc.ValidateChildren())

            {
                Helper.MessageBoxError(uc.GetFormErrors());

                return false;
            }

            var model = new RptTaxRatesModel()

            {
                Code = uc.txtCode.Text.Trim(),

                Description = uc.txtDescription.Text.Trim(),

                Rate = uc.nudRate.Value
            };

            return TreasuryFactory.RptTaxRatesRepository().Insert(model);
        }
    }
}