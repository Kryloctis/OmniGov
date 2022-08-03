using AccountingSystem.Views.Transactions.PaymentPostings.RPT_PaymentPosting;
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
        private readonly MainForm _mainForm;

        public frmPropertyPayment(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            Helper.LoadFormIcon(this);
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

        internal void GetSelectedTaxPayerInfo(PaymentTaxPayerInfo paymentTaxPayerInfo) 
        {
            txtTin.Text = paymentTaxPayerInfo.TIN;
            txtTaxpayer.Text = paymentTaxPayerInfo.TaxPayerName;
            txtBarangay.Text = paymentTaxPayerInfo.BarangayName;
            txtMunicipality.Text = paymentTaxPayerInfo.MunicipalityName;
            txtProvince.Text = paymentTaxPayerInfo.ProvinceName;
            txtAddress.Text = paymentTaxPayerInfo.Address;
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            _ = new frmTaxPayerPaymentHistory(this).ShowDialog();
        }

        private void LoadTaxPayerValues()
        {
            //txtTin.Text = _paymentTaxPayerInfo.TIN;
            //txtTaxpayer.Text = _paymentTaxPayerInfo.TaxPayerName;
            //txtBarangay.Text = _paymentTaxPayerInfo.BarangayName;
            //txtMunicipality.Text = _paymentTaxPayerInfo.MunicipalityName;
            //txtProvince.Text = _paymentTaxPayerInfo.ProvinceName;
            //txtAddress.Text = _paymentTaxPayerInfo.Address;
        }

        private void frmPaymentPosting_Load(object sender, EventArgs e)
        {
            LoadTaxPayerValues();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFindTaxPayer_Click(object sender, EventArgs e)
        {
            _ = new frmTaxPayerList(this).ShowDialog();
        }
    }
}
