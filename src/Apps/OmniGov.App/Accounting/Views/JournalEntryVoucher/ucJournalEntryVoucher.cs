using OmniGov.Accounting.Data.Factories;
using OmniGov.Accounting.Domain.Entities;
using OmniGov.App.Accounting.Views.JournalEntryVoucher.JournalForms;
using OmniGov.App.Helpers;
using OmniGov.Core.Factories;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Text;

namespace OmniGov.App.Accounting.Views.JournalEntryVoucher
{
    public partial class ucJournalEntryVoucher : UserControl
    {
        private bool isEdit;
        private int? jevId;
        private (int jrnlId, string jrnlName) prevJournal;

        private ucGenJrnl ucGenJrnl;
        private ucCshDsbrsmntJrnl ucCshDsbrsmntJrnl;
        private ucChkDsbrsmntJrnl ucChkDsbrsmntJrnl;
        private ucCshRcptsJrnl ucCshRcptsJrnl;
        private ucAuthDbtAccDsbrsmntJrnl ucAuthDbtAccDsbrsmntJrnl;

        public ucJournalEntryVoucher()
        {
            InitializeComponent();
            Helper.DatagridEditableRowStyle(dgAccounts, true);
            ucGenJrnl = ucGenJrnl1;
            ucCshDsbrsmntJrnl = ucCshDsbrsmntJrnl1;
            ucChkDsbrsmntJrnl = ucChkDsbrsmntJrnl1;
            ucCshRcptsJrnl = ucCshRcptsJrnl1;
            ucAuthDbtAccDsbrsmntJrnl = ucAuthDbtAccDsbrsmntJrnl1;
        }

        private void VerifyUserPrivileges()
        {
            txtRemarks.Enabled = PrivilegesHelper.HasPrivilege(Privileges.TransJEVApproval);
        }

        internal void OnLoad(bool isEdit, int? jevId)
        {
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
            VerifyUserPrivileges();
            this.isEdit = isEdit;
            ResetForm();
            LoadJournals();
            LoadFunds();

            if (isEdit)
            {
                this.jevId = jevId;
                LoadSelectedJev(jevId.Value);
                var cmbxIndex = cmbxJournal.SelectedIndex;
                ToggleJournalFields(cmbxJournal.GetItemText(cmbxJournal.Items[cmbxIndex]));
                LoadJevAccEntries(jevId.Value, dgAccounts);
            }
            else
            {
                var cmbxIndex = cmbxJournal.SelectedIndex;
                ToggleJournalFields(cmbxJournal.GetItemText(cmbxJournal.Items[cmbxIndex]));
            }

            ToggleAccEntriesButtons(dgAccounts, tlStrpBtnRemoveAcc);
        }

        internal string GetFormErrors()
        {
            var errs = new string[]
            {
                errorProvider1.GetError(cmbxJournal),
                errorProvider1.GetError(cmbxFunds),
                errorProvider1.GetError(txtPayee),
                errorProvider1.GetError(mskTxtTransNo),
                AccEntriesValidated().errMssg,
            };

            return Factory.CreateErrors(errs).GenerateErrorMessage();
        }

        private void LoadJournals()
        {
            var dtJournals = Factory.JournalsRepository().GetRecords();
            HelperLoadRecords.ComboboxJournals(dtJournals, cmbxJournal, "id", "journal_name");
            cmbxJournal.SelectedIndex = 0;
        }

        private JevModel LocalJevModel()
        {
            var model = new JevModel();

            bool fundValid = int.TryParse(cmbxFunds.SelectedValue.ToString(), out int fundId);
            model.FundsId = (byte)fundId;

            bool journalValid = int.TryParse(cmbxJournal.SelectedValue.ToString(), out int journalId);
            model.JournalsId = (byte)journalId;

            model.TransactionNo = new string(mskTxtTransNo.Text.Where(char.IsDigit).TakeLast(4).ToArray());
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
                string trnsctnNo = mskTxtTransNo.Text;
                message = $"{jrnlTyp} modification (Transaction No.{trnsctnNo}) has been submitted";
                return UpdateData(jrnlTyp);
            }
            else
            {
                string trnsctnNo = GenTransctnNo();
                mskTxtTransNo.Text = trnsctnNo;

                message = $"{jrnlTyp} (Transaction No.{trnsctnNo}) has been submitted";
                return InsertData(jrnlTyp);
            }
        }

