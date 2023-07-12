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
        internal string receiptNumberFrom;
        internal string receiptNumberTo;
        internal int receiptQuantity;

        internal bool isCashTickets;
        internal bool isCollectorJO;
        internal bool isUpdate;

        public ucReceiptsIssued()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(cmbCollector),
                errorProvider1.GetError(cmbReceipt),
                errorProvider1.GetError(txtReceiptIssuedFrom),
                errorProvider1.GetError(txtReceiptIssuedTo),
                errorProvider1.GetError(txtReceiptQuantity)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            try
            {
                receiptIssuedId = 0;
                receiptId = 0;
                receiptIssuedId = 0;
                collectingOfficerId = 0;
                isCashTickets = false;
                isCollectorJO = false;
                receiptNumberFrom = "0";
                receiptNumberTo = "0";
                txtReceiptIssuedFrom.Text = "0";
                txtReceiptIssuedTo.Text = "0";
                txtReceiptQuantity.Clear();
                dtpDateIssued.Value = DateTime.Today;
                LoadCollectors();
                LoadReceipts();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        #region Collectors

        private DataColumn[] DataColumnsCollectingOfficers()
        {
            return new DataColumn[]
            {
                new DataColumn(Name = "id", typeof(int)),
                new DataColumn(Name = "full_name", typeof(string))
            };
        }

        private DataTable DataTableCollectingOfficers()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.AddRange(DataColumnsCollectingOfficers());

            DataTable dtCollectingOfficers = AccFactory.CollectingOfficerRepository().GetRecords();

            foreach (DataRow row in dtCollectingOfficers.Rows)
            {
                var newRow = dataTable.NewRow();
                int Id = Convert.ToInt32(row["id"]);
                string prefix = row["prefix"].ToString();
                string firstName = row["first_name"].ToString();
                string middleInitial = row["mid_initial"].ToString();
                string lastName = row["last_name"].ToString();
                string suffix = row["suffix"].ToString();
                string fullName = Helper.GenerateFullName(prefix, firstName, middleInitial, lastName, suffix);

                newRow["id"] = Id;
                newRow["full_name"] = fullName;
                dataTable.Rows.Add(newRow);
            }
            return dataTable;
        }

        private DataColumn[] DataColumnsCollectingOfficerHasJobOrders()
        {
            return new DataColumn[]
            {
                new DataColumn(Name = "job_orders_id", typeof(int)),
                new DataColumn(Name = "job_orders_full_name", typeof(string))
            };
        }

        private DataTable DataTableCollectingOfficerHasJobOrders()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.AddRange(DataColumnsCollectingOfficerHasJobOrders());
            DataTable dtCollectingOfficerHasJobOrder = AccFactory.CollectingOfficerHasJobOrdersRepository().GetViewRecords();

            foreach (DataRow row in dtCollectingOfficerHasJobOrder.Rows)
            {
                int jobOrderId = Convert.ToInt32(row["job_orders_id"]);
                string prefix = row["job_orders_prefix"].ToString();
                string firstName = row["job_orders_first_name"].ToString();
                string middleInitial = row["job_orders_mid_initial"].ToString();
                string lastName = row["job_orders_last_name"].ToString();
                string suffix = row["job_orders_last_name"].ToString();
                string jobOrderFullName = Helper.GenerateFullName(prefix, firstName, middleInitial, lastName, suffix);

                var newRow = dataTable.NewRow();
                newRow["job_orders_id"] = jobOrderId;
                newRow["job_orders_full_name"] = jobOrderFullName;
                dataTable.Rows.Add(newRow);
            }

            return dataTable;
        }

        internal void LoadCollectors()
        {
            if (cbCollector.Checked)
            {
                HelperLoadRecords.CollectingOfficerComboBox(DataTableCollectingOfficerHasJobOrders(), cmbCollector, "job_orders_full_name", "job_orders_id");
                isCollectorJO = true;
            }
            else
            {
                HelperLoadRecords.CollectingOfficerComboBox(DataTableCollectingOfficers(), cmbCollector, "full_name", "id");
                isCollectorJO = false;
            }
        }

        #endregion Collectors

        internal void LoadCollectorsWithReceiptIssued(int receiptId)
        {
            try
            {
                var collectorRepository = AccFactory.CollectingOfficerRepository();
                var dtCollector = collectorRepository.GetCollectorsWithReceiptsIssuedByReceiptId(receiptId);
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
            DataTable receiptsDt = AccFactory.ReceiptsRepository().GetRecords();

            foreach (DataRow row in receiptsDt.Rows)
            {
                int receiptsId = Convert.ToInt32(row["id"]);
                string accountableForm = $"{row["acc_form_no"]} - {row["acc_form_desc"]}";
                int quantity = Convert.ToInt32(row["quantity"]);
                int receiptNumberFrom = Convert.ToInt32(row["receipt_number_from"]);
                int receiptNumberTo = Convert.ToInt32(row["receipt_number_to"]);
                int remainingReceipts = quantity - TotalIssued(receiptsId);

                if (accountableForm.ToString().Contains("Tickets"))
                    row["acc_form_desc"] = $"{accountableForm} ({remainingReceipts}) ";
                else
                    row["acc_form_desc"] = $"{accountableForm}  ({receiptNumberFrom:D7} - {receiptNumberTo:D7}) ";

                //REMOVE RECEIPT IN COMBOBOX IF RECEIPT QUANTITY IS ZERO
                if (remainingReceipts == 0)
                {
                    if (isUpdate)
                        row.Delete();
                }
            }

            cmbReceipt.DataSource = receiptsDt;
            cmbReceipt.ValueMember = "id";
            cmbReceipt.DisplayMember = "acc_form_desc";

            int TotalIssued(int receiptId)
            {
                return AccFactory.ReceiptsIssuedRepository().GetTotalIssuedReceiptByReceiptId(receiptId);
            }
        }

        private void SetReceiptNumberFrom(int receiptId, DataRowView item = null)
        {
            try
            {
                var totalUsedReceipt = AccFactory.ReceiptsIssuedRepository().GetTotalIssuedReceiptByReceiptId(receiptId);
                txtReceiptIssuedFrom.Text = (Convert.ToInt32(receiptNumberFrom) + Convert.ToInt32(totalUsedReceipt)).ToString("D7");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SetFieldsForCashTickets()
        {
            txtReceiptQuantity.ReadOnly = false;
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

        internal void ReceiptsIssuedStatus()
        {
            bool isUsed = false;

            int receiptID = Convert.ToInt32(cmbReceipt.SelectedValue);
            var receiptDict = AccFactory.ReceiptsRepository().GetRecordByID(receiptID);

            int accountableFormID = Convert.ToInt32(receiptDict["accountable_forms_id"]);
            int receiptNumberFrom = Convert.ToInt32(txtReceiptIssuedFrom.Text);
            int receiptNumberTo = Convert.ToInt32(txtReceiptIssuedTo.Text);

            while (receiptNumberFrom <= receiptNumberTo)
            {
                isUsed = AccFactory.PaymentCollectionsRepository().ReceiptAlreadyUsed(accountableFormID, receiptNumberFrom);

                receiptNumberFrom++;
                if (isUsed)
                    break;
            }

            cmbReceipt.Enabled = !isUsed;
            txtReceiptIssuedFrom.Enabled = !isUsed;
            txtReceiptIssuedTo.Enabled = !isUsed;
        }

        private void OnLoad()
        {
            if (!DesignMode)
            {
                LoadCollectors();
                LoadReceipts();
            }
        }

        private void ucReceiptsIssued_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
                cmbReceipt_SelectionChangeCommitted(sender, e);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ComputeReceiptIssueQuantity()
        {
            var receiptNumberFrom = string.IsNullOrEmpty(txtReceiptIssuedFrom.Text) ? 0 : Convert.ToInt32(txtReceiptIssuedFrom.Text);
            var receiptNumberTo = string.IsNullOrEmpty(txtReceiptIssuedTo.Text) ? 0 : Convert.ToInt32(txtReceiptIssuedTo.Text);
            var quantity = (receiptNumberTo - receiptNumberFrom) + 1;

            if (quantity >= 1)
                txtReceiptQuantity.Text = quantity.ToString();
        }

        #region Validations

        private void cmbcollector_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbCollector.Text))
                e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbCollector, "Collecting Officer.");
        }

        private void cmbcollector_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbCollector);
        }

        private void cmbreceipt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbReceipt.Text))
                e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbReceipt, "Receipt.");
        }

        private void cmbreceipt_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbReceipt);
        }

        private bool IsReceiptBetweenFromAndTo()
        {
            try
            {
                var receiptsRepo = AccFactory.ReceiptsRepository();
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
            if (string.IsNullOrWhiteSpace(txtReceiptQuantity.Text.Trim()))
            {
                e.Cancel = true;
                return;
            }

            if (receiptQuantity < Convert.ToInt32(txtReceiptQuantity.Text.Trim()))
            {
                errorProvider1.SetError(txtReceiptQuantity, "Not enough quantity");
                e.Cancel = true;
            }
        }

        private void txtquantity_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtReceiptQuantity);
        }

        private void txtReceiptNumberFrom_Validating(object sender, CancelEventArgs e)
        {
            if (!isCashTickets)
            {
                if (string.IsNullOrEmpty(txtReceiptIssuedFrom.Text.Trim()))
                {
                    e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtReceiptIssuedFrom, "Receipt No. From.");
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
                    e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtReceiptIssuedTo, "Receipt No. To.");
                    return;
                }

                if (IsReceiptBetweenFromAndTo() == false)
                {
                    errorProvider1.SetError(txtReceiptIssuedTo, "Invalid receipt number to.");
                    e.Cancel = true;
                }
            }
        }

        private void txtReceiptNumberFrom_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtReceiptIssuedFrom);
        }

        private void txtReceiptNumberTo_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtReceiptIssuedTo);
        }

        #endregion Validations

        private void cmbReceipt_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataRowView item = cmbReceipt.SelectedItem as DataRowView;
            if (item == null) return;

            //SET DATA
            receiptId = int.Parse(item["id"].ToString());
            receiptQuantity = (int)item["quantity"] - (AccFactory.ReceiptsIssuedRepository().GetTotalIssuedReceiptByReceiptId(receiptId));
            receiptNumberFrom = item["receipt_number_from"].ToString();

            if (item["acc_form_desc"].ToString().Contains("Tickets"))
                SetFieldsForCashTickets();
            else
            {
                SetFieldsForNonCashTickets();
                SetReceiptNumberFrom(receiptId, item);
                return;
            }
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

        private void cbCollector_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LoadCollectors();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}