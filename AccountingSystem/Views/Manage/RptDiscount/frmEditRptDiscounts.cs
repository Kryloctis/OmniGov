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
    public partial class frmEditRptDiscounts : Form
    {
        private readonly frmRptDiscounts _frmRptDiscounts;
        private readonly ucRptDiscounts uc;
        public frmEditRptDiscounts(int rptDiscountId, frmRptDiscounts frmRptDiscounts)
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
                    Code = uc.txtCode.Text.Trim(),
                    Description = uc.txtDescription.Text.Trim(),
                    Rate = uc.nudRate.Value
                };

                return Factory.rptDiscountRepository().Update(model);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void LoadRecord() 
        {
            var dictRptDiscounts = Factory.rptDiscountRepository().GetRecordByID(uc.rptDiscountId);

            uc.txtCode.Text = dictRptDiscounts["code"];
            uc.txtDescription.Text = dictRptDiscounts["description"];
            uc.nudRate.Value = Convert.ToDecimal(dictRptDiscounts["rate"]);
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
