using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.ReceiptsIssued
{
    public partial class ucReceiptsIssued : UserControl
    {
        internal int receiptIssuedId;
        internal int selectedReceiptID;

        internal int collectingOfficerId;
        internal int receiptNumberFrom;
        internal string receiptNumberTo;
        internal int receiptAvailableQuantity;

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
            receiptIssuedId = 0;
            selectedReceiptID = 0;
            collectingOfficerId = 0;
            isCashTickets = false;
            isUpdate = false;
            receiptNumberFrom = 0;
            txtReceiptQuantity.Clear();
            txtReceiptIssuedTo.Clear();
            txtReceiptIssuedFrom.Clear();
            dtpDateIssued.Value = DateTime.Today;
            LoadCollectors();
            LoadReceipts();
            ControlsConfiguration();
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

        private DataTable DataTableRegularCollectingOfficers()
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

        private DataTable DataTableJobOrderCollectionOfficers()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.AddRange(DataColumnsCollectingOfficers());
            DataTable dtCollectingOfficerHasJobOrder = AccFactory.CollectingOfficerHasJobOrdersRepository().GetViewRecords();


            foreach (DataRow row in dtCollectingOfficerHasJobOrder.Rows)
            {
                int jobOrderId = Convert.ToInt32(row["job_orders_id"]);
                string prefix = row["job_orders_prefix"].ToString();
                string firstName = row["job_orders_first_name"].ToString();
                string middleInitial = row["job_orders_mid_initial"].ToString();
                string lastName = row["job_orders_last_name"].ToString();
                string suffix = row["job_orders_suffix"].ToString();
                string jobOrderFullName = Helper.GenerateFullName(prefix, firstName, middleInitial, lastName, suffix);

                var newRow = dataTable.NewRow();
                newRow["id"] = jobOrderId;
                newRow["full_name"] = jobOrderFullName;
                dataTable.Rows.Add(newRow);
            }

            return dataTable;
        }

        internal void LoadCollectors()
        {
            DataTable dataTable = cbCollectingOfficerTypeJO.Checked ? DataTableJobOrderCollectionOfficers() : DataTableRegularCollectingOfficers();
            HelperLoadRecords.CollectingOfficerComboBox(dataTable, cmbCollector, "full_name", "id");
        }

        #endregion Collectors

        internal void LoadReceipts()
        {
            DataTable receiptsDt = AccFactory.ReceiptsRepository().GetRecords();

            foreach (DataRow row in receiptsDt.Rows)
            {
                int receiptsId = Convert.ToInt32(row["id"]);
                DateTime receivedDate = Convert.ToDateTime(row["received_date"]);
                string accountableForm = $"{row["acc_form_no"]} - {row["acc_form_desc"]}";
                int quantity = Convert.ToInt32(row["quantity"]);
                int receiptNumberFrom = Convert.ToInt32(row["receipt_number_from"]);
                int receiptNumberTo = Convert.ToInt32(row["receipt_number_to"]);
                int receiptTotalIssued = AccFactory.ReceiptsIssuedRepository().GetTotalIssuedReceiptByReceiptId(receiptsId);
                int remainingReceipts = quantity - receiptTotalIssued;

                if (accountableForm.ToString().Contains("Tickets", StringComparison.InvariantCultureIgnoreCase))
                    row["acc_form_desc"] = $"{accountableForm} ({remainingReceipts}) ";
                else
                    row["acc_form_desc"] = $"{accountableForm}  ({receiptNumberFrom:D7} - {receiptNumberTo:D7}) ";

                if (remainingReceipts == 0)
                {
                    if (isUpdate && selectedReceiptID != receiptsId)
                        row.Delete();

                    if (!isUpdate)
                        row.Delete();
                }

                DateTime dateIssued = dtpDateIssued.Value.Date;

                if (receivedDate > dateIssued)
                    row.Delete();
            }

            HelperLoadRecords.ReceiptsCombobox(cmbReceipt, receiptsDt);
        }

        private void ucReceiptsIssued_Load(object sender, EventArgs e)
        {
            try
            {
                if (!DesignMode)
                {
                    LoadCollectors();
                    LoadReceipts();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ComputeReceiptIssueQuantity()
        {
            string receiptNumberFrom = txtReceiptIssuedFrom.Text;
            string receiptNumberTo = txtReceiptIssuedTo.Text;

            if (string.IsNullOrEmpty(receiptNumberFrom) || string.IsNullOrEmpty(receiptNumberTo))
                return;

            var quantity = Convert.ToInt32(receiptNumberTo) - Convert.ToInt32(receiptNumberFrom) + 1;

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

        private void txtquantity_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtReceiptQuantity, "Quantity");
            int quantity = string.IsNullOrEmpty(txtReceiptQuantity.Text) ? 0 : Convert.ToInt32(txtReceiptQuantity.Text);

            if (receiptAvailableQuantity < quantity)
            {
                errorProvider1.SetError(txtReceiptQuantity, "Not enough quantity");
                e.Cancel = true;
            }
        }

        private void txtquantity_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtReceiptQuantity);
        }

        private bool ReceiptNumberInRange(int receiptNumber)
        {
            try
            {
                int receiptId = Convert.ToInt32(cmbReceipt.SelectedValue);
                bool isReceiptNumberExist;
                bool isReceiptNumberInRange;

                isReceiptNumberExist = AccFactory.ReceiptsRepository().ReceiptNumberExist(receiptId, receiptNumber);

                if (isUpdate)
                    isReceiptNumberInRange = AccFactory.ReceiptsIssuedRepository().ReceiptNumberInRange(receiptId, receiptNumber, receiptIssuedId);
                else
                    isReceiptNumberInRange = AccFactory.ReceiptsIssuedRepository().ReceiptNumberInRange(receiptId, receiptNumber);

                if (isReceiptNumberExist && isReceiptNumberInRange)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
                return false;
            }
        }

        private bool ReceiptNumberExist(int receiptNumber)
        {
            int receiptID = Convert.ToInt32(cmbReceipt.SelectedValue);

            if (receiptID == 0)
                return AccFactory.ReceiptsRepository().ReceiptNumberExist(receiptID, receiptNumber);
            else
                return AccFactory.ReceiptsRepository().ReceiptNumberExist(receiptID, receiptNumber, receiptID);
        }

        private void txtReceiptNumberFrom_Validating(object sender, CancelEventArgs e)
        {
            if (isCashTickets)
                return;

            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtReceiptIssuedFrom, "Receipt Number From.");

            if (string.IsNullOrEmpty(txtReceiptIssuedFrom.Text))
                return;

            int receiptNumber = Convert.ToInt32(txtReceiptIssuedFrom.Text);
            if (!ReceiptNumberInRange(receiptNumber) && ReceiptNumberExist(receiptNumber))
            {
                errorProvider1.SetError(txtReceiptIssuedFrom, "Receipt series number is out of range.");
                e.Cancel = true;
            }
        }

        private void txtReceiptNumberFrom_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtReceiptIssuedFrom);
        }

        private void txtReceiptNumberTo_Validating(object sender, CancelEventArgs e)
        {
            if (isCashTickets)
                return;

            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtReceiptIssuedTo, "Receipt Number To.");

            if (string.IsNullOrEmpty(txtReceiptIssuedTo.Text))
                return;

            int receiptNumber = Convert.ToInt32(txtReceiptIssuedTo.Text);
            if (!ReceiptNumberInRange(receiptNumber) && ReceiptNumberExist(receiptNumber))
            {
                errorProvider1.SetError(txtReceiptIssuedTo, "Receipt series number is out of range.");
                e.Cancel = true;
            }
        }

        private void txtReceiptNumberTo_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtReceiptIssuedTo);
        }

        #endregion Validations

        internal void SetFieldsForCashTickets()
        {
            isCashTickets = true;
            txtReceiptQuantity.ReadOnly = false;
            txtReceiptIssuedFrom.Clear();
            txtReceiptIssuedFrom.Enabled = false;
            txtReceiptIssuedTo.Clear();
            txtReceiptIssuedTo.Enabled = false;
        }

        internal void SetFieldsForNonCashTickets()
        {
            isCashTickets = false;
            txtReceiptIssuedFrom.Enabled = true;
            txtReceiptIssuedTo.Enabled = true;
            txtReceiptQuantity.ReadOnly = true;
        }

        internal void ControlsConfiguration()
        {
            DataRowView item = cmbReceipt.SelectedItem as DataRowView;
            if (item == null) return;

            selectedReceiptID = Convert.ToInt32(item["id"]);
            int totalIssuedReceipt = AccFactory.ReceiptsIssuedRepository().GetTotalIssuedReceiptByReceiptId(selectedReceiptID);
            receiptAvailableQuantity = Convert.ToInt32(item["quantity"]) - totalIssuedReceipt;
            receiptNumberFrom = Convert.ToInt32(item["receipt_number_from"]);

            string accountableForm = item["acc_form_desc"].ToString();

            if (accountableForm.Contains("Tickets", StringComparison.InvariantCultureIgnoreCase))
                SetFieldsForCashTickets();
            else
            {
                SetFieldsForNonCashTickets();

                if (!isUpdate)
                    txtReceiptIssuedFrom.Text = (receiptNumberFrom + totalIssuedReceipt).ToString("D7");
            }
        }

        private void cmbReceipt_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                ControlsConfiguration();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
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
            if (cbCollectingOfficerTypeJO.Checked)
                isCollectorJO = true;
            else
                isCollectorJO = false;

            LoadCollectors();
        }

        private void dtpDateIssued_ValueChanged(object sender, EventArgs e)
        {
            LoadReceipts();
        }

    }
}