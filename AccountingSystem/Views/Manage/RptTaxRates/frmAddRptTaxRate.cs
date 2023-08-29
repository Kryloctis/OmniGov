using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RptTaxRates
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

        private bool Save()
        {
            try
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

                return AccFactory.RptTaxRatesRepository().Insert(model);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Helper.MessageBoxSuccess("Tax Rate has been saved.");
                _frmRptTaxRates.RunBackgroundWorker();
                uc.ResetForm();
            }
        }
    }
}