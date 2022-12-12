using AccountingSystem.Views.Reports.Financial_Statements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments
{
    public partial class ucPayment : UserControl
    {
        internal decimal amountPayment = 0;
        public ucPayment()
        {
            InitializeComponent();
        }

        private void LoadAccountableForms()
        {
            var dtAccountableForm = AccFactory.AccountableFormsRepository().GetRecords();
            HelperLoadRecords.AccountableFormsCombobox(cmbxAccountableForm, dtAccountableForm);
        }

        private void ResetForm() 
        {
            amountPayment = 0;

        }

        private void LoadReceipts() 
        {

        }

        internal void OnLoad() 
        {
            try
            {
                lblTotalPayment.Text = amountPayment.ToString("N2");
                LoadAccountableForms();
                dtPaymentDate.Value = Helper.GetCurrentDate();
            }
            catch (Exception ex){Helper.MessageBoxError(ex.Message);}
        }

        private void ucPayment_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
                OnLoad();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
