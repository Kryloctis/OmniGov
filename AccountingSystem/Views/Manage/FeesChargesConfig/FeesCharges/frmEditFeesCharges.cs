using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.FeesChargesConfig.FeesCharges
{
    public partial class frmEditFeesCharges : Form
    {
        private readonly frmFeesChargesConfig frmFeesChargesClassification;
        private readonly int feesClassificationId;
        private readonly int feesChargesId;
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
                UpdatedBy = Helper.UserId
            };

            return AccFactory.OtherPaymentRatesRepository().Update(feesChargesModel);
        }

        private void frmEditFeesCharges_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(true, feesChargesId);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Save())
                {
                    this.frmFeesChargesClassification.LoadFeesCharges();
                    Helper.MessageBoxSuccess("Fees & Charges has been updated");
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmEditFeesCharges_KeyDown(object sender, KeyEventArgs e)
        {
            try
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
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}