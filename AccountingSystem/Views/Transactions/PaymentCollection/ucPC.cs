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
using AccountingSystem.Views.Transactions.PaymentCollection.Find;

namespace AccountingSystem.Views.Transactions.PaymentCollection
{
    public partial class ucPC : UserControl
    {
        internal int Id = 0;
        internal int fundId = 0;
        internal int accId = 0;
        internal int glaId = 0;
        internal int slaId = 0;
        internal int userid = 0;
        internal bool withsubsidiary = false;
        internal int minreceipt = 0;
        internal int maxreceipt = 0;
        internal int receipt = 0;
        public ucPC()
        {
            InitializeComponent();
        }
        internal string GetFormErrors()
        {
            var errorArray = new string[9];
            errorArray[0] = errorProvider.GetError(cmbcollector);
            errorArray[1] = errorProvider.GetError(cmbfund);
            errorArray[2] = errorProvider.GetError(cmbforms);
            errorArray[3]= errorProvider.GetError(txtledger);
            errorArray[4] = errorProvider.GetError(txtpayee);
            errorArray[5] = errorProvider.GetError(txtreceipt);
            errorArray[6] = errorProvider.GetError(dtdate);
            errorArray[7] = errorProvider.GetError(txtamount);
            errorArray[8] = errorProvider.GetError(txtsubsidiary);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            fundId = 0;
            accId = 0;
            glaId = 0;
            slaId = 0;
            cmbforms.SelectedIndex = -1;
            cmbfund.SelectedIndex = -1;
            txtledger.Clear();
            txtsubsidiary.Clear();
            txtpayee.Clear();
            txtreceipt.Clear();
            dtdate.Value = DateTime.Now;
            txtamount.Value = Convert.ToDecimal("0.00");
            minreceipt = 0;
            maxreceipt = 0;
            receipt = 0;
    }
        internal void LoadForms(string id)
        {
            try
            {
                var formRepository = Factory.ReceiptsIssuedRepository();
                var dtforms = formRepository.GetRecordsReceipts(id);
                dtforms.Columns.Add("formdisplay", typeof(string), "acc_form_no + ' - ' + acc_form_desc");
                cmbforms.DataSource = dtforms;
                cmbforms.ValueMember = "id";
                cmbforms.DisplayMember = "formdisplay";
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
                        glaId = Id;
                        txtledger.Text = String.Format("{0} - {1}", ledgerData["ledger_code"], ledgerData["ledger_name"]);
                    }
                    if (table.Equals("subsidiary"))
                    {
                        if(Id > 0)
                        {
                            var subRepository = Factory.SubsidiaryLedgerAccountsRepository();
                            var subData = subRepository.GetRecordByID(Id);
                            slaId = Id;
                            txtsubsidiary.Text = String.Format("{0} - {1}", subData["sub_code"], subData["sub_name"]);
                        }
                        else
                        {
                            slaId = Id;
                            txtsubsidiary.Text = string.Empty;
                        }
                        

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

        internal bool isbetween(int num)
        {
            return num >= minreceipt && num <= maxreceipt;
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
        internal void LoadForms()
        {
            try
            {
                var formRepository = Factory.AccountableRepository();
                var dtforms = formRepository.GetRecords();
                dtforms.Columns.Add("formdisplay", typeof(string), "acc_form_no + ' - ' + acc_form_desc");
                cmbforms.DataSource = dtforms;
                cmbforms.ValueMember = "id";
                cmbforms.DisplayMember = "formdisplay";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
        public void loadSelectedLedger(int Id, string value)
        {
            glaId = Id;
            txtledger.Text = value;
        }
        public void loadSelectedSubsidiary(int Id, string value)
        {
            slaId= Id;
            txtsubsidiary.Text = value;
        }

        private void btnaccountable_Click(object sender, EventArgs e)
        {
            _ = new frmFind(this, "accountable").ShowDialog();
        }

        private void btnledger_Click(object sender, EventArgs e)
        {
            _ = new frmFind(this, "ledger").ShowDialog();
        }
        private void txtledger_DoubleClick(object sender, EventArgs e)
        {
            btnledger.PerformClick();
        }

        private void ucPC_Load(object sender, EventArgs e)
        {
            
        }

        private void cmbcollector_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider, cmbcollector);
        }

        private void cmbcollector_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider, cmbcollector, "Collecting Officer!");
        }

        private void txtledger_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtledger, "General Ledger Account!");
        }

