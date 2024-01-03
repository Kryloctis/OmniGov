using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Transactions.Payments.RealProperty;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments
{
    public partial class frmPaymentRpt : Form
    {
        private readonly ucPaymentTaxpayers ucPaymentTaxpayers;
        private ucPaymentRptTaxDues ucPaymentRptTaxDues;
        private ucPayment ucPayment;

        public frmPaymentRpt()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            ucPaymentTaxpayers = ucPaymentTaxpayers1;
            this.ucPaymentRptTaxDues = ucPaymentRptTaxDues1;
            ucPayment = ucPayment1;
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
                    radPayment.Checked = true;
                    LoadPaymentTab();
                    //ConfirmPayment();
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
            if (!ucPaymentRptTaxDues.ValidateChildren())
            {
                Helper.MessageBoxError(ucPaymentRptTaxDues.GetFormErrors());
                return;
            }

            radPayment.Checked = true;
            btnNext.Text = "Confirm Payment";
            decimal totalPayment = ucPaymentRptTaxDues.GetTotalTaxDue();
            ucPayment.OnLoad(Helper.UserId, "56", totalPayment);
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

                    int index = ucPaymentTaxpayers.dataGridView1.CurrentRow.Index;
                    int taxpayerId = Convert.ToInt32(ucPaymentTaxpayers.dataGridView1.Rows[index].Cells["taxpayers_id"].Value);
                    ucPaymentRptTaxDues.OnLoad(taxpayerId);

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
                    if (ConfirmPayment())
                        Helper.MessageBoxSuccess("Payment has been saved");
                }

                tabControlMain.SelectedIndex++;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool ConfirmPayment()
        {
            var rptPaymentsModel = new RptPaymentsModel() { PostedBy = Helper.UserId, };

            if (Helper.MessageBoxConfirmCancel("Confirm Payment?"))
                return AccFactory.PaymentCollectionsRepository().InsertWithRptPayment(ucPayment.PaymentCollectionsModel(), null, rptPaymentsModel, ucPaymentRptTaxDues.RptTaxDuesModelList());

            return false;
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
    }
}