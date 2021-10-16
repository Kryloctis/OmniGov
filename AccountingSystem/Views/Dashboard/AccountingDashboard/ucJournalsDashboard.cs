using AccountingSystem.Views.Reports.Journals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Dashboard.AccountingDashboard
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
            var dtFunds = Factory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "fund_name", "id");
        }

        private void LoadCounters() 
        {
            string fundName = cmbxFunds.Text.Trim();
            int month = dateTimePicker1.Value.Month;
            int year = dateTimePicker1.Value.Year;
            int generalJournalCount = Factory.JEVRepository().JevCounterByJournal(fundName, month, year, "General Journal");
            int cashReceiptsJournalCount = Factory.JEVRepository().JevCounterByJournal(fundName, month, year, "Cash Receipts Journal");
            int procurementReceivedJournalCount = Factory.JEVRepository().JevCounterByJournal(fundName, month, year, "Procurement Received Journal");
            int cashDisbursementJournalCount = Factory.JEVRepository().JevCounterByJournal(fundName, month, year, "Cash Disbursements Journal");
            int checkDisbursementJournalCount = Factory.JEVRepository().JevCounterByJournal(fundName, month, year, "Check Disbursements Journal");
            int adaDisbursementJournalCount = Factory.JEVRepository().JevCounterByJournal(fundName, month, year, "Authority to Debit Account Disbursement Journal");

            lblGeneralJournalCount.Text = generalJournalCount.ToString();
            lblCashReceiptsJournalCount.Text = cashReceiptsJournalCount.ToString();
            lblProcurementReceivedJournalCount.Text = procurementReceivedJournalCount.ToString();
            lblCashDisbursementsJournalCount.Text = cashDisbursementJournalCount.ToString();
            lblCheckDisbursementsJournalCount.Text = checkDisbursementJournalCount.ToString();
            lblADADisbursementsJournal.Text = adaDisbursementJournalCount.ToString();
        }

        private void lnkADAdisbursementsJournal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frmADAdisburementJournalReport = new frmADADisbursementsJournalReport();
            frmADAdisburementJournalReport.fundName = cmbxFunds.Text.Trim();
            frmADAdisburementJournalReport.journalName = "Authority to Debit Account Disbursement Journal";
            frmADAdisburementJournalReport.date = dateTimePicker1.Value;
            frmADAdisburementJournalReport.ShowDialog();
        }

        private void lnkCashDisbursementJournal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frmCashDisbursementJournalReport = new frmCashDisbursementsJournalReport();
            frmCashDisbursementJournalReport.fundName = cmbxFunds.Text.Trim();
            frmCashDisbursementJournalReport.journalName = "Cash Disbursements Journal";
            frmCashDisbursementJournalReport.date = dateTimePicker1.Value;
            frmCashDisbursementJournalReport.ShowDialog();
        }

        private void lnkCashReceiptJournal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frmCashReceiptsJournalReport = new frmCashReceiptsJournalReport();
            frmCashReceiptsJournalReport.fundName = cmbxFunds.Text.Trim();
            frmCashReceiptsJournalReport.journalName = "Cash Receipts Journal";
            frmCashReceiptsJournalReport.date = dateTimePicker1.Value;
            frmCashReceiptsJournalReport.ShowDialog();
        }

        private void lnkCheckDisbursementsJournal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frmCheckDisbursementJournalReport = new frmCheckDisbursementsJournalReport();
            frmCheckDisbursementJournalReport.fundName = cmbxFunds.Text.Trim();
            frmCheckDisbursementJournalReport.journalName = "Check Disbursements Journal";
            frmCheckDisbursementJournalReport.date = dateTimePicker1.Value;
            frmCheckDisbursementJournalReport.ShowDialog();
        }

        private void lnkGeneralJournal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frmGeneralJournalReport = new frmGeneralJournalReport();
            frmGeneralJournalReport.fundName = cmbxFunds.Text.Trim();
            frmGeneralJournalReport.journalName = "General Journal";
            frmGeneralJournalReport.date = dateTimePicker1.Value;
            frmGeneralJournalReport.ShowDialog();
        }

        private void lnkProcurementReceivedJournal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frmProcurementsReceivedJournalReport = new frmProcurementsReceivedJournalReport();
            frmProcurementsReceivedJournalReport.fundName = cmbxFunds.Text.Trim();
            frmProcurementsReceivedJournalReport.journalName = "Procurement Received Journal";
            frmProcurementsReceivedJournalReport.date = dateTimePicker1.Value;
            frmProcurementsReceivedJournalReport.ShowDialog();
        }
    }
}
