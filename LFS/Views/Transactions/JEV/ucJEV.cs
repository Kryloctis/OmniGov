using ACC.Data;
using ACC.Domain.Models;
using Google.Protobuf.WellKnownTypes;
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

        internal void OnLoad(bool isEdit, int? jevId)
        {
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
                txtJevNo.Text = GenerateJevNoTemplate();
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
                AccEntriesValidated().errMssg,
            };

            return AccFactory.CreateErrors(errs).GenerateErrorMessage();
        }

        private void LoadJournals()
        {
            var dtJournals = AccFactory.JournalsRepository().GetRecords();
            HelperLoadRecords.ComboboxJournals(dtJournals, cmbxJournal, "id", "journal_name");
            cmbxJournal.SelectedIndex = 0;
        }

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

        private void SetControlsReadOnly(Control parent, bool isReadOnly)
        {
            foreach (var c in parent.Controls.Cast<Control>()
                         .Where(c => c is ComboBox || c is DateTimePicker || c is TextBoxBase))
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
            dgAccounts.ReadOnly = isReadOnly;
        }

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

            ucGenJrnl.ResetForm();
            ucCshRcptsJrnl.ResetForm();
            ucCshDsbrsmntJrnl.ResetForm();
            ucAuthDbtAccDsbrsmntJrnl.ResetForm();

            dtpDateEntry.Value = DateTime.Now;
        }

        private void LoadFunds()
        {
            var dtFunds = AccFactory.FundsRepository().GetRecords();
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
                    e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtPayee, "Payee");
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
                var validateRow = RowsValidated(dgAccounts, jrnlType);

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

        private string GenerateJevNoTemplate(string seriesNo = "_ _ _")
        {
            bool fundValid = int.TryParse(cmbxFunds.SelectedValue.ToString(), out int fundId);
            var fund = AccFactory.FundsRepository().GetRecordByID(fundId);

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

            string fullJevNo = GenerateJevNoTemplate(jevSeriesNo);
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
        }

        private void LoadJevAccEntries(int jevId, DataGridView dgv)
        {
            DataTable dtJEV = AccFactory.JEVAccountsRepository().GetViewRecordsByJevId(jevId);

            foreach (DataRow row in dtJEV.Rows)
            {
                int newIndex = dgv.Rows.Add(
                    Convert.ToBoolean(row["is_debit"]) ? "Debit" : "Credit",
                    (row["fpp_id"] as int?) ?? 0,
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
                var cell = (DataGridViewComboBoxCell)dgv.Rows[newIndex].Cells["subsidiary_acc"];
                int subId = row["subsidiary_ledger_accounts_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["subsidiary_ledger_accounts_id"]);

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
            try
            {
                var cmbxIndex = cmbxJournal.SelectedIndex;
                ToggleJournalFields(cmbxJournal.GetItemText(cmbxJournal.Items[cmbxIndex]));
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

        internal (bool isValid, string errMssg) AccEntriesValidated()
        {
            var errMssg = string.Empty;
            if (dgAccounts.Rows.Count <= 0)
                return (Fail("No account entries found."));

            decimal.TryParse(tlStrpLblDebit.Text, out decimal debit);
            decimal.TryParse(tlStrpLblCredit.Text, out decimal credit);

            var rowVal = RowsValidated(dgAccounts, cmbxJournal.Text);
            if (!rowVal.isValidated)
                return Fail("Invalid accounting entry");

            if (debit != credit)
                return Fail("Debit and credit totals are not balanced.");

            return (true, string.Empty);

            (bool isValid, string errMssg) Fail(string msg)
            {
                return (false, msg);
            }
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

        private void cmbxJournal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxFunds_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                txtJevNo.Text = GenerateJevNoTemplate();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dtpDateEntry_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtJevNo.Text = GenerateJevNoTemplate();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}