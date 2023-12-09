using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Dialogs;
using AccountingSystem.Views.Transactions.Payments.OtherPayments.CattleTransferOfOwnership;
using AccountingSystem.Views.Transactions.Payments.RealProperty;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments
{
    public partial class frmRptPayments : Form
    {
        private ucRptTaxDues ucRptTaxDues;
        private ucPayment ucPayment;
        private dialogPayment dialog = new dialogPayment();
        private bool paymentComplete = false;

        public frmRptPayments()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgTaxpayers, true);
            ucRptTaxDues = ucRptTaxDues1;
            ucPayment = ucPayment1;
        }

        private DataColumn[] TaxpayersColumns()
        {
            return new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("tin", typeof(string)),
                new DataColumn("name", typeof(string)),
                new DataColumn("full_address", typeof(string)),
                new DataColumn("contact_info", typeof(string))
            };
        }

        private DataTable DataTableTaxpayers()
        {
            string searchText = txtTaxpayerSearch.Text.Trim();
            var dtTaxpayers = AccFactory.TaxpayersRepository().GetRecordsBySearch(searchText);
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(TaxpayersColumns());

            foreach (DataRow row in dtTaxpayers.Rows)
            {
                var newRow = dataTable.NewRow();
                newRow["id"] = row["id"];
                newRow["tin"] = row["tin"];
                newRow["name"] = row["name"];
                newRow["full_address"] = Helper.GenerateFullAddress(row["street"].ToString(), row["barangay"].ToString(), row["municipality"].ToString(), row["province"].ToString());
                newRow["contact_info"] = row["contact_info"];
                dataTable.Rows.Add(newRow);
            }

            return dataTable;
        }

        private void LoadTaxpayers()
        {
            HelperLoadRecords.DataGridViewPaymentTaxpayers(dgTaxpayers, DataTableTaxpayers());
            dgTaxpayers.CurrentCell = dgTaxpayers.FirstDisplayedCell;
        }

        private void LoadPaymentTab()
        {
            if (!ucRptTaxDues.ValidateChildren())
            {
                Helper.MessageBoxError(ucRptTaxDues.GetFormErrors());
                return;
            }

            decimal totalPayment = ucRptTaxDues.GetTotalTaxDue();
            ucPayment.txtPayee.Text = GetTaxPayerData()["taxpayer_name"];
            ucPayment.OnLoad("56", totalPayment);
            tabControl1.SelectedTab = tabPagePayment;
        }

        private void ConfirmPayment()
        {
            try
            {
                if (!ucPayment.ValidateChildren())
                {
                    Helper.MessageBoxError(ucPayment.GetFormErrors());
                    return;
                }

                if (!Helper.MessageBoxConfirmCancel("Are you sure to confirm the payment?"))
                    return;

                backgroundWorker1.RunWorkerAsync();
                dialog.ShowDialog();
                dialog.Text = "Processing Payment...";
                dialog.label1.Text = "Processing Payment...";
            }
            catch (Exception ex)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Transaction cancelled");
                sb.AppendLine(ex.Message);
                Helper.MessageBoxError(sb.ToString());
            }
        }

        private Dictionary<string, string> GetTaxPayerData()
        {
            var dict = new Dictionary<string, string>();
            int rowIndex = dgTaxpayers.CurrentRow.Index;
            int taxpayerId = Convert.ToInt32(dgTaxpayers.Rows[rowIndex].Cells["id"].Value);
            string taxpayarName = dgTaxpayers.Rows[rowIndex].Cells["name"].Value.ToString();

            dict.Add("taxpayer_id", taxpayerId.ToString());
            dict.Add("taxpayer_name", taxpayarName);
            return dict;
        }

        private void LoadTaxDuesTab()
        {
            if (GetTaxPayerData().Count < 1)
                return;

            int taxpayerId = Convert.ToInt32(GetTaxPayerData()["taxpayer_id"]);

            tabControl1.SelectedTab = tabPageTaxDues;
            ucRptTaxDues.taxpayersId = taxpayerId;
            ucRptTaxDues.LoadPostedProperties();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabPageTaxpayer)
                    LoadTaxDuesTab();
                else if (tabControl1.SelectedTab == tabPageTaxDues)
                    LoadPaymentTab();
                else if (paymentComplete)
                {
                    tabControl1.SelectedTab = tabPageTaxpayer;
                    paymentComplete = false;
                    return;
                }
                else if (tabControl1.SelectedTab == tabPagePayment)
                    ConfirmPayment();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void newFormPayments_Load(object sender, EventArgs e)
        {
            LoadTaxpayers();
            EnableDisableButtons();
        }

        private void tabPageTaxpayer_Enter(object sender, EventArgs e)
        {
            try
            {
                btnNext.Text = "Next";
                radTaxpayer.Checked = true;
                EnableDisableButtons();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tabPageTaxDues_Enter(object sender, EventArgs e)
        {
            try
            {
                btnNext.Text = "Proceed to Payment";
                radTaxDues.Checked = true;
                EnableDisableButtons();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tabPagePayment_Enter(object sender, EventArgs e)
        {
            try
            {
                btnNext.Text = "Confirm Payment";
                radPayment.Checked = true;
                ucPayment.Enabled = true;
                EnableDisableButtons();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void EnableDisableButtons()
        {
            if (tabControl1.SelectedIndex < 1)
                btnBack.Enabled = false;
            else
                btnBack.Enabled = true;

            if (dgTaxpayers.SelectedRows.Count < 1)
                btnNext.Enabled = false;
            else
                btnNext.Enabled = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex < 0)
                return;

            tabControl1.SelectedIndex = tabControl1.SelectedIndex - 1;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                EnableDisableButtons();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtTaxpayerSearch_TextChanged(object sender, EventArgs e)
        {
            LoadTaxpayers();
        }

        #region Save Payment

        private bool SaveRptPayment(PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, PaymentCollectionsModel paymentCollectionsModel, RptPaymentsModel rptPaymentsModel, List<RptTaxDuesModel> rptTaxDuesModels)
        {
            return AccFactory.PaymentCollectionsRepository().InsertWithRptPayment(paymentCollectionHasChequesModel, paymentCollectionsModel, rptPaymentsModel, rptTaxDuesModels);
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int totalProgress = ucPayment.dgCheques.Rows.Count;
            int progressCount = 0;
            var paymentCollectionHasChequesModel = new PaymentCollectionHasChequesModel();

            //rptPayments Model
            var rptPaymentsModel = new RptPaymentsModel();

            rptPaymentsModel.PostedBy = Helper.UserId;

            var chequesModels = new List<ChequesModel>();
            try
            {
                foreach (DataGridViewRow row in ucPayment.dgCheques.Rows)
                {
                    string bankAccountNo = row.Cells["bank_account_no"].Value.ToString();
                    string bankName = row.Cells["bank_name"].Value.ToString();
                    var rowBankBranch = row.Cells["bank_branch"].Value;
                    string bankBranch = rowBankBranch == null ? string.Empty : rowBankBranch.ToString();
                    decimal chequeAmount = Convert.ToDecimal(row.Cells["cheque_amount"].Value);
                    DateTime chequeDate = Convert.ToDateTime(row.Cells["cheque_date"].Value);
                    string chequeNo = row.Cells["cheque_no"].Value.ToString();
                    bool bankAccountExist = AccFactory.BankAccountsRepository().bankAccountExist(bankAccountNo, bankName);

                    int bankAccountId;

                    if (!bankAccountExist)
                    {
                        //banks model
                        var banksModel = new BanksModel()
                        {
                            BankName = bankName,
                            BankBranch = bankBranch
                        };

                        //bank accounts model
                        var bankAccountModel = new BankAccountsModel()
                        {
                            AccountNumber = bankAccountNo,
                            banksModel = banksModel
                        };

                        AccFactory.BankAccountsRepository().InsertWithBank(bankAccountModel);
                        bankAccountId = AccFactory.BankAccountsRepository().GetLastInsertedId();
                    }
                    else
                        bankAccountId = Convert.ToInt32(AccFactory.BankAccountsRepository().GetViewRecordByAccountNoBankName(bankAccountNo, bankName)["id"]);

                    var model = new ChequesModel()
                    {
                        Amount = chequeAmount,
                        ChequeDate = chequeDate,
                        ChequeNo = chequeNo,
                        BankAccountsId = bankAccountId
                    };

                    progressCount += 1;
                    chequesModels.Add(model);
                    Helper.ProgressCounter(backgroundWorker1, totalProgress, progressCount);
                }

                paymentCollectionHasChequesModel.ChequesModels = chequesModels;

                var methodInvoker = new MethodInvoker(delegate
                {
                    SaveRptPayment(paymentCollectionHasChequesModel, ucPayment.PaymentCollectionsModel(), rptPaymentsModel, ucRptTaxDues.RptTaxDuesModelList());
                });

                Invoke(methodInvoker);
                e.Result = "complete";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            dialog.label1.Text = e.ProgressPercentage.ToString();
            dialog.btnClose.Enabled = false;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Result.ToString() == "complete")
            {
                dialog.label1.Text = "Payment Process Complete!";
                dialog.btnClose.Enabled = true;
                btnNext.Text = "Finish";
                btnBack.Enabled = false;
                paymentComplete = true;
                ucPayment.Enabled = false;
                return;
            }

            paymentComplete = false;
        }

        #endregion Save Payment
    }
}