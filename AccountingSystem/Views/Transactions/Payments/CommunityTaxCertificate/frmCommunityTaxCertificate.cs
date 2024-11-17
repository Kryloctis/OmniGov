using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.CommunityTaxCertificate
{
    public partial class frmCommunityTaxCertificate : Form
    {

        private readonly ucTaxPayerDetails ucTaxPayerDetails;
        private readonly ucTaxDue ucTaxDue;
        public frmCommunityTaxCertificate()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.RemoveTabcontrolTabs(tabControlMain);

            ucTaxDue = ucTaxDue1;
            ucTaxPayerDetails = ucTaxPayerDetails1;
        }

        private void btnBackMain_Click(object sender, System.EventArgs e)
        {
            try
            {
                tabControlMain.SelectedIndex--;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadTaxPayerTab()
        {
            btnBackMain.Enabled = false;
            btnNext.Text = "Next";
            radTaxpayer.Checked = true;
        }

        private void LoadTaxDueTab()
        {
            btnBackMain.Enabled = true;
            btnNext.Text = "Proceed to Payment";
            radTaxDues.Checked = true;
        }

        private void LoadPaymentTab()
        {
            radPayment.Checked = true;
            btnNext.Text = "Confirm Payment";
            btnBackMain.Enabled = true;
            radPayment.Checked = true;

            //decimal totalPayment = ucPaymentFeesCharges.ComputeTotalAmountPayable();
            //ucPayment.OnLoad(Helper.userId, "54", totalPayment);
        }

        private void LoadReceiptTab()
        {
            btnNext.Text = "New Transaction";
            InitializeReceipt();
        }

        private void InitializeReceipt()
        {

            //int groomId = ucSpouseInfoGroom.GetSpouseInfo().SpouseRegistryId;
            //int brideId = ucSpouseInfoBride.GetSpouseInfo().SpouseRegistryId;

            //var dictGroomInfo = AccFactory.RegistryRepository().GetRecordByID(groomId);
            //var dictBrideInfo = AccFactory.RegistryRepository().GetRecordByID(brideId);

            //string groomName = Helper.GenerateFullName(string.Empty, dictGroomInfo["first_name"], dictGroomInfo["middle_name"], dictGroomInfo["last_name"], string.Empty);

            //string brideName = Helper.GenerateFullName(string.Empty, dictBrideInfo["first_name"], dictBrideInfo["middle_name"], dictBrideInfo["last_name"], string.Empty);

            //var dictReportParameters = new Dictionary<string, string>()
            //{
            //    { "paramMunicipality", Helper.selectedServerModel.MunicipalityName.ToUpper() },
            //    { "paramProvince", Helper.selectedServerModel.ProvinceName.ToUpper() },
            //    { "paramRegistryNo", ucMarriageDetails.GetMarriageDetails().registryNo },
            //    { "paramDateIssued", ucMarriageDetails.GetMarriageDetails().issuedOn.ToString()},
            //    { "paramGroomName", groomName },
            //    { "paramGroomAge", ucSpouseInfoGroom.GetSpouseInfo().age.ToString() },
            //    { "paramGroomMonths", ucSpouseInfoGroom.GetSpouseInfo().months.ToString() },
            //    { "paramGroomResidence", ucSpouseInfoGroom.GetSpouseInfo().currentResidence.ToString()},
            //    { "paramBrideName", brideName },
            //    { "paramBrideAge", ucSpouseInfoBride.GetSpouseInfo().age.ToString() },
            //    { "paramBrideMonths", ucSpouseInfoBride.GetSpouseInfo().months.ToString() },
            //    { "paramBrideResidence", ucSpouseInfoBride.GetSpouseInfo().currentResidence.ToString()}
            //};

            //string reportPath = $"{Application.StartupPath}\\Receipts\\AF54.rdlc";

            //ucPrintReceipt.Onload(reportPath, dictReportParameters);
        }

        private void LoadTabContents()
        {
            if (tabControlMain.SelectedIndex == 0)
                btnBackMain.Enabled = false;
            else
                btnBackMain.Enabled = true;


            switch (tabControlMain.SelectedTab.Name)
            {
                case "tabPageTaxpayer":
                    LoadTaxPayerTab();
                    break;

                case "tabPageTaxDues":
                    LoadTaxDueTab();
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

        private void frmCommunityTaxCertificate_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                //if (!TabValidated())
                //    return;

                //if (tabControlMain.SelectedTab.Name == "tabPagePayment" && TabValidated())
                //{
                //    if (Helper.MessageBoxConfirmCancel("Confirm Payment..."))
                //    {
                //        if (ConfirmPayment())
                //        {
                //            tabControlMain.SelectedIndex++;
                //        }
                //    }
                //    return;
                //}

                //if (tabControlMain.SelectedTab.Name == "tabPageReceipt")
                //{
                //    ResetForm();
                //    return;
                //}

                //tabControlMain.SelectedIndex++;
                tabControlMain.SelectedIndex++;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmCommunityTaxCertificate_Load(object sender, EventArgs e)
        {
            try
            {
                LoadTabContents();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ucTaxPayerDetails1_Load(object sender, EventArgs e)
        {

        }
    }
}
