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
            Helper.LoadFormIconAccounting(this);
            this.btnDelete.Click += new EventHandler(this.BtnDelete_Click);
        }

        private ushort? ValidateNullSubsidiary(object subsidiaryCellValue)
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
                var user = Helper.GetLoggedInUserAccounting();
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
                        return SaveJournal(user, uc);

                    case "Cash Receipts Journal":
                        break;
                    case "Check Disbursements Journal":
                        return SaveCheckDisbursementJournal(user, uc);

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

        private static JEVModel ParseJEVModelData(Dictionary<string, string> user, ucJEV uc)
        {
            string jevNo = $"{uc.txtFundsJevNo.Text}-{uc.txtJEVNo.Text.Trim()}";
            var jevModel = new JEVModel()
            {
                FundsId = uc.fundId,
                JournalsId = uc.journalId,
                JEVNumber = jevNo,
                DateEntry = uc.dtpDateEntry.Value,
                Explanation = uc.txtExplanation.Text.Trim(),
                CreatedBy = Convert.ToByte(user["id"])
            };

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

        private bool SaveJournal(Dictionary<string, string> user, ucJEV uc)
        {
            JEVModel jevModel = ParseJEVModelData(user, uc);

            return Factory.JEVRepository().Insert(jevModel, JevAcountsModelList());
        }

        private bool SaveCheckDisbursementJournal(Dictionary<string, string> user, ucJEV uc)
        {
            JEVModel jevModel = ParseJEVModelData(user, uc);

            var checkDisbursementsModel = new CheckDisbursementsJournalModel()
            {
                CheckNumber = uc.txtRefNo.Text.Trim(),
                Payee = uc.txtPayeeCollectingOfficer.Text.Trim()
            };

            return Factory.JEVRepository().InsertWithCheckDisbursement(jevModel, JevAcountsModelList(), checkDisbursementsModel);
        }

        private bool UpadateData()
        {
            try
            {
                var user = Helper.GetLoggedInUserAccounting();
                var uc = ucjev1;

                // if no fund or journal selected, show error
                if (uc.fundId == 0 || uc.journalId == 0)
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                // if error occurs, show messagebox error
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                // if no rows in accounts datagrid, show error
                if (uc.dgAccounts.Rows.Count == 0)
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                if (uc.txtDebitTotal.Text != uc.txtCreditTotal.Text)
                {
                    Helper.MessageBoxError("Debit & Credit amounts must be equal.");
                    return false;
                }

                string jevNo = $"{uc.txtFundsJevNo.Text}-{uc.txtJEVNo.Text.Trim()}";
                var jevModel = new JEVModel()
                {
                    Id = uc.jevId,
                    FundsId = uc.fundId,
                    JournalsId = uc.journalId,
                    JEVNumber = jevNo,
                    DateEntry = uc.dtpDateEntry.Value,
                    Explanation = uc.txtExplanation.Text.Trim(),
                    UpdatedBy = Convert.ToByte(user["id"])
                };

                return Factory.JEVRepository().Update(jevModel, JevAcountsModelList());
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

            if (UpadateData())
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
