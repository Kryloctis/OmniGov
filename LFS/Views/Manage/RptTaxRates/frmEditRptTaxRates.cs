using LFS.Helpers;
using System;
using System.Windows.Forms;
using Treasury.Data;
using Treasury.Domain.Entities;

namespace LFS.Views.Manage.RptTaxRates
{
    public partial class frmEditRptTaxRates : Form
    {
        private ucRptTaxRates uc;
        private readonly frmRptTaxRates _frmRptTaxRates;

        public frmEditRptTaxRates(int rptTaxRatesId, frmRptTaxRates frmRptTaxRates)
        {
            InitializeComponent();
            uc = ucRptTaxRates1;
            uc.rptTaxRatesId = rptTaxRatesId;
            _frmRptTaxRates = frmRptTaxRates;
            Helper.LoadFormIcon(this);
        }

        private void LoadRecord()
        {
            var dictTaxRates = TreasuryFactory.RptTaxRatesRepository().GetRecordByID(uc.rptTaxRatesId);
            decimal taxRate = Convert.ToDecimal(dictTaxRates["rate"]);

            uc.txtCode.Text = dictTaxRates["code"];
            uc.txtDescription.Text = dictTaxRates["description"];
            uc.nudRate.Value = (taxRate * 100);
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
                Id = uc.rptTaxRatesId,
                Code = uc.txtCode.Text.Trim(),
                Description = uc.txtDescription.Text.Trim(),
                Rate = uc.nudRate.Value
            };

            return TreasuryFactory.RptTaxRatesRepository().Update(model);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Save())
                {
                    Helper.MessageBoxSuccess("Tax Rate has been updated.");
                    _frmRptTaxRates.LoadTaxRates();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmEditRptTaxRates_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            uc.isEdit = true;
            LoadRecord();
        }
    }
}