using LFS.Helpers;
using LFS.Views.Manage.TaxPayers;
using OmniGov.Core.Repositories;
using OmniGov.Core.Factories;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Treasury.Data;

namespace LFS.Views.Transactions.Payments
{
    public partial class ucPaymentRegistry : UserControl
    {
        private string error;
        private readonly ucTaxPayers ucTaxPayers;

        public ucPaymentRegistry()
        {
            InitializeComponent();
            ucTaxPayers = ucTaxPayers1;
            Helper.DatagridFullRowSelectStyle(dgRegistry, true);
        }

        internal string GetFormErrors()
        {
            var errors = new string[]
            {
                error
            };

            return Factory.CreateErrors(errors).GenerateErrorMessage();
        }

        internal bool FormValidated(string fieldName)
        {
            switch (tabControlRegistry.SelectedTab.Name)
            {
                case "tabRegistryList":
                    if (dgRegistry.SelectedRows.Count != 1)
                    {
                        error = $"Select only one {fieldName}";
                        return false;
                    }
                    break;

                case "tabRegister":
                    if (!ucTaxPayers.ValidateChildren())
                    {
                        error = $"Fill all required fields {fieldName}";
                        return false;
                    }
                    break;
            }

            error = string.Empty;
            return true;
        }

        private void OnLoad()
        {
        }

        internal void LoadRegistry()
        {
            if (!backgroundWorker1.IsBusy)
            {
                string searchKey = txtSearch.Text.Trim();
                var dtRegistry = TreasuryFactory.TaxpayersRepository().GetViewRecordsBySearch(searchKey);
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync(dtRegistry);
            }
        }

        private DataColumn[] RegistryColumns()
        {
            return new DataColumn[]
            {
                new DataColumn("taxpayers_id", typeof (int)),
                new DataColumn("taxpayer_type_code", typeof(string)),
                new DataColumn("taxpayers_tin", typeof(string)),
                new DataColumn("taxpayers_name", typeof(string)),
                new DataColumn("taxpayers_address", typeof(string)),
                new DataColumn("taxpayers_contact_info", typeof(string)),
            };
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (e.Argument is not DataTable sourceDb)
                    return;

                var dataTable = new DataTable();
                dataTable.Columns.AddRange(RegistryColumns());

                int progressCount = 0;
                int totalProgressCount = sourceDb.Rows.Count;

                foreach (DataRow row in sourceDb.Rows)
                {
                    var newRow = dataTable.NewRow();
                    int taxpayerId = Convert.ToInt32(row["taxpayers_id"]);
                    string taxpayerTin = row["taxpayers_tin"].ToString();
                    string taxpayerName = row["taxpayers_name"].ToString();
                    string taxpayerTypeCode = row["taxpayer_type"].ToString();
                    string street = string.IsNullOrEmpty(row["taxpayers_street"].ToString()) ? string.Empty : $"{row["taxpayers_street"]},";
                    string barangay = string.IsNullOrEmpty(row["taxpayers_barangay"].ToString()) ? string.Empty : $"{row["taxpayers_barangay"]},";
                    string municipality = string.IsNullOrEmpty(row["taxpayers_municipality"].ToString()) ? string.Empty : $"{row["taxpayers_municipality"]},";
                    string province = string.IsNullOrEmpty(row["taxpayers_province"].ToString()) ? string.Empty : $"{row["taxpayers_province"]},";
                    string taxpayerAddress = $"{street} {barangay} {municipality} {province}";
                    string taxpayerContactInfo = row["taxpayers_contact_info"].ToString();

                    newRow["taxpayers_id"] = taxpayerId;
                    newRow["taxpayer_type_code"] = taxpayerTypeCode;
                    newRow["taxpayers_tin"] = taxpayerTin;
                    newRow["taxpayers_name"] = taxpayerName;
                    newRow["taxpayers_address"] = taxpayerAddress;
                    newRow["taxpayers_contact_info"] = taxpayerContactInfo;

                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                    dataTable.Rows.Add(newRow);
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
            if (e.Cancelled)
                return;
            if (e.Result is not DataTable dataTable)
                return;

            HelperLoadRecords.DatagridViewPayees(dgRegistry, dataTable);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadRegistry();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ucRegistry_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
                ucTaxPayers1.chckIsActive.Enabled = false;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            tabControlRegistry.SelectedTab = tabRegister;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tabControlRegistry.SelectedTab = tabRegistryList;
        }
    }
}

