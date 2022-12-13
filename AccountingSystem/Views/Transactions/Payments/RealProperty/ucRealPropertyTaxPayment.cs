using ACC.Domain.Interfaces;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.PropertyPayment
{
    public partial class ucRealPropertyTaxPayment : UserControl
    {
        private readonly string accountableFormNo = "56";
        internal readonly int accountableFormNoId = 9;
        internal bool isReadOnly = false;

        public ucRealPropertyTaxPayment()
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
            loadReceiptNos();
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


            var dtReceiptsIssued = AccFactory.ReceiptsIssuedRepository().GetViewIssuedReceiptToCollector(collectorId, accountableFormNoId);


            foreach (DataRow row in dtReceiptsIssued.Rows)
            {
                int receiptIssuedFrom = Convert.ToInt32(row["receipt_issued_from"]);
                int receiptIssuedTo = Convert.ToInt32(row["receipt_issued_to"]);

                for (int i = receiptIssuedFrom; i <= receiptIssuedTo; i++)
                {
                    bool receiptNoExist = AccFactory.PaymentCollectionsRepository().ReceiptExist(i.ToString(), accountableFormNoId);

                    if (!receiptNoExist)
                        dataTable.Rows.Add(i);
                }
            }

            return dataTable;
        }

        internal void loadReceiptNos()
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
                if (DataTableRecieptNos().Rows.Count > 1)
                    txtReceipts.Text = DataTableRecieptNos().Rows[0]["receipt_no"].ToString();

                //Apply autocomplete source
                txtReceipts.AutoCompleteCustomSource = autocompletesource;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadCollectorInfoById(int collectingOfficerId, string jobOrder)
        {
            bool isJobOrder = AccFactory.JobOrderRepository().IsUserJobOrder(collectingOfficerId);
            chckBxJobOrder.Checked = isJobOrder;

            if (!string.IsNullOrEmpty(jobOrder))
            {
                var dictJobOrder = AccFactory.JobOrderRepository().GetRecordByID(Convert.ToInt32(jobOrder));
                int userId = Convert.ToInt32(dictJobOrder["users_id"]);
                var userFullName = Helper.GetUserDataById(userId)["user_full_name"];

                chckBxJobOrder.Checked = true;
                txtCollectingOfficer.Text = userFullName;
            }
            else
            {
                var dictCollectingOfficer = AccFactory.CollectingOfficerRepository().GetRecordByID(collectingOfficerId);
                int userId = Convert.ToInt32(dictCollectingOfficer["users_id"]);
                var userFullName = Helper.GetUserDataById(userId)["user_full_name"];

                chckBxJobOrder.Checked = false;
                txtCollectingOfficer.Text = userFullName;
            }
        }

        internal void LoadCollectorInfoByUserId()
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
                LoadCollectorInfoByUserId();
                loadReceiptNos();
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
            if (isReadOnly)
                return;

            e.Cancel = ValidateReceipts(errorProvider1, txtReceipts);
        }

        private void txtReceipts_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtReceipts);
        }

        private void txtPayee_Validating(object sender, CancelEventArgs e)
        {
            if (isReadOnly)
                return;

            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtPayee, "Payee");
        }

        private void txtPayee_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtPayee);
        }
    }
}
