using OmniGov.App.Accounting.Views.Reports.FinancialStatements;
using OmniGov.App.Accounting.Views.Reports.JEV;
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
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
                _ = new frmSAAO().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSaaobb_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmSAAOB().ShowDialog();
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

        private void btnJevRprt_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmJEVReport().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}