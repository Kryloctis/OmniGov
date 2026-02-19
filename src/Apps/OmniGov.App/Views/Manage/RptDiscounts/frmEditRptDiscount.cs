using OmniGov.App.Helpers;
using Treasury.Data.Factories;
using Treasury.Domain.Entities;

namespace OmniGov.App.Views.Manage.RptDiscounts
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

            return TreasuryFactory.RptDiscountRepository().Update(model);
        }

        private void LoadRecord()
        {
            var dictRptDiscounts = TreasuryFactory.RptDiscountRepository().GetRecordByID(uc.rptDiscountId);
            decimal rate = Convert.ToDecimal(dictRptDiscounts["rate"]);

            uc.cmbxMonth.SelectedValue = dictRptDiscounts["month"];
            uc.txtDescription.Text = dictRptDiscounts["description"];
            uc.nudRate.Value = (rate * 100);
            uc.chckBxAdvance.Checked = Convert.ToBoolean(Convert.ToUInt16(dictRptDiscounts["is_advance"]));
        }

        private void frmEditRptDiscounts_Load(object sender, EventArgs e)
        {
            try
            {
                uc.isEdit = true;
                LoadRecord();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (Save())
                {
                    Helper.MessageBoxSuccess("Discount has been updated.");
                    _frmRptDiscounts.LoadDiscounts();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
