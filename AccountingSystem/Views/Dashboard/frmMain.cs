using AccountingSystem.Views.Dashboard.BudgetDashboard.BudgetSummary;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Dashboard
{
    public partial class frmMain : Form
    {
        private ucBudgetSummary ucBudgetSummary;
        private frmSignIn frmSignIn;

        public frmMain(frmSignIn frmSignIn)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            ucBudgetSummary = ucBudgetSummary1;
            this.frmSignIn = frmSignIn;
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
                ucBudgetSummary.OnLoad();
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

        private void radHome_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedTab = tabPageHome;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}