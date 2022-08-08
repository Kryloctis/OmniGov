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
    public partial class frmTaxPayerPaymentHistory : Form
    {
        private readonly frmPropertyPayment _frmPaymentPosting;
        public frmTaxPayerPaymentHistory(frmPropertyPayment frmPaymentPosting)
        {
            InitializeComponent();
            _frmPaymentPosting = frmPaymentPosting;
            Helper.LoadFormIcon(this);
        }
    }
}
