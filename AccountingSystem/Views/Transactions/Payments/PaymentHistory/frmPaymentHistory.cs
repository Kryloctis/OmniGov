using ACC.Data;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.PaymentHistory
{
    public partial class frmPaymentHistory : Form
    {
        public frmPaymentHistory()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
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
            var dtJoCollectors = AccFactory.JobOrderRepository().GetRecords();

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
            HelperLoadRecords.RowFilterCombobox(cmbxRowFilter);
            LoadCollectors();
            LoadAccountableForms();
        }

        private void frmPaymentHistory_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
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
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}