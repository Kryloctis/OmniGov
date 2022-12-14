using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.BusinessAdOnCharges
{
    public partial class frmAddBusinessAddOnCharges : Form
    {
        private readonly frmBusinessAddOnCharges _frmBusinessAddOnCharges;
        private readonly ucBusinessAddOnCharges _ucBusinessAddOnCharges;

        public frmAddBusinessAddOnCharges(frmBusinessAddOnCharges frmBusinessAdOnCharges)
        {
            InitializeComponent();
            _frmBusinessAddOnCharges = frmBusinessAdOnCharges;
            _ucBusinessAddOnCharges = ucBusinessAdOnCharges1;
            _ucBusinessAddOnCharges.isEdit = false;
        }

        private bool SaveData()
        {
            if (!_ucBusinessAddOnCharges.ValidateChildren())
            {
                Helper.MessageBoxError(_ucBusinessAddOnCharges.GetFormErrors());
                return false;
            }

            var code = _ucBusinessAddOnCharges.txtCode.Text.Trim();
            var description = _ucBusinessAddOnCharges.txtDescription.Text.Trim();
            var appliedEachBusiness = _ucBusinessAddOnCharges.cbxAppliedToEachBusiness.Checked;

            var businessAdOnChargesModel = new BusinessAddOnChargesModel()
            {
                Code = code,
                Description = description,
                IsAppliedEachBusiness = appliedEachBusiness,
                CreatedBy = Helper.UserId
            };

            return AccFactory.BusinessAddOnChargesRepository().Insert(businessAdOnChargesModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Business Add-on has been saved.");
                _frmBusinessAddOnCharges.LoadBusinessAddOnCharges();
                _ucBusinessAddOnCharges.ResetForm();
            }
        }
    }
}