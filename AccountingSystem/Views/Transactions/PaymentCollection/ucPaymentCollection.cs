using ACC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.PaymentCollection
{
    public partial class ucPaymentCollection : UserControl
    {
        internal int paymentCollectionId;
        internal int accountableFormId;
        internal int fundId;
        internal int generalLedgerId;
        internal int userId;
        internal int serialNumberFrom;
        internal int serialNumberTo;
        internal int serialNumber;

        internal bool isCashTicket;
        internal int cashTicketFaceValue;
        internal decimal accountableFormFaceValue;
        internal bool isSave;

        public ucPaymentCollection()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[9];
            errorArray[0] = epCollectingOfficer.GetError(cmbCollector);
            errorArray[1] = epFund.GetError(cmbFund);
            errorArray[2] = epAccountableForm.GetError(cmbAccountableForms);
            errorArray[3] = epAbstractOfGeneralCollection.GetError(cmbAccount);
            errorArray[4] = epPayee.GetError(txtPayee);
            errorArray[5] = epSerialNo.GetError(txtReceiptNumber);
            errorArray[6] = epCashTicketQuantity.GetError(txtCashTicketQuantity);
            errorArray[7] = epCashTicketAmount.GetError(txtCashTicketsAmount);
            errorArray[8] = epORAmount.GetError(txtAmount);

            IError _errors = AccFactory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            fundId = 0;
            accountableFormId = 0;
            txtReceiptNumber.Clear();
            txtPayee.Clear();
            dtDateOfCollection.Value = DateTime.Now;
            txtAmount.Value = Convert.ToDecimal("0.00");
            serialNumberFrom = 0;
            serialNumberTo = 0;
            serialNumber = 0;

            isCashTicket = false;
            cashTicketFaceValue = 0;
            accountableFormFaceValue = 0.0m;
            isSave = false;
        }

        private void ucPaymentCollection_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadFunds();
                LoadAccounts();

                LoadCollectors();
                LoadCollectorsAccountableForms();
                //GetAccountableFormSerialNumberRange();
                //GetAccountableFormFaceValue();
                SwitchFields();

                SelectCurrentLoggedInCollector();


            }
        }

        internal void LoadCollectorsAccountableForms()
        {
            try
            {
                var collectorsId = Convert.ToInt32(cmbCollector.SelectedValue);
                var receiptIssuedRepo = AccFactory.ReceiptsIssuedRepository();
                var dtAccountableForms = receiptIssuedRepo.GetCollectorsAccountbleForms(collectorsId);

                cmbAccountableForms.DataSource = dtAccountableForms;
                cmbAccountableForms.ValueMember = "accountable_form_id";
                cmbAccountableForms.DisplayMember = $"accountable_forms";
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadAccountableForms()
        {
            var accountableFormsDt = AccFactory.AccountableFormsRepository().GetRecords();
            HelperLoadRecords.AccountableFormsCombobox(cmbAccountableForms, accountableFormsDt);
        }

        internal void LoadFunds()
        {
            var fundDt = AccFactory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(fundDt, cmbFund, "fund_name", "id");
        }

        internal void LoadCollectors()
        {
            try
            {
                DataTable dtCollector;
                var collectingOfficerRepository = AccFactory.CollectingOfficerRepository();
                var collectingOfficerHasJORepo = AccFactory.CollectingOfficerHasJobOrdersRepository();

                if (cbJOCollector.Checked)
                    dtCollector = collectingOfficerHasJORepo.GetRecords();
                else
                    dtCollector = collectingOfficerRepository.GetRecords();


                HelperLoadRecords.CollectingOfficerComboBox(dtCollector, cmbCollector, "fullname", "id");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void SetSelectedValue(int Id, string table)
        {
            if (!string.IsNullOrEmpty(table) || Id > 0)
            {
                if (table.Equals("ledger"))
                {
                    var ledgerRepository = AccFactory.GeneralLedgerAccountsRepository();
                    var ledgerData = ledgerRepository.GetRecordByID(Id);
                    generalLedgerId = Id;
                    cmbAccount.Text = String.Format("{0} - {1}", ledgerData["ledger_code"], ledgerData["ledger_name"]);
                }
            }
        }

        internal void SelectCurrentLoggedInCollector()
        {
            var usersRepo = AccFactory.UsersRepository();

            if (usersRepo.LinkedCollector(Helper.UserId))
            {
                cbJOCollector.Enabled = false;
                cmbCollector.Enabled = false;
                cmbCollector.SelectedValue = AccFactory.CollectingOfficerRepository().GetRecordByUserID(Helper.UserId)["id"];
                return;
            }
            else if (usersRepo.LinkedJobOrder(Helper.UserId))
            {
                cbJOCollector.Checked = true;
                cbJOCollector.Enabled = false;
                cmbCollector.Enabled = false;
                cmbCollector.SelectedValue = AccFactory.JobOrderRepository().GetRecordByUserID(Helper.UserId)["id"];
            }
        }

        internal bool IsReceiptNumberBetweenFromAndTo(int receiptNumber)
        {
            //return (receiptNumber >= serialNumberFrom) && (receiptNumber <= serialNumberTo);
            return false; //temporary
        }

        internal void GetAccountableFormSerialNumberRange()
        {   
            var collectingOfficerId = Convert.ToInt32(cmbCollector.SelectedValue);
            var accountableFormId = Convert.ToInt32(cmbAccountableForms.SelectedValue);

            var dtReceiptIssued = AccFactory.ReceiptsIssuedRepository().GetIssuedReceiptToCollector(collectingOfficerId, accountableFormId);
            if (dtReceiptIssued.Rows.Count != 0)
            {
                serialNumberFrom = Convert.ToInt32(dtReceiptIssued.Rows[0]["receipt_issued_from"]);
                serialNumberTo = Convert.ToInt32(dtReceiptIssued.Rows[0]["receipt_issued_to"]);
            }
        }


        #region Validations
        private void cmbcollector_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epCollectingOfficer, cmbCollector, "Collecting Officer.");
        }

        private void cmbcollector_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epCollectingOfficer, cmbCollector);
        }


        private void cmbfund_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epFund, cmbFund, "Funds.");
        }

        private void cmbfund_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epFund, cmbFund);
        }

        private void cmbAccountableForms_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epAccountableForm, cmbAccountableForms, "Accountable Forms!");
        }

        private void cmbAccountableForms_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAccountableForm, cmbAccountableForms);
        }

        private void cmbAccount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epAbstractOfGeneralCollection, cmbAccount, "Abstract of General Collection.");
        }

        private void cmbAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAbstractOfGeneralCollection, cmbAccount);
        }

        #endregion

        #region ORValidation
        private void dtDateOfCollection_Validation(object sender, CancelEventArgs e)
        {
            DateTime todaysDate = DateTime.Now;
            DateTime dateOfCollection = dtDateOfCollection.Value;
            e.Cancel = Helper.ShowErrorDateTimePickerRange(epORDateOfCollection, todaysDate, dateOfCollection, dtDateOfCollection, "Date of Collection");
        }

        private void dtDateOfCollection_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorDateTimePickerRange(epORDateOfCollection, dtDateOfCollection);
        }

        internal void txtreceipt_Validating(object sender, CancelEventArgs e)
        {
            if (Helper.ShowErrorTextBoxEmpty(epSerialNo, txtReceiptNumber, "Receipt No."))
            {
                e.Cancel = true;
                return;
            }

            var receiptNumber = Convert.ToInt32(txtReceiptNumber.Text.Trim());

            if (ReceiptNumberHasCollection())
            {
                epSerialNo.SetError(txtReceiptNumber, "Receipt number already recorded.");
                e.Cancel = true;
                return;
            }

            //if (IsReceiptNumberBetweenFromAndTo(receiptNumber) == false || receiptNumber <= 0)
            //{
            //    epSerialNo.SetError(txtReceiptNumber, "Invalid Receipt number.");
            //    e.Cancel = true;
            //    return;
            //}
        }

        private bool ReceiptNumberHasCollection()
        {
            try
            {
                string receiptNumber = txtReceiptNumber.Text.Trim();
                int accountableFormId = Convert.ToInt32(cmbAccountableForms.SelectedValue);
                var paymentCollectionId = this.paymentCollectionId;

                var paymentCollectionRepo = AccFactory.PaymentCollectionRepository();


                bool isReceiptRecorded;

                if (isSave)
                    isReceiptRecorded = paymentCollectionRepo.ReceiptExist(receiptNumber, accountableFormId);
                else
                    isReceiptRecorded = paymentCollectionRepo.ReceiptExist(paymentCollectionId, receiptNumber, accountableFormId);

                return isReceiptRecorded;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txtreceipt_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epSerialNo, txtReceiptNumber);
        }

        internal void txtpayee_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epPayee, txtPayee, "Payee.");
        }

        private void txtpayee_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epPayee, txtPayee);
        }

        internal void txtAmount_Validating(object sender, CancelEventArgs e)
        {
            if (!Helper.ShowErrorNumericUpDownEmpty(epORAmount, txtAmount, "Amount"))
            {
                e.Cancel = Helper.ShowErrorNumericUpDownZero(epORAmount, txtAmount, "Amount");
            }
        }

        private void txtAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epORAmount, txtAmount);
        }


        #endregion

        #region CashTicketValidation

        private void dtCashTicketDateOfCollection_Validating(object sender, CancelEventArgs e)
        {
            DateTime todaysDate = DateTime.Now;
            DateTime dateOfCollection = dtCashTicketDateOfCollection.Value;
            e.Cancel = Helper.ShowErrorDateTimePickerRange(epCashTicketDateOfCollection, todaysDate, dateOfCollection, dtCashTicketDateOfCollection, "Date of Collection");
        }

        private void dtCashTicketDateOfCollection_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorDateTimePickerRange(epCashTicketDateOfCollection, dtCashTicketDateOfCollection);
        }

        internal void txtCashTicketQuantity_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownZero(epCashTicketQuantity, txtCashTicketQuantity, "Cash Ticket Quantity.");
        }

        private void txtCashTicketQuantity_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epCashTicketQuantity, txtCashTicketQuantity);
        }


        internal void txtCashTicketsAmount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownZero(epCashTicketAmount, txtCashTicketsAmount, "Amount");
        }

        private void txtCashTicketsAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epCashTicketAmount, txtCashTicketsAmount);
        }

        #endregion
        

        private void CreatePaymentCollection()
        {
            DataRowView accountableFormDRV = cmbAccountableForms.SelectedItem as DataRowView;
            DataRowView collectingOfficerDRV = cmbCollector.SelectedItem as DataRowView;

            if (accountableFormDRV == null || collectingOfficerDRV == null)
                return;

            if (paymentCollectionId == 0)    //accountableForm
                InsertPaymentCollectionTransaction(accountableFormDRV, collectingOfficerDRV);
            else
                EditPaymentCollectionTransaction(accountableFormDRV, collectingOfficerDRV);
        }

        private void EnableDisableNonCashTicketsFields(bool enable)
        {
            if (!enable)
            {
                dtDateOfCollection.Value = DateTime.Now;
                txtReceiptNumber.Clear();
                txtPayee.Clear();
                txtAmount.Value = Convert.ToDecimal("0.00");
            }

            dtDateOfCollection.Enabled = enable;
            txtReceiptNumber.Enabled = enable;
            txtPayee.Enabled = enable;
            txtAmount.Enabled = enable;
        }

        private void InsertPaymentCollectionTransaction(DataRowView accountableFormDRV, DataRowView collectingOfficerDRV)
        {
            var collectorId = Convert.ToInt32(collectingOfficerDRV[0].ToString());
            var accountableFormId = Convert.ToInt32(accountableFormDRV[0].ToString());

            var receiptIssuedRepo = AccFactory.ReceiptsIssuedRepository();
            var dtReceiptIssued = receiptIssuedRepo.GetIssuedReceiptToCollector(collectorId, accountableFormId);
            var dtReceiptIssuedRowCount = dtReceiptIssued.Rows.Count;

            if (dtReceiptIssuedRowCount == 0)   //if all receipt has been used.
            {
                Helper.MessageBoxSuccess("All Receipts has been recorded");
                EnableDisableNonCashTicketsFields(false);
                return;
            }

            EnableDisableNonCashTicketsFields(true);
            SetNextReceiptNumber();
        }

        private void SetNextReceiptNumber()
        {
            var collectingOfficerID = Convert.ToInt32(cmbCollector.SelectedValue);
            var accountableFormID = Convert.ToInt32(cmbAccountableForms.SelectedValue);

            var lastUsedReceipt = AccFactory.PaymentCollectionRepository().GetPreviouslyUsedReceiptNumber(collectingOfficerID, accountableFormID);
            if (lastUsedReceipt != 0)
            {
                txtReceiptNumber.Text = (lastUsedReceipt + 1).ToString("D7");
            }
            else
            {
                var dtReceiptsOfCollector = AccFactory.ReceiptsIssuedRepository().GetIssuedReceiptToCollector(collectingOfficerID, accountableFormID);

                serialNumberFrom = Convert.ToInt32(dtReceiptsOfCollector.Rows[0]["receipt_issued_from"]);
                txtReceiptNumber.Text = serialNumberFrom.ToString("D7");
            }
        }

        private DataTable DatatableAccounts()
        {
            DataTable dtAccounts;

            string searchText = cmbAccount.Text;

            if (string.IsNullOrEmpty(searchText))
            {
                dtAccounts = AccFactory.GeneralLedgerAccountsRepository().GetGeneralLedgerAccountsIncomeRecords();
            }
            else
            {
                dtAccounts = AccFactory.GeneralLedgerAccountsRepository().GetGeneralLedgerAccountsIncomeRecords(searchText);
            }

            return dtAccounts;
        }

        private void LoadAccounts()
        {
            try
            {
                if (DatatableAccounts().Rows.Count == 0) return;

                var accountDict = new Dictionary<ushort, string>();
                foreach (DataRow item in DatatableAccounts().Rows)
                {
                    ushort accountId = Convert.ToUInt16(item["general_ledger_accounts_id"]);
                    string accountName = $"{item["account_code"]} - {item["ledger_name"]}";
                    accountDict.Add(accountId, accountName);
                }

                cmbAccount.DataSource = new BindingSource(accountDict, null);
                cmbAccount.DisplayMember = "value";
                cmbAccount.ValueMember = "key";
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }


        #region Local Methods

        private void EditPaymentCollectionTransaction(DataRowView accountableFormDRV, DataRowView collectingOfficerDRV)
        {

        }

        private void GetAccountableFormFaceValue()
        {
            int accountableFormId = Convert.ToInt32(cmbAccountableForms.SelectedValue);
            accountableFormFaceValue = AccFactory.FaceValueRepository().GetFaceValueByAccountableFormId(accountableFormId);
        }

        internal void CancelNonCashTicketFieldValidations(bool cancelEvent)
        {
            if (cancelEvent)
            {
                txtAmount.Validating -= new CancelEventHandler(txtAmount_Validating);
                txtReceiptNumber.Validating -= new CancelEventHandler(txtreceipt_Validating);
                txtPayee.Validating -= new CancelEventHandler(txtpayee_Validating);
            }
            else
            {
                txtReceiptNumber.Validating += new CancelEventHandler(txtreceipt_Validating);
                txtPayee.Validating += new CancelEventHandler(txtpayee_Validating);
            }
        }

        internal void CancelCashTicketFieldValidations(bool cancelEvent)
        {
            if (cancelEvent)
            {
                txtCashTicketsAmount.Validating -= new CancelEventHandler(txtCashTicketsAmount_Validating);
                txtCashTicketQuantity.Validating -= new CancelEventHandler(txtCashTicketQuantity_Validating);
            }
            else
            {
                txtCashTicketQuantity.Validating += new CancelEventHandler(txtCashTicketQuantity_Validating);
                txtPayee.Validating += new CancelEventHandler(txtpayee_Validating);
            }
        }

        internal void SwitchFields()
        {
            isCashTicket = cmbAccountableForms.Text.Contains("Tickets");

            if (isCashTicket)
            {
                tabPaymentType.SelectedTab = tabCashTickets;
                isCashTicket = true;
                txtCashTicketsAmount.Value = accountableFormFaceValue;
            }
            else
            {
                tabPaymentType.SelectedTab = tabNonCashTickets;
                isCashTicket = false;
                txtAmount.Value = accountableFormFaceValue;
            }
        }

        #endregion

        #region Form Events

        private void txtreceipt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void cmbAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(cmbAccount.Text) && cmbAccount.Focused)
            {
                LoadAccounts();
                cmbAccount.DroppedDown = true;
            }
        }
        private void cmbAccount_SelectionChangeCommitted(object sender, EventArgs e)
        {
            generalLedgerId = Convert.ToInt32(cmbAccount.SelectedValue);
        }

        private void txtCashTicketQuantity_ValueChanged(object sender, EventArgs e)
        {
            var cashTicketAmount = accountableFormFaceValue;
            var cashTicketQuantity = Convert.ToInt32(txtCashTicketQuantity.Value);
            var amount = (cashTicketAmount) * (cashTicketQuantity);

            txtCashTicketsAmount.Text = amount.ToString("N2");
        }

        private void cmbCollector_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //DataRowView collector = cmbCollector.SelectedItem as DataRowView;
            //var collectorId = int.Parse(collector[0].ToString());

            LoadCollectorsAccountableForms();
            SwitchFields();
            //CreatePaymentCollection();
        }

        internal void cmbforms_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //GetAccountableFormFaceValue();
            SwitchFields();
            CreatePaymentCollection();
        }

        private void cbCollector_CheckedChanged(object sender, EventArgs e)
        {
            LoadCollectors();
        }

        #endregion


    }
}
