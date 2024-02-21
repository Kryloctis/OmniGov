using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.BurialPermit
{
    public partial class frmBurialPermit : Form
    {
        private readonly ucPayment ucPayment;
        private readonly ucBurialDetails ucBurialDetails;
        private readonly ucRemainsInfo ucRemainsInfo;
        private readonly ucPaymentFeesCharges ucPaymentFeesCharges;

        public frmBurialPermit()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            ucPayment = ucPayment1;
            ucBurialDetails = ucBurialDetails1;
            ucRemainsInfo = ucRemainsInfo1;
            ucPaymentFeesCharges = ucPaymentFeesCharges1;
        }

        private void ResetForm()
        {
            ucPayment.ResetForm();
            ucPaymentFeesCharges.ResetForm();
            ucBurialDetails.ResetForm();
            ucRemainsInfo.ResetForm();
            tabControlMain.SelectedIndex = 0;
        }

        private void frmBurialPermit_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            LoadTabContents();
            ucBurialDetails.OnLoad();
        }

        internal BurialPermitModel BurialPermitModel()
        {
            return new BurialPermitModel()
            {
                RemainsRegistryId = Convert.ToInt32(ucRemainsInfo.GetRemainsInfo().remainRegistryId),
                IsInfectious = ucBurialDetails.GetBurialDetails().isInfectious,
                IsEmbalmed = ucBurialDetails.GetBurialDetails().isEmbalmed,
                CauseOfDeath = ucBurialDetails.GetBurialDetails().causeOfDeath,
                Cemetery = ucBurialDetails.GetBurialDetails().cemetery,
                Disinterment = ucBurialDetails.GetBurialDetails().disinterment,
                Disposition = ucBurialDetails.GetBurialDetails().disposition,
                DeathDate = ucBurialDetails.GetBurialDetails().deathDate,
                RemainsAge = ucRemainsInfo.GetRemainsInfo().remainAge,
                CreatedBy = Helper.UserId,
            };
        }

        private bool TabValidated()
        {
            switch (tabControlMain.SelectedTab.Name)
            {
                case "tabPageBurialDetails":
                    if (!ucBurialDetails.ValidateChildren())
                    {
                        Helper.MessageBoxError(ucBurialDetails.GetFormErrors());
                        return false;
                    }
                    break;

                case "tabPageRemainsInfo":
                    if (!ucRemainsInfo.ValidateChildren())
                    {
                        Helper.MessageBoxError(ucRemainsInfo.GetFormErrors());
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

        private void LoadBurialDetailsTab()
        {
            radBurialDetails.Checked = true;
            btnNextMain.Text = "Next";
        }

        private void LoadRemainsInfoTab()
        {
            radRemainsInfo.Checked = true;
            btnNextMain.Text = "Next";
            ucRemainsInfo.deathDate = ucBurialDetails.dtDeathDate.Value;
            ucRemainsInfo.OnLoad();
        }

        private void LoadFeesAndChargesTab()
        {
            btnNextMain.Text = "Proceed to Payment";
            radFees.Checked = true;
            ucPaymentFeesCharges.OnLoad();
        }

        private void LoadPaymentTab()
        {
            btnNextMain.Text = "Confirm Payment";
            radPayment.Checked = true;

            decimal totalAmountPayable = ucPaymentFeesCharges.ComputeTotalAmountPayable();
            ucPayment.OnLoad(Helper.UserId, "58", totalAmountPayable);
        }

        private void LoadTabContents()
        {
            if (tabControlMain.SelectedIndex == 0)
                btnBackMain.Enabled = false;
            else
                btnBackMain.Enabled = true;

            switch (tabControlMain.SelectedTab.Name)
            {
                case "tabPageBurialDetails":
                    LoadBurialDetailsTab();
                    break;

                case "tabPageRemainsInfo":
                    LoadRemainsInfoTab();
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
            return AccFactory.PaymentCollectionsRepository().InsertWithBurialPermitPayment(ucPayment.PaymentCollectionsModel(), null, BurialPermitModel(), ucPaymentFeesCharges.PaymentFeesChargesModels());
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
                            Helper.MessageBoxSuccess("Payment has been saved, initiating the printing of the receipt...");
                            LoadReceipt();
                            ResetForm();
                            return;
                        }
                    }
                    return;
                }

                tabControlMain.SelectedIndex++;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadReceipt()
        {
            var af58Parameters = new frmBurialPermitReceipt();
            var burialDetails = ucBurialDetails.GetBurialDetails();
            var remainDetails = ucRemainsInfo.GetRemainsInfo();
            var dictRegistry = AccFactory.RegistryRepository().GetRecordByID(remainDetails.remainRegistryId);
            var remainName = dictRegistry["first_name"];

            var receiptParameters = new frmBurialPermitReceipt.AF58Parameters()
            {
                Municipality = Helper.selectedServerModel.MunicipalityName.ToUpper(),
                CauseOfDeath = burialDetails.causeOfDeath,
                Cemetery = burialDetails.cemetery,
                DeathDate = burialDetails.deathDate,
                Disinterment = burialDetails.disinterment,
                Disposition = burialDetails.disposition,
                IsInfectious = burialDetails.isInfectious,
                IsEmbalmed = burialDetails.isEmbalmed,
                IsDisinter = false,
                IsInter = true,
                IsRemove = false,
                MunicipalFeeAmount = string.Empty,
                MunicipalFeeDate = string.Empty,
                MunicipalFeeNo = string.Empty,
                RemainAge = remainDetails.remainAge,
                RemainName = remainName,
                RemainNationality = dictRegistry["nationality"],
                RemainSex = dictRegistry["sex"],
                TransactionDate = ucPayment.PaymentCollectionsModel().PaymentDate,
                CollectingOfficerName = ucPayment.txtCollectingOfficer.Text,
                TotalPayment = ucPayment.PaymentCollectionsModel().Amount
            };

            af58Parameters.OnLoad(receiptParameters);
            af58Parameters.ShowDialog();
        }

        private void btnBackMain_Click(object sender, EventArgs e)
        {
            try
            {
                tabControlMain.SelectedIndex--;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}