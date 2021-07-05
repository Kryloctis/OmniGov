using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ACC.Domain.Models;
using AccountingSystem.Views.Reports.JEV;

namespace AccountingSystem.Views.Transactions.JEV
{
    public partial class frmJEV : Form
    {
        public frmJEV()
        {
            InitializeComponent();
        }

        private void frmJEV_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);

            btnDelete.Click += new EventHandler(this.BtnDelete_Click);
        }

        private static ushort? ValidateNullSubsidiary(object subsidiaryCellValue)
        {
            if (subsidiaryCellValue != null)
            {
                return Convert.ToUInt16(subsidiaryCellValue);
            }

            return null;
        }

        private bool SaveData()
        {
            try
            {
                var userId = Helper.UserId;
                var uc = ucjev1;

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

                switch (uc.journalName)
                {
                    case "General Journal":
                        return InsertGeneralJournal(userId, uc);

                    case "Procurement Received Journal":
                        return InsertJournal(userId, uc);

                    case "Cash Disbursements Journal":
                        return InsertCashDisbursementsJournal(userId, uc);

                    case "Cash Receipts Journal":
                        return InsertCashReceiptsJournal(userId, uc);

                    case "Check Disbursements Journal":
                        return InsertCheckDisbursementJournal(userId, uc);

                    case "Authority to Debit Account Disbursement Journal":
                        return InsertADADisbursementsJournal(userId, uc);
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return false;
        }

        private static JEVModel ParseJEVModelData(byte userId, ucJEV uc, bool isUpdate = false)
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
            jevModel.IsApproved = true;

            if (!isUpdate)
                jevModel.CreatedBy = userId;
            else
                jevModel.UpdatedBy = userId;

            return jevModel;
        }

        private List<JEVAccountsModel> JevAcountsModelList()
        {
            var uc = ucjev1;
            var jevAccountsModelList = new List<JEVAccountsModel>();
            foreach (DataGridViewRow item in uc.dgAccounts.Rows)
            {
                int fppId = Convert.ToInt32(item.Cells["FPPId"].Value);
                ushort generalLedgerId = Convert.ToUInt16(item.Cells["GeneralLedgerId"].Value);
                ushort? subsidiaryLedgerId = ValidateNullSubsidiary(item.Cells["SubsidiaryLedgerId"].Value);
                bool isDebit = Convert.ToBoolean(item.Cells["IsDebit"].Value);
                bool? isDeposit = (bool?)item.Cells["IsDeposit"].Value;

                decimal amount;
                if (isDebit)
                    amount = Convert.ToDecimal(item.Cells["Debit"].Value);
                else
                    amount = Convert.ToDecimal(item.Cells["Credit"].Value);

                var jevAccountModel = new JEVAccountsModel()
                {
                    FPPId = fppId,
                    GeneralLedgerId = generalLedgerId,
                    SubsidiaryLedgerId = subsidiaryLedgerId,
                    IsDeposit = isDeposit,
                    IsDebit = isDebit,
                    Amount = amount
                };

                jevAccountsModelList.Add(jevAccountModel);
            }

            return jevAccountsModelList;
        }

        private bool InsertJournal(byte userId, ucJEV uc)
        {
            JEVModel jevModel = ParseJEVModelData(userId, uc);

            return Factory.JEVRepository().Insert(jevModel, JevAcountsModelList());
        }

        private bool InsertCheckDisbursementJournal(byte userId, ucJEV uc)
        {
            JEVModel jevModel = ParseJEVModelData(userId, uc);

            var checkDisbursementsModel = new CheckDisbursementsJournalModel()
            {
                CheckDate = uc.dtpCheckORPaid.Value,
                CheckNo = uc.txtCheckNo.Text.Trim(),
                DVNo = uc.txtDVRCDNo.Text.Trim(),
                RCINo = uc.txtRCIORADA.Text.Trim()
            };

            return Factory.JEVRepository().InsertWithCheckDisbursement(jevModel, JevAcountsModelList(), checkDisbursementsModel);
        }

        private bool InsertCashReceiptsJournal(byte userId, ucJEV uc)
        {
            JEVModel jevModel = ParseJEVModelData(userId, uc);

            var cashReceiptsJournalModel = new CashReceiptsJournalModel()
            {
                CollectingOfficerId = Convert.ToByte(uc.cmbCollectingDisbursingOfficer.SelectedValue),
                RCDNo = uc.txtDVRCDNo.Text.Trim(),
                ORNo = uc.txtRCIORADA.Text.Trim(),
                ORDate = uc.dtpCheckORPaid.Value
            };

            return Factory.JEVRepository().InsertWithCashReceipts(jevModel, JevAcountsModelList(), cashReceiptsJournalModel);
        }

        private bool InsertADADisbursementsJournal(byte userId, ucJEV uc)
        {
            JEVModel jevModel = ParseJEVModelData(userId, uc);

            var aDADisbursementsJournalModel = new ADADisbursementsJournalModel()
            {
                ADANumber = uc.txtRCIORADA.Text.Trim(),
                DVNo = uc.txtDVRCDNo.Text.Trim()
            };

            return Factory.JEVRepository().InsertWithADADisbursements(jevModel, JevAcountsModelList(), aDADisbursementsJournalModel);
        }

        private bool InsertCashDisbursementsJournal(byte userId, ucJEV uc)
        {
            JEVModel jevModel = ParseJEVModelData(userId, uc);

            var cashDisbursementsJournalModel = new CashDisbursementsJournalModel()
            {
                DisbursingOfficerId = Convert.ToInt32(uc.cmbCollectingDisbursingOfficer.SelectedValue),
                DVNo = uc.txtDVRCDNo.Text.Trim(),
                DatePaid = uc.dtpCheckORPaid.Value
            };

            return Factory.JEVRepository().InsertWithCashDisbursements(jevModel, JevAcountsModelList(), cashDisbursementsJournalModel);
        }

        private bool InsertGeneralJournal(byte userId, ucJEV uc)
        {
            JEVModel jevModel = ParseJEVModelData(userId, uc);

            var generalJournalModel = new GeneralJournalModel()
            {
                DVNo = uc.txtDVRCDNo.Text.Trim(),
                CheckNo = uc.txtCheckNo.Text.Trim(),
                ORNo = uc.txtRCIORADA.Text.Trim()
            };

            return Factory.JEVRepository().InsertWithGeneralJournal(jevModel, JevAcountsModelList(), generalJournalModel);
        }

        private bool UpdateJournal(byte userId, ucJEV uc)
        {
            JEVModel jevModel = ParseJEVModelData(userId, uc, true);

            return Factory.JEVRepository().Update(jevModel, JevAcountsModelList());
        }

        private bool UpdateCheckDisbursementJournal(byte userId, ucJEV uc)
        {
            JEVModel jevModel = ParseJEVModelData(userId, uc, true);

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

        private bool UpdateCashReceiptsJournal(byte userId, ucJEV uc)
        {
            JEVModel jevModel = ParseJEVModelData(userId, uc, true);

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

        private bool UpdateADADisbursementsJournal(byte userId, ucJEV uc)
        {
            JEVModel jevModel = ParseJEVModelData(userId, uc, true);

            var aDADisbursementsJournalModel = new ADADisbursementsJournalModel()
            {
                JevId = uc.jevId,
                ADANumber = uc.txtRCIORADA.Text.Trim(),
                DVNo = uc.txtDVRCDNo.Text.Trim()
            };

            return Factory.JEVRepository().UpdateWithADADisbursements(jevModel, JevAcountsModelList(), aDADisbursementsJournalModel);
        }

        private bool UpdateCashDisbursementsJournal(byte userId, ucJEV uc)
        {
            JEVModel jevModel = ParseJEVModelData(userId, uc, true);

            var cashDisbursementsJournalModel = new CashDisbursementsJournalModel()
            {
                JevId = uc.jevId,
                DisbursingOfficerId = Convert.ToInt32(uc.cmbCollectingDisbursingOfficer.SelectedValue),
                DVNo = uc.txtDVRCDNo.Text.Trim(),
                DatePaid = uc.dtpCheckORPaid.Value
            };

            return Factory.JEVRepository().UpdateWithCashDisbursements(jevModel, JevAcountsModelList(), cashDisbursementsJournalModel);
        }

        private bool UpdateGeneralJournal(byte userId, ucJEV uc)
        {
            JEVModel jevModel = ParseJEVModelData(userId, uc, true);

            var generalJournalModel = new GeneralJournalModel()
            {
                JevId = uc.jevId,
                DVNo = uc.txtDVRCDNo.Text.Trim(),
                CheckNo = uc.txtCheckNo.Text.Trim(),
                ORNo = uc.txtRCIORADA.Text.Trim()
            };


            return Factory.JEVRepository().UpdateWithGeneralJournal(jevModel, JevAcountsModelList(), generalJournalModel);
        }

        private bool UpdateData()
        {
            try
            {
                var userId = Helper.UserId;
                var uc = ucjev1;

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

                switch (uc.journalName)
                {
                    case "General Journal":
                        return UpdateGeneralJournal(userId, uc);

                    case "Procurement Received Journal":
                        return UpdateJournal(userId, uc);

                    case "Cash Disbursements Journal":
                        return UpdateCashDisbursementsJournal(userId, uc);

                    case "Cash Receipts Journal":
                        return UpdateCashReceiptsJournal(userId, uc);

                    case "Check Disbursements Journal":
                        return UpdateCheckDisbursementJournal(userId, uc);

                    case "Authority to Debit Account Disbursement Journal":
                        return UpdateADADisbursementsJournal(userId, uc);
                }


                if (uc.journalId != uc.oldJournalId)
                {

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
            var uc = ucjev1;
            if (uc.jevId == 0)
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("JEV has been saved.");
                    ucjev1.ResetForm();
                }
                return;
            }

            if (UpdateData())
            {
                Helper.MessageBoxSuccess("JEV has been saved.");

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
                    JEVModel jevModel = ParseJEVModelData(userId, uc);
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

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var uc = ucjev1;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            uc.Enabled = true;
            uc.ResetForm();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            _ = new frmJEVSearch(this).ShowDialog();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var uc = ucjev1;
                if (MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var jevModel = new JEVModel();
                    jevModel.Id = uc.jevId;

                    var jevRepository = Factory.JEVRepository();
                    _ = jevRepository.Delete(jevModel);
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
            var uc =  ucjev1;
            _ = new frmJEVReport(uc.jevId, uc.jevNo, uc.journalId).ShowDialog();
        }
    }
}
