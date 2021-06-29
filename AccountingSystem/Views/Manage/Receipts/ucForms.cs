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
    public partial class ucForms : UserControl
    {
        internal int Id = 0;
        internal int UserId = 0;
        internal int AccId = 0;
        public ucForms()
        {
            InitializeComponent();
        }

        private void ucForms_Load(object sender, EventArgs e)
        {

        }

        internal string GetFormErrors()
        {
            var errorArray = new string[5];
            errorArray[0] = errorProvider.GetError(cmbforms);
            errorArray[1] = errorProvider.GetError(txtfrom);
            errorArray[2] = errorProvider.GetError(txtto);
            errorArray[3] = errorProvider.GetError(dtpreceived);
            errorArray[4] = errorProvider.GetError(txtquantity);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }
        internal void ResetForm()
        {
            AccId = 0;
            cmbforms.SelectedIndex = -1;
            txtfrom.Text = string.Empty;
            txtto.Text = string.Empty;
            dtpreceived.Value = DateTime.Now;
            txtquantity.Text = string.Empty;
        }

        internal void LoadForms()
        {
            try
            {
                var formRepository = Factory.AccountableRepository();
                var dtforms = formRepository.GetRecords();
                dtforms.Columns.Add("formdisplay", typeof(string), "acc_form_no + ' - ' + acc_form_desc");
                cmbforms.DataSource = dtforms;
                cmbforms.ValueMember = "id";
                cmbforms.DisplayMember = "formdisplay";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbforms_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider, cmbforms, "Accountable Form!");
        }

        private void cmbforms_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider, cmbforms);
        }

        private void txtfrom_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtfrom, "Receipt Number From!");
        }

        private void txtfrom_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtfrom);
        }

        private void txtto_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtto);
        }

        private void txtto_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtto, "Receipt Number To!");
        }

        private void txtquantity_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtquantity, "Quantity!");
        }

        private void txtquantity_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtquantity);
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
            {
                e.Handled = true;
            }
        }

        private void txtfrom_KeyUp(object sender, KeyEventArgs e)
        {
            int from = txtfrom.Text.Length > 0 ? Convert.ToInt32(txtfrom.Text.Trim()) : 0;
            int to = txtto.Text.Length > 0 ? Convert.ToInt32(txtto.Text.Trim()) : 0;
            txtquantity.Text = from.Equals(1) ? ((from + to) - from).ToString() : (to - from).ToString();
        }

        private void txtto_KeyUp(object sender, KeyEventArgs e)
        {
            int from = txtfrom.Text.Length > 0 ? Convert.ToInt32(txtfrom.Text.Trim()) : 0;
            int to = txtto.Text.Length > 0 ? Convert.ToInt32(txtto.Text.Trim()) : 0;
            txtquantity.Text = from.Equals(1) ? ((from + to) - from).ToString() : (to - from).ToString();
        }
    }
}
