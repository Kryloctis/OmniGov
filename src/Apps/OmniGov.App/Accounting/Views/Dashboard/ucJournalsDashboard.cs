using OmniGov.Accounting.Data.Factories;
using OmniGov.App.Helpers;
using OmniGov.Core.Factories;

namespace OmniGov.App.Accounting.Views.Dashboard
{
    public partial class ucJournalsDashboard : UserControl
    {
        public ucJournalsDashboard()
        {
            InitializeComponent();
        }

        internal void Onload()
        {
            LoadFunds();
            LoadCounters();
            numdYear.Value = Helper.GetCurrentDate().Year;
        }

        private void cmbxFunds_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadCounters();
        }

        private void LoadFunds()
        {
            var dtFunds = Factory.FundsRepository().GetRecords();
            var newRow = dtFunds.NewRow();
            newRow["id"] = 0;
            newRow["fund_name"] = "All";

            dtFunds.Rows.InsertAt(newRow, 0);

            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "id", "fund_name");
        }

        private void LoadCounters()
        {
            string fundName = cmbxFunds.Text.Trim();
            int year = (int)numdYear.Value;
            int generalJournalCount = AccountingFactory.JEVRepository()
                                    .JevCounterByJournal(fundName, year, "General Journal");

            int cashReceiptsJournalCount = AccountingFactory.JEVRepository()
                                    .JevCounterByJournal(fundName, year, "Cash Receipts Journal");

            int procurementReceivedJournalCount = AccountingFactory.JEVRepository()
                                    .JevCounterByJournal(fundName, year, "Procurement Received Journal");

            int cashDisbursementJournalCount = AccountingFactory.JEVRepository()
                                    .JevCounterByJournal(fundName, year, "Cash Disbursements Journal");

            int checkDisbursementJournalCount = AccountingFactory.JEVRepository()
                                    .JevCounterByJournal(fundName, year, "Check Disbursements Journal");

            int adaDisbursementJournalCount = AccountingFactory.JEVRepository()
                                    .JevCounterByJournal(fundName, year, "Authority to Debit Account Disbursement Journal");

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

        private void numdYear_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadCounters();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}

