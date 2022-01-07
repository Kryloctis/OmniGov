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
    public partial class frmPaymentCollectionEdit : Form
    {
        private readonly frmPaymentCollection _frmPaymentCollection;
        private string receipt = string.Empty;

        public frmPaymentCollectionEdit(frmPaymentCollection frmPaymentCollection, int Id)
        {
            InitializeComponent();
            _frmPaymentCollection = frmPaymentCollection;
            
            ucPaymentCollection1.Id = Id;
            ucPaymentCollection1.userid = Helper.UserId;
        }

        private void frmPaymentCollectionEdit_Load(object sender, EventArgs e)
        {
            ucPaymentCollection1.LoadForms();
            ucPaymentCollection1.LoadCollectors();
            ucPaymentCollection1.LoadFunds();

            LoadSelectedValue();
        }

        private void LoadSelectedValue()
        {
            try
            {
                var uc = ucPaymentCollection1;
                var paymentCollectionRepository = Factory.PaymentCollectionRepository();
                var paymentCollectionDict = paymentCollectionRepository.GetRecordByID(uc.Id);



                uc.cmdCollector.SelectedValue = paymentCollectionDict["collecting_officers_id"];
                uc.cmbFund.SelectedValue = paymentCollectionDict["funds_id"];
                uc.cmbAccountableForms.SelectedValue = paymentCollectionDict["accountable_forms_id"];
                uc.SetSelectedValue(Convert.ToInt32(paymentCollectionDict["general_ledger_accounts_id"]), "ledger");
                uc.accId = Convert.ToInt32(paymentCollectionDict["accountable_forms_id"]);

                bool isCashTickets = String.IsNullOrEmpty(paymentCollectionDict["receipt_no"]);


                if (!isCashTickets)
                {
                    uc.SwitchFields(); 
                    uc.txtpayee.Text = paymentCollectionDict["payee"];
                    uc.txtreceipt.Text = paymentCollectionDict["receipt_no"];
                    uc.dtdate.Value = Convert.ToDateTime(paymentCollectionDict["payment_date"]);
                    uc.txtAmount.Value = Convert.ToDecimal(paymentCollectionDict["amount"]);
                    receipt = paymentCollectionDict["receipt_no"];
                    uc.receipt = Convert.ToInt32(paymentCollectionDict["receipt_no"]);
                    uc.cmdCollector.Enabled = false;
                }
                else
                {
                    uc.SwitchFields(); 
                    uc.dtCashTicketDateOfCollection.Value = Convert.ToDateTime(paymentCollectionDict["payment_date"]);
                    uc.txtCashTicketQuantity.Text = paymentCollectionDict["quantity"];
                    uc.txtCashTicketsAmount.Text = Convert.ToDecimal(paymentCollectionDict["amount"]).ToString("N2");
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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

                uc.txtpayee.Validating += new CancelEventHandler(uc.txtpayee_Validating);

                var pcModel = new PaymentCollectionModel()
                {
                    Id = uc.Id,
                    CollectingOfficerId = Convert.ToInt32(uc.cmdCollector.SelectedValue),
                    FundId = Convert.ToInt32(uc.cmbFund.SelectedValue),
                    AccountableFormId = Convert.ToInt32(uc.cmbAccountableForms.SelectedValue),
                    GeneralLedgerAccountId = uc.generalLedgerId,
                    Payee = uc.txtpayee.Text.Trim(),
                    ReceiptNo = uc.txtreceipt.Text.Trim(),
                    PaymentDate = Convert.ToDateTime(uc.dtdate.Text.Trim()),
                    Amount = Convert.ToDecimal(uc.txtAmount.Value),
                    UpdatedBy =uc.userid,
                };

                var pcrepository = Factory.PaymentCollectionRepository();
                if (!receipt.Equals(uc.txtreceipt.Text.Trim()))
                {
                    if (pcrepository.Update(pcModel))
                    {
                        var riRepository = Factory.ReceiptsIssuedRepository();
                        var dtri = riRepository.GetRecords(uc.cmdCollector.SelectedValue.ToString(), uc.cmbAccountableForms.SelectedValue.ToString());
                        if (dtri.Rows.Count > 0)
                        {
                            int rid = 0;
                            for (int i = 0; i < dtri.Rows.Count; i++)
                            {
                                rid = Convert.ToInt32(dtri.Rows[i]["id"]);
                            }
                            var rcModel = new ReceiptsIssuedModel()
                            {
                                Id = rid,
                                Last_issued = Convert.ToInt32(uc.txtreceipt.Text.Trim())
                            };
                            return riRepository.UpdateCurrentIssued(rcModel);
                        }
                    }                       
                    else return false;
                }
                else if (uc.txtAmount.Value <= 0)
                {
                    Helper.MessageBoxSuccess("Empty Amount!");
                    uc.txtAmount.Focus();
                    return false;
                }
                else
                {
                    return pcrepository.Update(pcModel);
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var uc = ucPaymentCollection1;

            if (uc.isCashTicket)
                UpdateCashTickets();
            else
                UpdateReceipts();
        }

        private void UpdateCashTickets()
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
                    CollectingOfficerId = Convert.ToInt32(uc.cmdCollector.SelectedValue),
                    FundId = Convert.ToInt32(uc.cmbFund.SelectedValue),
                    AccountableFormId = Convert.ToInt32(uc.cmbAccountableForms.SelectedValue),
                    GeneralLedgerAccountId = uc.generalLedgerId,
                    Quantity = Convert.ToInt32(uc.txtCashTicketQuantity.Value),
                    PaymentDate = Convert.ToDateTime(uc.dtCashTicketDateOfCollection.Text.Trim()),
                    Amount = Convert.ToDecimal(uc.txtCashTicketsAmount.Text),
                    CreatedBy = uc.userid,
                };


                var paymentCollectionRepo = Factory.PaymentCollectionRepository();

                bool insertSuccess = paymentCollectionRepo.Update(paymentCollectionModel);

                if (insertSuccess)
                {
                    Helper.MessageBoxSuccess("Payment Collection has been updated.");
                    _frmPaymentCollection.LoadRecords();
                    ucPaymentCollection1.ResetForm();
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                Helper.MessageBoxWarning(ex.Message);
            }
        }


        private void UpdateReceipts()
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Payment Collection has been updated.");
                _frmPaymentCollection.LoadRecords();
                ucPaymentCollection1.ResetForm();
            }
        }
    }
}
