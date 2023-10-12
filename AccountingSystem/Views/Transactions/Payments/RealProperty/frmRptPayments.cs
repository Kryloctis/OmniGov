using ACC.Domain.Models;
using AccountingSystem.Views.Dialogs;
using AccountingSystem.Views.Transactions.Payments.OtherPayments;
using AccountingSystem.Views.Transactions.Payments.OtherPayments.AF51_57;
using AccountingSystem.Views.Transactions.Payments.OtherPayments.BurialPermit;
using AccountingSystem.Views.Transactions.Payments.OtherPayments.CattleOwnership;
using AccountingSystem.Views.Transactions.Payments.OtherPayments.CattleTransferOfOwnership;
using AccountingSystem.Views.Transactions.Payments.OtherPayments.MarriageLicense;
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

        private ucAF51_57 ucAF51And57;
        private ucOtherCharges ucOtherCharges;
        private ucMarriageLicense ucMarriageLicense;
        private ucBurialPermit ucBurialPermit;
        private ucCattleOwnership ucCattleOwnership;
        internal ucCattleTransferOfOwnership ucCattleTransferOfOwnership;

        public frmRptPayments()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgTaxpayers, true);
            ucRptTaxDues = ucRptTaxDues1;
            ucPayment = ucPayment1;
            ucAF51And57 = ucaF51_571;
            ucOtherCharges = ucOtherCharges1;

            ucBurialPermit = ucBurialPermit1;
            ucMarriageLicense = ucMarriageLicense1;
            ucCattleOwnership = ucCattleOwnership2;
            ucCattleTransferOfOwnership = ucCattleTransferOfOwnership1;
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
            try
            {
                HelperLoadRecords.DataGridViewPaymentTaxpayers(dgTaxpayers, DataTableTaxpayers());
                dgTaxpayers.CurrentCell = dgTaxpayers.FirstDisplayedCell;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadPaymentTab()
        {
            if (tabControlTaxDues.SelectedTab == tabPageRpt)
            {
                if (!ucRptTaxDues.ValidateChildren())
                {
                    Helper.MessageBoxError(ucRptTaxDues.GetFormErrors());
                    return;
                }

                ucPayment.amountPayment = ucRptTaxDues.GetTotalTaxDue();
                ucPayment.txtTaxpayer.Text = GetTaxPayerData()["taxpayer_name"];
                ucPayment.txtPayee.Text = GetTaxPayerData()["taxpayer_name"];
                ucPayment.OnLoad("56");
            }
            else if (tabControlTaxDues.SelectedTab == tabPageBpl)
            {
                ucPayment.amountPayment = 0;
                ucPayment.txtTaxpayer.Text = GetTaxPayerData()["taxpayer_name"];
                ucPayment.txtPayee.Text = GetTaxPayerData()["taxpayer_name"];
                ucPayment.OnLoad();
            }
            else if (tabControlTaxDues.SelectedTab == tabPageOthers)
            {
                ucPayment.amountPayment = ucOtherCharges.GetTotalOtherCharges();
                ucPayment.txtTaxpayer.Text = GetTaxPayerData()["taxpayer_name"];
                ucPayment.txtPayee.Text = GetTaxPayerData()["taxpayer_name"];
                ucPayment.OnLoad(ucPayment.selectedAccountableFormNo);
            }

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
            ucaF51_571.LoadTaxpayerInfo(taxpayerId);
            ucCattleOwnership.LoadTaxpayerInfo(taxpayerId);
            ucCattleTransferOfOwnership.LoadOldOwnerInfo(taxpayerId);
            ucBurialPermit.LoadTaxpayerInfo(taxpayerId);
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

        private void radRpt_CheckedChanged(object sender, EventArgs e)
        {
            tabControlTaxDues.SelectedTab = tabPageRpt;
        }

        private void radBpl_CheckedChanged(object sender, EventArgs e)
        {
            tabControlTaxDues.SelectedTab = tabPageBpl;
        }

        private void radOthers_CheckedChanged(object sender, EventArgs e)
        {
            tabControlTaxDues.SelectedTab = tabPageOthers;
        }

        private void txtTaxpayerSearch_TextChanged(object sender, EventArgs e)
        {
            LoadTaxpayers();
        }

        #region Save Payment

        private PaymentCollectionsModel PaymentCollectionsModel()
        {
            var paymentCollectionsModel = new PaymentCollectionsModel();

            try
            {
                var collectingOfficerData = ucPayment.GetCollectingOfficerData();
                bool isJobOrder = Convert.ToBoolean(collectingOfficerData["is_job_order"]);

                paymentCollectionsModel.CollectingOfficerId = !isJobOrder ? Convert.ToInt32(collectingOfficerData["id"]) : null;
                paymentCollectionsModel.JobOrderId = isJobOrder ? Convert.ToInt32(collectingOfficerData["id"]) : null;
                paymentCollectionsModel.AccountableFormId = Convert.ToInt32(ucPayment.cmbxAccountableForm.SelectedValue);
                paymentCollectionsModel.Amount = ucPayment.amountPayment;
                paymentCollectionsModel.Payee = ucPayment.txtPayee.Text;
                paymentCollectionsModel.ReceiptNo = ucPayment.txtReceipts.Text.Trim();
                paymentCollectionsModel.PaymentDate = ucPayment.dtPaymentDate.Value;
                paymentCollectionsModel.CreatedBy = Helper.UserId;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return paymentCollectionsModel;
        }

        private MarriageLicenseModel MarriageLicenseModel()
        {
            var marriageLicenseModel = new MarriageLicenseModel();

            try
            {
                var collectingOfficerData = ucPayment.GetCollectingOfficerData();
                bool isJobOrder = Convert.ToBoolean(collectingOfficerData["is_job_order"]);

                marriageLicenseModel.RegisterNo = ucMarriageLicense.txtRegistrationNumber.Text;
                marriageLicenseModel.IssuedOn = ucMarriageLicense.dtpIssuedDate.Value;
                marriageLicenseModel.PublishedOn = ucMarriageLicense.dtpPublishedDate.Value;
                marriageLicenseModel.HusbandName = ucMarriageLicense.txtHusbandName.Text;
                marriageLicenseModel.HusbandAge = Convert.ToInt32(ucMarriageLicense.nudHusbandAgeYear.Value);
                marriageLicenseModel.HusbandMonth = Convert.ToInt32(ucMarriageLicense.nudHusbandAgeMonth.Value);
                marriageLicenseModel.HusbandStreet = ucMarriageLicense.txtHusbandStreet.Text;
                marriageLicenseModel.HusbandBarangay = ucMarriageLicense.cmbxHusbandBarangay.Text;
                marriageLicenseModel.HusbandMunipality = ucMarriageLicense.cmbxHusbandMunicipality.Text;
                marriageLicenseModel.HusbandProvince = ucMarriageLicense.cmbxHusbandProvince.Text;

                marriageLicenseModel.WifeName = ucMarriageLicense.txtWifeName.Text;
                marriageLicenseModel.WifeAge = Convert.ToInt32(ucMarriageLicense.nudWifeAgeYear.Text);
                marriageLicenseModel.WifeMonth = Convert.ToInt32(ucMarriageLicense.nudWifeAgeMonth.Text);
                marriageLicenseModel.WifeStreet = ucMarriageLicense.txtWifeStreet.Text;
                marriageLicenseModel.WifeBarangay = ucMarriageLicense.cmbxWifeBarangay.Text;
                marriageLicenseModel.WifeMunicipality = ucMarriageLicense.cmbxWifeBarangay.Text;
                marriageLicenseModel.WifeProvince = ucMarriageLicense.cmbxWifeProvince.Text;
                marriageLicenseModel.CreatedBy = Helper.UserId;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return marriageLicenseModel;
        }

        private BurialPermitModel BurialPermitModel()
        {
            var burialPermitModel = new BurialPermitModel();

            try
            {
                var collectingOfficerData = ucPayment.GetCollectingOfficerData();
                bool isJobOrder = Convert.ToBoolean(collectingOfficerData["is_job_order"]);
                burialPermitModel.Permission = ucBurialPermit.txtPermission.Text;
                burialPermitModel.RemainsName = ucBurialPermit.txtCemetery.Text;
                burialPermitModel.RemainsNationality = ucBurialPermit.txtRemainsNationality.Text;
                burialPermitModel.RemainsAge = Convert.ToInt32(ucBurialPermit.nudRemainsAge.Value);
                burialPermitModel.RemainsSex = ucBurialPermit.cmbxRemainsSex.Text;
                burialPermitModel.DeathDate = Convert.ToDateTime(ucBurialPermit.dtpDeathDate.Value);
                burialPermitModel.CauseOfDeath = ucBurialPermit.txtCauseOfDeath.Text;
                burialPermitModel.Cemetery = ucBurialPermit.txtCemetery.Text;
                burialPermitModel.Disinterment = ucBurialPermit.txtDisinterment.Text;
                burialPermitModel.IsInfectious = ucBurialPermit.cbxIsInfectious.Checked;
                burialPermitModel.IsEmbalmed = ucBurialPermit.cbxIsEmbalbed.Checked;
                burialPermitModel.CreatedAt = DateTime.Today;
                burialPermitModel.CreatedBy = Helper.UserId;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return burialPermitModel;
        }

        private CattleOwnershipModel CattleOwnershipModel()
        {
            var cattleOwnershipModel = new CattleOwnershipModel();

            try
            {
                var collectingOfficerData = ucPayment.GetCollectingOfficerData();
                bool isJobOrder = Convert.ToBoolean(collectingOfficerData["is_job_order"]);

                cattleOwnershipModel.OwnerID = ucCattleOwnership.ownerID;
                cattleOwnershipModel.Tag = 1;
                cattleOwnershipModel.OwnerBarangay = ucCattleOwnership.cmbxBarangay.Text;
                cattleOwnershipModel.OwnerMunicipality = ucCattleOwnership.cmbxMunicipality.Text;
                cattleOwnershipModel.OwnerProvince = ucCattleOwnership.cmbxProvince.Text;
                cattleOwnershipModel.CattleType = ucCattleOwnership.cmbxType.Text;
                cattleOwnershipModel.CattleSex = ucCattleOwnership.cmbxSex.Text;
                cattleOwnershipModel.CattleAge = Convert.ToInt32(ucCattleOwnership.nudAge.Value);
                cattleOwnershipModel.Description = ucCattleOwnership.txtDescription.Text;
                cattleOwnershipModel.CreatedBy = Helper.UserId;
                cattleOwnershipModel.CreatedAt = DateTime.Now;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return cattleOwnershipModel;
        }

        private CattleTransferOfOwnershipModel CattleTransferOfOwnershipModel()
        {
            var cattleTransferOfOwnershipModel = new CattleTransferOfOwnershipModel();

            try
            {
                var collectingOfficerData = ucPayment.GetCollectingOfficerData();
                bool isJobOrder = Convert.ToBoolean(collectingOfficerData["is_job_order"]);

                cattleTransferOfOwnershipModel.CattleOwnershipID = ucCattleTransferOfOwnership.cattleID;
                cattleTransferOfOwnershipModel.OldOwnerID = ucCattleTransferOfOwnership.oldOwnerID;
                cattleTransferOfOwnershipModel.NewOwnerID = ucCattleTransferOfOwnership.newOwnerID;
                cattleTransferOfOwnershipModel.Barangay = ucCattleOwnership.cmbxBarangay.Text;
                cattleTransferOfOwnershipModel.Municipality = ucCattleOwnership.cmbxMunicipality.Text;
                cattleTransferOfOwnershipModel.Province = ucCattleOwnership.cmbxProvince.Text;
                cattleTransferOfOwnershipModel.CattleType = ucCattleOwnership.cmbxType.Text;
                cattleTransferOfOwnershipModel.CattleSex = ucCattleOwnership.cmbxSex.Text;
                cattleTransferOfOwnershipModel.CattleAge = Convert.ToInt32(ucCattleOwnership.nudAge.Value);
                cattleTransferOfOwnershipModel.Description = ucCattleOwnership.txtDescription.Text;
                cattleTransferOfOwnershipModel.CreatedBy = Helper.UserId;
                cattleTransferOfOwnershipModel.CreatedAt = DateTime.Now;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return cattleTransferOfOwnershipModel;
        }

        private bool SaveRptPayment(PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, PaymentCollectionsModel paymentCollectionsModel, RptPaymentsModel rptPaymentsModel, List<RptTaxDuesModel> rptTaxDuesModels)
        {
            return AccFactory.PaymentCollectionsRepository().InsertWithRptPayment(paymentCollectionHasChequesModel, paymentCollectionsModel, rptPaymentsModel, rptTaxDuesModels);
        }

        private bool SaveMarriageLicensePayment(PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, PaymentCollectionsModel paymentCollectionsModel, MarriageLicenseModel marriageLicenseModel)
        {
            try
            {
                return AccFactory.PaymentCollectionsRepository().InsertWithMarriageLicensePayment(paymentCollectionHasChequesModel, paymentCollectionsModel, marriageLicenseModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool SaveBurialPermitPayment(PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, PaymentCollectionsModel paymentCollectionsModel, BurialPermitModel burialPermitModel)
        {
            try
            {
                return AccFactory.PaymentCollectionsRepository().InsertWithBurialPermitPayment(paymentCollectionHasChequesModel, paymentCollectionsModel, burialPermitModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool SaveCattleOwnershipPayment(PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, PaymentCollectionsModel paymentCollectionsModel, CattleOwnershipModel cattleOwnershipModel)
        {
            try
            {
                return AccFactory.PaymentCollectionsRepository().InsertWithCattleOwnershipPayment(paymentCollectionHasChequesModel, paymentCollectionsModel, cattleOwnershipModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool SaveTransferOfCattleOwnership(PaymentCollectionHasChequesModel paymentCollectionHasChequesModel, PaymentCollectionsModel paymentCollectionsModel, CattleTransferOfOwnershipModel cattleTransferOfOwnershipModel)
        {
            try
            {
                return AccFactory.PaymentCollectionsRepository().InsertWithTransferOfCattleOwnershipPayment(paymentCollectionHasChequesModel, paymentCollectionsModel, cattleTransferOfOwnershipModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
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
                    backgroundWorker1.ReportProgress((progressCount * 100) / totalProgress);
                    chequesModels.Add(model);
                }

                paymentCollectionHasChequesModel.ChequesModels = chequesModels;

                var methodInvoker = new MethodInvoker(delegate
                {
                    if (radBpl.Checked)
                    {
                    }
                    else if (radRpt.Checked)
                    {
                        SaveRptPayment(paymentCollectionHasChequesModel, PaymentCollectionsModel(), rptPaymentsModel, ucRptTaxDues.RptTaxDuesModelList());
                    }
                    else if (radOthers.Checked)
                    {
                        switch (ucPayment.selectedAccountableFormNo)
                        {
                            case "51":
                                break;

                            case "52":
                                SaveTransferOfCattleOwnership(paymentCollectionHasChequesModel, PaymentCollectionsModel(), CattleTransferOfOwnershipModel());
                                break;

                            case "53":
                                SaveCattleOwnershipPayment(paymentCollectionHasChequesModel, PaymentCollectionsModel(), CattleOwnershipModel());
                                break;

                            case "54":
                                SaveMarriageLicensePayment(paymentCollectionHasChequesModel, PaymentCollectionsModel(), MarriageLicenseModel());
                                break;

                            case "58":
                                SaveBurialPermitPayment(paymentCollectionHasChequesModel, PaymentCollectionsModel(), BurialPermitModel());
                                break;

                            default:
                                break;
                        }
                    }
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

        #region Current Payment Transaction Identifier

        private void tabPageAF51ANDAF57_Enter(object sender, EventArgs e)
        {
            ucPayment.selectedAccountableFormNo = "51";
            ucOtherCharges = ucOtherCharges1;
            ucOtherCharges.accountableForm = ucPayment.selectedAccountableFormNo;
        }

        private void tabPageCertificateOfTransferOfCattle_Enter(object sender, EventArgs e)
        {
            ucCattleTransferOfOwnership._frmPayments = this;
            ucPayment.selectedAccountableFormNo = "52";
            ucOtherCharges = ucOtherCharges2;
            ucOtherCharges.accountableForm = ucPayment.selectedAccountableFormNo;
        }

        private void tabPageCattleOwnership_Enter(object sender, EventArgs e)
        {
            ucPayment.selectedAccountableFormNo = "53";
            ucOtherCharges = ucOtherCharges3;
            ucOtherCharges.accountableForm = ucPayment.selectedAccountableFormNo;
        }

        private void tabPageMarriageLicense_Enter(object sender, EventArgs e)
        {
            ucPayment.selectedAccountableFormNo = "54";
            ucOtherCharges = ucOtherCharges4;
            ucOtherCharges.accountableForm = ucPayment.selectedAccountableFormNo;
        }

        private void tabPageBurialPermit_Enter(object sender, EventArgs e)
        {
            ucPayment.selectedAccountableFormNo = "58";
            ucOtherCharges = ucOtherCharges5;
            ucOtherCharges.accountableForm = ucPayment.selectedAccountableFormNo;
        }

        #endregion Current Payment Transaction Identifier
    }
}