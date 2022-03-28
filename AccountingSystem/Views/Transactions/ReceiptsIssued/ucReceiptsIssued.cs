using ACC.Domain.Interfaces;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.ReceiptsIssued
{
    public partial class ucReceiptsIssued : UserControl
    {
        internal int receiptIssuedId;
        internal int receiptId;
        internal int collectingOfficerId;
        internal bool isCashTickets;
        internal bool isCollectorJO;

        internal string receiptNumberFrom;
        internal string receiptNumberTo;

        public ucReceiptsIssued()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[5];
            errorArray[0] = epCollectingOfficer.GetError(cmbCollector);
            errorArray[1] = epReceipt.GetError(cmbReceipt);
            errorArray[2] = epFrom.GetError(txtReceiptIssuedFrom);
            errorArray[3] = epTo.GetError(txtReceiptIssuedTo);
            errorArray[4] = epQuantity.GetError(txtReceiptQuantity);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            radioStubQuantity.Checked = false;
            radioCustomQuantity.Checked = false;
            txtReceiptIssuedFrom.Text = "0";
            txtReceiptIssuedTo.Text = "0";
            txtReceiptQuantity.Clear();
            dtpIssued.Value = DateTime.Today;

            receiptIssuedId = 0;
            receiptId = 0;
            receiptIssuedId = 0;
            collectingOfficerId = 0;
            isCashTickets = false;
            isCollectorJO = false;

            receiptNumberFrom = "0";
            receiptNumberTo = "0";
        }

        internal void LoadCollectors()
        {
            try
            {
                var collectorRepository = Factory.CollectingOfficerRepository();
                var collectorHasJORepo = Factory.CollectingOfficerHasJobOrdersRepository();
                var dtCollector = new DataTable();

                if (cbCollector.Checked)
                {
                    dtCollector = collectorHasJORepo.GetRecords();
                    isCollectorJO = true;
                }
                else
                {
                    dtCollector = collectorRepository.GetRecords();
                    isCollectorJO = false;
                }

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

                foreach (DataRow row in receiptsDt.Rows)
                {
                    string receiptNumberFrom = Convert.ToInt32(row["receipt_number_from"]).ToString("D7");
                    string receiptNumberTo = Convert.ToInt32(row["receipt_number_to"]).ToString("D7");
                        
                    row["acc_form_no"] = $"{row["acc_form_no"]} - {row["acc_form_desc"]}  ({receiptNumberFrom} - {receiptNumberTo}) ";
                }

                cmbReceipt.DataSource = receiptsDt;
                cmbReceipt.ValueMember = "id";
                cmbReceipt.DisplayMember = "acc_form_no";
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

        private bool IsReceiptBetweenFromAndTo()
        {
            try
            {
                var receiptsRepo = Factory.ReceiptsRepository();
                var receiptNumberFrom = Convert.ToInt32(txtReceiptIssuedFrom.Text);
                var receiptNumberTo = Convert.ToInt32(txtReceiptIssuedTo.Text);
                var receiptId = Convert.ToInt32(cmbReceipt.SelectedValue);

                return receiptsRepo.IsReceiptBetweenFromAndTo(receiptId, receiptNumberFrom, receiptNumberTo);
            }
            catch (Exception)
            {
                throw;
            }
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
            if (item == null) return;

            if (item["acc_form_no"].ToString().Contains("Tickets"))
                SetFieldsForCashTickets();
            else
                SetFieldsForNonCashTickets();

            var receiptId = int.Parse(item["id"].ToString());
            var receiptQuantity = int.Parse(item["quantity"].ToString());

            if (ReceiptQuantityAvailable(receiptId, receiptQuantity)) 
            {
                SetReceiptNumberFrom(receiptId, item);
              
                return;
            }
        }
        
        private bool ReceiptQuantityAvailable(int receiptId, int receiptQuantity)
        {
            try
            {
                var receiptsIssuedRepo = Factory.ReceiptsIssuedRepository();
                return receiptsIssuedRepo.ReceiptAvailabilityByQuantity(receiptId, receiptQuantity); ;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SetReceiptNumberFrom(int receiptId, DataRowView item = null)
        {
            try
            {
                if (item != null)
                    receiptNumberFrom = item["receipt_number_from"].ToString();

                var totalUsedReceipt = Factory.ReceiptsIssuedRepository().GetReceiptIssuedQuantityByReceiptId(receiptId);

               txtReceiptIssuedFrom.Text = (Convert.ToInt32(receiptNumberFrom) + Convert.ToInt32(totalUsedReceipt)).ToString("D7");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SetReceiptNumberTo(DataRowView item)
        {
            try
            {
                receiptNumberTo = item["receipt_number_to"].ToString();
                txtReceiptIssuedTo.Text = (Convert.ToInt32(receiptNumberTo) + 49).ToString("D7");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SetFieldsForCashTickets()
        {
            txtReceiptQuantity.ReadOnly  = false;
            isCashTickets = true;

            txtReceiptIssuedFrom.ResetText();
            txtReceiptIssuedTo.ResetText();

            txtReceiptIssuedFrom.Enabled = false;
            txtReceiptIssuedTo.Enabled = false;
        }

        private void SetFieldsForNonCashTickets()
        {
            isCashTickets = false;
            txtReceiptIssuedFrom.Enabled = true;
            txtReceiptIssuedTo.Enabled = true;

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
                cmbReceipt_SelectionChangeCommitted(sender, e);
            }
        }

        private void ComputeReceiptIssueQuantity()
        {
            var receiptNumberFrom = Convert.ToInt32(txtReceiptIssuedFrom.Text);
            var receiptNumberTo = Convert.ToInt32(txtReceiptIssuedTo.Text);
            var quantity = (receiptNumberTo - receiptNumberFrom) + 1;


            if (quantity >= 1)
                txtReceiptQuantity.Text = quantity.ToString();
        }

        private void cbCollector_CheckedChanged(object sender, EventArgs e)
        {
            LoadCollectors();
        }

        private void txtReceiptNumberFrom_Validating(object sender, CancelEventArgs e)
        {
            if (!isCashTickets)
            {
                if (string.IsNullOrEmpty(txtReceiptIssuedFrom.Text.Trim()))
                {
                    e.Cancel = Helper.ShowErrorTextBoxEmpty(epFrom, txtReceiptIssuedFrom, "Receipt No. From.");
                    return;
                }
            }
        }

        private void txtReceiptNumberTo_Validating(object sender, CancelEventArgs e)
        {
            if (!isCashTickets)
            {
                if (string.IsNullOrEmpty(txtReceiptIssuedTo.Text.Trim()))
                {
                    e.Cancel = Helper.ShowErrorTextBoxEmpty(epTo, txtReceiptIssuedTo, "Receipt No. To.");
                    return;
                }
                
                if (IsReceiptBetweenFromAndTo() == false)
                {
                    epTo.SetError(txtReceiptIssuedTo, "Invalid receipt number to.");
                    e.Cancel = true;
                }
            }
        }

        private void txtReceiptNumberFrom_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epFrom, txtReceiptIssuedFrom);
        }

        private void txtReceiptNumberTo_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epTo, txtReceiptIssuedTo);
        }

        private void txtReceiptIssuedFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtReceiptIssuedTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtReceiptIssuedFrom_TextChanged(object sender, EventArgs e)
        {
            ComputeReceiptIssueQuantity();
        }

        private void txtReceiptIssuedTo_TextChanged(object sender, EventArgs e)
        {
            ComputeReceiptIssueQuantity();
        }

        private void radioStubQuantity_CheckedChanged(object sender, EventArgs e)
        {
            SetReceiptNumberFrom(Convert.ToInt32(cmbReceipt.SelectedValue));
            txtReceiptIssuedTo.Text = (Convert.ToInt32(txtReceiptIssuedFrom.Text) + 49).ToString("D7");
        }

        private void radioCustomQuantity_CheckedChanged(object sender, EventArgs e)
        {
            txtReceiptIssuedFrom.Text = "0";
            txtReceiptIssuedTo.Text = "0";
            txtReceiptQuantity.Text = "0";

            txtReceiptIssuedFrom.Focus();
        }

    }
}
