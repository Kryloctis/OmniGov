using AccountingSystem.Views.Transactions.PaymentPosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.PaymentPostings.RPT_PaymentPosting
{
    public partial class frmRptTaxDue : Form
    {
        private readonly frmPaymentPosting _frmPaymentPosting;
        public frmRptTaxDue(frmPaymentPosting frmPaymentPosting)
        {
            InitializeComponent();
            _frmPaymentPosting = frmPaymentPosting;
            Helper.LoadFormIcon(this);
        }
    }
}
