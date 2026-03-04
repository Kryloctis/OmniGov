using OmniGov.App.Accounting.Views.Reports.FinancialStatements;
using OmniGov.App.Accounting.Views.Reports.JournalEntryVoucher;
using OmniGov.App.Accounting.Views.Reports.Journals;
using OmniGov.App.Accounting.Views.Reports.Ledgers;
using OmniGov.App.Accounting.Views.Reports.TrialBalance;
using OmniGov.App.Budget.Views.Reports;
using OmniGov.App.Helpers;
using OmniGov.App.Views.Reports.Cashbook;
using OmniGov.App.Views.Reports.ConsolidatedReceipts;
using OmniGov.App.Views.Reports.DailyCashPositionReport;
using OmniGov.App.Views.Reports.Ltoms;
using OmniGov.App.Views.Reports.RCD;
using OmniGov.App.Views.Reports.RCI;
using OmniGov.App.Views.Reports.ReleasedAndUnreleasedChecks;
using OmniGov.App.Views.Reports.RptReports;
using OmniGov.App.Views.Reports.TaxClearance;

namespace OmniGov.App.Views.Dashboard.Reports
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

        private void btnBankCashbook_Click(object sender, EventArgs e)
        {
            _ = new frmCashbook().ShowDialog();
        }

        private void btnCertListRptDelinquencies_Click(object sender, EventArgs e)
        {
            _ = new frmCertifiedListRptDelinquences().ShowDialog();
        }

        private void btnConsRprtAccForms_Click(object sender, EventArgs e)
        {
            _ = new frmConsolidatedReceipts().ShowDialog();
        }

        private void btnDlyCashPstn_Click(object sender, EventArgs e)
        {
            _ = new frmDailyCash().ShowDialog();
        }

        private void btnFs_Click(object sender, EventArgs e)
        {
            _ = new frmFinancialStatements().ShowDialog();
        }

        private void btnJevRprt_Click(object sender, EventArgs e)
        {
            _ = new frmJEVReport().ShowDialog();
        }

        private void btnJournals_Click(object sender, EventArgs e)
        {
            _ = new frmJournalReports().ShowDialog();
        }

        private void btnLedgers_Click(object sender, EventArgs e)
        {
            _ = new frmLedgers().ShowDialog();
        }

        private void btnLstRptDelinquencies_Click(object sender, EventArgs e)
        {
            _ = new frmListRptDelinquencies().ShowDialog();
        }

        private void btnLtom16_Click(object sender, EventArgs e)
        {
            _ = new frmLtom16().ShowDialog();
        }

        private void btnLtom17and19_Click(object sender, EventArgs e)
        {
            _ = new frmLtom17to19().ShowDialog();
        }

        private void btnLtom20_Click(object sender, EventArgs e)
        {
            _ = new frmLtom20().ShowDialog();
        }

        private void btnLtom21_Click(object sender, EventArgs e)
        {
            _ = new frmLtom21().ShowDialog();
        }

        private void btnLtom22_Click(object sender, EventArgs e)
        {
            _ = new frmLtom22().ShowDialog();
        }

        private void btnLtom23_Click(object sender, EventArgs e)
        {
            _ = new frmLtom23().ShowDialog();
        }

        private void btnLtom24_Click(object sender, EventArgs e)
        {
            _ = new frmLtom24().ShowDialog();
        }

        private void btnLtom25_Click(object sender, EventArgs e)
        {
            _ = new frmLtom25().ShowDialog();
        }

        private void btnLtom26_Click(object sender, EventArgs e)
        {
            _ = new frmLtom26().ShowDialog();
        }

        private void btnLtom27_Click(object sender, EventArgs e)
        {
            _ = new frmLtom27().ShowDialog();
        }

        private void btnLtom28_Click(object sender, EventArgs e)
        {
            _ = new frmLtom28().ShowDialog();
        }

        private void btnLtom29_Click(object sender, EventArgs e)
        {
            _ = new frmLtom29().ShowDialog();
        }

        private void btnLtom30_Click(object sender, EventArgs e)
        {
            _ = new frmLtom30().ShowDialog();
        }

        private void btnLtom31_Click(object sender, EventArgs e)
        {
            _ = new frmLtom31().ShowDialog();
        }

        private void btnLtom32_Click(object sender, EventArgs e)
        {
            _ = new frmLtom32().ShowDialog();
        }

        private void btnLtom33_Click(object sender, EventArgs e)
        {
            _ = new frmLtom33().ShowDialog();
        }

        private void btnLtom34_Click(object sender, EventArgs e)
        {
            _ = new frmLtom34().ShowDialog();
        }

        private void btnRcd_Click(object sender, EventArgs e)
        {
            _ = new frmRcd().ShowDialog();
        }

        private void btnRci_Click(object sender, EventArgs e)
        {
            _ = new frmRciReport().ShowDialog();
        }

        private void btnRptDuesPayments_Click(object sender, EventArgs e)
        {
            _ = new frmRptDuesPayments().ShowDialog();
        }

        private void btnRptStmntAcc_Click(object sender, EventArgs e)
        {
            _ = new frmRealPropertyTaxStatementOfAccount().ShowDialog();
        }

        private void btnSaaob_Click(object sender, EventArgs e)
        {
            _ = new frmSAAO().ShowDialog();
        }

        private void btnSaaobb_Click(object sender, EventArgs e)
        {
            _ = new frmSAAOB().ShowDialog();
        }

        private void btnSchedRc_Click(object sender, EventArgs e)
        {
            _ = new frmReleasedUnreleasedChecksReport().ShowDialog();
        }

        private void btnTrialBalance_Click(object sender, EventArgs e)
        {
            _ = new frmTrialBalance().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _ = new frmTaxClearance().ShowDialog();
        }

        private void ValidateAccountingPermissions()
        {
            btnSaao.Enabled = PrivilegesHelper.HasPrivilege(Privileges.RptSAAOB);
            btnSaaob.Enabled = PrivilegesHelper.HasPrivilege(Privileges.RptSAAOBB);
            btnJevRprt.Enabled = PrivilegesHelper.HasPrivilege(Privileges.RptJEVs);

            var rptJrnlsPrivileges = new List<bool>
            {
                PrivilegesHelper.HasPrivilege(Privileges.RptGenJournal),
                PrivilegesHelper.HasPrivilege(Privileges.RptCashRecvJournal),
                PrivilegesHelper.HasPrivilege(Privileges.RptProcRecvJournal),
                PrivilegesHelper.HasPrivilege(Privileges.RptCashDisbJournal),
                PrivilegesHelper.HasPrivilege(Privileges.RptChkDisbJournal),
                PrivilegesHelper.HasPrivilege(Privileges.RptAuthDebitAcctDJ),
            };

            var rptLedgerPrivileges = new List<bool>
            {
                PrivilegesHelper.HasPrivilege(Privileges.RptGenLedger),
                PrivilegesHelper.HasPrivilege(Privileges.RptSubsidiaryLedger),
                PrivilegesHelper.HasPrivilege(Privileges.RptSummarySubLedger),
                PrivilegesHelper.HasPrivilege(Privileges.RptTransLog),
            };

            var rptTrialBalPrivileges = new List<bool>
            {
                PrivilegesHelper.HasPrivilege(Privileges.RptPreTrialBal),
                PrivilegesHelper.HasPrivilege(Privileges.RptPostTrialBal),
            };

            var rptFsPrivileges = new List<bool>
            {
                PrivilegesHelper.HasPrivilege(Privileges.RptFinPosition),
                PrivilegesHelper.HasPrivilege(Privileges.RptFinPerformance),
                PrivilegesHelper.HasPrivilege(Privileges.RptChangesNetAssets),
                PrivilegesHelper.HasPrivilege(Privileges.RptCashFlows),
            };

            btnJournals.Enabled = !rptJrnlsPrivileges.Contains(false);
            btnLedgers.Enabled = !rptLedgerPrivileges.Contains(false);
            btnTrialBalance.Enabled = !rptTrialBalPrivileges.Contains(false);
            btnFs.Enabled = !rptFsPrivileges.Contains(false);
        }

        private void ValidateTreasuryPermissions()
        {
            btnRcd.Enabled = PrivilegesHelper.HasPrivilege(Privileges.RptCollDeposits);
            btnLstRptDelinquencies.Enabled = PrivilegesHelper.HasPrivilege(Privileges.RptDelinqAccts);
            btnRci.Enabled = PrivilegesHelper.HasPrivilege(Privileges.RptChkIssued);
            btnBankCashbook.Enabled = PrivilegesHelper.HasPrivilege(Privileges.RptBankCashbook);
            btnConsRprtAccForms.Enabled = PrivilegesHelper.HasPrivilege(Privileges.RptConsReceipts);
            btnDlyCashPstn.Enabled = PrivilegesHelper.HasPrivilege(Privileges.RptDailyCashPos);
            btnRptDuesPayments.Enabled = PrivilegesHelper.HasPrivilege(Privileges.RptRPTAR);
            btnConsRprtAccForms.Enabled = PrivilegesHelper.HasPrivilege(Privileges.RptConsPropTaxDues);
            btnSchedRc.Enabled = PrivilegesHelper.HasPrivilege(Privileges.RptSchedReleasedChk)
                                 || PrivilegesHelper.HasPrivilege(Privileges.RptSchedUnreleasedChk);
        }
    }
}