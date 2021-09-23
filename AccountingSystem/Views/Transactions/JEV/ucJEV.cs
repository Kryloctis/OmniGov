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
        internal int jevId = 0;
        internal string jevNo;
        internal byte fundId = 0;
        internal byte journalId = 0;
        internal byte oldJournalId = 0;
        internal string journalName;
        internal byte isApproved = 0;
        internal byte isDisapproved = 0;
        internal byte isCancelled = 0;

        public ucJEV()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgAccounts);
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[7];
            errorArray[0] = fundId == 0 ? "Please select a fund source" : string.Empty;
            errorArray[1] = journalId == 0 ? "Please select the type of journal" : string.Empty;
            errorArray[2] = epJEV.GetError(txtJEVNo);
            errorArray[3] = dgAccounts.Rows.Count == 0 ? "Please add a FPP, account & amount in the table provided." : string.Empty;
            errorArray[4] = epPayee.GetError(txtPayee);
            errorArray[5] = epExplanation.GetError(txtExplanation);
            errorArray[6] = epCollectingDisbursing.GetError(cmbCollectingDisbursingOfficer);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {
            jevId = 0;
            jevNo = string.Empty;
            oldJournalId = 0;
            journalName = string.Empty;
            isApproved = 0;
            isDisapproved = 0;
            isCancelled = 0;

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

            txtJEVNo.Text = GetJEVSeriesNo();
        }

        internal void LoadFunds()
        {
            var funds = Factory.FundsRepository().GetRecords();

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

                    GenerateJEVNumber();
                }


                flowLayoutPanelFunds.Controls.Add(radFund);

                radFund.Click += new EventHandler(radioFunds_Click);
                radFund.CheckedChanged += new EventHandler(radioFunds_CheckedChanged);
            }
        }

        internal void LoadJournals()
        {
            string CheckedJournal = "General Journal";
            var journals = Factory.JournalsRepository().GetRecords();

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

            SetGeneralJournalFields();

        }

        internal void LoadCollectingOfficer()
        {
            var dtCollectingOfficer = Factory.CollectingOfficerRepository().GetRecords();
            HelperLoadRecords.CollectingOfficerComboBox(dtCollectingOfficer, cmbCollectingDisbursingOfficer, "fullname", "id");
        }

        internal void LoadDisbursingOfficer()
        {
            var dtDisbursingOfficer = Factory.DisbursingOfficerRepository().GetRecords();
            HelperLoadRecords.DisbursingOfficerComboBox(dtDisbursingOfficer, cmbCollectingDisbursingOfficer, "fullname", "id");
        }

        private void ShowCheckIcon(RadioButton radioButton)
        {
            if (radioButton.Checked)
                radioButton.Image = Properties.Resources.ok14px;
            else
                radioButton.Image = null;
        }

        private void GenerateJEVNumber()
        {
            var fund = Factory.FundsRepository().GetRecordByID(fundId);

            string fundCode = fund["fund_code"];

            string year = dtpDateEntry.Value.Year.ToString();
            string month = dtpDateEntry.Value.ToString("MM");

            txtFundsJevNo.Text = $"{fundCode}-{year}-{month}";
        }

        private void radioFunds_Click(object sender, EventArgs e)
        {
            var radFund = sender as RadioButton;
            fundId = Convert.ToByte(radFund.Tag);
            GenerateJEVNumber();
        }

        private void radioFunds_CheckedChanged(object sender, EventArgs e)
        {
            var radFund = sender as RadioButton;
            ShowCheckIcon(radFund);
            btnAddAccount.Enabled = true;
        }

        private void radioJournals_Click(object sender, EventArgs e)
        {
            var radJournals = sender as RadioButton;
            journalId = Convert.ToByte(radJournals.Tag);
            ClearErrors();
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
        }

        private void radioJournals_CheckedChanged(object sender, EventArgs e)
        {
            var radJournal = sender as RadioButton;
            journalId = Convert.ToByte(radJournal.Tag);
            ShowCheckIcon(radJournal);
            journalName = radJournal.Text.Trim();

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

        private void ucJEV_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                Helper.DatagridFullRowSelectStyle(dgAccounts, true);
                LoadFunds();
                LoadJournals();

                txtJEVNo.Text = GetJEVSeriesNo();
                btnEditAccount.Enabled = false;
                btnRemoveAccount.Enabled = false;
            }
        }

        internal string GetJEVSeriesNo()
        {
            var jev = Factory.JEVRepository().GetLastJevNoSeries();
            return jev.ToString();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            _ = new frmJEVAccountAdd(this).ShowDialog();
        }

        private void dtpDateEntry_ValueChanged(object sender, EventArgs e)
        {
            GenerateJEVNumber();
        }

        private void dgAccounts_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableButtons(dgAccounts, btnEditAccount, btnRemoveAccount);
        }

        private void txtJEVNo_Validating(object sender, CancelEventArgs e)
        {
            if (!txtJEVNo.MaskCompleted)
            {
                epJEV.SetError(txtJEVNo, "Please enter a valid series number");
                e.Cancel = true;
            }

            string jevNo = txtJEVNo.Text;
            bool jevNoExist;
            if (jevId == 0)
                jevNoExist = Factory.JEVRepository().JevNumberAndYearExist(jevNo, dtpDateEntry.Value.Year);
            else
                jevNoExist = Factory.JEVRepository().JevNumberExist(jevNo, jevId);

            if (jevNoExist)
            {
                epJEV.SetError(txtJEVNo, "JEV number already exist.");
                e.Cancel = true;
            }
        }

        private void txtJEVNo_Validated(object sender, EventArgs e)
        {
            epJEV.SetError(txtJEVNo, string.Empty);
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

                    txtDebitTotal.Text = totalDebit.ToString("N2");
                    txtCreditTotal.Text = totalCredit.ToString("N2");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);;
            } 

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

        private void btnRemoveAccount_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgAccounts.SelectedRows)
            {
                dgAccounts.Rows.Remove(row);
            }
            SumDebitCredit();
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            _ = new frmJEVAccountEdit(this).ShowDialog();
        }

        private void dgAccounts_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _ = new frmJEVAccountEdit(this).ShowDialog();
        }

        internal void ClearErrors()
        {
            Helper.ClearErrorTextBox(epPayee, txtPayee);
            Helper.ClearMaskedTextboxError(epJEV, txtJEVNo);
            Helper.ClearErrorTextBox(epExplanation, txtExplanation);
            Helper.ClearErrorComboBox(epCollectingDisbursing, cmbCollectingDisbursingOfficer);
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
    }
}