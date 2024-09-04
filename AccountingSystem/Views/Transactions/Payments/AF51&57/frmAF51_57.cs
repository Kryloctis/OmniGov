using ACC.Data;
using AccountingSystem.DataSets;
using AccountingSystem.Views.Transactions.Payments.BurialPermit;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.AF51_57;

public partial class frmAF51_57 : Form
{
    private readonly ucPaymentFeesCharges ucPaymentFeesCharges;
    private readonly ucPayment ucPayment;
    private ucPrintReceipt ucPrintReceipt;

    public frmAF51_57()
    {
        InitializeComponent();
        Helper.LoadFormIcon(this);
        Helper.RemoveTabcontrolTabs(tabControlMain);
        this.ucPaymentFeesCharges = ucPaymentFeesCharges1;
        this.ucPayment = ucPayment1;
        this.ucPrintReceipt = ucPrintReceipt1;
    }

    private void ResetForm()
    {
        ucPaymentFeesCharges.ResetForm();
        ucPayment.ResetForm();
        tabControlMain.SelectedTab = tabPageFeesCharges;
    }

    private void LoadFeesAndChargesTab()
    {
        btnNextMain.Text = "Proceed to Payment";
        btnBackMain.Enabled = false;
        radFeesCharges.Checked = true;
        ucPaymentFeesCharges.OnLoad();
    }

    private void LoadPaymentTab()
    {
        radPayment.Checked = true;
        btnNextMain.Text = "Confirm Payment";
        btnBackMain.Enabled = true;

        decimal totalAmountPayable = ucPaymentFeesCharges.ComputeTotalAmountPayable();
        ucPayment1.OnLoad(Helper.userId, string.Empty, totalAmountPayable);
    }

    private void LoadReceipt()
    {
        var dataTable = new dsTreasury.dtAF51DataTable().Clone();

        foreach (var model in ucPaymentFeesCharges.PaymentFeesChargesModels())
        {
            var newRow = dataTable.NewRow();
            var dictOtherPaymentRate = AccFactory.OtherPaymentRatesRepository().GetRecordByID(model.OtherPaymentRatesId);
            newRow["nature_of_collection"] = $"{dictOtherPaymentRate["description"]} x{model.Unit}";
            newRow["amount"] = model.SubTotal;
            dataTable.Rows.Add(newRow);
        }

        var reportDataSource = new ReportDataSource("dtAF51", dataTable);

        var dictParameters = new Dictionary<string, string>()
        {
            {"paramMunicipality",Helper.selectedServerModel.MunicipalityName.ToUpper()},
            {"paramTransactionDate",ucPayment.PaymentCollectionsModel().PaymentDate.ToString()},
            {"paramTotalPayment",ucPayment.PaymentCollectionsModel().Amount.ToString()},
            {"paramTotalPaymentWords",new Helper.AmountToWords().ConvertAmountToWords(ucPayment.PaymentCollectionsModel().Amount.ToString())},
            {"paramPayee",ucPayment.PaymentCollectionsModel().Payee},
            {"paramIsCash",ucPayment.radPaymentCash.Checked.ToString()},
            {"paramIsCheck",ucPayment.radPaymentCheque.Checked.ToString()},
            {"paramIsMoneyOrder",false.ToString()},
            {"paramAgency",string.Empty},
            {"paramChequeBank",string.Empty},
            {"paramChequeNo",string.Empty},
            {"paramChequeDate",string.Empty},
            {"paramCollectingOfficerName",ucPayment.txtCollectingOfficer.Text.Trim()},
            {"paramFund",string.Empty},
        };

        string reportPath = $"{Application.StartupPath}\\Receipts\\AF51.rdlc";
        ucPrintReceipt.Onload(reportPath, dictParameters, reportDataSource);
    }

    private void LoadReceiptTab()
    {
        btnNextMain.Text = "New Transaction";
        LoadReceipt();
    }

    private bool ConfirmPayment()
    {
        return AccFactory.PaymentCollectionsRepository().InsertWithFeesCharges(ucPayment.PaymentCollectionsModel(), null, ucPaymentFeesCharges.PaymentFeesChargesModels());
    }

    private bool TabValidated()
    {
        switch (tabControlMain.SelectedTab.Name)
        {
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

    private void OnLoad()
    {
        LoadTabContents();
    }

    private void LoadTabContents()
    {
        if (tabControlMain.SelectedIndex == 0)
            btnBackMain.Enabled = false;
        else
            btnBackMain.Enabled = true;

        switch (tabControlMain.SelectedTab.Name)
        {
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

    private void frmAF51_57_Load(object sender, EventArgs e)
    {
        try
        {
            OnLoad();
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