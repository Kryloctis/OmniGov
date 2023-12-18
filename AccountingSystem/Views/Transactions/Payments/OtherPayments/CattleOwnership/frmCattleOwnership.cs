using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Dialogs;
using AccountingSystem.Views.Manage.RptPenalties;
using AccountingSystem.Views.Manage.TaxPayers;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.CattleOwnership
{
    public partial class frmCattleOwnership : Form
    {
        private readonly ucPayment ucPayment;
        private dialogPayment dialog = new dialogPayment();
        private readonly ucPaymentFeesCharges ucPaymentFeesCharges;
        private readonly ucPaymentRegistry ucPaymentRegistry;
        private readonly ucCattleDetails ucCattleDetails;

        public frmCattleOwnership()
        {
            InitializeComponent();
            ucPayment = ucPayment1;
            this.ucPaymentFeesCharges = ucPaymentFeesCharges1;
            ucCattleDetails = ucCattleDetails1;
            ucPaymentRegistry = ucPaymentRegistry1;
        }

        #region Private Methods

        private void OnLoad()
        {
            LoadTabContents();
        }

        private void ConfirmPayment()
        {
            try
            {
                if (!TabValidated())
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

        private bool TabValidated()
        {
            switch (tabControlMain.SelectedTab.Name)
            {
                case "tabPageOwner":
                    if (!ucPaymentRegistry.FormValidated("owner"))
                    {
                        Helper.MessageBoxError(ucPaymentRegistry.GetFormErrors());
                        return false;
                    }
                    break;

                case "tabPageCattleDetails":
                    if (!ucCattleDetails.ValidateChildren())
                    {
                        Helper.MessageBoxError(ucCattleDetails.GetFormErrors());
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

        private bool SaveCattleOwnership(PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, PaymentCollectionsModel paymentCollectionsModel, CattleOwnershipModel cattleOwnershipModel)
        {
            return AccFactory.PaymentCollectionsRepository().InsertWithCattleOwnershipPayment(paymentCollectionHasChequesModel, paymentCollectionsModel, cattleOwnershipModel);
        }

        private CattleOwnershipModel CattleOwnershipModel()
        {
            var cattleOwnershipModel = new CattleOwnershipModel();
            //var collectingOfficerData = ucPayment.GetCollectingOfficerData();
            //bool isJobOrder = Convert.ToBoolean(collectingOfficerData["is_job_order"]);

            //cattleOwnershipModel.OwnerID = ucCattleOwnership.ownerID;
            //cattleOwnershipModel.Tag = 1;
            //cattleOwnershipModel.OwnerName = ucCattleOwnership.txtOwnerName.Text;
            //cattleOwnershipModel.OwnerBarangay = ucCattleOwnership.cmbxBarangay.Text;
            //cattleOwnershipModel.OwnerMunicipality = ucCattleOwnership.cmbxMunicipality.Text;
            //cattleOwnershipModel.OwnerProvince = ucCattleOwnership.cmbxProvince.Text;
            //cattleOwnershipModel.CattleType = ucCattleOwnership.cmbxType.Text;
            //cattleOwnershipModel.CattleSex = ucCattleOwnership.radCattleMale.Checked ? "Male" : "Female";
            //cattleOwnershipModel.CattleAge = Convert.ToInt32(ucCattleOwnership.nudAge.Value);
            //cattleOwnershipModel.Description = ucCattleOwnership.txtDescription.Text;
            //cattleOwnershipModel.CreatedBy = Helper.UserId;
            //cattleOwnershipModel.CreatedAt = DateTime.Now;

            return cattleOwnershipModel;
        }

        private void LoadTabContents()
        {
            if (tabControlMain.SelectedIndex == 0)
                btnBackMain.Enabled = false;
            else
                btnBackMain.Enabled = true;

            switch (tabControlMain.SelectedTab.Name)
            {
                case "tabPageOwner":
                    LoadOwner();
                    break;

                case "tabPageCattleDetails":
                    LoadCattleDetailsTab();
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

        private void LoadOwner()
        {
            radOwner.Checked = true;
            btnNextMain.Text = "Next";
            ucPaymentRegistry.LoadRegistry();
        }

        private void LoadCattleDetailsTab()
        {
            btnNextMain.Text = "Next";
            radCattleDetails.Checked = true;
        }

        private void LoadFeesAndChargesTab()
        {
            btnNextMain.Text = "Proceed to Payment";
            btnBackMain.Enabled = true;
            radFeesCharges.Checked = true;
            ucPaymentFeesCharges.OnLoad();
        }

        private void LoadPaymentTab()
        {
            btnNextMain.Text = "Confirm Payment";
            btnBackMain.Enabled = true;
            radPayment.Checked = true;

            decimal totalAmountPayable = ucPaymentFeesCharges.ComputeTotalAmountPayable();
            ucPayment.OnLoad("53", totalAmountPayable);

            //if (isNewPayee)
            //    ucPayment.txtPayee.Text = ucTaxPayers.txtName.Text;
            //else
            //ucPayment.txtPayee.Text = GetTaxPayerData()["taxpayer_name"];
        }

        #endregion Private Methods

        #region Event Handlers

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
                    Helper.ProgressCounter(bgwSavingPayment, totalProgressCount, progressCount);
                    chequesModels.Add(model);
                }

                paymentCollectionHasChequesModel.ChequesModels = chequesModels;

                var methodInvoker = new MethodInvoker(delegate
                {
                    SaveCattleOwnership(paymentCollectionHasChequesModel, ucPayment.PaymentCollectionsModel(), CattleOwnershipModel());
                });

                Invoke(methodInvoker);
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

        private void frmCattleOwnership_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        #endregion Event Handlers
    }
}