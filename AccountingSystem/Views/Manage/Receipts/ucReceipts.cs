using ACC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Receipts
{
    public partial class ucReceipts : UserControl
    {
        internal int Id = 0;
        internal int UserId = 0;
        internal int AccId = 0;
        internal int fromSerialNo = 0;
        internal int toSerialNo = 0;
        internal bool isTicket = false;
        public ucReceipts()
        {
            InitializeComponent();
        }
        internal string GetFormErrors()
        {
            var errorArray = new string[5];
            errorArray[0] = errorProvider.GetError(cmbAccountableForms);
            errorArray[1] = errorProvider.GetError(txtORFrom);
            errorArray[2] = errorProvider.GetError(txtORTo);
            errorArray[3] = errorProvider.GetError(dtpReceivedDate);
            errorArray[4] = errorProvider.GetError(txtQuantity);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }
        internal void ResetForm()
        {
            AccId = 0;
            cmbAccountableForms.SelectedIndex = -1;
            txtORFrom.Text = string.Empty;
            txtORTo.Text = string.Empty;
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

        private void cmbforms_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider, cmbAccountableForms, "Accountable Form!");
        }

        private void cmbforms_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider, cmbAccountableForms);
        }

        private void txtfrom_Validating(object sender, CancelEventArgs e)
        {
            if (!isTicket)
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtORFrom, "Receipt Number From!");
                if (Convert.ToInt32(txtORFrom.Text.Trim()) <= toSerialNo || Convert.ToInt32(txtORFrom.Text.Trim()) <= 0)
                {
                    errorProvider.SetError(txtORFrom, "Invalid Receipt Number!");
                    e.Cancel = true;
                }
            }
        }

        private void txtfrom_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtORFrom);
        }

        private void txtto_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtORTo);
        }

        private void txtto_Validating(object sender, CancelEventArgs e)
        {
            if (!isTicket)
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtORTo, "Receipt Number To!");
            }
            
        }

        private void txtquantity_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtQuantity, "Quantity!");
        }

        private void txtquantity_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtQuantity);
        }

        private void txtfrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
               
            }
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
            int from = txtORFrom.Text.Length > 0 ? Convert.ToInt32(txtORFrom.Text.Trim()) : 0;
            int to = txtORTo.Text.Length > 0 ? Convert.ToInt32(txtORTo.Text.Trim()) : 0;
            //txtquantity.Text = from.Equals(1) ? ((from + to) - from).ToString() : from == to ? "1" : (to - from).ToString();
            txtQuantity.Text = (((to - from) + 1) < 0 ? 0: ((to - from) + 1)).ToString();
        }

        private void txtto_KeyUp(object sender, KeyEventArgs e)
        {
            int from = txtORFrom.Text.Length > 0 ? Convert.ToInt32(txtORFrom.Text.Trim()) : 0;
            int to = txtORTo.Text.Length > 0 ? Convert.ToInt32(txtORTo.Text.Trim()) : 0;
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
                txtORFrom.Enabled = false;
                txtORTo.Enabled = false;
                txtQuantity.ReadOnly = false;

                txtORFrom.Text = "0";
                txtORTo.Text = "0";


                txtQuantity.Text = string.Empty;

            }
            else
            {
                isTicket = false;
                txtORFrom.Enabled = true;
                txtORTo.Enabled = true;
                txtQuantity.ReadOnly = true;

                var receiptsRepository = Factory.ReceiptsRepository();
                var accountableFormId = int.Parse(item[0].ToString());

                fromSerialNo = receiptsRepository.RMIN(accountableFormId);
                toSerialNo = receiptsRepository.RMAX(accountableFormId);

                txtORFrom.Text = (toSerialNo + 1).ToString();

                int from = txtORFrom.Text.Length > 0 ? Convert.ToInt32(txtORFrom.Text.Trim()) : 0;
                int to = txtORTo.Text.Length > 0 ? Convert.ToInt32(txtORTo.Text.Trim()) : 0;
                txtQuantity.Text = (((to - from) + 1) < 0 ? 0 : ((to - from) + 1)).ToString();
            }
        }

        private void txtfrom_TextChanged(object sender, EventArgs e)
        {
            if (!isTicket)
            {
                if (txtORFrom.Text.Length > 0)
                {
                    int num = int.Parse(txtORFrom.Text.Trim());
                    if (num > 1)
                    {
                        txtORFrom.Enabled = false;
                    }
                    else
                    {
                        txtORFrom.Enabled = true;
                    }
                }
            }
            
        }

    }
}
