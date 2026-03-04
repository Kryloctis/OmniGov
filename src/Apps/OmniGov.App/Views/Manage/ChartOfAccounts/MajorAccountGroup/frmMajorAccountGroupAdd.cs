using OmniGov.App.Helpers;
using OmniGov.Core.Entities;
using OmniGov.Core.Factories;

namespace OmniGov.App.Views.Manage.ChartOfAccounts.MajorAccountGroup
{
    public partial class frmMajorAccountGroupAdd : Form
    {
        private readonly frmChartOfAccounts _frmChartOfAccounts;
        private UcMajorAccountGroup uc;

        public frmMajorAccountGroupAdd(frmChartOfAccounts frmChartOfAccounts)
        {
            InitializeComponent();
            _frmChartOfAccounts = frmChartOfAccounts;
            uc = ucMajorAccountGroup1;
        }

        private bool SaveData()
        {
            // if error occurs, show messagebox error
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            // proceed to insert
            var majorAccountGroupModel = new MajorAccountGroupModel()
            {
                AccountGroupId = byte.Parse(uc.cmbAccountGroup.SelectedValue.ToString()),
                MajorAccountGroupCode = uc.txtCode.Text.Trim(),
                MajorAccountGroupName = uc.txtName.Text.Trim()
            };

            return Factory.MajorAccountGroupRepository().Insert(majorAccountGroupModel);
        }

        private void frmMajorAccountGroupAdd_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            uc.LoadAccountGroup();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Major account group has been saved.");
                uc.ResetForm();
                _frmChartOfAccounts.LoadMajorAccountGroup();
            }
        }
    }
}