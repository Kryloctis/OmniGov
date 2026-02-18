using OmniGov.App.Helpers;
using System;
using System.Windows.Forms;
using Treasury.Data.Factories;
using Treasury.Domain.Entities;

namespace OmniGov.App.Views.Manage.FeesChargesConfig.Classification
{
    public partial class frmEditFeesChargesClassification : Form
    {
        private readonly frmFeesChargesConfig frmFeesChargesClassification;
        private readonly ucFeesChargesClassification uc;
        private readonly int feesChargesClassificationId;

        public frmEditFeesChargesClassification(int feesChargesClassificationId, frmFeesChargesConfig frmFeesChargesClassification)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucFeesChargesClassification1;
            this.frmFeesChargesClassification = frmFeesChargesClassification;
            this.feesChargesClassificationId = feesChargesClassificationId;
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
                Id = feesChargesClassificationId,
                Code = uc.txtCode.Text.Trim(),
                Description = uc.txtDesciption.Text.Trim(),
                COAAccountCode = uc.txtCOAAccountCode.Text.Trim(),
                BLGFAccountCode = uc.txtBLFGAccountCode.Text.Trim(),
                FundID = uc.cmbxFund.SelectedValue
            };

            return TreasuryFactory.TaxTypesRepository().Update(feesChargesClassificationModel);
        }

        private void frmEditFeesChargesClassification_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(true, this.feesChargesClassificationId);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Save())
                {
                    frmFeesChargesClassification.LoadFeesCharges();
                    Close();
                    Helper.MessageBoxSuccess("Fees & Charges classification has been updated.");
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmEditFeesChargesClassification_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Control)
                {
                    if (Save())
                    {
                        frmFeesChargesClassification.LoadFeesCharges();
                        Close();
                        Helper.MessageBoxSuccess("Fees & Charges classification has been updated.");
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
