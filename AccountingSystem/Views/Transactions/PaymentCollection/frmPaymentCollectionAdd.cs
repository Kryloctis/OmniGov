using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.PaymentCollection
{
    public partial class frmPaymentCollectionAdd : Form
    {
        private readonly frmPaymentCollection _frmPaymentCollection;
        private readonly ucPaymentCollection uc;

        public frmPaymentCollectionAdd(frmPaymentCollection frmpc)
        {
            InitializeComponent();
            _frmPaymentCollection = frmpc;
            ucPaymentCollection1.userid = Helper.UserId;
            uc = ucPaymentCollection1;
        }

        private void frmPaymentCollectionAdd_Load(object sender, EventArgs e)
        {

            if(ucPaymentCollection1.cmdCollector.Items.Count > 0)
            {
                var uRepository = Factory.UsersRepository();
                if (uRepository.LinkedCollector(Helper.UserId))
                {
                    var colRepository = Factory.CollectingOfficerRepository();
                    var data = colRepository.GetRecordByUserID(Helper.UserId);
                    ucPaymentCollection1.cmdCollector.SelectedValue = data["id"];
                    ucPaymentCollection1.cmdCollector.Enabled = false;
                }
            }

        }

        private bool SaveData()
        {
            try
            {
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                var paymentCollectionModel = new PaymentCollectionModel()
                {
                    CollectingOfficerId = Convert.ToInt32(uc.cmdCollector.SelectedValue),
                    FundId = Convert.ToInt32(uc.cmbFund.SelectedValue),
                    AccountableFormId = Convert.ToInt32(uc.cmbAccountableForms.SelectedValue),
                    GeneralLedgerAccountId = uc.generalLedgerId,
                    Quantity = 1,
                    Payee = uc.txtpayee.Text.Trim(),
                    ReceiptNo = uc.txtreceipt.Text.Trim(),
                    PaymentDate = Convert.ToDateTime(uc.dtDateOfCollection.Text.Trim()),
                    Amount = Convert.ToDecimal(uc.txtAmount.Value),
                    CreatedBy = Helper.UserId,
                };

                var paymentCollectionRepo = Factory.PaymentCollectionRepository();
                bool insertSuccess = paymentCollectionRepo.Insert(paymentCollectionModel);

                if (insertSuccess)
                    return UpdateReceiptsCount();
                else
                    return false;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxWarning(ex.Message);
            }
            return false;
        }

        private bool UpdateReceiptsCount()
        {
            try
            {
                var collectorId = uc.cmdCollector.SelectedValue.ToString();
                var accountableFormId = uc.cmbAccountableForms.SelectedValue.ToString();
                var receiptsIssuedRepo = Factory.ReceiptsIssuedRepository();

                var dtReceiptIssued = receiptsIssuedRepo.GetRecords(collectorId, accountableFormId);
                var receiptIssuedCount = dtReceiptIssued.Rows.Count;

                if (receiptIssuedCount > 0)
                {
                    int rid = 0;
                    for (int i = 0; i < receiptIssuedCount; i++)
                    {
                        rid = Convert.ToInt32(dtReceiptIssued.Rows[i]["id"]);
                    }


                    var rcModel = new ReceiptsIssuedModel()
                    {
                        Id = rid,
                        Last_issued = Convert.ToInt32(uc.txtreceipt.Text.Trim())
                    };
                    return receiptsIssuedRepo.UpdateCurrentIssued(rcModel);
                }

                return false;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isFormCashTicket = uc.isCashTicket;

            if (isFormCashTicket)
            {
                uc.CancelReceiptFieldValidations(true);
                SaveCashTickets();
            }
            else
            {
                uc.CancelCashTicketFieldValidations(true);
                SaveReceipts();
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


                var paymentCollectionModel = new PaymentCollectionModel()
                {
                    CollectingOfficerId = Convert.ToInt32(uc.cmdCollector.SelectedValue),
                    FundId = Convert.ToInt32(uc.cmbFund.SelectedValue),
                    AccountableFormId = Convert.ToInt32(uc.cmbAccountableForms.SelectedValue),
                    GeneralLedgerAccountId = uc.generalLedgerId,
                    Quantity = Convert.ToInt32(uc.txtCashTicketQuantity.Value),
                    PaymentDate = Convert.ToDateTime(uc.dtCashTicketDateOfCollection.Text.Trim()),
                    Amount = Convert.ToDecimal(uc.txtCashTicketsAmount.Text),
                    CreatedBy = Helper.UserId,
                };

                var paymentCollectionRepo = Factory.PaymentCollectionRepository();
                bool insertSuccess = paymentCollectionRepo.Insert(paymentCollectionModel);

                if (insertSuccess)
                {
                    Helper.MessageBoxSuccess("Payment Collection has been saved.");
                    _frmPaymentCollection.LoadRecords();
                    uc.ResetForm();
                }
                
            }
            catch (Exception ex)
            {
                Helper.MessageBoxWarning(ex.Message);
            }
        }



        private void SaveReceipts()
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Payment Collection has been saved.");
                _frmPaymentCollection.LoadRecords();
                uc.ResetForm();


                uc.cmbcollector_SelectedIndexChanged(this, EventArgs.Empty);
                uc.cmbforms_SelectedIndexChanged(this, EventArgs.Empty);
                uc.cmbforms_SelectedValueChanged(this, EventArgs.Empty);

            }
        }

    }
}
