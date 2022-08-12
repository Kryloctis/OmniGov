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

namespace AccountingSystem.Views.Manage.RptTaxRates
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
            var dictTaxRates = AccFactory.RptTaxRatesRepository().GetRecordByID(uc.rptTaxRatesId);

            uc.txtCode.Text = dictTaxRates["code"];
            uc.txtDescription.Text = dictTaxRates["description"];
            uc.nudRate.Value = Convert.ToDecimal(dictTaxRates["rate"]);
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
                    Id = uc.rptTaxRatesId,
                    Code = uc.txtCode.Text.Trim(),
                    Description = uc.txtDescription.Text.Trim(),
                    Rate = uc.nudRate.Value
                };

                return AccFactory.RptTaxRatesRepository().Update(model);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Helper.MessageBoxSuccess("Tax Rate has been updated.");
                _frmRptTaxRates.LoadTaxRates();
                Close();
            }
        }

        private void frmEditRptTaxRates_Load(object sender, EventArgs e)
        {
            uc.isEdit = true;
            LoadRecord();
        }
    }
}