        private bool InsertData(string jrnlTyp)
        {
            switch (jrnlTyp)
            {
                case "General Journal":
                    return AccountingFactory.JEVRepository().InsertGeneralJournalEntry(LocalJevModel(), JevAcountsModelList(), ucGenJrnl.GeneralJournalModel());

                case "Procurement Received Journal":
                    return AccountingFactory.JEVRepository().InsertProcurementReceivedJournalEntry(LocalJevModel(), JevAcountsModelList());

                case "Cash Receipts Journal":
                    return AccountingFactory.JEVRepository().InsertCashReceiptsJournalEntry(LocalJevModel(), JevAcountsModelList(), ucCshRcptsJrnl.CashReceiptsJournalModel());

                case "Cash Disbursements Journal":
                    return AccountingFactory.JEVRepository().InsertCashDisbursementsJournalEntry(LocalJevModel(), JevAcountsModelList(), ucCshDsbrsmntJrnl.CashDisbursementsJournalModel());

                case "Check Disbursements Journal":
                    return AccountingFactory.JEVRepository().InsertCheckDisbursementsJournalEntry(LocalJevModel(), JevAcountsModelList(), ucChkDsbrsmntJrnl.CheckDisbursementsJournalModel());

                case "Authority to Debit Account Disbursement Journal":
                    return AccountingFactory.JEVRepository().InsertADADisbursementsJournalEntry(LocalJevModel(), JevAcountsModelList(), ucAuthDbtAccDsbrsmntJrnl.ADADisbursementsJournalModel());

                default:
                    return false;
            }
        }

        private bool UpdateData(string currentJrnlTyp)
        {
            switch (currentJrnlTyp)
            {
                case "General Journal":
                    return AccountingFactory.JEVRepository().UpdateGeneralJournalEntry(LocalJevModel(), prevJournal, JevAcountsModelList(), ucGenJrnl.GeneralJournalModel());

                case "Procurement Received Journal":
                    return AccountingFactory.JEVRepository().UpdateProcurementReceivedJournalEntry(LocalJevModel(), prevJournal, JevAcountsModelList());

                case "Cash Receipts Journal":
                    return AccountingFactory.JEVRepository().UpdateCashReceiptsJournalEntry(LocalJevModel(), prevJournal, JevAcountsModelList(), ucCshRcptsJrnl.CashReceiptsJournalModel());

                case "Cash Disbursements Journal":
                    return AccountingFactory.JEVRepository().UpdateCashDisbursementsJournalEntry(LocalJevModel(), prevJournal, JevAcountsModelList(), ucCshDsbrsmntJrnl.CashDisbursementsJournalModel());

                case "Check Disbursements Journal":
                    return AccountingFactory.JEVRepository().UpdateCheckDisbursementsJournalEntry(LocalJevModel(), prevJournal, JevAcountsModelList(), ucChkDsbrsmntJrnl.CheckDisbursementsJournalModel());

                case "Authority to Debit Account Disbursement Journal":
                    return AccountingFactory.JEVRepository().UpdateADADisbursementsJournalEntry(LocalJevModel(), prevJournal, JevAcountsModelList(), ucAuthDbtAccDsbrsmntJrnl.ADADisbursementsJournalModel());

                default:
                    return false;
            }
        }

        private void SetControlsReadOnly(Control parent, bool isReadOnly)
        {
            foreach (var c in parent.Controls.Cast<Control>()
                         .Where(c => c is ComboBox || c is DateTimePicker || c is TextBoxBase || c is LinkLabel))
            {
                if (c is TextBoxBase tb)
                {
                    tb.ReadOnly = isReadOnly;
                    continue;
                }

                c.Enabled = !isReadOnly;
            }

            dgAccounts.SelectionChanged -= dgAccounts_SelectionChanged;
        }

