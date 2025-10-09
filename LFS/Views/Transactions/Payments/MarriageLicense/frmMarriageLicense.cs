using ACC.Data;
using ACC.Domain.Models;
using LFS.Helpers;
using LFS.Views.Transactions.Payments.BurialPermit;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LFS.Views.Transactions.Payments.MarriageLicense
{
    public partial class frmMarriageLicense : Form
    {
        private readonly ucMarriageDetails ucMarriageDetails;
        private readonly ucSpouseInfo ucSpouseInfoGroom;
        private readonly ucSpouseInfo ucSpouseInfoBride;
        private readonly ucPaymentFeesCharges ucPaymentFeesCharges;
        private readonly ucPayment ucPayment;
        private readonly ucPrintReceipt ucPrintReceipt;

        public frmMarriageLicense()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.RemoveTabcontrolTabs(tabControlMain);
            ucPayment = ucPayment1;
            ucPrintReceipt = ucPrintReceipt1;
            ucPaymentFeesCharges = ucPaymentFeesCharges1;
            ucMarriageDetails = ucMarriageDetails1;
            ucSpouseInfoGroom = ucSpouseInfoGroom1;
            ucSpouseInfoBride = ucSpouseInfoBride1;
        }

        private void ResetForm()
        {
            ucPayment.ResetForm();
            ucMarriageDetails.ResetForm();
            ucPaymentFeesCharges.ResetForm();
            ucSpouseInfoBride.ResetForm();
            ucSpouseInfoGroom.ResetForm();
            tabControlMain.SelectedIndex = 0;
        }

        private void frmMarriageLicense_Load(object sender, EventArgs e)
        {
            try
            {
                LoadTabContents();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private MarriageLicenseModel MarriageLicenseModel()
        {
            return new MarriageLicenseModel()
            {
                MarriageLicenseNo = ucMarriageDetails.GetMarriageDetails().licenseNo,
                RegistryNo = ucMarriageDetails.GetMarriageDetails().registryNo,
                DatePublished = ucMarriageDetails.GetMarriageDetails().publishedOn,
                DateIssued = ucMarriageDetails.GetMarriageDetails().issuedOn,
                GroomRegistryId = ucSpouseInfoGroom.GetSpouseInfo().SpouseRegistryId,
                GroomAge = ucSpouseInfoGroom.GetSpouseInfo().age,
                GroomMonths = ucSpouseInfoGroom.GetSpouseInfo().months,
                GroomReligion = ucSpouseInfoGroom.GetSpouseInfo().religion,
                GroomResidence = ucSpouseInfoGroom.GetSpouseInfo().currentResidence,
                BrideRegistryId = ucSpouseInfoBride.GetSpouseInfo().SpouseRegistryId,
                BrideAge = ucSpouseInfoBride.GetSpouseInfo().age,
                BrideMonths = ucSpouseInfoBride.GetSpouseInfo().months,
                BrideReligion = ucSpouseInfoBride.GetSpouseInfo().religion,
                BrideResidence = ucSpouseInfoBride.GetSpouseInfo().currentResidence,
                CreatedBy = UserHelper.loggedUser.Id
            };
        }

        private void LoadMarriageDetailsTab()
        {
            ucMarriageDetails.OnLoad();
            radMarriageDetails.Checked = true;
        }

        private void LoadGroomInfoTab()
        {
            ucSpouseInfoGroom.OnLoad();
            radGroomInfo.Checked = true;
        }

        private void LoadBrideInfoTab()
        {
            btnNextMain.Text = "Next";
            ucSpouseInfoBride.OnLoad();
            radBrideInfo.Checked = true;
        }

        private void LoadFeesAndChargesTab()
        {
            ucPaymentFeesCharges.OnLoad();
            btnBackMain.Enabled = true;
            btnNextMain.Text = "Proceed to Payment";
            radFeesCharges.Checked = true;
        }

        private void LoadPaymentTab()
        {
            radPayment.Checked = true;
            btnNextMain.Text = "Confirm Payment";
            btnBackMain.Enabled = true;
            radPayment.Checked = true;

            decimal totalPayment = ucPaymentFeesCharges.ComputeTotalAmountPayable();
            ucPayment.OnLoad(UserHelper.loggedUser.Id, "54", totalPayment);
        }

        private void LoadReceiptTab()
        {
            btnNextMain.Text = "New Transaction";
            InitializeReceipt();
        }

        private void InitializeReceipt()
        {
            int groomId = ucSpouseInfoGroom.GetSpouseInfo().SpouseRegistryId;
            int brideId = ucSpouseInfoBride.GetSpouseInfo().SpouseRegistryId;

            var dictGroomInfo = AccFactory.RegistryRepository().GetRecordByID(groomId);
            var dictBrideInfo = AccFactory.RegistryRepository().GetRecordByID(brideId);

            string groomName = Helper.GenerateFullName(string.Empty, dictGroomInfo["first_name"], dictGroomInfo["middle_name"], dictGroomInfo["last_name"], string.Empty);

            string brideName = Helper.GenerateFullName(string.Empty, dictBrideInfo["first_name"], dictBrideInfo["middle_name"], dictBrideInfo["last_name"], string.Empty);

            var dictReportParameters = new Dictionary<string, string>()
            {
                { "paramMunicipality", ServerHelper.selectedServer.MunicipalityName.ToUpper() },
                { "paramProvince", ServerHelper.selectedServer.ProvinceName.ToUpper() },
                { "paramRegistryNo", ucMarriageDetails.GetMarriageDetails().registryNo },
                { "paramDateIssued", ucMarriageDetails.GetMarriageDetails().issuedOn.ToString()},
                { "paramGroomName", groomName },
                { "paramGroomAge", ucSpouseInfoGroom.GetSpouseInfo().age.ToString() },
                { "paramGroomMonths", ucSpouseInfoGroom.GetSpouseInfo().months.ToString() },
                { "paramGroomResidence", ucSpouseInfoGroom.GetSpouseInfo().currentResidence.ToString()},
                { "paramBrideName", brideName },
                { "paramBrideAge", ucSpouseInfoBride.GetSpouseInfo().age.ToString() },
                { "paramBrideMonths", ucSpouseInfoBride.GetSpouseInfo().months.ToString() },
                { "paramBrideResidence", ucSpouseInfoBride.GetSpouseInfo().currentResidence.ToString()}
            };

            string reportPath = $"{Application.StartupPath}\\Receipts\\AF54.rdlc";

            ucPrintReceipt.Onload(reportPath, dictReportParameters);
        }

        private bool ConfirmPayment()
        {
            return AccFactory.PaymentCollectionsRepository().InsertWithMarriageLicensePayment(ucPayment.PaymentCollectionsModel(), null, MarriageLicenseModel(), ucPaymentFeesCharges.PaymentFeesChargesModels());
        }

        private void LoadTabContents()
        {
            if (tabControlMain.SelectedIndex == 0)
                btnBackMain.Enabled = false;
            else
                btnBackMain.Enabled = true;

            switch (tabControlMain.SelectedTab.Name)
            {
                case "tabPageMarriageDetails":
                    LoadMarriageDetailsTab();
                    break;

                case "tabPageGroomInfo":
                    LoadGroomInfoTab();
                    break;

                case "tabPageBrideInfo":
                    LoadBrideInfoTab();
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

        private bool TabValidated()
        {
            switch (tabControlMain.SelectedTab.Name)
            {
                case "tabPageMarriageDetails":
                    if (!ucMarriageDetails.ValidateChildren())
                    {
                        Helper.MessageBoxError(ucMarriageDetails.GetFormErrors());
                        return false;
                    }
                    break;

                case "tabPageGroomInfo":

                    if (!ucSpouseInfoGroom.ValidateChildren())
                    {
                        Helper.MessageBoxError(ucSpouseInfoGroom.GetFormErrors());
                        return false;
                    }
                    break;

                case "tabPageBrideInfo":
                    if (!ucSpouseInfoBride.ValidateChildren())
                    {
                        Helper.MessageBoxError(ucSpouseInfoBride.GetFormErrors());
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

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadTabContents();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmMarriageLicense_FormClosing(object sender, FormClosingEventArgs e)
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