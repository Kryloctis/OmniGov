using OmniGov.App.Helpers;

using OmniGov.Core.Factories;

using System.ComponentModel;

namespace OmniGov.App.Views.Transactions.CheckIssuance.Deductions

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

        internal string GetFormErrors()

        {
            var errorArray = new string[]

            {
                epDescription.GetError(txtDescription),

                epAmount.GetError(nudAmount)
            };

            return Factory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private void AddToList()

        {
            string description = txtDescription.Text.Trim();

            decimal amount = nudAmount.Value;

            _uc.dtDeductions.Rows.Add(description, amount);

            HelperLoadRecords.RCIDeductionsDatagridview(_uc.dtDeductions, dgDeductions);
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

        private void btnConfirmDeductions_Click(object sender, EventArgs e)

        {
            if (Helper.MessageBoxConfirmCancel("Confirm deduction/s that has been set?"))
            {
                _uc.SetDeductionLabel();
                Close();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)

        {
            foreach (DataGridViewRow row in dgDeductions.SelectedRows)
                dgDeductions.Rows.Remove(row);
        }

        private void dgDeductions_SelectionChanged(object sender, EventArgs e)

        {
            bool hasRowSelected = Convert.ToBoolean(dgDeductions.Rows.Count != 0);

            btnRemoveDeductions.Enabled = hasRowSelected;

            btnConfirmDeductions.Enabled = hasRowSelected;
        }

        private void frmDeductions_FormClosing(object sender, FormClosingEventArgs e)

        {
            _uc.SetDeductionLabel();
        }

        private void frmDeductions_Load(object sender, EventArgs e)

        {
            OnLoad();
        }

        private void nudAmount_Validated(object sender, EventArgs e)

        {
            Helper.ClearErrorNumericUpDown(epAmount, nudAmount);
        }

        private void nudAmount_Validating(object sender, CancelEventArgs e)

        {
            e.Cancel = Helper.ShowErrorNumericUpDownZero(epAmount, nudAmount, "Amount.");
        }

        private void OnLoad()

        {
            HelperLoadRecords.RCIDeductionsDatagridview(_uc.dtDeductions, dgDeductions);
        }

        private void ResetForm()

        {
            txtDescription.Text = string.Empty;

            nudAmount.Value = 0;

            txtDescription.Focus();
        }

        private void txtDescription_Validated(object sender, EventArgs e)

        {
            Helper.ClearErrorTextBox(epDescription, txtDescription);
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)

        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(epDescription, txtDescription, "Description.");
        }
    }
}