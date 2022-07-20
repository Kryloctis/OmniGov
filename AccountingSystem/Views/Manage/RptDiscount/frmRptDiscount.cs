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
    public partial class frmRptDiscount : Form
    {
        private readonly int rptDiscountId = 1;

        public frmRptDiscount()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void LoadDiscountPercentage()
        {
            try
            {
                string percentage = Factory.rptDiscountRepository().GetRecordByID(rptDiscountId)["percentage"];
                nudPercentage.Value = string.IsNullOrEmpty(percentage) ? 0 : Convert.ToDecimal(percentage);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private bool Save() 
        {
            try
            {
                decimal percentage = nudPercentage.Value;

                var model = new RptDiscountModel()
                {
                    Id = rptDiscountId,
                    Percentage = percentage
                };

                return Factory.rptDiscountRepository().Update(model);
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
            }
        }

        private void frmRptDiscount_Load(object sender, EventArgs e)
        {
            LoadDiscountPercentage();
        }
    }
}
