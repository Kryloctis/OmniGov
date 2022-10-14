using AccountingSystem.Views.Reports.RealPropertyTaxReports.ListOfRealPropertyTaxDelinquencies;
using AccountingSystem.Views.Reports.RealPropertyTaxReports.RealPropertyTaxStatementOfAccount;
using AccountingSystem.Views.Transactions.PaymentPosting;
using AccountingSystem.Views.Transactions.PropertyPayment.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RealPropertyTaxReports.RealPropertyTaxAccountRegister
{
    public partial class frmRptTaxPayerList : Form
    {
        private readonly frmRealPropertyTaxAccountRegisterReport _frmRealPropertyTaxAccountRegisterReport;
        private readonly frmRealPropertyTaxStatementOfAccount _frmRealPropertyTaxStatementOfAccount;
        private readonly frmListOfRealPropertyTaxDelinquenciesReport _frmListOfRealPropertyTaxDelinquenciesReport;
        private readonly frmPayments _frmRealPropertyPayment;

        public frmRptTaxPayerList(
            frmRealPropertyTaxAccountRegisterReport frmRealPropertyTaxAccountRegisterReport,
            frmRealPropertyTaxStatementOfAccount frmRealPropertyTaxStatementOfAccount,
            frmListOfRealPropertyTaxDelinquenciesReport frmListOfRealPropertyTaxDelinquenciesReport,
            frmPayments frmRealPropertyPayment)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);
            _frmRealPropertyTaxAccountRegisterReport = frmRealPropertyTaxAccountRegisterReport;
            _frmRealPropertyTaxStatementOfAccount = frmRealPropertyTaxStatementOfAccount;
            _frmListOfRealPropertyTaxDelinquenciesReport = frmListOfRealPropertyTaxDelinquenciesReport;
            _frmRealPropertyPayment = frmRealPropertyPayment;
            btnSelect.Enabled = true;
        }

        private Form ParentIdentifier()
        {
            var forms = new Form[] { _frmRealPropertyTaxAccountRegisterReport, _frmRealPropertyTaxStatementOfAccount, _frmListOfRealPropertyTaxDelinquenciesReport, _frmRealPropertyPayment };

            foreach (Form form in forms)
            {
                if (form != null)
                    return form;
            }
            return null;
        }

        private DataTable DataTableAssessmentPost(string searchText)
        {
            var columns = new string[] { "id", "owner_tin", "owner_name", "barangay_name", "municipality_name", "province_name", "owner_address" };
            var dtAssessmentPostin = AccFactory.RptAssessmentPostsRepository().GetRecordsBySearch(searchText);
            var dtView = new DataView(dtAssessmentPostin);
            return dtView.ToTable(false, columns);
        }

        private void LoadTaxpayerList()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                string searchText = txtSearch.Text.Trim();
                HelperLoadRecords.TaxPayerListDatagridView(dataGridView1, DataTableAssessmentPost(searchText));
                dataGridView1.CurrentCell = dataGridView1.FirstDisplayedCell;

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
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
            LoadTaxpayerList();
        }

        private void frmRptOwnerList_Load(object sender, EventArgs e)
        {
            EnableDisableSelectButton();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            EnableDisableSelectButton();
        }

        private void InitializeRealPropertyTaxAccountngRegisterReport()
        {

        }

        private void InitializeRealPropertyTaxStatementOfAccountReport()
        {
            int rowIndex = dataGridView1.CurrentRow.Index;
            string ownerName = dataGridView1.Rows[rowIndex].Cells["owner_name"].Value.ToString();
            string completeARPNumber = string.Empty;
            string ownerAddress = dataGridView1.Rows[rowIndex].Cells["owner_address"].Value.ToString();

            _frmRealPropertyTaxStatementOfAccount.completeARPNumber = completeARPNumber;
            _frmRealPropertyTaxStatementOfAccount.OwnerName = ownerName;
            _frmRealPropertyTaxStatementOfAccount.OwnerAddress = ownerAddress;

            _frmRealPropertyTaxStatementOfAccount.backgroundWorker1.RunWorkerAsync();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                LoadMethods();
                Close();
            }
        }

        private void GetSelectedRealPropertyTaxPayer()
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
                    string tin = dataGridView1.Rows[rowIndex].Cells["owner_tin"].Value.ToString();
                    string taxPayerName = dataGridView1.Rows[rowIndex].Cells["owner_name"].Value.ToString();
                    string address = dataGridView1.Rows[rowIndex].Cells["owner_address"].Value.ToString();
                    string barangayName = dataGridView1.Rows[rowIndex].Cells["barangay_name"].Value.ToString();
                    string municipalityName = dataGridView1.Rows[rowIndex].Cells["municipality_name"].Value.ToString();
                    string provinceName = dataGridView1.Rows[rowIndex].Cells["province_name"].Value.ToString();

                    var paymentPostingFields = new rptPropertyPaymentTaxPayerInfoModel()
                    {
                        TIN = tin,
                        TaxPayerName = taxPayerName,
                        Address = address,
                        BarangayName = barangayName,
                        MunicipalityName = municipalityName,
                        ProvinceName = provinceName
                    };

                    _frmRealPropertyPayment.paymentTaxPayerInfoModel = paymentPostingFields;
                    _frmRealPropertyPayment.GetSelectedTaxPayerInfo();
                }

                Close();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void InitializeListOfDeliquentAccountsReport()
        {
            int rowIndex = dataGridView1.CurrentRow.Index;
            _frmListOfRealPropertyTaxDelinquenciesReport._ownerName = dataGridView1.Rows[rowIndex].Cells["owner_name"].Value.ToString();
            _frmListOfRealPropertyTaxDelinquenciesReport.backgroundWorker1.RunWorkerAsync();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            LoadMethods();
        }

        private void LoadMethods()
        {
            switch (ParentIdentifier())
            {
                case frmRealPropertyTaxAccountRegisterReport:
                    InitializeRealPropertyTaxAccountngRegisterReport();
                    break;

                case frmRealPropertyTaxStatementOfAccount:
                    InitializeRealPropertyTaxStatementOfAccountReport();
                    break;

                case frmPayments:
                    GetSelectedRealPropertyTaxPayer();
                    break;

                case frmListOfRealPropertyTaxDelinquenciesReport:
                    InitializeListOfDeliquentAccountsReport();
                    break;

                default:
                    break;
            }

            Close();
        }
    }
}