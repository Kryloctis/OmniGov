using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.SupplementalAppropriations
{
    public partial class ucSupplementalAppropriations : UserControl
    {
        internal bool isEdit = false;
        internal DateTime dateEntry;
        internal bool isContinuing;

        public ucSupplementalAppropriations()
        {
            InitializeComponent();
        }

        internal void LoadSelected(DateTime dateEntry, decimal amount, string remarks)
        {
            dtpDateEntry.Value = dateEntry;
            nudAmount.Value = amount;
            txtRemarks.Text = remarks;
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(nudAmount)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            LoadDateEntryMaxMin();
            nudAmount.Value = 0;
            txtRemarks.Text = string.Empty;
        }

        private void LoadDateEntryMaxMin()
        {
            if (isContinuing)
                dtpDateEntry.MaxDate = new DateTime(9998, 12, DateTime.DaysInMonth(9998, 12));
            else
                dtpDateEntry.MaxDate = new DateTime(dateEntry.Year, 12, DateTime.DaysInMonth(dateEntry.Year, 12));

            dtpDateEntry.MinDate = dateEntry;
        }

        private void LoadFields()
        {
            LoadDateEntryMaxMin();
        }

        private void ucSupplementalAppropriations_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadFields();
            }
        }

        #region Validations

        private bool AmountValidated(NumericUpDown numericUpDown, ErrorProvider errorProvider, string message)
        {
            if (numericUpDown.Value == 0)
            {
                errorProvider.SetError(numericUpDown, Helper.ErrorMessage(message));
                return false;
            }

            return true;
        }

        private void nudAmount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !AmountValidated(nudAmount, errorProvider1, "Amount.");
        }

        private void nudAmount_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudAmount);
        }

        #endregion Validations
    }
}