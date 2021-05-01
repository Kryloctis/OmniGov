using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACC.Domain.Interfaces;
using AccountingSystem.Views.Transactions.RCI.Find;

namespace AccountingSystem.Views.Transactions.RCI
{
    public partial class ucRCI : UserControl
    {
        internal int Id = 0;
        internal int bankId = 0;
        internal int fundsId = 0;
        internal int functionId = 0;
        public ucRCI()
        {
            InitializeComponent();
        }

        private void ucRCI_Load(object sender, EventArgs e)
        {

        }
        internal string GetFormErrors()
        {
            var errorArray = new string[12];
            errorArray[0] = errorProvider.GetError(txtObno);
            errorArray[1] = errorProvider.GetError(txtdvno);
            errorArray[2] = errorProvider.GetError(txtfund);
            errorArray[3] = errorProvider.GetError(txtfunction);
            errorArray[4] = errorProvider.GetError(txtbank);
            errorArray[5] = errorProvider.GetError(txtcheckno);
            errorArray[6] = errorProvider.GetError(dtcheckdate);
            errorArray[7] = errorProvider.GetError(txtpayee);
            errorArray[8] = errorProvider.GetError(txtnature);
            errorArray[9] = errorProvider.GetError(txttrust);
            errorArray[10] = errorProvider.GetError(txtvat);
            errorArray[11] = errorProvider.GetError(txtamount);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }
        internal void ResetForm()
        {
            txtObno.Clear();
            txtdvno.Clear();
            bankId=fundsId=functionId=0;
            txtfund.Clear();
            txtfunction.Clear();
            txtbank.Clear();
            txtcheckno.Clear();
            dtcheckdate.Value = DateTime.Now;
            txtpayee.Clear();
            txtnature.Clear();
            txttrust.Value = Convert.ToDecimal("0.00");
            txtvat.Value = Convert.ToDecimal("0.00");
            txtamount.Value = Convert.ToDecimal("0.00");
        }
        internal void setSelectedValue(int Id, string table)
        {
            try
            {
               if(!string.IsNullOrEmpty(table) || Id > 0)
                {
                    if (table.Equals("banks"))
                    {
                        var banksRepository = Factory.BanksRepository();
                        var bankData = banksRepository.GetRecordByID(Id);
                        bankId = Convert.ToInt16(bankData["id"]);
                        txtbank.Text = String.Format("{0} - {1}", bankData["account_no"],bankData["bank_name"]);
                    }
                    if (table.Equals("funds"))
                    {
                        var fundsRepository = Factory.FundsRepository();
                        var fundsData = fundsRepository.GetRecordByID(Id);
                        fundsId = Convert.ToInt16(fundsData["id"]);
                        txtfund.Text = String.Format("{0} - {1}", fundsData["fund_code"], fundsData["fund_name"]);
                    }
                    if (table.Equals("functions"))
                    {
                        var functionRepository = Factory.FunctionProgramProjectRepository();
                        var functionData = functionRepository.GetRecordByID(Id);
                        functionId = Convert.ToInt16(functionData["id"]);
                        txtfunction.Text = String.Format("{0} - {1}", functionData["fpp_code"], functionData["fpp_name"]);
                    }
                }

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        public void loadSelectedBank(int Id,string value)
        {
            bankId = Id;
            txtbank.Text = value;
        }

        public void loadSelectedFund(int Id, string value)
        {
            fundsId = Id;
            txtfund.Text = value;
            
        }

        public void loadSelectedFunction(int Id,string value)
        {
            functionId = Id;
            txtfunction.Text = value;
        }
        

        private void txtbank_DoubleClick(object sender, EventArgs e)
        {
            btncharge.PerformClick();
        }

        private void btncharge_Click(object sender, EventArgs e)
        {
            _ = new frmFind(this, "banks").ShowDialog();
        }

        private void txtfund_DoubleClick(object sender, EventArgs e)
        {

             btnfund.PerformClick();
        }

        private void txtfunction_DoubleClick(object sender, EventArgs e)
        {
            btnfunction.PerformClick();
        }

        private void btnfunction_Click(object sender, EventArgs e)
        {
            _ = new frmFind(this, "functions").ShowDialog();
        }

        private void btnfund_Click(object sender, EventArgs e)
        {
            _ = new frmFind(this, "funds").ShowDialog();
        }

        private void txtObno_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtObno, "obligation no.!");
        }

        private void txtdvno_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtdvno, "disbursement no.!");
        }

        private void txtfund_Validating(object sender, CancelEventArgs e)
        {
            if (!btnfund.Focused)
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtfund, "funding.!");
                if (fundsId <= 0)
                {
                    errorProvider.SetError(txtfund, "Please select funding!");
                    e.Cancel = true;
                }

            }
            else
            {
                e.Cancel = false;
            }

        }

        private void txtfunction_Validating(object sender, CancelEventArgs e)
        {
            if (!txtfunction.Focused)
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtfunction, "function.!");
                if (functionId <= 0)
                {
                    errorProvider.SetError(txtfunction, "Please select function!");
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = false;
            }
            
        }

        private void txtbank_Validating(object sender, CancelEventArgs e)
        {
            if (!txtbank.Focused)
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtbank, "bank.!");
                if (bankId <= 0)
                {
                    errorProvider.SetError(txtbank, "Please select bank account!");
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = false;
            }
           
        }

        private void txtcheckno_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtcheckno, "check no.!");
        }

        private void dtcheckdate_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void txtpayee_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtpayee, "payee.!");
        }

        private void txtnature_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtnature, "nature of payment.!");
        }

        private void txttrust_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void txtObno_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtObno);
        }

        private void txtdvno_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtdvno);
        }

        private void txtfund_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtfund);
        }

        private void txtfunction_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtfunction);
        }

        private void txtbank_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtbank);
        }

        private void txtcheckno_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtcheckno);
        }

        private void dtcheckdate_Validated(object sender, EventArgs e)
        {

        }

        private void txtpayee_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtpayee);
        }

        private void txtnature_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtnature);
        }

        private void txttrust_Validated(object sender, EventArgs e)
        {

        }
    }
}
