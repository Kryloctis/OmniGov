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
    public partial class frmEditRptDiscount : Form
    {
        private readonly frmRptDiscounts _frmRptDiscounts;
        private readonly ucRptDiscounts uc;
        public frmEditRptDiscount(int rptDiscountId, frmRptDiscounts frmRptDiscounts)
        {
            InitializeComponent();
            _frmRptDiscounts = frmRptDiscounts;
            uc = ucRptDiscounts1;
            uc.rptDiscountId = rptDiscountId;
            Helper.LoadFormIcon(this);
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
                    Id = uc.rptDiscountId,
                    Month = Convert.ToInt32(uc.cmbxMonth.SelectedValue),
                    Description = uc.txtDescription.Text.Trim(),
                    Rate = uc.nudRate.Value,
                    IsAdvance = uc.chckBxAdvance.Checked
                };

                return AccFactory.RptDiscountRepository().Update(model);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void LoadRecord() 
        {
            var dictRptDiscounts = AccFactory.RptDiscountRepository().GetRecordByID(uc.rptDiscountId);

            uc.cmbxMonth.SelectedValue = dictRptDiscounts["month"];
            uc.txtDescription.Text = dictRptDiscounts["description"];
            uc.nudRate.Value = Convert.ToDecimal(dictRptDiscounts["rate"]);
            uc.chckBxAdvance.Checked = Convert.ToBoolean(Convert.ToUInt16(dictRptDiscounts["is_advance"]));
        }

        private void frmEditRptDiscounts_Load(object sender, EventArgs e)
        {
            uc.isEdit = true;
            LoadRecord();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Helper.MessageBoxSuccess("Discount has been updated.");
                _frmRptDiscounts.LoadDiscounts();
                Close();
            }
        }
    }
}
