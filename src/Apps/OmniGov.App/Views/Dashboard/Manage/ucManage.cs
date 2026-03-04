using OmniGov.App.Helpers;
using OmniGov.App.Views.Manage.AccountableForm;
using OmniGov.App.Views.Manage.AllotmentClasses;
using OmniGov.App.Views.Manage.BankAccounts;
using OmniGov.App.Views.Manage.Banks;
using OmniGov.App.Views.Manage.Barangay;
using OmniGov.App.Views.Manage.ChartOfAccounts;
using OmniGov.App.Views.Manage.FunctionProgramProject;
using OmniGov.App.Views.Manage.Funds;
using OmniGov.App.Views.Manage.Journals;
using OmniGov.App.Views.Manage.Registry;
using OmniGov.App.Views.Manage.Roles;
using OmniGov.App.Views.Manage.RptDiscounts;
using OmniGov.App.Views.Manage.RptPenalties;
using OmniGov.App.Views.Manage.RptTaxRates;
using OmniGov.App.Views.Manage.Signatories;
using OmniGov.App.Views.Manage.Users;

namespace OmniGov.App.Views.Dashboard.Manage
{
    public partial class ucManage : UserControl
    {
        public ucManage()
        {
            InitializeComponent();
        }

        internal void OnLoad()
        {
            ValidatePermissions();
        }

        private void ValidatePermissions()
        {
            panelAdmin.Enabled = UserHelper.loggedUser.isSuper;
            btnBanks.Enabled = PrivilegesHelper.HasPrivilege(Privileges.MngBanks);
            btnBankAccs.Enabled = PrivilegesHelper.HasPrivilege(Privileges.MngBankAccounts);
            btnAccForms.Enabled = PrivilegesHelper.HasPrivilege(Privileges.MngAccForms);
            btnDocSignatories.Enabled = PrivilegesHelper.HasPrivilege(Privileges.MngSignatories);
            btnBarangays.Enabled = PrivilegesHelper.HasPrivilege(Privileges.MngBarangays);
            btnFpp.Enabled = PrivilegesHelper.HasPrivilege(Privileges.MngFuncProgProj);
            btnUsers.Enabled = PrivilegesHelper.HasPrivilege(Privileges.MngUsers);
            btnRoles.Enabled = PrivilegesHelper.HasPrivilege(Privileges.MngRoles);
            btnChrtAccs.Enabled = PrivilegesHelper.HasPrivilege(Privileges.MngChartAccounts);
            btnJrnls.Enabled = PrivilegesHelper.HasPrivilege(Privileges.MngJournals);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            _ = new frmUsers().ShowDialog();
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            _ = new frmRoles().ShowDialog();
        }

        private void btnFunds_Click(object sender, EventArgs e)
        {
            _ = new frmFunds().ShowDialog();
        }

        private void btnAccForms_Click(object sender, EventArgs e)
        {
            _ = new frmAccountableForm().ShowDialog();
        }

        private void btnAllotmentClasses_Click(object sender, EventArgs e)
        {
            _ = new frmAllotmentClasses().ShowDialog();
        }

        private void btnFpp_Click(object sender, EventArgs e)
        {
            _ = new frmFunctionProgramProject().ShowDialog();
        }

        private void btnBarangays_Click(object sender, EventArgs e)
        {
            _ = new frmBarangay().ShowDialog();
        }

        private void btnDocSignatories_Click(object sender, EventArgs e)
        {
            _ = new frmSignatories().ShowDialog();
        }

        private void btnRegistry_Click(object sender, EventArgs e)
        {
            _ = new frmRegistry().ShowDialog();
        }

        private void btnBanks_Click(object sender, EventArgs e)
        {
            _ = new frmBanks().ShowDialog();
        }

        private void btnBankAccs_Click(object sender, EventArgs e)
        {
            _ = new frmBankAccounts().ShowDialog();
        }

        private void btnTaxRate_Click(object sender, EventArgs e)
        {
            _ = new frmRptTaxRates().ShowDialog();
        }

        private void btnPenalty_Click(object sender, EventArgs e)
        {
            _ = new frmRptPenalties().ShowDialog();
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            _ = new frmRptDiscounts().ShowDialog();
        }

        private void btnChrtAccs_Click(object sender, EventArgs e)
        {
            _ = new frmChartOfAccounts().ShowDialog();
        }

        private void btnJrnls_Click(object sender, EventArgs e)
        {
            _ = new frmJournals().ShowDialog();
        }
    }
}