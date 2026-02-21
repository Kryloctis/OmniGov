using OmniGov.App.Helpers;
using OmniGov.Treasury.Data.Factories;
using OmniGov.Treasury.Domain.Entities;

namespace OmniGov.App.Views.Manage.BusinessAddOnCharges
{
    public partial class frmEditBusinessAddOnCharges : Form
    {
        private int _businessAddOnChargesID;
        private readonly frmBusinessAddOnCharges _frmBusinessAddOnCharges;
        private readonly ucBusinessAddOnCharges _ucBusinessAddOnCharges;

        public frmEditBusinessAddOnCharges(int businessAddOnChargesID, frmBusinessAddOnCharges frmBusinessAdOnCharges)
        {
            InitializeComponent();
            _ucBusinessAddOnCharges = ucBusinessAddOnCharges1;
            _ucBusinessAddOnCharges.id = businessAddOnChargesID;
            _businessAddOnChargesID = businessAddOnChargesID;
            _frmBusinessAddOnCharges = frmBusinessAdOnCharges;
            _ucBusinessAddOnCharges.isEdit = true;
        }

        private void frmEditBusinessAddOnCharges_Load(object sender, EventArgs e)
        {
            LoadSelectedRecord();
        }

        private void LoadSelectedRecord()
        {
            var dictBusinessAddOnCharges = TreasuryFactory.BusinessAddOnChargesRepository().GetRecordByID(_businessAddOnChargesID);

            var appliedEachBusiness = Convert.ToInt16(dictBusinessAddOnCharges["is_applied_each_business"]);
            _ucBusinessAddOnCharges.txtCode.Text = dictBusinessAddOnCharges["code"];
            _ucBusinessAddOnCharges.txtDescription.Text = dictBusinessAddOnCharges["description"];
            _ucBusinessAddOnCharges.cbxAppliedToEachBusiness.Checked = Convert.ToBoolean(appliedEachBusiness);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateBusinessAddOnCharges())
                {
                    Helper.MessageBoxSuccess("Business Add-on has been updated.");
                    _frmBusinessAddOnCharges.LoadBusinessAddOnCharges();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool UpdateBusinessAddOnCharges()
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
                BusinessAddOnChargesID = _businessAddOnChargesID,
                Code = code,
                Description = description,
                IsAppliedEachBusiness = appliedEachBusiness,
                CreatedBy = UserHelper.loggedUser.Id
            };

            return TreasuryFactory.BusinessAddOnChargesRepository().Update(businessAdOnChargesModel);
        }
    }
}
