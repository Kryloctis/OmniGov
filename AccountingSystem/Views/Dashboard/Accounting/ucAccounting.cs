using AccountingSystem.Views.Manage.ChartOfAccounts;
using AccountingSystem.Views.Manage.Journals;
using AccountingSystem.Views.Reports.Financial_Statements;
using AccountingSystem.Views.Reports.Journals;
using AccountingSystem.Views.Reports.Ledgers;
using AccountingSystem.Views.Reports.TrialBalance;
using AccountingSystem.Views.Transactions.JEV;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
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

            //Removes tabs to tabcontrol
        }

        internal void OnLoad()
        {
            ucJevDashboard.OnLoad();
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