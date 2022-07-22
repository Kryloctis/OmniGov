using ACC.Domain.Models;
using System;
using System.Transactions;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.PaymentCollection
{
    public partial class frmPaymentCollectionAdd : Form
    {
        private readonly frmPaymentCollection _frmPaymentCollection;
        private readonly ucPaymentCollection uc;

        public frmPaymentCollectionAdd(frmPaymentCollection frmPaymentCollection)
        {
            InitializeComponent();
            _frmPaymentCollection = frmPaymentCollection;
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

                using (var scope = new TransactionScope())
                {
                    var collectingOfficerId = Convert.ToInt32(uc.cmbCollector.SelectedValue);
                    var fundId = Convert.ToInt32(uc.cmbFund.SelectedValue);
                    var accountableFormId = Convert.ToInt32(uc.cmbAccountableForms.SelectedValue);
                    var generalLedgerId = Convert.ToInt32(uc.cmbAccount.SelectedValue);
                    var quantity = 1;
                    var payee = uc.txtPayee.Text.Trim();
                    var receiptNumber = uc.txtReceiptNumber.Text.Trim();
                    var paymentDate = Convert.ToDateTime(uc.dtDateOfCollection.Text.Trim());
                    var amount = Convert.ToDecimal(uc.txtAmount.Value);
                    var createdBy = Helper.UserId;


                    var paymentCollectionModel = new PaymentCollectionModel()
                    {
                        CollectingOfficerId = collectingOfficerId,
                        FundId = fundId,
                        AccountableFormId = accountableFormId,
                        GeneralLedgerAccountId = generalLedgerId,
                        Quantity = quantity,
                        Payee = payee,
                        ReceiptNo = receiptNumber,
                        PaymentDate = paymentDate,
                        Amount = amount,
                        CreatedBy = Helper.UserId,
                    };

                    //CHANGE SOME VALUE IF COLLECTING OFFICER IS JOB ORDER.
                    if (uc.cbCollectorTypeJO.Checked)
                    {
                        var regularCollectingOfficerId = AccFactory.CollectingOfficerHasJobOrdersRepository().GetCollectingOfficerIDByJobOrderId(collectingOfficerId);
                        paymentCollectionModel.CollectingOfficerId = regularCollectingOfficerId;
                        paymentCollectionModel.JobOrderId = collectingOfficerId;
                    }

                    var paymentCollectionRepo = AccFactory.PaymentCollectionRepository();
                    bool insertSuccess = paymentCollectionRepo.Insert(paymentCollectionModel);

                    if (insertSuccess)
                    {
                        UpdateReceiptsCount();   
                        Helper.MessageBoxSuccess("Payment Collection has been saved.");
                        _frmPaymentCollection.LoadRecords();
                        uc.ResetForm();
                        scope.Complete();
                    }
                };
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


                using (var scope = new TransactionScope()) {

                    var collectingOfficerId = Convert.ToInt32(uc.cmbCollector.SelectedValue);
                    var fundId = Convert.ToInt32(uc.cmbFund.SelectedValue);
                    var accountableFormId = Convert.ToInt32(uc.cmbAccountableForms.SelectedValue);
                    var generalLedgerId = Convert.ToInt32(uc.cmbAccount.SelectedValue);
                    var quantity = Convert.ToInt32(uc.txtCashTicketQuantity.Value);
                    var paymentDate = Convert.ToDateTime(uc.dtCashTicketDateOfCollection.Text.Trim());
                    var amount = Convert.ToDecimal(uc.txtCashTicketsAmount.Text);
                    var createdBy = Helper.UserId;

                    var paymentCollectionModel = new PaymentCollectionModel()
                    {
                        CollectingOfficerId = collectingOfficerId,
                        FundId = fundId,
                        AccountableFormId = accountableFormId,
                        GeneralLedgerAccountId = generalLedgerId,
                        Quantity = quantity,
                        PaymentDate = paymentDate,
                        Amount = amount,
                        CreatedBy = createdBy
                    };

                    //CHANGE SOME VALUE IF COLLECTING OFFICER IS JOB ORDER.
                    if (uc.cbCollectorTypeJO.Checked)
                    {
                        var regularCollectingOfficerId = AccFactory.CollectingOfficerHasJobOrdersRepository().GetCollectingOfficerIDByJobOrderId(collectingOfficerId);
                        paymentCollectionModel.CollectingOfficerId = regularCollectingOfficerId;
                        paymentCollectionModel.JobOrderId = collectingOfficerId;
                    }

                    var paymentCollectionRepo = AccFactory.PaymentCollectionRepository();
                    bool insertSuccess = paymentCollectionRepo.Insert(paymentCollectionModel);

                    if (insertSuccess)
                    {
                        UpdateReceiptsCount();
                        Helper.MessageBoxSuccess("Payment Collection has been saved.");
                        _frmPaymentCollection.LoadRecords();
                        uc.ResetForm();
                        scope.Complete();
                    }

                };

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
                var collectorId = uc.cmbCollector.SelectedValue.ToString();
                var accountableFormId = uc.cmbAccountableForms.SelectedValue.ToString();
                var receiptsIssuedRepo = AccFactory.ReceiptsIssuedRepository();

                var dtReceiptIssued = receiptsIssuedRepo.GetIssuedReceiptByCollectorIdAndAccountableFormId(collectorId, accountableFormId);
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

            uc.txtPayee.Focus();
        }
        #endregion

    }
}
