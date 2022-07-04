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

        internal void LoadAccountableForms()
        {
            var dtAccountableFormRepo = Factory.AccountableFormsRepository().GetRecords();
            HelperLoadRecords.AccountableFormsCombobox(cmbAccountableForms, dtAccountableFormRepo);
        }

        #region Validations

        internal string GetFormErrors()
        {
            var errorArray = new string[5];
            errorArray[0] = epAccountableForms.GetError(cmbAccountableForms);
            errorArray[1] = epReceiptNumberFrom.GetError(txtReceiptNumberFrom);
            errorArray[2] = epReceiptNumberTo.GetError(txtReceiptNumberTo);
            errorArray[3] = epReceivedDate.GetError(dtpReceivedDate);
            errorArray[4] = epQuantity.GetError(txtQuantity);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        private void cmbforms_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epAccountableForms, cmbAccountableForms, "Accountable Form.");
        }

        private void cmbforms_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAccountableForms, cmbAccountableForms);
        }

        private void txtfrom_Validating(object sender, CancelEventArgs e)
        {
            if (!isCashTicket)
                e.Cancel = Helper.ShowErrorTextBoxEmpty(epReceiptNumberFrom, txtReceiptNumberFrom, "Receipt Number From.");            
        }

        private void txtfrom_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epReceiptNumberFrom, txtReceiptNumberFrom);
        }

        private void txtto_Validating(object sender, CancelEventArgs e)
        {
            if (!isCashTicket)
                e.Cancel = Helper.ShowErrorTextBoxEmpty(epReceiptNumberTo, txtReceiptNumberTo, "Receipt Number To.");
        }

        private void txtto_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epReceiptNumberTo, txtReceiptNumberTo);
        }

        private void txtquantity_Validating(object sender, CancelEventArgs e)
        {
            bool isEmpty = Helper.ShowErrorTextBoxEmpty(epQuantity, txtQuantity, "Quantity.");
            bool isZeroOrLess = Convert.ToInt32(string.IsNullOrEmpty(txtQuantity.Text.Trim()) ? 0 : txtQuantity.Text) <= 0;

            if (isEmpty || isZeroOrLess)
            {
                epQuantity.SetError(txtQuantity, "Please enter a valid quantity.");
                e.Cancel = true;
            }
        }

        private void txtquantity_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epQuantity, txtQuantity);
        }
        #endregion

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

        private void txtfrom_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(txtReceiptNumberTo.Text.Trim()) || string.IsNullOrEmpty(txtReceiptNumberFrom.Text.Trim()))
                return;

            int from = Convert.ToInt32(txtReceiptNumberFrom.Text.Trim());
            int to = Convert.ToInt32(txtReceiptNumberTo.Text.Trim());

            txtQuantity.Text = (to - from).ToString();
        }

        private void txtto_KeyUp(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(txtReceiptNumberTo.Text.Trim()) || string.IsNullOrEmpty(txtReceiptNumberFrom.Text.Trim()))
                return;

            int from = Convert.ToInt32(txtReceiptNumberFrom.Text.Trim());
            int to = Convert.ToInt32(txtReceiptNumberTo.Text.Trim());

            txtQuantity.Text = ((to - from) + 1).ToString();
        }

        private void cmbforms_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView item = cmbAccountableForms.SelectedItem as DataRowView;

            if (item == null)
                return;

            if (item[2].ToString().Contains("Tickets"))
            {
                isCashTicket = true;
                txtReceiptNumberFrom.Enabled = false;
                txtReceiptNumberTo.Enabled = false;
                txtQuantity.ReadOnly = false;
                txtReceiptNumberFrom.ResetText();
                txtReceiptNumberTo.ResetText();
                txtQuantity.Text = string.Empty;
            }
            else
            {
                isCashTicket = false;
                txtReceiptNumberFrom.Enabled = true;
                txtReceiptNumberTo.Enabled = true;
                txtQuantity.ReadOnly = true;
                txtQuantity.Text = string.Empty;
            }
        }

        private void ucReceipts_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadAccountableForms();
            }   
        }

    }
}
