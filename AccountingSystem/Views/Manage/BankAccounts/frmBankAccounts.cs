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
            LoadBankAccounts();
        }

        internal void LoadBankAccounts()
        {
            var keySearch = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keySearch))
                return; 

            var dtBankAccount = AccFactory.BankAccountsRepository().GetRecords();
            HelperLoadRecords.DatagridViewBankAccounts(dtBankAccount, dgBankAccounts);
        }
         
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddBankAccounts(this).ShowDialog();
        }

        private void dgBankAccounts_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgBankAccounts, btnEdit, btnDelete);   
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            LoadBankAccounts();
        }
    }
}
