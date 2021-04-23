using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACC.Domain.Models;

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
            this.btnDelete.Click += new EventHandler(this.BtnDelete_Click);
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
                var user = Helper.GetLoggedInUser();
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
                    case "Procurement Received Journal":
                    case "Cash Disbursements Journal":
                        return InsertJournal(user, uc);

                    case "Cash Receipts Journal":
                        return InsertCashReceiptsJournal(user, uc);
                    case "Check Disbursements Journal":
                        return InsertCheckDisbursementJournal(user, uc);

                    case "Advice to Debit Account Disbursement Journal":
                        return InsertADADisbursementsJournal(user, uc);
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return false;
        }

        private static JEVModel ParseJEVModelData(Dictionary<string, string> user, ucJEV uc, bool isUpdate = false)
        {
            string jevNo = $"{uc.txtFundsJevNo.Text}-{uc.txtJEVNo.Text.Trim()}";
            var jevModel = new JEVModel();

            if (isUpdate) jevModel.Id = uc.jevId;

            jevModel.FundsId = uc.fundId;
            jevModel.JournalsId = uc.journalId;
            jevModel.JEVNumber = jevNo;
            jevModel.DateEntry = uc.dtpDateEntry.Value;
            jevModel.Explanation = uc.txtExplanation.Text.Trim();

            if (!isUpdate)
                jevModel.CreatedBy = Convert.ToByte(user["id"]);
            else
                jevModel.UpdatedBy = Convert.ToByte(user["id"]);

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

        private bool InsertJournal(Dictionary<string, string> user, ucJEV uc)
        {
            JEVModel jevModel = ParseJEVModelData(user, uc);

            return Factory.JEVRepository().Insert(jevModel, JevAcountsModelList());
        }

        private bool InsertCheckDisbursementJournal(Dictionary<string, string> user, ucJEV uc)
        {
            JEVModel jevModel = ParseJEVModelData(user, uc);

            var checkDisbursementsModel = new CheckDisbursementsJournalModel()
            {
                CheckNumber = uc.txtRCIORADA.Text.Trim(),
                Payee = uc.txtPayee.Text.Trim()
            };

            return Factory.JEVRepository().InsertWithCheckDisbursement(jevModel, JevAcountsModelList(), checkDisbursementsModel);
        }

        private bool InsertCashReceiptsJournal(Dictionary<string, string> user, ucJEV uc)
        {
            JEVModel jevModel = ParseJEVModelData(user, uc);

            var cashReceiptsJournalModel = new CashReceiptsJournalModel()
            {

                CollectingOfficerId = Convert.ToByte(uc.cmbCollectingOfficer.SelectedValue),
                RCDNumber = uc.txtRCIORADA.Text.Trim()
            };

            return Factory.JEVRepository().InsertWithCashReceipts(jevModel, JevAcountsModelList(), cashReceiptsJournalModel);
        }

        private bool InsertADADisbursementsJournal(Dictionary<string, string> user, ucJEV uc)
        {
            JEVModel jevModel = ParseJEVModelData(user, uc);

            var aDADisbursementsJournalModel = new ADADisbursementsJournalModel()
            {
                ADANumber = uc.txtRCIORADA.Text.Trim()
            };

            return Factory.JEVRepository().InsertWithADADisbursements(jevModel, JevAcountsModelList(), aDADisbursementsJournalModel);
        }

        private bool UpdateJournal(Dictionary<string, string> user, ucJEV uc)
        {
            JEVModel jevModel = ParseJEVModelData(user, uc, true);

            return Factory.JEVRepository().Update(jevModel, JevAcountsModelList());
        }

        private bool UpdateCheckDisbursementJournal(Dictionary<string, string> user, ucJEV uc)
        {
            JEVModel jevModel = ParseJEVModelData(user, uc, true);

            var checkDisbursementsModel = new CheckDisbursementsJournalModel()
            {
                JevId = uc.jevId,
                CheckNumber = uc.txtRCIORADA.Text.Trim(),
                Payee = uc.txtPayee.Text.Trim()
            };

            return Factory.JEVRepository().UpdateWithCheckDisbursement(jevModel, JevAcountsModelList(), checkDisbursementsModel);
        }

        private bool UpdateCashReceiptsJournal(Dictionary<string, string> user, ucJEV uc)
        {
            JEVModel jevModel = ParseJEVModelData(user, uc, true);

            var cashReceiptsJournalModel = new CashReceiptsJournalModel()
            {
                JevId = uc.jevId,
                CollectingOfficerId = Convert.ToByte(uc.cmbCollectingOfficer.SelectedValue),
                RCDNumber = uc.txtRCIORADA.Text.Trim()
            };

            return Factory.JEVRepository().UpdateWithCashReceipts(jevModel, JevAcountsModelList(), cashReceiptsJournalModel);
        }

        private bool UpdateData()
        {
            try
            {
                var user = Helper.GetLoggedInUser();
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
                    case "Procurement Received Journal":
                    case "Cash Disbursements Journal":
                        return UpdateJournal(user, uc);

                    case "Cash Receipts Journal":
                        return UpdateCashReceiptsJournal(user, uc);

                    case "Check Disbursements Journal":
                        return UpdateCheckDisbursementJournal(user, uc);

                    case "Advice to Debit Account Disbursement Journal":
                        break;
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
    }
}
