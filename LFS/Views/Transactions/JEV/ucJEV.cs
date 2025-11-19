using ACC.Data;
using ACC.Domain.Models;
using LFS.Helpers;
using LFS.Views.Transactions.JEV.JournalForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LFS.Views.Transactions.JEV
{
    public partial class ucJev : UserControl
    {
        private bool isEdit;
        private int? jevId;
        private (int jrnlId, string jrnlName) prevJournal;

        private ucGenJrnl ucGenJrnl;
        private ucCshDsbrsmntJrnl ucCshDsbrsmntJrnl;
        private ucChkDsbrsmntJrnl ucChkDsbrsmntJrnl;
        private ucCshRcptsJrnl ucCshRcptsJrnl;
        private ucAuthDbtAccDsbrsmntJrnl ucAuthDbtAccDsbrsmntJrnl;

        public ucJev()
        {
            InitializeComponent();
            Helper.DatagridEditableRowStyle(dgAccounts, true);
            ucGenJrnl = ucGenJrnl1;
            ucCshDsbrsmntJrnl = ucCshDsbrsmntJrnl1;
            ucChkDsbrsmntJrnl = ucChkDsbrsmntJrnl1;
            ucCshRcptsJrnl = ucCshRcptsJrnl1;
            ucAuthDbtAccDsbrsmntJrnl = ucAuthDbtAccDsbrsmntJrnl1;
        }

        /// <summary>
        /// Initializes the form during load, including loading lookup data and toggling UI based on journal type.
        /// Also loads existing JE V data if in edit mode.
        /// </summary>
        /// <param name="isEdit">Indicates whether the form is in edit mode.</param>
        /// <param name="jevId">The JE V identifier if editing an existing record.</param>
        internal void OnLoad(bool isEdit, int? jevId)
        {
            this.isEdit = isEdit;
            ResetForm();
            LoadFunds();
            LoadJournals();

            string journalName;

            if (isEdit)
            {
                this.jevId = jevId;
                LoadSelectedJev(jevId.Value);
                journalName = cmbxJournal.Text;
                ToggleJournalFields(journalName);
                LoadJevAccEntries(jevId.Value);
            }
            else
            {
                journalName = cmbxJournal.Text;
                ToggleJournalFields(journalName);
            }

            ToggleAccEntriesButtons(dgAccounts, tlStrpBtnRemoveAcc);
        }

        /// <summary>
        /// Retrieves all form-level validation errors, including journal-specific row validation errors,
        /// and formats them into a single consolidated error message.
        /// </summary>
        /// <returns>A formatted error message string if any validation errors exist; otherwise, an empty or null-like message.</returns>
        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(cmbxJournal),
                errorProvider1.GetError(cmbxFunds),
                errorProvider1.GetError(txtPayee),
            };
            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        /// <summary>
        /// Clears all error messages currently displayed by the error provider for specified controls.
        /// </summary>
        internal void ClearErrors()
        {
            Helper.ClearErrorTextBox(errorProvider1, txtPayee);
            Helper.ClearErrorTextBox(errorProvider1, txtJevNo);
            Helper.ClearErrorTextBox(errorProvider1, txtExplanation);
            //Helper.ClearErrorComboBox(errorProvider1, cmbCollectingDisbursingOfficer);
        }

        /// <summary>
        /// Loads journal types from the repository and populates the journal ComboBox.
        /// </summary>
        private void LoadJournals()
        {
            var dtJournals = AccFactory.JournalsRepository().GetRecords();
            HelperLoadRecords.ComboboxJournals(dtJournals, cmbxJournal, "id", "journal_name");
        }

        /// <summary>
        /// Constructs and returns a populated <see cref="JevModel"/> based on current form input.
        /// Handles both new and edit scenarios and auto-approves if user has required privilege.
        /// </summary>
        /// <returns>A fully configured <see cref="JevModel"/> instance.</returns>
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

            return model;
        }

        /// <summary>
        /// Builds a list of <see cref="JEVAccountsModel"/> from the current rows in the accounts DataGridView.
        /// </summary>
        /// <returns>A list of account entry models ready for persistence.</returns>
        private List<JEVAccountsModel> JevAcountsModelList()
        {
            var jevAccountsModelList = new List<JEVAccountsModel>();
            foreach (DataGridViewRow item in dgAccounts.Rows)
            {
                int? fppId = item.Cells["fpp"]?.Value is int rwFppId && rwFppId != 0 ? rwFppId : null;
                ushort generalLedgerId = Convert.ToUInt16(item.Cells["gen_ldgr_acc"].Value);
                ushort? subsidiaryLedgerId = ushort.TryParse($"{item.Cells["subsidiary_acc"].Value}", out ushort val) ? (val == 0 ? null : val) : null;
                string obligationNo = item.Cells["obligation_no"].Value?.ToString() ?? "";
                bool isDebit = $"{item.Cells["is_debit"].Value}" == "Debit";
                bool isDeposit = $"{item.Cells["is_deposit"].Value}" == "Deposit";
                decimal amount = (decimal)item.Cells["amount"].Value;

                var jevAccountModel = new JEVAccountsModel()
                {
                    FPPId = fppId,
                    GeneralLedgerId = generalLedgerId,
                    SubsidiaryLedgerId = subsidiaryLedgerId,
                    ObligationNo = obligationNo,
                    IsDeposit = isDeposit,
                    IsDebit = isDebit,
                    Amount = amount,
                };

                jevAccountsModelList.Add(jevAccountModel);
            }

            return jevAccountsModelList;
        }

        internal bool SubmitJev(out string message, out bool isEdit)
        {
            string jrnlTyp = cmbxJournal.Text;
            isEdit = this.isEdit;

            if (this.isEdit)
            {
                message = $"{jrnlTyp} modification has been submitted";
                return UpdateData(jrnlTyp);
            }
            else
            {
                message = $"{jrnlTyp} has been submitted";
                return InsertData(jrnlTyp);
            }
        }

        private bool InsertData(string jrnlTyp)
        {
            switch (jrnlTyp)
            {
                case "General Journal":
                    return AccFactory.JEVRepository().InsertJevGenJrnl(JevModel(), JevAcountsModelList(), ucGenJrnl.GeneralJournalModel());

                case "Procurement Received Journal":
                    return AccFactory.JEVRepository().InsertJevProcRcvJrnl(JevModel(), JevAcountsModelList());

                case "Cash Receipts Journal":
                    return AccFactory.JEVRepository().InsertJevCashRcptsJrnl(JevModel(), JevAcountsModelList(), ucCshRcptsJrnl.CashReceiptsJournalModel());

                case "Cash Disbursements Journal":
                    return AccFactory.JEVRepository().InsertJevCashDsbrsmntsJrnl(JevModel(), JevAcountsModelList(), ucCshDsbrsmntJrnl.CashDisbursementsJournalModel());

                case "Check Disbursements Journal":
                    return AccFactory.JEVRepository().InsertJevChkDsbrsmntJrnl(JevModel(), JevAcountsModelList(), ucChkDsbrsmntJrnl.CheckDisbursementsJournalModel());

                case "Authority to Debit Account Disbursement Journal":
                    return AccFactory.JEVRepository().InsertJevAdaDsbrsmntsJrnl(JevModel(), JevAcountsModelList(), ucAuthDbtAccDsbrsmntJrnl.ADADisbursementsJournalModel());

                default:
                    return false;
            }
        }

        private bool UpdateData(string currentJrnlTyp)
        {
            switch (currentJrnlTyp)
            {
                case "General Journal":
                    return AccFactory.JEVRepository().UpdateJevGenJrnl(JevModel(), prevJournal, JevAcountsModelList(), ucGenJrnl.GeneralJournalModel());

                case "Procurement Received Journal":
                    return AccFactory.JEVRepository().UpdateJevProcRcvJrnl(JevModel(), prevJournal, JevAcountsModelList());

                case "Cash Receipts Journal":
                    return AccFactory.JEVRepository().UpdateJevCshRcptsJrnl(JevModel(), prevJournal, JevAcountsModelList(), ucCshRcptsJrnl.CashReceiptsJournalModel());

                case "Cash Disbursements Journal":
                    return AccFactory.JEVRepository().UpdateJevCshDsbrsmntsJrnl(JevModel(), prevJournal, JevAcountsModelList(), ucCshDsbrsmntJrnl.CashDisbursementsJournalModel());

                case "Check Disbursements Journal":
                    return AccFactory.JEVRepository().UpdateJevChkDsbrsmntJrnl(JevModel(), prevJournal, JevAcountsModelList(), ucChkDsbrsmntJrnl.CheckDisbursementsJournalModel());

                case "Authority to Debit Account Disbursement Journal":
                    return AccFactory.JEVRepository().UpdateJevAdaDsbrsmntsJrnl(JevModel(), prevJournal, JevAcountsModelList(), ucAuthDbtAccDsbrsmntJrnl.ADADisbursementsJournalModel());

                default:
                    return false;
            }
        }

        /// <summary>
        /// Sets the entire form to read-only or editable mode.
        /// </summary>
        /// <param name="isReadOnly">True to disable editing; false to enable.</param>
        internal void SetJevReadOnly(bool isReadOnly)
        {
            foreach (DateTimePicker dateTimePicker in Controls.OfType<DateTimePicker>())
                dateTimePicker.Enabled = !isReadOnly;

            foreach (Button button in Controls.OfType<Button>())
                button.Enabled = !isReadOnly;

            foreach (TextBox textBox in Controls.OfType<TextBox>())
                textBox.ReadOnly = isReadOnly;

            cmbxJournal.Enabled = !isReadOnly;
            cmbxFunds.Enabled = !isReadOnly;
            //btnAddAccount.Enabled = !isReadOnly;
            //btnEditAccount.Enabled = !isReadOnly;
            //btnRemoveAccount.Enabled = !isReadOnly;
            //cmbCollectingDisbursingOfficer.Enabled = !isReadOnly;
        }

        /// <summary>
        /// Resets all form fields and reloads default data (e.g., journals and funds).
        /// </summary>
        internal void ResetForm()
        {
            if (isEdit)
            {
                jevId = null;
            }

            txtJevNo.Text = string.Empty;
            txtRefNo.Text = string.Empty;
            txtPayee.Text = string.Empty;
            txtExplanation.Text = string.Empty;
            tabControl2.SelectedTab = tbPgJevDetails;

            dgAccounts.Rows.Clear();
            tlStrpLblDebit.Text = 0.ToString("N2");
            tlStrpLblCredit.Text = 0.ToString("N2");
            LoadJournals();
            LoadFunds();

            dtpDateEntry.Value = DateTime.Now;
        }

        /// <summary>
        /// Loads fund data from the repository and binds it to the funds ComboBox.
        /// </summary>
        private void LoadFunds()
        {
            var dtFunds = AccFactory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "id", "fund_name");
        }

        /// <summary>
        /// Calculates and displays the total debit and credit amounts from the accounts grid.
        /// </summary>
        private void SumDebitCredit()
        {
            decimal totalDebit = 0;
            decimal totalCredit = 0;
            if (dgAccounts.Rows.Count > 0)
            {
                foreach (DataGridViewRow item in dgAccounts.Rows)
                {
                    string rowIsDebit = $"{item.Cells["is_debit"].Value}";

                    if (string.IsNullOrWhiteSpace(rowIsDebit)) continue;
                    bool isDebit = $"{item.Cells["is_debit"].Value}" == "Debit";
                    decimal amount = Convert.ToDecimal(item.Cells["amount"].Value);

                    totalDebit += isDebit ? amount : 0m;
                    totalCredit += isDebit ? 0m : amount;
                }
            }

            tlStrpLblDebit.Text = totalDebit.ToString("N2");
            tlStrpLblCredit.Text = totalCredit.ToString("N2");

            bool isBlncd = totalDebit == totalCredit;
            tlStrpLblBlncIndctr.Text = isBlncd ? "Debit and Credit are equal" : "Debit and Credit totals must be equal!";
            tlStrpLblBlncIndctr.ForeColor = isBlncd ? Color.DarkOliveGreen : Color.IndianRed;
        }

        /// <summary>
        /// Shows or hides journal-specific panels and initializes the accounts grid based on selected journal type.
        /// </summary>
        /// <param name="journal">The name of the selected journal.</param>
        private void ToggleJournalFields(string journal)
        {
            splitContainer1.Panel2Collapsed = false;

            switch (journal)
            {
                case "General Journal":
                    ucGenJrnl.OnLoad(isEdit, jevId);
                    cstmTbCtrlJrnls.SelectedTab = tbPgGenJrnl;
                    break;

                case "Cash Receipts Journal":
                    ucCshRcptsJrnl.OnLoad(isEdit, jevId);
                    cstmTbCtrlJrnls.SelectedTab = tbPgCshRcptsJrnl;
                    break;

                case "Cash Disbursements Journal":
                    ucCshDsbrsmntJrnl.OnLoad(isEdit, jevId);
                    cstmTbCtrlJrnls.SelectedTab = tbPgCshDsbrsmntJrnl;
                    break;

                case "Check Disbursements Journal":
                    ucChkDsbrsmntJrnl.OnLoad(isEdit, jevId);
                    cstmTbCtrlJrnls.SelectedTab = tbPgChkDsbrsmntJrnl;
                    break;

                case "Authority to Debit Account Disbursement Journal":
                    ucAuthDbtAccDsbrsmntJrnl.OnLoad(isEdit, jevId);
                    cstmTbCtrlJrnls.SelectedTab = tbPgAuthDbtAccDsbrsmntJrnl;
                    break;

                default:
                    splitContainer1.Panel2Collapsed = true;
                    break;
            }

            InitializeJevAccTbl(journal);
        }

        /// <summary>
        /// Updates the state and text of the "Remove Account" button based on selected rows.
        /// </summary>
        /// <param name="dgv">The accounts DataGridView.</param>
        /// <param name="btnDelete">The ToolStrip button to update.</param>
        private void ToggleAccEntriesButtons(DataGridView dgv, ToolStripButton btnDelete)
        {
            int SelectedRows = dgv.SelectedRows.Count;

            if (SelectedRows == 1 || SelectedRows > 1)
            {
                btnDelete.Enabled = true;
                btnDelete.Text = "Remove (" + SelectedRows + ")";
            }
            else
            {
                btnDelete.Enabled = false;
                btnDelete.Text = "Remove";
            }
        }

        private void dgAccounts_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ToggleAccEntriesButtons(dgAccounts, tlStrpBtnRemoveAcc);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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

        private void tlStrpBtnAddAcc_Click(object sender, EventArgs e)
        {
            try
            {
                string jrnlType = cmbxJournal.Text;
                var validateRow = ValidateRows(dgAccounts, jrnlType);

                if (!validateRow.isValidated)
                {
                    var errMssg = AccFactory.CreateErrors(validateRow.errors).GenerateErrorMessage();
                    Helper.MessageBoxError(errMssg);
                    return;
                }

                int r = dgAccounts.Rows.Add();
                dgAccounts.CurrentCell = dgAccounts.Rows[r].Cells["is_debit"];
                dgAccounts.BeginEdit(true);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tlStrpBtnRemoveAcc_Click(object sender, EventArgs e)
        {
            try
            {
                int count = dgAccounts.SelectedRows.Count;
                if (count == 0) return;

                string msg = $"Are you sure you want to remove {(count == 1 ? "the accounting entry" : $"{count} accounting entries")}?";

                if (MessageBox.Show(msg, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgvRow in dgAccounts.SelectedRows)
                    {
                        dgAccounts.Rows.RemoveAt(dgvRow.Index);
                    }

                    SumDebitCredit();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private string CreateNewJevNo()
        {
            bool fundValid = int.TryParse(cmbxFunds.SelectedValue.ToString(), out int fundId);
            var fund = AccFactory.FundsRepository().GetRecordByID(fundId);

            if (fundValid)
            {
                string fundCode = fund["fund_code"];
                string month = dtpDateEntry.Value.ToString("MM");
                string year = dtpDateEntry.Value.Year.ToString();
                var jevSeriesNo = AccFactory.JEVRepository().GetLastJevNoSeries(fundId);

                return $"{fundCode}-{year}-{month}-{jevSeriesNo}";
            }
            else
                throw new Exception();
        }

        /// <summary>
        /// Loads an existing JE V record and populates the form fields and account grid.
        /// </summary>
        /// <param name="jevId">The JE V identifier to load.</param>
        private void LoadSelectedJev(int jevId)
        {
            var dictJev = AccFactory.JEVRepository().GetViewRecordByJEVId(jevId);
            if (dictJev.Count < 1) { throw new ArgumentException("Settings dictionary cannot be null or empty.", nameof(dictJev)); }

            byte journalId = Convert.ToByte(dictJev["journals_id"]);
            string journalName = dictJev["journal_name"];
            byte fundId = Convert.ToByte(dictJev["funds_id"]);
            string fundCode = dictJev["fund_code"];
            DateTime dateEntry = Convert.ToDateTime(dictJev["date_entry"]);
            string yearMonthPart = dateEntry.ToString("yyyy-MM");
            string jevSeriesNo = string.IsNullOrWhiteSpace(dictJev["jev_no"]) ? "_ _ _" : dictJev["jev_no"];
            string fullJevNo = $"{fundCode}-{yearMonthPart}-{jevSeriesNo}";
            string refNo = dictJev["ref_no"];
            string payee = dictJev["payee"];
            string explanation = dictJev["explanation"];

            prevJournal = (jevId, journalName);
            cmbxJournal.SelectedValue = journalId;
            cmbxFunds.SelectedValue = fundId;
            txtExplanation.Text = explanation;
            dtpDateEntry.Value = dateEntry;
            txtRefNo.Text = refNo;
            txtPayee.Text = payee;
            txtJevNo.Text = fullJevNo;

            var isValid = new List<bool>()
                {
                    byte.TryParse($"{dictJev["is_approved"]}", out byte isApproved),
                    byte.TryParse($"{dictJev["is_disapproved"]}", out byte isDisapproved),
                    byte.TryParse($"{dictJev["is_cancelled"]}", out byte isCancelled)
                };

            if (!isValid.Contains(false))
            {
                string status = Helper.GetStatus(isApproved == 1, isDisapproved == 1, isCancelled == 1);
                lblStatus.Text = $"Status: {status}";
            }
            else
                throw new Exception();

            bool createdByValid = int.TryParse($"{dictJev["created_by"]}", out int createdById);
            var dictCrtdBy = AccFactory.UsersRepository().GetRecordByID(createdById);
            string crtdByName = !createdByValid ? string.Empty :
                Helper.GenerateFullName(dictCrtdBy["prefix"],
                                        dictCrtdBy["first_name"],
                                        dictCrtdBy["mid_initial"],
                                        dictCrtdBy["last_name"],
                                        dictCrtdBy["suffix"]);

            lblCreatedBy.Text = $"Submitted by: {crtdByName}";

            dgAccounts.Rows.Clear();
            SumDebitCredit();
        }

        /// <summary>
        /// Loads account entries for a given JE V and populates the accounts DataGridView.
        /// </summary>
        /// <param name="jevId">The JE V identifier.</param>
        private void LoadJevAccEntries(int jevId)
        {
            DataTable dtJEV = AccFactory.JEVAccountsRepository().GetViewRecordsByJevId(jevId);

            foreach (DataRow row in dtJEV.Rows)
            {
                int newIndex = dgAccounts.Rows.Add(
                    Convert.ToBoolean(row["is_debit"]) ? "Debit" : "Credit",
                    Convert.ToInt32(row["fpp_id"]),
                    Convert.ToInt32(row["general_ledger_accounts_id"]),
                    null,
                    byte.TryParse($"{row["is_deposit"]}", out byte val)
                        ? (val == 1 ? "Deposit" : "Collection")
                        : "Collection",
                    Convert.ToDecimal(row["amount"]),
                    row["obligation_no"].ToString()
                );

                // === OPTIMIZED LOADING OF SUBSIDIARY LEDGER ===
                PopulateSubsidiaryCell(newIndex);

                // Assign sub-ledger value safely
                var cell = (DataGridViewComboBoxCell)dgAccounts.Rows[newIndex].Cells["subsidiary_acc"];
                int subId = row["subsidiary_ledger_accounts_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["subsidiary_ledger_accounts_id"]);

                if (cell.DataSource is DataTable dtSub &&
                    dtSub.AsEnumerable().Any(r => r.Field<int>("id") == subId))
                    cell.Value = subId;
                else
                    cell.Value = 0;  // fallback
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

        private void cmbxJournal_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxJournal, "Journal");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxJournal_Validated(object sender, EventArgs e)
        {
            try
            {
                Helper.ClearErrorComboBox(errorProvider1, cmbxJournal);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxFunds_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxFunds, "Fund");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxFunds_Validated(object sender, EventArgs e)
        {
            try
            {
                Helper.ClearErrorComboBox(errorProvider1, cmbxFunds);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        //internal bool CancelJev(int jevId)
        //{
        //    if (MessageBox.Show("Confirm cancellation of JEV.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        //    {
        //        return AccFactory.JEVRepository().CancelJev(jevId);
        //    }
        //}

        /// <summary>
        /// Configures the accounts DataGridView columns and visibility based on journal type.
        /// </summary>
        /// <param name="jrnlName">The selected journal name.</param>
        private void InitializeJevAccTbl(string jrnlName)
        {
            var dgColumns = DgvColumns();

            if (dgAccounts.Columns.Count != dgColumns.Count)
            {
                dgAccounts.Columns.Clear();
                dgAccounts.Columns.AddRange(dgColumns.ToArray());
            }

            dgAccounts.Columns["is_deposit"].Visible = jrnlName == "Cash Receipts Journal";
        }

        private DataTable DtFpp()
        {
            var dtFpp = AccFactory.FunctionProgramProjectRepository().GetViewRecords();
            var dt = new DataTable();
            var dtColmns = new DataColumn[]
            {
                new DataColumn(Name = "id", typeof(int)),
                new DataColumn(Name = "fpp_name", typeof(string)),
            };

            dt.Columns.AddRange(dtColmns);
            dt.Rows.Add(0, "N/A");

            foreach (DataRow dr in dtFpp.Rows)
                dt.Rows.Add(dr["id"], dr["fpp_name"]);

            return dt;
        }

        private DataTable DtGenLdgrAccs()
        {
            var dtGenLdgrAcc = AccFactory.GeneralLedgerAccountsRepository().GetViewRecords();
            var dt = new DataTable();
            var dtColmns = new DataColumn[]
            {
                new DataColumn(Name = "id", typeof(int)),
                new DataColumn(Name = "gen_ldgr_acc_name", typeof(string)),
            };
            dt.Columns.AddRange(dtColmns);

            foreach (DataRow dr in dtGenLdgrAcc.Rows)
                dt.Rows.Add(dr["general_ledger_accounts_id"], dr["ledger_name"]);

            return dt;
        }

        /// <summary>
        /// Defines and configures the columns for the accounts DataGridView.
        /// </summary>
        /// <returns>A list of configured <see cref="DataGridViewColumn"/> instances.</returns>
        private List<DataGridViewColumn> DgvColumns()
        {
            var dtColumns = new List<DataGridViewColumn>
            {
                new DataGridViewComboBoxColumn ()
                {
                    HeaderText = "D/C",
                    Name = "is_debit",
                    FlatStyle = FlatStyle.Flat,
                    MinimumWidth = 100,

                    Items = {"Debit", "Credit"},
                },

                new DataGridViewComboBoxColumn ()
                {
                    HeaderText = "FPP",
                    Name = "fpp",
                    FlatStyle = FlatStyle.Flat,
                    DataSource = DtFpp(),
                    ValueMember = "id",
                    DisplayMember = "fpp_name",
                    MinimumWidth = 200,
                },

                new DataGridViewComboBoxColumn ()
                {
                    HeaderText = "Account",
                    Name = "gen_ldgr_acc",
                    FlatStyle = FlatStyle.Flat,
                    DataSource = DtGenLdgrAccs(),
                    ValueMember = "id",
                    DisplayMember = "gen_ldgr_acc_name",
                    MinimumWidth = 200,
                },

                new DataGridViewComboBoxColumn()
                {
                    HeaderText = "Subsidiary",
                    Name = "subsidiary_acc",
                    FlatStyle = FlatStyle.Flat,
                    MaxDropDownItems = 10,
                    MinimumWidth = 200,
                },

                new DataGridViewComboBoxColumn()
                {
                    HeaderText = "Mode",
                    Name = "is_deposit",
                    FlatStyle = FlatStyle.Flat,
                    MinimumWidth = 100,
                    Items = { "Collection", "Deposit" },
                },

                new DataGridViewTextBoxColumn ()
                {
                    HeaderText = "Amount",
                    Name = "amount",
                    MinimumWidth = 200,
                    ValueType = typeof(decimal),
                    DefaultCellStyle = { Format = "N2"}
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Obligation No.",
                    Name = "obligation_no",
                    MinimumWidth = 200,
                   DefaultCellStyle = { NullValue = "" }
                },
            };

            return dtColumns;
        }

        /// <summary>
        /// Dynamically loads subsidiary accounts based on selected General Ledger and Fund.
        /// </summary>
        /// <param name="rowIndex">The index of the row being edited.</param>
        private DataTable DtSubLdrAccs(int genLdgrId, int fundId)
        {
            var dtDbSub = AccFactory.SubsidiaryLedgerAccountsRepository().GetRecordsByFundAndGeneralLedger(fundId, genLdgrId);

            var dtDbRows = dtDbSub.AsEnumerable()
                              .Select(r => new object[]
                              {
                                      r.Field<ushort>("id"),
                                      r.Field<string>("sub_name")
                              })
                              .ToArray();

            var dtSubAcc = new DataTable();
            var dtClmns = new DataColumn[]
            {
                new DataColumn(Name = "id", typeof(int)),
                new DataColumn(Name = "sub_name", typeof(string))
            };

            dtSubAcc.Columns.AddRange(dtClmns);
            dtSubAcc.Rows.Add(0, "N/A");

            foreach (var dtDbRow in dtDbRows)
            {
                var newRow2 = dtSubAcc.NewRow();
                newRow2["id"] = dtDbRow[0];
                newRow2["sub_name"] = dtDbRow[1];
                dtSubAcc.Rows.Add(newRow2);
            }

            return dtSubAcc;
        }

        private void dgAccounts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SumDebitCredit();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void PopulateSubsidiaryCell(int rowIndex)
        {
            var genIdObj = dgAccounts.Rows[rowIndex].Cells["gen_ldgr_acc"].Value;
            var fundObj = cmbxFunds.SelectedValue;

            if (genIdObj == null || fundObj == null) return;

            int genId = Convert.ToInt32(genIdObj);
            int fundId = Convert.ToInt32(fundObj);

            // Build DataSource
            var dtSub = DtSubLdrAccs(genId, fundId);

            var cell = (DataGridViewComboBoxCell)dgAccounts.Rows[rowIndex].Cells["subsidiary_acc"];
            cell.DataSource = dtSub;
            cell.DisplayMember = "sub_name";
            cell.ValueMember = "id";

            // Safely assign existing value (or fallback)
            var currentValue = cell.Value;

            if (currentValue != null &&
                dtSub.AsEnumerable().Any(r => r.Field<int>("id") == Convert.ToInt32(currentValue)))
            {
                // keep original
                return;
            }

            // fallback to N/A
            cell.Value = 0;
        }

        /// <summary>
        /// Validates an entire grid row based on journal type and returns validation results.
        /// </summary>
        /// <param name="dgv">The DataGridView containing account rows.</param>
        /// <param name="journalType">The type of journal currently selected.</param>
        /// <returns>A tuple indicating overall validity and an array of error messages per invalid row.</returns>
        private (bool isValidated, string[] errors) ValidateRows(DataGridView dgv, string journalType)
        {
            var errors = new List<string>();
            var validations = new List<bool>();

            foreach (DataGridViewRow dgvRow in dgv.Rows)
            {
                var sb = new StringBuilder();
                var rowValid = new List<bool>();
                sb.AppendLine($"Errors on row {dgvRow.Index + 1}");

                foreach (DataGridViewCell cell in dgvRow.Cells)
                {
                    string err = ValidateCell(cell, cell.Value, journalType);
                    bool cellValid = string.IsNullOrEmpty(err);

                    if (!cellValid)
                    {
                        rowValid.Add(cellValid);
                        sb.AppendLine($"        - {err}");
                    }
                }

                bool isRowValid = !rowValid.Contains(false);

                if (!isRowValid)
                {
                    validations.Add(isRowValid);
                    errors.Add(sb.ToString());
                }
            }

            return (!validations.Contains(false), errors.ToArray());
        }

        /// <summary>
        /// Validates a single DataGridView cell based on its column and current journal type.
        /// </summary>
        /// <param name="cell">The cell to validate.</param>
        /// <param name="formattedValue">The value to validate.</param>
        /// <param name="journalType">The active journal type (affects conditional validation).</param>
        /// <returns>An error message if invalid; otherwise, an empty string.</returns>
        private string ValidateCell(DataGridViewCell cell, object formattedValue, string journalType)
        {
            string col = cell.OwningColumn.Name;
            string val = formattedValue?.ToString()?.Trim() ?? ""; // <-- this is correct

            switch (col)
            {
                case "fpp":
                    return string.IsNullOrWhiteSpace(val) ? "FPP is required" : "";

                case "gen_ldgr_acc":
                    return string.IsNullOrWhiteSpace(val) ? "Account is required" : "";

                case "is_debit":
                    return string.IsNullOrWhiteSpace(val) ? "D/C is required" : "";

                case "subsidiary_acc":
                    return string.IsNullOrWhiteSpace(val) ? "Select Subsidiary" : "";

                case "is_deposit":
                    if (journalType == "Cash Receipts Journal")
                        return string.IsNullOrWhiteSpace(val) ? "Mode is required" : "";

                    return "";

                case "amount":
                    if (!decimal.TryParse(val, out var amt) || amt <= 0m)
                        return "Amount must be greater than 0";
                    return "";

                default:
                    return "";
            }
        }

        private void dgAccounts_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                var g = (DataGridView)sender;
                var cell = g.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string jrnlName = cmbxJournal.Text;

                string err = ValidateCell(cell, e.FormattedValue, jrnlName);
                cell.ErrorText = err; // empty = no error
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgAccounts_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (dgAccounts.CurrentCell?.OwningColumn?.Name == "amount" && e.Control is TextBox tb)
                {
                    tb.KeyPress -= Tb_KeyPress;
                    tb.KeyPress += Tb_KeyPress;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        /// <summary>
        /// Restricts input in amount fields to digits and a single decimal point.
        /// </summary>
        private void Tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            // Allow control characters (e.g., backspace)
            if (char.IsControl(e.KeyChar)) return;

            bool isDigit = char.IsDigit(e.KeyChar);
            bool isDecimal = e.KeyChar == '.' && !tb.Text.Contains('.');

            e.Handled = !(isDigit || isDecimal);
        }

        private void dgAccounts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                string col = dgAccounts.Columns[e.ColumnIndex].Name;

                if (col == "gen_ldgr_acc")
                    PopulateSubsidiaryCell(e.RowIndex);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgAccounts_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgAccounts.IsCurrentCellDirty)
                    dgAccounts.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}