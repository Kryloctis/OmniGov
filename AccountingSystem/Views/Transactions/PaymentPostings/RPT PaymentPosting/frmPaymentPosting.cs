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
    public partial class frmPaymentPosting : Form
    {
        private readonly frmTaxPayerList _frmTaxPayerList;
        private readonly PaymentTaxPayerInfo _paymentTaxPayerInfo;

        public frmPaymentPosting(PaymentTaxPayerInfo paymentTaxPayerInfo, frmTaxPayerList frmTaxPayerList)
        {
            InitializeComponent();
            _paymentTaxPayerInfo = paymentTaxPayerInfo;
            _frmTaxPayerList = frmTaxPayerList;
            Helper.LoadFormIcon(this);
        }

        public class PaymentTaxPayerInfo
        {
            #region Taxpayer info

            public string TIN { get; set; }
            public string TaxPayerName { get; set; }
            public string BarangayName { get; set; }
            public string MunicipalityName { get; set; }
            public string ProvinceName { get; set; }
            public string Address { get; set; } 
            #endregion
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            _ = new frmTaxPayerPaymentHistory(this).ShowDialog();
        }

        private void btnGetTaxDue_Click(object sender, EventArgs e)
        {
            _ = new frmRptTaxDue(this).ShowDialog();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            _ = new frmRptTaxPayment(this).ShowDialog();
        }

        private void LoadTaxPayerValues()
        {
            txtTin.Text = _paymentTaxPayerInfo.TIN;
            txtTaxpayer.Text = _paymentTaxPayerInfo.TaxPayerName;
            txtBarangay.Text = _paymentTaxPayerInfo.BarangayName;
            txtMunicipality.Text = _paymentTaxPayerInfo.MunicipalityName;
            txtProvince.Text = _paymentTaxPayerInfo.ProvinceName;
            txtAddress.Text = _paymentTaxPayerInfo.Address;
        }

        private void frmPaymentPosting_Load(object sender, EventArgs e)
        {
            LoadTaxPayerValues();
        }
    }
}
