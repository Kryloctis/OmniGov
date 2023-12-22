using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Dialogs;
using AccountingSystem.Views.Manage.TaxPayers;
using AccountingSystem.Views.Transactions.Payments.BurialPermit;
using AccountingSystem.Views.Transactions.Payments.MarriageLicense;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.BurialPermit
{
    public partial class frmBurialPermit : Form
    {
        private readonly ucPayment ucPayment;
        private readonly ucBurialDetails ucBurialDetails;
        private readonly ucRemainsInfo ucRemainsInfo;
        private readonly ucPaymentFeesCharges ucPaymentFeesCharges;
        private dialogPayment dialog = new dialogPayment();

        public frmBurialPermit()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            ucPayment = ucPayment1;
            ucBurialDetails = ucBurialDetails1;
            ucRemainsInfo = ucRemainsInfo1;
            ucPaymentFeesCharges = ucPaymentFeesCharges1;
        }

        private void frmBurialPermit_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            LoadTabContents();
            ucBurialDetails.OnLoad();
        }

        private void ConfirmPayment()
        {
            try
            {
                if (!FormValidations())
                    return;

                if (!Helper.MessageBoxConfirmCancel("Are you sure to confirm the payment?"))
                    return;

                bgwSavingPayment.RunWorkerAsync();
                dialog.ShowDialog();
                dialog.Text = "Processing Payment...";
                dialog.label1.Text = "Processing Payment...";
            }
            catch (Exception ex)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Transaction cancelled");
                sb.AppendLine(ex.Message);
                Helper.MessageBoxError(sb.ToString());
            }
        }

        private bool FormValidations()
        {
            var selectedTab = tabControlMain.SelectedTab;
            if (selectedTab == tabPagePayment)
            {
                if (!ucPayment.ValidateChildren())
                {
                    Helper.MessageBoxError(ucPayment.GetFormErrors());
                    return false;
                }
            }

            return true;
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

        private void LoadBurialDetailsTab()
        {
            radBurialDetails.Checked = true;
            btnNextMain.Text = "Next";
        }

        private void LoadRemainsInfoTab()
        {
            radRemainsInfo.Checked = true;
            btnNextMain.Text = "Next";
            ucRemainsInfo.deathDate = ucBurialDetails.dtDeathDate.Value;
            ucRemainsInfo.OnLoad();
        }

        private void LoadFeesAndChargesTab()
        {
            btnNextMain.Text = "Proceed to Payment";
            radFees.Checked = true;
            ucPaymentFeesCharges.OnLoad();
        }

        private void LoadPaymentTab()
        {
            btnNextMain.Text = "Confirm Payment";
            radPayment.Checked = true;

            decimal totalAmountPayable = ucPaymentFeesCharges.ComputeTotalAmountPayable();
            ucPayment.OnLoad("58", totalAmountPayable);
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
                    radPayment.Checked = true;
                    LoadPaymentTab();
                    //ConfirmPayment();
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

        private void btnNextMain_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TabValidated())
                    return;

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

        private void bgwSavingPayment_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int totalProgressCount = ucPayment.dgCheques.Rows.Count;
                int progressCount = 0;
                var paymentCollectionHasChequesModel = new PaymentCollectionHasChequesModel();

                var chequesModels = new List<ChequesModel>();

                foreach (DataGridViewRow row in ucPayment.dgCheques.Rows)
                {
                    string bankAccountNo = row.Cells["bank_account_no"].Value.ToString();
                    string bankName = row.Cells["bank_name"].Value.ToString();
                    var rowBankBranch = row.Cells["bank_branch"].Value;
                    string bankBranch = rowBankBranch == null ? string.Empty : rowBankBranch.ToString();
                    decimal chequeAmount = Convert.ToDecimal(row.Cells["cheque_amount"].Value);
                    DateTime chequeDate = Convert.ToDateTime(row.Cells["cheque_date"].Value);
                    string chequeNo = row.Cells["cheque_no"].Value.ToString();
                    bool bankAccountExist = AccFactory.BankAccountsRepository().bankAccountExist(bankAccountNo, bankName);

                    int bankAccountId;

                    if (!bankAccountExist)
                    {
                        //banks model
                        var banksModel = new BanksModel()
                        {
                            BankName = bankName,
                            BankBranch = bankBranch
                        };

                        //bank accounts model
                        var bankAccountModel = new BankAccountsModel()
                        {
                            AccountNumber = bankAccountNo,
                            banksModel = banksModel
                        };

                        AccFactory.BankAccountsRepository().InsertWithBank(bankAccountModel);
                        bankAccountId = AccFactory.BankAccountsRepository().GetLastInsertedId();
                    }
                    else
                        bankAccountId = Convert.ToInt32(AccFactory.BankAccountsRepository().GetViewRecordByAccountNoBankName(bankAccountNo, bankName)["id"]);

                    var model = new ChequesModel()
                    {
                        Amount = chequeAmount,
                        ChequeDate = chequeDate,
                        ChequeNo = chequeNo,
                        BankAccountsId = bankAccountId
                    };

                    progressCount++;
                    chequesModels.Add(model);
                    Helper.ProgressCounter(bgwSavingPayment, totalProgressCount, progressCount);
                }

                paymentCollectionHasChequesModel.ChequesModels = chequesModels;

                //e.Result = SaveBurialPermitPayment(paymentCollectionHasChequesModel, ucPayment.PaymentCollectionsModel(), BurialPermitModel());
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void bgwSavingPayment_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            dialog.label1.Text = e.ProgressPercentage.ToString();
            dialog.btnClose.Enabled = false;
        }

        private void bgwSavingPayment_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is not bool isPaymentSave)
                return;

            if (isPaymentSave)
            {
                dialog.label1.Text = "Payment Process Complete!";
                dialog.btnClose.Enabled = true;
                btnNextMain.Text = "Finish";
                ucPayment.Enabled = false;
                return;
            }
        }
    }
}