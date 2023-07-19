using ACC.Domain.Interfaces;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Receipts
{
    public partial class ucReceipts : UserControl
    {
        internal int receiptId;
        internal int accountableFormId;
        internal bool isCashTicket;

        public ucReceipts()
        {
            InitializeComponent();
        }

        internal void ResetForm()
        {
            receiptId = 0;
            accountableFormId = 0;
            isCashTicket = false;

            txtReceiptNumberFrom.Clear();
            txtReceiptNumberTo.Clear();
            dtpReceivedDate.Value = DateTime.Today;
            txtQuantity.Clear();
            txtRemark.Clear();
        }

        private DataColumn[] DataColumnAccountableForms()
        {
            return new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("accountableForm", typeof(string))
            };
        }

        private DataTable DataTableAccountableForm()
        {
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(DataColumnAccountableForms());

            var dtAccoutnableForm = AccFactory.AccountableFormsRepository().GetRecords();
            foreach (DataRow row in dtAccoutnableForm.Rows)
            {
                var newRow = dataTable.NewRow();
                newRow["id"] = row["id"];
                newRow["accountableForm"] = $"{row["acc_form_no"]} - {row["acc_form_desc"]}";
                dataTable.Rows.Add(newRow);
            }
            return dataTable;
        }

        internal void LoadAccountableForms()
        {
            HelperLoadRecords.AccountableFormsCombobox(cmbAccountableForms, DataTableAccountableForm());
        }

        #region Validations

        internal string GetFormErrors()
        {
            var errorArray = new string[5];
            errorArray[0] = errorProvider.GetError(cmbAccountableForms);
            errorArray[1] = errorProvider.GetError(txtReceiptNumberFrom);
            errorArray[2] = errorProvider.GetError(txtReceiptNumberTo);
            errorArray[3] = errorProvider.GetError(dtpReceivedDate);
            errorArray[4] = errorProvider.GetError(txtQuantity);

            IError _errors = AccFactory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        private void cmbforms_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider, cmbAccountableForms, "Accountable Form.");
        }

        private void cmbforms_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider, cmbAccountableForms);
        }

        private void txtfrom_Validating(object sender, CancelEventArgs e)
        {
            if (isCashTicket)
                return;

            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtReceiptNumberFrom, "Receipt Number From.");
        }

        private void txtfrom_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtReceiptNumberFrom);
        }

        private void txtto_Validating(object sender, CancelEventArgs e)
        {
            if (isCashTicket)
                return;

            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtReceiptNumberTo, "Receipt Number To.");
        }

        private void txtto_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtReceiptNumberTo);
        }

        private void txtquantity_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtQuantity, "Quantity.");
        }

        private void txtquantity_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtQuantity);
        }

        #endregion Validations

        #region Form Events Methods

        private void ComputeReceipQuantity()
        {
            string receiptNumberFrom = txtReceiptNumberFrom.Text;
            string receiptNumberTo = txtReceiptNumberTo.Text;

            if (string.IsNullOrEmpty(receiptNumberFrom) || string.IsNullOrEmpty(receiptNumberTo))
                return;

            var quantity = Convert.ToInt32(receiptNumberTo) - Convert.ToInt32(receiptNumberFrom) + 1;

            if (quantity >= 1)
                txtQuantity.Text = quantity.ToString();
            else
                txtQuantity.Text = string.Empty;
        }

        private void txtfrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtquantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtReceiptNumberFrom_TextChanged(object sender, EventArgs e)
        {
            ComputeReceipQuantity();
        }

        private void txtReceiptNumberTo_TextChanged(object sender, EventArgs e)
        {
            ComputeReceipQuantity();
        }

        #endregion

        private void SetFieldsForCashTickets()
        {
            isCashTicket = true;
            txtReceiptNumberFrom.Enabled = false;
            txtReceiptNumberFrom.Clear();
            txtReceiptNumberTo.Enabled = false;
            txtReceiptNumberTo.Clear();
            txtQuantity.ReadOnly = false;
        }

        private void SetFieldsForNonCashTickets()
        {
            isCashTicket = false;
            txtReceiptNumberFrom.Enabled = true;
            txtReceiptNumberTo.Enabled = true;
            txtQuantity.ReadOnly = true;
        }

        private void cmbforms_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView item = cmbAccountableForms.SelectedItem as DataRowView;
            if (item == null) return;

            if (item["accountableForm"].ToString().Contains("Tickets"))
                SetFieldsForCashTickets();
            else
                SetFieldsForNonCashTickets();
        }


        private void ucReceipts_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                try
                {
                    LoadAccountableForms();
                }
                catch (Exception ex)
                {
                    Helper.MessageBoxError(ex.Message);
                }
            }
        }


    }
}