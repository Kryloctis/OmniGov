using OmniGov.App.Helpers;
using OmniGov.Treasury.Data.Factories;
using OmniGov.Treasury.Domain.Entities;

namespace OmniGov.App.Views.Manage.BusinessAddOnCharges
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Business Add-on has been saved.");
                _frmBusinessAddOnCharges.LoadBusinessAddOnCharges();
                _ucBusinessAddOnCharges.ResetForm();
            }
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
                CreatedBy = UserHelper.loggedUser.Id
            };

            return TreasuryFactory.BusinessAddOnChargesRepository().Insert(businessAdOnChargesModel);
        }
    }
}