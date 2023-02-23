using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.ReleasedAndUnReleasedChecks
{
    public partial class frmReleasedAndUnreleaseChecks : Form
    {
        public frmReleasedAndUnreleaseChecks()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void frmReleasedAndUnreleaseChecks_Load(object sender, EventArgs e)
        {
            LoadBanks();
            LoadBankAccounts();
            LoadFunds();
        }


        internal void LoadBanks()
        {
            try
            {
                var bankRepository = AccFactory.BanksRepository();
                var dtBank = bankRepository.GetRecords();
                cmbxBank.DataSource = dtBank;
                cmbxBank.ValueMember = "id";
                cmbxBank.DisplayMember = "bank_name";
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }


        private void LoadBankAccounts()
        {
            int bankID = Convert.ToInt32(cmbxBank.SelectedValue);
            DataTable dtBankAccounts = AccFactory.BankAccountsRepository().GetBankAccountsByBankID(bankID);

            cmbxBankAccountNo.DataSource = dtBankAccounts;
            cmbxBankAccountNo.ValueMember = "id";
            cmbxBankAccountNo.DisplayMember = "account_no";
        }


        private void LoadFunds()
        {
            var dtFunds = AccFactory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFund, "fund_name", "id");
        }

        private void cmbxBank_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadBankAccounts();
        }
    }
}
