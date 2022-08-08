using AccountingSystem.Views.Transactions.PaymentPostings.RPT_PaymentPosting;
using AccountingSystem.Views.Transactions.PropertyPayment;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
namespace AccountingSystem.Views.Transactions.PaymentPosting
{
    public partial class frmPropertyPayment : Form
    {
        private ucPropertyTaxPayment ucPaymentInfo;
        private readonly MainForm _mainForm;

        public frmPropertyPayment(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);
        }

        public class PaymentTaxPayerInfo
        {
            public string TIN { get; set; }
            public string TaxPayerName { get; set; }
            public string BarangayName { get; set; }
            public string MunicipalityName { get; set; }
            public string ProvinceName { get; set; }
            public string Address { get; set; }
        }

        public class RealPropertyPaymentTaxDueModel
        {
            public int AssessmentPostId {get; set;}
            public int Year { get; set; }
            public string CompleteArpNo { get; set; }
            public string TaxType { get; set; }
            public decimal TaxDue { get; set; }
            public decimal Discount { get; set; }
            public decimal Penalty { get; set; }
            public decimal TotalTaxDue { get; set; }

        }

        private DataTable RealPropertyPaymentTaxDuesDataTable(List<RealPropertyPaymentTaxDueModel> realPropertyPaymentTaxDueModelList)
        {
            var dataTable = new DataTable();
            var columns = new DataColumn[]
            {
                new DataColumn("assessment_post_id", typeof(int)),
                new DataColumn("year", typeof(int)),
                new DataColumn("complete_arp_no", typeof(string)),
                new DataColumn("tax_type", typeof(string)),
                new DataColumn("tax_due", typeof(decimal)),
                new DataColumn("discount", typeof(decimal)),
                new DataColumn("penalty", typeof(decimal)),
                new DataColumn("total_sef_basic", typeof(decimal))
            };

            dataTable.Columns.AddRange(columns);


            //Populate DataTable
            if (realPropertyPaymentTaxDueModelList != null)
            {
                foreach (RealPropertyPaymentTaxDueModel model in realPropertyPaymentTaxDueModelList)
                {
                    int assessmentPostId = model.AssessmentPostId;
                    int year = model.Year;
                    string arpNo = model.CompleteArpNo;
                    string taxType = model.TaxType;
                    decimal taxDue = model.TaxDue;
                    decimal discount = model.Discount;
                    decimal penalty = model.Penalty;
                    decimal totalSefBasic = model.TotalTaxDue;

                    dataTable.Rows.Add(assessmentPostId, year, arpNo, taxType, taxDue, discount, penalty, totalSefBasic);
                }
            }

            return dataTable;
        }

        private decimal GetTotalDue(DataGridView dataGridView)
        {
            decimal totalDue = 0;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                totalDue += Convert.ToDecimal(row.Cells["total_sef_basic"].Value);
            }

            return totalDue;
        }

        internal void LoadRealPropertyPaymentTaxDues(List<RealPropertyPaymentTaxDueModel> realPropertyPaymentTaxDueModelList)
        {
            try
            {
                HelperLoadRecords.PropertyPaymentPropertiesTaxDuesDatagridView(RealPropertyPaymentTaxDuesDataTable(realPropertyPaymentTaxDueModelList), dataGridView1);
                txtTotalDue.Text = GetTotalDue(dataGridView1).ToString("N2");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void GetSelectedTaxPayerInfo(PaymentTaxPayerInfo paymentTaxPayerInfo)
        {
            txtTin.Text = paymentTaxPayerInfo.TIN;
            txtTaxpayer.Text = paymentTaxPayerInfo.TaxPayerName;
            txtBarangay.Text = paymentTaxPayerInfo.BarangayName;
            txtMunicipality.Text = paymentTaxPayerInfo.MunicipalityName;
            txtProvince.Text = paymentTaxPayerInfo.ProvinceName;
            txtAddress.Text = paymentTaxPayerInfo.Address;
            btnGetTaxDue.Enabled = true;
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            _ = new frmTaxPayerPaymentHistory(this).ShowDialog();
        }

        private void frmPaymentPosting_Load(object sender, EventArgs e)
        {
            LoadRealPropertyPaymentTaxDues(null);
        }

        private void btnFindTaxPayer_Click(object sender, EventArgs e)
        {
            _ = new frmTaxPayerList(this).ShowDialog();
            LoadRealPropertyPaymentTaxDues(null);
        }

        private void ShowTaxDue()
        {
            string taxPayerName = txtTaxpayer.Text.Trim();

            _ = new frmPropertyTaxDue(taxPayerName, this).ShowDialog();
        }

        private void btnGetTaxDue_Click(object sender, EventArgs e)
        {
            ShowTaxDue();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        private void CancelTransaction() 
        {
            LoadRealPropertyPaymentTaxDues(null);
            ucPaymentInfo.txtPayee.Clear();
            ucPaymentInfo.txtReceiptNo.Clear();
        }

        private void btnCancelTransaction_Click(object sender, EventArgs e)
        {
           
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
       
        }
    }
}
