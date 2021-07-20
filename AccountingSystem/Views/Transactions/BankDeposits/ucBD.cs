using ACC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.BankDeposits
{
    public partial class ucBD : UserControl
    {
        internal int Id = 0;
        internal int bankId = 0;
        internal int fundId = 0;
        internal int userid = 0;
        public ucBD()
        {
            InitializeComponent();
        }
        internal string GetFormErrors()
        {
            var errorArray = new string[5];
            errorArray[0] = errorProvider.GetError(cmbbanks);
            errorArray[1] = errorProvider.GetError(cmbfunds);
            errorArray[2] = errorProvider.GetError(txtreference);
            errorArray[3] = errorProvider.GetError(dtdate);
            errorArray[4] = errorProvider.GetError(txtamount);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }
        private void ucBD_Load(object sender, EventArgs e)
        {

        }

        internal void ResetForm()
        {
            cmbbanks.SelectedIndex = -1;
            cmbfunds.SelectedIndex = -1;
            txtreference.Clear();
            dtdate.Value = DateTime.Now;
            txtamount.Value = Convert.ToDecimal("0.00");
        }

        internal void LoadBanks()
        {
            try
            {
                var bankRepository = Factory.BanksRepository();
                var dtBank = bankRepository.GetRecords();
                dtBank.Columns.Add("bankdetails", typeof(string), "bank_name +'-'+account_no");
                cmbbanks.DataSource = dtBank;
                cmbbanks.ValueMember = "id";
                cmbbanks.DisplayMember = "bankdetails";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadFunds()
        {
            try
            {
                var fundsRepository = Factory.FundsRepository();
                var dtfunds = fundsRepository.GetRecords();
                dtfunds.Columns.Add("funddetails", typeof(string), "fund_code +'-'+fund_name");
                cmbfunds.DataSource = dtfunds;
                cmbfunds.ValueMember = "id";
                cmbfunds.DisplayMember = "funddetails";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        } 
        private void txtreference_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtreference, "Reference!");
        }
        private void txtreference_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtreference);
        }

        private void cmbbanks_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider, cmbbanks, "Banks!");
        }

        private void cmbbanks_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider, cmbbanks);
        }

        private void cmbfunds_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider, cmbfunds, "Fund!");
        }

        private void cmbfunds_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider, cmbfunds);
        }
    }
}
