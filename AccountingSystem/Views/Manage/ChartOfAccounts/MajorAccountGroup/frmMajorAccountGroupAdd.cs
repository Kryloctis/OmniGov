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
    public partial class frmMajorAccountGroupAdd : Form
    {
        private readonly frmChartOfAccounts _frmChartOfAccounts;

        public frmMajorAccountGroupAdd(frmChartOfAccounts frmChartOfAccounts)
        {
            InitializeComponent();
            _frmChartOfAccounts = frmChartOfAccounts;
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
                    AccountGroupId = byte.Parse(uc.cmbAccountGroup.SelectedValue.ToString()),
                    MajorAccountGroupCode = uc.txtCode.Text.Trim(),
                    MajorAccountGroupName = uc.txtName.Text.Trim()
                };

                var majorAccountGroupRepository = Factory.MajorAccountGroupRepository();
                return majorAccountGroupRepository.Insert(majorAccountGroupModel);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }

            return false;
        }

        private void frmMajorAccountGroupAdd_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIconAccounting(this);
            ucMajorAccountGroup1.LoadAccountGroup();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Major account group has been saved.");
                ucMajorAccountGroup1.ResetForm();
                _frmChartOfAccounts.LoadMajorAccountGroup();
            }
        }
    }
}
