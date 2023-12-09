using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Dialogs;
using AccountingSystem.Views.Manage.TaxPayers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.OtherPayments.BurialPermit
{
    public partial class frmBurialPermit : Form
    {
        private readonly ucTaxPayers ucTaxPayers;
        private readonly ucPayment ucPayment;
        private readonly ucBurialPermit ucBurialPermit;
        private readonly ucPaymentFeesCharges ucOtherCharges;
        private dialogPayment dialog = new dialogPayment();
        private bool isNewPayee = false;

        public frmBurialPermit()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgPayees, true);
            ucTaxPayers = ucTaxPayers1;
            ucPayment = ucPayment1;
            ucBurialPermit = ucBurialPermit1;
            ucOtherCharges = ucBurialPermit.ucOtherCharges1;
            //ucOtherCharges.accountableForm = "58";
        }

        private void frmBurialPermit_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            string searchText = txtSearch.Text;
            LoadPayees(searchText);
            ucTaxPayers.chckIsActive.Enabled = false;
            ucOtherCharges.OnLoad();
        }

        private DataColumn[] PayeesColumns()
        {
            return new DataColumn[]
            {
                new DataColumn("taxpayers_id", typeof (int)),
                new DataColumn("taxpayer_type_code", typeof(string)),
                new DataColumn("taxpayers_tin", typeof(string)),
                new DataColumn("taxpayers_name", typeof(string)),
                new DataColumn("taxpayers_address", typeof(string)),
                new DataColumn("taxpayers_contact_info", typeof(string)),
            };
        }

        private DataTable DataTablePayees(string searchText)
        {
            var dtPayees = AccFactory.TaxpayersRepository().GetViewRecordsBySearch(searchText.Trim());
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(PayeesColumns());

            int progressCount = 0;
            int totalProgressCount = dtPayees.Rows.Count;

            foreach (DataRow row in dtPayees.Rows)
            {
                var newRow = dataTable.NewRow();
                int taxpayerId = Convert.ToInt32(row["taxpayers_id"]);
                string taxpayerTin = row["taxpayers_tin"].ToString();
                string taxpayerName = row["taxpayers_name"].ToString();
                string taxpayerTypeCode = row["taxpayer_type"].ToString();
                string street = string.IsNullOrEmpty(row["taxpayers_street"].ToString()) ? string.Empty : $"{row["taxpayers_street"]},";
                string barangay = string.IsNullOrEmpty(row["taxpayers_barangay"].ToString()) ? string.Empty : $"{row["taxpayers_barangay"]},";
                string municipality = string.IsNullOrEmpty(row["taxpayers_municipality"].ToString()) ? string.Empty : $"{row["taxpayers_municipality"]},";
                string province = string.IsNullOrEmpty(row["taxpayers_province"].ToString()) ? string.Empty : $"{row["taxpayers_province"]},";
                string taxpayerAddress = $"{street} {barangay} {municipality} {province}";
                string taxpayerContactInfo = row["taxpayers_contact_info"].ToString();

                newRow["taxpayers_id"] = taxpayerId;
                newRow["taxpayer_type_code"] = taxpayerTypeCode;
                newRow["taxpayers_tin"] = taxpayerTin;
                newRow["taxpayers_name"] = taxpayerName;
                newRow["taxpayers_address"] = taxpayerAddress;
                newRow["taxpayers_contact_info"] = taxpayerContactInfo;

                progressCount++;
                Helper.ProgressCounter(bgwPayee, totalProgressCount, progressCount);

                dataTable.Rows.Add(newRow);
            }

            return dataTable;
        }

        private void LoadPayees(string searchText)
        {
            if (!bgwPayee.IsBusy)
            {
                bgwPayee.RunWorkerAsync(searchText);
            }
        }

        private void bgwPayee_DoWork(object sender, DoWorkEventArgs e)
        {
            string searchText = e.Argument.ToString();
            var dataTable = DataTablePayees(searchText);

            Invoke((MethodInvoker)delegate
            {
                HelperLoadRecords.DatagridViewPayees(dgPayees, dataTable);
            });
        }

        private void bgwPayee_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void bgwPayee_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dgPayees.CurrentCell = dgPayees.FirstDisplayedCell;
        }

        private void ConfirmPayment()
        {
            try
            {
                if (!FormValidations())
                    return;

                if (!Helper.MessageBoxConfirmCancel("Are you sure to confirm the payment?"))
                    return;

                bgwSavingPayment.RunWorkerAsync();
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

        private bool FormValidations()
        {
            var selectedTab = tabControlMain.SelectedTab;

            if (selectedTab == tabPagePayee)
            {
                if (isNewPayee)
                {
                    if (!ucTaxPayers.ValidateChildren())
                    {
                        Helper.MessageBoxError(ucTaxPayers.GetFormErrors());
                        return false;
                    }
                }
            }
            else if (selectedTab == tabPageFees)
            {
                if (!ucBurialPermit.ValidateChildren())
                {
                    Helper.MessageBoxError(ucBurialPermit.GetFormErrors());
                    return false;
                }
            }
            else if (selectedTab == tabPagePayment)
            {
                if (!ucPayment.ValidateChildren())
                {
                    Helper.MessageBoxError(ucPayment.GetFormErrors());
                    return false;
                }
            }

            return true;
        }

        private void ChangeTabs()
        {
            var selectedTab = tabControlMain.SelectedTab;

            if (selectedTab == tabPagePayee)
                tabControlMain.SelectedTab = tabPageFees;
            else if (selectedTab == tabPageFees)
                tabControlMain.SelectedTab = tabPagePayment;
            else if (selectedTab == tabPagePayment)
                ConfirmPayment();
        }

        private void btnNextMain_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormValidations())
                    return;

                ChangeTabs();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            tabControlPayee.SelectedTab = tabNewPayee;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (Helper.MessageBoxConfirmCancel("Your input won't be stored."))
            {
                tabControlPayee.SelectedTab = tabPayeeList;
                ucTaxPayers.ResetForm();
            }
        }

        private void btnBackMain_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControlMain.SelectedIndex < 0)
                    return;

                tabControlMain.SelectedIndex = tabControlMain.SelectedIndex - 1;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        #region Payment

        private bool SaveBurialPermitPayment(PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, PaymentCollectionsModel paymentCollectionsModel, BurialPermitModel burialPermitModel)
        {
            return AccFactory.PaymentCollectionsRepository().InsertWithBurialPermitPayment(paymentCollectionHasChequesModel, paymentCollectionsModel, burialPermitModel);
        }

        private BurialPermitModel BurialPermitModel()
        {
            var burialPermitModel = new BurialPermitModel();

            var collectingOfficerData = ucPayment.GetCollectingOfficerData();
            bool isJobOrder = Convert.ToBoolean(collectingOfficerData["is_job_order"]);

            burialPermitModel.RemainsName = ucBurialPermit.txtRemainsName.Text;
            burialPermitModel.RemainsNationality = ucBurialPermit.txtRemainsNationality.Text;
            burialPermitModel.RemainsAge = Convert.ToInt32(ucBurialPermit.nudRemainsAge.Value);
            burialPermitModel.RemainsSex = ucBurialPermit.radMale.Checked ? "Male" : "Female";
            burialPermitModel.DeathDate = ucBurialPermit.dtpDeathDate.Value;
            burialPermitModel.CauseOfDeath = ucBurialPermit.txtCauseOfDeath.Text;
            burialPermitModel.Cemetery = ucBurialPermit.txtCemetery.Text;
            burialPermitModel.Disinterment = ucBurialPermit.txtDisinterment.Text;
            burialPermitModel.IsInfectious = ucBurialPermit.radInfectiousYes.Checked;
            burialPermitModel.IsEmbalmed = ucBurialPermit.radEmbalmedYes.Checked;
            burialPermitModel.Disposition = ucBurialPermit.txtDisposition.Text;
            burialPermitModel.CreatedBy = Helper.UserId;

            return burialPermitModel;
        }

        private void bgwSavingPayment_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int totalProgressCount = ucPayment.dgCheques.Rows.Count;
                int progressCount = 0;
                var paymentCollectionHasChequesModel = new PaymentCollectionHasChequesModel();

                var chequesModels = new List<ChequesModel>();

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

                    progressCount++;
                    chequesModels.Add(model);
                    Helper.ProgressCounter(bgwSavingPayment, totalProgressCount, progressCount);
                }

                paymentCollectionHasChequesModel.ChequesModels = chequesModels;

                e.Result = SaveBurialPermitPayment(paymentCollectionHasChequesModel, ucPayment.PaymentCollectionsModel(), BurialPermitModel());
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void bgwSavingPayment_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            dialog.label1.Text = e.ProgressPercentage.ToString();
            dialog.btnClose.Enabled = false;
        }

        private void bgwSavingPayment_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is not bool isPaymentSave)
                return;

            if (isPaymentSave)
            {
                dialog.label1.Text = "Payment Process Complete!";
                dialog.btnClose.Enabled = true;
                btnNextMain.Text = "Finish";
                btnBack.Enabled = false;
                ucPayment.Enabled = false;
                return;
            }
        }

        #endregion Payment

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearch.Text;
                LoadPayees(searchText);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private Dictionary<string, string> GetTaxPayerData()
        {
            var dict = new Dictionary<string, string>();
            int rowIndex = dgPayees.CurrentRow.Index;
            int taxpayerId = Convert.ToInt32(dgPayees.Rows[rowIndex].Cells["taxpayers_id"].Value);
            string taxpayerName = dgPayees.Rows[rowIndex].Cells["taxpayers_name"].Value.ToString();

            dict.Add("taxpayers_id", taxpayerId.ToString());
            dict.Add("taxpayer_name", taxpayerName);
            return dict;
        }

        private void LoadFeesAndChargesTab()
        {
            btnBackMain.Enabled = true;
            btnNextMain.Text = "Proceed to Payment";
            radFees.Checked = true;
        }

        private void LoadPaymentTab()
        {
            btnNextMain.Text = "Confirm Payment";
            btnBackMain.Enabled = true;
            radPayment.Checked = true;

            decimal totalAmountPayable = 0;
            ucPayment.OnLoad("58", totalAmountPayable);

            if (isNewPayee)
                ucPayment.txtPayee.Text = ucTaxPayers.txtName.Text;
            else
                ucPayment.txtPayee.Text = GetTaxPayerData()["taxpayer_name"];
        }

        private void tabPagePayment_Enter(object sender, EventArgs e)
        {
            try
            {
                LoadPaymentTab();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tabPageFees_Enter(object sender, EventArgs e)
        {
            try
            {
                LoadFeesAndChargesTab();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tabPagePayee_Enter(object sender, EventArgs e)
        {
            try
            {
                LoadPayee();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadPayee()
        {
            btnBackMain.Enabled = false;
            radPayee.Checked = true;
        }

        private void tabNewPayee_Enter(object sender, EventArgs e)
        {
            isNewPayee = true;
        }

        private void tabPayeeList_Enter(object sender, EventArgs e)
        {
            isNewPayee = false;
        }
    }
}