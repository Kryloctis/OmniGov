using ACC.Data;
using LFS.Helpers;
using LFS.Views.Transactions.Payments.BurialPermit;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LFS.Views.Transactions.Payments.CattleOwnership
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
            var taxpayerId = ucCattleOwnership.CattleOwnershipModel().TaxpayerId;
            var dictTaxpayer = AccFactory.TaxpayersRepository().GetViewRecordById(taxpayerId);

            var dictParameters = new Dictionary<string, string>()
            {
                {"paramMunicipality", ServerHelper.selectedServer.MunicipalityName.ToUpper()},
                {"paramProvince", ServerHelper.selectedServer.ProvinceName.ToUpper()},
                {"paramTransactionDate", ucPayment.PaymentCollectionsModel().PaymentDate.ToString()},
                {"paramOwnerName", dictTaxpayer["taxpayers_name"]},
                {"paramOwnerMunicipality", dictTaxpayer["taxpayers_municipality"]},
                {"paramOwnerProvince", dictTaxpayer["taxpayers_province"]},
                {"paramCattleName", ucCattleOwnership.CattleOwnershipModel().CattleName},
                {"paramCattleAge", ucCattleOwnership.CattleOwnershipModel().CattleAge.ToString()},
                {"paramCattleSex", ucCattleOwnership.CattleOwnershipModel().CattleSex},
                {"paramMunicipalTreasurerName", string.Empty},
                {"paramMunicipalSecretaryName", string.Empty},
                {"paramMunicipalMayor", string.Empty },
            };

            string reportPath = $"{Application.StartupPath}\\Receipts\\AF53.rdlc";
            ucPrintReceipt.Onload(reportPath, dictParameters);
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

        private void frmCattleOwnership_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmCattleOwnership_FormClosing(object sender, FormClosingEventArgs e)
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