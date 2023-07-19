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
            receiptId = 0;
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
                string accountableForm = $"{row["acc_form_no"]} - {row["acc_form_desc"]}";
                int quantity = Convert.ToInt32(row["quantity"]);
                int receiptNumberFrom = Convert.ToInt32(row["receipt_number_from"]);
                int receiptNumberTo = Convert.ToInt32(row["receipt_number_to"]);
                int remainingReceipts = quantity - TotalIssued(receiptsId);

                if (accountableForm.ToString().Contains("Tickets"))
                    row["acc_form_desc"] = $"{accountableForm} ({remainingReceipts}) ";
                else
                    row["acc_form_desc"] = $"{accountableForm}  ({receiptNumberFrom:D7} - {receiptNumberTo:D7}) ";

                if (remainingReceipts == 0)
                {
                    if (isUpdate && receiptId != receiptsId)
                        row.Delete();

                    if (!isUpdate)
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

        private bool ReceiptNumberInRange()
        {
            try
            {
                bool isFieldsEmpty = txtReceiptIssuedFrom.Text.Length == 0 || txtReceiptIssuedTo.Text.Length == 0;

                if (isFieldsEmpty)
                    return false;

                int receiptId = Convert.ToInt32(cmbReceipt.SelectedValue);
                int receiptNumberFrom = Convert.ToInt32(txtReceiptIssuedFrom.Text);
                int receiptNumberTo = Convert.ToInt32(txtReceiptIssuedTo.Text);

                return AccFactory.ReceiptsRepository().ReceiptInRange(receiptId, receiptNumberFrom, receiptNumberTo);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
                return false;
            }
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

        private void txtReceiptNumberFrom_Validating(object sender, CancelEventArgs e)
        {
            if (isCashTickets)
                return;

            if (string.IsNullOrEmpty(txtReceiptIssuedFrom.Text.Trim()))
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtReceiptIssuedFrom, "Receipt Number From.");
                return;
            }

            if (!ReceiptNumberInRange() && !string.IsNullOrEmpty(txtReceiptIssuedTo.Text.Trim()))
            {
                errorProvider1.SetError(txtReceiptIssuedFrom, "Invalid receipt number from.");
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

            if (string.IsNullOrEmpty(txtReceiptIssuedTo.Text.Trim()))
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtReceiptIssuedTo, "Receipt Number To.");
                return;
            }

            if (!ReceiptNumberInRange())
            {
                errorProvider1.SetError(txtReceiptIssuedTo, "Invalid receipt number to.");
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

            receiptId = Convert.ToInt32(item["id"]);
            int totalIssuedReceipt = AccFactory.ReceiptsIssuedRepository().GetTotalIssuedReceiptByReceiptId(receiptId);
            receiptAvailableQuantity = Convert.ToInt32(item["quantity"]) - totalIssuedReceipt;
            receiptNumberFrom = Convert.ToInt32(item["receipt_number_from"]);

            if (item["acc_form_desc"].ToString().Contains("Tickets"))
                SetFieldsForCashTickets();
            else
            {
                SetFieldsForNonCashTickets();
                txtReceiptIssuedFrom.Text = (receiptNumberFrom + totalIssuedReceipt).ToString("D7");
            }
        }

        private void cmbReceipt_SelectionChangeCommitted(object sender, EventArgs e)
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
    }
}