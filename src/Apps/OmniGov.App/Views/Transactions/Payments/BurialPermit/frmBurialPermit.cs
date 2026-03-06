using OmniGov.App.Helpers;

using OmniGov.Core.Factories;

using OmniGov.Treasury.Data.Factories;

using OmniGov.Treasury.Domain.Entities;

namespace OmniGov.App.Views.Transactions.Payments.BurialPermit

{
    public partial class frmBurialPermit : Form

    {
        private readonly ucBurialDetails ucBurialDetails;
        private readonly ucPayment ucPayment;
        private readonly ucPaymentFeesCharges ucPaymentFeesCharges;
        private readonly ucPrintReceipt ucPrintReceipt;
        private readonly ucRemainsInfo ucRemainsInfo;

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

                CreatedBy = UserHelper.loggedUser.Id,
            };
        }

        private void btnBackMain_Click(object sender, EventArgs e)

        {
            tabControlMain.SelectedIndex--;
        }

        private void btnNextMain_Click(object sender, EventArgs e)

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

        private bool ConfirmPayment()

        {
            return TreasuryFactory.PaymentCollectionsRepository().InsertWithBurialPermitPayment(ucPayment.PaymentCollectionsModel(), null, BurialPermitModel(), ucPaymentFeesCharges.PaymentFeesChargesModels());
        }

        private void frmBurialPermit_FormClosing(object sender, FormClosingEventArgs e)

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

        private void frmBurialPermit_Load(object sender, EventArgs e)

        {
            OnLoad();
        }

        private void InitializeReceipt()

        {
            var burialDetails = ucBurialDetails.GetBurialDetails();

            var remainDetails = ucRemainsInfo.GetRemainsInfo();

            string isInfectious = burialDetails.isInfectious ? "Infectious" : "Non-Infectious";

            string isEmbalmed = burialDetails.isEmbalmed ? "Embalmed" : "None";

            var dictRegistry = Factory.RegistryRepository().GetRecordByID(remainDetails.remainRegistryId);

            var remainName = Helper.GenerateFullName(string.Empty, dictRegistry["first_name"], dictRegistry["middle_name"], dictRegistry["last_name"], string.Empty);

            var dictReportParameters = new Dictionary<string, string>()

            {
                {"paramMunicipality", (ServerHelper.SelectedProfile?.Name ?? "").ToUpper()},

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

        private void LoadBurialDetailsTab()

        {
            radBurialDetails.Checked = true;

            btnNextMain.Text = "Next";
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

            ucPayment.OnLoad(UserHelper.loggedUser.Id, "58", totalAmountPayable);
        }

        private void LoadReceiptTab()

        {
            btnNextMain.Text = "New Transaction";

            InitializeReceipt();
        }

        private void LoadRemainsInfoTab()

        {
            radRemainsInfo.Checked = true;

            btnNextMain.Text = "Next";

            ucRemainsInfo.deathDate = ucBurialDetails.dtDeathDate.Value;

            ucRemainsInfo.OnLoad();
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

        private void OnLoad()

        {
            LoadTabContents();

            ucBurialDetails.OnLoad();
        }

        private void ResetForm()

        {
            ucPayment.ResetForm();

            ucPaymentFeesCharges.ResetForm();

            ucBurialDetails.ResetForm();

            ucRemainsInfo.ResetForm();

            tabControlMain.SelectedIndex = 0;
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)

        {
            LoadTabContents();
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
    }
}