        internal void SetJevReadOnly(bool isReadOnly)
        {
            var parents = new Control[]
            {
                splitContainer2.Panel1,
                panel2,
                ucChkDsbrsmntJrnl,
                ucGenJrnl,
                ucCshDsbrsmntJrnl,
                ucCshRcptsJrnl,
                ucAuthDbtAccDsbrsmntJrnl,
            };

            foreach (var p in parents)
                SetControlsReadOnly(p, isReadOnly);
            tlStrpBtnAddAcc.Enabled = !isReadOnly;
            tlStrpBtnRemoveAcc.Enabled = !isReadOnly;
            txtExplanation.ReadOnly = isReadOnly;
            dgAccounts.ReadOnly = isReadOnly;
        }

        internal void ResetForm()
        {
            if (isEdit)
            {
                jevId = null;
            }

            mskTxtJevNo.Text = string.Empty;
            txtRefNo.Text = string.Empty;
            txtPayee.Text = string.Empty;
            txtExplanation.Text = string.Empty;
            txtRemarks.Clear();
            tabControl2.SelectedTab = tbPgJevDetails;

            dgAccounts.Rows.Clear();
            tlStrpLblDebit.Text = 0.ToString("N2");
            tlStrpLblCredit.Text = 0.ToString("N2");
            LoadJournals();
            LoadFunds();

            ucGenJrnl.ResetForm();
            ucCshRcptsJrnl.ResetForm();
            ucCshDsbrsmntJrnl.ResetForm();
            ucAuthDbtAccDsbrsmntJrnl.ResetForm();
            lblStatus.Text = "Status: Draft";
            lblCreatedBy.Text = $"Submitted by: {UserHelper.loggedUser.FullName}";
            ToggleJevStatIndctr(lblStatIndctr);
            mskTxtTransNo.ResetText();

            dtpDateEntry.Value = DateTime.Now;
        }

