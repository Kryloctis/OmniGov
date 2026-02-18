using OmniGov.App.Helpers;
using System;
using System.Windows.Forms;
using Treasury.Data.Factories;
using Treasury.Domain.Entities;

namespace OmniGov.App.Views.Manage.RptDiscounts
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

            return TreasuryFactory.RptDiscountRepository().Insert(model);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Save())
                {
                    Helper.MessageBoxSuccess("Discount has been saved.");
                    _frmRptDiscounts.LoadDiscounts();
                    uc.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
