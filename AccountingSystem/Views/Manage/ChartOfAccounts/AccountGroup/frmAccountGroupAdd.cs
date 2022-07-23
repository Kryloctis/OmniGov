using System;
using System.Windows.Forms;
using ACC.Domain.Models;

namespace AccountingSystem.Views.Manage.ChartOfAccounts.AccountGroup
{
    public partial class frmAccountGroupAdd : Form
    {
        private frmChartOfAccounts _frmChartOfAccounts;

        public frmAccountGroupAdd(frmChartOfAccounts frmChartOfAccounts)
        {
            InitializeComponent();
            _frmChartOfAccounts = frmChartOfAccounts;
        }

        private bool SaveData()
        {
            try
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

                var accountGroupRepository = AccFactory.AccountGroupRepository();
                return accountGroupRepository.Insert(accountGroupModel);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }

            return false;
        }

        private void frmAccountGroupAdd_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Account group has been saved.");
                _frmChartOfAccounts.LoadAccountGroup();
                ucAccountGroup1.ResetForm();
            }
        }
    }
}
