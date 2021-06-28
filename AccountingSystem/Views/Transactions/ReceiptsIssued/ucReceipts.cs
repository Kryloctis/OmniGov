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
        public ucReceipts()
        {
            InitializeComponent();
        }

        private void ucReceipts_Load(object sender, EventArgs e)
        {

        }

        internal string GetFormErrors()
        {
            var errorArray = new string[2];
            errorArray[0] = errorProvider.GetError(cmbcollector);
            errorArray[1] = errorProvider.GetError(cmbreceipt);

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

        internal void LoadReceipts()
        {
            try
            {
                var riRepository = Factory.ReceiptsIssuedRepository();
                var dtri = riRepository.GetRecords(Convert.ToInt16(cmbcollector.SelectedValue));
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
    }
}
