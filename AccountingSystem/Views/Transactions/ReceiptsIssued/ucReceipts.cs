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

namespace AccountingSystem.Views.Transactions.ReceiptsIssued
{
    public partial class ucReceipts : UserControl
    {
        internal int Id = 0;
        internal int CoId = 0;
        internal int RId = 0;
        internal int startingreceipt = 0;
        internal int maxreceipt = 0;
        public ucReceipts()
        {
            InitializeComponent();
        }

        private void ucReceipts_Load(object sender, EventArgs e)
        {

        }

        internal string GetFormErrors()
        {
            var errorArray = new string[5];
            errorArray[0] = errorProvider.GetError(cmbcollector);
            errorArray[1] = errorProvider.GetError(cmbreceipt);
            errorArray[2] = errorProvider.GetError(txtfrom);
            errorArray[3] = errorProvider.GetError(txtto);
            errorArray[4] = errorProvider.GetError(txtquantity);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            CoId = 0;
            RId = 0;
            cmbcollector.SelectedIndex = -1;
            cmbreceipt.SelectedIndex = -1;
            dtpissued.Value = DateTime.Now;
    }

        internal void LoadCollectors()
        {
            try
            {
                var collectorRepository = Factory.CollectingOfficerRepository();
                var dtCollector = collectorRepository.GetRecords();
                cmbcollector.DataSource = dtCollector;
                cmbcollector.ValueMember = "id";
                cmbcollector.DisplayMember = "fullname";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadReceipts(int id)
        {
            try
            {
                var riRepository = Factory.ReceiptsIssuedRepository();
                var dtri = riRepository.GetRecords(id);
                dtri.Columns.Add("details", typeof(string), "acc_form_no +'-'+acc_form_desc+' ('+receiptsfrom+'-'+receiptsto+')'");
                cmbreceipt.DataSource = dtri;
                cmbreceipt.ValueMember = "id";
                cmbreceipt.DisplayMember = "details";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbcollector_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider, cmbcollector);
        }

        private void cmbcollector_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider, cmbcollector, "Collecting Officer!");
        }

        private void cmbreceipt_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider, cmbreceipt);
        }

        private void cmbreceipt_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider, cmbreceipt, "Receipt!");
        }

        private void txtfrom_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtfrom);
        }

        private void txtfrom_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtfrom, "Receipt No. From!");
            if(Convert.ToInt32(txtfrom.Text.Trim()) < startingreceipt)
            {
                errorProvider.SetError(txtfrom, "Invalid Receipt Number!");
                e.Cancel = true;
            }
        }

        private void txtto_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtto);
        }

        private void txtto_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtto, "Receipt No. To!");
            if (Convert.ToInt32(txtto.Text.Trim()) > maxreceipt)
            {
                errorProvider.SetError(txtto, "Invalid Receipt Number!");
                e.Cancel = true;
            }
        }

        private void txtquantity_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtquantity);
        }

        private void txtquantity_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtquantity, "Quantity!");
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


        internal string NextReceipt(int id)
        {
            string data = string.Empty;
            try
            {
                var riRepository = Factory.ReceiptsRepository();
                var dtri2 = riRepository.FirstReceipt(id);
                var dtri = riRepository.NextReceipt(id);
                if (dtri2.Rows.Count > 0)
                {
                    int last = 0;
                    for (int i = 0; i < dtri2.Rows.Count; i++)
                    {
                        last = dtri2.Rows[i]["receiptsfrom"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(dtri2.Rows[i]["receiptsfrom"]);
                        maxreceipt = dtri2.Rows[i]["receiptsto"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(dtri2.Rows[i]["receiptsto"]);
                    }
                    startingreceipt = last;
                    data = last.ToString();
                }                
                if (dtri.Rows.Count > 0)
                {
                    int last = 0;
                    for (int i = 0; i < dtri.Rows.Count; i++)
                    {
                        last = dtri.Rows[i]["issuelast"].Equals(DBNull.Value) ? 0 : Convert.ToInt32(dtri.Rows[i]["issuelast"]);
                    }
                    startingreceipt = last + 1;
                    data = (last + 1).ToString();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            return data;
        }

        private void cmbreceipt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbreceipt.SelectedIndex != -1)
            {
                DataRowView item = cmbreceipt.SelectedItem as DataRowView;
                if(item != null)
                {
                    txtfrom.Text = NextReceipt(Convert.ToInt16(item[0]));
                }
                
            }
        }

        private void cmbcollector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbcollector.SelectedIndex != -1)
            {
                DataRowView item = cmbcollector.SelectedItem as DataRowView;
                if(item != null)
                {
                    LoadReceipts(Convert.ToInt16(item[0]));
                }
             
            }
        }
    }
}
