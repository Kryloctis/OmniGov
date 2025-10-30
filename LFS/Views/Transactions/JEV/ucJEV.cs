using ACC.Data;
using ACC.Domain.Models;
using LFS.Helpers;
using LFS.Views.Dashboard;
using LFS.Views.Reports.Journals;
using LFS.Views.Transactions.JEV.JournalForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LFS.Views.Transactions.JEV
{
    public partial class ucJev : UserControl
    {
        private bool isEdit;
        private int? jevId;

        private ucGenJrnl ucGenJrnl;
        private ucCshDsbrsmntJrnl ucCshDsbrsmntJrnl;
        private ucChkDsbrsmntJrnl ucChkDsbrsmntJrnl;
        private ucCshRcptsJrnl ucCshRcptsJrnl;
        private ucAuthDbtAccDsbrsmntJrnl ucAuthDbtAccDsbrsmntJrnl;

        public ucJev()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgAccounts, true);

            ucGenJrnl = ucGenJrnl1;
            ucCshDsbrsmntJrnl = ucCshDsbrsmntJrnl1;
            ucChkDsbrsmntJrnl = ucChkDsbrsmntJrnl1;
            ucCshRcptsJrnl = ucCshRcptsJrnl1;
            ucAuthDbtAccDsbrsmntJrnl = ucAuthDbtAccDsbrsmntJrnl1;
        }

        internal void LoadJournals()
        {
            var dtJournals = AccFactory.JournalsRepository().GetRecords();
            HelperLoadRecords.ComboboxJournals(dtJournals, cmbxJournal, "id", "journal_name");
        }

        private void SetCashReceiptsJournalFields()
        {
            dgAccounts.Columns["IsDeposit"].Visible = true;
            dgAccounts.Rows.Clear();
        }

        #region Models

        private JevModel JevModel()
        {
            var model = new JevModel();

            bool fundValid = int.TryParse(cmbxFunds.SelectedValue.ToString(), out int fundId);
            model.FundsId = (byte)fundId;

            bool journalValid = int.TryParse(cmbxJournal.SelectedValue.ToString(), out int journalId);
            model.JournalsId = (byte)journalId;

            model.DateEntry = dtpDateEntry.Value;
            model.RefNo = txtRefNo.Text.Trim();
            model.Payee = txtPayee.Text.Trim();
            model.Explanation = txtExplanation.Text.Trim();

            if (isEdit)
            {
                model.Id = jevId.Value;
                model.UpdatedBy = (byte)UserHelper.loggedUser.Id;
            }
            else
                model.CreatedBy = (byte)UserHelper.loggedUser.Id;

            //Verify User Privileges
            if (PrivilegesHelper.HasPrivilege(Privileges.TransJEVApproved))
            {
                model.IsApproved = true;
                model.JEVNumber = GetJEVSeriesNo();
            }

            return model;
        }

        private static ushort? ValidateNullSubsidiary(object subsidiaryCellValue)
        {
            if (subsidiaryCellValue != null)
                return Convert.ToUInt16(subsidiaryCellValue);

            return null;
        }

        private List<JEVAccountsModel> JevAcountsModelList()
        {
            var jevAccountsModelList = new List<JEVAccountsModel>();
            foreach (DataGridViewRow item in dgAccounts.Rows)
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

        internal (JevModel JevModel, List<JEVAccountsModel> jEVAccountsModels, GeneralJournalModel GeneralJournalModel) JevGenJrnlModels()
        {
            return (JevModel(), JevAcountsModelList(), ucGenJrnl.GeneralJournalModel());
        }

        internal (JevModel JevModel, List<JEVAccountsModel> jEVAccountsModels, CashReceiptsJournalModel CashReceiptsJournalModel) JevCshRcptsJrnlModels()
        {
            return (JevModel(), JevAcountsModelList(), ucCshRcptsJrnl.CashReceiptsJournalModel());
        }

        internal (JevModel JevModel, List<JEVAccountsModel> jEVAccountsModels, CashDisbursementsJournalModel CashDisbursementsJournalModel) JevCshDsbrsmntJrnlModels()
        {
            return (JevModel(), JevAcountsModelList(), ucCshDsbrsmntJrnl.CashDisbursementsJournalModel());
        }

        internal (JevModel JevModel, List<JEVAccountsModel> jEVAccountsModels, CheckDisbursementsJournalModel CheckDisbursementsJournalModel) JevChkDsbrsmntJrnlModels()
        {
            return (JevModel(), JevAcountsModelList(), ucChkDsbrsmntJrnl.CheckDisbursementsJournalModel());
        }

        internal (JevModel JevModel, List<JEVAccountsModel> jEVAccountsModels, ADADisbursementsJournalModel ADADisbursementsJournalModel) JevAuthDbtAccDsbrsmntModels()
        {
            return (JevModel(), JevAcountsModelList(), ucAuthDbtAccDsbrsmntJrnl.ADADisbursementsJournalModel());
        }

        internal (JevModel JevModel, List<JEVAccountsModel> jevAccountsModels) JevProcurementRcvJrnl()
        {
            return (JevModel(), JevAcountsModelList());
        }

        #endregion Models

        internal void OnLoad(bool isEdit, int? jevId)
        {
            LoadFunds();
            LoadJournals();

            if (isEdit)
            {
                this.jevId = jevId;
                LoadSelectedJEV(jevId.Value);
            }
        }

        internal void SetJevReadOnly(bool isReadOnly)
        {
            foreach (DateTimePicker dateTimePicker in Controls.OfType<DateTimePicker>())
            {
                dateTimePicker.Enabled = !isReadOnly;
            }

            foreach (Button button in Controls.OfType<Button>())
            {
                button.Enabled = !isReadOnly;
            }

            foreach (TextBox textBox in Controls.OfType<TextBox>())
            {
                textBox.ReadOnly = isReadOnly;
            }

            cmbxJournal.Enabled = !isReadOnly;
            cmbxFunds.Enabled = !isReadOnly;
            //btnAddAccount.Enabled = !isReadOnly;
            //btnEditAccount.Enabled = !isReadOnly;
            //btnRemoveAccount.Enabled = !isReadOnly;
            //cmbCollectingDisbursingOfficer.Enabled = !isReadOnly;

            if (isReadOnly)
                dgAccounts.SelectionChanged -= new EventHandler(dgAccounts_SelectionChanged);
            else
                dgAccounts.SelectionChanged += new EventHandler(dgAccounts_SelectionChanged);
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(cmbxJournal),
                errorProvider1.GetError(cmbxFunds),
                errorProvider1.GetError(txtJevNo),
                dgAccounts.Rows.Count < 1 ? "Please add a FPP, account & amount in the table provided." : string.Empty,
                errorProvider1.GetError(txtPayee),
                errorProvider1.GetError(txtExplanation),
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            txtJevNo.Text = string.Empty;
            txtRefNo.Text = string.Empty;
            txtPayee.Text = string.Empty;
            txtExplanation.Text = string.Empty;

            dgAccounts.Rows.Clear();
            tlStrpLblDebit.Text = 0.ToString("N2");
            tlStrpLblCredit.Text = 0.ToString("N2");
            LoadJournals();
            LoadFunds();

            dtpDateEntry.Value = DateTime.Now;
        }

        internal void LoadFunds()
        {
            var dtFunds = AccFactory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "id", "fund_name");
        }

        internal string GetJEVSeriesNo()
        {
            try
            {
                bool fundValid = int.TryParse(cmbxFunds.SelectedValue.ToString(), out int fundId);
                var jev = AccFactory.JEVRepository().GetLastJevNoSeries(fundId);
                return jev.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            return "0000";
        }

        internal string GenerateJevTemplateNo()
        {
            bool fundValid = int.TryParse(cmbxFunds.SelectedValue.ToString(), out int fundId);
            Dictionary<string, string> fund = AccFactory.FundsRepository().GetRecordByID(fundId);

            string fundCode = fund["fund_code"];

            string year = dtpDateEntry.Value.Year.ToString();
            string month = dtpDateEntry.Value.ToString("MM");

            return $"{fundCode}-{year}-{month}";
        }

        /// <summary>
        /// Sums the debit credit.
        /// </summary>
        internal void SumDebitCredit()
        {
            decimal totalDebit = 0;
            decimal totalCredit = 0;

            if (dgAccounts.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in dgAccounts.Rows)
                {
                    decimal debitValue = string.IsNullOrWhiteSpace(item.Cells["Debit"].Value.ToString()) ? 0 : Convert.ToDecimal(item.Cells["Debit"].Value);
                    decimal creditValue = string.IsNullOrWhiteSpace(item.Cells["Credit"].Value.ToString()) ? 0 : Convert.ToDecimal(item.Cells["Credit"].Value);

                    totalDebit += Convert.ToDecimal(debitValue);
                    totalCredit += Convert.ToDecimal(creditValue);
                }
            }

            tlStrpLblDebit.Text = totalDebit.ToString("N2");
            tlStrpLblCredit.Text = totalCredit.ToString("N2");
        }

        /// <summary>
        /// Toggles the journal fields.
        /// </summary>
        /// <param name="journal">The journal.</param>
        private void ToggleJournalFields(string journal)
        {
            splitContainer1.Panel2Collapsed = false;

            switch (journal)
            {
                case "General Journal":
                    cstmTbCtrlJrnls.SelectedTab = tbPgGenJrnl;
                    break;

                case "Cash Receipts Journal":
                    cstmTbCtrlJrnls.SelectedTab = tbPgCshRcptsJrnl;
                    break;

                case "Cash Disbursements Journal":
                    cstmTbCtrlJrnls.SelectedTab = tbPgCshDsbrsmntJrnl;
                    break;

                case "Check Disbursements Journal":
                    cstmTbCtrlJrnls.SelectedTab = tbPgChkDsbrsmntJrnl;
                    break;

                case "Authority to Debit Account Disbursement Journal":
                    cstmTbCtrlJrnls.SelectedTab = tbPgAuthDbtAccDsbrsmntJrnl;
                    break;

                default:
                    splitContainer1.Panel2Collapsed = true;
                    break;
            }
        }

        private void EnableDisableButtons(DataGridView dgv, ToolStripButton btnEdit, ToolStripButton btnDelete)
        {
            int SelectedRows = dgv.SelectedRows.Count;
            if (SelectedRows == 1)
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnDelete.Text = "Remove (" + SelectedRows + ")";
            }
            else if (SelectedRows > 1)
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = true;
                btnDelete.Text = "Remove (" + SelectedRows + ")";
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnDelete.Text = "Remove";
            }
        }

        private void dgAccounts_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                EnableDisableButtons(dgAccounts, tlStrpBtnEditAcc, tlStrpBtnRemoveAcc);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgAccounts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                var grid = (DataGridView)sender;
                if (grid.Columns[e.ColumnIndex].Name == "IsDeposit")
                {
                    e.Value = (bool)e.Value ? "Deposit" : "Collection";
                    e.FormattingApplied = true;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void ClearErrors()
        {
            Helper.ClearErrorTextBox(errorProvider1, txtPayee);
            Helper.ClearErrorTextBox(errorProvider1, txtJevNo);
            Helper.ClearErrorTextBox(errorProvider1, txtExplanation);
            //Helper.ClearErrorComboBox(errorProvider1, cmbCollectingDisbursingOfficer);
        }

        private void txtPayee_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtPayee.Enabled)
                {
                    e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtPayee, lblPayee.Text);
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtPayee_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtPayee);
        }

        private void txtExplanation_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtExplanation.Enabled)
                {
                    e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtExplanation, lblExplanation.Text);
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtExplanation_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtExplanation);
        }

        private void tlStrpBtnAddAcc_Click(object sender, EventArgs e)
        {
            try
            {
                string journalName = cmbxJournal.Text;
                var frmJevAccountAdd = new frmJevAccAdd(this, journalName);
                frmJevAccountAdd.ucJEVAccount.journalName = journalName;
                frmJevAccountAdd.ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tlStrpBtnEditAcc_Click(object sender, EventArgs e)
        {
            try
            {
                string journalName = cmbxJournal.Text;
                var frmJevAccountEdit = new frmJevAccEdit(this, journalName);
                frmJevAccountEdit.ucJEVAccount.journalName = journalName;
                frmJevAccountEdit.ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tlStrpBtnRemoveAcc_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to remove this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgAccounts.SelectedRows)
                    {
                        dgAccounts.Rows.Remove(row);
                    }
                    SumDebitCredit();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        /// <summary>
        /// Loads the selected jev.
        /// </summary>
        /// <param name="jevId">The jev identifier.</param>
        ///

        private void LoadSelectedJEV(int jevId)
        {
            var jevDict = AccFactory.JEVRepository().GetViewRecordByJEVId(jevId);

            cmbxJournal.SelectedValue = Convert.ToByte(jevDict["journals_id"]);
            cmbxFunds.SelectedValue = Convert.ToByte(jevDict["funds_id"]);
            txtExplanation.Text = jevDict["explanation"];
            dtpDateEntry.Value = Convert.ToDateTime(jevDict["date_entry"]);
            txtRefNo.Text = jevDict["ref_no"];
            txtPayee.Text = jevDict["payee"];
            txtJevNo.Text = $"{GenerateJevTemplateNo()}-{jevDict["jev_no"]}";

            bool isEdited = Convert.ToByte(jevDict["is_edited"]) == 1;
            //tlStrpLblCreatedBy.Text = $"Created By: {(isEdited ? "(Edited)" : string.Empty)} {jevDict["created_by_name"]}";

            dgAccounts.Rows.Clear();
            LoadJevAccEntries(jevId);
            SumDebitCredit();
            GetJevStatus(jevId);
            ClearErrors();
        }

        internal void GetJevStatus(int jevId)
        {
            string jevStatus = AccFactory.JEVRepository().GetJevStatus(jevId).ToLower();

            switch (jevStatus)
            {
                case "pending":

                    break;

                case "approved":

                    break;

                case "disapproved":

                    break;

                case "cancelled":

                    break;
            }
        }

        private void LoadJevAccEntries(int jevId)
        {
            DataTable dtJEV = AccFactory.JEVAccountsRepository().GetViewRecordsByJevId(jevId);

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

                    dgAccounts.Rows.Add(accountRow);
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

                    dgAccounts.Rows.Add(accountRow);
                }
            }
        }

        private void cmbxJournal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                string journalName = cmbxJournal.Text;
                ToggleJournalFields(journalName);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        //internal bool CancelJev(int jevId)
        //{
        //    if (MessageBox.Show("Confirm cancellation of JEV.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        //    {
        //        return AccFactory.JEVRepository().CancelJev(jevId);
        //    }
        //}
    }
}