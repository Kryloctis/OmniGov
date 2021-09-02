using ACC.Domain.Models;
using AccountingSystem.Views.Reports.JEV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.JEV
{
    public partial class frmJEV : Form
    {
        ucJEV uc;

        public frmJEV()
        {
            InitializeComponent();
            uc = ucjev1;
            Helper.LoadFormIcon(this);
        }

        private void frmJEV_Load(object sender, EventArgs e)
        {
            if (!Helper.HasPermission("JEV Approval"))
            {
                btnApprove.Visible = false;
                btnDisapprove.Visible = false;
                btnCancelJEV.Visible = false;
                toolStripSeparator2.Visible = false;
            }

            if (!Helper.HasPermission("Report JEVs"))
            {
                btnPrint.Visible = false;
                toolStripSeparator3.Visible = false;
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

            if (isUpdate) jevModel.Id = uc.jevId;

            jevModel.FundsId = uc.fundId;
            jevModel.JournalsId = uc.journalId;
            jevModel.JEVNumber = jevNo;
            jevModel.DateEntry = uc.dtpDateEntry.Value;
            jevModel.RefNo = uc.txtRefNo.Text.Trim();
            jevModel.Payee = uc.txtPayee.Text.Trim();
            jevModel.Explanation = uc.txtExplanation.Text.Trim();


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


        private bool InsertData()
        {
            try
            {
                var userId = Helper.UserId;

                if (!FormValidations())
                    return false;

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

        private bool UpdateData()
        {
            try
            {
                var userId = Helper.UserId;

                // validate form
                if (uc.fundId == 0 || uc.journalId == 0 || !uc.ValidateChildren() || uc.dgAccounts.Rows.Count == 0)
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                if (uc.txtDebitTotal.Text != uc.txtCreditTotal.Text)
                {
                    Helper.MessageBoxError("Debit & Credit amounts must be equal.");
                    return false;
                }

                if (uc.isDisapproved == 1)
                {
                    return SetJEVStatus(0);
                }


                switch (uc.journalName)
                {
                    case "General Journal":
                        return UpdateGeneralJournal(userId);

                    case "Procurement Received Journal":
                        return UpdateJournal(userId);

                    case "Cash Disbursements Journal":
                        return UpdateCashDisbursementsJournal(userId);

                    case "Cash Receipts Journal":
                        return UpdateCashReceiptsJournal(userId);

                    case "Check Disbursements Journal":
                        return UpdateCheckDisbursementJournal(userId);

                    case "Authority to Debit Account Disbursement Journal":
                        return UpdateADADisbursementsJournal(userId);
                }

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.StackTrace);
            }

            return false;
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (uc.jevId == 0)
            {
                if (InsertData())
                {
                    Helper.MessageBoxSuccess("JEV has been saved.");
                    ucjev1.ResetForm();
                }
                return;
            }

            if (UpdateData())
            {
                string message = uc.isDisapproved == 1 ? "This JEV will be send back to pending." : "JEV has been saved.";

                Helper.MessageBoxSuccess(message);
                CheckJevStatus(uc.jevId);

                if (uc.journalId != uc.oldJournalId) //CHECK IF THE PREVIOUS JOURNAL ID IS NOT EQUAL TO NEW SELECTED JOURNAL ID
                {
                    switch (uc.oldJournalId)
                    {
                        case 1:
                            Factory.GeneralJournalRepository().DeleteGeneralJournalByJevID(uc.jevId);
                            TransferJournalToNewJournal();  //INSERT TO NEW SELECTED JOURNAL
                            return;
                        case 2:
                            Factory.CashReceiptsJournalRepository().DeleteCashReceiptsJournalByJevID(uc.jevId);
                            TransferJournalToNewJournal();  //INSERT TO NEW SELECTED JOURNAL
                            return;
                        case 3:
                            //Factory.GeneralJournalRepository().DeleteGeneralJournalByJevID(uc.jevId);
                            return;
                        case 4:
                            Factory.CashDisbursementsJournalRepository().DeleteCashDisbursementJournalByJevID(uc.jevId);
                            TransferJournalToNewJournal();  //INSERT TO NEW SELECTED JOURNAL
                            return;
                        case 5:
                            Factory.CheckDisbursementsJournalRepository().DeleteCheckDisbursementJournalByJevID(uc.jevId);
                            TransferJournalToNewJournal();  //INSERT TO NEW SELECTED JOURNAL
                            return;
                        case 6:
                            //Factory.GeneralJournalRepository().DeleteGeneralJournalByJevID(uc.jevId);
                            return;
                    }

                }
                return;
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

        internal void ResetForm()
        {
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnApprove.Enabled = false;
            btnDisapprove.Enabled = false;
            btnCancelJEV.Enabled = false;
            btnPrint.Enabled = false;
            btnSave.Text = "Save";

            uc.Enabled = true;
            lblJevStatus.ForeColor = Color.Black;
            lblJevStatus.Text = "--";
            lblShowMessage.Visible = false;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ResetForm();
            uc.ResetForm();
        }

        internal void BtnSearch_Click(object sender, EventArgs e)
        {
            var frmJevSearch = new frmJEVSearch(this);
            frmJevSearch.cmbxJevStatus.SelectedIndex = 0;
            frmJevSearch.ShowDialog();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var jevModel = new JEVModel();
                    jevModel.Id = uc.jevId;

                    var jevRepository = Factory.JEVRepository();
                    _ = jevRepository.Delete(jevModel);
                    ResetForm();
                    uc.ResetForm();
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            _ = new frmJEVReport(uc.jevId, uc.jevNo, uc.journalId).ShowDialog();
        }

        //CHECK JEV STATUS
        internal void CheckJevStatus(int jevId)
        {
            switch (Factory.JEVRepository().GetJevStatus(jevId))
            {
                case 0:
                    //PENDING
                    lblJevStatus.Text = "PENDING";
                    lblJevStatus.ForeColor = Color.DarkGoldenrod;
                    lblShowMessage.Visible = false;
                    btnPrint.Enabled = false;
                    btnApprove.Enabled = true;
                    btnDisapprove.Enabled = true;
                    btnCancelJEV.Enabled = true;
                    btnDelete.Enabled = true;
                    ucjev1.Enabled = true;
                    btnSave.Enabled = true;
                    break;
                case 1:
                    //APPROVED
                    lblJevStatus.Text = "APPROVED";
                    lblJevStatus.ForeColor = System.Drawing.Color.Green;
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
                case 2:
                    //DISSAPROVED
                    lblJevStatus.Text = "DISAPPROVED";
                    lblJevStatus.ForeColor = Color.Firebrick;
                    lblShowMessage.Visible = true;
                    btnDisapprove.Enabled = false;
                    btnCancelJEV.Enabled = true;
                    btnPrint.Enabled = false;
                    btnSave.Enabled = false;
                    btnDelete.Enabled = false;
                    ucjev1.Enabled = false;
                    break;
                case 3:
                    //CANCELLED
                    lblJevStatus.Text = "CANCELLED";
                    lblJevStatus.ForeColor = Color.Firebrick;
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

        //Set JEV Status
        private bool SetJEVStatus(byte jevStatus)
        {
            try
            {
                var userId = Helper.UserId;

                if (!FormValidations())
                    return false;

                var status = Factory.JEVRepository().SetJEVStatus(uc.jevId, jevStatus);

                return status;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return false;
        }

        //APPROVE
        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (uc.jevId != 0)
            {
                if (MessageBox.Show("Are you sure you want to approved this JEV?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (SetJEVStatus(1))
                    {
                        Helper.MessageBoxSuccess("JEV has been approved.");
                        CheckJevStatus(uc.jevId);
                    }
                    return;
                }

            }
        }

        //DISAPPROVE
        private void btnDisapprove_Click(object sender, EventArgs e)
        {
            if (uc.jevId != 0)
            {
                var frmRemarks = new frmRemarks(this);
                frmRemarks.isDissaprove = true;
                frmRemarks.btnAccept.Text = "Disapprove";
                frmRemarks.ShowDialog();
            }
        }

        private void lblShowMessage_Click(object sender, EventArgs e)
        {
            var frmRemarks = new frmRemarks(this);
            if (ucjev1.Enabled)
            {
                frmRemarks.btnAccept.Visible = false;
                frmRemarks.btnCancel.Text = "Close";
            }
            frmRemarks.ShowDialog();

        }

        //CANCEL
        private void btnCancelJEV_Click(object sender, EventArgs e)
        {
            if (uc.jevId != 0)
            {
                if (MessageBox.Show("Are you sure you want to cancel this JEV?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (SetJEVStatus(3))
                    {
                        Helper.MessageBoxSuccess("JEV has been cancelled.");
                        CheckJevStatus(uc.jevId);
                    }
                    return;
                }

            }
        }

    }
}
