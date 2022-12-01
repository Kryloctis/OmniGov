using AccountingSystem.Views.Manage.Realignment;
using AccountingSystem.Views.Manage.RealProperties;
using AccountingSystem.Views.Manage.TaxPayers;
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
        private readonly frmAddRealProperties _frmAddRealProperties;

        public frmRptTaxPayerList(
            frmRealPropertyTaxAccountRegisterReport frmRealPropertyTaxAccountRegisterReport,
            frmRealPropertyTaxStatementOfAccount frmRealPropertyTaxStatementOfAccount,
            frmListOfRealPropertyTaxDelinquenciesReport frmListOfRealPropertyTaxDelinquenciesReport,
            frmPayments frmRealPropertyPayment,
            frmAddRealProperties frmAddRealProperties
            )
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);
            _frmRealPropertyTaxAccountRegisterReport = frmRealPropertyTaxAccountRegisterReport;
            _frmRealPropertyTaxStatementOfAccount = frmRealPropertyTaxStatementOfAccount;
            _frmListOfRealPropertyTaxDelinquenciesReport = frmListOfRealPropertyTaxDelinquenciesReport;
            _frmRealPropertyPayment = frmRealPropertyPayment;
            _frmAddRealProperties = frmAddRealProperties;
            btnSelect.Enabled = true;
        }

        private Form ParentIdentifier()
        {
            var forms = new Form[] { _frmRealPropertyTaxAccountRegisterReport, _frmRealPropertyTaxStatementOfAccount, _frmListOfRealPropertyTaxDelinquenciesReport, _frmRealPropertyPayment, _frmAddRealProperties };

            foreach (Form form in forms)
            {
                if (form != null)
                    return form;
            }
            return null;
        }

        private DataTable DataTableAssessmentPost(string searchText)
        {
            var columns = new string[] { "id", "taxpayer_tin", "taxpayer_name", "barangay_name", "municipality_name", "province_name", "owner_address" };
            var dtAssessmentPostin = AccFactory.RptAssessmentPostsRepository().GetRecordsBySearch(searchText);
            var dtView = new DataView(dtAssessmentPostin);
            return dtView.ToTable(false, columns);
        }

        private DataTable DataTableTaxpayerList(string searchText)
        {
            var columns = new string[] { "taxpayers_id", "taxpayers_name", "taxpayer_type", "taxpayers_tin", "taxpayers_contact_info", "taxpayers_barangay", "taxpayers_street", "taxpayers_municipality", "taxpayers_province" };

            var dtTaxpayer = AccFactory.TaxpayersRepository().GetRecordsBySearch(searchText);
            var dtView = new DataView(dtTaxpayer);
            return dtView.ToTable(false, columns);
        }

        private void LoadTaxpayerList()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                string searchText = txtSearch.Text.Trim();
                HelperLoadRecords.TaxPayerListDatagridView(dataGridView1, DataTableTaxpayerList(searchText));
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
            string ownerName = dataGridView1.Rows[rowIndex].Cells["taxpayer_name"].Value.ToString();
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
                    string tin = dataGridView1.Rows[rowIndex].Cells["taxpayers_tin"].Value.ToString();
                    string taxPayerName = dataGridView1.Rows[rowIndex].Cells["taxpayers_name"].Value.ToString();
                    string address = dataGridView1.Rows[rowIndex].Cells["taxpayers_street"].Value.ToString();
                    string barangayName = dataGridView1.Rows[rowIndex].Cells["taxpayers_barangay"].Value.ToString();
                    string municipalityName = dataGridView1.Rows[rowIndex].Cells["taxpayers_municipality"].Value.ToString();
                    string provinceName = dataGridView1.Rows[rowIndex].Cells["taxpayers_province"].Value.ToString();

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

        private void GetSelectedTaxpayer()
        {
            try
            {
                MessageBox.Show("Test");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void InitializeListOfDeliquentAccountsReport()
        {
            int rowIndex = dataGridView1.CurrentRow.Index;
            _frmListOfRealPropertyTaxDelinquenciesReport._ownerName = dataGridView1.Rows[rowIndex].Cells["taxpayer_name"].Value.ToString();
            _frmListOfRealPropertyTaxDelinquenciesReport.backgroundWorker1.RunWorkerAsync();
        }

        private void InitializeRealProperties()
        {
            int rowIndex = dataGridView1.CurrentRow.Index;

            var taxpayerID = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["taxpayers_id"].Value);
            var taxpayer = dataGridView1.Rows[rowIndex].Cells["taxpayers_name"].Value.ToString();
            var taxpayerType = dataGridView1.Rows[rowIndex].Cells["taxpayer_type"].Value.ToString();
            var taxpayerTIN = dataGridView1.Rows[rowIndex].Cells["taxpayers_tin"].Value.ToString();
            var taxpayerContact = dataGridView1.Rows[rowIndex].Cells["taxpayers_contact_info"].Value.ToString();
            var taxpayerBarangay = dataGridView1.Rows[rowIndex].Cells["taxpayers_barangay"].Value.ToString();
            var taxpayerMunicipality = dataGridView1.Rows[rowIndex].Cells["taxpayers_municipality"].Value.ToString();
            var taxpayerProvince = dataGridView1.Rows[rowIndex].Cells["taxpayers_province"].Value.ToString();

            var address = $"{taxpayerBarangay}, {taxpayerMunicipality}, {taxpayerProvince}";

            _frmAddRealProperties.uc.taxpayerID = taxpayerID;
            _frmAddRealProperties.uc.txtTaxpayers.Text = taxpayer;
            _frmAddRealProperties.uc.txtTaxpayerType.Text = taxpayerType;
            _frmAddRealProperties.uc.txtTaxpayerTIN.Text = taxpayerTIN;
            _frmAddRealProperties.uc.txtTaxpayerContact.Text = taxpayerContact;
            _frmAddRealProperties.uc.txtTaxpayerAddress.Text = address;
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

                case frmAddRealProperties:
                    InitializeRealProperties();
                    break;

                default:
                    break;
            }

            Close();
        }
    }
}