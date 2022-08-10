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

namespace AccountingSystem.Views.Transactions.PropertyPayment
{
    public partial class ucPropertyTaxPayment : UserControl
    {
        private readonly string accountableFormNo = "56";
        private readonly int accountableFormNoId = 9;

        public ucPropertyTaxPayment()
        {
            InitializeComponent();
        }

        internal string GetFormErrors() 
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(txtReceipts),
                errorProvider1.GetError(txtPayee)
            };
          

            IError _errors = AccFactory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm() 
        {
            loadreceiptnos();
            txtPayee.Clear();
            dtPaymentDate.Value = Helper.GetCurrentDate();
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


            var dtReceiptsIssued = AccFactory.ReceiptsIssuedRepository().GetIssuedReceiptToCollector(collectorId, accountableFormNoId);


            foreach (DataRow row in dtReceiptsIssued.Rows)
            {
                int receiptIssuedFrom = Convert.ToInt32(row["receipt_issued_from"]);
                int receiptIssuedTo = Convert.ToInt32(row["receipt_issued_to"]);

                for (int i = receiptIssuedFrom; i <= receiptIssuedTo; i++)
                {
                    bool receiptNoExist = AccFactory.PaymentCollectionsRepository().ReceiptExist(i.ToString(), accountableFormNoId);
                   
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
                //Populate text box autocomplete source
                var autocompletesource = new AutoCompleteStringCollection();
                foreach (DataRow row in DataTableRecieptNos().Rows)
                {
                    string receipt = row["receipt_no"].ToString();

                    autocompletesource.Add(receipt);
                }

                //Get Least OR Number
                if(DataTableRecieptNos().Rows.Count > 1)
                    txtReceipts.Text = DataTableRecieptNos().Rows[0]["receipt_no"].ToString();

                //Apply autocomplete source
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


        private bool ValidateReceipts(ErrorProvider errorProvider, TextBox textBox) 
        {
            try
            {
                string receiptNo = txtReceipts.Text.Trim();
                bool receiptExist = AccFactory.PaymentCollectionsRepository().ReceiptExist(receiptNo, accountableFormNoId);
                bool receiptValid = DataTableRecieptNos().AsEnumerable().Where(c => c.Field<string>("receipt_no").Equals(receiptNo)).Count() > 0;

                if (Helper.ShowErrorTextBoxEmpty(errorProvider, textBox, "Receipt No."))
                    return true;
                else if (receiptExist)
                {
                    errorProvider.SetError(txtReceipts, "Receipt already been used to other transaction.");
                    return true;
                }
                else if (!receiptValid)
                {
                    errorProvider.SetError(txtReceipts, "Invalid Receipt No.");
                    return true;
                }
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
