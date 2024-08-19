using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.BurialPermit
{
    public partial class frmBurialPermit : Form
    {
        private readonly ucPayment ucPayment;
        private readonly ucBurialDetails ucBurialDetails;
        private readonly ucRemainsInfo ucRemainsInfo;
        private readonly ucPaymentFeesCharges ucPaymentFeesCharges;
        private readonly ucPrintReceipt ucPrintReceipt;

        public frmBurialPermit()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.RemoveTabcontrolTabs(tabControlMain);
            ucPayment = ucPayment1;
            ucBurialDetails = ucBurialDetails1;
            ucRemainsInfo = ucRemainsInfo1;
            ucPaymentFeesCharges = ucPaymentFeesCharges1;
            ucPrintReceipt = ucPrintReceipt1;
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
                CreatedBy = Helper.userId,
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
            radPayment.Checked = true;
            btnNextMain.Text = "Confirm Payment";

            decimal totalAmountPayable = ucPaymentFeesCharges.ComputeTotalAmountPayable();
            ucPayment.OnLoad(Helper.userId, "58", totalAmountPayable);
        }

        private void LoadReceiptTab()
        {
            btnNextMain.Text = "New Transaction";
            InitializeReceipt();
        }

        private void InitializeReceipt()
        {
            var burialDetails = ucBurialDetails.GetBurialDetails();
            var remainDetails = ucRemainsInfo.GetRemainsInfo();
            string isInfectious = burialDetails.isInfectious ? "Infectious" : "Non-Infectious";
            string isEmbalmed = burialDetails.isEmbalmed ? "Embalmed" : "None";
            var dictRegistry = AccFactory.RegistryRepository().GetRecordByID(remainDetails.remainRegistryId);
            var remainName = Helper.GenerateFullName(string.Empty, dictRegistry["first_name"], dictRegistry["middle_name"], dictRegistry["last_name"], string.Empty);

            var dictReportParameters = new Dictionary<string, string>()
            {
                {"paramMunicipality", Helper.selectedServerModel.MunicipalityName.ToUpper()},
                {"paramTransactionDate", ucPayment.PaymentCollectionsModel().PaymentDate.ToString()},
                {"paramRemainName", remainName},
                {"paramRemainSex", dictRegistry["sex"]},
                {"paramRemainNationality", dictRegistry["nationality"]},
                {"paramRemainAge", remainDetails.remainAge.ToString()},
                {"paramRemainDeathDate", burialDetails.deathDate.ToShortDateString()},
                {"paramCauseOfDeath", burialDetails.causeOfDeath},
                {"paramCemetery", burialDetails.cemetery},
                {"paramDisinterment", burialDetails.disinterment},
                {"paramIsInfectious", isInfectious},
                {"paramIsEmbalmed", isEmbalmed},
                {"paramDisposition", burialDetails.disposition},
                {"paramIsInter", "true"},
                {"paramIsDisinter", "false"},
                {"paramIsRemove", "false"},
                {"paramTotalPayment", ucPayment.PaymentCollectionsModel().Amount.ToString()},
                {"paramMunicipalFeeNo", string.Empty},
                {"paramMunicipalFeeDate", string.Empty},
                {"paramMunicipalFeeAmount", string.Empty},
                {"paramCollectingOfficerName", ucPayment.txtCollectingOfficer.Text },
            };

            string reportPath = $"{Application.StartupPath}\\Receipts\\AF58.rdlc";

            ucPrintReceipt.Onload(reportPath, dictReportParameters);
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
                        tabControlMain.SelectedIndex++;
                        //if (ConfirmPayment())
                        //{
                        //}
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
    }
}