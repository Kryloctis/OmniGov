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
            Helper.DatagridFullRowSelectStyle(dgObligationNoList, true);
        }

        private void ucRCI_Load(object sender, EventArgs e)
        {

        }
        internal string GetFormErrors()
        {
            var errorArray = new string[12];
            errorArray[0] = errorProvider.GetError(txtObno);
            errorArray[1] = errorProvider.GetError(txtdvno);
            errorArray[2] = errorProvider.GetError(cmbfund);
            errorArray[3] = errorProvider.GetError(txtfunction);
            errorArray[4] = errorProvider.GetError(cmbbank);
            errorArray[5] = errorProvider.GetError(txtcheckno);
            errorArray[6] = errorProvider.GetError(dtcheckdate);
            errorArray[7] = errorProvider.GetError(txtpayee);
            errorArray[8] = errorProvider.GetError(txtnature);
            errorArray[9] = errorProvider.GetError(txtamount);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }
        internal void ResetForm()
        {
            txtdvno.Clear();
            bankId=fundsId=functionId=0;
            cmbbank.SelectedIndex = -1;
            txtfunction.Clear();
            cmbfund.SelectedIndex = -1;
            txtcheckno.Clear();
            dtcheckdate.Value = DateTime.Now;
            txtpayee.Clear();
            txtnature.Clear();
            txtamount.Value = Convert.ToDecimal("0.00");
        }
        internal void LoadFunds()
        {
            try
            {
                var fundRepository = Factory.FundsRepository();
                var dtFund = fundRepository.GetRecords();
                dtFund.Columns.Add("funddisplay", typeof(string), "fund_code + ' - ' + fund_name");
                cmbfund.DataSource = dtFund;
                cmbfund.ValueMember = "id";
                cmbfund.DisplayMember = "funddisplay";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
        internal void LoadBanks()
        {
            try
            {
                var fundRepository = Factory.BanksRepository();
                var dtBank = fundRepository.GetRecords();
                dtBank.Columns.Add("bankdisplay", typeof(string), "bank_name + ' - ' + account_no");
                cmbbank.DataSource = dtBank;
                cmbbank.ValueMember = "id";
                cmbbank.DisplayMember = "bankdisplay";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
        internal void setSelectedValue(int Id, string table)
        {
            try
            {
               if(!string.IsNullOrEmpty(table) || Id > 0)
                {
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
        public void loadSelectedFunction(int Id,string value)
        {
            functionId = Id;
            txtfunction.Text = value;
        }
        private void btncharge_Click(object sender, EventArgs e)
        {
            _ = new frmFind(this, "banks").ShowDialog();
        }
        private void txtdvno_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtdvno, "disbursement no.");
        }

        private void txtfunction_Validating(object sender, CancelEventArgs e)
        {
            if (!txtfunction.Focused)
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtfunction, "fpp.");
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



        private void txtdvno_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtdvno);
        }

     
        private void txtfunction_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtfunction);
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
        private void cmbfund_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider, cmbfund);
        }

        private void cmbfund_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider, cmbfund, "Fund.");
        }

        private void cmbbank_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider, cmbbank);
        }

        private void cmbbank_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider, cmbbank, "Bank!");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var obligationNo = txtObno.Text.Trim();

            if (String.IsNullOrEmpty(obligationNo))
                return;

            dgObligationNoList.Rows.Add(obligationNo, "Remove");
            txtObno.Text = String.Empty;
            txtObno.Focus();
        }

        private void txtfunction_DoubleClick(object sender, EventArgs e)
        {
            _ = new frmFind(this,  "functions").ShowDialog();
        }

        private void dgObligationNoList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                int rowIndex = dgObligationNoList.CurrentCell.RowIndex;
                dgObligationNoList.Rows.RemoveAt(rowIndex);
            }
        }

        private void txtObno_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = !string.IsNullOrEmpty(txtObno.Text.Trim());
        }
    }
}
