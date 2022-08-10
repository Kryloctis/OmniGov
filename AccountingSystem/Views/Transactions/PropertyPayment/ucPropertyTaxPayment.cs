using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.PropertyPayment
{
    public partial class ucPropertyTaxPayment : UserControl
    {
        private readonly string accountableFormNo = "56";

        public ucPropertyTaxPayment()
        {
            InitializeComponent();
        }

        private string GetAccountableFormData(string columName)
        {
            var dictAccForm = AccFactory.AccountableFormsRepository().GetRecordByAccFormNo(accountableFormNo);

            if (dictAccForm.Values.Count < 1)
                return string.Empty;

            return dictAccForm[columName];
        }

        internal void LoadAccountableForm() 
        {
            try
            {
                txtAccountableForm.Text = $"{accountableFormNo} - {GetAccountableFormData("acc_form_desc")}";
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private DataTable DataTableRecieptNos() 
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("receipt_no");

            int collectorId;

            var dictJobOrderRepo = AccFactory.CollectingOfficerHasJobOrdersRepository().GetViewRecordByJobOrderUserId(Helper.UserId);
            var dictCollectingOfficerRepo = AccFactory.CollectingOfficerRepository().GetRecordByUserID(Helper.UserId);

            if (dictJobOrderRepo.Values.Count > 1)
                collectorId = Convert.ToInt32(dictJobOrderRepo["job_orders_id"]);
            else
                collectorId = Convert.ToInt32(dictCollectingOfficerRepo["id"]);


            var dtReceiptsIssued = AccFactory.ReceiptsIssuedRepository().GetIssuedReceiptToCollector(collectorId, 9);


            foreach (DataRow row in dtReceiptsIssued.Rows)
            {
                int receiptIssuedFrom = Convert.ToInt32(row["receipt_issued_from"]);
                int receiptIssuedTo = Convert.ToInt32(row["receipt_issued_to"]);

                for (int i = receiptIssuedFrom; i <= receiptIssuedTo; i++)
                {
                    bool receiptNoExist = AccFactory.PaymentCollectionRepository().ReceiptExist(i.ToString(), 9);
                   
                    if(!receiptNoExist)
                        dataTable.Rows.Add(i);
                }
            }

            return dataTable;
        }

        internal void loadreceiptnos()
        {
            try
            {
                var autocompletesource = new AutoCompleteStringCollection();

                foreach (DataRow row in DataTableRecieptNos().Rows)
                {
                    string receipt = row["receipt_no"].ToString();

                    autocompletesource.Add(receipt);
                }

                txtReceipts.AutoCompleteCustomSource = autocompletesource;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadCollectorInfo() 
        {
            try
            {
                txtCollectingOfficer.Text = Helper.LoggedInUserData()["user_full_name"];

                bool isJobOrder = AccFactory.JobOrderRepository().IsUserJobOrder(Helper.UserId);
                chckBxJobOrder.Checked = isJobOrder;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void ucPropertyTaxPayment_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadAccountableForm();
                LoadCollectorInfo();
                loadreceiptnos();
            }
        }


        private void chckBxJobOrders_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void txtReceipts_TextChanged(object sender, EventArgs e)
        {

        }

        private bool ValidateReceipts(ErrorProvider errorProvider, TextBox textBox) 
        {
            try
            {
                if (Helper.ShowErrorTextBoxEmpty(errorProvider, textBox, "Receipt No."))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return true;
        }

        private void txtReceipts_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = ValidateReceipts(errorProvider1, txtReceipts);
        }

        private void txtReceipts_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtReceipts);
        }

        private void txtPayee_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtPayee, "Payee");
        }

        private void txtPayee_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtPayee);
        }
    }
}
