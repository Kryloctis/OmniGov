using ACC.Data;
using ACC.Domain.Models;
using LFS;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.ChartOfAccounts.AccountGroup
{
    public partial class frmAccountGroupAdd : Form
    {
        private frmChartOfAccounts _frmChartOfAccounts;

        public frmAccountGroupAdd(frmChartOfAccounts frmChartOfAccounts)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _frmChartOfAccounts = frmChartOfAccounts;
        }

        private bool SaveData()
        {
            var uc = ucAccountGroup1;
            // if error occurs, show messagebox error
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            // proceed to insert
            var accountGroupModel = new AccountGroupModel()
            {
                AccountGroupCode = uc.txtCode.Text.Trim(),
                AccountGroupName = uc.txtName.Text.Trim()
            };

            return AccFactory.AccountGroupRepository().Insert(accountGroupModel);
        }

        private void frmAccountGroupAdd_Load(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Account group has been saved.");
                    _frmChartOfAccounts.LoadAccountGroup();
                    ucAccountGroup1.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}