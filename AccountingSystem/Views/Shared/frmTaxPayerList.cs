using ACC.Data;
using AccountingSystem.Views.Manage.RealProperties;
using AccountingSystem.Views.Reports.RealPropertyTaxReports;
using AccountingSystem.Views.Reports.RealPropertyTaxReports.ListOfRealPropertyTaxDelinquencies;
using AccountingSystem.Views.Reports.RealPropertyTaxReports.RealPropertyTaxStatementOfAccount;
using AccountingSystem.Views.Transactions.Payments;
using AccountingSystem.Views.Transactions.Payments.OtherPayments.CattleOwnership;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Shared
{
    public partial class frmTaxPayerList : Form
    {
        private readonly Form refForm;

        public frmTaxPayerList(Form form)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);
            refForm = form;
        }

        private DataTable DataTableAssessmentPost(string searchText)
        {
            var columns = new string[] { "id", "taxpayer_tin", "taxpayer_name", "barangay_name", "municipality_name", "province_name", "owner_address" };
            var dtAssessmentPostin = AccFactory.RptAssessmentPostsRepository().GetRecordsBySearch(searchText);
            var dtView = new DataView(dtAssessmentPostin);
            return dtView.ToTable(false, columns);
        }

        private DataColumn[] TaxpayersColumns()
        {
            return new DataColumn[]
            {
                new DataColumn("taxpayers_id", typeof (int)),
                new DataColumn("taxpayers_name", typeof(string)),
                new DataColumn("taxpayer_type_code", typeof(string)),
                new DataColumn("taxpayers_tin", typeof(string)),
                new DataColumn("taxpayers_address", typeof(string)),
                new DataColumn("taxpayers_contact_info", typeof(string))
            };
        }

        private DataTable DataTableTaxpayerList(string searchText)
        {
            var dtTaxpayers = AccFactory.TaxpayersRepository().GetViewRecordsBySearch(searchText);
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(TaxpayersColumns());

            int rowCount = 0;
            int recordCount = dtTaxpayers.Rows.Count;

            foreach (DataRow row in dtTaxpayers.Rows)
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
                string createdAt = row["created_at"].ToString();
                string updatedAt = row["updated_at"].ToString();

                newRow["taxpayers_id"] = taxpayerId;
                newRow["taxpayers_name"] = taxpayerName;
                newRow["taxpayer_type_code"] = taxpayerTypeCode;
                newRow["taxpayers_tin"] = taxpayerTin;
                newRow["taxpayers_address"] = taxpayerAddress;
                newRow["taxpayers_contact_info"] = taxpayerContactInfo;

                rowCount++;
                int progressBarPercentage = (rowCount * 100) / recordCount;
                backgroundWorker1.ReportProgress(progressBarPercentage);

                dataTable.Rows.Add(newRow);
            }
            return dataTable;
        }

        private void LoadTaxpayerList()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                string searchText = txtSearch.Text.Trim();
                HelperLoadRecords.DatagridViewTaxPayerList(dataGridView1, DataTableTaxpayerList(searchText));
            });
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView1.CurrentCell = dataGridView1.FirstDisplayedCell;
        }

        private void EnableDisableSelectButton()
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                btnSelect.Enabled = true;
                return;
            }
            btnSelect.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadTaxpayerList();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmRptOwnerList_Load(object sender, EventArgs e)
        {
            try
            {
                EnableDisableSelectButton();
                LoadTaxpayerList();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            EnableDisableSelectButton();
        }

        private void InitializeRealPropertyTaxAccountngRegisterReport()
        {
        }

        private void InitializeRealPropertyTaxStatementOfAccountReport(frmRealPropertyTaxStatementOfAccount frmRealPropertyTaxStatementOfAccount)
        {
            int rowIndex = dataGridView1.CurrentRow.Index;
            string ownerName = dataGridView1.Rows[rowIndex].Cells["taxpayer_name"].Value.ToString();
            string completeARPNumber = string.Empty;
            string ownerAddress = dataGridView1.Rows[rowIndex].Cells["owner_address"].Value.ToString();

            frmRealPropertyTaxStatementOfAccount.completeARPNumber = completeARPNumber;
            frmRealPropertyTaxStatementOfAccount.OwnerName = ownerName;
            frmRealPropertyTaxStatementOfAccount.OwnerAddress = ownerAddress;
            frmRealPropertyTaxStatementOfAccount.backgroundWorker1.RunWorkerAsync();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    LoadMethods();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void InitializeListOfDeliquentAccountsReport(frmListOfRealPropertyTaxDelinquenciesReport frmListOfRealPropertyTaxDelinquenciesReport)
        {
            int rowIndex = dataGridView1.CurrentRow.Index;
            frmListOfRealPropertyTaxDelinquenciesReport._ownerName = dataGridView1.Rows[rowIndex].Cells["taxpayers_name"].Value.ToString();
            frmListOfRealPropertyTaxDelinquenciesReport.backgroundWorker1.RunWorkerAsync();
        }

        private void InitializeRealProperties(frmAddRealProperties frmAddRealProperties)
        {
            int rowIndex = dataGridView1.CurrentRow.Index;

            var taxpayerID = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["taxpayers_id"].Value);
            var dictTaxpayer = AccFactory.TaxpayersRepository().GetViewRecordById(taxpayerID);
            var taxpayer = dictTaxpayer["taxpayers_name"].ToString();
            var taxpayerType = dictTaxpayer["taxpayer_type"].ToString();
            var taxpayerTIN = dictTaxpayer["taxpayers_tin"].ToString();
            var taxpayerContact = dictTaxpayer["taxpayers_contact_info"].ToString();
            var taxpayerBarangay = dictTaxpayer["taxpayers_barangay"].ToString();
            var taxpayerMunicipality = dictTaxpayer["taxpayers_municipality"].ToString();
            var taxpayerProvince = dictTaxpayer["taxpayers_province"].ToString();

            var address = $"{taxpayerBarangay}, {taxpayerMunicipality}, {taxpayerProvince}";

            frmAddRealProperties.uc.taxpayerID = taxpayerID;
            frmAddRealProperties.uc.txtTaxpayers.Text = taxpayer;
            frmAddRealProperties.uc.txtTaxpayerType.Text = taxpayerType;
            frmAddRealProperties.uc.txtTaxpayerTIN.Text = taxpayerTIN;
            frmAddRealProperties.uc.txtTaxpayerContact.Text = taxpayerContact;
            frmAddRealProperties.uc.txtTaxpayerAddress.Text = address;
        }

        private void InitializeNewOwnerDetails(frmRptPayments frmPayments)
        {
            int rowIndex = dataGridView1.CurrentRow.Index;

            var taxpayerId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["taxpayers_id"].Value);
            var dictTaxpayer = AccFactory.TaxpayersRepository().GetViewRecordById(taxpayerId);
            var taxpayer = dictTaxpayer["taxpayers_name"].ToString();
            var taxpayerBarangay = dictTaxpayer["taxpayers_barangay"].ToString();
            var taxpayerMunicipality = dictTaxpayer["taxpayers_municipality"].ToString();
            var taxpayerProvince = dictTaxpayer["taxpayers_province"].ToString();
        }


        private void InitializeOwnerDetails(frmCattleOwnership frmCattleOwnership)
        {
            int rowIndex = dataGridView1.CurrentRow.Index;

            var taxpayerId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["taxpayers_id"].Value);
            var dictTaxpayer = AccFactory.TaxpayersRepository().GetViewRecordById(taxpayerId);
            var taxpayer = dictTaxpayer["taxpayers_name"].ToString();
            var taxpayerBarangay = dictTaxpayer["taxpayers_barangay"].ToString();
            var taxpayerMunicipality = dictTaxpayer["taxpayers_municipality"].ToString();
            var taxpayerProvince = dictTaxpayer["taxpayers_province"].ToString();


            frmCattleOwnership.ucCattleOwnership.ownerID = taxpayerId;
            frmCattleOwnership.ucCattleOwnership.txtOwnerName.Text = taxpayer;
            frmCattleOwnership.ucCattleOwnership.cmbxProvince.Text = taxpayerProvince;
            frmCattleOwnership.ucCattleOwnership.cmbxMunicipality.Text = taxpayerMunicipality;
            frmCattleOwnership.ucCattleOwnership.cmbxBarangay.Text = taxpayerBarangay;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                LoadMethods();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadMethods()
        {
            switch (refForm)
            {
                case frmRealPropertyTaxAccountRegisterReport:
                    InitializeRealPropertyTaxAccountngRegisterReport();
                    break;

                case frmRealPropertyTaxStatementOfAccount:
                    InitializeRealPropertyTaxStatementOfAccountReport((frmRealPropertyTaxStatementOfAccount)refForm);
                    break;

                case frmListOfRealPropertyTaxDelinquenciesReport:
                    InitializeListOfDeliquentAccountsReport((frmListOfRealPropertyTaxDelinquenciesReport)refForm);
                    break;

                case frmAddRealProperties:
                    InitializeRealProperties((frmAddRealProperties)refForm);
                    break;

                case frmRptPayments:
                    InitializeNewOwnerDetails((frmRptPayments)refForm);
                    break;

                case frmCattleOwnership:
                    InitializeOwnerDetails((frmCattleOwnership)refForm);
                    break;

                default:
                    break;
            }

            Close();
        }
    }
}