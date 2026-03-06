using OmniGov.App.Helpers;

using OmniGov.Treasury.Data.Factories;

using OmniGov.Treasury.Domain.Entities;

namespace OmniGov.App.Views.Manage.FeesChargesConfig.Classification

{
    public partial class frmAddFeesChargesClassification : Form

    {
        private readonly frmFeesChargesConfig frmFeesChargesClassification;
        private readonly ucFeesChargesClassification uc;
        private int? parentId;

        public frmAddFeesChargesClassification(int? parentId, frmFeesChargesConfig frmFeesChargesClassification)

        {
            InitializeComponent();

            Helper.LoadFormIcon(this);

            this.parentId = parentId;

            uc = ucFeesChargesClassification1;

            this.frmFeesChargesClassification = frmFeesChargesClassification;
        }

        private void btnSave_Click(object sender, EventArgs e)

        {
            if (Save())
            {
                this.frmFeesChargesClassification.LoadFeesCharges();
                Close();
                Helper.MessageBoxSuccess("Fees & Charges classification has been saved.");
            }
        }

        private void frmAddFeesChargesClassification_KeyDown(object sender, KeyEventArgs e)

        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                if (Save())
                {
                    this.frmFeesChargesClassification.LoadFeesCharges();
                    Close();
                    Helper.MessageBoxSuccess("Fees & Charges classification has been saved.");
                }
            }
        }

        private void frmAddFeesChargesClassification_Load(object sender, EventArgs e)

        {
            uc.OnLoad(false);
        }

        private bool Save()

        {
            if (!uc.ValidateChildren())

            {
                Helper.MessageBoxError(uc.GetFormErrors());

                return false;
            }

            var feesChargesClassificationModel = new TaxTypesModel()

            {
                ParentID = parentId,
                Code = uc.txtCode.Text.Trim(),
                Description = uc.txtDesciption.Text.Trim(),
                FundID = uc.cmbxFund.SelectedValue,
                COAAccountCode = uc.txtCOAAccountCode.Text.Trim(),
                BLGFAccountCode = uc.txtBLFGAccountCode.Text.Trim()
            };

            return TreasuryFactory.TaxTypesRepository().Insert(feesChargesClassificationModel);
        }
    }
}