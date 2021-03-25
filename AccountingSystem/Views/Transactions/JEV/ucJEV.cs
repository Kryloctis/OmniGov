using ACC.Domain.Interfaces;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.JEV
{
    public partial class ucJEV : UserControl
    {
        internal int jevId = 0;
        internal byte fundId = 0;
        internal byte journalId = 0;
        internal string journalName;

        public ucJEV()
        {
            InitializeComponent();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[6];
            errorArray[0] = fundId == 0 ? "Please select a fund source" : string.Empty;
            errorArray[1] = journalId == 0 ? "Please select the type of journal" : string.Empty;
            errorArray[2] = epJEV.GetError(txtJEVNo);
            errorArray[3] = dgAccounts.Rows.Count == 0 ? "Please add a FPP, account & amount in the table provided." : string.Empty;
            errorArray[4] = epRefNo.GetError(txtRefNo);
            errorArray[5] = epCollectingOfficerPayee.GetError(txtPayeeCollectingOfficer);

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }

        internal void ResetForm()
        {

            txtJEVNo.Clear();
            txtRefNo.Clear();
            txtPayeeCollectingOfficer.Clear();
            txtExplanation.Clear();

            dgAccounts.Rows.Clear();
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

                if (fund["fund_name"].ToString() == "General Fund")
                {
                    radFund.Checked = true;
                    fundId = Convert.ToByte(fund["id"]);
                    ShowCheckIcon(radFund);

                    GenerateJEVNumber(fund["fund_code"].ToString(), dtpDateEntry.Value.Year.ToString(), dtpDateEntry.Value.Month.ToString("00"));
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
                    ShowCheckIcon(radJournal);
                }

                flowLayoutPanelJournals.Controls.Add(radJournal);

                radJournal.Click += new EventHandler(radioJournals_Click);
                radJournal.CheckedChanged += new EventHandler(radioJournals_CheckedChanged);
            }
        }

        internal void LoadCollectingOfficer()
        {
            var dtCollectingOfficer = Factory.CollectingOfficerRepository().GetRecords();
            HelperLoadRecords.CollectingOfficerComboBox(dtCollectingOfficer, cmbCollectingOfficer, "fullname", "id");
        }

        private void ShowCheckIcon(RadioButton radioButton)
        {
            if (radioButton.Checked)
                radioButton.Image = Properties.Resources.ok14px;
            else
                radioButton.Image = null;
        }

        private void GenerateJEVNumber(string fundCode = null, string year = null, string month = null, string seriesNo = null)
        {
            string jevNo = txtFundsJevNo.Text;
            string[] part = jevNo.Split("-");

            fundCode ??= part[0];
            year ??= part[1];
            month ??= part[2];

            txtFundsJevNo.Text = $"{fundCode}-{year}-{month}";
        }

        private void SetJEVNoOfFundCode()
        {
            var fund = Factory.FundsRepository().GetRecordByID(fundId);
            GenerateJEVNumber(fund["fund_code"]);
        }

        private void radioFunds_Click(object sender, EventArgs e)
        {
            var radFund = sender as RadioButton;
            fundId = Convert.ToByte(radFund.Tag);
            SetJEVNoOfFundCode();
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
        }

        private void EnableDisableAdditionalFields(bool statusRefNo, bool statusPayee, bool statusCollectingOfficer)
        {
            lblRefNo.Visible = statusRefNo;
            txtRefNo.Enabled = statusRefNo;

            if (statusPayee || statusCollectingOfficer)
                lblCollectingOfficerPayee.Visible = true;
            else
                lblCollectingOfficerPayee.Visible = false;


            txtPayeeCollectingOfficer.Enabled = statusPayee;
            cmbCollectingOfficer.Visible = statusCollectingOfficer;
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
                case "Procurement Received Journal":
                case "Cash Disbursements Journal":
                    EnableDisableAdditionalFields(false, false, false);

                    epRefNo.SetError(txtRefNo, string.Empty);
                    epCollectingOfficerPayee.SetError(txtPayeeCollectingOfficer, string.Empty);
                    break;
                case "Cash Receipts Journal":
                    EnableDisableAdditionalFields(true, false, true);

                    lblRefNo.Text = "RCD No.";
                    lblCollectingOfficerPayee.Text = "Collecting Officer";
                    break;
                case "Check Disbursements Journal":
                    EnableDisableAdditionalFields(true, true, false);

                    lblRefNo.Text = "Check No.";
                    lblCollectingOfficerPayee.Text = "Payee";
                    break;
                case "Advice to Debit Account Disbursement Journal":
                    EnableDisableAdditionalFields(true, false, false);

                    lblRefNo.Text = "ADA No.";
                    epCollectingOfficerPayee.SetError(txtPayeeCollectingOfficer, string.Empty);
                    break;

                default:
                    break;
            }
        }

        private void ucJEV_Load(object sender, EventArgs e)
        {
            Helper.DatagridDefaultStyle(dgAccounts);
            LoadFunds();
            LoadJournals();
            LoadCollectingOfficer();

            btnEditAccount.Enabled = false;
            btnRemoveAccount.Enabled = false;
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            _ = new frmJEVAccountAdd(this).ShowDialog();
        }

        private void dtpDateEntry_ValueChanged(object sender, EventArgs e)
        {
            GenerateJEVNumber(null, dtpDateEntry.Value.Year.ToString(), dtpDateEntry.Value.Month.ToString("00"));
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

            string jevNo = $"{txtFundsJevNo.Text}-{txtJEVNo.Text}";
            bool jevNoExist;
            if (jevId == 0)
                 jevNoExist = Factory.JEVRepository().JevNumberExist(jevNo);
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

        private void txtRefNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtRefNo.Enabled)
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(epRefNo, txtRefNo, lblRefNo.Text);
            }
        }

        private void txtRefNo_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epRefNo, txtRefNo);
        }

        private void txtPayeeCollectingOfficer_Validating(object sender, CancelEventArgs e)
        {
            if (txtPayeeCollectingOfficer.Enabled)
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(epCollectingOfficerPayee, txtPayeeCollectingOfficer, lblCollectingOfficerPayee.Text);
            }
        }

        private void txtPayeeCollectingOfficer_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epCollectingOfficerPayee, txtPayeeCollectingOfficer);
        }

        private void btnRemoveAccount_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgAccounts.SelectedRows)
            {
                dgAccounts.Rows.Remove(row);
            }
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            _ = new frmJEVAccountEdit(this).ShowDialog();
        }
    }
}