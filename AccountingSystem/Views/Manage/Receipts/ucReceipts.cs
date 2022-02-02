using ACC.Domain.Interfaces;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Receipts
{
    public partial class ucReceipts : UserControl
    {
        internal int receiptId = 0;
        internal int UserId = 0;
        internal int AccId = 0;
        internal int fromSerialNo = 0;
        internal int toSerialNo = 0;
        internal bool isTicket = false;

        public ucReceipts()
        {
            InitializeComponent();
        }

        internal void ResetForm()
        {
            AccId = 0;
            cmbAccountableForms.SelectedIndex = -1;
            txtReceiptNumberFrom.Text = string.Empty;
            txtReceiptNumberTo.Text = string.Empty;
            dtpReceivedDate.Value = DateTime.Now;
            txtQuantity.Text = string.Empty;
            txtRemark.Text = string.Empty;
        }

        internal void LoadForms()
        {
            try
            {
                var formRepository = Factory.AccountableRepository();
                var dtforms = formRepository.GetRecords();

                dtforms.Columns.Add("formdisplay", typeof(string), "acc_form_no + ' - ' + acc_form_desc");
                cmbAccountableForms.DataSource = dtforms;
                cmbAccountableForms.ValueMember = "id";
                cmbAccountableForms.DisplayMember = "formdisplay";
            }
            catch (Exception ex) 
            { 
                Helper.MessageBoxError(ex.Message); 
            }
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
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epAccountableForms, cmbAccountableForms, "Accountable Form!");
        }

        private void cmbforms_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epAccountableForms, cmbAccountableForms);
        }


        private void txtfrom_Validating(object sender, CancelEventArgs e)
        {
            if (isTicket == false)
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(epReceiptNumberFrom, txtReceiptNumberFrom, "Receipt Number From.");

                if (Convert.ToInt32(txtReceiptNumberFrom.Text.Trim()) <= toSerialNo || Convert.ToInt32(txtReceiptNumberFrom.Text.Trim()) <= 0)
                {
                    epReceiptNumberFrom.SetError(txtReceiptNumberFrom, "Invalid Receipt Number!");
                    e.Cancel = true;
                }
            }
        }

        private void txtfrom_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epReceiptNumberFrom, txtReceiptNumberFrom);
        }

        private void txtto_Validating(object sender, CancelEventArgs e)
        {
            if (isTicket == false)
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(epReceiptNumberTo, txtReceiptNumberTo, "Receipt Number To.");

                if (String.IsNullOrEmpty(txtReceiptNumberTo.Text.Trim()) == true)
                    return;

                if (Convert.ToInt32(txtReceiptNumberTo.Text.Trim()) <= Convert.ToInt32(txtReceiptNumberFrom.Text.Trim()))
                {
                    epReceiptNumberTo.SetError(txtReceiptNumberTo, "Invalid Receipt Number.");
                    e.Cancel = true;
                }
            }
        }

        private void txtto_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epReceiptNumberTo, txtReceiptNumberTo);
        }

        private void txtquantity_Validating(object sender, CancelEventArgs e)
        {
            bool isEmpty = Helper.ShowErrorTextBoxEmpty(epQuantity, txtQuantity, "Quantity.");
            bool isZero = txtQuantity.Text.Trim().Equals("0");

            if (isEmpty || isZero)
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
            {
                e.Handled = true;

            }
        }

        private void txtquantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtfrom_KeyUp(object sender, KeyEventArgs e)
        {
            int from = txtReceiptNumberFrom.Text.Length > 0 ? Convert.ToInt32(txtReceiptNumberFrom.Text.Trim()) : 0;
            int to = txtReceiptNumberTo.Text.Length > 0 ? Convert.ToInt32(txtReceiptNumberTo.Text.Trim()) : 0;
            //txtquantity.Text = from.Equals(1) ? ((from + to) - from).ToString() : from == to ? "1" : (to - from).ToString();
            txtQuantity.Text = (((to - from) + 1) < 0 ? 0: ((to - from) + 1)).ToString();
        }

        private void txtto_KeyUp(object sender, KeyEventArgs e)
        {
            int from = txtReceiptNumberFrom.Text.Length > 0 ? Convert.ToInt32(txtReceiptNumberFrom.Text.Trim()) : 0;
            int to = txtReceiptNumberTo.Text.Length > 0 ? Convert.ToInt32(txtReceiptNumberTo.Text.Trim()) : 0;
            txtQuantity.Text = (((to - from) + 1) < 0 ? 0 : ((to - from) + 1)).ToString();
        }

        private void cmbforms_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView item = cmbAccountableForms.SelectedItem as DataRowView;

            if (item == null)
                return;

            if (item[2].ToString().Contains("Tickets"))
            {
                isTicket = true;
                txtReceiptNumberFrom.Enabled = false;
                txtReceiptNumberTo.Enabled = false;
                txtQuantity.ReadOnly = false;

                txtReceiptNumberFrom.Text = "0";
                txtReceiptNumberTo.Text = "0";


                txtQuantity.Text = string.Empty;

            }
            else
            {
                isTicket = false;
                txtReceiptNumberFrom.Enabled = true;
                txtReceiptNumberTo.Enabled = true;
                txtQuantity.ReadOnly = true;

                var receiptsRepository = Factory.ReceiptsRepository();
                var accountableFormId = int.Parse(item[0].ToString());

                fromSerialNo = receiptsRepository.RMIN(accountableFormId);
                toSerialNo = receiptsRepository.RMAX(accountableFormId);

                txtReceiptNumberFrom.Text = (toSerialNo + 1).ToString();

                int from = txtReceiptNumberFrom.Text.Length > 0 ? Convert.ToInt32(txtReceiptNumberFrom.Text.Trim()) : 0;
                int to = txtReceiptNumberTo.Text.Length > 0 ? Convert.ToInt32(txtReceiptNumberTo.Text.Trim()) : 0;
                txtQuantity.Text = (((to - from) + 1) < 0 ? 0 : ((to - from) + 1)).ToString();
            }
        }

        private void txtfrom_TextChanged(object sender, EventArgs e)
        {
            if (!isTicket)
            {
                if (txtReceiptNumberFrom.Text.Length > 0)
                {
                    int num = int.Parse(txtReceiptNumberFrom.Text.Trim());
                    if (num > 1)
                    {
                        txtReceiptNumberFrom.Enabled = false;
                    }
                    else
                    {
                        txtReceiptNumberFrom.Enabled = true;
                    }
                }
            }
            
        }



    }
}
