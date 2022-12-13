using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RptDiscount
{
    public partial class ucRptDiscounts : UserControl
    {
        internal int rptDiscountId;
        internal bool isEdit = false;

        public ucRptDiscounts()
        {
            InitializeComponent();
        }

        private DataTable Months()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("month", typeof(int));
            dataTable.Columns.Add("month_name", typeof(string));

            dataTable.Rows.Add(1, "January");
            dataTable.Rows.Add(2, "February");
            dataTable.Rows.Add(3, "March");
            dataTable.Rows.Add(4, "April");
            dataTable.Rows.Add(5, "May");
            dataTable.Rows.Add(6, "June");
            dataTable.Rows.Add(7, "July");
            dataTable.Rows.Add(8, "August");
            dataTable.Rows.Add(9, "September");
            dataTable.Rows.Add(10, "October");
            dataTable.Rows.Add(11, "November");
            dataTable.Rows.Add(12, "December");

            return dataTable;
        }

        private void LoadMonths()
        {
            try
            {
                cmbxMonth.DataSource = Months();
                cmbxMonth.DisplayMember = "month_name";
                cmbxMonth.ValueMember = "month";
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void ResetForm()
        {
            if (isEdit)
                rptDiscountId = 0;

            LoadMonths();
            txtDescription.Clear();
            nudRate.Value = 0;
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtDescription),
                errorProvider1.GetError(nudRate)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        #region Validations

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtDescription, "Description");
        }

        private void txtDescription_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtDescription);
        }

        private bool RateValidated()
        {
            bool isValidated;

            bool isZero = Helper.ShowErrorNumericUpDownZero(errorProvider1, nudRate, "Rate");
            bool isEmpty = Helper.ShowErrorNumericUpDownEmpty(errorProvider1, nudRate, "Rate");

            if (isZero || isEmpty)
                isValidated = true;
            else
                isValidated = false;

            return isValidated;
        }

        private void nudRate_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = RateValidated();
        }

        private void nudRate_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorNumericUpDown(errorProvider1, nudRate);
        }

        #endregion Validations

        private void ucRptDiscounts_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadMonths();
            }
        }
    }
}