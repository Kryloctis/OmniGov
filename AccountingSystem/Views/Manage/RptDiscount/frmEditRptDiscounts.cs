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
        public frmEditRptDiscounts(frmRptDiscounts frmRptDiscounts)
        {
            InitializeComponent();
            _frmRptDiscounts = frmRptDiscounts;
            uc = ucRptDiscounts1;
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

                return true;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void frmEditRptDiscounts_Load(object sender, EventArgs e)
        {
            uc.isEdit = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Helper.MessageBoxSuccess("Discount has been updated.");
                Close();
            }
        }
    }
}
