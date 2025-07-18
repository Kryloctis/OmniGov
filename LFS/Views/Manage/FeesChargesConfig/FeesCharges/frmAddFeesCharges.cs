using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace LFS.Views.Manage.FeesChargesConfig.FeesCharges
{
    public partial class frmAddFeesCharges : Form
    {
        private readonly int feesChargesClassificationId;
        private readonly frmFeesChargesConfig frmFeesChargesClassification;
        private readonly ucFeesCharges uc;

        public frmAddFeesCharges(int feesChargesClassificationId, frmFeesChargesConfig frmFeesChargesClassification)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.feesChargesClassificationId = feesChargesClassificationId;
            uc = ucFeesCharges1;
            this.frmFeesChargesClassification = frmFeesChargesClassification;
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
                IsRateEditable = uc.chckEditableRate.Checked,
                TaxTypeID = feesChargesClassificationId,
                Description = uc.txtDescription.Text.Trim(),
                Amount = uc.nudAmount.Value,
                StartingYear = (int)uc.nudStartingYear.Value,
                CreatedBy = Helper.userId
            };

            return AccFactory.OtherPaymentRatesRepository().Insert(feesChargesModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Save())
                {
                    this.frmFeesChargesClassification.LoadFeesCharges();
                    Helper.MessageBoxSuccess("Fees & Charges has been saved");
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmAddFeesCharges_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(false);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmAddFeesCharges_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Control)
                {
                    if (Save())
                    {
                        this.frmFeesChargesClassification.LoadFeesCharges();
                        Helper.MessageBoxSuccess("Fees & Charges has been saved");
                        Close();
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}