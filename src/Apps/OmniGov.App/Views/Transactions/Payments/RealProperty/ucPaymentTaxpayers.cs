using OmniGov.App.Helpers;
using OmniGov.Core.Factories;
using System.ComponentModel;
using System.Data;
using Treasury.Data.Factories;

namespace OmniGov.App.Views.Transactions.Payments.RealProperty
{
    public partial class ucPaymentTaxpayers : UserControl
    {
        public ucPaymentTaxpayers()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);
        }

        internal void ResetForm()
        {
            txtSearch.Clear();
            LoadTaxpayers();
        }

        internal void OnLoad()
        {
            HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowFilter.ComboBox);
            cmbxRowFilter.ComboBox.SelectionChangeCommitted += new EventHandler(CmbxRowFiter_SelectionChangeCommitted);
            LoadTaxpayers();
        }

        internal string GetFormErrors()
        {
            var errors = new string[] { this.Tag == null ? string.Empty : this.Tag.ToString() };
            return Factory.CreateErrors(errors).GenerateErrorMessage();
        }

        internal bool IsValidated()
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                this.Tag = "Invalid taxpayer";
                return false;
            }

            this.Tag = null;
            return true;
        }

        internal int GetSelectedTaxpayerId()
        {
            int index = dataGridView1.CurrentRow.Index;
            return Convert.ToInt32(dataGridView1.Rows[index].Cells["taxpayers_id"].Value);
        }

        private void LoadTaxpayers()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
                string searchKey = txtSearch.Text.Trim();
                int rowFilter = Convert.ToInt32(cmbxRowFilter.ComboBox.SelectedValue);
                backgroundWorker1.RunWorkerAsync((searchKey, rowFilter));
            }
        }

        private DataColumn[] TaxpayersColumns()
        {
            return new DataColumn[]
            {
                new DataColumn("taxpayers_id", typeof (int)),
                new DataColumn("taxpayers_name", typeof(string)),
                new DataColumn("taxpayer_type", typeof(string)),
                new DataColumn("taxpayers_tin", typeof(string)),
                new DataColumn("taxpayers_address", typeof(string)),
                new DataColumn("taxpayers_contact_info", typeof(string)),
                new DataColumn("representative_name", typeof(string)),
                new DataColumn("is_active", typeof(bool)),
                new DataColumn("created_at", typeof(string)),
                new DataColumn("updated_at", typeof(string))
            };
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var parameters = ((string searchKey, int rowFilter))e.Argument;
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(TaxpayersColumns());
            var dtTaxpayers = TreasuryFactory.TaxpayersRepository().GetViewRecordsByParameters(parameters.searchKey, true, parameters.rowFilter);

            int totalProgressCount = dtTaxpayers.Rows.Count;
            int progressCount = 0;

            foreach (DataRow row in dtTaxpayers.Rows)
            {
                var newRow = dataTable.NewRow();
                int taxpayerId = Convert.ToInt32(row["taxpayers_id"]);
                string taxpayerTin = $"{row["taxpayers_tin"]}";
                string taxpayerName = $"{row["taxpayers_name"]}";
                string taxpayerTypeCode = $"{row["taxpayer_type"]}";
                string representativeName = string.IsNullOrWhiteSpace($"{row["representative_name"]}") ? "None" : $"{row["representative_name"]}";
                string address = $"{row["taxpayers_address"]}";
                string municipality = $"{row["taxpayers_municipality"]}";
                string province = $"{row["taxpayers_province"]}";
                string taxpayerAddress = $"{address}, {municipality}, {province}";
                string taxpayerContactInfo = $"{row["taxpayers_contact_info"]}";
                bool isActive = Convert.ToBoolean(Convert.ToByte(row["is_active"]));
                string createdAt = $"{row["created_at"]}";
                string updatedAt = $"{row["updated_at"]}";

                newRow["taxpayers_id"] = taxpayerId;
                newRow["taxpayer_type"] = taxpayerTypeCode;
                newRow["taxpayers_tin"] = taxpayerTin;
                newRow["taxpayers_name"] = taxpayerName;
                newRow["taxpayers_address"] = taxpayerAddress;
                newRow["taxpayers_contact_info"] = taxpayerContactInfo;
                newRow["representative_name"] = representativeName;
                newRow["is_active"] = isActive;
                newRow["created_at"] = createdAt;
                newRow["updated_at"] = updatedAt;

                progressCount++;
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                dataTable.Rows.Add(newRow);
            }

            e.Result = dataTable;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                return;
            if (e.Result is not DataTable dataTable)
                return;

            HelperLoadRecords.TaxpayerDatagridView(dataGridView1, dataTable);
            dataGridView1.CurrentCell = dataGridView1.FirstDisplayedCell;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadTaxpayers();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void CmbxRowFiter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadTaxpayers();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}