using ACC.Domain.Interfaces;
using AccountingSystem.Views.Transactions.RCI;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.CheckIssuance.Deductions
{
    public partial class frmDeductions : Form
    {

        DataTable dtDeductions = new();


        public frmDeductions(ucRCI uc)
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgDeductions);
        }

        private void frmDeductions_Load(object sender, EventArgs e)
        {
            CreateDatagridColumn();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgDeductions.SelectedRows)
                dgDeductions.Rows.Remove(row);
        }
        private void dgDeductions_SelectionChanged(object sender, EventArgs e)
        {
            bool hasRowSelected = Convert.ToBoolean(dgDeductions.Rows.Count != 0);
            btnRemove.Enabled = hasRowSelected;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                Helper.MessageBoxError(GetFormErrors());
                return;
            }

            AddToList();
            ResetForm();
        }

        private void ResetForm()
        {
            txtDescription.Text = String.Empty;
            nudAmount.Value = 0;
            txtDescription.Focus();
        }

        private void AddToList()
        {
            dtDeductions.Rows.Add(txtDescription.Text.Trim(), nudAmount.Value);
            HelperLoadRecords.RCIDeductionsDatagridview(dtDeductions, dgDeductions);
        }

        private void CreateDatagridColumn()
        {
            dtDeductions.Columns.Add("Description");
            dtDeductions.Columns.Add("Amount");
        }

        #region Validations

        internal string GetFormErrors()
        {
            var errorArray = new string[2];
            errorArray[0] = epDescription.GetError(txtDescription);
            errorArray[1] = epAmount.GetError(nudAmount);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epDescription, txtDescription, "Description.");
        }
        private void txtDescription_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epDescription, txtDescription);
        }

        private void nudAmount_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorNumericUpDownZero(epAmount, nudAmount, "Amount.");
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }

        #endregion

  
    }
}
