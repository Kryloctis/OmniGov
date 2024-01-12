using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Dashboard;
using AccountingSystem.Views.Reports.JEV;
using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.JEV
{
    public partial class frmJev : Form
    {
        internal ucJev uc;
        internal frmJevList frmJEVList;
        internal ucJevDashboard ucJEVDashboard;
        internal int createdById;
        private Dictionary<string, dynamic> userDict;

        public frmJev(bool isEdit, frmJevList frmJEVList, ucJevDashboard ucJEVDashboard)
        {
            InitializeComponent();
            uc = ucjev1;
            uc.isEdit = isEdit;
            this.frmJEVList = frmJEVList;
            this.ucJEVDashboard = ucJEVDashboard;
            userDict = Helper.LoggedInUserData();
            Helper.LoadFormIcon(this);
        }

        private void frmJEV_Load(object sender, EventArgs e)
        {
            OnLoad();
        }

        private void OnLoad()
        {
            if (uc.isEdit)
                LoadSelectedJEV(uc.jevId);

            lblCreatedBy.Text = $"{userDict["first_name"]} {userDict["mid_initial"]} {userDict["last_name"]}";
            uc.SumDebitCredit();
            VerifyPermissions();
        }

        private void VerifyPermissions()
        {
            //1. Verify logged in user have JEV permission
            if (!Helper.HasPermission("Transaction > JEV"))
            {
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                uc.SetJevReadOnly(true);
            }

            //2. Check if user has permission of JEV approval
            if (!Helper.HasPermission("Transaction > JEV Approval"))
            {
                btnApprove.Visible = false;
                btnDisapprove.Visible = false;
                btnCancelJEV.Visible = false;
                toolStripSeparator2.Visible = false;
            }

            //3. Check if user has permission to view JEV report
            if (!Helper.HasPermission("Report > JEVs"))
                btnPrint.Enabled = false;

            //4. Verify logged in user if able to access dissaproval message
            if (createdById != Helper.UserId && !Helper.HasPermission("Transaction > JEV Approval"))
                lblShowMessage.Enabled = false;

            //5. Verify logged in user if user is the same who create the JEV for edit purposes only
            if (uc.isEdit && Helper.UserId != createdById)
            {
                string jevStatus = AccFactory.JEVRepository().GetJevStatus(uc.jevId);

                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                uc.SetJevReadOnly(true);

                if (Helper.HasPermission("Transaction > Edit Approved JEV") && jevStatus == "approved")
                {
                    btnSave.Enabled = true;
                    uc.SetJevReadOnly(false);
                }
            }
            else
                uc.SetJevReadOnly(false);
        }

        private static ushort? ValidateNullSubsidiary(object subsidiaryCellValue)
        {
            if (subsidiaryCellValue != null)
            {
                return Convert.ToUInt16(subsidiaryCellValue);
            }

            return null;
        }

        internal bool FormValidations()
        {
            // validate form
            if (uc.fundId == 0 || uc.journalId == 0 || !uc.ValidateChildren() || uc.dgAccounts.Rows.Count == 0)
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            // if debit & credit not equal, show error
            if (uc.txtDebitTotal.Text != uc.txtCreditTotal.Text)
            {
                Helper.MessageBoxError("Debit & Credit amounts must be equal.");
                return false;
            }

            return true;
        }

        private JevModel JevModelData()
        {
            JevModel jevModel = new JevModel();
            string jevStatus = AccFactory.JEVRepository().GetJevStatus(uc.jevId).ToLower();

            if (uc.isEdit)
                jevModel.Id = uc.jevId;

            jevModel.FundsId = uc.fundId;
            jevModel.JournalsId = uc.journalId;
            jevModel.DateEntry = uc.dtpDateEntry.Value;
            jevModel.RefNo = uc.txtRefNo.Text.Trim();
            jevModel.Payee = uc.txtPayee.Text.Trim();
            jevModel.Explanation = uc.txtExplanation.Text.Trim();
            jevModel.IsEdited = jevStatus == "approved" && uc.isEdit ? true : false;

            if (Helper.HasPermission("Transaction > JEV Approved"))
            {
                jevModel.IsApproved = true;
                jevModel.JEVNumber = uc.GetJEVSeriesNo();
            }

            if (!uc.isEdit)
                jevModel.CreatedBy = Helper.UserId;
            else
                jevModel.UpdatedBy = Helper.UserId;

            return jevModel;
        }

        private List<JEVAccountsModel> JevAcountsModelList()
        {
            var jevAccountsModelList = new List<JEVAccountsModel>();
            foreach (DataGridViewRow item in uc.dgAccounts.Rows)
            {
                string fppId = item.Cells["FPPId"].Value.ToString();
                ushort generalLedgerId = Convert.ToUInt16(item.Cells["GeneralLedgerId"].Value);
                ushort? subsidiaryLedgerId = ValidateNullSubsidiary(item.Cells["SubsidiaryLedgerId"].Value);
                string obligationNo = item.Cells["obligationNo"].Value.ToString();
                bool isDebit = Convert.ToBoolean(item.Cells["IsDebit"].Value);
                bool? isDeposit = (bool?)item.Cells["IsDeposit"].Value;

                decimal amount;
                if (isDebit)
                    amount = Convert.ToDecimal(item.Cells["Debit"].Value);
                else
                    amount = Convert.ToDecimal(item.Cells["Credit"].Value);

                var jevAccountModel = new JEVAccountsModel()
                {
                    FPPId = string.IsNullOrWhiteSpace(fppId) ? null : Convert.ToInt32(fppId),
                    GeneralLedgerId = generalLedgerId,
                    SubsidiaryLedgerId = subsidiaryLedgerId,
                    ObligationNo = obligationNo,
                    IsDeposit = isDeposit,
                    IsDebit = isDebit,
                    Amount = amount
                };

                jevAccountsModelList.Add(jevAccountModel);
            }

            return jevAccountsModelList;
        }

        //INSERT
        private bool InsertJournal()
        {
            JevModel jevModel = JevModelData();

            return AccFactory.JEVRepository().Insert(jevModel, JevAcountsModelList());
        }

        private bool InsertCheckDisbursementJournal()
        {
            JevModel jevModel = JevModelData();

            var checkDisbursementsModel = new CheckDisbursementsJournalModel()
            {
                CheckDate = uc.dtpCheckORPaid.Value,
                CheckNo = uc.txtCheckNo.Text.Trim(),
                DVNo = uc.txtDVRCDNo.Text.Trim(),
                RCINo = uc.txtRCIORADA.Text.Trim()
            };

            return AccFactory.JEVRepository().InsertWithCheckDisbursement(jevModel, JevAcountsModelList(), checkDisbursementsModel);
        }

        private bool InsertCashReceiptsJournal()
        {
            JevModel jevModel = JevModelData();

            var cashReceiptsJournalModel = new CashReceiptsJournalModel()
            {
                CollectingOfficerId = Convert.ToByte(uc.cmbCollectingDisbursingOfficer.SelectedValue),
                RCDNo = uc.txtDVRCDNo.Text.Trim(),
                ORNo = uc.txtRCIORADA.Text.Trim(),
                ORDate = uc.dtpCheckORPaid.Value
            };

            return AccFactory.JEVRepository().InsertWithCashReceipts(jevModel, JevAcountsModelList(), cashReceiptsJournalModel);
        }

        private bool InsertADADisbursementsJournal()
        {
            JevModel jevModel = JevModelData();

            var aDADisbursementsJournalModel = new ADADisbursementsJournalModel()
            {
                ADANumber = uc.txtRCIORADA.Text.Trim(),
                DVNo = uc.txtDVRCDNo.Text.Trim()
            };

            return AccFactory.JEVRepository().InsertWithADADisbursements(jevModel, JevAcountsModelList(), aDADisbursementsJournalModel);
        }

        private bool InsertCashDisbursementsJournal()
        {
            JevModel jevModel = JevModelData();

            var cashDisbursementsJournalModel = new CashDisbursementsJournalModel()
            {
                DisbursingOfficerId = Convert.ToInt32(uc.cmbCollectingDisbursingOfficer.SelectedValue),
                DVNo = uc.txtDVRCDNo.Text.Trim(),
                DatePaid = uc.dtpCheckORPaid.Value
            };

            return AccFactory.JEVRepository().InsertWithCashDisbursements(jevModel, JevAcountsModelList(), cashDisbursementsJournalModel);
        }

        private bool InsertGeneralJournal()
        {
            JevModel jevModel = JevModelData();

            var generalJournalModel = new GeneralJournalModel()
            {
                DVNo = uc.txtDVRCDNo.Text.Trim(),
                CheckNo = uc.txtCheckNo.Text.Trim(),
                ORNo = uc.txtRCIORADA.Text.Trim()
            };

            return AccFactory.JEVRepository().InsertWithGeneralJournal(jevModel, JevAcountsModelList(), generalJournalModel);
        }

        //UPDATE
        private bool UpdateJournal(JevModel jevModel)
        {
            return AccFactory.JEVRepository().Update(jevModel, JevAcountsModelList());
        }

        private bool UpdateCheckDisbursementJournal(JevModel jevModel)
        {
            var checkDisbursementsModel = new CheckDisbursementsJournalModel()
            {
                JevId = uc.jevId,
                CheckDate = uc.dtpCheckORPaid.Value,
                CheckNo = uc.txtCheckNo.Text.Trim(),
                DVNo = uc.txtDVRCDNo.Text.Trim(),
                RCINo = uc.txtRCIORADA.Text.Trim()
            };

            return AccFactory.JEVRepository().UpdateWithCheckDisbursement(jevModel, JevAcountsModelList(), checkDisbursementsModel);
        }

        private bool UpdateCashReceiptsJournal(JevModel jevModel)
        {
            var cashReceiptsJournalModel = new CashReceiptsJournalModel()
            {
                JevId = uc.jevId,
                CollectingOfficerId = Convert.ToByte(uc.cmbCollectingDisbursingOfficer.SelectedValue),
                RCDNo = uc.txtRCIORADA.Text.Trim(),
                ORNo = uc.txtRCIORADA.Text.Trim(),
                ORDate = uc.dtpCheckORPaid.Value
            };

            return AccFactory.JEVRepository().UpdateWithCashReceipts(jevModel, JevAcountsModelList(), cashReceiptsJournalModel);
        }

        private bool UpdateADADisbursementsJournal(JevModel jevModel)
        {
            var aDADisbursementsJournalModel = new ADADisbursementsJournalModel()
            {
                JevId = uc.jevId,
                ADANumber = uc.txtRCIORADA.Text.Trim(),
                DVNo = uc.txtDVRCDNo.Text.Trim()
            };

            return AccFactory.JEVRepository().UpdateWithADADisbursements(jevModel, JevAcountsModelList(), aDADisbursementsJournalModel);
        }

        private bool UpdateCashDisbursementsJournal(JevModel jevModel)
        {
            var cashDisbursementsJournalModel = new CashDisbursementsJournalModel()
            {
                JevId = uc.jevId,
                DisbursingOfficerId = Convert.ToInt32(uc.cmbCollectingDisbursingOfficer.SelectedValue),
                DVNo = uc.txtDVRCDNo.Text.Trim(),
                DatePaid = uc.dtpCheckORPaid.Value
            };

            return AccFactory.JEVRepository().UpdateWithCashDisbursements(jevModel, JevAcountsModelList(), cashDisbursementsJournalModel);
        }

        private bool UpdateGeneralJournal(JevModel jevModel)
        {
            var generalJournalModel = new GeneralJournalModel()
            {
                JevId = uc.jevId,
                DVNo = uc.txtDVRCDNo.Text.Trim(),
                CheckNo = uc.txtCheckNo.Text.Trim(),
                ORNo = uc.txtRCIORADA.Text.Trim()
            };

            return AccFactory.JEVRepository().UpdateWithGeneralJournal(jevModel, JevAcountsModelList(), generalJournalModel);
        }

        private bool InsertData()
        {
            switch (uc.journalName)
            {
                case "General Journal":
                    return InsertGeneralJournal();

                case "Procurement Received Journal":
                    return InsertJournal();

                case "Cash Disbursements Journal":
                    return InsertCashDisbursementsJournal();

                case "Cash Receipts Journal":
                    return InsertCashReceiptsJournal();

                case "Check Disbursements Journal":
                    return InsertCheckDisbursementJournal();

                case "Authority to Debit Account Disbursement Journal":
                    return InsertADADisbursementsJournal();

                default: return false;
            }
        }

        internal bool UpdateData(string jevStatus, string remarks = null)
        {
            JevModel jevModel = JevModelData();
            bool updated;

            switch (jevStatus.ToLower())
            {
                case "pending":
                    jevModel.JEVNumber = null;
                    jevModel.IsApproved = false;
                    jevModel.IsDisapproved = false;
                    jevModel.IsCancelled = false;
                    jevModel.Remarks = remarks;
                    break;

                case "disapproved":
                    jevModel.JEVNumber = null;
                    jevModel.IsApproved = false;
                    jevModel.IsDisapproved = true;
                    jevModel.Remarks = remarks;
                    break;

                case "approved":
                    jevModel.JEVNumber = AccFactory.JEVRepository().GetLastJevNoSeries(uc.fundId);
                    jevModel.IsApproved = true;
                    jevModel.IsDisapproved = false;
                    jevModel.IsCancelled = false;
                    jevModel.Remarks = remarks;
                    break;

                case "cancelled":
                    jevModel.IsCancelled = true;
                    jevModel.Remarks = remarks;
                    break;
            }

            switch (uc.journalName)
            {
                case "General Journal":
                    updated = UpdateGeneralJournal(jevModel);
                    break;

                case "Procurement Received Journal":
                    updated = UpdateJournal(jevModel);
                    break;

                case "Cash Disbursements Journal":
                    updated = UpdateCashDisbursementsJournal(jevModel);
                    break;

                case "Cash Receipts Journal":
                    updated = UpdateCashReceiptsJournal(jevModel);
                    break;

                case "Check Disbursements Journal":
                    updated = UpdateCheckDisbursementJournal(jevModel);
                    break;

                case "Authority to Debit Account Disbursement Journal":
                    updated = UpdateADADisbursementsJournal(jevModel);
                    break;

                default:
                    updated = false;
                    break;
            }

            if (uc.journalId != uc.oldJournalId) //CHECK IF THE PREVIOUS JOURNAL ID IS NOT EQUAL TO NEW SELECTED JOURNAL ID
            {
                switch (uc.oldJournalId)
                {
                    case 1:
                        AccFactory.GeneralJournalRepository().DeleteGeneralJournalByJevID(uc.jevId);
                        TransferJournalToNewJournal();  //INSERT TO NEW SELECTED JOURNAL
                        break;

                    case 2:
                        AccFactory.CashReceiptsJournalRepository().DeleteCashReceiptsJournalByJevID(uc.jevId);
                        TransferJournalToNewJournal();  //INSERT TO NEW SELECTED JOURNAL
                        break;

                    case 3:
                        //Factory.GeneralJournalRepository().DeleteGeneralJournalByJevID(uc.jevId);
                        break;

                    case 4:
                        AccFactory.CashDisbursementsJournalRepository().DeleteCashDisbursementJournalByJevID(uc.jevId);
                        TransferJournalToNewJournal();  //INSERT TO NEW SELECTED JOURNAL
                        break;

                    case 5:
                        AccFactory.CheckDisbursementsJournalRepository().DeleteCheckDisbursementJournalByJevID(uc.jevId);
                        TransferJournalToNewJournal();  //INSERT TO NEW SELECTED JOURNAL
                        break;

                    case 6:
                        //Factory.GeneralJournalRepository().DeleteGeneralJournalByJevID(uc.jevId);
                        break;
                }
            }

            return updated;
        }

        private bool SaveData()
        {
            if (!FormValidations())
                return false;

            bool saveData;

            if (uc.isEdit)
            {
                string currentJevStatus = AccFactory.JEVRepository().GetJevStatus(uc.jevId);
                if (currentJevStatus.ToLower() == "disapproved")
                {
                    if (Helper.MessageBoxConfirmCancel("This JEV will be return into Pending.\nConfirm if you want to proceed..."))
                        saveData = UpdateData("pending");
                    else
                        return false;
                }
                else
                    saveData = UpdateData(currentJevStatus);
            }
            else
                saveData = InsertData();

            return saveData;
        }

        private bool DeleteData()
        {
            if (MessageBox.Show("Are you sure you want to delete this JEV?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var jevModel = new JevModel();
                jevModel.Id = uc.jevId;

                var jevRepository = AccFactory.JEVRepository();
                return jevRepository.Delete(jevModel);
            }
            return false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    if (!uc.isEdit)
                    {
                        Helper.MessageBoxSuccess("JEV has been saved");
                        ucjev1.ResetForm();
                        ucJEVDashboard.LoadJEVCounter();
                    }
                    else
                    {
                        int jevId = uc.jevId;
                        Helper.MessageBoxSuccess("JEV has been updated");
                        GetJevStatus(jevId);
                        VerifyPermissions();
                        frmJEVList.LoadJEVList();
                        ucJEVDashboard.LoadJEVCounter();
                        Close();
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void TransferJournalToNewJournal()
        {
            switch (uc.journalId)
            {
                case 1:
                    var generalJournalModel = new GeneralJournalModel()
                    {
                        JevId = uc.jevId,
                        DVNo = uc.txtDVRCDNo.Text.Trim(),
                        CheckNo = uc.txtCheckNo.Text.Trim(),
                        ORNo = uc.txtRCIORADA.Text.Trim()
                    };

                    AccFactory.GeneralJournalRepository().Insert(generalJournalModel);
                    return;

                case 2:
                    var cashReceiptsJournalModel = new CashReceiptsJournalModel()
                    {
                        JevId = uc.jevId,
                        CollectingOfficerId = Convert.ToByte(uc.cmbCollectingDisbursingOfficer.SelectedValue),
                        RCDNo = uc.txtDVRCDNo.Text.Trim(),
                        ORNo = uc.txtRCIORADA.Text.Trim(),
                        ORDate = uc.dtpCheckORPaid.Value
                    };

                    AccFactory.CashReceiptsJournalRepository().Insert(cashReceiptsJournalModel);
                    return;

                case 3:
                    //DO NOTHING
                    return;

                case 4:
                    var cashDisbursementsJournalModel = new CashDisbursementsJournalModel()
                    {
                        JevId = uc.jevId,
                        DisbursingOfficerId = Convert.ToInt32(uc.cmbCollectingDisbursingOfficer.SelectedValue),
                        DVNo = uc.txtDVRCDNo.Text.Trim(),
                        DatePaid = uc.dtpCheckORPaid.Value
                    };

                    AccFactory.CashDisbursementsJournalRepository().Insert(cashDisbursementsJournalModel);
                    return;

                case 5:

                    var checkDisbursementsModel = new CheckDisbursementsJournalModel()
                    {
                        JevId = uc.jevId,
                        CheckDate = uc.dtpCheckORPaid.Value,
                        CheckNo = uc.txtCheckNo.Text.Trim(),
                        DVNo = uc.txtDVRCDNo.Text.Trim(),
                        RCINo = uc.txtRCIORADA.Text.Trim()
                    };

                    AccFactory.CheckDisbursementsJournalRepository().Insert(checkDisbursementsModel);
                    return;

                case 6:
                    //DO NOTHING
                    return;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteData())
                {
                    Helper.MessageBoxSuccess("JEV has been deleted.");
                    frmJEVList.LoadJEVList();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                frmJEVReport _frmJEVReport = new frmJEVReport(uc.jevId, uc.journalId);
                _frmJEVReport.ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void GetJevStatus(int jevId)
        {
            string jevStatus = AccFactory.JEVRepository().GetJevStatus(jevId).ToLower();

            switch (jevStatus)
            {
                case "pending":
                    lblJevStatus.Text = "PENDING";
                    lblJevStatus.ForeColor = Color.FromArgb(216, 146, 22);
                    lblShowMessage.Visible = false;
                    btnPrint.Enabled = false;
                    btnApprove.Enabled = true;
                    btnDisapprove.Enabled = true;
                    btnCancelJEV.Enabled = true;
                    btnDelete.Enabled = true;
                    btnSave.Enabled = true;
                    break;

                case "approved":
                    lblJevStatus.Text = "APPROVED";
                    lblJevStatus.ForeColor = Color.FromArgb(78, 159, 61);
                    lblShowMessage.Visible = false;
                    btnApprove.Enabled = false;
                    btnDisapprove.Enabled = false;
                    btnCancelJEV.Enabled = true;
                    btnPrint.Enabled = true;
                    btnSave.Enabled = true;
                    btnDelete.Enabled = false;
                    btnSave.Enabled = false;
                    break;

                case "disapproved":
                    lblJevStatus.Text = "DISAPPROVED";
                    lblJevStatus.ForeColor = Color.FromArgb(149, 1, 1);
                    lblShowMessage.Visible = true;
                    btnApprove.Enabled = false;
                    btnDisapprove.Enabled = false;
                    btnCancelJEV.Enabled = true;
                    btnPrint.Enabled = false;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    break;

                case "cancelled":
                    lblJevStatus.Text = "CANCELLED";
                    lblJevStatus.ForeColor = Color.FromArgb(66, 63, 62);
                    lblShowMessage.Visible = false;
                    btnApprove.Enabled = false;
                    btnDisapprove.Enabled = false;
                    btnCancelJEV.Enabled = false;
                    btnPrint.Enabled = false;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    break;
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                if (uc.isEdit)
                {
                    if (UpdateData("approved"))
                    {
                        Helper.MessageBoxSuccess("JEV has been approved.");
                        GetJevStatus(uc.jevId);
                        uc.txtFundsJevNo.Text = uc.GenerateJevTemplateNo();
                        uc.txtJEVNo.Text = uc.GetJEVSeriesNo();
                        frmJEVList.LoadJEVList();
                        ucJEVDashboard.LoadJEVCounter();
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError($"{ex.Message}\n(No changes has been saved.)"); }
        }

        private void btnDisapprove_Click(object sender, EventArgs e)
        {
            try
            {
                if (uc.jevId != 0)
                {
                    var frmRemarks = new frmJevDisapproval(this);
                    frmRemarks.btnDisapprove.Visible = true;
                    frmRemarks.btnAccept.Visible = false;
                    frmRemarks.btnSaveMessage.Visible = false;
                    frmRemarks.ShowDialog();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void lblShowMessage_Click(object sender, EventArgs e)
        {
            try
            {
                if (uc.jevId != 0)
                {
                    var frmRemarks = new frmJevDisapproval(this);
                    frmRemarks.btnDisapprove.Visible = false;
                    frmRemarks.btnCancel.Text = "Close";
                    frmRemarks.ShowDialog();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnCancelJEV_Click(object sender, EventArgs e)
        {
            try
            {
                if (uc.isEdit)
                {
                    if (MessageBox.Show("Confirm cancellation of JEV.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (UpdateData("cancelled"))
                        {
                            Helper.MessageBoxSuccess("JEV has been cancelled.");
                            GetJevStatus(uc.jevId);
                            frmJEVList.LoadJEVList();
                            ucJEVDashboard.LoadJEVCounter();
                        }
                        return;
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError($"{ex.Message}\n(No changes has been saved.)"); }
        }

        private void CheckedFund(string fundName)
        {
            uc.flowLayoutPanelFunds.Controls.OfType<RadioButton>().FirstOrDefault(r => (r.Text == fundName) ? r.Checked = true : r.Checked = false);
        }

        private void CheckedJournal(string journalName)
        {
            uc.flowLayoutPanelJournals.Controls.OfType<RadioButton>().FirstOrDefault(r => (r.Text == journalName) ? r.Checked = true : r.Checked = false);
        }

        private void LoadJevAccounts()
        {
            DataTable dtJEV = AccFactory.JEVAccountsRepository().GetViewRecordsByJevId(uc.jevId);

            foreach (DataRow row in dtJEV.Rows)
            {
                string fppId = row["fpp_id"].ToString();
                string fppName = row["fpp_name"].ToString();
                string generalLedgerId = row["general_ledger_accounts_id"].ToString();
                string subsidiaryId = !string.IsNullOrWhiteSpace(row["subsidiary_ledger_accounts_id"].ToString()) ? row["subsidiary_ledger_accounts_id"].ToString() : null;
                string subsidiaryName = row["subsidiary_ledger_accounts_name"].ToString();
                string obligationNo = row["obligation_no"].ToString();
                string generalLedgerName = row["general_ledger_accounts_name"].ToString();
                string accountCode = row["account_code"].ToString();
                decimal amount = Convert.ToDecimal(row["amount"]);
                bool isDebit = Convert.ToBoolean(row["is_debit"]);
                bool? isDeposit;

                if (!string.IsNullOrWhiteSpace(row["is_deposit"].ToString()))
                    isDeposit = Convert.ToBoolean(row["is_deposit"]);
                else
                    isDeposit = null;

                object[] accountRow;
                if (isDebit)
                {
                    // for debit row
                    accountRow = new object[]
                    {
                        fppId,
                        generalLedgerId,
                        subsidiaryId,
                        isDebit,
                        fppName,
                        generalLedgerName,
                        accountCode,
                        subsidiaryName,
                        obligationNo,
                        amount.ToString("N2"),
                        "",
                        isDeposit
                    };

                    uc.dgAccounts.Rows.Add(accountRow);
                }
                else
                {
                    // for credit row
                    accountRow = new object[]
                    {
                        fppId,
                        generalLedgerId,
                        subsidiaryId,
                        isDebit,
                        fppName,
                        $"     {generalLedgerName}",
                        accountCode,
                        subsidiaryName,
                        obligationNo,
                        "",
                        amount.ToString("N2"),
                        isDeposit
                    };

                    uc.dgAccounts.Rows.Add(accountRow);
                }
            }
        }

        private void LoadCheckDisbursementsDataIfExist(int jevId)
        {
            var checkDisbursementsRepository = AccFactory.CheckDisbursementsJournalRepository();

            if (checkDisbursementsRepository.JevIdExist(jevId))
            {
                Dictionary<string, string> checkDisbursementsDict = checkDisbursementsRepository.GetRecordByJevID(jevId);

                uc.dtpCheckORPaid.Value = Convert.ToDateTime(checkDisbursementsDict["check_date"]);
                uc.txtCheckNo.Text = checkDisbursementsDict["check_no"];
                uc.txtDVRCDNo.Text = checkDisbursementsDict["dv_no"];
                uc.txtRCIORADA.Text = checkDisbursementsDict["rci_no"];
            }
        }

        private void LoadCashReceiptsDataIfExist(int jevId)
        {
            var cashReceiptsJournalRepository = AccFactory.CashReceiptsJournalRepository();

            if (cashReceiptsJournalRepository.JevIdExist(jevId))
            {
                Dictionary<string, string> checkDisbursementsDict = cashReceiptsJournalRepository.GetViewRecordByJevID(jevId);

                uc.txtDVRCDNo.Text = checkDisbursementsDict["rcd_no"];
                uc.cmbCollectingDisbursingOfficer.SelectedValue = checkDisbursementsDict["collecting_officers_id"];
                uc.txtRCIORADA.Text = checkDisbursementsDict["or_no"];
                uc.dtpCheckORPaid.Value = Convert.ToDateTime(checkDisbursementsDict["or_date"]);
            }
        }

        private void LoadADADisbursementDataIfExist(int jevId)
        {
            var aDADisbursementsJournalRepository = AccFactory.ADADisbursementsJournalRepository();

            if (aDADisbursementsJournalRepository.JevIdExist(jevId))
            {
                Dictionary<string, string> adaDisbursementsDict = aDADisbursementsJournalRepository.GetViewRecordByJevID(jevId);

                uc.txtDVRCDNo.Text = adaDisbursementsDict["dv_no"];
                uc.txtRCIORADA.Text = adaDisbursementsDict["ada_no"];
            }
        }

        private void LoadCashDisbursementDataIfExist(int jevId)
        {
            var cashDisbursementsJournalRepository = AccFactory.CashDisbursementsJournalRepository();

            if (cashDisbursementsJournalRepository.JevIdExist(jevId))
            {
                Dictionary<string, string> cashDisbursementsDict = cashDisbursementsJournalRepository.GetViewRecordByJevID(jevId);

                uc.dtpCheckORPaid.Value = Convert.ToDateTime(cashDisbursementsDict["date_paid"]);
                uc.txtDVRCDNo.Text = cashDisbursementsDict["dv_no"];
                uc.cmbCollectingDisbursingOfficer.SelectedValue = Convert.ToInt32(cashDisbursementsDict["disbursing_officers_id"]);
            }
        }

        private void LoadGeneralJournalDataIfExist(int jevId)
        {
            var generalJournalRepository = AccFactory.GeneralJournalRepository();

            if (generalJournalRepository.JevIdExist(jevId))
            {
                Dictionary<string, string> generalJournalDict = generalJournalRepository.GetViewRecordByJevID(jevId);

                uc.txtCheckNo.Text = generalJournalDict["check_no"];
                uc.txtDVRCDNo.Text = generalJournalDict["dv_no"];
                uc.txtRCIORADA.Text = generalJournalDict["or_no"];
            }
        }

        internal void LoadSelectedJEV(int jevId)
        {
            Cursor = Cursors.WaitCursor;
            Enabled = true;
            Dictionary<string, string> jevDict = AccFactory.JEVRepository().GetViewRecordByJEVId(jevId);

            int dictJevId = Convert.ToInt32(jevDict["id"]);
            byte dictFundId = Convert.ToByte(jevDict["funds_id"]);
            string dictExplanation = jevDict["explanation"];
            DateTime dictDateEntry = Convert.ToDateTime(jevDict["date_entry"]);
            byte dictJournalId = Convert.ToByte(jevDict["journals_id"]);
            byte dictOldJournalId = Convert.ToByte(jevDict["journals_id"]);
            string dictCreatedBy = jevDict["created_by_name"];
            string dictJevNo = jevDict["jev_no"];
            string dictPayee = jevDict["payee"];
            string dictRefNo = jevDict["ref_no"];

            uc.jevId = dictJevId;
            uc.fundId = dictFundId;
            uc.txtExplanation.Text = dictExplanation;
            uc.dtpDateEntry.Value = dictDateEntry;
            uc.txtRefNo.Text = dictRefNo;
            uc.txtPayee.Text = dictPayee;
            uc.txtJEVNo.Text = dictJevNo;
            uc.journalId = dictJournalId;
            uc.oldJournalId = dictOldJournalId;
            lblCreatedBy.Text = dictCreatedBy;

            if (!string.IsNullOrEmpty(dictJevNo))
                uc.txtFundsJevNo.Text = uc.GenerateJevTemplateNo();

            if (Convert.ToByte(jevDict["is_edited"]) == 1)
            {
                lblIsEdited.Visible = true;
                lblIsEdited.Text = $"(Edited)";
            }
            else
                lblIsEdited.Visible = false;

            CheckedFund(jevDict["fund_name"]);
            CheckedJournal(jevDict["journal_name"]);

            uc.ClearErrors();

            uc.dgAccounts.Rows.Clear();
            LoadJevAccounts();
            uc.SumDebitCredit();
            GetJevStatus(uc.jevId);

            LoadCheckDisbursementsDataIfExist(uc.jevId);
            LoadCashReceiptsDataIfExist(uc.jevId);
            LoadADADisbursementDataIfExist(uc.jevId);
            LoadCashDisbursementDataIfExist(uc.jevId);
            LoadGeneralJournalDataIfExist(uc.jevId);

            btnSave.Text = "&Update";

            Cursor = Cursors.Default;
        }
    }
}