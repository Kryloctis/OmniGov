using ACC.Data;
using ACC.Domain.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace AccountingSystem.Views.Transactions.Payments
{
    public partial class ucPayment : UserControl
    {
        private decimal totalPaymentAmount;

        public ucPayment()
        {
            InitializeComponent();
        }

        internal PaymentCollectionsModel PaymentCollectionsModel()
        {
            var paymentCollectionsModel = new PaymentCollectionsModel();

            var collectingOfficerData = GetCollectingOfficerData();
            bool isJobOrder = Convert.ToBoolean(collectingOfficerData["is_job_order"]);

            paymentCollectionsModel.CollectingOfficerId = !isJobOrder ? Convert.ToInt32(collectingOfficerData["id"]) : null;
            paymentCollectionsModel.JobOrderId = isJobOrder ? Convert.ToInt32(collectingOfficerData["id"]) : null;
            paymentCollectionsModel.AccountableFormId = Convert.ToInt32(cmbxAccountableForm.SelectedValue);
            paymentCollectionsModel.Amount = totalPaymentAmount;
            paymentCollectionsModel.Payee = txtPayee.Text;
            paymentCollectionsModel.ReceiptNo = txtReceipts.Text.Trim();
            paymentCollectionsModel.PaymentDate = dtPaymentDate.Value;
            paymentCollectionsModel.CreatedBy = Helper.UserId;

            return paymentCollectionsModel;
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

        internal void OnLoad(string accountableFormNo, decimal totalAmount = 0)
        {
            totalPaymentAmount = totalAmount;
            lblTotalPayment.Text = totalAmount.ToString("N2");
            txtCollectingOfficer.Text = GetCollectingOfficerData().Count < 1 ? string.Empty : GetCollectingOfficerData()["collector_full_name"];
            PaymentMethods();
            Helper.DatagridFullRowSelectStyle(dgCheques, false, false, true);
            LoadAccountableForms(accountableFormNo);
            LoadReceipts();
            LoadCheques();
            dtPaymentDate.Value = Helper.GetCurrentDate();
        }

        private void LoadAccountableForms(string accountableForNo)
        {
            HelperLoadRecords.AccountableFormsCombobox(cmbxAccountableForm, DataTableAccountableForm(accountableForNo));
        }

        private DataColumn[] DataColumnAccountableForms()
        {
            return new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("accountableForm", typeof(string))
            };
        }

        private DataTable DataTableAccountableForm(string accountableFormNo)
        {
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(DataColumnAccountableForms());
            var dtAccountableForm = string.IsNullOrWhiteSpace(accountableFormNo) ? AccFactory.AccountableFormsRepository().GetRecords() : AccFactory.AccountableFormsRepository().GetRecordsByAccFormNo(accountableFormNo);

            foreach (DataRow row in dtAccountableForm.Rows)
            {
                var newRow = dataTable.NewRow();
                newRow["id"] = row["id"];
                newRow["accountableForm"] = $"{row["acc_form_no"]} - {row["acc_form_desc"]}";
                dataTable.Rows.Add(newRow);
            }
            cmbxAccountableForm.Enabled = true;
            return dataTable;
        }

        internal Dictionary<string, string> GetCollectingOfficerData()
        {
            var dict = new Dictionary<string, string>();
            var dictJobOrder = AccFactory.JobOrderRepository().GetRecordByUserID(Helper.UserId);
            var dictCollectingOfficer = AccFactory.CollectingOfficerRepository().GetRecordByUserID(Helper.UserId);

            if (dictJobOrder.Count > 0)
            {
                string jobOrderFullName = Helper.GenerateFullName(dictJobOrder["prefix"], dictJobOrder["first_name"], dictJobOrder["mid_initial"], dictJobOrder["last_name"], dictJobOrder["suffix"]);
                dict.Add("id", dictJobOrder["id"]);
                dict.Add("collector_full_name", jobOrderFullName);
                dict.Add("is_job_order", "true");
            }
            else if (dictCollectingOfficer.Count > 0)
            {
                string collectingOfficerName = Helper.GenerateFullName(dictCollectingOfficer["prefix"], dictCollectingOfficer["first_name"], dictCollectingOfficer["mid_initial"], dictCollectingOfficer["last_name"], dictCollectingOfficer["suffix"]);
                dict.Add("id", dictCollectingOfficer["id"]);
                dict.Add("collector_full_name", collectingOfficerName);
                dict.Add("is_job_order", "false");
            }
            return dict;
        }

        private List<int> GetReceiptsList()
        {
            var list = new List<int>();

            if (GetCollectingOfficerData().Count < 1)
                return list;

            int collectorId = Convert.ToInt32(GetCollectingOfficerData()["id"]);
            bool isCollectorJobOrder = Convert.ToBoolean(GetCollectingOfficerData()["is_job_order"]);
            int accountableFormId = Convert.ToInt32(cmbxAccountableForm.SelectedValue);

            var dtIssuedReceipts = AccFactory.ReceiptsIssuedRepository().GetViewRecordsByCollectorId_IsCollectorJo_AccountableFormId(collectorId, isCollectorJobOrder, accountableFormId);
            var receiptNos = new List<int>();

            foreach (DataRow row in dtIssuedReceipts.Rows)
            {
                int receiptIssuedFrom = Convert.ToInt32(row["receipt_issued_from"]);
                int receiptIssuedTo = Convert.ToInt32(row["receipt_issued_to"]);

                for (int i = receiptIssuedFrom; i < receiptIssuedTo; i++)
                    receiptNos.Add(i);
            }

            //Sorting Receipt No.s In Order
            receiptNos.Sort((a, b) => a.CompareTo(b));

            var paymentCollectionReceiptsList = AccFactory.PaymentCollectionsRepository().GetRecordsReceiptsByAccFormId(accountableFormId);
            list = receiptNos.Except(paymentCollectionReceiptsList).ToList();

            return list;
        }

        private void LoadReceipts()
        {
            //Added for Autocomplete Source Collection
            var autoCompleteCollection = new AutoCompleteStringCollection();
            GetReceiptsList().ForEach(x => autoCompleteCollection.Add(x.ToString("#######")));
            txtReceipts.AutoCompleteCustomSource = autoCompleteCollection;
            string receiptNo = txtReceipts.Text = GetReceiptsList().Count < 1 ? string.Empty : GetReceiptsList()[0].ToString();
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

        private DataGridViewColumn[] DatagridViewColumnsChequeDetails()
        {
            return new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn() { Name = "id", Visible = false},
                new DataGridViewTextBoxColumn() { Name = "cheque_no", HeaderText = "Cheque No." },
                new DataGridViewTextBoxColumn() { Name = "cheque_date", HeaderText = "Cheque Date"},
                new DataGridViewTextBoxColumn() { Name = "cheque_amount", HeaderText = "Amount"},
                new DataGridViewTextBoxColumn() { Name = "bank_account_no", HeaderText = "Account No."},
                new DataGridViewTextBoxColumn() { Name = "bank_branch", HeaderText = "Bank Branch"},
                new DataGridViewTextBoxColumn() { Name = "bank_name", HeaderText = "Bank Name"}
            };
        }

        private void LoadCheques()
        {
            try
            {
                dgCheques.Columns.Clear();
                dgCheques.Rows.Clear();
                dgCheques.Columns.AddRange(DatagridViewColumnsChequeDetails());
                dgCheques.CurrentCell = dgCheques.FirstDisplayedCell;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            dgCheques.Rows.Add();
        }

        private void dgCheques_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgCheques.Rows[e.RowIndex].Cells["cheque_date"].Value = "mm/dd/yyyy";
            dgCheques.Rows[e.RowIndex].Cells["cheque_amount"].Value = "0.00";
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgCheques.SelectedRows)
            {
                dgCheques.Rows.Remove(row);
            }
        }

        private void radPaymentCash_CheckedChanged(object sender, EventArgs e)
        {
            PaymentMethods();
        }

        private void radPaymentCashCheque_CheckedChanged(object sender, EventArgs e)
        {
            PaymentMethods();
        }

        private void radPaymentCheque_CheckedChanged(object sender, EventArgs e)
        {
            PaymentMethods();
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
            if (string.IsNullOrEmpty(textBox.Text.Trim()))
            {
                errorProvider.SetError(textBox, "Account logged in must be a collector, enable to proceed transaction...");
                return false;
            }

            return true;
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

        private void txtCollectingOfficer_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtCollectingOfficer);
        }

        private void txtCollectingOfficer_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !CollectorValidated(errorProvider1, txtCollectingOfficer);
        }

        private void txtPayee_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtPayee);
        }

        private void txtPayee_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtPayee, "Payee");
        }

        private void txtReceipts_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtReceipts);
        }

        private void txtReceipts_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                e.Cancel = !ReceiptNoValidated(errorProvider1, txtReceipts);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        //List of cheque details
        private bool ChequesValidated()
        {
            try
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
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            return false;
        }

        private void dgCheques_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (PaymentMethods() == "cash")
                return;

            e.Cancel = !ChequesValidated();
        }

        private void dgCheques_Validated(object sender, EventArgs e)
        {
            dgCheques.Tag = string.Empty;
        }
    }
}