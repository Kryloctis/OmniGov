using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.MarriageLicense
{
    public partial class frmMarriageLicense : Form
    {
        private readonly ucMarriageDetails ucMarriageDetails;
        private readonly ucSpouseInfo ucSpouseInfoGroom;
        private readonly ucSpouseInfo ucSpouseInfoBride;
        private readonly ucPaymentFeesCharges ucPaymentFeesCharges;
        private readonly ucPayment ucPayment;

        public frmMarriageLicense()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            ucPayment = ucPayment1;
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
                CreatedBy = Helper.userId
            };
        }

        private bool ConfirmPayment()
        {
            return AccFactory.PaymentCollectionsRepository().InsertWithMarriageLicensePayment(ucPayment.PaymentCollectionsModel(), null, MarriageLicenseModel(), ucPaymentFeesCharges.PaymentFeesChargesModels());
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
            ucPayment.OnLoad(Helper.userId, "54", totalPayment);
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

        private void LoadReceipt()
        {
            int groomId = ucSpouseInfoGroom.GetSpouseInfo().SpouseRegistryId;
            int brideId = ucSpouseInfoBride.GetSpouseInfo().SpouseRegistryId;

            var dictGroomInfo = AccFactory.RegistryRepository().GetRecordByID(groomId);
            var dictBrideInfo = AccFactory.RegistryRepository().GetRecordByID(brideId);

            string groomName = Helper.GenerateFullName(string.Empty, dictGroomInfo["first_name"], dictGroomInfo["middle_name"], dictGroomInfo["last_name"], string.Empty);

            string brideName = Helper.GenerateFullName(string.Empty, dictBrideInfo["first_name"], dictBrideInfo["middle_name"], dictBrideInfo["last_name"], string.Empty);

            var af54ReceiptParameters = new frmMarriageLicenseReceipt.AF54Parameters()
            {
                Municipality = Helper.selectedServerModel.MunicipalityName.ToUpper(),
                Province = Helper.selectedServerModel.ProvinceName.ToUpper(),
                RegistryNo = ucMarriageDetails.GetMarriageDetails().registryNo,
                DateIssued = ucMarriageDetails.GetMarriageDetails().issuedOn,
                GroomName = groomName,
                GroomAge = ucSpouseInfoGroom.GetSpouseInfo().age.ToString(),
                GroomMonths = ucSpouseInfoGroom.GetSpouseInfo().months.ToString(),
                BrideName = brideName,
                BrideAge = ucSpouseInfoBride.GetSpouseInfo().age.ToString(),
                BrideMonths = ucSpouseInfoBride.GetSpouseInfo().months.ToString()
            };

            var frmAF54Receipt = new frmMarriageLicenseReceipt();
            frmAF54Receipt.OnLoad(af54ReceiptParameters);
            frmAF54Receipt.ShowDialog();
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
    }
}