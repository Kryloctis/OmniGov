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
    public partial class frmTaxPayerList : Form
    {
        private readonly MainForm _mainForm;
        public frmTaxPayerList(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            Helper.LoadFormIcon(this);
        }

        private void LoadTaxpayerList() 
        {
            try
            {

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message); 
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            _ = new frmPaymentPosting(this).ShowDialog();
        }
    }
}
