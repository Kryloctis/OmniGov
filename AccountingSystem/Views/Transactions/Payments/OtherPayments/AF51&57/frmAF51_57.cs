using ACC.Data;
using AccountingSystem.Views.Manage.FeesChargesConfig.FeesCharges;
using AccountingSystem.Views.Manage.TaxPayers;
using AccountingSystem.Views.Transactions.Payments.OtherPayments.BurialPermit;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.AF51_57
{
    public partial class frmAF51_57 : Form
    {
        private readonly ucPaymentRegistry ucPaymentRegistry;
        private readonly ucPaymentFeesCharges ucPaymentFeesCharges;
        private readonly ucPayment ucPayment;

        public frmAF51_57()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.ucPaymentFeesCharges = ucPaymentFeesCharges1;
            this.ucPaymentRegistry = ucPaymentRegistry1;
            this.ucPayment = ucPayment1;
        }

        #region Private Methods

        private void LoadPayeeTab()
        {
            radPayee.Checked = true;
            btnNextMain.Text = "Next";
        }

        private void LoadFeesAndChargesTab()
        {
            btnNextMain.Text = "Proceed to Payment";
            btnBackMain.Enabled = true;
            radFeesCharges.Checked = true;
            ucPaymentFeesCharges.OnLoad();
        }

        private void LoadPaymentTab()
        {
            btnNextMain.Text = "Confirm Payment";
            btnBackMain.Enabled = true;
            radPayment.Checked = true;

            decimal totalAmountPayable = ucPaymentFeesCharges.ComputeTotalAmountPayable();
            ucPayment1.OnLoad(string.Empty, totalAmountPayable);

            //if (isNewPayee)
            //    ucPayment.txtPayee.Text = ucTaxPayers.txtName.Text;
            //else
            //ucPayment.txtPayee.Text = GetTaxPayerData()["taxpayer_name"];
        }

        private void ConfirmPayment()
        {
            Helper.MessageBoxConfirmCancel("Confirm Payment?");
        }

        private bool TabValidated()
        {
            switch (tabControlMain.SelectedTab.Name)
            {
                case "tabPagePayee":
                    if (!ucPaymentRegistry.FormValidated("payee"))
                    {
                        Helper.MessageBoxError(ucPaymentRegistry.GetFormErrors());
                        return false;
                    }
                    break;

                case "tabPageFeesCharges":

                    if (!ucPaymentFeesCharges.ValidateChildren())
                    {
                        Helper.MessageBoxError(ucPaymentFeesCharges.GetFormErrors());
                        return false;
                    }
                    break;

                case "tabPagePayment":
                    if (!ucPayment.ValidateChildren())
                    {
                        Helper.MessageBoxError(ucPayment.GetFormErrors());
                        return false;
                    }
                    break;

                default:
                    return true;
            }

            return true;
        }

        private void OnLoad()
        {
            LoadTabContents();
            ucPaymentRegistry.LoadRegistry();
        }

        #endregion Private Methods

        #region Event Methods

        private void LoadTabContents()
        {
            if (tabControlMain.SelectedIndex == 0)
                btnBackMain.Enabled = false;
            else
                btnBackMain.Enabled = true;

            switch (tabControlMain.SelectedTab.Name)
            {
                case "tabPagePayee":
                    LoadPayeeTab();
                    break;

                case "tabPageFeesCharges":
                    LoadFeesAndChargesTab();
                    break;

                case "tabPagePayment":
                    radPayment.Checked = true;
                    LoadPaymentTab();
                    //ConfirmPayment();
                    break;
            }
        }

        private void btnNextMain_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TabValidated())
                    return;

                tabControlMain.SelectedIndex++;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnBackMain_Click(object sender, EventArgs e)
        {
            try
            {
                tabControlMain.SelectedIndex--;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmAF51_57_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadTabContents();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        #endregion Event Methods
    }
}