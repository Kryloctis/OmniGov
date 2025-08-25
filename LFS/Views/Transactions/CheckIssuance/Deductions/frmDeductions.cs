using ACC.Data;
using LFS.Helpers;
using LFS.Views.Transactions.RCI;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace LFS.Views.Transactions.CheckIssuance.Deductions
{
    public partial class frmDeductions : Form
    {
        private readonly ucRCI _uc;
        //private DataTable dtDeductions = new();

        public frmDeductions(ucRCI uc)
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgDeductions);
            _uc = uc;
        }

        private void OnLoad()
        {
            HelperLoadRecords.RCIDeductionsDatagridview(_uc.dtDeductions, dgDeductions);
        }

        private void frmDeductions_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgDeductions.SelectedRows)
                    dgDeductions.Rows.Remove(row);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgDeductions_SelectionChanged(object sender, EventArgs e)
        {
            bool hasRowSelected = Convert.ToBoolean(dgDeductions.Rows.Count != 0);
            btnRemoveDeductions.Enabled = hasRowSelected;
            btnConfirmDeductions.Enabled = hasRowSelected;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateChildren())
                {
                    Helper.MessageBoxError(GetFormErrors());
                    return;
                }

                AddToList();
                ResetForm();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ResetForm()
        {
            txtDescription.Text = string.Empty;
            nudAmount.Value = 0;
            txtDescription.Focus();
        }

        private void AddToList()
        {
            string description = txtDescription.Text.Trim();
            decimal amount = nudAmount.Value;

            _uc.dtDeductions.Rows.Add(description, amount);
            HelperLoadRecords.RCIDeductionsDatagridview(_uc.dtDeductions, dgDeductions);
        }

        #region Validations

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                epDescription.GetError(txtDescription),
                epAmount.GetError(nudAmount)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
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

        #endregion Validations

        private void btnConfirmDeductions_Click(object sender, EventArgs e)
        {
            try
            {
                if (Helper.MessageBoxConfirmCancel("Confirm deduction/s that has been set?"))
                {
                    _uc.SetDeductionLabel();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmDeductions_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _uc.SetDeductionLabel();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}