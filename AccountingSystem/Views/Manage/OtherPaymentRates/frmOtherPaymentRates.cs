using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.OtherPaymentRates
{
    public partial class frmOtherPaymentRates : Form
    {
        public frmOtherPaymentRates()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            _ = new frmAddOtherPaymentRates().ShowDialog();
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            _ = new frmEditOtherPaymentRates().ShowDialog();
        }
    }
}
