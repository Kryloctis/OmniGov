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
        public frmPaymentPosting(frmTaxPayerList frmTaxPayerList)
        {
            InitializeComponent();
            _frmTaxPayerList = frmTaxPayerList;
            Helper.LoadFormIcon(this);
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            _ = new frmTaxPayerTransactions(this).ShowDialog();
        }

        private void btnGetTaxDue_Click(object sender, EventArgs e)
        {
            _ = new frmRptTaxDue(this).ShowDialog();
        }
    }
}
