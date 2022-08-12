using ACC.Domain.Models;
using System;
using System.Transactions;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.PaymentCollection
{
    public partial class frmPaymentCollectionAdd : Form
    {
        private readonly ucPaymentCollection uc;

        public frmPaymentCollectionAdd()
        {
            InitializeComponent();
            uc = ucPaymentCollection1;
            uc.userId = Helper.UserId;
        }
        
        private void frmPaymentCollectionAdd_Load(object sender, EventArgs e)
        {

        }

        private void SaveReceipts()
        {
            try
            {
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return;
                }

                var collectingOfficerId = Convert.ToInt32(uc.cmbCollector.SelectedValue);
                var fundId = Convert.ToInt32(uc.cmbFund.SelectedValue);
                var accountableFormID = Convert.ToInt32(uc.cmbAccountableForms.SelectedValue);
                var generalLedgerAccountsID = Convert.ToInt32(uc.cmbAccount.SelectedValue);
                var payee = uc.txtPayee.Text.Trim();
                var receiptNumber = uc.txtReceiptNumber.Text.Trim();
                var paymentDate = Convert.ToDateTime(uc.dtDateOfCollection.Text.Trim());
                var amount = Convert.ToDecimal(uc.txtAmount.Value);
                var createdBy = Helper.UserId;


                var paymentCollectionModel = new PaymentCollectionsModel()
                {
                    CollectingOfficerId = collectingOfficerId,
                    FundId = fundId,
                    AccountableFormId = accountableFormID,
                    Payee = payee,
                    ReceiptNo = receiptNumber,
                    PaymentDate = paymentDate,
                    Amount = amount,
                    IsCancelled = false,
                    CreatedBy = Helper.UserId
                };

                if (uc.cbJOCollector.Checked)
                {
                    var regularCollectingOfficerId = AccFactory.CollectingOfficerHasJobOrdersRepository().GetCollectingOfficerIDByJobOrderId(collectingOfficerId);
                    paymentCollectionModel.CollectingOfficerId = regularCollectingOfficerId;
                    paymentCollectionModel.JobOrderId = collectingOfficerId;
                }

                var paymentCollectionRepo = AccFactory.PaymentCollectionsRepository().InsertWithGeneralPayment(paymentCollectionModel,  new GeneralPaymentsModel() { Quantity = 1});

                Helper.MessageBoxSuccess("Payment Collection has been saved.");
                UpdateReceiptsCount();
                return; 

            }
            catch (Exception ex)
            {
                Helper.MessageBoxWarning(ex.Message);
            }

        }

        private void SaveCashTickets()
        {
            try
            {
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return;
                }

                var collectingOfficerID = Convert.ToInt32(uc.cmbCollector.SelectedValue);
                var fundId = Convert.ToInt32(uc.cmbFund.SelectedValue);
                var accountableFormID = Convert.ToInt32(uc.cmbAccountableForms.SelectedValue);
                var quantity = Convert.ToInt32(uc.txtCashTicketQuantity.Value);
                var paymentDate = Convert.ToDateTime(uc.dtCashTicketDateOfCollection.Text.Trim());
                var amount = Convert.ToDecimal(uc.txtCashTicketsAmount.Text);
                var createdBy = Helper.UserId;

                var paymentCollectionModel = new PaymentCollectionsModel()
                {
                    CollectingOfficerId = collectingOfficerID,
                    FundId = fundId,
                    AccountableFormId = accountableFormID,
                    PaymentDate = paymentDate,
                    Amount = amount,
                    CreatedBy = createdBy
                };

                if (uc.cbJOCollector.Checked)
                {
                    var regularCollectingOfficerId = AccFactory.CollectingOfficerHasJobOrdersRepository().GetCollectingOfficerIDByJobOrderId(collectingOfficerID);
                    paymentCollectionModel.CollectingOfficerId = regularCollectingOfficerId;
                    paymentCollectionModel.JobOrderId = collectingOfficerID;
                }

                var paymentCollectionRepo = AccFactory.PaymentCollectionsRepository().InsertWithGeneralPayment(paymentCollectionModel, new GeneralPaymentsModel() { Quantity = quantity});

                Helper.MessageBoxSuccess("Payment Collection has been saved.");
                UpdateReceiptsCount();
                return;


            }
            catch (Exception ex)
            {
                Helper.MessageBoxWarning(ex.Message);
            }
        }

        private void UpdateReceiptsCount()
        {
            try
            {
                var collectorId = Convert.ToInt32(uc.cmbCollector.SelectedValue);
                var accountableFormId = Convert.ToInt32(uc.cmbAccountableForms.SelectedValue);
                var receiptsIssuedRepo = AccFactory.ReceiptsIssuedRepository();

                var dtReceiptIssued = receiptsIssuedRepo.GetIssuedReceiptToCollector(collectorId, accountableFormId);
                var receiptIssuedCount = dtReceiptIssued.Rows.Count;

                if (receiptIssuedCount == 0)
                    return;

                int issuanceId = 0;

                for (int i = 0; i < receiptIssuedCount; i++)
                    issuanceId = Convert.ToInt32(dtReceiptIssued.Rows[i]["id"]);
               

                var receiptIssuedModel = new ReceiptsIssuedModel()
                {
                    Id = issuanceId,
                    Last_issued = Convert.ToInt32(uc.txtReceiptNumber.Text.Trim())
                };
                receiptsIssuedRepo.UpdateLastIssued(receiptIssuedModel);
             
            }
            catch (Exception)
            {

                throw;
            }
        }


        #region Form Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isFormCashTicket = uc.isCashTicket;

            if (isFormCashTicket)
            {
                uc.CancelNonCashTicketFieldValidations(true);
                SaveCashTickets();
            }
            else
            {
                uc.CancelCashTicketFieldValidations(true);
                SaveReceipts();
            }

            uc.ResetForm();     
            uc.txtPayee.Focus();
        }
        #endregion

    }
}
