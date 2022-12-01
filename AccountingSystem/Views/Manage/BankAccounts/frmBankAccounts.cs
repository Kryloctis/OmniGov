using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.BankAccounts
{
    public partial class frmBankAccounts : Form
    {
        public frmBankAccounts()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgBankAccounts, true, true);
        }

        private void frmBankAccounts_Load(object sender, EventArgs e)
        {
            var dtBankAccount = AccFactory.BankAccountsRepository().GetRecords();
            HelperLoadRecords.DatagridViewBankAccounts(dtBankAccount, dgBankAccounts);
        }

        internal void LoadBankAccounts()
        { 
            
        }
         
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddBankAccounts(this).ShowDialog();
        }

    }
}
