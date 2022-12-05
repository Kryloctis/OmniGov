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

    public partial class frmEditBankAccounts : Form
    {
        private frmBankAccounts _frmBankAccounts;
        private int _bankAccountID;

        public frmEditBankAccounts(frmBankAccounts frmBankAccounts, int bankAccountID)
        {
            InitializeComponent();
            _frmBankAccounts = frmBankAccounts;
            _bankAccountID = bankAccountID;
        }
    }
}
