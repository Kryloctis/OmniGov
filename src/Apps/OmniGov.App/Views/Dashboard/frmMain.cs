using OmniGov.App.Accounting.Views.Dashboard;
using OmniGov.App.Budget.Views.Dashboard;
using OmniGov.App.Helpers;
using OmniGov.App.Views.Dashboard.Manage;
using OmniGov.App.Views.Dashboard.MyAccount;
using OmniGov.App.Views.Dashboard.Reports;
using OmniGov.App.Views.Dashboard.Treasury;
using OmniGov.App.Views.SignIn;
using System.Diagnostics;

namespace OmniGov.App.Views.Dashboard
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
            this.ShowInTaskbar = true;
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
            tabControlMain.SelectedTab = tabPageBudget;
        }

        private void LoadTabPagesContents(TabControl tabControl)
        {
            switch (tabControl.SelectedTab.Name)
            {
                case "tabPageBudget":
                    ucBudget.OnLoad();
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

                case "tabPageManage":
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
            tlStrpLblServer.Text = $"Server: {ServerHelper.SelectedProfile?.Name} ({ServerHelper.SelectedProfile?.ProvinceName})";
            tlStrpLblVersion.Text = $"Version:{Helper.version}";
            tlStrpLblLoggedUser.Text = $"Logged User:{UserHelper.loggedUser?.FullName ?? "Unknown"}";
            VerifyUserPrivileges();
            LoadTabPagesContents(tabControlMain);
        }

        private void radAccounting_CheckedChanged(object sender, EventArgs e)
        {
            tabControlMain.SelectedTab = tabPageAccounting;
        }

        private void radTreasury_CheckedChanged(object sender, EventArgs e)
        {
            tabControlMain.SelectedTab = tabPageTreasury;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (Helper.MessageBoxConfirm("Logout Now?"))
            {
                this.Close();
            }
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Do nothing, the caller (frmSignIn) handles showing itself.
        }

        private void radManage_CheckedChanged(object sender, EventArgs e)
        {
            tabControlMain.SelectedTab = tabPageManage;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTabPagesContents(tabControlMain);
        }

        private void radReports_CheckedChanged(object sender, EventArgs e)
        {
            tabControlMain.SelectedTab = tabPageReports;
        }

        private void radioBtnMyAccount_CheckedChanged(object sender, EventArgs e)
        {
            tabControlMain.SelectedTab = tabPageMyAccount;
        }

        private void tlStrpWhatsNew_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = Helper.updateReleaseLnk,
                UseShellExecute = true
            });
        }
    }
}