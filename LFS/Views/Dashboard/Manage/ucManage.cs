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
            bool isAdmin = AccFactory.UsersRepository().GetViewRecordById(Helper.userId)["office"] == "SysAdmin";
            panelAdmin.Enabled = isAdmin;

            if (!Helper.HasPermission("Manage > Banks"))
                btnBanks.Enabled = false;

            if (!Helper.HasPermission("Manage > Accountable Forms"))
                btnAccForms.Enabled = false;

            if (!Helper.HasPermission("Manage > Bank Accounts"))
                btnBankAccs.Enabled = false;

            if (!Helper.HasPermission("Manage > Signatories"))
                btnDocSignatories.Enabled = false;

            if (!Helper.HasPermission("Manage > Barangays"))
                btnBarangays.Enabled = false;

            if (!Helper.HasPermission("Manage > Function/Program/Project"))
                btnFpp.Enabled = false;

            if (!Helper.HasPermission("Manage > Users"))
                btnUsers.Enabled = false;

            if (!Helper.HasPermission("Manage > Roles"))
                btnRoles.Enabled = false;
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