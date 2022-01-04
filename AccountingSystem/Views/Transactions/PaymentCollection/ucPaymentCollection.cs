using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACC.Domain.Interfaces;

namespace AccountingSystem.Views.Transactions.PaymentCollection
{
    public partial class ucPaymentCollection : UserControl
    {
        internal int Id = 0;
        internal int fundId = 0;
        internal int accId = 0;
        internal int generalLedgerId = 0;
        internal int slaId = 0;
        internal int userid = 0;
        internal bool withsubsidiary = false;
        internal int minreceipt = 0;
        internal int maxreceipt = 0;
        internal int receipt = 0;
       
        internal bool isCashTicket;
        internal int cashTicketFaceValue = 0;
        internal decimal accountableFormFaceValue = 0;

        public ucPaymentCollection()
        {
            InitializeComponent();
        }
        internal string GetFormErrors()
        {
            var errorArray = new string[8];
            errorArray[0] = errorProvider.GetError(cmbcollector);
            errorArray[1] = errorProvider.GetError(cmbfund);
            errorArray[2] = errorProvider.GetError(cmbforms);
            errorArray[3]= errorProvider.GetError(cmbAccount);
            errorArray[4] = errorProvider.GetError(txtpayee);
            errorArray[5] = errorProvider.GetError(txtreceipt);
            errorArray[6] = errorProvider.GetError(dtdate);
            errorArray[7] = errorProvider.GetError(txtamount);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            fundId = 0;
            accId = 0;
            generalLedgerId = 0;
            slaId = 0;
            cmbforms.SelectedIndex = -1;
            cmbAccount.SelectedIndex = -1;

            txtpayee.Clear();
            txtreceipt.Clear();
            dtdate.Value = DateTime.Now;
            txtamount.Value = Convert.ToDecimal("0.00");
            minreceipt = 0;
            maxreceipt = 0;
            receipt = 0;
        }

        internal void LoadForms(int collectorsId)
        {
            try
            {
                var formRepository = Factory.ReceiptsIssuedRepository();
                var dtforms = formRepository.GetRecordsReceipts(collectorsId.ToString());
                dtforms.Columns.Add("formdisplay", typeof(string), "acc_form_no + ' - ' + acc_form_desc + ' - ' + (quantity)");
                cmbforms.DataSource = dtforms;
                cmbforms.ValueMember = "id";
                cmbforms.DisplayMember = "formdisplay";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }


        internal void LoadForms()
        {
            try
            {
                cmbforms.SelectedValueChanged -= cmbforms_SelectedValueChanged;
                var formRepository = Factory.AccountableRepository();
                var dtforms = formRepository.GetRecords();
                dtforms.Columns.Add("formdisplay", typeof(string), "acc_form_no + ' - ' + acc_form_desc");
                cmbforms.DataSource = dtforms;
                cmbforms.ValueMember = "id";
                cmbforms.DisplayMember = "formdisplay";
                cmbforms.SelectedValueChanged += cmbforms_SelectedValueChanged;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }



        internal void LoadFunds()
        {
            try
            {
                var fundRepository = Factory.FundsRepository();
                var dtFund = fundRepository.GetRecords();
                dtFund.Columns.Add("funddisplay", typeof(string), "fund_code + ' - ' + fund_name");
                cmbfund.DataSource = dtFund;
                cmbfund.ValueMember = "id";
                cmbfund.DisplayMember = "funddisplay";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }


        internal void setSelectedValue(int Id, string table)
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
                cmbcollector.DataSource = dtCollector;
                cmbcollector.ValueMember = "id";
                cmbcollector.DisplayMember = "fullname";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }    

        internal bool IsBetween(int num)
        {
            return (num >= minreceipt) && (num <= maxreceipt);
        }



        public void loadSelectedLedger(int Id, string value)
        {
            generalLedgerId = Id;
            cmbAccount.Text = value;
        }

        private void ucPC_Load(object sender, EventArgs e)
        {
            LoadForms(Convert.ToInt32(cmbcollector.SelectedValue));
            LoadCollectors();
            LoadFunds();

            cmbAccount.SelectedValueChanged -= cmbAccount_SelectedValueChanged;
            LoadAccounts();
            cmbAccount.SelectedValueChanged += cmbAccount_SelectedValueChanged;
            cmbAccount.SelectedIndex = -1;
        }

        private void cmbfund_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider, cmbfund, "Funds.");
        }

