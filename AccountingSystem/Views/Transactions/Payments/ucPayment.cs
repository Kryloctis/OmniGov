using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Ubiety.Dns.Core.Records;

namespace AccountingSystem.Views.Transactions.Payments
{
    public partial class ucPayment : UserControl
    {
        internal decimal amountPayment = 0;
        internal string taxpayerName = string.Empty;

        public ucPayment()
        {
            InitializeComponent();
        }

        private void LoadAccountableForms()
        {
            var dtAccountableForm = AccFactory.AccountableFormsRepository().GetRecords();
            HelperLoadRecords.AccountableFormsCombobox(cmbxAccountableForm, dtAccountableForm);
        }

        private void ResetForm()
        {
            amountPayment = 0;
        }

        private Dictionary<string, string> GetCollectingOfficerData()
        {
            var dict = new Dictionary<string, string>();
            var dictJobOrder = AccFactory.JobOrderRepository().GetRecordByUserID(Helper.UserId);
            var dictCollectingOfficer = AccFactory.CollectingOfficerRepository().GetRecordByUserID(Helper.UserId);

            if (dictJobOrder.Count > 0)
            {
                string jobOrderFullName = Helper.GenerateFullName(dictJobOrder["prefix"], dictJobOrder["first_name"], dictJobOrder["mid_initial"], dictJobOrder["last_name"], dictJobOrder["suffix"]);
                dict.Add("id", dictJobOrder["id"]);
                dict.Add("collector_full_name", jobOrderFullName);
                dict.Add("is_job_order", "true");
            }
            else if (dictCollectingOfficer.Count > 0)
            {
                string collectingOfficerName = Helper.GenerateFullName(dictCollectingOfficer["prefix"], dictCollectingOfficer["first_name"], dictCollectingOfficer["mid_initial"], dictCollectingOfficer["last_name"], dictCollectingOfficer["suffix"]);
                dict.Add("id", dictCollectingOfficer["id"]);
                dict.Add("collector_full_name", collectingOfficerName);
                dict.Add("is_job_order", "false");
            }
            return dict;
        }

        private List<int> GetReceiptsList() 
        {
            var list = new List<int>();

            if (GetCollectingOfficerData().Count < 1)
                return list;

            int collectorId = Convert.ToInt32(GetCollectingOfficerData()["id"]);
            bool isCollectorJobOrder = Convert.ToBoolean(GetCollectingOfficerData()["is_job_order"]);
            int accountableFormId = Convert.ToInt32(cmbxAccountableForm.SelectedValue);

            var dtIssuedReceipts = AccFactory.ReceiptsIssuedRepository().GetViewRecordsByCollectorId_IsCollectorJo_AccountableFormId(collectorId, isCollectorJobOrder, accountableFormId);
            var receiptNos = new List<int>();

            foreach (DataRow row in dtIssuedReceipts.Rows)
            {
                int receiptIssuedFrom = Convert.ToInt32(row["receipt_issued_from"]);
                int receiptIssuedTo = Convert.ToInt32(row["receipt_issued_to"]);

                for (int i = receiptIssuedFrom; i < receiptIssuedTo; i++)
                    receiptNos.Add(i);
            }

            //Sorting Receipt No.s In Order
            receiptNos.Sort((a, b) => a.CompareTo(b));

            var paymentCollectionReceiptsList = AccFactory.PaymentCollectionsRepository().GetRecordsReceiptsByAccFormId(accountableFormId);
            list = receiptNos.Except(paymentCollectionReceiptsList).ToList();

            return list;
        }

        private void LoadReceipts()
        {        
            //Added for Autocomplete Source Collection
            var autoCompleteCollection = new AutoCompleteStringCollection();
            GetReceiptsList().ForEach(x => autoCompleteCollection.Add(x.ToString("#######")));
            txtReceipts.AutoCompleteCustomSource = autoCompleteCollection;
            string receiptNo = txtReceipts.Text = GetReceiptsList().Count < 1? string.Empty : GetReceiptsList()[0].ToString();
        }

        internal void OnLoad()
        {
            try
            {
                lblTotalPayment.Text = amountPayment.ToString("N2");
                txtCollectingOfficer.Text = GetCollectingOfficerData().Count < 1? string.Empty : GetCollectingOfficerData()["collector_full_name"];
                LoadAccountableForms();
                LoadReceipts();
                dtPaymentDate.Value = Helper.GetCurrentDate();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ucPayment_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
                OnLoad();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
        }

        private void cmbxAccountableForm_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadReceipts();
        }

        #region Validations

        private bool ReceiptNoValidated(ErrorProvider errorProvider, TextBox textBox) 
        {
            if (Helper.ShowErrorTextBoxEmpty(errorProvider1, txtReceipts, "Receipt No."))
                return false;
            else 
            {
                int accountableFormId = Convert.ToInt32(cmbxAccountableForm.SelectedValue);
                int receiptNo = Convert.ToInt32(txtReceipts.Text.Trim());
                bool receiptExist = AccFactory.PaymentCollectionsRepository().ReceiptExist(receiptNo, accountableFormId);

                if (!GetReceiptsList().Contains(receiptNo)) 
                {
                    errorProvider.SetError(textBox, "Invalid Receipt No.");
                    return false;
                }
                else if (receiptExist)
                {
                    errorProvider.SetError(textBox, "Used Receipt No.");
                    return false;
                }
                return true;
            }
        }

        private void txtReceipts_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                e.Cancel = !ReceiptNoValidated(errorProvider1, txtReceipts);
            }
            catch (Exception ex){Helper.MessageBoxError(ex.Message);}
        }

        private void txtReceipts_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtReceipts);
        }

        private void txtPayee_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtPayee, "Payee");
        }

        private void txtPayee_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtPayee);
        }
        #endregion

        private void txtReceipts_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}