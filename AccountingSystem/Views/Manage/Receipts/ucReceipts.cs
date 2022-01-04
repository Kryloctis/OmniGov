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
        internal int startreceipt = 0;
        internal int maxreceipt = 0;
        internal bool istickets = false;
        public ucReceipts()
        {
            InitializeComponent();
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
            txtremarks.Text = string.Empty;
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
            if (!istickets)
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtfrom, "Receipt Number From!");
                if (Convert.ToInt32(txtfrom.Text.Trim()) <= maxreceipt || Convert.ToInt32(txtfrom.Text.Trim()) <= 0)
                {
                    errorProvider.SetError(txtfrom, "Invalid Receipt Number!");
                    e.Cancel = true;
                }
            }
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
            if (!istickets)
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtto, "Receipt Number To!");
            }
            
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
            //txtquantity.Text = from.Equals(1) ? ((from + to) - from).ToString() : from == to ? "1" : (to - from).ToString();
            txtquantity.Text = (((to - from) + 1) < 0 ? 0: ((to - from) + 1)).ToString();
        }

        private void txtto_KeyUp(object sender, KeyEventArgs e)
        {
            int from = txtfrom.Text.Length > 0 ? Convert.ToInt32(txtfrom.Text.Trim()) : 0;
            int to = txtto.Text.Length > 0 ? Convert.ToInt32(txtto.Text.Trim()) : 0;
            txtquantity.Text = (((to - from) + 1) < 0 ? 0 : ((to - from) + 1)).ToString();
        }

        private void cmbforms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbforms.SelectedIndex != -1)
            {
                DataRowView item = cmbforms.SelectedItem as DataRowView;
                if (item != null)
                {
                    if (item[2].ToString().Contains("Tickets"))
                    {
                        istickets = true;
                        txtfrom.Enabled = false;
                        txtto.Enabled = false;
                        txtquantity.ReadOnly = false;

                        txtfrom.Text = "0";
                        txtto.Text = "0";
                        txtquantity.Text = "0";
                    }
                    else
                    {
                        istickets = false;
                        txtfrom.Enabled = true;
                        txtto.Enabled = true;
                        txtquantity.ReadOnly = true;
                        var reporeceipt = Factory.ReceiptsRepository();
                        startreceipt = reporeceipt.RMIN(int.Parse(item[0].ToString()));
                        maxreceipt = reporeceipt.RMAX(int.Parse(item[0].ToString()));
                        txtfrom.Text = (maxreceipt + 1).ToString();

                        int from = txtfrom.Text.Length > 0 ? Convert.ToInt32(txtfrom.Text.Trim()) : 0;
                        int to = txtto.Text.Length > 0 ? Convert.ToInt32(txtto.Text.Trim()) : 0;
                        txtquantity.Text = (((to - from) + 1) < 0 ? 0 : ((to - from) + 1)).ToString();
                    }

                }
            }
        }

        private void txtfrom_TextChanged(object sender, EventArgs e)
        {
            if (!istickets)
            {
                if (txtfrom.Text.Length > 0)
                {
                    int num = int.Parse(txtfrom.Text.Trim());
                    if (num > 1)
                    {
                        txtfrom.Enabled = false;
                    }
                    else
                    {
                        txtfrom.Enabled = true;
                    }
                }
            }
            
        }
    }
}
