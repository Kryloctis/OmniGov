using AccountingSystem.Views.Reports.Cashbook;
using AccountingSystem.Views.Reports.ConsolidatedReceipts;
using AccountingSystem.Views.Reports.Financial_Statements;
using AccountingSystem.Views.Reports.Journals;
using AccountingSystem.Views.Reports.Ledgers;
using AccountingSystem.Views.Reports.Ltom;
using AccountingSystem.Views.Reports.Rcd;
using AccountingSystem.Views.Reports.RCI;
using AccountingSystem.Views.Reports.ReleasedAndUnreleasedCheques;
using AccountingSystem.Views.Reports.RptReports;
using AccountingSystem.Views.Reports.Saaob;
using AccountingSystem.Views.Reports.Saaobb;
using AccountingSystem.Views.Reports.TrialBalance;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AccountingSystem.Views.Reports.DailyCashPositionReport;

namespace AccountingSystem.Views.Dashboard.Reports
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
            ValidateTreasuryPermissions();
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
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
                _ = new frmRCIReport().ShowDialog();
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
    }
}