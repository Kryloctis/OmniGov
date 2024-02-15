using ACC.Data;
using AccountingSystem.Views.Transactions.Payments.OtherPayments.CattleTransferOfOwnership;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.CattleTransferOfOwnership
{
    public partial class frmCattleTransfer : Form
    {
        private readonly ucPayment ucPayment;
        private readonly ucPaymentFeesCharges ucPaymentFeesCharges;
        private readonly ucCattleTransfer ucCattleTransfer;

        public frmCattleTransfer()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            ucPayment = ucPayment1;
            ucPaymentFeesCharges = ucPaymentFeesCharges1;
            ucCattleTransfer = ucCattleTransfer1;
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
                    radFeesCharges.Checked = true;
                    LoadFeesAndChargesTab();
                    break;

                case "tabPagePayment":
                    radPayment.Checked = true;
                    LoadPaymentTab();
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
            ucPayment.OnLoad(Helper.UserId, "52", totalAmountPayable);
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

        private bool ConfirmPayment()
        {
            if (Helper.MessageBoxConfirmCancel("Confirm Payment?"))
                return AccFactory.PaymentCollectionsRepository().InsertWithPrevCattleOwnership(ucPayment.PaymentCollectionsModel(), null, ucCattleTransfer.GetCattleOwnershipModel(), ucCattleTransfer.GetPrevCattleOwnershipModel(), ucPaymentFeesCharges.PaymentFeesChargesModels());

            return false;
        }

        private void LoadReceipt()
        {
            var frmReceipt = new frmCattleTransferReceipt();
            var cattleTransferDetails = ucCattleTransfer.GetCattleTransferReceiptContent();

            var receiptParameters = new frmCattleTransferReceipt.AF52Parameters()
            {
                Municipality = Helper.selectedServerModel.MunicipalityName.ToUpper(),
                Province = Helper.selectedServerModel.ProvinceName.ToUpper(),
                OldOwnerName = cattleTransferDetails.oldOwnerName,
                OldOwnerAddress = cattleTransferDetails.oldOwnerAddress,
                OldOwnerMunicipality = cattleTransferDetails.oldOwnerMunicipality,
                OldOwnerProvince = cattleTransferDetails.oldOwnerProvince,
                NewOwnerName = cattleTransferDetails.newOwnerName,
                NewOwnerAddress = cattleTransferDetails.newOwnerAddress,
                NewOwnerMunicipality = cattleTransferDetails.newOwnerMunicipality,
                NewOwnerProvince = cattleTransferDetails.newOwnerProvince,
                CattleName = cattleTransferDetails.cattleName,
                CattleAge = cattleTransferDetails.cattleAge,
                CattlePrice = cattleTransferDetails.amountPurchase,
                CattlePriceWords = new Helper.AmountToWords().ConvertAmountToWords(cattleTransferDetails.amountPurchase.ToString("N2")),
                CattleSex = cattleTransferDetails.cattleSex,
                CattleYears = cattleTransferDetails.cattleYears,
                CurrentDate = Helper.GetCurrentDate(),
                TransactionDate = ucPayment.PaymentCollectionsModel().PaymentDate,
                MunicipalMayor = string.Empty,
                MunicipalSecretaryName = string.Empty
            };

            frmReceipt.OnLoad(receiptParameters);
            frmReceipt.ShowDialog();
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

        private void btnNextMain_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TabValidated())
                    return;

                if (tabControlMain.SelectedTab.Name == "tabPagePayment" && TabValidated())
                {
                    if (ConfirmPayment())
                    {
                        Helper.MessageBoxSuccess("Payment has been saved");
                        LoadReceipt();
                        ResetForm();
                        return;
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

        private void frmCattleTransfer_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}