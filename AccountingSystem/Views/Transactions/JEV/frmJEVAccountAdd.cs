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
            this.ucjevAccount1.fundId = ucJEV.fundId;
        }

        private bool AddAccount()
        {
            var uc = ucjevAccount1;
            string fppId = uc.cmbFPP.SelectedValue.ToString();
            string fppName = uc.cmbFPP.Text;
            string generalLedgerId = uc.cmbAccount.SelectedValue.ToString();
            string subsidiaryLedgerId = uc.cmbSubsidiary.SelectedValue.ToString();
            string generalLedgerName = uc.cmbAccount.Text;
            string amount = uc.nudAmount.Value.ToString("N2");
            bool isDebit = uc.radioDebit.Checked;
            bool? isDeposit;
            if (uc.radioDeposits.Checked)
                isDeposit = true;
            else if (uc.radioCollections.Checked)
                isDeposit = false;
            else
                isDeposit = null;

            if (isDebit)
            {
                var dgRowDebit = new object[]
                {
                    fppId,
                    generalLedgerId,
                    subsidiaryLedgerId,
                    isDebit,
                    isDeposit,
                    fppName,
                    generalLedgerName,
                    "Account Code",
                    amount,
                    "",
                };

                ucJEV.dgAccounts.Rows.Add(dgRowDebit);
            }
            else
            {
                var dgRowCredit = new object[]
                {
                    fppId,
                    generalLedgerId,
                    subsidiaryLedgerId,
                    isDebit,
                    isDeposit,
                    fppName,
                    $"     {generalLedgerName}",
                    "Account Code",
                    "",
                    amount,
                };

                ucJEV.dgAccounts.Rows.Add(dgRowCredit);
            } 

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
