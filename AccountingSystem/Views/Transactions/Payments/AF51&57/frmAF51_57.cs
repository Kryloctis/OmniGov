using ACC.Data;
using System;
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
        ucPayment1.OnLoad(Helper.UserId, string.Empty, totalAmountPayable);
    }

    private bool ConfirmPayment()
    {
        if (!TabValidated())
            return false;

        if (Helper.MessageBoxConfirmCancel("Confirm Payment?"))
            return AccFactory.PaymentCollectionsRepository().InsertWithFeesCharges(ucPayment.PaymentCollectionsModel(), null, ucPaymentFeesCharges.PaymentFeesChargesModels());

        return false;
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
            if (tabControlMain.SelectedTab.Name == "tabPagePayment" && TabValidated())
            {
                if (ConfirmPayment())
                    Helper.MessageBoxSuccess("Payment has been saved");
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