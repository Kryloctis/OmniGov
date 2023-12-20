using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
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

        private dialogPayment dialog = new dialogPayment();

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

        private void frmMarriageLicense_Load(object sender, EventArgs e)
        {
            try
            {
                LoadTabContents();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ConfirmPayment()
        {
            try
            {
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
            btnNextMain.Text = "Confirm Payment";
            btnBackMain.Enabled = true;
            radPayment.Checked = true;

            decimal totalPayment = ucPaymentFeesCharges.ComputeTotalAmountPayable();
            ucPayment.OnLoad("54", totalPayment);
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
                    radPayment.Checked = true;
                    LoadPaymentTab();
                    //ConfirmPayment();
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
                var chequesModels = new List<ChequesModel>();
                int totalProgressCount = ucPayment.dgCheques.Rows.Count;
                int progressCount = 0;
                var paymentCollectionHasChequesModel = new PaymentCollectionHasChequesModel();

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
                        var banksModel = new BanksModel()
                        {
                            BankName = bankName,
                            BankBranch = bankBranch
                        };

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

                e.Result = "complete";
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
            if (e.Result.ToString() == "complete")
            {
                dialog.label1.Text = "Payment Process Complete!";
                dialog.btnClose.Enabled = true;
                btnNextMain.Text = "Finish";
                ucPayment.Enabled = false;
                return;
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
    }
}