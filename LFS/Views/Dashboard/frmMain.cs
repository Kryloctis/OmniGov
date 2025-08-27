using LFS.Helpers;
using LFS.Views.Dashboard.Accounting;
using LFS.Views.Dashboard.Budget;
using LFS.Views.Dashboard.Manage;
using LFS.Views.Dashboard.MyAccount;
using LFS.Views.Dashboard.Reports;
using LFS.Views.Dashboard.Treasury;
using LFS.Views.SignIn;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace LFS.Views.Dashboard
{
    public partial class frmMain : Form
    {
        private frmSignIn frmSignIn;
        private ucBudget ucBudget;
        private ucAccounting ucAccounting;
        private ucTreasury ucTreasury;
        private ucManage ucManage;
        private ucReports ucReports;
        private ucMyAccount ucMyAccount;

        public frmMain(frmSignIn frmSignIn)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.frmSignIn = frmSignIn;
            Helper.RemoveTabcontrolTabs(tabControlMain);

            this.ucBudget = ucBudget1;
            this.ucAccounting = ucAccounting1;
            this.ucTreasury = ucTreasury1;
            this.ucManage = ucManage1;
            this.ucReports = ucReports1;
            this.ucMyAccount = ucMyAccount1;
        }

        private void VerifyUserPrivileges()
        {
            UserPrivileges();
        }

        private void UserPrivileges()
        {
            if (!PrivilegesHelper.HasPrivilege(Privileges.DashBudget))
            {
                tabControlMain.TabPages.Remove(tabPageBudget);
                radBudget.Visible = false;
            }

            if (!PrivilegesHelper.HasPrivilege(Privileges.DashAccounting))
            {
                tabControlMain.TabPages.Remove(tabPageAccounting);
                radAccounting.Visible = false;
            }

            if (!PrivilegesHelper.HasPrivilege(Privileges.DashTreasury))
            {
                tabControlMain.TabPages.Remove(tabPageTreasury);
                radTreasury.Visible = false;
            }

        }

        private void radBudget_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tabControlMain.SelectedTab = tabPageBudget;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadTabPagesContents(TabControl tabControl)
        {
            switch (tabControl.SelectedTab.Name)
            {
                case "tabPageBudget":
                    ucBudget.OnloadEvent();
                    radBudget.Checked = true;
                    break;

                case "tabPageAccounting":
                    ucAccounting.OnLoad();
                    radAccounting.Checked = true;
                    break;

                case "tabPageTreasury":
                    ucTreasury.OnLoad();
                    radTreasury.Checked = true;
                    break;

                case "tabPageSettings":
                    ucManage.OnLoad();
                    radManage.Checked = true;
                    break;

                case "tabPageReports":
                    ucReports.OnLoad();
                    radReports.Checked = true;
                    break;

                case "tabPageMyAccount":
                    ucMyAccount.OnLoad(this, frmSignIn);
                    radioBtnMyAccount.Checked = true;
                    break;
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                tlStrpLblServer.Text = ServerHelper.selectedServer.MunicipalityName;
                tlStrpLblVersion.Text = $"Version: {Helper.version}";
                VerifyUserPrivileges();
                LoadTabPagesContents(tabControlMain);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void radAccounting_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tabControlMain.SelectedTab = tabPageAccounting;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void radTreasury_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tabControlMain.SelectedTab = tabPageTreasury;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                if (Helper.MessageBoxConfirm("Logout Now?"))
                {
                    Close();
                    frmSignIn.Show();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                frmSignIn.Show();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void radManage_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tabControlMain.SelectedTab = tabPageManage;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadTabPagesContents(tabControlMain);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void radReports_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tabControlMain.SelectedTab = tabPageReports;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void radioBtnMyAccount_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tabControlMain.SelectedTab = tabPageMyAccount;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tlStrpWhatsNew_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = Helper.updateReleaseLnk,
                    UseShellExecute = true
                });
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}