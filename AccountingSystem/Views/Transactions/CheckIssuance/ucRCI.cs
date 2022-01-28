using ACC.Domain.Interfaces;
using AccountingSystem.Views.Transactions.CheckIssuance.Deductions;
using AccountingSystem.Views.Transactions.CheckIssuance.Obligations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.RCI
{
    public partial class ucRCI : UserControl
    {
        internal int Id = 0;
        internal int bankId = 0;
        internal int fundsId = 0;
        internal int functionId = 0;


        internal short obligationNumberCount = 0;
        internal decimal totalDeduction;

        internal DataTable dtObligations = new();

        public ucRCI()
        {
            InitializeComponent();
        }

        private void ucRCI_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadBanks();
                LoadFunds();

                cmbFPP.SelectedValueChanged -= new EventHandler(cmbFPP_SelectedValueChanged);
                LoadFPP();
                cmbFPP.SelectedValueChanged += new EventHandler(cmbFPP_SelectedValueChanged);

                dtObligations.Columns.Add("obligation_no");
            }
        }

        internal void LoadFPP()
        {
            try
            {
                cmbFPP.DroppedDown = false;
                Cursor.Current = Cursors.Default;

                if (DataTableFPP().Rows.Count == 0) return;

                var fppDict = new Dictionary<int, string>();
                foreach (DataRow item in DataTableFPP().Rows)
                {
                    int fppId = Convert.ToInt32(item["id"]);
                    string fppName = $"{item["fpp_code"]} - {item["fpp_name"]}";

                    fppDict.Add(fppId, fppName);
                }

                cmbFPP.DataSource = new BindingSource(fppDict, null);
                cmbFPP.DisplayMember = "value";
                cmbFPP.ValueMember = "key";
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }
        private DataTable DataTableFPP()
        {
            DataTable dtFPP;

            if (string.IsNullOrEmpty(cmbFPP.Text))
                dtFPP = Factory.FunctionProgramProjectRepository().GetRecords();
            else
                dtFPP = Factory.FunctionProgramProjectRepository().GetRecordsByCodeName(cmbFPP.Text);

            return dtFPP;
        }



        internal void ResetForm()
        {
            txtdvno.Clear();
            cmbfund.SelectedIndex = -1;
            bankId =fundsId=functionId=0;
            cmbbank.SelectedIndex = -1;
            txtcheckno.Clear();
            cmbFPP.SelectedIndex = -1;
            dtcheckdate.Value = DateTime.Now;
            txtpayee.Clear();
            txtnature.Clear();
            nudNetAmount.Value = Convert.ToDecimal("0.00");
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

        internal void SetSelectedValue(int Id, string table)
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
                        cmbFPP.Text = String.Format("{0} - {1}", functionData["fpp_code"], functionData["fpp_name"]);
                    }
                }

            }
            catch (Exception ex) 
            { 
                Helper.MessageBoxError(ex.Message); 
            }
        }

        public void LoadSelectedFunction(int Id,string value)
        {
            functionId = Id;
            cmbFPP.Text = value;
        }

       
        internal void cmbxFPP_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbFPP.Text))
            {
                cmbFPP.TextChanged -= new EventHandler(cmbxFPP_TextChanged);
                LoadFPP();
                cmbFPP.SelectedIndex = -1;
                cmbFPP.TextChanged += new EventHandler(cmbxFPP_TextChanged);
            }
        }

        internal void cmbFPP_SelectedValueChanged(object sender, EventArgs e)
        {
            functionId = Convert.ToInt32(cmbFPP.SelectedValue);
        }

        private void btnAddObligation_Click(object sender, EventArgs e)
        {
            _ = new frmObligations(this).ShowDialog();
        }

        private void btnAddDeductions_Click(object sender, EventArgs e)
        {
            _ = new frmDeductions(this).ShowDialog();
        }

        internal void SetObligationLabel()
        {
            obligationNumberCount = (short)dtObligations.Rows.Count;
            btnAddObligation.Text = $"({obligationNumberCount}) obligation/s added.";
        }


        #region Validations
        internal string GetFormErrors()
        {
            var errorArray = new string[10];
            errorArray[0] = epObligations.GetError(btnAddObligation);
            errorArray[1] = epDVNo.GetError(txtdvno);
            errorArray[2] = epFund.GetError(cmbfund);
            errorArray[3] = epFpp.GetError(cmbFPP);
            errorArray[4] = epBank.GetError(cmbbank);
            errorArray[5] = epCheckNo.GetError(txtcheckno);
            errorArray[6] = epCheckDate.GetError(dtcheckdate);
            errorArray[7] = epPayee.GetError(txtpayee);
            errorArray[8] = epNatureOfPayment.GetError(txtnature);
            errorArray[9] = epNetAmount.GetError(nudNetAmount);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        private void btnAddObligation_Validating(object sender, CancelEventArgs e)
        {
            obligationNumberCount = (short)dtObligations.Rows.Count;
            if (obligationNumberCount == 0)
            {
                epObligations.SetError(btnAddObligation, "Please enter an obligation number.");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }

        }

        private void btnAddObligation_Validated(object sender, EventArgs e)
        {
            epObligations.SetError(btnAddObligation, string.Empty);
        }

        private void txtdvno_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epDVNo, txtdvno, "Disbursement No.");
        }

        private void txtdvno_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epDVNo, txtdvno);
        }

        private void cmbfund_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epFund, cmbfund, "Fund.");
        }

        private void cmbfund_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epFund, cmbfund);
        }

        private void cmbbank_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epBank, cmbbank, "Bank.");
        }

        private void cmbbank_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epBank, cmbbank);
        }

        private void txtcheckno_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epCheckNo, txtcheckno, "Check No.");
        }

        private void txtcheckno_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epCheckNo, txtcheckno);
        }

        private void cmbFPP_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epFpp, cmbFPP, "fpp.");
            if (functionId <= 0)
            {
                epObligations.SetError(cmbFPP, "Please select fpp.");
                e.Cancel = true;
            }
        }

        private void cmbFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epFpp, cmbFPP);
        }

        private void txtpayee_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epPayee, txtpayee, "Payee");
        }

        private void txtpayee_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epPayee, txtpayee);
        }


        private void txtnature_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epNatureOfPayment, txtnature, "Nature of Payment");
        }

        private void txtnature_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epNatureOfPayment, txtnature);
        }

        private void txtamount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownZero(epNetAmount, nudNetAmount, "Net Amount.");
        }

        private void txtamount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epNetAmount, nudNetAmount);
        }



        #endregion


    }
}
