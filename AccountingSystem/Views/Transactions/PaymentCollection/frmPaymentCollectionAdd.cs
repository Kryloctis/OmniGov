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

        public frmPaymentCollectionAdd(frmPaymentCollection frmpc)
        {
            InitializeComponent();
            _frmPaymentCollection = frmpc;
            ucPaymentCollection1.userid = Helper.UserId;
        }

        private void frmPaymentCollectionAdd_Load(object sender, EventArgs e)
        {
            ucPaymentCollection1.LoadForms();
            ucPaymentCollection1.LoadCollectors();
            ucPaymentCollection1.LoadFunds();

            if(ucPaymentCollection1.cmbcollector.Items.Count > 0)
            {
                var uRepository = Factory.UsersRepository();
                if (uRepository.LinkedCollector(Helper.UserId))
                {
                    var colRepository = Factory.CollectingOfficerRepository();
                    var data = colRepository.GetRecordByUserID(Helper.UserId);
                    ucPaymentCollection1.cmbcollector.SelectedValue = data["id"];
                    ucPaymentCollection1.cmbcollector.Enabled = false;
                }
               // ucpc1.LoadForms(Helper.UserId);
            }
           
        }

        private bool SaveData()
        {
            try
            {
                var uc = ucPaymentCollection1;

                uc.txtCashTicketQuantity.Validating -= new CancelEventHandler(uc.txtCashTicketQuantity_Validating);

                uc.txtpayee.Validating -= new CancelEventHandler(uc.txtpayee_Validating);

                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                uc.txtCashTicketQuantity.Validating += new CancelEventHandler(uc.txtCashTicketQuantity_Validating);

                var pcModel = new PaymentCollectionModel()
                {
                    CollectingOfficerId = Convert.ToInt32(uc.cmbcollector.SelectedValue),
                    FundId = Convert.ToInt32(uc.cmbfund.SelectedValue),
                    AccountableFormId = Convert.ToInt32(uc.cmbforms.SelectedValue),
                    GeneralLedgerAccountId = uc.generalLedgerId,
                    Quantity = 1,
                    Payee = uc.txtpayee.Text.Trim(),
                    ReceiptNo = uc.txtreceipt.Text.Trim(),
                    PaymentDate = Convert.ToDateTime(uc.dtdate.Text.Trim()),
                    Amount = Convert.ToDecimal(uc.txtamount.Value),
                    CreatedBy = uc.userid,
                };

                var paymentCollectionRepo = Factory.PaymentCollectionRepository();

                bool receiptExist = paymentCollectionRepo.ReceiptExist(uc.txtreceipt.Text.Trim(), Convert.ToInt32(uc.cmbforms.SelectedValue));

                if (receiptExist)
                {
                    Helper.MessageBoxSuccess("Receipt already exists!");
                    uc.txtreceipt.Focus();
                    return false;
                }
                else if(uc.txtamount.Value <= 0)
                {
                    Helper.MessageBoxSuccess("Please enter amount.");
                    uc.txtamount.Focus();
                    return false;
                }
                else
                {
                    bool insertSuccess = paymentCollectionRepo.Insert(pcModel);

                    if (insertSuccess)
                    {
                        var receiptsIssuedRepo = Factory.ReceiptsIssuedRepository();
                        var dtReceiptIssued = receiptsIssuedRepo.GetRecords(uc.cmbcollector.SelectedValue.ToString(), uc.cmbforms.SelectedValue.ToString());
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
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxWarning(ex.Message);
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var uc = ucPaymentCollection1;

            if (!uc.isCashTicket)
                SaveCashTickets();
            else
                SaveReceipts();

        }

        private void SaveCashTickets()
        {
            try
            {

                var uc = ucPaymentCollection1;

                uc.txtpayee.Validating -= new CancelEventHandler(uc.txtpayee_Validating);

                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return;
                }


                var paymentCollectionModel = new PaymentCollectionModel()
                {
                    CollectingOfficerId = Convert.ToInt32(uc.cmbcollector.SelectedValue),
                    FundId = Convert.ToInt32(uc.cmbfund.SelectedValue),
                    AccountableFormId = Convert.ToInt32(uc.cmbforms.SelectedValue),
                    GeneralLedgerAccountId = uc.generalLedgerId,
                    Quantity = Convert.ToInt32(uc.txtCashTicketQuantity.Value),
                    PaymentDate = Convert.ToDateTime(uc.dtCashTicketDateOfCollection.Text.Trim()),
                    Amount = Convert.ToDecimal(uc.txtCashTicketsAmount.Text),
                    CreatedBy = uc.userid,
                };


                var paymentCollectionRepo = Factory.PaymentCollectionRepository();

                bool insertSuccess = paymentCollectionRepo.Insert(paymentCollectionModel);

                if (insertSuccess)
                {
                    Helper.MessageBoxSuccess("Payment Collection has been saved.");
                    _frmPaymentCollection.LoadRecords();
                    ucPaymentCollection1.ResetForm();
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
                ucPaymentCollection1.ResetForm();
            }
        }

      
    }
}
