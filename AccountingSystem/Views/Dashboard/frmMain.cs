using ACC.Data;
using AccountingSystem.Views.Dashboard.Accounting;
using AccountingSystem.Views.Dashboard.AccountingDashboard;
using AccountingSystem.Views.Dashboard.Budget;
using AccountingSystem.Views.Dashboard.Settings;
using AccountingSystem.Views.Dashboard.Treasury;
using Org.BouncyCastle.Asn1.Esf;
using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AccountingSystem.Views.Dashboard
{
    public partial class frmMain : Form
    {
        private frmSignIn frmSignIn;
        private ucBudget ucBudget;
        private ucAccounting ucAccounting;
        private ucTreasury ucTreasury;
        private ucSettings ucSettings;

        public frmMain(frmSignIn frmSignIn)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.frmSignIn = frmSignIn;

            //Removes tabs to tabcontrol
            tabControlMain.Padding = new Point(0, 0);
            tabControlMain.ItemSize = new Size(0, 1);
            tabControlMain.SizeMode = TabSizeMode.Fixed;
            tabControlMain.Appearance = TabAppearance.FlatButtons;
            tabControlMain.DrawMode = TabDrawMode.OwnerDrawFixed;

            this.ucBudget = ucBudget1;
            this.ucAccounting = ucAccounting1;
            this.ucTreasury = ucTreasury1;
            this.ucSettings = ucSettings1;
        }

        #region Permission Validations

        private void ValidatePermissions()
        {
            ValidateMainPermissions();
        }

        private void ValidateMainPermissions()
        {
            if (!Helper.HasPermission("Dashboard > Budget"))
            {
                tabControlMain.TabPages.Remove(tabPageBudget);
                radBudget.Visible = false;
            }

            if (!Helper.HasPermission("Dashboard > Accounting"))
            {
                tabControlMain.TabPages.Remove(tabPageAccounting);
                radAccounting.Visible = false;
            }

            if (!Helper.HasPermission("Dashboard > Treasury"))
            {
                tabControlMain.TabPages.Remove(tabPageTreasury);
                radTreasury.Visible = false;
            }
        }


        #endregion Permission Validations

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
                    ucSettings.OnLoad();
                    radSettings.Checked = true;
                    break;
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                ValidatePermissions();
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
                this.Close();
                frmSignIn.Show();
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

        private void radSettings_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tabControlMain.SelectedTab = tabPageSettings;
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
    }
}