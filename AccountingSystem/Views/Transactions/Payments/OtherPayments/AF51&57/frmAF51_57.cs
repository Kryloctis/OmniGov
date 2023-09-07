using AccountingSystem.Views.Manage.TaxPayers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.AF51_57
{
    public partial class frmAF51_57 : Form
    {
        private ucTaxPayers ucTaxPayers;

        public frmAF51_57()
        {
            InitializeComponent();
            ucTaxPayers = ucTaxPayers1;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            tabControlPayee.SelectedTab = tabNewPayee;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (Helper.MessageBoxConfirmCancel("Your input won't be stored."))
            {
                tabControlPayee.SelectedTab = tabPayeeList;
                ucTaxPayers.ResetForm();
            }
        }

        private void bgwPayee_DoWork(object sender, DoWorkEventArgs e)
        {
        }

        private void bgwPayee_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void bgwPayee_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void LoadPayee()
        {
            btnBackMain.Enabled = false;
            radPayee.Checked = true;
        }

        private void LoadFeesAndChargesTab()
        {
            btnBackMain.Enabled = true;
            btnNextMain.Text = "Proceed to Payment";
            radFees.Checked = true;
        }

        private void LoadPaymentTab()
        {
            btnNextMain.Text = "Confirm Payment";
            btnBackMain.Enabled = true;
            radPayment.Checked = true;
        }

        private void ConfirmPayment()
        {
            Helper.MessageBoxConfirmCancel("Confirm Payment?");
        }

        private void ChangeTabs()
        {
            var selectedTab = tabControlMain.SelectedTab;

            if (selectedTab == tabPagePayee)
                tabControlMain.SelectedTab = tabPageFees;
            else if (selectedTab == tabPageFees)
                tabControlMain.SelectedTab = tabPagePayment;
            else if (selectedTab == tabPagePayment)
                ConfirmPayment();
        }

        private void btnNextMain_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeTabs();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnBackMain_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControlMain.SelectedIndex < 0)
                    return;

                tabControlMain.SelectedIndex = tabControlMain.SelectedIndex - 1;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tabPagePayee_Enter(object sender, EventArgs e)
        {
            try
            {
                LoadPayee();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tabPageFees_Enter(object sender, EventArgs e)
        {
            try
            {
                LoadFeesAndChargesTab();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tabPagePayment_Enter(object sender, EventArgs e)
        {
            try
            {
                LoadPaymentTab();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}