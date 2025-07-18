using LFS.Views.Reports.Cashbook;
using LFS.Views.Reports.ConsolidatedReceipts;
using LFS.Views.Reports.DailyCashPositionReport;
using LFS.Views.Reports.Financial_Statements;
using LFS.Views.Reports.Journals;
using LFS.Views.Reports.Ledgers;
using LFS.Views.Reports.Ltoms;
using LFS.Views.Reports.Rcd;
using LFS.Views.Reports.RCI;
using LFS.Views.Reports.ReleasedAndUnreleasedCheques;
using LFS.Views.Reports.RptReports;
using LFS.Views.Reports.Saaob;
using LFS.Views.Reports.Saaobb;
using LFS.Views.Reports.TaxClearance;
using LFS.Views.Reports.TrialBalance;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LFS.Views.Dashboard.Reports
{
    public partial class ucReports : UserControl
    {
        public ucReports()
        {
            InitializeComponent();
        }

        internal void OnLoad()
        {
            ValidateAccountingPermissions();
            //ValidateTreasuryPermissions();
        }

        private void ValidateAccountingPermissions()
        {
            if (!Helper.HasPermission("Report > SAAOB"))
                btnSaaob.Enabled = false;

            if (!Helper.HasPermission("Report > SAAOBB"))
                btnSaaobb.Enabled = false;

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
            btnJournals.Enabled = validateJournals.Contains(false);

            var validateLedgers = new List<bool>();
            ledgerReportPermissions.ForEach(x => { validateLedgers.Add(!Helper.HasPermission(x)); });
            btnLedgers.Enabled = validateLedgers.Contains(false);

            var validateTrialBalance = new List<bool>();
            trialBalanceReportPermissions.ForEach(x => { validateTrialBalance.Add(!Helper.HasPermission(x)); });
            btnTrialBalance.Enabled = validateTrialBalance.Contains(false);

            var validateFinancialStatements = new List<bool>();
            financialStatementsReportPermissions.ForEach(x => { validateFinancialStatements.Add(!Helper.HasPermission(x)); });
            btnFs.Enabled = validateFinancialStatements.Contains(false);
        }

        private void ValidateTreasuryPermissions()
        {
            if (!Helper.HasPermission("Report > Report of Collections and Deposits"))
                btnRcd.Enabled = false;

            if (!Helper.HasPermission("Report > List of Delinquent Accounts"))
                btnLstRptDelinquencies.Enabled = false;

            if (!Helper.HasPermission("Report > Report of Checks Issued"))
                btnRci.Enabled = false;

            if (!Helper.HasPermission("Report > Bank Cashbook"))
                btnBankCashbook.Enabled = false;

            if (!Helper.HasPermission("Report > Consolidated Receipts"))
                btnConsRprtAccForms.Enabled = false;

            if (!Helper.HasPermission("Report > Daily Cash Position"))
                btnDlyCashPstn.Enabled = false;

            if (!Helper.HasPermission("Report > Real Property Tax Account Register (RPTAR)"))
                btnRptDuesPayments.Enabled = false;

            if (!Helper.HasPermission("Report > Consolidated Real Property Tax Dues"))
                btnConsRprtAccForms.Enabled = false;

            if (!Helper.HasPermission("Report > Schedule of Released Cheques") || !Helper.HasPermission("Report > Schedule of Unreleased Cheques"))
                btnSchedRc.Enabled = false;
        }

        private void btnLtom17and19_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmLtom17to19().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnRcd_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmRcd().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnLtom20_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmLtom20().ShowDialog();
            }
            catch (Exception ex)
            { Helper.MessageBoxError(ex.Message); }
        }

        private void btnLtom23_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmLtom23().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSaaob_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmSaaob().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSaaobb_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmSaaobb().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnJournals_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmJournalReports().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnLedgers_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmLedgers().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnTrialBalance_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmTrialBalance().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnFs_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmFinancialStatements().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnBankCashbook_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmCashbook().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSchedRc_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmReleasedUnreleasedChecksReport().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnConsRprtAccForms_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmConsolidatedReceipts().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnDlyCashPstn_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmDailyCash().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnRci_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmRciReport().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnRptStmntAcc_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmRealPropertyTaxStatementOfAccount().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnLstRptDelinquencies_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmListRptDelinquencies().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnRptDuesPayments_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmRptDuesPayments().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnCertListRptDelinquencies_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmCertifiedListRptDelinquences().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnLtom24_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmLtom24().ShowDialog();
            }
            catch (Exception ex)
            { Helper.MessageBoxError(ex.Message); }
        }

        private void btnLtom29_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmLtom29().ShowDialog();
            }
            catch (Exception ex)
            { Helper.MessageBoxError(ex.Message); }
        }

        private void btnLtom30_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmLtom30().ShowDialog();
            }
            catch (Exception ex)
            { Helper.MessageBoxError(ex.Message); }
        }

        private void btnLtom31_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmLtom31().ShowDialog();
            }
            catch (Exception ex)
            { Helper.MessageBoxError(ex.Message); }
        }

        private void btnLtom21_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmLtom21().ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnLtom22_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmLtom22().ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnLtom16_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmLtom16().ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnLtom25_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmLtom25().ShowDialog();
            }
            catch (Exception ex)
            { Helper.MessageBoxError(ex.Message); }
        }

        private void btnLtom26_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmLtom26().ShowDialog();
            }
            catch (Exception ex)
            { Helper.MessageBoxError(ex.Message); }
        }

        private void btnLtom27_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmLtom27().ShowDialog();
            }
            catch (Exception ex)
            { Helper.MessageBoxError(ex.Message); }
        }

        private void btnLtom28_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmLtom28().ShowDialog();
            }
            catch (Exception ex)
            { Helper.MessageBoxError(ex.Message); }
        }

        private void btnLtom32_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmLtom32().ShowDialog();
            }
            catch (Exception ex)
            { Helper.MessageBoxError(ex.Message); }
        }

        private void btnLtom33_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmLtom33().ShowDialog();
            }
            catch (Exception ex)
            { Helper.MessageBoxError(ex.Message); }
        }

        private void btnLtom34_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmLtom34().ShowDialog();
            }
            catch (Exception ex)
            { Helper.MessageBoxError(ex.Message); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmTaxClearance().ShowDialog();
            }
            catch (Exception ex)
            { Helper.MessageBoxError(ex.Message); }
        }
    }
}