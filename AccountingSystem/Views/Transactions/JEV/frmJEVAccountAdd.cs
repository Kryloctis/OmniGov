using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.JEV
{
    
    public partial class frmJEVAccountAdd : Form
    {
        private readonly ucJEV ucJEV;
        public frmJEVAccountAdd(ucJEV ucJEV)
        {
            InitializeComponent();
            this.ucJEV = ucJEV;
        }

        private bool AddAccount()
        {
            var uc = ucjevAccount1;
            string fppId = uc.cmbFPP.SelectedValue.ToString();
            string fppName = uc.cmbFPP.Text;
            string accountId = uc.cmbAccount.SelectedValue.ToString();
            string accountName = uc.cmbAccount.Text;
            string amount = uc.nudAmount.Value.ToString("N2");
            bool isDebit = uc.radioDebit.Checked;

            string[] dgRowDebit = new string[]
                {
                    fppId,
                    accountId,
                    "Subsidiary",
                    fppName,
                    accountName,
                    "Account Code",
                    amount,
                    "",
                };

            string[] dgRowCredit = new string[]
                {
                    fppId,
                    accountId,
                    "Subsidiary",
                    fppName,
                    $"     {accountName}",
                    "Account Code",
                    "",
                    amount,
                };

            if (isDebit)
                ucJEV.dgAccounts.Rows.Add(dgRowDebit);
            else
                ucJEV.dgAccounts.Rows.Add(dgRowCredit);

            return false;
        }

        private void frmJEVAccountAdd_Load(object sender, EventArgs e)
        {
            var uc = ucjevAccount1;
            uc.LoadFPP();
            uc.LoadGeneralLedgers();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            AddAccount();
        }
    }
}
