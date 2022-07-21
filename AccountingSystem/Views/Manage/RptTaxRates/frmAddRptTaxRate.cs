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
                if(!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

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
                _frmRptTaxRates.LoadTaxRates();
                uc.ResetForm();
            }
        }
    }
}
