using ACC.Domain.Models;
using AccountingSystem.Views.Dashboard;
using AccountingSystem.Views.Reports.JEV;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.JEV
{
    public partial class frmJEV : Form
    {
        private ucJEV uc;
        internal frmJEVList _frmJEVList;
        internal ucJEVDashboard _ucJEVDashboard;
        internal int createdById;
        private Dictionary<string, dynamic> userDict;

        public frmJEV(frmJEVList frmJEVList, ucJEVDashboard ucJEVDashboard)
        {
            InitializeComponent();
            uc = ucjev1;
            _frmJEVList = frmJEVList;
            _ucJEVDashboard = ucJEVDashboard;
            userDict = Helper.LoggedInUserData();
            Helper.LoadFormIcon(this);
        }

        private void frmJEV_Load(object sender, EventArgs e)
        {

            if (_frmJEVList != null)
            {
                LoadSelectedJEV(uc.jevId);
                GetJevStatus(uc.jevId);
            }
            else
                lblCreatedBy.Text = $"{userDict["first_name"]} {userDict["mid_initial"]} {userDict["last_name"]}";

            uc.SumDebitCredit();
            PermissionVerification();
        }

        private void PermissionVerification()
        {
            try
            {
                void HasPermissionToEditApprovedJEV()
                {
                    if (uc.isEdit)
                    {
                        string jevStatus = Factory.JEVRepository().GetJevStatus(uc.jevId);


                        if (Helper.HasPermission("Transaction Edit Approved JEV") && jevStatus == "approved")
                        {
                            btnSave.Enabled = true;
                            ucjev1.Enabled = true;
                        }
                    }
                }


                if (!Helper.HasPermission("JEV Approval"))
                {
                    btnApprove.Visible = false;
                    btnDisapprove.Visible = false;
                    btnCancelJEV.Visible = false;
                    toolStripSeparator2.Visible = false;
                }

                if (!Helper.HasPermission("Report JEVs"))
                    btnPrint.Enabled = false;

                if (!Helper.HasPermission("Transaction JEV"))
                {
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    ucjev1.Enabled = false;
                }


                if (Helper.UserId != createdById && createdById != 0)
                {
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    ucjev1.Enabled = false;
                }

                if (createdById != Helper.UserId)
                    lblShowMessage.Enabled = false;

                if (Helper.HasPermission("JEV Approval"))
                    lblShowMessage.Enabled = true;

                HasPermissionToEditApprovedJEV();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
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

        private JEVModel ParseJEVModelData(byte userId, bool isUpdate = false)
        {
            string jevNo = uc.txtJEVNo.Text.Trim();
            var jevModel = new JEVModel();
            string jevStatus = Factory.JEVRepository().GetJevStatus(uc.jevId).ToLower();

            if (isUpdate) jevModel.Id = uc.jevId;

            jevModel.FundsId = uc.fundId;
            jevModel.JournalsId = uc.journalId;
            jevModel.JEVNumber = jevNo;
            jevModel.DateEntry = uc.dtpDateEntry.Value;
            jevModel.RefNo = uc.txtRefNo.Text.Trim();
            jevModel.Payee = uc.txtPayee.Text.Trim();
            jevModel.Explanation = uc.txtExplanation.Text.Trim();
            jevModel.IsEdited = jevStatus == "approved" && uc.isEdit ? true : false;

            if (!Helper.HasPermission("Transaction JEV Approved"))
                jevModel.IsApproved = false;
            else
                jevModel.IsApproved = true;

            if (!isUpdate)
                jevModel.CreatedBy = userId;
            else
                jevModel.UpdatedBy = userId;

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
        private bool InsertJournal(byte userId)
        {
            JEVModel jevModel = ParseJEVModelData(userId);

            return Factory.JEVRepository().Insert(jevModel, JevAcountsModelList());
        }

        private bool InsertCheckDisbursementJournal(byte userId)
        {
            JEVModel jevModel = ParseJEVModelData(userId);

            var checkDisbursementsModel = new CheckDisbursementsJournalModel()
            {
                CheckDate = uc.dtpCheckORPaid.Value,
                CheckNo = uc.txtCheckNo.Text.Trim(),
                DVNo = uc.txtDVRCDNo.Text.Trim(),
                RCINo = uc.txtRCIORADA.Text.Trim()
            };

            return Factory.JEVRepository().InsertWithCheckDisbursement(jevModel, JevAcountsModelList(), checkDisbursementsModel);
        }

        private bool InsertCashReceiptsJournal(byte userId)
        {
            JEVModel jevModel = ParseJEVModelData(userId);

            var cashReceiptsJournalModel = new CashReceiptsJournalModel()
            {
                CollectingOfficerId = Convert.ToByte(uc.cmbCollectingDisbursingOfficer.SelectedValue),
                RCDNo = uc.txtDVRCDNo.Text.Trim(),
                ORNo = uc.txtRCIORADA.Text.Trim(),
                ORDate = uc.dtpCheckORPaid.Value
            };

            return Factory.JEVRepository().InsertWithCashReceipts(jevModel, JevAcountsModelList(), cashReceiptsJournalModel);
        }

        private bool InsertADADisbursementsJournal(byte userId)
        {
            JEVModel jevModel = ParseJEVModelData(userId);

            var aDADisbursementsJournalModel = new ADADisbursementsJournalModel()
            {
                ADANumber = uc.txtRCIORADA.Text.Trim(),
                DVNo = uc.txtDVRCDNo.Text.Trim()
            };

            return Factory.JEVRepository().InsertWithADADisbursements(jevModel, JevAcountsModelList(), aDADisbursementsJournalModel);
        }

        private bool InsertCashDisbursementsJournal(byte userId)
        {
            JEVModel jevModel = ParseJEVModelData(userId);

            var cashDisbursementsJournalModel = new CashDisbursementsJournalModel()
            {
                DisbursingOfficerId = Convert.ToInt32(uc.cmbCollectingDisbursingOfficer.SelectedValue),
                DVNo = uc.txtDVRCDNo.Text.Trim(),
                DatePaid = uc.dtpCheckORPaid.Value
            };

            return Factory.JEVRepository().InsertWithCashDisbursements(jevModel, JevAcountsModelList(), cashDisbursementsJournalModel);
        }

        private bool InsertGeneralJournal(byte userId)
        {
            JEVModel jevModel = ParseJEVModelData(userId);

            var generalJournalModel = new GeneralJournalModel()
            {
                DVNo = uc.txtDVRCDNo.Text.Trim(),
                CheckNo = uc.txtCheckNo.Text.Trim(),
                ORNo = uc.txtRCIORADA.Text.Trim()
            };

            return Factory.JEVRepository().InsertWithGeneralJournal(jevModel, JevAcountsModelList(), generalJournalModel);
        }

        //UPDATE
        private bool UpdateJournal(byte userId)
        {
            JEVModel jevModel = ParseJEVModelData(userId, true);

            return Factory.JEVRepository().Update(jevModel, JevAcountsModelList());
        }

        private bool UpdateCheckDisbursementJournal(byte userId)
        {
            JEVModel jevModel = ParseJEVModelData(userId, true);

            var checkDisbursementsModel = new CheckDisbursementsJournalModel()
            {
                JevId = uc.jevId,
                CheckDate = uc.dtpCheckORPaid.Value,
                CheckNo = uc.txtCheckNo.Text.Trim(),
                DVNo = uc.txtDVRCDNo.Text.Trim(),
                RCINo = uc.txtRCIORADA.Text.Trim()
            };

            return Factory.JEVRepository().UpdateWithCheckDisbursement(jevModel, JevAcountsModelList(), checkDisbursementsModel);
        }

        private bool UpdateCashReceiptsJournal(byte userId)
        {
            JEVModel jevModel = ParseJEVModelData(userId, true);

            var cashReceiptsJournalModel = new CashReceiptsJournalModel()
            {
                JevId = uc.jevId,
                CollectingOfficerId = Convert.ToByte(uc.cmbCollectingDisbursingOfficer.SelectedValue),
                RCDNo = uc.txtRCIORADA.Text.Trim(),
                ORNo = uc.txtRCIORADA.Text.Trim(),
                ORDate = uc.dtpCheckORPaid.Value
            };

            return Factory.JEVRepository().UpdateWithCashReceipts(jevModel, JevAcountsModelList(), cashReceiptsJournalModel);
        }

        private bool UpdateADADisbursementsJournal(byte userId)
        {
            JEVModel jevModel = ParseJEVModelData(userId, true);

            var aDADisbursementsJournalModel = new ADADisbursementsJournalModel()
            {
                JevId = uc.jevId,
                ADANumber = uc.txtRCIORADA.Text.Trim(),
                DVNo = uc.txtDVRCDNo.Text.Trim()
            };

            return Factory.JEVRepository().UpdateWithADADisbursements(jevModel, JevAcountsModelList(), aDADisbursementsJournalModel);
        }

        private bool UpdateCashDisbursementsJournal(byte userId)
        {
            JEVModel jevModel = ParseJEVModelData(userId, true);

            var cashDisbursementsJournalModel = new CashDisbursementsJournalModel()
            {
                JevId = uc.jevId,
                DisbursingOfficerId = Convert.ToInt32(uc.cmbCollectingDisbursingOfficer.SelectedValue),
                DVNo = uc.txtDVRCDNo.Text.Trim(),
                DatePaid = uc.dtpCheckORPaid.Value
            };

            return Factory.JEVRepository().UpdateWithCashDisbursements(jevModel, JevAcountsModelList(), cashDisbursementsJournalModel);
        }

        private bool UpdateGeneralJournal(byte userId)
        {
            JEVModel jevModel = ParseJEVModelData(userId, true);

            var generalJournalModel = new GeneralJournalModel()
            {
                JevId = uc.jevId,
                DVNo = uc.txtDVRCDNo.Text.Trim(),
                CheckNo = uc.txtCheckNo.Text.Trim(),
                ORNo = uc.txtRCIORADA.Text.Trim()
            };


            return Factory.JEVRepository().UpdateWithGeneralJournal(jevModel, JevAcountsModelList(), generalJournalModel);
        }

        private bool SetRemarks()
        {
            try
            {
                int jevId = ucjev1.jevId;
                var remarks = Factory.JEVRepository().SetRemarks(jevId, string.Empty);

                return remarks;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool InsertData(ref string message)
        {
            try
            {
                var userId = Helper.UserId;
                message = "JEV has been saved.";


                switch (uc.journalName)
                {
                    case "General Journal":
                        return InsertGeneralJournal(userId);

                    case "Procurement Received Journal":
                        return InsertJournal(userId);

                    case "Cash Disbursements Journal":
                        return InsertCashDisbursementsJournal(userId);

                    case "Cash Receipts Journal":
                        return InsertCashReceiptsJournal(userId);

                    case "Check Disbursements Journal":
                        return InsertCheckDisbursementJournal(userId);

                    case "Authority to Debit Account Disbursement Journal":
                        return InsertADADisbursementsJournal(userId);
                }

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }


            return false;
        }

        private bool UpdateData(ref string message)
        {
            var userId = Helper.UserId;

            using (TransactionScope scope = new TransactionScope())
            {
                bool updated = true;

                try
                {
                    string jevStatus = Factory.JEVRepository().GetJevStatus(uc.jevId);

                    if (jevStatus.ToLower() == "disapproved")
                    {
                        _ = SetJEVStatus("pending");
                        _ = SetRemarks();
                        message = "JEV has been updated and will be send back to pending.";
                    }
                    else
                        message = "JEV has been updated.";

                    switch (uc.journalName)
                    {
                        case "General Journal":
                            _ = UpdateGeneralJournal(userId);
                            break;

                        case "Procurement Received Journal":
                            _ = UpdateJournal(userId);
                            break;

                        case "Cash Disbursements Journal":
                            _ = UpdateCashDisbursementsJournal(userId);
                            break;

                        case "Cash Receipts Journal":
                            _ = UpdateCashReceiptsJournal(userId);
                            break;

                        case "Check Disbursements Journal":
                            _ = UpdateCheckDisbursementJournal(userId);
                            break;

                        case "Authority to Debit Account Disbursement Journal":
                            _ = UpdateADADisbursementsJournal(userId);
                            break;
                    }

                    if (uc.journalId != uc.oldJournalId) //CHECK IF THE PREVIOUS JOURNAL ID IS NOT EQUAL TO NEW SELECTED JOURNAL ID
                    {
                        switch (uc.oldJournalId)
                        {
                            case 1:
                                Factory.GeneralJournalRepository().DeleteGeneralJournalByJevID(uc.jevId);
                                TransferJournalToNewJournal();  //INSERT TO NEW SELECTED JOURNAL
                                break;
                            case 2:
                                Factory.CashReceiptsJournalRepository().DeleteCashReceiptsJournalByJevID(uc.jevId);
                                TransferJournalToNewJournal();  //INSERT TO NEW SELECTED JOURNAL
                                break;
                            case 3:
                                //Factory.GeneralJournalRepository().DeleteGeneralJournalByJevID(uc.jevId);
                                break;
                            case 4:
                                Factory.CashDisbursementsJournalRepository().DeleteCashDisbursementJournalByJevID(uc.jevId);
                                TransferJournalToNewJournal();  //INSERT TO NEW SELECTED JOURNAL
                                break;
                            case 5:
                                Factory.CheckDisbursementsJournalRepository().DeleteCheckDisbursementJournalByJevID(uc.jevId);
                                TransferJournalToNewJournal();  //INSERT TO NEW SELECTED JOURNAL
                                break;
                            case 6:
                                //Factory.GeneralJournalRepository().DeleteGeneralJournalByJevID(uc.jevId);
                                break;
                        }

                    }

                    scope.Complete();
                }
                catch (Exception ex)
                {
                    Helper.MessageBoxError($"{ex.Message}\n(No changes has been saved.)");
                    updated = false;
                }

                if (updated)
                    return true;
                else
                    return false;
            }

        }

        private bool SaveData(ref string message)
        {
            if (!FormValidations())
                return false;

            bool saveData;

            if (uc.isEdit)
                saveData = UpdateData(ref message);
            else
                saveData = InsertData(ref message);

            return saveData;
        }

        private bool DeleteData()
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this JEV?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var jevModel = new JEVModel();
                    jevModel.Id = uc.jevId;

                    var jevRepository = Factory.JEVRepository();
                    return jevRepository.Delete(jevModel);
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            if (SaveData(ref message))
            {
                if (!uc.isEdit)
                {
                    Helper.MessageBoxSuccess(message);
                    ucjev1.ResetForm();
                    _ucJEVDashboard.LoadJEVCounter();
                }
                else
                {
                    int jevId = uc.jevId;
                    Helper.MessageBoxSuccess(message);
                    GetJevStatus(jevId);
                    PermissionVerification();
                    _frmJEVList.LoadJEVList();
                    _ucJEVDashboard.LoadJEVCounter();
                }
            }

        }

        private void TransferJournalToNewJournal()
        {
            var userId = Helper.UserId;
            var uc = ucjev1;

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

                    Factory.GeneralJournalRepository().Insert(generalJournalModel);
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

                    Factory.CashReceiptsJournalRepository().Insert(cashReceiptsJournalModel);
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

                    Factory.CashDisbursementsJournalRepository().Insert(cashDisbursementsJournalModel);
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

                    Factory.CheckDisbursementsJournalRepository().Insert(checkDisbursementsModel);
                    return;
                case 6:
                    //DO NOTHING
                    return;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (DeleteData())
            {
                Helper.MessageBoxSuccess("JEV has been deleted.");
                _frmJEVList.LoadJEVList();
                Close();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmJEVReport _frmJEVReport = new frmJEVReport(uc.jevId, uc.jevNo, uc.journalId);
            _frmJEVReport.ShowDialog();
        }

        internal void GetJevStatus(int jevId)
        {
            try
            {
                string jevStatus = Factory.JEVRepository().GetJevStatus(jevId).ToLower();

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
                        ucjev1.Enabled = true;
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
                        ucjev1.Enabled = false;
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
                        ucjev1.Enabled = false;
                        break;
                    case "cancelled":
                        //CANCELLED
                        lblJevStatus.Text = "CANCELLED";
                        lblJevStatus.ForeColor = Color.FromArgb(66, 63, 62);
                        lblShowMessage.Visible = false;
                        btnApprove.Enabled = false;
                        btnDisapprove.Enabled = false;
                        btnCancelJEV.Enabled = false;
                        btnPrint.Enabled = false;
                        btnSave.Enabled = false;
                        btnDelete.Enabled = false;
                        ucjev1.Enabled = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private bool SetJEVStatus(string status)
        {
            try
            {
                var userId = Helper.UserId;

                if (!FormValidations())
                    return false;

                return Factory.JEVRepository().SetJEVStatus(uc.jevId, status);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                if (uc.isEdit)
                {
                    if (SetJEVStatus("approve"))
                    {
                        Helper.MessageBoxSuccess("JEV has been approved.");
                        GetJevStatus(uc.jevId);
                        _frmJEVList.LoadJEVList();
                        _ucJEVDashboard.LoadJEVCounter();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError($"{ex.Message}\n(No changes has been saved.)");
            }
        }

        private void btnDisapprove_Click(object sender, EventArgs e)
        {
            if (uc.jevId != 0)
            {
                var frmRemarks = new frmJEVDisapproval(this);
                frmRemarks.btnDisapprove.Visible = true;
                frmRemarks.btnAccept.Visible = false;
                frmRemarks.btnSaveMessage.Visible = false;
                frmRemarks.ShowDialog();
            }
        }

        private void lblShowMessage_Click(object sender, EventArgs e)
        {
            if (uc.jevId != 0)
            {
                var frmRemarks = new frmJEVDisapproval(this);
                frmRemarks.btnDisapprove.Visible = false;
                frmRemarks.btnCancel.Text = "Close";
                frmRemarks.ShowDialog();
            }
        }

        private void btnCancelJEV_Click(object sender, EventArgs e)
        {
            try
            {
                if (uc.jevId != 0)
                {
                    if (MessageBox.Show("Confirm cancellation of JEV.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        if (SetJEVStatus("cancel"))
                        {
                            Helper.MessageBoxSuccess("JEV has been cancelled.");
                            GetJevStatus(uc.jevId);
                            _frmJEVList.LoadJEVList();
                            _ucJEVDashboard.LoadJEVCounter();
                        }
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError($"{ex.Message}\n(No changes has been saved.)");
            }
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
            DataTable dtJEV = Factory.JEVAccountsRepository().GetViewRecordsByJevId(uc.jevId);

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
            var checkDisbursementsRepository = Factory.CheckDisbursementsJournalRepository();

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
            var cashReceiptsJournalRepository = Factory.CashReceiptsJournalRepository();

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
            var aDADisbursementsJournalRepository = Factory.ADADisbursementsJournalRepository();

            if (aDADisbursementsJournalRepository.JevIdExist(jevId))
            {
                Dictionary<string, string> adaDisbursementsDict = aDADisbursementsJournalRepository.GetViewRecordByJevID(jevId);

                uc.txtDVRCDNo.Text = adaDisbursementsDict["dv_no"];
                uc.txtRCIORADA.Text = adaDisbursementsDict["ada_no"];
            }
        }

        private void LoadCashDisbursementDataIfExist(int jevId)
        {
            var cashDisbursementsJournalRepository = Factory.CashDisbursementsJournalRepository();

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
            var generalJournalRepository = Factory.GeneralJournalRepository();

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
            try
            {
                Cursor = Cursors.WaitCursor;
                Enabled = true;
                Dictionary<string, string> jevDict = Factory.JEVRepository().GetViewRecordByJEVId(jevId);

                LoadCheckDisbursementsDataIfExist(uc.jevId);
                LoadCashReceiptsDataIfExist(uc.jevId);
                LoadADADisbursementDataIfExist(uc.jevId);
                LoadCashDisbursementDataIfExist(uc.jevId);
                LoadGeneralJournalDataIfExist(uc.jevId);

                uc.jevId = Convert.ToInt32(jevDict["id"]);
                uc.fundId = Convert.ToByte(jevDict["funds_id"]);
                uc.txtExplanation.Text = jevDict["explanation"];
                uc.dtpDateEntry.Value = Convert.ToDateTime(jevDict["date_entry"]);
                uc.txtRefNo.Text = jevDict["ref_no"];
                uc.txtPayee.Text = jevDict["payee"];

                uc.journalId = Convert.ToByte(jevDict["journals_id"]);
                uc.oldJournalId = Convert.ToByte(jevDict["journals_id"]);
                lblCreatedBy.Text = jevDict["created_by_name"];



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

                btnSave.Text = "&Update";

                Cursor = Cursors.Default;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
