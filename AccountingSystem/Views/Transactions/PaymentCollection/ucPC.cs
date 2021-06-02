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
        internal int accId = 0;
        internal int glaId = 0;
        internal int slaId = 0;
        internal int userid = 0;
        public ucPC()
        {
            InitializeComponent();
        }
        internal string GetFormErrors()
        {
            var errorArray = new string[7];
            errorArray[0] = errorProvider.GetError(cmbcollector);
            errorArray[1] = errorProvider.GetError(txtaccountable);
            errorArray[2] = errorProvider.GetError(txtledger);
            errorArray[3] = errorProvider.GetError(txtpayee);
            errorArray[4] = errorProvider.GetError(txtreceipt);
            errorArray[5] = errorProvider.GetError(dtdate);
            errorArray[6] = errorProvider.GetError(txtamount);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            accId = 0;
            glaId = 0;
            slaId = 0;
            txtaccountable.Clear();
            txtledger.Clear();
            txtsubsidiary.Clear();
            txtpayee.Clear();
            txtreceipt.Clear();
            dtdate.Value = DateTime.Now;
            txtamount.Value = Convert.ToDecimal("0.00");
        }
        private void cmbcollector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbcollector.SelectedIndex == -1)
            {
                txtaccountable.Enabled = false;
                txtledger.Enabled = false;
                txtsubsidiary.Enabled = false;
                btnaccountable.Enabled = false;
                btnledger.Enabled = false;
                btnsubsidiary.Enabled = false;
                txtpayee.Enabled = false;
                txtreceipt.Enabled = false;
                dtdate.Enabled = false;
                txtamount.Enabled = false;
                
            }
            else
            {
                txtaccountable.Enabled = true;
                txtledger.Enabled = true;
               // txtsubsidiary.Enabled = true;
                btnaccountable.Enabled = true;
                btnledger.Enabled = true;
              //  btnsubsidiary.Enabled = true;
                txtpayee.Enabled = true;
                txtreceipt.Enabled = true;
                dtdate.Enabled = true;
                txtamount.Enabled = true;
            }
        }
        internal void setSelectedValue(int Id, string table)
        {
           
            try
            {
                if (!string.IsNullOrEmpty(table) || Id > 0)
                {
                    if (table.Equals("accountable"))
                    {
                        var accRepository = Factory.AccountableRepository();
                        var accData = accRepository.GetRecordByID(Id);
                        accId = Id;
                        txtaccountable.Text = String.Format("{0} - {1}", accData["acc_form_no"], accData["acc_form_desc"]);
                    }
                    if (table.Equals("ledger"))
                    {
                        var ledgerRepository = Factory.GeneralLedgerAccountsRepository();
                        var ledgerData = ledgerRepository.GetRecordByID(Id);
                        glaId = Id;
                        txtledger.Text = String.Format("{0} - {1}", ledgerData["ledger_code"], ledgerData["ledger_name"]);
                    }
                    if (table.Equals("subsidiary"))
                    {
                        var subRepository = Factory.SubsidiaryLedgerAccountsRepository();
                        var subData = subRepository.GetRecordByID(Id);
                        slaId = Id;
                        txtsubsidiary.Text = String.Format("{0} - {1}", subData["sub_code"], subData["sub_name"]);

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

        public void loadSelectedAccountable(int Id, string value)
        {
            accId = Id;
            txtaccountable.Text = value;
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

        private void txtaccountable_DoubleClick(object sender, EventArgs e)
        {
            btnaccountable.PerformClick();
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

        private void txtaccountable_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtaccountable, "Accountable Form!");
        }

        private void txtaccountable_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtaccountable);
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
            /*var subRepository = Factory.SubsidiaryLedgerAccountsRepository();
            bool isubsidiary = subRepository.HasSubsidiary(Convert.ToUInt16(glaId));
            if (isubsidiary)
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtsubsidiary, "Subsidiary!");
            }*/
               
        }

        private void txtsubsidiary_Validated(object sender, EventArgs e)
        {
            //Helper.ClearErrorTextBox(errorProvider, txtsubsidiary);
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
                bool isubsidiary = subRepository.HasSubsidiary(Convert.ToUInt16(glaId));
                txtsubsidiary.Enabled = isubsidiary;
                btnsubsidiary.Enabled = isubsidiary;
            }
        }
    }
}
