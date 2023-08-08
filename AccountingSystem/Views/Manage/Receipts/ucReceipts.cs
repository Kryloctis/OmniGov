using ACC.Domain.Interfaces;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Receipts
{
    public partial class ucReceipts : UserControl
    {
        internal int receiptID;
        internal int accountableFormId;
        internal bool isCashTicket;

        public ucReceipts()
        {
            InitializeComponent();
        }

        internal void ResetForm()
        {
            receiptID = 0;
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

        private void cmbAccountableForms_Validating(object sender, CancelEventArgs e)
        {

            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider, cmbAccountableForms, "Accountable Form.");
        }

        private void cmbAccountableForms_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider, cmbAccountableForms);
        }

        private bool ReceiptNumberExist(int receiptNumber)
        {
            int accountableFormID = Convert.ToInt32(cmbAccountableForms.SelectedValue);

            if (receiptID == 0)
                return AccFactory.ReceiptsRepository().ReceiptNumberExist(accountableFormID, receiptNumber);
            else
                return AccFactory.ReceiptsRepository().ReceiptNumberExist(accountableFormID, receiptNumber, receiptID);
        }

        private void txtReceiptNumberFrom_Validating(object sender, CancelEventArgs e)
        {
            if (isCashTicket)
                return;

            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtReceiptNumberFrom, "Receipt Number From.");

            if (string.IsNullOrEmpty(txtReceiptNumberFrom.Text))
                return;

            int receiptNumber = Convert.ToInt32(txtReceiptNumberFrom.Text);
            if (ReceiptNumberExist(receiptNumber))
            {
                errorProvider.SetError(txtReceiptNumberFrom, "Receipt number from of this accountable form already exist.");
                e.Cancel = true;
            }
        }

        private void txtReceiptNumberFrom_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtReceiptNumberFrom);
        }

        private void txtReceiptNumberTo_Validating(object sender, CancelEventArgs e)
        {
            if (isCashTicket)
                return;

            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtReceiptNumberTo, "Receipt Number To.");
            int receiptNumber = Convert.ToInt32(txtReceiptNumberTo.Text);

            if (ReceiptNumberExist(receiptNumber))
            {
                errorProvider.SetError(txtReceiptNumberTo, "Receipt number to of this accountable form already exist.");
                e.Cancel = true;
            }
        }

        private void txtReceiptNumberTo_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtReceiptNumberTo);
        }

        private void txtQuantity_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtQuantity, "Quantity.");
        }

        private void txtQuantity_Validated(object sender, EventArgs e)
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

        private void ControlsConfiguration()
        {
            DataRowView item = cmbAccountableForms.SelectedItem as DataRowView;
            if (item == null) return;

            string accountableForm = item["accountableForm"].ToString();
            if (accountableForm.Contains("Tickets", StringComparison.InvariantCultureIgnoreCase))
                SetFieldsForCashTickets();
            else
                SetFieldsForNonCashTickets();
        }

        private void cmbforms_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ControlsConfiguration();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadAccountableForms()
        {
            HelperLoadRecords.AccountableFormsCombobox(cmbAccountableForms, DataTableAccountableForm());
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