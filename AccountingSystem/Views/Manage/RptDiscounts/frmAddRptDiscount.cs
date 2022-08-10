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

namespace AccountingSystem.Views.Manage.RptDiscount
{
    public partial class frmAddRptDiscount : Form
    {
        private readonly frmRptDiscounts _frmRptDiscounts;
        private readonly ucRptDiscounts uc;
        public frmAddRptDiscount(frmRptDiscounts frmRptDiscounts)
        {
            InitializeComponent();
            _frmRptDiscounts = frmRptDiscounts;
            uc = ucRptDiscounts1;
            Helper.LoadFormIcon(this);
        }

        private void frmAddRptDiscount_Load(object sender, EventArgs e)
        {
            uc.isEdit = false;
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

                var model = new RptDiscountsModel()
                {
                    Month = Convert.ToInt32(uc.cmbxMonth.SelectedValue),
                    Description = uc.txtDescription.Text.Trim(),
                    Rate = uc.nudRate.Value,
                    IsAdvance = uc.chckBxAdvance.Checked
                };

                return AccFactory.RptDiscountRepository().Insert(model);
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
                Helper.MessageBoxSuccess("Discount has been saved.");
                _frmRptDiscounts.LoadDiscounts();
                uc.ResetForm();
            }
        }
    }
}