        private void LoadFunds()
        {
            var dtFunds = Factory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "id", "fund_name");
        }

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

            bool isBlncd = (totalDebit == totalCredit);
            bool isZero = totalDebit == 0;
            tlStrpLblBlncIndctr.Text = isZero ? "No Record of Accounting Entries" :
                                    (isBlncd ?
                                    "Debit and Credit are equal" :
                                    "Debit and Credit totals must be equal!");

            tlStrpLblBlncIndctr.ForeColor = isZero
            ? Color.FromKnownColor(KnownColor.ControlDarkDark)
            : (isBlncd ? Color.DarkOliveGreen : Color.IndianRed);
        }

        private void ToggleJournalFields(string journal)
        {
            switch (journal)
            {
                case "General Journal":
                    ucGenJrnl.OnLoad(isEdit, jevId);
                    cstmTbCtrlJrnls.SelectedTab = tbPgGenJrnl;
                    splitContainer1.Panel2Collapsed = false;
                    break;

                case "Cash Receipts Journal":
                    ucCshRcptsJrnl.OnLoad(isEdit, jevId);
                    cstmTbCtrlJrnls.SelectedTab = tbPgCshRcptsJrnl;
                    splitContainer1.Panel2Collapsed = false;
                    break;

                case "Cash Disbursements Journal":
                    ucCshDsbrsmntJrnl.OnLoad(isEdit, jevId);
                    cstmTbCtrlJrnls.SelectedTab = tbPgCshDsbrsmntJrnl;
                    splitContainer1.Panel2Collapsed = false;
                    break;

                case "Check Disbursements Journal":
                    ucChkDsbrsmntJrnl.OnLoad(isEdit, jevId);
                    cstmTbCtrlJrnls.SelectedTab = tbPgChkDsbrsmntJrnl;
                    splitContainer1.Panel2Collapsed = false;
                    break;

                case "Authority to Debit Account Disbursement Journal":
                    ucAuthDbtAccDsbrsmntJrnl.OnLoad(isEdit, jevId);
                    cstmTbCtrlJrnls.SelectedTab = tbPgAuthDbtAccDsbrsmntJrnl;
                    splitContainer1.Panel2Collapsed = false;
                    break;

                default:
                    splitContainer1.Panel2Collapsed = true;
                    break;
            }

            InitializeJevAccTbl(journal);
        }

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
            ToggleAccEntriesButtons(dgAccounts, tlStrpBtnRemoveAcc);
        }

        private void txtPayee_Validating(object sender, CancelEventArgs e)
        {
            if (txtPayee.Enabled)
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtPayee, "Payee");
            }
        }

        private void txtPayee_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtPayee);
        }

        private void tlStrpBtnAddAcc_Click(object sender, EventArgs e)
        {
            string jrnlType = cmbxJournal.Text;
            var validateRow = RowsValidated(dgAccounts, jrnlType);

            if (!validateRow.isValidated)
            {
                var errMssg = Factory.CreateErrors(validateRow.errors).GenerateErrorMessage();
                Helper.MessageBoxError(errMssg);
                return;
            }

            int r = dgAccounts.Rows.Add();
            dgAccounts.CurrentCell = dgAccounts.Rows[r].Cells["is_debit"];
            dgAccounts.BeginEdit(true);
        }

        private void tlStrpBtnRemoveAcc_Click(object sender, EventArgs e)
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

        private string GenTransctnNo()
        {
            DateTime dateEntry = dtpDateEntry.Value;
            string seriesNo = AccountingFactory.JEVRepository().GetLastTransactionNo(dateEntry.Year);
            string trnsctnNo = $"{dateEntry:yy}-{seriesNo}";
            return trnsctnNo;
        }

        private string GenerateJevNoTemplate(string seriesNo = "_ _ _")
        {
            bool fundValid = int.TryParse(cmbxFunds.SelectedValue.ToString(), out int fundId);
            var fund = Factory.FundsRepository().GetRecordByID(fundId);

            if (fundValid)
            {
                string fundCode = fund["fund_code"];
                string month = dtpDateEntry.Value.ToString("MM");
                string year = dtpDateEntry.Value.Year.ToString();

                return $"{fundCode}-{year}-{month}-{seriesNo}";
            }
            else
                throw new Exception();
        }

        private void ToggleJevStatIndctr(Label label, string status = "")
        {
            var indctrColor = new Color();

            switch (status)
            {
                case "draft":
                    indctrColor = Color.FromKnownColor(KnownColor.ControlDarkDark);
                    break;

                case "pending":
                    indctrColor = Color.Gold;
                    break;

                case "approved":
                    indctrColor = Color.Green;
                    break;

                case "disapproved":
                    indctrColor = Color.Red;
                    break;

                case "cancelled":
                    indctrColor = Color.Purple;
                    break;

                default:
                    indctrColor = Color.FromKnownColor(KnownColor.ControlDarkDark);
                    break;
            }

            label.ForeColor = indctrColor;
        }

        private void LoadSelectedJev(int jevId)
        {
            var dictJev = AccountingFactory.JEVRepository().GetViewRecordByJEVId(jevId);
            if (dictJev.Count < 1) { throw new ArgumentException("Settings dictionary cannot be null or empty.", nameof(dictJev)); }

            byte journalId = Convert.ToByte(dictJev["journals_id"]);
            string journalName = dictJev["journal_name"];
            byte fundId = Convert.ToByte(dictJev["funds_id"]);
            string fundCode = dictJev["fund_code"];
            DateTime dateEntry = Convert.ToDateTime(dictJev["date_entry"]);
            string yearMonthPart = dateEntry.ToString("yyyy-MM");
            string jevSeriesNo = string.IsNullOrWhiteSpace(dictJev["jev_no"]) ? "_ _ _" : dictJev["jev_no"];
            string refNo = dictJev["ref_no"];
            string payee = dictJev["payee"];
            string explanation = dictJev["explanation"];
            string remarks = dictJev["remarks"];

            string transactionNo = Helper.FormatTransactionNo(dictJev["transaction_no"].ToString());

            prevJournal = (jevId, journalName);
            mskTxtTransNo.Text = transactionNo;
            cmbxJournal.SelectedValue = journalId;
            cmbxFunds.SelectedValue = fundId;
            txtExplanation.Text = explanation;
            dtpDateEntry.Value = dateEntry;
            txtRefNo.Text = refNo;
            txtPayee.Text = payee;
            txtRemarks.Text = remarks;

            string fullJevNo = GenerateJevNoTemplate(jevSeriesNo);
            mskTxtJevNo.Text = fullJevNo;

            string status = dictJev["status"];
            string formattedStatus = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(status);
            lblStatus.Text = $"Status: {formattedStatus}";
            ToggleJevStatIndctr(lblStatIndctr, status);

            bool createdByValid = int.TryParse($"{dictJev["created_by"]}", out int createdById);
            var dictCrtdBy = Factory.UsersRepository().GetRecordByID(createdById);
            string crtdByName = !createdByValid ? string.Empty :
                Helper.GenerateFullName(dictCrtdBy["prefix"],
                                        dictCrtdBy["first_name"],
                                        dictCrtdBy["mid_initial"],
                                        dictCrtdBy["last_name"],
                                        dictCrtdBy["suffix"]);

            lblCreatedBy.Text = $"Submitted by: {crtdByName}";

            dgAccounts.Rows.Clear();
        }

        private void LoadJevAccEntries(int jevId, DataGridView dgv)
        {
            DataTable dtJEV = AccountingFactory.JEVAccountsRepository().GetViewRecordsByJevId(jevId);

            foreach (DataRow row in dtJEV.Rows)
            {
                int newIndex = dgv.Rows.Add(
                    Convert.ToBoolean(row["is_debit"]) ? "Debit" : "Credit", //Credit or Debit Column
                    int.TryParse(row["fpp_id"].ToString(), out int fppId) ? fppId : 0, //FPP Column
                    Convert.ToInt32(row["general_ledger_accounts_id"]), //Account Column
                    int.TryParse(row["subsidiary_ledger_accounts_id"].ToString(), out int subId) ? subId : 0, //Subsidiary Column
                    byte.TryParse($"{row["is_deposit"]}", out byte val)
                        ? (val == 1 ? "Deposit" : "Collection")
                        : "Collection", //Deposit or Collection Column
                    Convert.ToDecimal(row["amount"]), //Amount Column
                    row["obligation_no"].ToString() //Obligation Column
                );

                // === OPTIMIZED LOADING OF SUBSIDIARY LEDGER ===
                PopulateSubsidiaryCell(newIndex);

                // Assign sub-ledger value safely
                var cell = (DataGridViewComboBoxCell)dgv.Rows[newIndex].Cells["subsidiary_acc"];

                if (cell.DataSource is DataTable dtSub &&
                    dtSub.AsEnumerable().Any(r => r.Field<int>("id") == subId))
                    cell.Value = subId;
                else
                    cell.Value = 0;  // fallback
            }

            SumDebitCredit();
        }

        private void cmbxJournal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var cmbxIndex = cmbxJournal.SelectedIndex;
            ToggleJournalFields(cmbxJournal.GetItemText(cmbxJournal.Items[cmbxIndex]));
        }

        private void cmbxJournal_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxJournal, "Journal");
        }

        private void cmbxJournal_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxJournal);
        }

        private void cmbxFunds_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxFunds, "Fund");
        }

        private void cmbxFunds_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxFunds);
        }

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
            var dtFpp = Factory.FunctionProgramProjectRepository().GetViewRecords();
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
            var dtGenLdgrAcc = AccountingFactory.GeneralLedgerAccountsRepository().GetViewRecords();
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

        private DataTable DtSubLdrAccs(int genLdgrId, int fundId)
        {
            var dtDbSub = AccountingFactory.SubsidiaryLedgerAccountsRepository().GetRecordsByFundAndGeneralLedger(fundId, genLdgrId);

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
            SumDebitCredit();
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

        internal (bool isValid, string errMssg) AccEntriesValidated()
        {
            var errMssg = string.Empty;
            if (dgAccounts.Rows.Count <= 0)
                return (false, "No account entries found.");

            decimal.TryParse(tlStrpLblDebit.Text, out decimal debit);
            decimal.TryParse(tlStrpLblCredit.Text, out decimal credit);

            var rowVal = RowsValidated(dgAccounts, cmbxJournal.Text);
            if (!rowVal.isValidated)
                return (false, "Invalid accounting entry");

            if (debit != credit)
                return (false, "Debit and credit totals are not balanced.");

            return (true, string.Empty);
        }

        private (bool isValidated, string[] errors) RowsValidated(DataGridView dgv, string journalType)
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
            var g = (DataGridView)sender;
            var cell = g.Rows[e.RowIndex].Cells[e.ColumnIndex];
            string jrnlName = cmbxJournal.Text;

            string err = ValidateCell(cell, e.FormattedValue, jrnlName);
            cell.ErrorText = err; // empty = no error
        }

        private void dgAccounts_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgAccounts.CurrentCell?.OwningColumn?.Name == "amount" && e.Control is TextBox tb)
            {
                tb.KeyPress -= Tb_KeyPress;
                tb.KeyPress += Tb_KeyPress;
            }
        }

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
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string col = dgAccounts.Columns[e.ColumnIndex].Name;

            if (col == "gen_ldgr_acc")
                PopulateSubsidiaryCell(e.RowIndex);
        }

        private void dgAccounts_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgAccounts.IsCurrentCellDirty)
                dgAccounts.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void cmbxJournal_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void lblStatus_TextChanged(object sender, EventArgs e)
        {
        }

        /////Auditing Section
        internal bool CancelJev(out string transactionnNo)
        {
            transactionnNo = mskTxtTransNo.Text;

            if (MessageBox.Show($"Confirm cancellation of JEV (Transaction No.{transactionnNo})",
                                "Confirmation",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string remarks = txtRemarks.Text.Trim();
                const JevModel.Status cancelled = JevModel.Status.cancelled;
                int jevIdValue = jevId.Value;
                return AccountingFactory.JEVRepository().SetJevStatus(jevIdValue, cancelled, remarks);
            }
            return false;
        }

        internal bool DisapproveJev(out string trnsctnNo)
        {
            trnsctnNo = mskTxtTransNo.Text;

            if (MessageBox.Show($"Confirm disapproval of JEV (Transaction No.{trnsctnNo})",
                                "Confirmation",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string remarks = txtRemarks.Text.Trim();
                const JevModel.Status disapproved = JevModel.Status.disapproved;
                int jevIdValue = jevId.Value;
                return AccountingFactory.JEVRepository().SetJevStatus(jevIdValue, disapproved, remarks);
            }
            return false;
        }

        internal bool ApproveJev(out string jevNo, out string trnsctnNo)
        {
            trnsctnNo = mskTxtTransNo.Text;

            if (Helper.MessageBoxConfirmCancel($"Confirm approval of JEV (Transaction No.{trnsctnNo})"))
            {
                bool fundValid = int.TryParse(cmbxFunds.SelectedValue?.ToString(), out int fundId);
                string jevSeriesNo = AccountingFactory.JEVRepository().GetLastJevNoSeries(fundId);
                string genJevNo = GenerateJevNoTemplate(jevSeriesNo);

                if (fundValid)
                {
                    jevNo = genJevNo;

                    string remarks = txtRemarks.Text.Trim();
                    const JevModel.Status approved = JevModel.Status.approved;
                    int jevIdValue = jevId.Value;
                    return AccountingFactory.JEVRepository().SetJevStatus(jevIdValue, approved, remarks);
                }
                else
                    throw new Exception("Fund is invalid.");
            }

            trnsctnNo = string.Empty;
            jevNo = string.Empty;
            return false;
        }
    }
}