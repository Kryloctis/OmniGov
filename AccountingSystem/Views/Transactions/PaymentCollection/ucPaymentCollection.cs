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
        internal int Id = 0;
        internal int fundId = 0;
        internal int accId = 0;
        internal int generalLedgerId = 0;
        internal int userid = 0;
        internal int minReceipt = 0;
        internal int maxReceipt = 0;
        internal int receipt = 0;

        internal bool isCashTicket;
        internal int cashTicketFaceValue = 0;
        internal decimal accountableFormFaceValue;

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
            errorArray[4] = epPayee.GetError(txtpayee);
            errorArray[5] = epSerialNo.GetError(txtreceipt);
            errorArray[6] = epCashTicketQuantity.GetError(txtCashTicketQuantity);
            errorArray[7] = epCashTicketAmount.GetError(txtCashTicketsAmount);
            errorArray[8] = epORAmount.GetError(txtAmount);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            fundId = 0;
            accId = 0;
            //generalLedgerId = 0;
            //cmbAccountableForms.SelectedIndex = -1;
            //cmbAccount.SelectedIndex = -1;

            txtreceipt.Clear();
            txtpayee.Clear();
            dtDateOfCollection.Value = DateTime.Now;
            txtAmount.Value = Convert.ToDecimal("0.00");
            minReceipt = 0;
            maxReceipt = 0;
            receipt = 0;
        }

        internal void LoadForms(int collectorsId)
        {
            try
            {
                var formRepository = Factory.ReceiptsIssuedRepository();
                var dtforms = formRepository.GetRecordsReceipts(collectorsId.ToString());
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
                var formRepository = Factory.AccountableRepository();
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
                var collectorRepository = Factory.CollectingOfficerRepository();
                var dtCollector = collectorRepository.GetRecords();
                cmdCollector.DataSource = dtCollector;
                cmdCollector.ValueMember = "id";
                cmdCollector.DisplayMember = "fullname";
            }
            catch (Exception ex) 
            { 
                Helper.MessageBoxError(ex.Message);
            }
        }    

        internal bool IsBetween(int num)
        {
            return (num >= minReceipt) && (num <= maxReceipt);
        }

        private void ucPaymentCollection_Load(object sender, EventArgs e)
        {
            LoadForms(Convert.ToInt32(cmdCollector.SelectedValue));
            LoadCollectors();
            LoadFunds();

            cmbAccount.SelectedValueChanged -= cmbAccount_SelectedValueChanged;
            LoadAccounts();
            cmbAccount.SelectedValueChanged += cmbAccount_SelectedValueChanged;
            cmbAccount.SelectedIndex = -1;
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
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epSerialNo, txtreceipt, "Receipt No.");

            if (!IsBetween(Convert.ToInt32(txtreceipt.Text.Trim())))
            {
                epSerialNo.SetError(txtreceipt, "Receipt No. invalid.");
                e.Cancel = true;
            }
            else if (Convert.ToInt32(txtreceipt.Text.Trim()) <= 0)
            {
                epSerialNo.SetError(txtreceipt, "Receipt No. invalid.");
                e.Cancel = true;
            }
        }

        private void txtreceipt_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epSerialNo, txtreceipt);
        }

        internal void txtpayee_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epPayee, txtpayee, "Payee.");
        }

        private void txtpayee_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epPayee, txtpayee);
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
            if (cmbAccountableForms.SelectedIndex != -1)
            {
                DataRowView forms = cmbAccountableForms.SelectedItem as DataRowView;
                DataRowView collector = cmdCollector.SelectedItem as DataRowView;
                if (forms != null && collector != null)
                {
                    if (Id <= 0)
                    {
                        try
                        {
                            var rcRepository = Factory.ReceiptsIssuedRepository();
                            var dtrc = rcRepository.GetRecords(collector[0].ToString(), forms[0].ToString());
                            if (dtrc.Rows.Count > 0)
                            {
                                int receiptto = 0;
                                int receiptlast = 0;
                                for (int i = 0; i < dtrc.Rows.Count; i++)
                                {
                                    receiptto = Convert.ToInt32(dtrc.Rows[i]["issueto"]);
                                    maxReceipt = Convert.ToInt32(dtrc.Rows[i]["issueto"]);
                                    minReceipt = Convert.ToInt32(dtrc.Rows[i]["issuefrom"]);
                                    receiptlast = dtrc.Rows[i]["last_issued"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(dtrc.Rows[i]["last_issued"]);

                                }
                                if (receiptto.Equals(receiptlast))
                                    txtreceipt.Text = "0";
                                else
                                {
                                    if (receiptlast < minReceipt)
                                        txtreceipt.Text = minReceipt.ToString();
                                    else if (receiptlast.Equals(minReceipt))
                                        txtreceipt.Text = (receiptlast + 1).ToString();
                                    else
                                        txtreceipt.Text = (receiptlast + 1).ToString();
                                }

                            }
                            else
                            {
                                txtreceipt.Text = "0";
                            }
                        }
                        catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
                    }
                    else
                    {
                        if (accId != Convert.ToInt32(cmbAccountableForms.SelectedValue))
                        {
                            try
                            {
                                var rcRepository = Factory.ReceiptsIssuedRepository();
                                var dtrc = rcRepository.GetRecords(collector[0].ToString(), forms[0].ToString());
                                if (dtrc.Rows.Count > 0)
                                {
                                    int receiptto = 0;
                                    int receiptlast = 0;
                                    for (int i = 0; i < dtrc.Rows.Count; i++)
                                    {

                                        receiptto = Convert.ToInt32(dtrc.Rows[i]["issueto"]);
                                        maxReceipt = Convert.ToInt32(dtrc.Rows[i]["issueto"]);
                                        minReceipt = Convert.ToInt32(dtrc.Rows[i]["issuefrom"]);
                                        receiptlast = dtrc.Rows[i]["last_issued"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(dtrc.Rows[i]["last_issued"]);
                                    }
                                    if (receiptto.Equals(receiptlast))
                                        txtreceipt.Text = "0";
                                    else
                                    {
                                        if (receiptlast < minReceipt)
                                            txtreceipt.Text = minReceipt.ToString();
                                        else if (receiptlast.Equals(minReceipt))
                                            txtreceipt.Text = (receiptlast + 1).ToString();
                                        else
                                            txtreceipt.Text = (receiptlast + 1).ToString();
                                    }

                                }
                                else
                                {
                                    txtreceipt.Text = "0";
                                }
                            }
                            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
                        }
                        else
                        {
                            txtreceipt.Text = receipt.ToString();
                        }
                    }
                }
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
            if(cmdCollector.SelectedIndex != -1)
            {
                DataRowView collector = cmdCollector.SelectedItem as DataRowView;
                cmbAccountableForms.Enabled = true;
                txtpayee.Enabled = true;
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
                txtpayee.Enabled = false;
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
               txtreceipt.Validating -= new CancelEventHandler(txtreceipt_Validating);
               txtpayee.Validating -= new CancelEventHandler(txtpayee_Validating);
            }
            else
            {
                txtreceipt.Validating += new CancelEventHandler(txtreceipt_Validating);
                txtpayee.Validating += new CancelEventHandler(txtpayee_Validating);
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
                txtpayee.Validating += new CancelEventHandler(txtpayee_Validating);
            }
        }

    }
}