        private void cmbfund_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider, cmbfund);
        }

        private void cmbcollector_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider, cmbcollector);
        }

        private void cmbcollector_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider, cmbcollector, "Collecting Officer.");
        }

        private void cmbAccount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider, cmbAccount, "Abstract of General Collection.");
        }

        private void cmbAccount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider, cmbAccount);
        }
       
        internal void txtpayee_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtpayee, "Payee.");
        }
        private void txtpayee_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtpayee);
        }

        internal void txtreceipt_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtreceipt, "Receipt No.");
            if (!IsBetween(Convert.ToInt32(txtreceipt.Text.Trim())))
            {
                errorProvider.SetError(txtreceipt, "Receipt No. invalid.");
                e.Cancel = true;
            }
            else if(Convert.ToInt32(txtreceipt.Text.Trim()) <= 0)
            {
                errorProvider.SetError(txtreceipt, "Receipt No. invalid.");
                e.Cancel = true;
            }
        }

        private void txtreceipt_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtreceipt);
        }  

        private void cmbforms_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider, cmbforms);
        }

        private void cmbforms_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider, cmbforms, "Accountable Forms!");
        }

        internal void txtCashTicketQuantity_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownZero(errorProvider, txtCashTicketQuantity, "Cash Ticket Quantity.");
        }

        private void txtCashTicketQuantity_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider, txtCashTicketQuantity);
        }


        private void cmbforms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbforms.SelectedIndex != -1)
            {
                DataRowView forms = cmbforms.SelectedItem as DataRowView;
                DataRowView collector = cmbcollector.SelectedItem as DataRowView;
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
                                    maxreceipt = Convert.ToInt32(dtrc.Rows[i]["issueto"]);
                                    minreceipt = Convert.ToInt32(dtrc.Rows[i]["issuefrom"]);
                                    receiptlast = dtrc.Rows[i]["last_issued"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(dtrc.Rows[i]["last_issued"]);

                                }
                                if (receiptto.Equals(receiptlast))
                                    txtreceipt.Text = "0";
                                else
                                {
                                    if (receiptlast < minreceipt)
                                        txtreceipt.Text = minreceipt.ToString();
                                    else if (receiptlast.Equals(minreceipt))
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
                        if (accId != Convert.ToInt32(cmbforms.SelectedValue))
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
                                        maxreceipt = Convert.ToInt32(dtrc.Rows[i]["issueto"]);
                                        minreceipt = Convert.ToInt32(dtrc.Rows[i]["issuefrom"]);
                                        receiptlast = dtrc.Rows[i]["last_issued"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(dtrc.Rows[i]["last_issued"]);
                                    }
                                    if (receiptto.Equals(receiptlast))
                                        txtreceipt.Text = "0";
                                    else
                                    {
                                        if (receiptlast < minreceipt)
                                            txtreceipt.Text = minreceipt.ToString();
                                        else if (receiptlast.Equals(minreceipt))
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
        private void cmbforms_SelectedValueChanged(object sender, EventArgs e)
        {
            int idOfSelectedAccountableForm = Convert.ToInt32(cmbforms.SelectedValue);

            accountableFormFaceValue = Factory.FaceValueRepository().GetFaceValueByAccountableFormId(idOfSelectedAccountableForm);

            SwitchFields();

            txtCashTicketQuantity_TextChanged(sender, e);
        }
      
        private void cmbcollector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbcollector.SelectedIndex != -1)
            {
                DataRowView collector = cmbcollector.SelectedItem as DataRowView;
                cmbforms.Enabled = true;
                txtpayee.Enabled = true;
                //txtreceipt.Enabled = true;
                dtdate.Enabled = true;
                txtamount.Enabled = true;
                cmbAccount.Enabled = true;
                LoadForms(int.Parse(collector[0].ToString()));
            }
            else
            {
                cmbforms.Enabled = false;
                txtpayee.Enabled = false;
                //txtreceipt.Enabled = false;
                dtdate.Enabled = false;
                txtamount.Enabled = false;
                cmbAccount.Enabled = false;
            }
        }

        private void txtreceipt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }
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
            isCashTicket = cmbforms.Text.Contains("Tickets");

            if (isCashTicket)
            {
                tabPaymentType.SelectedTab = tabCashTickets;
                isCashTicket = true;
            }
            else
            {
                tabPaymentType.SelectedTab = tabNonCashTickets;
                isCashTicket = false;
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
    }
}
