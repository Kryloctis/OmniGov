using ACC.Data;
using LFS.Views.Transactions.Payments.BurialPermit;
using LFS.Views.Transactions.Payments.OtherPayments.CattleTransferOfOwnership;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LFS.Views.Transactions.Payments.CattleTransferOfOwnership
{
    public partial class frmCattleTransfer : Form
    {
        private readonly ucPayment ucPayment;
        private readonly ucPaymentFeesCharges ucPaymentFeesCharges;
        private readonly ucCattleTransfer ucCattleTransfer;
        private ucPrintReceipt ucPrintReceipt;

        public frmCattleTransfer()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.RemoveTabcontrolTabs(tabControlMain);
            ucPayment = ucPayment1;
            ucPaymentFeesCharges = ucPaymentFeesCharges1;
            ucCattleTransfer = ucCattleTransfer1;
            ucPrintReceipt = ucPrintReceipt1;
        }

        private void OnLoad()
        {
            LoadTabContents();
            ucCattleTransfer.OnLoad();
        }

        private void LoadTabContents()
        {
            if (tabControlMain.SelectedIndex == 0)
                btnBackMain.Enabled = false;
            else
                btnBackMain.Enabled = true;

            switch (tabControlMain.SelectedTab.Name)
            {
                case "tabPageCattleTransfer":
                    LoadCattleTransferTab();
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

        private void LoadCattleTransferTab()
        {
            btnNextMain.Text = "Next";
            radCattleTransfer.Checked = true;
        }

        private void LoadFeesAndChargesTab()
        {
            radFeesCharges.Checked = true;
            btnNextMain.Text = "Proceed to Payment";
            btnBackMain.Enabled = true;
            ucPaymentFeesCharges.OnLoad();
        }

        private void LoadPaymentTab()
        {
            radPayment.Checked = true;
            btnNextMain.Text = "Confirm Payment";
            btnBackMain.Enabled = true;

            decimal totalAmountPayable = ucPaymentFeesCharges.ComputeTotalAmountPayable();
            ucPayment.OnLoad(Helper.userId, "52", totalAmountPayable);
        }

        private void InitializeReceipt()
        {
            var cattleTransferDetails = ucCattleTransfer.GetCattleTransferReceiptContent();

            var dictParameters = new Dictionary<string, string>
            {
                {"paramMunicipal", Helper.selectedServerModel.MunicipalityName.ToUpper()},
                {"paramProvince", Helper.selectedServerModel.ProvinceName.ToUpper()},
                {"paramOldOwnerName", cattleTransferDetails.oldOwnerName},
                {"paramOldOwnerAddress", cattleTransferDetails.oldOwnerAddress},
                {"paramOldOwnerMunicipality", cattleTransferDetails.oldOwnerMunicipality},
                {"paramOldOwnerProvince", cattleTransferDetails.oldOwnerProvince},
                {"paramNewOwnerName", cattleTransferDetails.newOwnerName},
                {"paramNewOwnerAddress", cattleTransferDetails.newOwnerAddress},
                {"paramNewOwnerMunicipality", cattleTransferDetails.newOwnerMunicipality},
                {"paramNewOwnerProvince", cattleTransferDetails.newOwnerProvince},
                {"paramCattleName", cattleTransferDetails.cattleName},
                {"paramCattleAge", cattleTransferDetails.cattleAge.ToString()},
                {"paramCattlePrice", cattleTransferDetails.amountPurchase.ToString()},
                {"paramCattlePriceWords", new Helper.AmountToWords().ConvertAmountToWords(cattleTransferDetails.amountPurchase.ToString("N2"))},
                {"paramCattleSex", cattleTransferDetails.cattleSex},
                {"paramCattleYears", cattleTransferDetails.cattleYears.ToString()},
                {"paramCurrentDate", Helper.GetCurrentDate().ToString()},
                {"paramTransactionDate", ucPayment.PaymentCollectionsModel().PaymentDate.ToString()},
                {"paramMunicipalTreasurer", string.Empty},
                {"paramMunicipalMayorName", string.Empty},
                {"paramMunicipalSecretaryName", string.Empty},
            };

            string reportPath = $"{Application.StartupPath}\\Receipts\\AF52.rdlc";
            ucPrintReceipt.Onload(reportPath, dictParameters);
        }

        private void LoadReceiptTab()
        {
            btnNextMain.Text = "New Transaction";
            InitializeReceipt();
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadTabContents();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ResetForm()
        {
            ucPayment.ResetForm();
            ucPaymentFeesCharges.ResetForm();
            ucCattleTransfer.ResetForm();
            tabControlMain.SelectedIndex = 0;
        }

        private bool TabValidated()
        {
            switch (tabControlMain.SelectedTab.Name)
            {
                case "tabPageCattleTransfer":
                    if (!ucCattleTransfer.ValidateChildren())
                    {
                        Helper.MessageBoxError(ucCattleTransfer.GetFormErrors());
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

        private bool ConfirmPayment()
        {
            return AccFactory.PaymentCollectionsRepository().InsertWithPrevCattleOwnership(ucPayment.PaymentCollectionsModel(), null, ucCattleTransfer.GetCattleOwnershipModel(), ucCattleTransfer.GetPrevCattleOwnershipModel(), ucPaymentFeesCharges.PaymentFeesChargesModels());
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
                        if (ConfirmPayment())
                        {
                            tabControlMain.SelectedIndex++;
                        }
                    }

                    return;
                }

                if (tabControlMain.SelectedTab.Name == "tabPageReceipt")
                {
                    ResetForm();
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

        private void frmCattleTransfer_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmCattleTransfer_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool isInReceiptTab = tabControlMain.SelectedTab.Name == "tabPageReceipt";
            string promptMessage = isInReceiptTab ? "Are you sure you want to close the form?" : "The transaction cannot be saved.\nAre you sure you want to close the form?";
            bool confirmation = Helper.MessageBoxConfirmCancel(promptMessage);

            if (confirmation)
            {
                e.Cancel = false;
                return;
            }
            e.Cancel = true;
        }
    }
}