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
    public partial class ucReceiptsIssued : UserControl
    {
        internal int Id = 0;
        internal int CoId = 0;
        internal int RId = 0;
        internal int startingreceipt = 0;
        internal int maxreceipt = 0;
        internal int maxtickets = 0;
        internal bool istickets = false;
        public ucReceiptsIssued()
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
            txtfrom.Text = string.Empty;
            txtto.Text = string.Empty;
            txtquantity.Text = string.Empty;
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

        internal void LoadCollectors(int rid)
        {
            try
            {
                var collectorRepository = Factory.CollectingOfficerRepository();
                var dtCollector = collectorRepository.GetRecords(rid);
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
                dtri.Columns.Add("details", typeof(string), "IIF(acc_form_desc LIKE '*Tickets*',acc_form_no +'-'+acc_form_desc+' ('+quantity+')',acc_form_no +'-'+acc_form_desc+' ('+receiptsfrom+'-'+receiptsto+')')");
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
           
            if (!istickets)
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtfrom, "Receipt No. From!");
                if (int.Parse(txtfrom.Text.Trim()) < startingreceipt)
                {
                    errorProvider.SetError(txtfrom, "Invalid Receipt Number!");
                    e.Cancel = true;
                }
            }
          
        }

        private void txtto_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtto);
        }

        private void txtto_Validating(object sender, CancelEventArgs e)
        {
            
            if (!istickets)
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtto, "Receipt No. To!");
                if (int.Parse(txtto.Text.Trim()) > maxreceipt)
                {

                    errorProvider.SetError(txtto, "Invalid Receipt Number!");
                    e.Cancel = true;
                }
            }
         
        }

        private void txtquantity_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider, txtquantity);
        }

        private void txtquantity_Validating(object sender, CancelEventArgs e)
        {
            if (!istickets)
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider, txtquantity, "Quantity!");
            }
            else
            {
                var quantityToIssue = int.Parse(txtquantity.Text.Trim());

                if (maxtickets == 0) { 
                    e.Cancel = false;
                    return;
                }

                if (quantityToIssue > maxtickets)
                {
                    errorProvider.SetError(txtquantity, "Invalid Quantity Number.");
                    e.Cancel = true;
                }
            }
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
            int from = txtfrom.Text.Length > 0 ? int.Parse(txtfrom.Text.Trim()) : 0;
            int to = txtto.Text.Length > 0 ? int.Parse(txtto.Text.Trim()) : 0;
            //txtquantity.Text = from.Equals(1) ? ((from + to) - from).ToString() : from==to ? "1":(to - from).ToString();
            txtquantity.Text = ((to - from) + 1).ToString();
        }

        private void txtto_KeyUp(object sender, KeyEventArgs e)
        {
            int from = txtfrom.Text.Length > 0 ? int.Parse(txtfrom.Text.Trim()) : 0;
            int to = txtto.Text.Length > 0 ? int.Parse(txtto.Text.Trim()) : 0;
            txtquantity.Text = ((to - from) + 1).ToString();
        }

        internal string NextTicket(int receiptId)
        {
            string data = string.Empty;
            try
            {
                var receiptsRepository = Factory.ReceiptsRepository();
                var receiptIssued = receiptsRepository.NextTicket(receiptId);

                int last = 0;
                int rowCount = receiptIssued.Rows.Count;

                if (rowCount > 0)
                {
                    for (int i = 0; i < rowCount; i++)
                    {
                        last = receiptIssued.Rows[i]["issuelast"].Equals(DBNull.Value) ? 0 : int.Parse(receiptIssued.Rows[i]["issuelast"].ToString());

                        maxtickets = receiptIssued.Rows[i]["quantity"].Equals(DBNull.Value) ? 0 : int.Parse(receiptIssued.Rows[i]["quantity"].ToString());
                    }

                    data = (maxtickets - last).ToString();
                }
                else
                {
                    data = 1.ToString();
                }

            }
            catch (Exception ex) { 
                Helper.MessageBoxError(ex.Message); 
            }

            return data;
        }
        internal string NextReceipt(int id)
        {
            string data = string.Empty;
            try
            {
                var riRepository = Factory.ReceiptsRepository();
                var dtri2 = riRepository.FirstReceipt(id);
                var dtri = riRepository.NextReceipt(id);
                int last = 0;
                int first = 0;               
                if (dtri.Rows.Count > 0)
                {                    
                    for (int i = 0; i < dtri.Rows.Count; i++)
                    {
                        bool returned = dtri.Rows[i]["is_returned"].Equals(DBNull.Value) ? false : true;
                        if (returned)
                        {
                            last = dtri.Rows[i]["issuelast"].Equals(DBNull.Value) ? 0 : int.Parse(dtri.Rows[i]["issuelast"].ToString());
                        }
                        else
                        {
                            last = dtri.Rows[i]["issuelast"].Equals(DBNull.Value) ? 0 : int.Parse(dtri.Rows[i]["issuelast"].ToString());
                        }                       
                    }
                    startingreceipt = last+1;
                    data = (last + 1).ToString();
                    
                }
                if (dtri2.Rows.Count > 0)
                {

                    for (int i = 0; i < dtri2.Rows.Count; i++)
                    {
                        first = dtri2.Rows[i]["receiptsfrom"].Equals(DBNull.Value) ? 0 : int.Parse(dtri2.Rows[i]["receiptsfrom"].ToString());
                        maxreceipt = dtri2.Rows[i]["receiptsto"].Equals(DBNull.Value) ? 0 : int.Parse(dtri2.Rows[i]["receiptsto"].ToString());
                    }
                    if (startingreceipt <= 0)
                    {
                        startingreceipt = first;
                        data = first.ToString();
                    }

                }

                data = startingreceipt > maxreceipt ? "0" : data;
                maxreceipt = startingreceipt > maxreceipt ? 1 : maxreceipt;
                startingreceipt = startingreceipt > maxreceipt ? 1 : startingreceipt;

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
                    var receiptId = int.Parse(item[0].ToString());

                    if (item[10].ToString().Contains("Tickets"))
                    {
                        istickets = true;
                        txtfrom.Enabled = false;
                        txtto.Enabled = false;
                        txtquantity.ReadOnly = false;

                        txtfrom.Text = "0";
                        txtto.Text = "0";
                        txtquantity.Text = NextTicket(receiptId);
                    }
                    else
                    {
                        istickets = false;
                        txtfrom.Enabled = true;
                        txtto.Enabled = true;
                        txtquantity.ReadOnly = true;
                        txtfrom.Text = NextReceipt(int.Parse(item[0].ToString()));
                    }
                    
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
                    LoadReceipts(int.Parse(item[0].ToString()));
                }
             
            }
        }

        private void txtquantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }
        }
    }
}
