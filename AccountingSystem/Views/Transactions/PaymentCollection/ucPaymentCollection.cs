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
        internal int receiptNumberFrom;
        internal int receiptNumberTo;
        internal int receiptNumber;

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
            errorArray[0] = epCollectingOfficer.GetError(cmdCollector);
            errorArray[1] = epFund.GetError(cmbFund);
            errorArray[2] = epAccountableForm.GetError(cmbAccountableForms);
            errorArray[3] = epAbstractOfGeneralCollection.GetError(cmbAccount);
            errorArray[4] = epPayee.GetError(txtPayee);
            errorArray[5] = epSerialNo.GetError(txtReceiptNumber);
            errorArray[6] = epCashTicketQuantity.GetError(txtCashTicketQuantity);
            errorArray[7] = epCashTicketAmount.GetError(txtCashTicketsAmount);
            errorArray[8] = epORAmount.GetError(txtAmount);

            IError _errors = Factory.CreateErrors(errorArray);
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
            receiptNumberFrom = 0;
            receiptNumberTo = 0;
            receiptNumber = 0;

            isCashTicket = false;
            cashTicketFaceValue = 0;
            accountableFormFaceValue = 0.0m;
            isSave = false;
        }

        internal void LoadForms(int collectorsId)
        {
            try
            {
                var accountableFormRepo = Factory.ReceiptsIssuedRepository();
                var dtforms = accountableFormRepo.GetIssuedReceiptByCollectorId(collectorsId.ToString());

                dtforms.Columns.Add("formdisplay", typeof(string), "acc_form_no + ' - ' + acc_form_desc + ' - ' + (quantity)");
                cmbAccountableForms.DataSource = dtforms;
                cmbAccountableForms.ValueMember = "id";
                cmbAccountableForms.DisplayMember = "formdisplay";
            } 
            catch (Exception ex) 
            { 
                Helper.MessageBoxError(ex.Message); 
            }
        }

        internal void LoadForms()
        {
            try
            {
                cmbAccountableForms.SelectedValueChanged -= cmbforms_SelectedValueChanged;
                var formRepository = Factory.AccountableFormsRepository();
                var dtforms = formRepository.GetRecords();
                dtforms.Columns.Add("formdisplay", typeof(string), "acc_form_no + ' - ' + acc_form_desc");
                cmbAccountableForms.DataSource = dtforms;
                cmbAccountableForms.ValueMember = "id";
                cmbAccountableForms.DisplayMember = "formdisplay";
                cmbAccountableForms.SelectedValueChanged += cmbforms_SelectedValueChanged;
            }
            catch (Exception ex) 
            { 
                Helper.MessageBoxError(ex.Message); 
            }
        }

        internal void LoadFunds()
        {
            try
            {
                var fundRepository = Factory.FundsRepository();
                var dtFund = fundRepository.GetRecords();
                dtFund.Columns.Add("funddisplay", typeof(string), "fund_code + ' - ' + fund_name");
                cmbFund.DataSource = dtFund;
                cmbFund.ValueMember = "id";
                cmbFund.DisplayMember = "funddisplay";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void SetSelectedValue(int Id, string table)
        {
           
            try
            {
                if (!string.IsNullOrEmpty(table) || Id > 0)
                {
                    if (table.Equals("ledger"))
                    {
                        var ledgerRepository = Factory.GeneralLedgerAccountsRepository();
                        var ledgerData = ledgerRepository.GetRecordByID(Id);
                        generalLedgerId = Id;
                        cmbAccount.Text = String.Format("{0} - {1}", ledgerData["ledger_code"], ledgerData["ledger_name"]);
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadCollectors()
        {
            try
            {
                var collectingOfficerRepository = Factory.CollectingOfficerRepository();
                var collectingOfficerHasJORepo = Factory.CollectingOfficerHasJobOrdersRepository();

                DataTable dtCollectors = new();
                var dtJOCollectors = collectingOfficerHasJORepo.GetRecords();
                var dtRegularCollectors = collectingOfficerRepository.GetRecords();

                dtRegularCollectors.Merge(dtJOCollectors);
                dtCollectors = dtRegularCollectors;

                cmdCollector.DataSource = dtCollectors;
                cmdCollector.ValueMember = "id";
                cmdCollector.DisplayMember = "fullname";
            }
            catch (Exception ex) 
            { 
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadCurrentCollector()
        {
            try
            {
                if (cmdCollector.Items.Count > 0)
                {
                    var uRepository = Factory.UsersRepository();
                    if (uRepository.LinkedCollector(Helper.UserId) || uRepository.LinkedJobOrder(Helper.UserId))
                    {

                        Dictionary<string, string> collectorDict = new();

                        if (Helper.IsJobOrder(Helper.UserId))
                        {
                            var jobOrderRepo = Factory.JobOrderRepository();
                            collectorDict = jobOrderRepo.GetRecordByUserID(Helper.UserId);
                            cmdCollector.SelectedValue = collectorDict["id"];
                        }
                        else
                        {
                            var colRepository = Factory.CollectingOfficerRepository();
                            collectorDict = colRepository.GetRecordByUserID(Helper.UserId);
                            cmdCollector.SelectedValue = collectorDict["id"];
                        }

                        cmdCollector.Enabled = false;
                    }

                    else
                    {
                        cmdCollector.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal bool IsReceiptNumberBetweenFromAndTo(int receiptNumber)
        {
            return (receiptNumber >= receiptNumberFrom) && (receiptNumber <= receiptNumberTo);
        }

        private void ucPaymentCollection_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadForms(Convert.ToInt32(cmdCollector.SelectedValue));
                LoadCollectors();
                LoadFunds();

                cmbAccount.SelectedValueChanged -= cmbAccount_SelectedValueChanged;
                LoadAccounts();
                cmbAccount.SelectedValueChanged += cmbAccount_SelectedValueChanged;
                cmbAccount.SelectedIndex = -1;

                LoadCurrentCollector();
            }
        }


        #region Validations
        private void cmbcollector_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epCollectingOfficer, cmdCollector, "Collecting Officer.");
        }

        private void cmbcollector_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epCollectingOfficer, cmdCollector);
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

            if (IsReceiptNumberBetweenFromAndTo(receiptNumber) == false || receiptNumber <= 0)
            {
                epSerialNo.SetError(txtReceiptNumber, "Invalid Receipt number.");
                e.Cancel = true;
                return;
            }
        }

        private bool ReceiptNumberHasCollection()
        {
            try
            {
                string receiptNumber = txtReceiptNumber.Text.Trim();
                int accountableFormId = Convert.ToInt32(cmbAccountableForms.SelectedValue) ;
                var paymentCollectionId = this.paymentCollectionId;

                var paymentCollectionRepo = Factory.PaymentCollectionRepository();


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


        internal void cmbforms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAccountableForms.SelectedIndex == -1)
                return;
            CreatePaymentCollection();
        }

        private void CreatePaymentCollection()
        {
            DataRowView forms = cmbAccountableForms.SelectedItem as DataRowView;
            DataRowView collector = cmdCollector.SelectedItem as DataRowView;

            if (forms == null && collector == null)
                return;

            if (paymentCollectionId <= 0)    //ADD
                InsertPaymentCollection(forms, collector);
            else 
                EditPaymentCollection(forms, collector);
        }

        private void InsertPaymentCollection(DataRowView forms, DataRowView collector)
        {
            try
            {
                var collectorId = collector[0].ToString();
                var accountableFormId = forms[0].ToString();

                var receiptIssuedRepo = Factory.ReceiptsIssuedRepository();
                var dtReceiptIssued = receiptIssuedRepo.GetIssuedReceiptByCollectorIdAndAccountableFormId(collectorId, accountableFormId);

                var dtReceiptIssuedRowCount = dtReceiptIssued.Rows.Count;


                if (dtReceiptIssuedRowCount > 0) //IF RECORD FOUND ROW COUNT IS NOT ZERO
                {
                    int receiptNumberTo = 0;
                    int lastIssued = 0;

                    for (int i = 0; i < dtReceiptIssuedRowCount; i++)
                    {
                        receiptNumberTo = Convert.ToInt32(dtReceiptIssued.Rows[i]["receipt_issued_to"]);
                        this.receiptNumberTo = Convert.ToInt32(dtReceiptIssued.Rows[i]["receipt_issued_to"]);
                        receiptNumberFrom = Convert.ToInt32(dtReceiptIssued.Rows[i]["receipt_issued_from"]);
                        lastIssued = dtReceiptIssued.Rows[i]["last_issued"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(dtReceiptIssued.Rows[i]["last_issued"]);
                    }

                    if (receiptNumberTo.Equals(lastIssued))
                        txtReceiptNumber.Text = "0";

                    else
                    {
                        if (lastIssued < receiptNumberFrom)
                            txtReceiptNumber.Text = receiptNumberFrom.ToString("D7");
                        else if (lastIssued.Equals(receiptNumberFrom))
                            txtReceiptNumber.Text = (lastIssued + 1).ToString("D7");
                        else
                            txtReceiptNumber.Text = (lastIssued + 1).ToString("D7");
                    }
                }
                else
                {
                    txtReceiptNumber.Text = "0";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void EditPaymentCollection(DataRowView forms, DataRowView collector)
        {
            if (accountableFormId != Convert.ToInt32(cmbAccountableForms.SelectedValue))
            {
                try
                {
                    var collectorId = collector[0].ToString();
                    var accountableFormId = forms[0].ToString();

                    var receiptsIssuedRepo = Factory.ReceiptsIssuedRepository();
                    var dtReceiptIssued = receiptsIssuedRepo.GetIssuedReceiptByCollectorIdAndAccountableFormId(accountableFormId, accountableFormId);

                    var dtReceiptIssuedRowCount = dtReceiptIssued.Rows.Count;

                    if (dtReceiptIssuedRowCount > 0)
                    {
                        int receiptto = 0;
                        int receiptlast = 0;
                        for (int i = 0; i < dtReceiptIssuedRowCount; i++)
                        {
                            receiptto = Convert.ToInt32(dtReceiptIssued.Rows[i]["receipt_issued_to"]);
                            receiptNumberTo = Convert.ToInt32(dtReceiptIssued.Rows[i]["receipt_issued_to"]);
                            receiptNumberFrom = Convert.ToInt32(dtReceiptIssued.Rows[i]["receipt_issued_from"]);
                            receiptlast = dtReceiptIssued.Rows[i]["last_issued"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(dtReceiptIssued.Rows[i]["last_issued"]);
                        }
                        if (receiptto.Equals(receiptlast))
                            txtReceiptNumber.Text = "0";
                        else
                        {
                            if (receiptlast < receiptNumberFrom)
                                txtReceiptNumber.Text = receiptNumberFrom.ToString("D7");
                            else if (receiptlast.Equals(receiptNumberFrom))
                                txtReceiptNumber.Text = (receiptlast + 1).ToString("D7");
                            else
                                txtReceiptNumber.Text = (receiptlast + 1).ToString("D7");
                        }

                    }
                    else
                    {
                        txtReceiptNumber.Text = "0";
                    }
                }
                catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            }
            else
            {
                txtReceiptNumber.Text = receiptNumber.ToString("D7");
            }
        }

        internal void cmbforms_SelectedValueChanged(object sender, EventArgs e)
        {
            int idOfSelectedAccountableForm = Convert.ToInt32(cmbAccountableForms.SelectedValue);
            accountableFormFaceValue = Factory.FaceValueRepository().GetFaceValueByAccountableFormId(idOfSelectedAccountableForm);
            SwitchFields();
            txtCashTicketQuantity_TextChanged(sender, e);
        }

        internal void cmbcollector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmdCollector.SelectedIndex != -1)
            {
                DataRowView collector = cmdCollector.SelectedItem as DataRowView;
                cmbAccountableForms.Enabled = true;
                txtPayee.Enabled = true;
                //txtreceipt.Enabled = true;
                dtDateOfCollection.Enabled = true;
                txtAmount.Enabled = true;
                cmbAccount.Enabled = true;
                LoadForms(int.Parse(collector[0].ToString()));
            }
            else
            {

                DataRowView collector = cmdCollector.SelectedItem as DataRowView;
                cmbAccountableForms.Enabled = false;
                txtPayee.Enabled = false;
                //txtreceipt.Enabled = false;
                dtDateOfCollection.Enabled = false;
                txtAmount.Enabled = false;
                cmbAccount.Enabled = false;
            }
        }

        private void txtreceipt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private DataTable DatatableAccounts()
        {
            DataTable dtAccounts;

            string searchText = cmbAccount.Text;

            if (string.IsNullOrEmpty(searchText))
            {
                dtAccounts = Factory.GeneralLedgerAccountsRepository().GetGeneralLedgerAccountsIncomeRecords();
            }
            else
            {
                dtAccounts = Factory.GeneralLedgerAccountsRepository().GetGeneralLedgerAccountsIncomeRecords(searchText);
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

        private void txtCashTicketQuantity_TextChanged(object sender, EventArgs e)
        {
            var cashTicketAmount = accountableFormFaceValue;
            var cashTicketQuantity = Convert.ToInt32(txtCashTicketQuantity.Value);
            var amount = (cashTicketAmount) * (cashTicketQuantity);

            txtCashTicketsAmount.Text = amount.ToString("N2");
        }

        private void cmbAccount_SelectedValueChanged(object sender, EventArgs e)
        {
            generalLedgerId = Convert.ToInt32(cmbAccount.SelectedValue);
        }

        private void cmbAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(cmbAccount.Text) && cmbAccount.Focused)
            {
                LoadAccounts();
                cmbAccount.DroppedDown = true;
            }
        }


        internal void CancelReceiptFieldValidations(bool cancelEvent)
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

    }
}
