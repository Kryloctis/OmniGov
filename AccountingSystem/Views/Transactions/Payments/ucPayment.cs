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

        private void LoadCollectingOfficer()
        {
            var dictJobOrder = AccFactory.JobOrderRepository().GetRecordByUserID(Helper.UserId);
            var dictCollectingOfficer = AccFactory.CollectingOfficerRepository().GetRecordByUserID(Helper.UserId);

            if (dictJobOrder.Count > 0)
            {
                string jobOrderFullName = Helper.GenerateFullName(dictJobOrder["prefix"], dictJobOrder["first_name"], dictJobOrder["mid_initial"], dictJobOrder["last_name"], dictJobOrder["suffix"]);
                txtCollectingOfficer.Text = jobOrderFullName;
            }
            else if (dictCollectingOfficer.Count > 0)
            {
                string collectingOfficerName = Helper.GenerateFullName(dictCollectingOfficer["prefix"], dictCollectingOfficer["first_name"], dictCollectingOfficer["mid_initial"], dictCollectingOfficer["last_name"], dictCollectingOfficer["suffix"]);
                txtCollectingOfficer.Text = collectingOfficerName;
            }
        }

        private void LoadReceipts(int collectorId, bool isCollectorJO) 
        {


        }

        internal void OnLoad() 
        {
            try
            {
                lblTotalPayment.Text = amountPayment.ToString("N2");
                LoadCollectingOfficer();
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
