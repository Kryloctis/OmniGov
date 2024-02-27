using ACC.Data;
using AccountingSystem.DataSets;
using AccountingSystem.Views.Manage.TaxPayers;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.AF51_57;

public partial class frmAF51_57 : Form
{
    private readonly ucPaymentFeesCharges ucPaymentFeesCharges;
    private readonly ucPayment ucPayment;

    public frmAF51_57()
    {
        InitializeComponent();
        Helper.LoadFormIcon(this);
        this.ucPaymentFeesCharges = ucPaymentFeesCharges1;
        this.ucPayment = ucPayment1;
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
        btnNextMain.Text = "Confirm Payment";
        btnBackMain.Enabled = true;
        radPayment.Checked = true;

        decimal totalAmountPayable = ucPaymentFeesCharges.ComputeTotalAmountPayable();
        ucPayment1.OnLoad(Helper.userId, string.Empty, totalAmountPayable);
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
                radPayment.Checked = true;
                LoadPaymentTab();
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
        var frmReceipt = new frmAF51Receipt();
        var dataTable = new dsTreasury.dtAF51DataTable();

        foreach (var model in ucPaymentFeesCharges.PaymentFeesChargesModels())
        {
            var newRow = dataTable.NewRow();
            var dictOtherPaymentRate = AccFactory.OtherPaymentRatesRepository().GetRecordByID(model.OtherPaymentRatesId);
            newRow["nature_of_collection"] = $"{dictOtherPaymentRate["description"]} x{model.Unit}";
            newRow["amount"] = model.SubTotal;
            dataTable.Rows.Add(newRow);
        }

        var receiptParameters = new frmAF51Receipt.AF51Parameters()
        {
            Municipality = Helper.selectedServerModel.MunicipalityName.ToUpper(),
            TransactionDate = ucPayment.PaymentCollectionsModel().PaymentDate,
            TotalPayment = ucPayment.PaymentCollectionsModel().Amount,
            TotalPaymentWords = new Helper.AmountToWords().ConvertAmountToWords(ucPayment.PaymentCollectionsModel().Amount.ToString()),
            Payee = ucPayment.PaymentCollectionsModel().Payee,
            IsCash = ucPayment.radPaymentCash.Checked,
            IsCheck = ucPayment.radPaymentCheque.Checked,
            IsMoneyOrder = false,
            Agency = string.Empty,
            ChequeBank = string.Empty,
            ChequeDate = string.Empty,
            ChequeNo = string.Empty,
            CollectingOfficerName = ucPayment.txtCollectingOfficer.Text.Trim(),
            Fund = string.Empty,
            dtAF51DataTable = dataTable
        };

        frmReceipt.OnLoad(receiptParameters);
        frmReceipt.ShowDialog();
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