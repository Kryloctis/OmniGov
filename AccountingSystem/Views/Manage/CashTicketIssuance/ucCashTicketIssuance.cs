using ACC.Data;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.CashTicketIssuance
{
    public partial class ucCashTicketIssuance : UserControl
    {

        internal int selectedCashTicketID;
        internal bool isCollectorJO;
        internal bool isEdit;
        internal int cashTicketRemainingStockQty;
        internal int cashTicketTotalIssued;

        public ucCashTicketIssuance()
        {
            InitializeComponent();
        }

        internal void ResetForm()
        {
            nudQuantity.Value = 0;
            dtpDateIssued.Value = DateTime.Today;
            LoadCollectors();
            LoadCashTickets();
        }

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


        private void ucCashTicketIssuance_Load(object sender, EventArgs e)
        {
            try
            {
                if (!DesignMode)
                {
                    LoadCollectors();
                    LoadCashTickets();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadCashTickets()
        {
            DataTable cashTicketsDT = AccFactory.CashTicketsRepository().GetRecords();

            foreach (DataRow row in cashTicketsDT.Rows)
            {
                int cashTicketId = Convert.ToInt32(row["id"]);
                string accountableForm = $"{row["acc_form_no"]} - {row["acc_form_desc"]}";
                int cashTicketStockQty = Convert.ToInt32(row["quantity"]);
                cashTicketTotalIssued = AccFactory.CashTicketsIssuedRepository().GetTotalIssuedCashTicketById(cashTicketId);
                cashTicketRemainingStockQty = cashTicketStockQty - cashTicketTotalIssued;

                row["acc_form_desc"] = $"{accountableForm} ({cashTicketRemainingStockQty}) ";

                if (cashTicketRemainingStockQty == 0)
                    row.Delete();
            }

            HelperLoadRecords.ReceiptsCombobox(cmbxCashTickets, cashTicketsDT);
        }

        private void cbCollectingOfficerTypeJO_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCollectingOfficerTypeJO.Checked)
                isCollectorJO = true;
            else
                isCollectorJO = false;

            LoadCollectors();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(cmbCollector),
                errorProvider1.GetError(cmbxCashTickets),
                errorProvider1.GetError(nudQuantity),
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private void nudQuantity_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownZero(errorProvider1, nudQuantity, "Quantity");
            int quantity = Convert.ToInt32(nudQuantity.Value);

            if (cashTicketRemainingStockQty < quantity)
            {
                errorProvider1.SetError(nudQuantity, "Not enough quantity.");
                e.Cancel = true;
            }
        }

        private void nudQuantity_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudQuantity);
        }

        private void cmbxCashTickets_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView item = cmbxCashTickets.SelectedItem as DataRowView;
            if (item == null) return;

            selectedCashTicketID = Convert.ToInt32(item["id"]);
            int totalIssuedReceipt = AccFactory.ReceiptsIssuedRepository().GetTotalIssuedReceiptByReceiptId(selectedCashTicketID);
            cashTicketRemainingStockQty = Convert.ToInt32(item["quantity"]) - totalIssuedReceipt;
        }
    }
}
