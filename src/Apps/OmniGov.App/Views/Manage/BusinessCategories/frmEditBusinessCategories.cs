using OmniGov.App.Helpers;
using OmniGov.Treasury.Data.Factories;
using OmniGov.Treasury.Domain.Entities;

namespace OmniGov.App.Views.Manage.BusinessCategories
{
    public partial class frmEditBusinessCategories : Form
    {
        private readonly frmBusinessCategories _frmBusinessCategories;
        private readonly ucBusinessCategories _ucBusinessCategories;
        private int _businessCategoriesID;

        public frmEditBusinessCategories(int businessCategoriesID, frmBusinessCategories frmBusinessCategories)
        {
            InitializeComponent();
            _ucBusinessCategories = ucBusinessCategories1;
            _businessCategoriesID = businessCategoriesID;
            _frmBusinessCategories = frmBusinessCategories;
            _ucBusinessCategories.businessCategoryID = businessCategoriesID;
            _ucBusinessCategories.isEdit = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UpdateBusinessCategories())
            {
                Helper.MessageBoxSuccess("Business Categories has been updated.");
                _frmBusinessCategories.LoadBusinessCategories();
                Helper.DatagridViewRecordFinder(_frmBusinessCategories.dgBusinessCategories, "id", _businessCategoriesID.ToString());
                Close();
            }
        }

        private void frmEditBusinessCategories_Load(object sender, EventArgs e)
        {
            OnLoad();
        }

        private void LoadSelectedRecord()
        {
            var dictBusinessCategories = TreasuryFactory.BusinessCategoriesRepository().GetRecordByID(_businessCategoriesID);

            var isLineOfBusiness = Convert.ToInt16(dictBusinessCategories["is_line_of_business"]);

            _ucBusinessCategories.txtCode.Text = dictBusinessCategories["code"];
            _ucBusinessCategories.txtOrdinanceReferenceNo.Text = dictBusinessCategories["ordinance_ref_no"];
            _ucBusinessCategories.txtDescription.Text = dictBusinessCategories["description"];
            _ucBusinessCategories.cbxLineOfBusiness.Checked = Convert.ToBoolean(isLineOfBusiness);
        }

        private void OnLoad()
        {
            LoadSelectedRecord();
        }

        private bool UpdateBusinessCategories()
        {
            if (!_ucBusinessCategories.ValidateChildren())
            {
                Helper.MessageBoxError(_ucBusinessCategories.GetFormErrors());
                return false;
            }

            var code = _ucBusinessCategories.txtCode.Text.Trim();
            var ordinanceReferenceNo = _ucBusinessCategories.txtOrdinanceReferenceNo.Text.Trim();
            var description = _ucBusinessCategories.txtDescription.Text.Trim();
            var lineInBusiness = _ucBusinessCategories.cbxLineOfBusiness.Checked;

            var businessCategoriesModel = new BusinessCategoriesModel()
            {
                BusinessCategoryID = _businessCategoriesID,
                Code = code,
                OrdinanceReferenceNumber = ordinanceReferenceNo,
                Description = description,
                LineOfBusiness = lineInBusiness
            };

            return TreasuryFactory.BusinessCategoriesRepository().Update(businessCategoriesModel);
        }
    }
}