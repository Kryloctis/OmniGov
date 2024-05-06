using AccountingSystem.Views.Manage.AccountableForm;
using AccountingSystem.Views.Manage.AllotmentClasses;
using AccountingSystem.Views.Manage.BankAccounts;
using AccountingSystem.Views.Manage.Banks;
using AccountingSystem.Views.Manage.Barangay;
using AccountingSystem.Views.Manage.FunctionProgramProject;
using AccountingSystem.Views.Manage.Funds;
using AccountingSystem.Views.Manage.Registry;
using AccountingSystem.Views.Manage.Signatories;
using AccountingSystem.Views.Manage.Users.List;
using AccountingSystem.Views.Manage.Users.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Dashboard.Settings
{
    public partial class ucSettings : UserControl
    {
        public ucSettings()
        {
            InitializeComponent();
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
    }
}