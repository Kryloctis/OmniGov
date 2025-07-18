using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace LFS.Views.Manage.ChartOfAccounts.MajorAccountGroup
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

            return AccFactory.MajorAccountGroupRepository().Insert(majorAccountGroupModel);
        }

        private void frmMajorAccountGroupAdd_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            uc.LoadAccountGroup();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Major account group has been saved.");
                    uc.ResetForm();
                    _frmChartOfAccounts.LoadMajorAccountGroup();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}