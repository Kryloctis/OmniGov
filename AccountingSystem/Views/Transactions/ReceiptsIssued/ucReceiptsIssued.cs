using ACC.Domain.Interfaces;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.ReceiptsIssued
{
    public partial class ucReceiptsIssued : UserControl
    {
        internal int Id = 0;
        internal int CoId = 0;
        internal int RId = 0;
        internal int startingreceipt = 0;
        internal int maxreceipt = 0;
        internal int maxtickets = 0;
        internal bool isTickets = false;

        public ucReceiptsIssued()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[5];
            errorArray[0] = epCollectingOfficer.GetError(cmbCollector);
            errorArray[1] = epReceipt.GetError(cmbReceipt);
            errorArray[2] = epFrom.GetError(nudReceiptIssuedFrom);
            errorArray[3] = epTo.GetError(nudReceiptIssuedTo);
            errorArray[4] = epQuantity.GetError(txtReceiptQuantity);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            CoId = 0;
            RId = 0;
            cmbCollector.SelectedIndex = -1;
            cmbReceipt.SelectedIndex = -1;
            nudReceiptIssuedFrom.Text = string.Empty;
            nudReceiptIssuedTo.Text = string.Empty;
            txtReceiptQuantity.Text = string.Empty;
            dtpIssued.Value = DateTime.Now;
        }

        internal void LoadCollectors()
        {
            try
            {
                var collectorRepository = Factory.CollectingOfficerRepository();
                var dtCollector = collectorRepository.GetRecords();
                cmbCollector.DataSource = dtCollector;
                cmbCollector.ValueMember = "id";
                cmbCollector.DisplayMember = "fullname";
                cmbCollector.SelectedIndex = -1;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadCollectors(int rid)
        {
            try
            {
                var collectorRepository = Factory.CollectingOfficerRepository();
                var dtCollector = collectorRepository.GetRecords(rid);
                cmbCollector.DataSource = dtCollector;
                cmbCollector.ValueMember = "id";
                cmbCollector.DisplayMember = "fullname";
            }
            catch (Exception ex) 
            { 
                Helper.MessageBoxError(ex.Message); 
            }
        }

        internal void LoadReceipts()
        {
            try
            {
                var receiptsRepo = Factory.ReceiptsRepository();
                var receiptsDt = receiptsRepo.GetReceipts();

                cmbReceipt.DataSource = receiptsDt;
                cmbReceipt.ValueMember = "id";
                cmbReceipt.DisplayMember = "receipt";
                cmbReceipt.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }


        #region Validations

        private void cmbcollector_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbCollector.Text))
                e.Cancel = Helper.ShowErrorComboBoxEmpty(epCollectingOfficer, cmbCollector, "Collecting Officer.");
        }

        private void cmbcollector_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epCollectingOfficer, cmbCollector);
        }

        private void cmbreceipt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbReceipt.Text))
                e.Cancel = Helper.ShowErrorComboBoxEmpty(epReceipt, cmbReceipt, "Receipt.");
        }

        private void cmbreceipt_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epReceipt, cmbReceipt);
        }

        private void txtfrom_Validating(object sender, CancelEventArgs e)
        {
            if (!isTickets)
            {
                if (string.IsNullOrEmpty(nudReceiptIssuedFrom.Text.Trim()))
                    e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epFrom, nudReceiptIssuedFrom, "Receipt No. From.");

                //if (int.Parse(txtfrom.Text.Trim()) < startingreceipt)
                //{
                //    errorProvider.SetError(txtfrom, "Invalid Receipt No.");
                //    e.Cancel = true;
                //}
            }
        }

        private void txtfrom_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epFrom, nudReceiptIssuedFrom);
        }

        private void txtto_Validating(object sender, CancelEventArgs e)
        {
            if (!isTickets)
            {
                if (string.IsNullOrEmpty(nudReceiptIssuedTo.Text.Trim()))
                    e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epTo, nudReceiptIssuedTo, "Receipt No. To.");

                //if (int.Parse(txtto.Text.Trim()) > maxreceipt)
                //{
                //    errorProvider.SetError(txtto, "Invalid Receipt No.");
                //    e.Cancel = true;
                //}
            }
        }

        private void txtto_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epTo, nudReceiptIssuedTo);
        }

        private void txtquantity_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtReceiptQuantity.Text.Trim()))
                e.Cancel = Helper.ShowErrorTextBoxEmpty(epQuantity, txtReceiptQuantity, "Quantity.");
        }

        private void txtquantity_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epQuantity, txtReceiptQuantity);
        }

        #endregion


        private void cmbReceipt_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataRowView item = cmbReceipt.SelectedItem as DataRowView;
            if (item == null)
                return;

            var receiptId = int.Parse(item[0].ToString());
            var receiptQuantity = int.Parse(item[5].ToString());

            if (CheckReceiptsAvailability(receiptId, receiptQuantity))
            {
                if (item["receipt"].ToString().Contains("Tickets"))
                {
                    SetFieldsForCashTickets();
                }

                else
                {
                    SetFieldsForNonCashTickets();
                    SetReceiptNumberFrom(receiptId);
                }
            }
            else
            {
                nudReceiptIssuedFrom.ResetText();
                nudReceiptIssuedTo.ResetText();
            }
        }

        private bool CheckReceiptsAvailability(int receiptId, int receiptQuantity)
        {
            try
            {
                var receiptsIssuedRepo  = Factory.ReceiptsIssuedRepository();
                var receiptsAvailable = receiptsIssuedRepo.ReceiptAvailability(receiptId, receiptQuantity);

                return receiptsAvailable;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SetReceiptNumberFrom(int receiptId)
        {
            try
            {
                var receiptIssuedRepo = Factory.ReceiptsIssuedRepository();
                var receiptNumberFrom = receiptIssuedRepo.GetReceiptNumberFromByReceiptId(receiptId);
                receiptNumberFrom += 1; 
                nudReceiptIssuedFrom.Text = receiptNumberFrom.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SetFieldsForCashTickets()
        {
            isTickets = true;
            nudReceiptIssuedFrom.Enabled = false;
            nudReceiptIssuedTo.Enabled = false;
            //txtReceiptQuantity.ReadOnly = false;

            nudReceiptIssuedFrom.Text = "0";
            nudReceiptIssuedTo.Text = "0";
            //txtReceiptQuantity.Text = NextTicket(receiptId);
        }

        private void SetFieldsForNonCashTickets()
        {
            isTickets = false;
            nudReceiptIssuedFrom.Enabled = true;
            nudReceiptIssuedTo.Enabled = true;
            //txtReceiptQuantity.ReadOnly = true;
            //txtReceiptIssuedFrom.Text = NextReceipt(int.Parse(item[0].ToString()));
        }

        private void cmbcollector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbCollector.SelectedIndex != -1)
            {
                DataRowView item = cmbCollector.SelectedItem as DataRowView;
                if(item != null)
                {
                    var collectorId = int.Parse(item[0].ToString());
                }
             
            }
        }

        private void ucReceiptsIssued_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadCollectors();
                LoadReceipts();
            }
        }

        private void nudReceiptIssuedTo_ValueChanged(object sender, EventArgs e)
        {
            ComputeReceiptIssueQuantity();
        }

        private void ComputeReceiptIssueQuantity()
        {
            var receiptNumberFrom = nudReceiptIssuedFrom.Value;
            var receiptNumberTo   = nudReceiptIssuedTo.Value;
            var quantity          = (receiptNumberTo - receiptNumberFrom) + 1;

            if (quantity >= 1)
                txtReceiptQuantity.Text = Math.Floor(quantity).ToString();
        }

    }
}
