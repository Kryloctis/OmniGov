using ACC.Domain.Interfaces;
using AccountingSystem.Views.Transactions.BankDeposits.Find;
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
        internal int userid = 0;
        public ucBD()
        {
            InitializeComponent();
        }
        internal string GetFormErrors()
        {
            var errorArray = new string[4];
            errorArray[0] = errorProvider.GetError(txtbank);
            errorArray[1] = errorProvider.GetError(txtreference);
            errorArray[2] = errorProvider.GetError(dtdate);
            errorArray[3] = errorProvider.GetError(txtamount);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }
        private void ucBD_Load(object sender, EventArgs e)
        {

        }

        internal void ResetForm()
        {
            bankId = 0;
            txtbank.Clear();
            txtreference.Clear();
            dtdate.Value = DateTime.Now;
            txtamount.Value = Convert.ToDecimal("0.00");
        }

        internal void setSelectedValue(int Id, string table)
        {
            try
            {
                if (!string.IsNullOrEmpty(table) || Id > 0)
                {
                    if (table.Equals("banks"))
                    {
                        var bankRepository = Factory.BanksRepository();
                        var bankData = bankRepository.GetRecordByID(Id);
                        bankId = Id;
                        txtbank.Text = String.Format("{0} - {1}", bankData["account_no"], bankData["bank_name"]);
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        public void loadSelectedBank(int Id, string value)
        {
            bankId = Id;
            txtbank.Text = value;
        }

        private void btnbank_Click(object sender, EventArgs e)
        {
            _ = new frmFind(this, "banks").ShowDialog();
        }

        private void txtbank_DoubleClick(object sender, EventArgs e)
        {
            btnbank.PerformClick();
        }

        private void txtbank_Validating(object sender, CancelEventArgs e)
        {
           e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtbank, "Bank!");
        }
        private void txtbank_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtbank);
        }
        private void txtreference_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtreference, "Reference!");
        }
        private void txtreference_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtreference);
        }
    }
}
