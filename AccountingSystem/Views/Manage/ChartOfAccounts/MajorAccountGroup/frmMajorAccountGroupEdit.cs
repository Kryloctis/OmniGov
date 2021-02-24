using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.ChartOfAccounts.MajorAccountGroup
{
    public partial class frmMajorAccountGroupEdit : Form
    {
        private readonly frmChartOfAccounts _frmChartOfAccounts;

        public frmMajorAccountGroupEdit(frmChartOfAccounts frmChartOfAccounts, short majorAccountGroupId)
        {
            InitializeComponent();
            _frmChartOfAccounts = frmChartOfAccounts;
            ucMajorAccountGroup1.majorAccountGroupId = majorAccountGroupId;
        }

        private void LoadSelectedRecord()
        {
            try
            {
                var uc = ucMajorAccountGroup1;
                var majorAccountGroupRepository = Factory.MajorAccountGroupRepository();
                Dictionary<string, string> data = majorAccountGroupRepository.GetRecordByID(uc.majorAccountGroupId);

                uc.cmbAccountGroup.SelectedValue = data["account_group_id"];
                uc.txtCode.Text = data["maj_acc_group_code"];
                uc.txtName.Text = data["maj_acc_group_name"];
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool SaveData()
        {
            try
            {
                var uc = ucMajorAccountGroup1;
                // if error occurs, show messagebox error
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                // proceed to insert
                var majorAccountGroupModel = new MajorAccountGroupModel()
                {
                    Id = ucMajorAccountGroup1.majorAccountGroupId,
                    AccountGroupId = byte.Parse(uc.cmbAccountGroup.SelectedValue.ToString()),
                    MajorAccountGroupCode = uc.txtCode.Text.Trim(),
                    MajorAccountGroupName = uc.txtName.Text.Trim()
                };

                return Factory.MajorAccountGroupRepository().Update(majorAccountGroupModel);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }

            return false;
        }

        private void frmMajorAccountGroupEdit_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            ucMajorAccountGroup1.LoadAccountGroup();
            LoadSelectedRecord();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Major account group has been saved.");
                _frmChartOfAccounts.LoadMajorAccountGroup();
            }
        }
    }
}
