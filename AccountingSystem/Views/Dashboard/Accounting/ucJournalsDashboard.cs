using ACC.Data;
using LFS.Views.Reports.Journals;
using LFS;
using System;
using System.Windows.Forms;

namespace LFS.Views.Dashboard.AccountingDashboard
{
    public partial class ucJournalsDashboard : UserControl
    {
        public ucJournalsDashboard()
        {
            InitializeComponent();
        }

        private void ucJournalsDashboard_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadFunds();
                LoadCounters();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LoadCounters();
        }

        private void cmbxFunds_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadCounters();
        }

        private void LoadFunds()
        {
            var dtFunds = AccFactory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "fund_name", "id");
        }

        private void LoadCounters()
        {
            string fundName = cmbxFunds.Text.Trim();
            int month = dateTimePicker1.Value.Month;
            int year = dateTimePicker1.Value.Year;
            int generalJournalCount = AccFactory.JEVRepository().JevCounterByJournal(fundName, month, year, "General Journal");
            int cashReceiptsJournalCount = AccFactory.JEVRepository().JevCounterByJournal(fundName, month, year, "Cash Receipts Journal");
            int procurementReceivedJournalCount = AccFactory.JEVRepository().JevCounterByJournal(fundName, month, year, "Procurement Received Journal");
            int cashDisbursementJournalCount = AccFactory.JEVRepository().JevCounterByJournal(fundName, month, year, "Cash Disbursements Journal");
            int checkDisbursementJournalCount = AccFactory.JEVRepository().JevCounterByJournal(fundName, month, year, "Check Disbursements Journal");
            int adaDisbursementJournalCount = AccFactory.JEVRepository().JevCounterByJournal(fundName, month, year, "Authority to Debit Account Disbursement Journal");

            lblGeneralJournalCount.Text = generalJournalCount.ToString();
            lblCashReceiptsJournalCount.Text = cashReceiptsJournalCount.ToString();
            lblProcurementReceivedJournalCount.Text = procurementReceivedJournalCount.ToString();
            lblCashDisbursementsJournalCount.Text = cashDisbursementJournalCount.ToString();
            lblCheckDisbursementsJournalCount.Text = checkDisbursementJournalCount.ToString();
            lblADADisbursementsJournal.Text = adaDisbursementJournalCount.ToString();
        }

        private void lnkADAdisbursementsJournal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void lnkCashDisbursementJournal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void lnkCashReceiptJournal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void lnkCheckDisbursementsJournal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void lnkGeneralJournal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void lnkProcurementReceivedJournal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }
    }
}