        private void txtledger_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtledger);
        }

        private void txtpayee_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtpayee, "Payee!");
        }

        private void txtpayee_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtpayee);
        }

        private void txtreceipt_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtreceipt, "Receipt No!");
            if (!isbetween(Convert.ToInt32(txtreceipt.Text.Trim())))
            {
                errorProvider.SetError(txtreceipt, "Receipt No. invalid!");
                e.Cancel = true;
            }
        }

        private void txtreceipt_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtreceipt);
        }

        private void btnsubsidiary_Click(object sender, EventArgs e)
        {
            _ = new frmFind(this, "subsidiary").ShowDialog();
        }

        private void txtsubsidiary_Validating(object sender, CancelEventArgs e)
        {
            if (withsubsidiary)
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtsubsidiary, "Subsidiary!");
            }
               
        }

        private void txtsubsidiary_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtsubsidiary);
        }

        private void txtsubsidiary_DoubleClick(object sender, EventArgs e)
        {
            btnsubsidiary.PerformClick();
        }

        private void txtledger_TextChanged(object sender, EventArgs e)
        {
            if(txtledger.Text.Length > 0 && glaId > 0)
            {
                var subRepository = Factory.SubsidiaryLedgerAccountsRepository();
                withsubsidiary = subRepository.HasSubsidiary(Convert.ToUInt16(glaId));
                txtsubsidiary.Enabled = withsubsidiary;
                btnsubsidiary.Enabled = withsubsidiary;
                if (!withsubsidiary)
                {
                    txtsubsidiary.Clear();
                    slaId = 0;
                }
            }
        }

        private void cmbfund_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider, cmbfund, "Funds!");
        }

        private void cmbfund_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider, cmbfund);
        }

        private void cmbforms_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider, cmbforms);
        }

        private void cmbforms_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider, cmbforms, "Accountable Forms!");
        }

        private void cmbforms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbforms.SelectedIndex != -1 && cmbforms.Focused)
            {
                if (Id <= 0)
                {
                    try
                    {
                        var rcRepository = Factory.ReceiptsIssuedRepository();
                        var dtrc = rcRepository.GetRecords(cmbcollector.SelectedValue.ToString(), cmbforms.SelectedValue.ToString());
                        if (dtrc.Rows.Count > 0)
                        {
                            int receiptto = 0;
                            int receiptlast = 0;
                            for (int i = 0; i < dtrc.Rows.Count; i++)
                            {
                                receiptto = Convert.ToInt32(dtrc.Rows[i]["receiptsto"]);
                                maxreceipt = Convert.ToInt32(dtrc.Rows[i]["receiptsto"]);
                                minreceipt = Convert.ToInt32(dtrc.Rows[i]["receiptsfrom"]);
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
                            var dtrc = rcRepository.GetRecords(cmbcollector.SelectedValue.ToString(), cmbforms.SelectedValue.ToString());
                            if (dtrc.Rows.Count > 0)
                            {
                                int receiptto = 0;
                                int receiptlast = 0;
                                for (int i = 0; i < dtrc.Rows.Count; i++)
                                {

                                    receiptto = Convert.ToInt32(dtrc.Rows[i]["receiptsto"]);
                                    maxreceipt = Convert.ToInt32(dtrc.Rows[i]["receiptsto"]);
                                    minreceipt = Convert.ToInt32(dtrc.Rows[i]["receiptsfrom"]);
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

        private void cmbcollector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbcollector.SelectedIndex != -1)
            {
                cmbfund.Enabled = true;
                cmbforms.Enabled = true;
                btnledger.Enabled = true;
                txtpayee.Enabled = true;
                txtreceipt.Enabled = true;
                dtdate.Enabled = true;
                txtamount.Enabled = true;
                txtledger.Enabled = true;
                btnledger.Enabled = true;
                txtsubsidiary.Enabled = true;
                btnsubsidiary.Enabled = true;
            }
            else
            {
                cmbfund.Enabled = false;
                cmbforms.Enabled = false;
                btnledger.Enabled = false;
                txtpayee.Enabled = false;
                txtreceipt.Enabled = false;
                dtdate.Enabled = false;
                txtamount.Enabled = false;
                txtledger.Enabled = false;
                btnledger.Enabled = false;
                txtsubsidiary.Enabled = false;
                btnsubsidiary.Enabled = false;
            }
        }

        private void txtreceipt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }
        }
    }
}
