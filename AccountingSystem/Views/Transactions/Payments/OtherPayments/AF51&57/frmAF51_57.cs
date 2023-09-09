using AccountingSystem.Views.Manage.TaxPayers;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.AF51_57
{
    public partial class frmAF51_57 : Form
    {
        private ucTaxPayers ucTaxPayers;

        public frmAF51_57()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);
            ucTaxPayers = ucTaxPayers1;
        }

        private DataColumn[] PayeesColumns()
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

        private DataTable DataTablePayees(string searchText)
        {
            var dtPayees = AccFactory.TaxpayersRepository().GetViewRecordsBySearch(searchText.Trim());
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(PayeesColumns());

            int progressCount = 0;
            int totalProgressCount = dtPayees.Rows.Count;

            foreach (DataRow row in dtPayees.Rows)
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
                Helper.ProgressCounter(bgwPayee, totalProgressCount, progressCount);

                dataTable.Rows.Add(newRow);
            }

            return dataTable;
        }

        private void LoadPayees(string searchText)
        {
            if (!bgwPayee.IsBusy)
            {
                bgwPayee.RunWorkerAsync(searchText);
            }
        }

        private void bgwPayee_DoWork(object sender, DoWorkEventArgs e)
        {
            string searchText = e.Argument.ToString();
            var dataTable = DataTablePayees(searchText);

            Invoke((MethodInvoker)delegate
            {
                HelperLoadRecords.DatagridViewPayees(dataGridView1, dataTable);
            });
        }

        private void bgwPayee_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void bgwPayee_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView1.CurrentCell = dataGridView1.FirstDisplayedCell;
        }

        #region Content

        private void btnNew_Click(object sender, EventArgs e)
        {
            tabControlPayee.SelectedTab = tabNewPayee;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (Helper.MessageBoxConfirmCancel("Your input won't be stored."))
            {
                tabControlPayee.SelectedTab = tabPayeeList;
                ucTaxPayers.ResetForm();
            }
        }

        private void LoadPayee()
        {
            btnBackMain.Enabled = false;
            radPayee.Checked = true;
        }

        private void LoadFeesAndChargesTab()
        {
            btnBackMain.Enabled = true;
            btnNextMain.Text = "Proceed to Payment";
            radFees.Checked = true;
        }

        private void LoadPaymentTab()
        {
            btnNextMain.Text = "Confirm Payment";
            btnBackMain.Enabled = true;
            radPayment.Checked = true;
        }

        private void ConfirmPayment()
        {
            Helper.MessageBoxConfirmCancel("Confirm Payment?");
        }

        private void ChangeTabs()
        {
            var selectedTab = tabControlMain.SelectedTab;

            if (selectedTab == tabPagePayee)
                tabControlMain.SelectedTab = tabPageFees;
            else if (selectedTab == tabPageFees)
                tabControlMain.SelectedTab = tabPagePayment;
            else if (selectedTab == tabPagePayment)
                ConfirmPayment();
        }

        private void btnNextMain_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeTabs();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnBackMain_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControlMain.SelectedIndex < 0)
                    return;

                tabControlMain.SelectedIndex = tabControlMain.SelectedIndex - 1;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tabPagePayee_Enter(object sender, EventArgs e)
        {
            try
            {
                LoadPayee();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tabPageFees_Enter(object sender, EventArgs e)
        {
            try
            {
                LoadFeesAndChargesTab();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tabPagePayment_Enter(object sender, EventArgs e)
        {
            try
            {
                LoadPaymentTab();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        #endregion Content

        private void frmAF51_57_Load(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearch.Text;
                LoadPayees(searchText);
                ucTaxPayers.chckIsActive.Enabled = false;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearch.Text;
                LoadPayees(searchText);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}