using AccountingSystem.Views.Dashboard.BudgetDashboard.BudgetSummary;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AccountingSystem.Views.Dashboard
{
    public partial class frmMain : Form
    {
        private frmSignIn frmSignIn;

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
        }

        private void radBudget_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedTab = tabPageBudget;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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
    }
}