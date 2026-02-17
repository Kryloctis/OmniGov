using LFS.Helpers;
using OmniGov.Core.Entities;
using OmniGov.Core.Repositories;
using OmniGov.Core.Factories;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LFS.Views.Manage.ChartOfAccounts.AccountGroup
{
    public partial class frmAccountGroupEdit : Form
    {
        private readonly frmChartOfAccounts _frmChartOfAccounts;
        private UcAccountGroup uc;

        public frmAccountGroupEdit(frmChartOfAccounts frmChartOfAccounts, byte _accountGroupId)
        {
            InitializeComponent();
            _frmChartOfAccounts = frmChartOfAccounts;
            uc = ucAccountGroup1;
            uc.accountGroupId = _accountGroupId;
        }

        private void LoadSelectedRecord()
        {
            Dictionary<string, string> accountGroupData = Factory.AccountGroupRepository().GetRecordByID(uc.accountGroupId);

            uc.txtCode.Text = accountGroupData["account_group_code"];
            uc.txtName.Text = accountGroupData["account_group_name"];
        }

        private bool SaveData()
        {
            // if error occurs, show messagebox error
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            // proceed to update
            var accountGroupModel = new AccountGroupModel()
            {
                Id = uc.accountGroupId,
                AccountGroupCode = uc.txtCode.Text.Trim(),
                AccountGroupName = uc.txtName.Text.Trim()
            };

            return Factory.AccountGroupRepository().Update(accountGroupModel);
        }

        private void OnLoad()
        {
            LoadSelectedRecord();
        }

        private void frmAccountGroupEdit_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Account group has been saved.");
                    _frmChartOfAccounts.LoadAccountGroup();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}

