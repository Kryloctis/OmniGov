using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Dialogs;
using AccountingSystem.Views.Transactions.Payments.RealProperty;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments
{
    public partial class frmPaymentRpt : Form
    {
        private readonly ucPaymentTaxpayers ucPaymentTaxpayers;
        private ucPaymentRptTaxDues ucPaymentRptTaxDues;
        private ucPayment ucPayment;
        private dialogPayment dialog = new dialogPayment();

        public frmPaymentRpt()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            ucPaymentTaxpayers = ucPaymentTaxpayers1;
            this.ucPaymentRptTaxDues = ucPaymentRptTaxDues1;
            ucPayment = ucPayment1;
        }

        private void LoadTabContents()
        {
            if (tabControlMain.SelectedIndex == 0)
                btnBackMain.Enabled = false;
            else
                btnBackMain.Enabled = true;

            switch (tabControlMain.SelectedTab.Name)
            {
                case "tabPageTaxpayer":
                    LoadTaxpayerTab();
                    break;

                case "tabPageTaxDues":
                    LoadTaxDuesTab();
                    break;

                case "tabPagePayment":
                    radPayment.Checked = true;
                    LoadPaymentTab();
                    //ConfirmPayment();
                    break;
            }
        }

        private void LoadTaxpayerTab()
        {
            radTaxpayer.Checked = true;
            btnNext.Text = "Next";
        }

        private void LoadTaxDuesTab()
        {
            radTaxDues.Checked = true;
            btnNext.Text = "Proceed to Payment";
        }

        private void LoadPaymentTab()
        {
            if (!ucPaymentRptTaxDues.ValidateChildren())
            {
                Helper.MessageBoxError(ucPaymentRptTaxDues.GetFormErrors());
                return;
            }

            radPayment.Checked = true;
            btnNext.Text = "Confirm Payment";
            decimal totalPayment = ucPaymentRptTaxDues.GetTotalTaxDue();
            ucPayment.OnLoad(Helper.UserId, "56", totalPayment);
        }

        private bool TabValidated()
        {
            switch (tabControlMain.SelectedTab.Name)
            {
                case "tabPageTaxpayer":
                    if (!ucPaymentTaxpayers.IsValidated())
                    {
                        Helper.MessageBoxError(ucPaymentTaxpayers.GetFormErrors());
                        return false;
                    }

                    int index = ucPaymentTaxpayers.dataGridView1.CurrentRow.Index;
                    int taxpayerId = Convert.ToInt32(ucPaymentTaxpayers.dataGridView1.Rows[index].Cells["taxpayers_id"].Value);
                    ucPaymentRptTaxDues.OnLoad(taxpayerId);

                    return true;

                case "tabPageTaxDues":
                    if (!ucPaymentRptTaxDues.ValidateChildren())
                    {
                        Helper.MessageBoxError(ucPaymentRptTaxDues.GetFormErrors());
                        return false;
                    }
                    return true;

                case "tabPagePayment":
                    if (!ucPayment.ValidateChildren())
                    {
                        Helper.MessageBoxError(ucPayment.GetFormErrors());
                        return false;
                    }
                    return true;

                default:
                    return true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (!TabValidated())
                    return;

                tabControlMain.SelectedIndex++;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                tabControlMain.SelectedIndex--;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

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
                    SaveRptPayment(paymentCollectionHasChequesModel, ucPayment.PaymentCollectionsModel(), rptPaymentsModel, ucPaymentRptTaxDues.RptTaxDuesModelList());
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
                btnBackMain.Enabled = false;
                ucPayment.Enabled = false;
                return;
            }
        }

        private void frmRptPayments_Load(object sender, EventArgs e)
        {
            try
            {
                LoadTabContents();
                ucPaymentTaxpayers.OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadTabContents();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}