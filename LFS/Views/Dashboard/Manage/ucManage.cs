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
using System;
using System.Windows.Forms;

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
            try
            {
                _ = new frmUsers().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmRoles().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnFunds_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmFunds().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnAccForms_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmAccountableForm().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnAllotmentClasses_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmAllotmentClasses().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnFpp_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmFunctionProgramProject().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnBarangays_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmBarangay().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnDocSignatories_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmSignatories().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnRegistry_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmRegistry().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnBanks_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmBanks().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnBankAccs_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmBankAccounts().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnTaxRate_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmRptTaxRates().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnPenalty_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmRptPenalties().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmRptDiscounts().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnChrtAccs_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmChartOfAccounts().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnJrnls_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmJournals().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
