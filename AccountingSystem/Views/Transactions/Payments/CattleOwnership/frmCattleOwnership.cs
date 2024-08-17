using ACC.Data;
using AccountingSystem.Views.Transactions.Payments.BurialPermit;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.CattleOwnership
{
    public partial class frmCattleOwnership : Form
    {
        private readonly ucPayment ucPayment;
        private readonly ucPaymentFeesCharges ucPaymentFeesCharges;
        private readonly ucCattleOwnership ucCattleOwnership;
        private ucPrintReceipt ucPrintReceipt;

        public frmCattleOwnership()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.RemoveTabcontrolTabs(tabControlMain);
            ucPayment = ucPayment1;
            ucPaymentFeesCharges = ucPaymentFeesCharges1;
            ucCattleOwnership = ucCattleOwnership1;
            ucPrintReceipt = ucPrintReceipt1;
        }

        private void ResetForm()
        {
            ucPayment.ResetForm();
            ucPaymentFeesCharges.ResetForm();
            ucCattleOwnership.ResetForm();
            tabControlMain.SelectedIndex = 0;
        }

        private void OnLoad()
        {
            LoadTabContents();
            ucCattleOwnership.OnLoad();
        }

        private bool TabValidated()
        {
            switch (tabControlMain.SelectedTab.Name)
            {
                case "tabPageCattleOwnership":
                    if (!ucCattleOwnership.ValidateChildren())
                    {
                        Helper.MessageBoxError(ucCattleOwnership.GetFormErrors());
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

        private void LoadCattleDetailsTab()
        {
            btnNextMain.Text = "Next";
            radCattleOwnershipInfo.Checked = true;
        }

        private void LoadFeesAndChargesTab()
        {
            radFeesCharges.Checked = true;
            btnNextMain.Text = "Proceed to Payment";
            btnBackMain.Enabled = true;
            radFeesCharges.Checked = true;
            ucPaymentFeesCharges.OnLoad();
        }

        private void LoadPaymentTab()
        {
            radPayment.Checked = true;
            btnNextMain.Text = "Confirm Payment";
            btnBackMain.Enabled = true;
            radPayment.Checked = true;

            decimal totalAmountPayable = ucPaymentFeesCharges.ComputeTotalAmountPayable();
            ucPayment.OnLoad(Helper.userId, "53", totalAmountPayable);
        }

        private void InitializeReceipt()
        {
            var frmAF53Receipt = new frmCattleOwnershipReceipt();
            var taxpayerId = ucCattleOwnership.CattleOwnershipModel().TaxpayerId;
            var dictTaxpayer = AccFactory.TaxpayersRepository().GetViewRecordById(taxpayerId);

            var reportParameters = new frmCattleOwnershipReceipt.AF53Parameters
            {
                Municipality = Helper.selectedServerModel.MunicipalityName.ToUpper(),
                Province = Helper.selectedServerModel.ProvinceName.ToUpper(),
                TransactionDate = ucPayment.PaymentCollectionsModel().PaymentDate,
                OwnerName = dictTaxpayer["taxpayers_name"],
                OwnerMunicipality = dictTaxpayer["taxpayers_municipality"],
                OwnerProvince = dictTaxpayer["taxpayers_province"],
                CattleName = ucCattleOwnership.CattleOwnershipModel().CattleName,
                CattleAge = ucCattleOwnership.CattleOwnershipModel().CattleAge,
                CattleSex = ucCattleOwnership.CattleOwnershipModel().CattleSex,
                MunicipalTreasurerName = string.Empty,
                MunicipalSecretaryName = string.Empty,
                MunicipalMayor = string.Empty,
            };
        }

        private void LoadReceiptTab()
        {
            btnNextMain.Text = "New Transaction";
            InitializeReceipt();
        }

        private void LoadTabContents()
        {
            if (tabControlMain.SelectedIndex == 0)
                btnBackMain.Enabled = false;
            else
                btnBackMain.Enabled = true;

            switch (tabControlMain.SelectedTab.Name)
            {
                case "tabPageCattleOwnership":
                    LoadCattleDetailsTab();
                    break;

                case "tabPageFeesCharges":
                    LoadFeesAndChargesTab();
                    break;

                case "tabPagePayment":
                    LoadPaymentTab();
                    break;

                case "tabPageReceipt":
                    LoadReceiptTab();
                    break;
            }
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadTabContents();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool ConfirmPayment()
        {
            return AccFactory.PaymentCollectionsRepository().InsertWithCattleOwnershipPayment(ucPayment.PaymentCollectionsModel(), null, ucCattleOwnership.CattleOwnershipModel(), ucPaymentFeesCharges.PaymentFeesChargesModels());
        }

        private void btnNextMain_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TabValidated())
                    return;

                if (tabControlMain.SelectedTab.Name == "tabPagePayment" && TabValidated())
                {
                    if (Helper.MessageBoxConfirmCancel("Confirm Payment..."))
                    {
                        tabControlMain.SelectedIndex++;

                        //if (ConfirmPayment())
                        //{
                        //    return;
                        //}
                    }
                    return;
                }

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

        private void frmCattleOwnership_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}