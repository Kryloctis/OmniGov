using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Dialogs;
using AccountingSystem.Views.Manage.TaxPayers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.BurialPermit
{
    public partial class frmBurialPermit : Form
    {
        private readonly ucTaxPayers ucTaxPayers;
        private readonly ucPayment ucPayment;
        private readonly ucBurialPermit ucBurialPermit;
        private readonly ucPaymentFeesCharges ucOtherCharges;
        private dialogPayment dialog = new dialogPayment();

        public frmBurialPermit()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            ucPayment = ucPayment1;
            ucOtherCharges = ucBurialPermit.ucOtherCharges1;
            //ucOtherCharges.accountableForm = "58";
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
            ucTaxPayers.chckIsActive.Enabled = false;
            ucOtherCharges.OnLoad();
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

            if (selectedTab == tabPageFeesCharges)
            {
                if (!ucBurialPermit.ValidateChildren())
                {
                    Helper.MessageBoxError(ucBurialPermit.GetFormErrors());
                    return false;
                }
            }
            else if (selectedTab == tabPagePayment)
            {
                if (!ucPayment.ValidateChildren())
                {
                    Helper.MessageBoxError(ucPayment.GetFormErrors());
                    return false;
                }
            }

            return true;
        }

        private void ChangeTabs()
        {
            var selectedTab = tabControlMain.SelectedTab;

            if (selectedTab == tabPageFeesCharges)
                tabControlMain.SelectedTab = tabPagePayment;
            else if (selectedTab == tabPagePayment)
                ConfirmPayment();
        }

        private void btnNextMain_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormValidations())
                    return;

                ChangeTabs();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnBackMain_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControlMain.SelectedIndex < 0)
                    return;

                tabControlMain.SelectedIndex = tabControlMain.SelectedIndex - 1;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool SaveBurialPermitPayment(PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, PaymentCollectionsModel paymentCollectionsModel, BurialPermitModel burialPermitModel)
        {
            return AccFactory.PaymentCollectionsRepository().InsertWithBurialPermitPayment(paymentCollectionHasChequesModel, paymentCollectionsModel, burialPermitModel);
        }

        private BurialPermitModel BurialPermitModel()
        {
            var burialPermitModel = new BurialPermitModel();

            var collectingOfficerData = ucPayment.GetCollectingOfficerData();
            bool isJobOrder = Convert.ToBoolean(collectingOfficerData["is_job_order"]);

            burialPermitModel.RemainsName = ucBurialPermit.txtRemainsName.Text;
            burialPermitModel.RemainsNationality = ucBurialPermit.txtRemainsNationality.Text;
            burialPermitModel.RemainsAge = Convert.ToInt32(ucBurialPermit.nudRemainsAge.Value);
            burialPermitModel.RemainsSex = ucBurialPermit.radMale.Checked ? "Male" : "Female";
            burialPermitModel.DeathDate = ucBurialPermit.dtpDeathDate.Value;
            burialPermitModel.CauseOfDeath = ucBurialPermit.txtCauseOfDeath.Text;
            burialPermitModel.Cemetery = ucBurialPermit.txtCemetery.Text;
            burialPermitModel.Disinterment = ucBurialPermit.txtDisinterment.Text;
            burialPermitModel.IsInfectious = ucBurialPermit.radInfectiousYes.Checked;
            burialPermitModel.IsEmbalmed = ucBurialPermit.radEmbalmedYes.Checked;
            burialPermitModel.Disposition = ucBurialPermit.txtDisposition.Text;
            burialPermitModel.CreatedBy = Helper.UserId;

            return burialPermitModel;
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

                e.Result = SaveBurialPermitPayment(paymentCollectionHasChequesModel, ucPayment.PaymentCollectionsModel(), BurialPermitModel());
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

        private void LoadFeesAndChargesTab()
        {
            btnBackMain.Enabled = true;
            btnNextMain.Text = "Proceed to Payment";
            radFees.Checked = true;
        }

        private void LoadPaymentTab()
        {
            btnNextMain.Text = "Confirm Payment";
            btnBackMain.Enabled = true;
            radPayment.Checked = true;

            decimal totalAmountPayable = 0;
            ucPayment.OnLoad("58", totalAmountPayable);
        }

        private void tabPagePayment_Enter(object sender, EventArgs e)
        {
            try
            {
                LoadPaymentTab();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tabPageFees_Enter(object sender, EventArgs e)
        {
            try
            {
                LoadFeesAndChargesTab();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}