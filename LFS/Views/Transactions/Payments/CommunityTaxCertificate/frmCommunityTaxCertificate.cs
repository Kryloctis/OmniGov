using ACC.Data;
using ACC.Domain.Models;
using LFS.Views.Transactions.Payments.BurialPermit;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LFS.Views.Transactions.Payments.CommunityTaxCertificate
{
    public partial class frmCommunityTaxCertificate : Form
    {
        private readonly ucTaxPayerDetails ucTaxPayerDetails;
        private readonly ucTaxDue ucTaxDue;
        private readonly ucPayment ucPayment;
        private readonly ucPrintReceipt ucPrintReceipt;

        public frmCommunityTaxCertificate()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.RemoveTabcontrolTabs(tabControlMain);

            ucTaxDue = ucTaxDue1;
            ucTaxPayerDetails = ucTaxPayerDetails1;
            ucPayment = ucPayment1;
            ucPrintReceipt = ucPrintReceipt1;
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

            decimal totalPayment = ucTaxDue.ComputeTotalAmountPayable();
            ucPayment.OnLoad(Helper.userId, "15", totalPayment);
        }

        private void LoadReceiptTab()
        {
            btnNext.Text = "New Transaction";
            InitializeReceipt();
        }

        private void InitializeReceipt()
        {
            var dictReportParameters = new Dictionary<string, string>()
            {
                { "paramYear", ucTaxPayerDetails.nudYear.Text},
                { "paramPlaceOfIssue", ucTaxPayerDetails.txtPlaceOfIssue.Text },
                { "paramDateIssued", ucTaxPayerDetails.dtpDateOfIssued.Text},
                { "paramReceiptNo", ucPayment.txtReceipts.Text},
                { "paramLastName", ucTaxPayerDetails.txtLastName.Text },
                { "paramFirstName", ucTaxPayerDetails.txtFirstName.Text },
                { "paramMiddleName", ucTaxPayerDetails.txtMiddleName.Text },
                { "paramTIN", ucTaxPayerDetails.txtTIN.Text },
                { "paramAddress", ucTaxPayerDetails.txtAddress.Text },
                { "paramProfession", ucTaxPayerDetails.txtOccupation.Text },
                { "paramDateOfBirth", ucTaxPayerDetails.dtpDateOfBirth.Text },
                { "paramHeight", ucTaxPayerDetails.nudHeight.Value.ToString("N2") },
                { "paramWeight", ucTaxPayerDetails.nudWeight.Value.ToString("N2") },
                { "paramCommunityTaxDue", ucTaxDue.nudBasicTax.Value.ToString("N2") },
                { "paramGrossReceipt", ucTaxDue.nudGrossReceipt.Value.ToString("N2") },
                { "paramSalariesOrGrossReceipt", ucTaxDue.nudSalary.Value.ToString("N2") },
                { "paramIncomeFromRealProperty", ucTaxDue.nudIncomeFromRpt.Value.ToString("N2") },
                { "paramTotal", ucTaxDue.ComputeTotalAmountPayable().ToString("N2") },
                { "paramInterest", "0" },
                { "paramTotalAmountPaid", ucTaxDue.ComputeTotalAmountPayable().ToString("N2")},
            };

            string reportPath = $"{Application.StartupPath}\\Receipts\\AF15.rdlc";

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

        private void ResetForm()
        {
            ucPayment.ResetForm();
            ucTaxDue.ResetForm();
            ucTaxPayerDetails.ResetForm();
            tabControlMain.SelectedIndex = 0;
        }

        private bool ConfirmPayment()
        {
            return AccFactory.PaymentCollectionsRepository().InsertWithCommunityTaxCertificate(ucPayment.PaymentCollectionsModel(), CommunityTaxCertificateModel());
        }

        private CommunityTaxCertificateModel CommunityTaxCertificateModel()
        {
            return new CommunityTaxCertificateModel()
            {
                Year = Convert.ToInt32(ucTaxPayerDetails.nudYear.Value),
                PlaceOfIssued = ucTaxPayerDetails.txtPlaceOfIssue.Text,
                DateOfIssued = ucTaxPayerDetails.dtpDateOfIssued.Value,
                FirstName = ucTaxPayerDetails.txtFirstName.Text,
                MiddleName = ucTaxPayerDetails.txtMiddleName.Text,
                LastName = ucTaxPayerDetails.txtLastName.Text,
                Sex = ucTaxPayerDetails.radMale.Checked,
                Citizenship = ucTaxPayerDetails.txtCitizenship.Text,
                Address = ucTaxPayerDetails.txtAddress.Text,
                TIN = ucTaxPayerDetails.txtTIN.Text,
                ICR = ucTaxPayerDetails.txtICR.Text,
                PlaceOfBirth = ucTaxPayerDetails.txtPlaceOfBirth.Text,
                Height = ucTaxPayerDetails.nudHeight.Value,
                Weight = ucTaxPayerDetails.nudWeight.Value,
                CivilStatus = "",
                DateOfBirth = ucTaxPayerDetails.dtpDateOfBirth.Value,
                Profession = ucTaxPayerDetails.txtOccupation.Text,
                BasicCommunityTax = ucTaxDue.nudBasicTax.Value,
                AdditionalCommunityTax = ucTaxDue.AdditionalCommunityTaxSum(),
                CreatedBy = Helper.userId
            };
        }

        private void btnNext_Click(object sender, EventArgs e)
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

        private bool TabValidated()
        {
            switch (tabControlMain.SelectedTab.Name)
            {
                case "tabPageTaxpayer":
                    if (!ucTaxPayerDetails.ValidateChildren())
                    {
                        Helper.MessageBoxError(ucTaxPayerDetails.GetFormErrors());
                        return false;
                    }
                    break;

                case "tabPageTaxDues":

                    if (!ucTaxDue.ValidateChildren())
                    {
                        Helper.MessageBoxError(ucTaxDue.GetFormErrors());
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

                case "tabPageReceipt":
                    if (!ucPrintReceipt.ValidateChildren())
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

        private void ucPrintReceipt1_Load(object sender, EventArgs e)
        {
        }
    }
}