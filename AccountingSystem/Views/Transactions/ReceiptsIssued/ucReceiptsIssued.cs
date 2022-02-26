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
        internal int CollectingOfficerId = 0;
        internal int ReceiptId = 0;
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
            CollectingOfficerId = 0;
            ReceiptId = 0;
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
            }
            catch (Exception ex) 
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadCollectors(int receiptId)
        {
            try
            {
                var collectorRepository = Factory.CollectingOfficerRepository();
                var dtCollector = collectorRepository.GetRecordsByReceiptId(receiptId);
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

        private void nudReceiptIssuedFrom_Validating(object sender, CancelEventArgs e)
        {
            if (!isTickets)
            {
                if (string.IsNullOrEmpty(nudReceiptIssuedFrom.Text.Trim()))
                    e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epFrom, nudReceiptIssuedFrom, "Receipt No. From.");
            }
        }


        private void nudReceiptIssuedFrom_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epFrom, nudReceiptIssuedFrom);
        }

        private void nudReceiptIssuedTo_Validating(object sender, CancelEventArgs e)
        {
            if (!isTickets)
            {
                if (string.IsNullOrEmpty(nudReceiptIssuedTo.Text.Trim()))
                    e.Cancel = Helper.ShowErrorNumericUpDownEmpty(epTo, nudReceiptIssuedTo, "Receipt No. To.");

                if (IsReceiptBetweenFromAndTo() == false)
                {
                    epTo.SetError(nudReceiptIssuedTo, "Invalid receipt number to.");
                    e.Cancel = true;
                }
            }
        }
        private bool IsReceiptBetweenFromAndTo()
        {
            try
            {
                var receiptsRepo = Factory.ReceiptsRepository();
                var receiptNumberFrom = Convert.ToInt32(nudReceiptIssuedFrom.Value);
                var receiptNumberTo = Convert.ToInt32(nudReceiptIssuedTo.Value);
                var receiptId = Convert.ToInt32(cmbReceipt.SelectedValue);

                return receiptsRepo.IsReceiptBetweenFromAndTo(receiptId, receiptNumberFrom, receiptNumberTo);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void nudReceiptIssuedTo_Validated(object sender, EventArgs e)
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

            if (item["receipt"].ToString().Contains("Tickets"))
            {
                SetFieldsForCashTickets();
            }
            else
            {
                if (CheckReceiptsAvailability(receiptId, receiptQuantity))
                {
                    SetFieldsForNonCashTickets();
                    SetReceiptNumberFrom(receiptId);
                }
                else
                {
                    nudReceiptIssuedFrom.ResetText();
                    nudReceiptIssuedTo.ResetText();
                }
            }
        }

        private bool CheckReceiptsAvailability(int receiptId, int receiptQuantity)
        {
            try
            {
                var receiptsIssuedRepo = Factory.ReceiptsIssuedRepository();
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
                var receiptRepo = Factory.ReceiptsRepository();
                var receiptNumberFrom = receiptRepo.GetReceiptNumberFromByReceiptId(receiptId);

                var receiptIssuedRepo = Factory.ReceiptsIssuedRepository();
                var receiptIssuedQuantity = receiptIssuedRepo.GetReceiptIssuedQuantityByReceiptId(receiptId);

                var receiptNumber = (receiptNumberFrom + receiptIssuedQuantity);
                nudReceiptIssuedFrom.Text = receiptNumber.ToString().PadLeft(7, '0');
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SetFieldsForCashTickets()
        {
            txtReceiptQuantity.ReadOnly  = false;
            isTickets = true;
            nudReceiptIssuedFrom.Enabled = false;
            nudReceiptIssuedTo.Enabled = false;
        }

        private void SetFieldsForNonCashTickets()
        {
            isTickets = false;
            nudReceiptIssuedFrom.Enabled = true;
            nudReceiptIssuedTo.Enabled = true;

            txtReceiptQuantity.ReadOnly = true;
        }

        private void cmbcollector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCollector.SelectedIndex != -1)
            {
                DataRowView item = cmbCollector.SelectedItem as DataRowView;
                if (item != null)
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
            var receiptNumberTo = nudReceiptIssuedTo.Value;
            var quantity = (receiptNumberTo - receiptNumberFrom) + 1;

            if (quantity >= 1)
                txtReceiptQuantity.Text = Math.Floor(quantity).ToString();
        }

    }
}
