using OmniGov.App.Helpers;

using OmniGov.Treasury.Data.Factories;

namespace OmniGov.App.Views.Manage.TaxPayers

{
    public partial class frmAddTaxpayers : Form

    {
        private readonly ucTaxPayers uc;

        private frmTaxpayers frmTaxpayers;

        public frmAddTaxpayers(frmTaxpayers frmTaxpayers)

        {
            InitializeComponent();

            Helper.LoadFormIcon(this);

            this.frmTaxpayers = frmTaxpayers;

            uc = ucTaxPayers1;
        }

        private void btnSave_Click(object sender, EventArgs e)

        {
            if (SaveTaxpayer())
            {
                Helper.MessageBoxSuccess("Taxpayer has been saved.");
                frmTaxpayers.LoadTaxpayers();
                uc.ResetForm();
            }
        }

        private void frmAddTaxpayers_KeyDown(object sender, KeyEventArgs e)

        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                if (SaveTaxpayer())
                {
                    Helper.MessageBoxSuccess("Taxpayer has been saved.");
                    frmTaxpayers.LoadTaxpayers();
                    uc.ResetForm();
                }
            }
        }

        private void frmAddTaxpayers_Load(object sender, EventArgs e)

        {
            uc.OnLoad(false);
            ActiveControl = uc;
        }

        private bool SaveTaxpayer()

        {
            if (!uc.ValidateChildren())

            {
                Helper.MessageBoxError(uc.GetFormErrors());

                return false;
            }

            var taxpayersModel = uc.TaxpayersModel();

            taxpayersModel.CreatedBy = UserHelper.loggedUser.Id;

            return TreasuryFactory.TaxpayersRepository().Insert(taxpayersModel);
        }
    }
}