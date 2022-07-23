using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACC.Domain.Models;

namespace AccountingSystem.Views.Manage.ChartOfAccounts.AccountGroup
{
    public partial class frmAccountGroupEdit : Form
    {
        private readonly frmChartOfAccounts _frmChartOfAccounts;

        public frmAccountGroupEdit(frmChartOfAccounts frmChartOfAccounts, byte _accountGroupId)
        {
            InitializeComponent();
            _frmChartOfAccounts = frmChartOfAccounts;
            ucAccountGroup1.accountGroupId = _accountGroupId;
        }

        private void LoadSelectedRecord()
        {
            try
            {
                var uc = ucAccountGroup1;
                var accountGroupRepository = AccFactory.AccountGroupRepository();
                Dictionary<string, string> accountGroupData = accountGroupRepository.GetRecordByID(uc.accountGroupId);

                uc.txtCode.Text = accountGroupData["account_group_code"];
                uc.txtName.Text = accountGroupData["account_group_name"];
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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

                // proceed to update
                var accountGroupModel = new AccountGroupModel()
                {
                    Id = uc.accountGroupId,
                    AccountGroupCode = uc.txtCode.Text.Trim(),
                    AccountGroupName = uc.txtName.Text.Trim()
                };

                var accountGroupRepository = AccFactory.AccountGroupRepository();
                return accountGroupRepository.Update(accountGroupModel);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }

            return false;
        }

        private void frmAccountGroupEdit_Load(object sender, EventArgs e)
        {
            LoadSelectedRecord();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Account group has been saved.");
                _frmChartOfAccounts.LoadAccountGroup();
            }
        }
    }
}
