using ACC.Domain.Interfaces;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.JEV
{
    public partial class ucJEV : UserControl
    {
        internal bool isEdit = false;
        internal int jevId = 0;
        internal string jevNo;
        internal byte fundId = 0;
        internal byte journalId = 0;
        internal byte oldJournalId = 0;
        internal string journalName;

        public ucJEV()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgAccounts, true);
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
                if (textBox.Name == txtJEVNo.Name || textBox.Name == txtFundsJevNo.Name)
                    continue;

                textBox.ReadOnly = isReadOnly;
            }

            groupFunds.Enabled = !isReadOnly;
            groupJournals.Enabled = !isReadOnly;
            btnAddAccount.Enabled = !isReadOnly;
            btnEditAccount.Enabled = !isReadOnly;
            btnRemoveAccount.Enabled = !isReadOnly;
            cmbCollectingDisbursingOfficer.Enabled = !isReadOnly;

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
                epJEV.GetError(txtJEVNo),
                dgAccounts.Rows.Count == 0 ? "Please add a FPP, account & amount in the table provided." : string.Empty,
                epPayee.GetError(txtPayee),
                epExplanation.GetError(txtExplanation),
                epCollectingDisbursing.GetError(cmbCollectingDisbursingOfficer)
            };

            IError _errors = AccFactory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
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

            txtCheckNo.Text = string.Empty;
            txtRCIORADA.Text = string.Empty;
            txtDVRCDNo.Text = string.Empty;

            dgAccounts.Rows.Clear();
            txtDebitTotal.Text = 0.ToString("N2");
            txtCreditTotal.Text = 0.ToString("N2");
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
                    Appearance = Appearance.Button,
                    TextImageRelation = TextImageRelation.ImageBeforeText
                };

                // making general fund as default
                if (fund["fund_name"].ToString() == "General Fund")
                {
                    radFund.Checked = true;
                    fundId = Convert.ToByte(fund["id"]);
                    ShowCheckIcon(radFund);
                }

                flowLayoutPanelFunds.Controls.Add(radFund);

                radFund.Click += new EventHandler(radioFunds_Click);
                radFund.CheckedChanged += new EventHandler(radioFunds_CheckedChanged);
            }
        }

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
                radJournal.TextImageRelation = TextImageRelation.ImageBeforeText;

                if (journal["journal_name"].ToString() == CheckedJournal)
                {
                    radJournal.Checked = true;
                    journalId = Convert.ToByte(journal["id"]);
                    journalName = CheckedJournal;
                    ShowCheckIcon(radJournal);
                }

                flowLayoutPanelJournals.Controls.Add(radJournal);

                radJournal.Click += new EventHandler(radioJournals_Click);
                radJournal.CheckedChanged += new EventHandler(radioJournals_CheckedChanged);
            }
        }

        internal void LoadCollectingOfficer()
        {
            var dtCollectingOfficer = AccFactory.CollectingOfficerRepository().GetRecords();
            HelperLoadRecords.CollectingOfficerComboBox(dtCollectingOfficer, cmbCollectingDisbursingOfficer, "fullname", "id");
        }

        internal void LoadDisbursingOfficer()
        {
            var dtDisbursingOfficer = AccFactory.DisbursingOfficerRepository().GetRecords();
            HelperLoadRecords.DisbursingOfficerComboBox(dtDisbursingOfficer, cmbCollectingDisbursingOfficer, "fullname", "id");
        }

        private void ShowCheckIcon(RadioButton radioButton)
        {
            if (radioButton.Checked)
                radioButton.Image = Properties.Resources.ok14px;
            else
                radioButton.Image = null;
        }

        internal string GetJEVSeriesNo()
        {
            try
            {
                var jev = AccFactory.JEVRepository().GetLastJevNoSeries(fundId);
                return jev.ToString();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return "0000";
        }

        internal string GenerateJEVNumber()
        {
            var fund = AccFactory.FundsRepository().GetRecordByID(fundId);

            string fundCode = fund["fund_code"];

            string year = dtpDateEntry.Value.Year.ToString();
            string month = dtpDateEntry.Value.ToString("MM");

            return $"{fundCode}-{year}-{month}";
        }

        private void radioFunds_Click(object sender, EventArgs e)
        {
            var radFund = sender as RadioButton;
            fundId = Convert.ToByte(radFund.Tag);
        }

        private void radioFunds_CheckedChanged(object sender, EventArgs e)
        {
            var radFund = sender as RadioButton;
            ShowCheckIcon(radFund);
            btnAddAccount.Enabled = true;
        }

        #region Set Fields

        private void SetJournalFields(string journalName)
        {
            if (flowLayoutPanelJournals.Controls.Count < 1)
                return;

            switch (journalName)
            {
                case "General Journal":
                    SetGeneralJournalFields();
                    break;

                case "Procurement Received Journal":
                    SetProcurementReceivedJournalFields();
                    break;

                case "Cash Disbursements Journal":
                    SetCashDisbursementsJournalFields();
                    LoadDisbursingOfficer();
                    break;

                case "Cash Receipts Journal":
                    SetCashReceiptsJournalFields();
                    LoadCollectingOfficer();
                    break;

                case "Check Disbursements Journal":
                    SetCheckDisbursementsJournalFields();
                    break;

                case "Authority to Debit Account Disbursement Journal":
                    SetADAJournalFields();
                    break;

                default:
                    break;
            }
        }

        private void SetGeneralJournalFields()
        {
            lblCheckORPaidDate.Visible = false;
            dtpCheckORPaid.Enabled = false;

            lblCheckNo.Text = "Check No.";
            lblCheckNo.Visible = true;
            txtCheckNo.Enabled = true;

            lblRciOrADANo.Text = "OR No.";
            lblRciOrADANo.Visible = true;
            txtRCIORADA.Enabled = true;

            lblDVRCDNo.Text = "DV No.";
            lblDVRCDNo.Visible = true;
            txtDVRCDNo.Enabled = true;

            lblCollectingDisbursingOfficer.Visible = false;
            cmbCollectingDisbursingOfficer.Enabled = false;
            cmbCollectingDisbursingOfficer.DataSource = null;
            cmbCollectingDisbursingOfficer.Text = string.Empty;
            dgAccounts.Columns["IsDeposit"].Visible = false;
        }

        private void SetProcurementReceivedJournalFields()
        {
            lblCheckORPaidDate.Visible = false;
            dtpCheckORPaid.Enabled = false;

            lblCheckNo.Visible = false;
            txtCheckNo.Enabled = false;
            txtCheckNo.Text = string.Empty;

            lblRciOrADANo.Visible = false;
            txtRCIORADA.Enabled = false;
            txtRCIORADA.Text = string.Empty;

            lblDVRCDNo.Visible = false;
            txtDVRCDNo.Enabled = false;
            txtDVRCDNo.Text = string.Empty;

            lblCollectingDisbursingOfficer.Visible = false;
            cmbCollectingDisbursingOfficer.Enabled = false;
            cmbCollectingDisbursingOfficer.DataSource = null;
            cmbCollectingDisbursingOfficer.Text = string.Empty;
            dgAccounts.Columns["IsDeposit"].Visible = false;
        }

        private void SetCashDisbursementsJournalFields()
        {
            lblCheckORPaidDate.Text = "Date Paid";
            lblCheckORPaidDate.Visible = true;
            dtpCheckORPaid.Enabled = true;

            lblCheckNo.Visible = false;
            txtCheckNo.Enabled = false;
            txtCheckNo.Text = string.Empty;

            lblRciOrADANo.Visible = false;
            txtRCIORADA.Enabled = false;
            txtRCIORADA.Text = string.Empty;

            lblDVRCDNo.Text = "DV No.";
            lblDVRCDNo.Visible = true;
            txtDVRCDNo.Enabled = true;

            lblCollectingDisbursingOfficer.Text = "Disbursing Officer";
            lblCollectingDisbursingOfficer.Visible = true;
            cmbCollectingDisbursingOfficer.Enabled = true;
            dgAccounts.Columns["IsDeposit"].Visible = false;
        }

        private void SetCashReceiptsJournalFields()
        {
            lblCheckORPaidDate.Text = "OR Date";
            lblCheckORPaidDate.Visible = true;
            dtpCheckORPaid.Enabled = true;

            lblCheckNo.Visible = false;
            txtCheckNo.Enabled = false;
            txtCheckNo.Text = string.Empty;

            lblRciOrADANo.Text = "OR No.";
            lblRciOrADANo.Visible = true;
            txtRCIORADA.Enabled = true;

            lblDVRCDNo.Text = "RCD No.";
            lblDVRCDNo.Visible = true;
            txtDVRCDNo.Visible = true;

            lblCollectingDisbursingOfficer.Text = "Collecting Officer";
            lblCollectingDisbursingOfficer.Visible = true;
            cmbCollectingDisbursingOfficer.Enabled = true;
            dgAccounts.Columns["IsDeposit"].Visible = true;

            dgAccounts.Rows.Clear();
        }

        private void SetADAJournalFields()
        {
            lblCheckORPaidDate.Visible = false;
            dtpCheckORPaid.Enabled = false;

            lblCheckNo.Visible = false;
            txtCheckNo.Enabled = false;
            txtCheckNo.Text = string.Empty;

            lblRciOrADANo.Text = "ADA No.";
            lblRciOrADANo.Visible = true;
            txtRCIORADA.Enabled = true;

            lblDVRCDNo.Text = "DV No.";
            lblDVRCDNo.Visible = true;
            txtDVRCDNo.Enabled = true;

            lblCollectingDisbursingOfficer.Visible = false;
            cmbCollectingDisbursingOfficer.Enabled = false;
            cmbCollectingDisbursingOfficer.DataSource = null;
            cmbCollectingDisbursingOfficer.Text = string.Empty;
            dgAccounts.Columns["IsDeposit"].Visible = false;
        }

        private void SetCheckDisbursementsJournalFields()
        {
            lblCheckORPaidDate.Text = "Check Date";
            lblCheckORPaidDate.Visible = true;
            dtpCheckORPaid.Enabled = true;

            lblCheckNo.Text = "Check No.";
            lblCheckNo.Visible = true;
            txtCheckNo.Enabled = true;

            lblRciOrADANo.Text = "RCI No.";
            lblRciOrADANo.Visible = true;
            txtRCIORADA.Enabled = true;

            lblDVRCDNo.Text = "DV No.";
            lblDVRCDNo.Visible = true;
            txtDVRCDNo.Enabled = true;

            lblCollectingDisbursingOfficer.Visible = false;
            cmbCollectingDisbursingOfficer.Enabled = false;
            cmbCollectingDisbursingOfficer.DataSource = null;
            cmbCollectingDisbursingOfficer.Text = string.Empty;
            dgAccounts.Columns["IsDeposit"].Visible = false;
        }

        #endregion Set Fields

        private void radioJournals_Click(object sender, EventArgs e)
        {
            var radJournals = sender as RadioButton;
            journalId = Convert.ToByte(radJournals.Tag);
            ClearErrors();
            SumDebitCredit();
        }

        private void radioJournals_CheckedChanged(object sender, EventArgs e)
        {
            var radJournal = sender as RadioButton;
            journalId = Convert.ToByte(radJournal.Tag);
            ShowCheckIcon(radJournal);
            journalName = radJournal.Text.Trim();
            SetJournalFields(journalName);
        }

        private void OnLoad()
        {
            try
            {
                if (!DesignMode)
                {
                    LoadFunds();
                    LoadJournals();
                    SetJournalFields("General Journal");
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ucJEV_Load(object sender, EventArgs e)
        {
            OnLoad();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            var frmJevAccountAdd = new frmJEVAccountAdd(this);
            frmJevAccountAdd.ucJEVAccount.journalName = journalName;
            frmJevAccountAdd.ShowDialog();
        }

        private void EnableDisableButtons(DataGridView dgv, Button btnEdit, Button btnDelete)
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
            EnableDisableButtons(dgAccounts, btnEditAccount, btnRemoveAccount);
        }

        private void dgAccounts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = (DataGridView)sender;
            if (grid.Columns[e.ColumnIndex].Name == "IsDeposit")
            {
                e.Value = (bool)e.Value ? "Deposit" : "Collection";
                e.FormattingApplied = true;
            }
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

                txtDebitTotal.Text = totalDebit.ToString("N2");
                txtCreditTotal.Text = totalCredit.ToString("N2");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); ; }
        }

        private void RemoveRow()
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

        private void btnRemoveAccount_Click(object sender, EventArgs e)
        {
            RemoveRow();
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            var frmJevAccountEdit = new frmJEVAccountEdit(this);
            frmJevAccountEdit.ucJEVAccount.journalName = journalName;
            frmJevAccountEdit.ShowDialog();
        }

        internal void ClearErrors()
        {
            Helper.ClearErrorTextBox(epPayee, txtPayee);
            Helper.ClearMaskedTextboxError(epJEV, txtJEVNo);
            Helper.ClearErrorTextBox(epExplanation, txtExplanation);
            Helper.ClearErrorComboBox(epCollectingDisbursing, cmbCollectingDisbursingOfficer);
        }

        #region Validations

        private void txtJEVNo_Validating(object sender, CancelEventArgs e)
        {
            //int year = dtpDateEntry.Value.Year;

            //if (!txtJEVNo.MaskCompleted)
            //{
            //    epJEV.SetError(txtJEVNo, "Please enter a valid series number");
            //    e.Cancel = true;
            //}

            //string jevNo = txtJEVNo.Text;
            //bool jevNoExist;
            //if (jevId == 0)
            //    jevNoExist = AccFactory.JEVRepository().JevNumberExistBy_JevNo_FundId_Year(jevNo, fundId, year);
            //else
            //    jevNoExist = AccFactory.JEVRepository().JevNumberExistBy_JevId_JevNo_FundId_Year(jevId, jevNo, fundId, year);

            //if (jevNoExist)
            //{
            //    epJEV.SetError(txtJEVNo, "JEV number already exist.");
            //    e.Cancel = true;
            //}
        }

        private void txtJEVNo_Validated(object sender, EventArgs e)
        {
            //epJEV.SetError(txtJEVNo, string.Empty);
        }

        private void txtPayee_Validating(object sender, CancelEventArgs e)
        {
            if (txtPayee.Enabled)
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(epPayee, txtPayee, lblPayee.Text);
            }
        }

        private void txtPayee_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epPayee, txtPayee);
        }

        private void txtExplanation_Validating(object sender, CancelEventArgs e)
        {
            if (txtExplanation.Enabled)
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(epExplanation, txtExplanation, lblExplanation.Text);
            }
        }

        private void txtExplanation_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epExplanation, txtExplanation);
        }

        private void cmbCollectingDisbursingOfficer_Validating(object sender, CancelEventArgs e)
        {
            if (journalName == "Cash Disbursements Journal" || journalName == "Cash Receipts Journal")
            {
                string message = journalName == "Cash Disbursements Journal" ? "Disbursing Officer" : "Collecting Officer";
                e.Cancel = Helper.ShowErrorComboBoxEmpty(epCollectingDisbursing, cmbCollectingDisbursingOfficer, message);
            }
        }

        private void cmbCollectingDisbursingOfficer_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epCollectingDisbursing, cmbCollectingDisbursingOfficer);
        }

        #endregion Validations
    }
}