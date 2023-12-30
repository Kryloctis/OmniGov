using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace AccountingSystem.Views.Transactions.Payments
{
    public partial class ucPayment : UserControl
    {
        private decimal totalPaymentAmount;
        private int userId;

        public ucPayment()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgCheques, false, false, true);
        }

        internal PaymentCollectionsModel PaymentCollectionsModel()
        {
            var paymentCollectionsModel = new PaymentCollectionsModel();
            int accFormId = Convert.ToInt32(cmbxAccountableForm.SelectedValue);

            paymentCollectionsModel.CollectingOfficerId = GetCollectorInfo().CollectingOfficerId;
            paymentCollectionsModel.JobOrderId = GetCollectorInfo().JobOrderId;
            paymentCollectionsModel.AccountableFormId = accFormId;
            paymentCollectionsModel.Amount = totalPaymentAmount;
            paymentCollectionsModel.Payee = txtPayee.Text;
            paymentCollectionsModel.ReceiptNo = txtReceipts.Text.Trim();
            paymentCollectionsModel.PaymentDate = dtPaymentDate.Value;
            paymentCollectionsModel.CreatedBy = userId;

            return paymentCollectionsModel;
        }

        private (int? JobOrderId, int CollectingOfficerId, bool isCollector) GetCollectorInfo()
        {
            bool isUserCollectingOfficer = AccFactory.CollectingOfficerRepository().IsUserCollectingOfficer(userId);
            bool isUserJobOrder = AccFactory.JobOrderRepository().IsUserJobOrder(userId);

            if (isUserJobOrder)
            {
                var dictJobOrder = AccFactory.JobOrderRepository().GetRecordByUserID(userId);
                if (int.TryParse(dictJobOrder.GetValueOrDefault("id"), out int jobOrderId))
                {
                    var collectingOfficerId = AccFactory.CollectingOfficerHasJobOrdersRepository().GetCollectingOfficerIDByJobOrderId(jobOrderId);
                    return (jobOrderId, collectingOfficerId, true);
                }
            }
            else if (isUserCollectingOfficer)
            {
                var dictCollectingOfficer = AccFactory.CollectingOfficerRepository().GetRecordByUserID(userId);
                if (int.TryParse(dictCollectingOfficer.GetValueOrDefault("id"), out int collectingOfficerId))
                    return (null, collectingOfficerId, true);
            }

            return (null, 0, false);
        }

        internal string GetFormErrors()
        {
            var errors = new string[]
            {
                errorProvider1.GetError(txtCollectingOfficer),
                errorProvider1.GetError(cmbxAccountableForm),
                errorProvider1.GetError(txtReceipts),
                errorProvider1.GetError(txtPayee),
                dgCheques.Tag.ToString()
            };

            return AccFactory.CreateErrors(errors).GenerateErrorMessage();
        }

        internal void OnLoad(int loggedUserId, string accountableFormNo, decimal totalAmount = 0)
        {
            userId = loggedUserId;
            totalPaymentAmount = totalAmount;
            lblTotalPayment.Text = totalAmount.ToString("N2");
            CollectorValidated(errorProvider1, txtCollectingOfficer);
            PaymentMethods();
            LoadAccountableForms(accountableFormNo);
            LoadReceipts();
            LoadCheques();
            dtPaymentDate.Value = Helper.GetCurrentDate();
        }

        private void LoadAccountableForms(string accountableFormNo)
        {
            var dataColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("accountable_form", typeof(string))
            };

            var dataTable = new DataTable();
            dataTable.Columns.AddRange(dataColumns);
            var dtAccountableForm = string.IsNullOrWhiteSpace(accountableFormNo) ? AccFactory.AccountableFormsRepository().GetRecords() : AccFactory.AccountableFormsRepository().GetRecordsByAccFormNo(accountableFormNo);

            foreach (DataRow row in dtAccountableForm.Rows)
            {
                var newRow = dataTable.NewRow();
                newRow["id"] = row["id"];
                newRow["accountable_form"] = $"{row["acc_form_no"]} - {row["acc_form_desc"]}";
                dataTable.Rows.Add(newRow);
            }

            HelperLoadRecords.AccountableFormsCombobox(cmbxAccountableForm, dataTable, "id", "accountable_form");
        }

        private List<int> GetReceiptsList()
        {
            var list = new List<int>();

            if (!GetCollectorInfo().isCollector)
                return list;

            int accountableFormId = Convert.ToInt32(cmbxAccountableForm.SelectedValue);

            var dtIssuedReceipts = AccFactory.ReceiptsIssuedRepository().GetViewRecordsByCollectorId_AccFormId(GetCollectorInfo().CollectingOfficerId, accountableFormId);

            var receiptNos = new List<int>();

            foreach (DataRow row in dtIssuedReceipts.Rows)
            {
                int receiptIssuedFrom = Convert.ToInt32(row["receipt_issued_from"]);
                int receiptIssuedTo = Convert.ToInt32(row["receipt_issued_to"]);

                for (int i = receiptIssuedFrom; i < receiptIssuedTo; i++)
                    receiptNos.Add(i);
            }

            receiptNos.Sort((a, b) => a.CompareTo(b));

            var paymentCollectionReceiptsList = AccFactory.PaymentCollectionsRepository().GetRecordsReceiptsByAccFormId(accountableFormId);
            list = receiptNos.Except(paymentCollectionReceiptsList).ToList();

            return list;
        }

        private void LoadReceipts()
        {
            //Added for Autocomplete Source Collection
            var autoCompleteCollection = new AutoCompleteStringCollection();
            GetReceiptsList().ForEach(x => autoCompleteCollection.Add(x.ToString("D7")));
            txtReceipts.AutoCompleteCustomSource = autoCompleteCollection;
            string receiptNo = txtReceipts.Text = GetReceiptsList().Count < 1 ? string.Empty : GetReceiptsList()[0].ToString("D7");
        }

        private string PaymentMethods()
        {
            if (radPaymentCheque.Checked)
            {
                gpBxChequeDetails.Enabled = true;
                return "cheque";
            }
            else if (radPaymentCashCheque.Checked)
            {
                gpBxChequeDetails.Enabled = true;
                return "cash_cheque";
            }
            else
            {
                gpBxChequeDetails.Enabled = false;
                return "cash";
            }
        }

        private void radPaymentCash_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                PaymentMethods();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void radPaymentCashCheque_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                PaymentMethods();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void radPaymentCheque_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                PaymentMethods();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtReceipts_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cmbxAccountableForm_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadReceipts();
        }

        private bool CollectorValidated(ErrorProvider errorProvider, TextBox textBox)
        {
            bool isUserJobOrder = AccFactory.JobOrderRepository().IsUserJobOrder(userId);
            bool isUserCollectingOfficer = AccFactory.CollectingOfficerRepository().IsUserCollectingOfficer(userId);

            if (isUserJobOrder)
            {
                var dictJobOrder = AccFactory.JobOrderRepository().GetRecordByUserID(userId);
                bool isJobOrderCollector = AccFactory.CollectingOfficerHasJobOrdersRepository().IsJobOrderCollector(Convert.ToInt32(dictJobOrder["id"]));

                if (isJobOrderCollector)
                {
                    textBox.Text = Helper.GenerateFullName(dictJobOrder["prefix"], dictJobOrder["first_name"], dictJobOrder["mid_initial"], dictJobOrder["last_name"], dictJobOrder["suffix"]);
                    return true;
                }
            }
            else if (isUserCollectingOfficer)
            {
                var dictCO = AccFactory.CollectingOfficerRepository().GetRecordByID(userId);
                textBox.Text = Helper.GenerateFullName(dictCO["prefix"], dictCO["first_name"], dictCO["mid_initial"], dictCO["last_name"], dictCO["suffix"]);
                return true;
            }

            errorProvider.SetError(textBox, "User account ineligible for collecting officer role.");
            textBox.Clear();
            return false;
        }

        private void txtCollectingOfficer_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtCollectingOfficer);
        }

        private void txtCollectingOfficer_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !CollectorValidated(errorProvider1, txtCollectingOfficer);
        }

        private bool ReceiptNoValidated(ErrorProvider errorProvider, TextBox textBox)
        {
            if (Helper.ShowErrorTextBoxEmpty(errorProvider1, txtReceipts, "Receipt No."))
                return false;
            else
            {
                int accountableFormId = Convert.ToInt32(cmbxAccountableForm.SelectedValue);
                int receiptNo = Convert.ToInt32(txtReceipts.Text.Trim());
                bool receiptExist = AccFactory.PaymentCollectionsRepository().ReceiptExist(receiptNo, accountableFormId);

                if (!GetReceiptsList().Contains(receiptNo))
                {
                    errorProvider.SetError(textBox, "Invalid Receipt No.");
                    return false;
                }
                else if (receiptExist)
                {
                    errorProvider.SetError(textBox, "Used Receipt No.");
                    return false;
                }
                return true;
            }
        }

        private void txtPayee_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtPayee);
        }

        private void txtPayee_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtPayee, "Payee");
        }

        private void txtReceipts_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtReceipts);
        }

        private void txtReceipts_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = !ReceiptNoValidated(errorProvider1, txtReceipts);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void BtnAddCheque_Click(object sender, EventArgs e)
        {
            try
            {
                var dataTable = (DataTable)dgCheques.DataSource;
                dataTable.Rows.Add();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void DgCheques_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
        }

        private void BtnDeleteCheque_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRows = dgCheques.SelectedRows;
                if (Helper.MessageBoxConfirmDelete(selectedRows.Count))
                {
                    var dataTable = (DataTable)dgCheques.DataSource;

                    foreach (DataGridViewRow row in selectedRows)
                        dataTable.Rows.RemoveAt(row.Index);
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadCheques()
        {
            var dataTable = new DataTable();

            var dataColumns = new DataColumn[]
            {
                new DataColumn(Name = "id", typeof(int)),
                new DataColumn(Name = "cheque_no", typeof(string)),
                new DataColumn(Name = "cheque_date", typeof(DateTime)),
                new DataColumn(Name = "cheque_amount", typeof(decimal)),
                new DataColumn(Name = "bank_account_no",typeof(string)),
                new DataColumn(Name = "bank_branch", typeof(string)),
                new DataColumn(Name = "bank_name", typeof(string)),
            };

            dataTable.Columns.AddRange(dataColumns);

            HelperLoadRecords.DatagridViewPaymentCheques(dataTable, dgCheques);
            dgCheques.CurrentCell = dgCheques.FirstDisplayedCell;
        }

        private bool ChequesValidated()
        {
            if (dgCheques.Rows.Count < 1)
            {
                dgCheques.Tag = Helper.ErrorMessage("Cheque/s");
                return false;
            }

            var isValidated = new List<bool>();
            foreach (DataGridViewRow row in dgCheques.Rows)
            {
                //Validate Cheque Amount
                var rowAmount = row.Cells["cheque_amount"].Value;
                var rowChequeNo = row.Cells["cheque_no"].Value;
                var rowChequeDate = row.Cells["cheque_date"].Value;
                var rowAcountNo = row.Cells["bank_account_no"].Value;
                var rowBankName = row.Cells["bank_name"].Value;
                DateTime chequeDates = new DateTime();
                decimal amount = 0;

                if ((rowAmount == null || string.IsNullOrEmpty(rowAmount.ToString()) || !Decimal.TryParse(rowAmount.ToString(), out amount) || Convert.ToDecimal(rowAmount) < 1)
                    ||
                    (rowChequeNo == null || string.IsNullOrEmpty(rowChequeNo.ToString()))
                    ||
                    (rowAcountNo == null || string.IsNullOrEmpty(rowAcountNo.ToString()))
                    ||
                    (rowBankName == null || string.IsNullOrEmpty(rowBankName.ToString()))
                    ||
                    (rowChequeDate == null || !DateTime.TryParse(rowChequeDate.ToString(), out chequeDates)))
                {
                    dgCheques.Tag = "Invalid Input on Cheque Details.";
                    row.DefaultCellStyle.BackColor = Color.Salmon;
                    row.DefaultCellStyle.SelectionBackColor = Color.Salmon;
                    isValidated.Add(false);
                }
                else
                {
                    row.DefaultCellStyle.BackColor = DefaultBackColor;
                    row.DefaultCellStyle.SelectionBackColor = Color.SkyBlue;
                    isValidated.Add(true);
                }
            }
            return !isValidated.Contains(false);
        }

        private void dgCheques_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (PaymentMethods() == "cash")
                    return;

                e.Cancel = !ChequesValidated();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgCheques_Validated(object sender, EventArgs e)
        {
            dgCheques.Tag = string.Empty;
        }

        private void dgCheques_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                if (e.Exception is FormatException)
                {
                    // Handle format-related errors (e.g., invalid format in a cell)
                    MessageBox.Show($"Invalid {dgCheques.Columns[e.ColumnIndex].HeaderText} at row {e.RowIndex + 1}.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}