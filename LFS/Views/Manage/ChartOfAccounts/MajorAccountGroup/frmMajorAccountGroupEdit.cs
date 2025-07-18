using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LFS.Views.Manage.ChartOfAccounts.MajorAccountGroup
{
    public partial class frmMajorAccountGroupEdit : Form
    {
        private readonly frmChartOfAccounts _frmChartOfAccounts;
        private UcMajorAccountGroup uc;

        public frmMajorAccountGroupEdit(frmChartOfAccounts frmChartOfAccounts, short majorAccountGroupId)
        {
            InitializeComponent();
            _frmChartOfAccounts = frmChartOfAccounts;
            uc = ucMajorAccountGroup1;
            uc.majorAccountGroupId = majorAccountGroupId;
        }

        private void LoadSelectedRecord()
        {
            Dictionary<string, string> data = AccFactory.MajorAccountGroupRepository().GetRecordByID(uc.majorAccountGroupId);

            uc.cmbAccountGroup.SelectedValue = data["account_group_id"];
            uc.txtCode.Text = data["maj_acc_group_code"];
            uc.txtName.Text = data["maj_acc_group_name"];
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
                Id = uc.majorAccountGroupId,
                AccountGroupId = byte.Parse(uc.cmbAccountGroup.SelectedValue.ToString()),
                MajorAccountGroupCode = uc.txtCode.Text.Trim(),
                MajorAccountGroupName = uc.txtName.Text.Trim()
            };

            return AccFactory.MajorAccountGroupRepository().Update(majorAccountGroupModel);
        }

        private void frmMajorAccountGroupEdit_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            uc.LoadAccountGroup();
            LoadSelectedRecord();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Major account group has been saved.");
                    _frmChartOfAccounts.LoadMajorAccountGroup();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}