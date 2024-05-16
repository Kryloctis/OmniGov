using AccountingSystem.Views.Manage.ChartOfAccounts;
using AccountingSystem.Views.Manage.Journals;
using AccountingSystem.Views.Reports.Financial_Statements;
using AccountingSystem.Views.Reports.Journals;
using AccountingSystem.Views.Reports.Ledgers;
using AccountingSystem.Views.Reports.TrialBalance;
using AccountingSystem.Views.Transactions.JEV;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AccountingSystem.Views.Dashboard.Accounting
{
    public partial class ucAccounting : UserControl
    {
        private ucJevDashboard ucJevDashboard;

        public ucAccounting()
        {
            InitializeComponent();
            ucJevDashboard = ucJevDashboard1;
        }

        internal void OnLoad()
        {
            ucJevDashboard.OnLoad();
            ValidatePermissions();
        }

        private void ValidatePermissions()
        {
            ucJevDashboard.Enabled = Helper.HasPermission("Transaction > JEV");
            chartOfAccountsTStrpMnuItm.Enabled = Helper.HasPermission("Manage > Chart of Accounts");
            journalsTStrpMnuItm.Enabled = Helper.HasPermission("Manage > Journals");

            var journalReportPermissions = new List<string>
            {
                "Report > General Journal",
                "Report > Cash Receipts Journal",
                "Report > Procurement Received Journal",
                "Report > Cash Disbursements Journal",
                "Report > Check Disbursements Journal",
                "Report > Authority to Debit Account Disbursements Journal",
            };

            var ledgerReportPermissions = new List<string>
            {
                "Report > General Ledger",
                "Report > Subsidiary Ledger",
                "Report > Summary Subsidiary Ledger",
                "Report > Transaction Log",
            };

            var trialBalanceReportPermissions = new List<string>
            {
                "Report > Pre Trial Balance",
                "Report > Post Trial Balance",
            };

            var financialStatementsReportPermissions = new List<string>
            {
                "Report > Statement of Financial Position",
                "Report > Statement of Financial Performance",
                "Report > Statement of Changes in Net Assets Equity",
                "Report > Statement of Cash Flows",
            };

            var validateJournals = new List<bool>();
            journalReportPermissions.ForEach(x => { validateJournals.Add(!Helper.HasPermission(x)); });
            journalsToolStripMenuItem.Enabled = validateJournals.Contains(false);

            var validateLedgers = new List<bool>();
            ledgerReportPermissions.ForEach(x => { validateLedgers.Add(!Helper.HasPermission(x)); });
            ledgersToolStripMenuItem.Enabled = validateLedgers.Contains(false);

            var validateTrialBalance = new List<bool>();
            trialBalanceReportPermissions.ForEach(x => { validateTrialBalance.Add(!Helper.HasPermission(x)); });
            trialBalanceToolStripMenuItem.Enabled = validateTrialBalance.Contains(false);

            var validateFinancialStatements = new List<bool>();
            financialStatementsReportPermissions.ForEach(x => { validateFinancialStatements.Add(!Helper.HasPermission(x)); });
            financialStatementsToolStripMenuItem.Enabled = validateFinancialStatements.Contains(false);
        }

        private void chartOfAccountsTStrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmChartOfAccounts().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void journalsTStrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmJournals().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ledgersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmLedgers().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void trialBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmTrialBalance().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void financialStatementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmFinancialStatements().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void journalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmJournalReports().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}