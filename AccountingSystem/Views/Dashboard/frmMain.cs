using AccountingSystem.Views.Dashboard.Accounting;
using AccountingSystem.Views.Dashboard.Budget;
using AccountingSystem.Views.Dashboard.Settings;
using AccountingSystem.Views.Dashboard.Treasury;
using System;
using System.Drawing;
using System.Windows.Forms;

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
            tabControl1.Padding = new Point(0, 0);
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;

            this.ucBudget = ucBudget1;
            this.ucAccounting = ucAccounting1;
            this.ucTreasury = ucTreasury1;
            this.ucSettings = ucSettings1;
        }

        private void radBudget_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedTab = tabPageBudget;
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
                    radAccounting.Checked = true;
                    break;

                case "tabPageTreasury":
                    radTreasury.Checked = true;
                    break;

                case "tabPageSettings":
                    radSettings.Checked = true;
                    break;
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void radAccounting_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedTab = tabPageAccounting;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void radTreasury_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedTab = tabPageTreasury;
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
                tabControl1.SelectedTab = tabPageSettings;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadTabPagesContents(tabControl1);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}