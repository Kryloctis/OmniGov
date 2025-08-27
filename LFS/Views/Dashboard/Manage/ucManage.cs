using ACC.Data;
using LFS.Helpers;
using LFS.Views.Manage.AccountableForm;
using LFS.Views.Manage.AllotmentClasses;
using LFS.Views.Manage.BankAccounts;
using LFS.Views.Manage.Banks;
using LFS.Views.Manage.Barangay;
using LFS.Views.Manage.FunctionProgramProject;
using LFS.Views.Manage.Funds;
using LFS.Views.Manage.Registry;
using LFS.Views.Manage.RptDiscount;
using LFS.Views.Manage.RptPenalties;
using LFS.Views.Manage.RptTaxRates;
using LFS.Views.Manage.Signatories;
using LFS.Views.Manage.Users;
using LFS.Views.Manage.Users.Roles;
using System;
using System.Windows.Forms;

namespace LFS.Views.Dashboard.Manage
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
    }
}