using ACC.Domain.Models;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.PaymentCollection
{
    public partial class frmPaymentCollectionEdit : Form
    {
        private readonly frmPaymentCollection _frmPaymentCollection;
        private readonly ucPaymentCollection _uc; 
        internal string receiptSerialNumber;

        public frmPaymentCollectionEdit(frmPaymentCollection frmPaymentCollection, int paymentCollectionId)
        {
            InitializeComponent();
            _frmPaymentCollection = frmPaymentCollection;
            _uc = ucPaymentCollection1;
            _uc.paymentCollectionId = paymentCollectionId;
            _uc.userId = Helper.UserId;
        }

        private void frmPaymentCollectionEdit_Load(object sender, EventArgs e)
        {
            _uc.LoadAccountableForms();
            _uc.LoadCollectors();
            _uc.LoadFunds();
            _uc.SelectCurrentLoggedInCollector();
            LoadSelectedValue();
            _uc.GetAccountableFormSerialNumberRange();
            DisableUnEditableFields();
        }


        private void DisableUnEditableFields()
        {
            _uc.cmbCollector.Enabled = false;
            _uc.cmbAccountableForms.Enabled = false;
        }

        private void LoadSelectedValue()
        {
            try
            {
                var paymentCollectionRepository = AccFactory.PaymentCollectionRepository();
                var paymentCollectionDict = paymentCollectionRepository.GetRecordByID(_uc.paymentCollectionId);

                var regularCollectingOfficerId = paymentCollectionDict["collecting_officers_id"];
                var jobOrderCollectingOfficerId = paymentCollectionDict["job_orders_id"];
                _uc.cmbCollector.SelectedValue = string.IsNullOrEmpty(paymentCollectionDict["job_orders_id"]) ? regularCollectingOfficerId : jobOrderCollectingOfficerId; 
                _uc.cmbFund.SelectedValue = paymentCollectionDict["funds_id"];
                _uc.cmbAccountableForms.SelectedValue = paymentCollectionDict["accountable_forms_id"];
                _uc.SetSelectedValue(Convert.ToInt32(paymentCollectionDict["general_ledger_accounts_id"]), "ledger");
                _uc.accountableFormId = Convert.ToInt32(paymentCollectionDict["accountable_forms_id"]);
                bool isCashTickets = string.IsNullOrEmpty(paymentCollectionDict["receipt_no"]);


                if (!isCashTickets)
                {
                    _uc.SwitchFields(); 
                    _uc.txtPayee.Text = paymentCollectionDict["payee"];
                    _uc.txtReceiptNumber.Text = Convert.ToInt32(paymentCollectionDict["receipt_no"]).ToString("D7");
                    _uc.dtDateOfCollection.Value = Convert.ToDateTime(paymentCollectionDict["payment_date"]);
                    _uc.txtAmount.Value = Convert.ToDecimal(paymentCollectionDict["amount"]);
                    receiptSerialNumber = paymentCollectionDict["receipt_no"];
                    _uc.serialNumber = Convert.ToInt32(paymentCollectionDict["receipt_no"]);
                    _uc.cmbCollector.Enabled = false;
                }
                else
                {
                    _uc.SwitchFields(); 
                    _uc.dtCashTicketDateOfCollection.Value = Convert.ToDateTime(paymentCollectionDict["payment_date"]);
                    _uc.txtCashTicketQuantity.Text = paymentCollectionDict["quantity"];
                    _uc.txtCashTicketsAmount.Text = Convert.ToDecimal(paymentCollectionDict["amount"]).ToString("N2");
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
        private bool UpdateData()
        {
            try
            {
                if (!_uc.ValidateChildren())
                {
                    Helper.MessageBoxError(_uc.GetFormErrors());
                    return false;
                }

                var paymentCollectionModel = new PaymentCollectionModel()
                {
                    Id = _uc.paymentCollectionId,
                    FundId = Convert.ToInt32(_uc.cmbFund.SelectedValue),
                    GeneralLedgerAccountId = _uc.generalLedgerId,
                    Payee = _uc.txtPayee.Text.Trim(),
                    ReceiptNo = _uc.txtReceiptNumber.Text.Trim(),
                    PaymentDate = Convert.ToDateTime(_uc.dtDateOfCollection.Text.Trim()),
                    Amount = Convert.ToDecimal(_uc.txtAmount.Value),
                    UpdatedBy =_uc.userId,
                };

                var paymentcollectionRepo = AccFactory.PaymentCollectionRepository();

                if (paymentcollectionRepo.Update(paymentCollectionModel))
                    return true;            
            
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
            {
                uc.CancelNonCashTicketFieldValidations(true);
                UpdateCashTickets();
            }

            else
            {
                uc.CancelCashTicketFieldValidations(true);
                UpdateReceipts();
            }

        }

        private void UpdateCashTickets()
        {
            try
            {
                _uc.txtPayee.Validating -= new CancelEventHandler(_uc.txtpayee_Validating);

                if (!_uc.ValidateChildren())
                {
                    Helper.MessageBoxError(_uc.GetFormErrors());
                    return;
                }


                var paymentCollectionModel = new PaymentCollectionModel()
                {
                    CollectingOfficerId = Convert.ToInt32(_uc.cmbCollector.SelectedValue),
                    FundId = Convert.ToInt32(_uc.cmbFund.SelectedValue),
                    AccountableFormId = Convert.ToInt32(_uc.cmbAccountableForms.SelectedValue),
                    GeneralLedgerAccountId = _uc.generalLedgerId,
                    Quantity = Convert.ToInt32(_uc.txtCashTicketQuantity.Value),
                    PaymentDate = Convert.ToDateTime(_uc.dtCashTicketDateOfCollection.Text.Trim()),
                    Amount = Convert.ToDecimal(_uc.txtCashTicketsAmount.Text),
                    CreatedBy = _uc.userId,
                };


                var paymentCollectionRepo = AccFactory.PaymentCollectionRepository();

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
            if (UpdateData())
            {
                Helper.MessageBoxSuccess("Payment Collection has been updated.");
                _frmPaymentCollection.LoadRecords();
                Close();
            }
        }
    }
}
