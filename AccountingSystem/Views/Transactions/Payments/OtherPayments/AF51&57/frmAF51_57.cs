using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.AF51_57
{
    public partial class frmAF51_57 : Form
    {
        public frmAF51_57()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabNewPayee;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (Helper.MessageBoxConfirmCancel("Your input won't be stored."))
            {
                tabControl1.SelectedTab = tabPayeeList;
                ucTaxPayers1.ResetForm();
            }
        }
    }
}