using ACC.Data;
using ACC.Domain.Models;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace LFS.Views.Transactions.Payments.PaymentHistory
{
    public partial class frmPaymentHistory : Form
    {
        public frmPaymentHistory()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgPaymentHistory, true);
        }

        private void LoadCollectors()
        {
            var dataColumns = new DataColumn[]
            {
                new DataColumn(Name = "id", typeof(int)),
                new DataColumn(Name = "full_name", typeof(string)),
            };

            var dataTable = new DataTable();
            dataTable.Columns.AddRange(dataColumns);
            var dtCoCollectors = AccFactory.CollectingOfficerRepository().GetRecords();
            var dtJoCollectors = AccFactory.CollectingOfficerHasJobOrdersRepository().GetViewRecords();

            foreach (DataRow coRow in dtCoCollectors.Rows)
            {
                var newRow = dataTable.NewRow();
                string suffix = coRow["suffix"].ToString();
                string prefix = coRow["prefix"].ToString();
                string firstName = coRow["first_name"].ToString();
                string midInitial = coRow["mid_initial"].ToString();
                string lastName = coRow["last_name"].ToString();

                string coFullName = Helper.GenerateFullName(prefix, firstName, midInitial, lastName, suffix);

                newRow["id"] = coRow["id"].ToString();
                newRow["full_name"] = coFullName;
                dataTable.Rows.Add(newRow);
            }

            foreach (DataRow joRow in dtJoCollectors.Rows)
            {
                var newRow = dataTable.NewRow();
                string suffix = joRow["suffix"].ToString();
                string prefix = joRow["prefix"].ToString();
                string firstName = joRow["first_name"].ToString();
                string midInitial = joRow["mid_initial"].ToString();
                string lastName = joRow["last_name"].ToString();

                string coFullName = Helper.GenerateFullName(prefix, firstName, midInitial, lastName, suffix);

                newRow["id"] = joRow["id"].ToString();
                newRow["full_name"] = $"{coFullName} (Job Order)";
                dataTable.Rows.Add(newRow);
            }

            cmbxCollector.ComboBox.DataSource = dataTable;
            cmbxCollector.ComboBox.DisplayMember = "full_name";
            cmbxCollector.ComboBox.ValueMember = "id";
        }

        private void LoadAccountableForms()
        {
            var dtAccForms = AccFactory.AccountableFormsRepository().GetRecords();
            HelperLoadRecords.AccountableFormsCombobox(cmbxAccForm.ComboBox, dtAccForms, "id", "acc_form_desc");
        }

        private void OnLoad()
        {
            HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowFilter);
            LoadCollectors();
            LoadAccountableForms();
            LoadRecords();
        }

        private void frmPaymentHistory_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadRecords()
        {
            if (!backgroundWorker1.IsBusy)
            {
                string searchKey = txtSearch.Text.Trim();
                string collectorName = cmbxCollector.Text;
                var collectorId = cmbxCollector.ComboBox.SelectedValue;
                var accFormId = cmbxAccForm.ComboBox.SelectedValue;
                int rowFilter = Convert.ToInt32(cmbxRowFilter.SelectedValue);
                progressBar1.Value = 0;

                if (collectorId is null || accFormId is null)
                {
                    ((DataTable)dgPaymentHistory.DataSource).Rows.Clear();
                    dgPaymentHistory.Refresh();
                    progressBar1.Value = 100;
                    return;
                }

                DataTable dtSourceDb;

                if (collectorName.Contains("(Job Order)"))
                    dtSourceDb = AccFactory.PaymentCollectionsRepository().GerViewRecordsByJoIdAccFormId(Convert.ToInt32(collectorId), Convert.ToInt32(accFormId), searchKey, rowFilter);
                else
                    dtSourceDb = AccFactory.PaymentCollectionsRepository().GerViewRecordsByCoIdAccFormId(Convert.ToInt32(collectorId), Convert.ToInt32(accFormId), searchKey, rowFilter);

                backgroundWorker1.RunWorkerAsync(dtSourceDb);
            }
        }

        private DataColumn[] DataColumns()
        {
            return new DataColumn[]
            {
                new DataColumn(Name = "id", typeof(int)),
                new DataColumn(Name = "receipt_no", typeof(string)),
                new DataColumn(Name = "payee", typeof(string)),
                new DataColumn(Name = "payment_date", typeof(DateTime)),
                new DataColumn(Name = "amount", typeof(decimal)),
                new DataColumn(Name = "is_cancelled", typeof(bool)),
            };
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var dataTable = new DataTable();
                dataTable.Columns.AddRange(DataColumns());

                if (e.Argument is not DataTable dtSourceDb)
                    return;

                int totalProgress = dtSourceDb.Rows.Count;
                int progressCount = 0;

                foreach (DataRow row in dtSourceDb.Rows)
                {
                    var newRow = dataTable.NewRow();

                    newRow["id"] = row["id"];
                    newRow["receipt_no"] = row["receipt_no"];
                    newRow["payee"] = row["payee"];
                    newRow["payment_date"] = row["payment_date"];
                    newRow["amount"] = row["amount"];
                    newRow["is_cancelled"] = row["is_cancelled"];

                    progressCount++;
                    dataTable.Rows.Add(newRow);
                    Helper.ProgressCounter(backgroundWorker1, totalProgress, progressCount);
                }

                e.Result = dataTable;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                    return;
                if (e.Result is not DataTable dataTable)
                    return;

                if (dataTable.Rows.Count < 1)
                    progressBar1.Value = 100;

                lblRecordCount.Text = dataTable.Rows.Count.ToString();
                HelperLoadRecords.DatagridViewPaymentHistory(dataTable, dgPaymentHistory);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxRowFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnMarkAsVoid_Click(object sender, EventArgs e)
        {
            try
            {
                if (Helper.MessageBoxConfirmCancel("Do you want to void this payment?"))
                {
                    if (VoidPayment())
                    {
                        Helper.MessageBoxSuccess("Payment has been voided.");
                        LoadRecords();
                    }
                }
                return;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool VoidPayment()
        {
            try
            {
                int index = dgPaymentHistory.CurrentRow.Index;
                int paymentId = Convert.ToInt32(dgPaymentHistory.Rows[index].Cells["id"].Value);

                var paymentCollectionModel = new PaymentCollectionsModel()
                {
                    Id = paymentId,
                    IsCancelled = true
                };

                return AccFactory.PaymentCollectionsRepository().VoidPayment(paymentCollectionModel);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }

            return false;
        }

        private void dgPaymentHistory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgPaymentHistory.SelectedRows.Count != 0)
                btnMarkAsVoid.Enabled = true;
            else
                btnMarkAsVoid.Enabled = false;
        }
    }
}