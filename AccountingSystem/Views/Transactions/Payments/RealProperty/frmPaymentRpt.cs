using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.DataSets;
using AccountingSystem.Views.Transactions.Payments.BurialPermit;
using AccountingSystem.Views.Transactions.Payments.RealProperty;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments
{
    public partial class frmPaymentRpt : Form
    {
        private readonly ucPaymentTaxpayers ucPaymentTaxpayers;
        private ucPaymentRptTaxDues ucPaymentRptTaxDues;
        private ucPayment ucPayment;
        private ucPrintReceipt ucPrintReceipt;

        public frmPaymentRpt()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.RemoveTabcontrolTabs(tabControlMain);
            ucPaymentTaxpayers = ucPaymentTaxpayers1;
            ucPaymentRptTaxDues = ucPaymentRptTaxDues1;
            ucPayment = ucPayment1;
            ucPrintReceipt = ucPrintReceipt1;
        }

        private void ResetForm()
        {
            ucPayment.ResetForm();
            ucPaymentTaxpayers.ResetForm();
            ucPaymentRptTaxDues.ResetForm();
            tabControlMain.SelectedIndex = 0;
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
                    LoadTaxpayerTab();
                    break;

                case "tabPageTaxDues":
                    LoadTaxDuesTab();
                    break;

                case "tabPagePayment":
                    LoadPaymentTab();
                    break;

                case "tabPageReceipt":
                    LoadReceiptTab();
                    break;
            }
        }

        private void LoadTaxpayerTab()
        {
            radTaxpayer.Checked = true;
            btnNext.Text = "Next";
        }

        private void LoadTaxDuesTab()
        {
            radTaxDues.Checked = true;
            btnNext.Text = "Proceed to Payment";
        }

        private void LoadPaymentTab()
        {
            radPayment.Checked = true;

            if (!ucPaymentRptTaxDues.ValidateChildren())
            {
                Helper.MessageBoxError(ucPaymentRptTaxDues.GetFormErrors());
                return;
            }

            radPayment.Checked = true;
            btnNext.Text = "Confirm Payment";
            decimal totalPayment = ucPaymentRptTaxDues.GetTotalTaxDue();
            ucPayment.OnLoad(Helper.userId, "56", totalPayment);
        }

        private void LoadReceiptTab()
        {
            btnNext.Text = "New Transaction";
            LoadReceipt();
        }

        private void LoadReceipt()
        {
            var dtAf56 = new dsTreasury.dtAF56DataTable().Clone();
            var taxpayerId = ucPaymentTaxpayers.GetSelectedTaxpayerId();
            var dataSource = (DataTable)ucPaymentRptTaxDues.dgTaxDues.DataSource;
            var filteredRows = dataSource.AsEnumerable().Where(row => row.Field<bool>("is_selected")).CopyToDataTable();
            var dictTaxpayer = AccFactory.TaxpayersRepository().GetRecordByID(taxpayerId);

            foreach (DataRow row in filteredRows.Rows)
            {
                var newRow = dtAf56.NewRow();

                newRow["owner"] = dictTaxpayer["name"];
                newRow["location"] = "sample";
                newRow["block_lot_no"] = "sample";
                newRow["tax_dec_no"] = row["complete_arp_no"];
                newRow["assessed_value"] = 100;
                newRow["type"] = row["type"];
                newRow["tax_due"] = row["tax_due_amount"];
                newRow["penalt_discount"] = row["penalty_discount"];
                newRow["total"] = row["total_payment"];

                dtAf56.Rows.Add(newRow);
            }

            var reportDataSource = new ReportDataSource("dtAF56", dtAf56);

            decimal totalPayment = ucPaymentRptTaxDues.GetTotalTaxDue();

            var dictParameters = new Dictionary<string, string>()
            {
                { "paramAmountInFigures", $"{new Helper.AmountToWords().ConvertAmountToWords(totalPayment.ToString("N2"))} only."},
                { "paramSumOf", totalPayment.ToString()},
                { "paramReceivedFrom", ucPayment.txtPayee.Text.Trim()},
                { "paramMunicipality", Helper.selectedServerModel.MunicipalityName},
                { "paramDate", ucPayment.dtPaymentDate.Value.ToString()},
                { "paramCalendarYear", ucPaymentRptTaxDues.nudCalendarYear.Value.ToString()},
                { "paramMunicipalTreasurer", string.Empty},
                { "paramProvincialTreasurer", string.Empty},
                { "paramPaidCash", totalPayment.ToString()},
                { "paramCheckNo", string.Empty},
                { "paramTwPmo", string.Empty},
                { "paramTotalPaid", totalPayment.ToString()},
                { "paramTotalPayment", totalPayment.ToString()},
                { "paramBankDate", string.Empty},
            };

            string reportPath = $"{Application.StartupPath}\\Receipts\\AF56.rdlc";
            ucPrintReceipt.Onload(reportPath, dictParameters, reportDataSource);
        }

        private bool TabValidated()
        {
            switch (tabControlMain.SelectedTab.Name)
            {
                case "tabPageTaxpayer":
                    if (!ucPaymentTaxpayers.IsValidated())
                    {
                        Helper.MessageBoxError(ucPaymentTaxpayers.GetFormErrors());
                        return false;
                    }

                    ucPaymentRptTaxDues.OnLoad(ucPaymentTaxpayers.GetSelectedTaxpayerId());

                    return true;

                case "tabPageTaxDues":
                    if (!ucPaymentRptTaxDues.ValidateChildren())
                    {
                        Helper.MessageBoxError(ucPaymentRptTaxDues.GetFormErrors());
                        return false;
                    }
                    return true;

                case "tabPagePayment":
                    if (!ucPayment.ValidateChildren())
                    {
                        Helper.MessageBoxError(ucPayment.GetFormErrors());
                        return false;
                    }
                    return true;

                default:
                    return true;
            }
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

        private bool ConfirmPayment()
        {
            var rptPaymentsModel = new RptPaymentsModel() { PostedBy = Helper.userId, };

            return AccFactory.PaymentCollectionsRepository().InsertWithRptPayment(ucPayment.PaymentCollectionsModel(), null, rptPaymentsModel, ucPaymentRptTaxDues.RptTaxDuesModelList());
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                tabControlMain.SelectedIndex--;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmRptPayments_Load(object sender, EventArgs e)
        {
            try
            {
                LoadTabContents();
                ucPaymentTaxpayers.OnLoad();
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

        private void frmPaymentRpt_FormClosing(object sender, FormClosingEventArgs e)
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