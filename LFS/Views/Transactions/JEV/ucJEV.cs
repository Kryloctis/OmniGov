using ACC.Data;
using LFS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LFS.Views.Transactions.JEV
{
    public partial class ucJev : UserControl
    {
        internal bool isEdit;
        internal int jevId = 0;
        internal string jevNo;
        internal byte fundId = 0;
        internal byte journalId = 0;
        internal byte oldJournalId = 0;
        internal string journalName;

        public ucJev()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgAccounts, true);
        }

        #region Unused Methods

        internal void LoadJournals()
        {
            string CheckedJournal = "General Journal";
            var journals = AccFactory.JournalsRepository().GetRecords();

            foreach (DataRow journal in journals.Rows)
            {
                var radJournal = new RadioButton();
                radJournal.Text = journal["journal_name"].ToString();
                radJournal.Tag = journal["id"];
                radJournal.AutoSize = true;
                radJournal.Appearance = Appearance.Button;

                if (journal["journal_name"].ToString() == CheckedJournal)
                {
                    radJournal.Checked = true;
                    journalId = Convert.ToByte(journal["id"]);
                    journalName = CheckedJournal;
                }

                flowLayoutPanelJournals.Controls.Add(radJournal);
                radJournal.Click += new EventHandler(radioJournals_Click);
                radJournal.CheckedChanged += new EventHandler(radioJournals_CheckedChanged);
            }
        }

        private DataColumn[] DataColumnsCollectingOfficers()
        {
            return new DataColumn[]
            {
                new DataColumn(Name = "id", typeof(int)),
                new DataColumn(Name = "full_name", typeof(string))
            };
        }

        private DataColumn[] DataColumnDisbursingOfficer()
        {
            return new DataColumn[]
            {
                new DataColumn(Name = "id", typeof(int)),
                new DataColumn(Name = "full_name", typeof(string)),
                new DataColumn(Name = "job_title", typeof(string)),
                new DataColumn(Name = "created_at", typeof(string)),
                new DataColumn(Name = "updated_at", typeof(string)),
                new DataColumn(Name = "users_id", typeof(string))
            };
        }

        private DataTable DataTableCollectingOfficer()
        {
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(DataColumnsCollectingOfficers());
            var dtCollectingOfficer = AccFactory.CollectingOfficerRepository().GetRecords();

            foreach (DataRow row in dtCollectingOfficer.Rows)
            {
                string prefix = row["prefix"].ToString();
                string firstName = row["first_name"].ToString();
                string midInitial = row["mid_initial"].ToString();
                string lastName = row["last_name"].ToString();
                string suffix = row["suffix"].ToString();
                string fullName = Helper.GenerateFullName(prefix, firstName, midInitial, lastName, suffix);
                int Id = Convert.ToInt32(row["id"]);

                var newRow = dataTable.NewRow();

                newRow["id"] = Id;
                newRow["full_name"] = fullName;
                dataTable.Rows.Add(newRow);
            }
            return dataTable;
        }

        internal void LoadCollectingOfficer()
        {
            //HelperLoadRecords.CollectingOfficerComboBox(DataTableCollectingOfficer(), cmbCollectingDisbursingOfficer, "full_name", "id");
        }

        private DataTable DataTableDisbursingOfficer()
        {
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(DataColumnDisbursingOfficer());
            DataTable dtDisbursingOfficers = AccFactory.DisbursingOfficerRepository().GetRecords();

            foreach (DataRow row in dtDisbursingOfficers.Rows)
            {
                int rowId = Convert.ToInt32(row["id"]);
                string rowPrefix = row["prefix"].ToString();
                string rowFirstName = row["first_name"].ToString();
                string rowMiddleInitial = row["mid_initial"].ToString();
                string rowLastName = row["last_name"].ToString();
                string rowSuffix = row["suffix"].ToString();
                string rowJobTitle = row["job_title"].ToString();
                string rowCreatedAt = row["created_at"].ToString();
                string rowUpdatedAt = row["updated_at"].ToString();
                string rowUsersId = row["users_id"].ToString();

                var disbursingOfficerFullName = Helper.GenerateFullName(rowPrefix, rowFirstName, rowMiddleInitial, rowLastName, rowSuffix);

                var dtRow = dataTable.NewRow();
                dtRow["id"] = rowId;
                dtRow["full_name"] = disbursingOfficerFullName;
                dtRow["job_title"] = rowJobTitle;
                dtRow["created_at"] = rowCreatedAt;
                dtRow["updated_at"] = rowUpdatedAt;
                dtRow["users_id"] = rowUsersId;

                dataTable.Rows.Add(dtRow);
            }

            return dataTable;
        }

        internal void LoadDisbursingOfficer()
        {
            //HelperLoadRecords.DisbursingOfficerComboBox(DataTableDisbursingOfficer(), cmbCollectingDisbursingOfficer, "full_name", "id");
        }

        private void cmbCollectingDisbursingOfficer_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (journalName == "Cash Disbursements Journal" || journalName == "Cash Receipts Journal")
                {
                    string message = journalName == "Cash Disbursements Journal" ? "Disbursing Officer" : "Collecting Officer";
                    //e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbCollectingDisbursingOfficer, message);
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbCollectingDisbursingOfficer_Validated(object sender, EventArgs e)
        {
            //Helper.ClearErrorComboBox(errorProvider1, cmbCollectingDisbursingOfficer);
        }

        private void SetGeneralJournalFields()
        {
            //lblCheckORPaidDate.Visible = false;
            //dtpCheckORPaid.Enabled = false;

            //lblCheckNo.Text = "Check No.";
            //lblCheckNo.Visible = true;
            //txtCheckNo.Enabled = true;

            //lblRciOrADANo.Text = "OR No.";
            //lblRciOrADANo.Visible = true;
            //txtRCIORADA.Enabled = true;

            //lblDVRCDNo.Text = "DV No.";
            //lblDVRCDNo.Visible = true;
            //txtDVRCDNo.Enabled = true;

            //lblCollectingDisbursingOfficer.Visible = false;
            //cmbCollectingDisbursingOfficer.Enabled = false;
            //cmbCollectingDisbursingOfficer.DataSource = null;
            //cmbCollectingDisbursingOfficer.Text = string.Empty;
            dgAccounts.Columns["IsDeposit"].Visible = false;
        }

        private void SetProcurementReceivedJournalFields()
        {
            //lblCheckORPaidDate.Visible = false;
            //dtpCheckORPaid.Enabled = false;

            //lblCheckNo.Visible = false;
            //txtCheckNo.Enabled = false;
            //txtCheckNo.Text = string.Empty;

            //lblRciOrADANo.Visible = false;
            //txtRCIORADA.Enabled = false;
            //txtRCIORADA.Text = string.Empty;

            //lblDVRCDNo.Visible = false;
            //txtDVRCDNo.Enabled = false;
            //txtDVRCDNo.Text = string.Empty;

            //lblCollectingDisbursingOfficer.Visible = false;
            //cmbCollectingDisbursingOfficer.Enabled = false;
            //cmbCollectingDisbursingOfficer.DataSource = null;
            //cmbCollectingDisbursingOfficer.Text = string.Empty;
            dgAccounts.Columns["IsDeposit"].Visible = false;
        }

        private void SetCashDisbursementsJournalFields()
        {
            //lblCheckORPaidDate.Text = "Date Paid";
            //lblCheckORPaidDate.Visible = true;
            //dtpCheckORPaid.Enabled = true;

            //lblCheckNo.Visible = false;
            //txtCheckNo.Enabled = false;
            //txtCheckNo.Text = string.Empty;

            //lblRciOrADANo.Visible = false;
            //txtRCIORADA.Enabled = false;
            //txtRCIORADA.Text = string.Empty;

            //lblDVRCDNo.Text = "DV No.";
            //lblDVRCDNo.Visible = true;
            //txtDVRCDNo.Enabled = true;

            //lblCollectingDisbursingOfficer.Text = "Disbursing Officer";
            //lblCollectingDisbursingOfficer.Visible = true;
            //cmbCollectingDisbursingOfficer.Enabled = true;
            dgAccounts.Columns["IsDeposit"].Visible = false;
        }

        private void SetCashReceiptsJournalFields()
        {
            //lblCheckORPaidDate.Text = "OR Date";
            //lblCheckORPaidDate.Visible = true;
            //dtpCheckORPaid.Enabled = true;

            //lblCheckNo.Visible = false;
            //txtCheckNo.Enabled = false;
            //txtCheckNo.Text = string.Empty;

            //lblRciOrADANo.Text = "OR No.";
            //lblRciOrADANo.Visible = true;
            //txtRCIORADA.Enabled = true;

            //lblDVRCDNo.Text = "RCD No.";
            //lblDVRCDNo.Visible = true;
            //txtDVRCDNo.Visible = true;

            //lblCollectingDisbursingOfficer.Text = "Collecting Officer";
            //lblCollectingDisbursingOfficer.Visible = true;
            //cmbCollectingDisbursingOfficer.Enabled = true;
            dgAccounts.Columns["IsDeposit"].Visible = true;

            dgAccounts.Rows.Clear();
        }

        private void SetADAJournalFields()
        {
            //lblCheckORPaidDate.Visible = false;
            //dtpCheckORPaid.Enabled = false;

            //lblCheckNo.Visible = false;
            //txtCheckNo.Enabled = false;
            //txtCheckNo.Text = string.Empty;

            //lblRciOrADANo.Text = "ADA No.";
            //lblRciOrADANo.Visible = true;
            //txtRCIORADA.Enabled = true;

            //lblDVRCDNo.Text = "DV No.";
            //lblDVRCDNo.Visible = true;
            //txtDVRCDNo.Enabled = true;

            //lblCollectingDisbursingOfficer.Visible = false;
            //cmbCollectingDisbursingOfficer.Enabled = false;
            //cmbCollectingDisbursingOfficer.DataSource = null;
            //cmbCollectingDisbursingOfficer.Text = string.Empty;
            dgAccounts.Columns["IsDeposit"].Visible = false;
        }

        private void SetCheckDisbursementsJournalFields()
        {
            //lblCheckORPaidDate.Text = "Check Date";
            //lblCheckORPaidDate.Visible = true;
            //dtpCheckORPaid.Enabled = true;

            //lblCheckNo.Text = "Check No.";
            //lblCheckNo.Visible = true;
            //txtCheckNo.Enabled = true;

            //lblRciOrADANo.Text = "RCI No.";
            //lblRciOrADANo.Visible = true;
            //txtRCIORADA.Enabled = true;

            //lblDVRCDNo.Text = "DV No.";
            //lblDVRCDNo.Visible = true;
            //txtDVRCDNo.Enabled = true;

            //lblCollectingDisbursingOfficer.Visible = false;
            //cmbCollectingDisbursingOfficer.Enabled = false;
            //cmbCollectingDisbursingOfficer.DataSource = null;
            //cmbCollectingDisbursingOfficer.Text = string.Empty;
            dgAccounts.Columns["IsDeposit"].Visible = false;
        }

        #endregion Unused Methods

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
                if (textBox.Name == txtJEVNo.Name || textBox.Name == txtFundsJevNo.Name)
                    continue;

                textBox.ReadOnly = isReadOnly;
            }

            flowLayoutPanelFunds.Enabled = !isReadOnly;
            flowLayoutPanelJournals.Enabled = !isReadOnly;
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
                fundId == 0 ? "Please select a fund source" : string.Empty,
                journalId == 0 ? "Please select the type of journal" : string.Empty,
                errorProvider1.GetError(txtJEVNo),
                dgAccounts.Rows.Count == 0 ? "Please add a FPP, account & amount in the table provided." : string.Empty,
                errorProvider1.GetError(txtPayee),
                errorProvider1.GetError(txtExplanation),
                //errorProvider1.GetError(cmbCollectingDisbursingOfficer)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            jevId = 0;
            jevNo = string.Empty;
            oldJournalId = 0;
            journalName = string.Empty;

            txtJEVNo.Text = string.Empty;
            txtRefNo.Text = string.Empty;
            txtPayee.Text = string.Empty;
            txtExplanation.Text = string.Empty;

            //txtCheckNo.Text = string.Empty;
            //txtRCIORADA.Text = string.Empty;
            //txtDVRCDNo.Text = string.Empty;

            dgAccounts.Rows.Clear();
            tlStrpLblDebit.Text = 0.ToString("N2");
            tlStrpLblCredit.Text = 0.ToString("N2");
            flowLayoutPanelFunds.Controls.OfType<RadioButton>().FirstOrDefault(r => ((byte)r.Tag == 1) ? r.Checked = true : r.Checked = false);
            flowLayoutPanelJournals.Controls.OfType<RadioButton>().FirstOrDefault(r => ((byte)r.Tag == 1) ? r.Checked = true : r.Checked = false);

            dtpDateEntry.Value = DateTime.Now;
        }

        internal void LoadFunds()
        {
            var funds = AccFactory.FundsRepository().GetRecords();

            foreach (DataRow fund in funds.Rows)
            {
                var radFund = new RadioButton
                {
                    Text = fund["fund_name"].ToString(),
                    Tag = fund["id"],
                    AutoSize = true,
                    Appearance = Appearance.Button
                };

                // making general fund as default
                if (fund["fund_name"].ToString() == "General Fund")
                {
                    radFund.Checked = true;
                    fundId = Convert.ToByte(fund["id"]);
                }

                flowLayoutPanelFunds.Controls.Add(radFund);

                radFund.Click += new EventHandler(radioFunds_Click);
                radFund.CheckedChanged += new EventHandler(radioFunds_CheckedChanged);
            }
        }

        internal string GetJEVSeriesNo()
        {
            try
            {
                var jev = AccFactory.JEVRepository().GetLastJevNoSeries(fundId);
                return jev.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            return "0000";
        }

        internal string GenerateJevTemplateNo()
        {
            Dictionary<string, string> fund = AccFactory.FundsRepository().GetRecordByID(fundId);

            string fundCode = fund["fund_code"];

            string year = dtpDateEntry.Value.Year.ToString();
            string month = dtpDateEntry.Value.ToString("MM");

            return $"{fundCode}-{year}-{month}";
        }

        private void radioFunds_Click(object sender, EventArgs e)
        {
            try
            {
                var radFund = sender as RadioButton;
                fundId = Convert.ToByte(radFund.Tag);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void radioFunds_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var radFund = sender as RadioButton;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void SumDebitCredit()
        {
            try
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
            catch (Exception ex) { MessageBox.Show(ex.Message); ; }
        }

        private void ToggleJournalFields(string journal)
        {
            splitContainer1.Panel2Collapsed = false;

            switch (journal)
            {
                case "General Journal":
                    customTabControl2.SelectedTab = tbPgGenJrnl;
                    break;

                case "Cash Receipts Journal":
                    customTabControl2.SelectedTab = tbPgCshRcptsJrnl;
                    break;

                case "Cash Disbursements Journal":
                    customTabControl2.SelectedTab = tbPgCshDsbrsmntJrnl;
                    break;

                case "Check Disbursements Journal":
                    customTabControl2.SelectedTab = tbPgChkDsbrsmntJrnl;
                    break;

                case "Authority to Debit Account Disbursement Journal":
                    customTabControl2.SelectedTab = tbPgAuthDbtAccDsbrsmntJrnl;
                    break;

                default:
                    splitContainer1.Panel2Collapsed = true;
                    break;
            }
        }

        private void radioJournals_Click(object sender, EventArgs e)
        {
            try
            {
                var radJournal = sender as RadioButton;
                if (radJournal.Checked) ToggleJournalFields(journalName);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void radioJournals_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var radJournal = sender as RadioButton;
                journalId = Convert.ToByte(radJournal.Tag);
                journalName = radJournal.Text.Trim();
                ClearErrors();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void OnLoad()
        {
            LoadFunds();
            LoadJournals();
            ToggleIndicators();
            btnBack.Visible = false;
            btnSave.Visible = false;
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

        private void customTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ToggleIndicators();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ToggleIndicators()
        {
            foreach (Label label in pnlIndctors.Controls.OfType<Label>())
            {
                // Get index of the tab to match with label order (if you align them)
                int tabIndex = customTabControl1.SelectedIndex;

                // Highlight the label that matches the active tab
                if (tabIndex == label.TabIndex)
                    label.Text = "◉ " + label.Text.TrimStart('◉', '○', ' ');
                else
                    label.Text = "○ " + label.Text.TrimStart('◉', '○', ' ');
            }
        }

        private void NavigateTab(int direction)
        {
            int newIndex = customTabControl1.SelectedIndex + direction;
            int lastIndex = customTabControl1.TabPages.Count - 1;

            // Clamp the index within valid range
            newIndex = Math.Max(0, Math.Min(newIndex, lastIndex));

            customTabControl1.SelectedIndex = newIndex;

            // Update button visibility
            btnBack.Visible = newIndex > 0;
            btnNext.Visible = newIndex < lastIndex;
            btnSave.Visible = newIndex == lastIndex;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                NavigateTab(+1);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                NavigateTab(-1);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void ClearErrors()
        {
            Helper.ClearErrorTextBox(errorProvider1, txtPayee);
            Helper.ClearMaskedTextboxError(errorProvider1, txtJEVNo);
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
                var frmJevAccountAdd = new frmJevAccAdd(this);
                frmJevAccountAdd.ucJEVAccount.journalName = journalName;
                frmJevAccountAdd.ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tlStrpBtnEditAcc_Click(object sender, EventArgs e)
        {
            try
            {
                var frmJevAccountEdit = new frmJevAccEdit(this);
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
    }
}