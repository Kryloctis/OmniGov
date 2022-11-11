using AccountingSystem.Views.Manage.AccountableForm;
using AccountingSystem.Views.Manage.AllotmentClasses;
using AccountingSystem.Views.Manage.AllotmentRelease;
using AccountingSystem.Views.Manage.Amortization;
using AccountingSystem.Views.Manage.Banks;
using AccountingSystem.Views.Manage.Barangay;
using AccountingSystem.Views.Manage.BudgetAppropriations;
using AccountingSystem.Views.Manage.BusinessAdOnCharges;
using AccountingSystem.Views.Manage.BusinessCategories;
using AccountingSystem.Views.Manage.ChartOfAccounts;
using AccountingSystem.Views.Manage.CollectingOfficer;
using AccountingSystem.Views.Manage.DatabaseSynchronization;
using AccountingSystem.Views.Manage.DisbursingOfficer;
using AccountingSystem.Views.Manage.FunctionProgramProject;
using AccountingSystem.Views.Manage.Funds;
using AccountingSystem.Views.Manage.Journals;
using AccountingSystem.Views.Manage.RealProperties;
using AccountingSystem.Views.Manage.Receipts;
using AccountingSystem.Views.Manage.ReturnedReceipts;
using AccountingSystem.Views.Manage.RptDiscount;
using AccountingSystem.Views.Manage.RptPenalties;
using AccountingSystem.Views.Manage.RptTaxRates;
using AccountingSystem.Views.Manage.Signatories;
using AccountingSystem.Views.Manage.TaxPayers;
using AccountingSystem.Views.Manage.Users.List;
using AccountingSystem.Views.Manage.Users.Roles;
using AccountingSystem.Views.Reports.Cashbook;
using AccountingSystem.Views.Reports.CollectorsRCD;
using AccountingSystem.Views.Reports.ConsolidatedReceipts;
using AccountingSystem.Views.Reports.DailyCashReport;
using AccountingSystem.Views.Reports.GeneralCollection;
using AccountingSystem.Views.Reports.RCD;
using AccountingSystem.Views.Reports.RCI;
using AccountingSystem.Views.Reports.RealPropertyTaxReports;
using AccountingSystem.Views.Reports.RealPropertyTaxReports.CertifiedListOfPropertyTaxDelinquences;
using AccountingSystem.Views.Reports.RealPropertyTaxReports.ListOfRealPropertyTaxDelinquencies;
using AccountingSystem.Views.Reports.RealPropertyTaxReports.RealPropertyTaxStatementOfAccount;
using AccountingSystem.Views.Reports.SAAOB;
using AccountingSystem.Views.Reports.SAAOBB;
using AccountingSystem.Views.Transactions.AssessmentPosting;
using AccountingSystem.Views.Transactions.BankDeposits;
using AccountingSystem.Views.Transactions.ObligationRequest;
using AccountingSystem.Views.Transactions.PaymentPosting;
using AccountingSystem.Views.Transactions.RCI;
using AccountingSystem.Views.Transactions.ReceiptsIssued;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem
{
    public partial class MainForm : Form
    {
        private Dictionary<string, dynamic> userDict;
        private LoginForm loginForm;

        public MainForm(LoginForm _loginForm)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            ClearTabPages();
            userDict = Helper.LoggedInUserData();
            loginForm = _loginForm;
        }

        private void ClearTabPages()
        {
            tabControlDashboard.TabPages.Clear();
            tabControlAccounting.TabPages.Clear();
            tabControlLedgers.TabPages.Clear();
            tabControlTrialBalance.TabPages.Clear();
            tabControlFinancialStatements.TabPages.Clear();
        }

        private void FocusLasTabPages()
        {
            int budgetTabPageCount = tabControlBudget.TabPages.Count;
            int ledgersTabPageCount = tabControlLedgers.TabPages.Count;
            int trialBalanceTabPageCount = tabControlTrialBalance.TabPages.Count;
            int financialStatementsTabPageCount = tabControlFinancialStatements.TabPages.Count;

            if (budgetTabPageCount > 1)
                tabControlBudget.SelectedTab = tabControlBudget.TabPages[budgetTabPageCount - 1];

            if (ledgersTabPageCount > 1)
                tabControlLedgers.SelectedTab = tabControlLedgers.TabPages[ledgersTabPageCount - 1];

            if (trialBalanceTabPageCount > 1)
                tabControlTrialBalance.SelectedTab = tabControlTrialBalance.TabPages[trialBalanceTabPageCount - 1];

            if (financialStatementsTabPageCount > 1)
                tabControlFinancialStatements.SelectedTab = tabControlFinancialStatements.TabPages[financialStatementsTabPageCount - 1];
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadLoggedInUser();
                ValidatePermissions();
                FocusLasTabPages();
            }
        }

        private void LoadLoggedInUser()
        {
            lblUserFullName.Text = $"Welcome: {userDict["user_full_name"]}";
            lblUserRole.Text = userDict["role_name"];
        }

        #region  Permission Validations

        private void ValidatePermissions()
        {
            ValidateDashboadPermissions();

            ValidateManagePermissions();

            ValidateTransactionPermissions();

            ValidateReportPermissions();

            ValidateAccountingControlPermissions();
        }

        private void ValidateDashboadPermissions()
        {
            if (Helper.HasPermission("Dashboard > Budget"))
                tabControlDashboard.TabPages.Add(tabPageBudget);

            if (Helper.HasPermission("Dashboard > Accounting"))
                tabControlDashboard.TabPages.Add(tabPageAccounting);

            if (Helper.HasPermission("Dashboard > Treasury"))
                tabControlDashboard.TabPages.Add(tabPageTreasury);
        }

        private void ValidateReportPermissions()
        {
            if (!Helper.HasPermission("Report > Report of Checks Issued"))
                reportOfCheckIssuedRCIToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Report > Report of Collections and Deposits"))
                reportOfCollectionsDepositsRCDToolStripMenuItem.Enabled = false;

            //if (!Helper.HasPermission("Report > Abstract of General Collections"))
            //    abstractOfGeneralCollectionsToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Report > Bank Cashbook"))
                bankCashbookToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Report > Consolidated Receipts"))
                consolidatedReportOfAccountabilityForAccountableFormsToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Report > Daily Cash Position"))
                dailyCashPositionsToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Report > SAAOB"))
                sAAOBToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Report > SAAOBB"))
                sAAOBBToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Report > Collector's RCD"))
                collectorsRCDToolStripMenuItem.Enabled = false;

            //if (!Helper.HasPermission("Report Real Property Tax Account Register (RPTAR)"))
            //    toolStripMenuItemrealPropertyTaxAccountRegister.Enabled = false;

            //if (!Helper.HasPermission("Report Consolidated Real Property Tax Dues"))
            //    toolStripMenuItemConsolidatedRealPropertyTaxDues.Enabled = false;

            //if (!Helper.HasPermission("Report List of Delinquent Accounts"))
            //    toolStripMenuItemListOfDelinquentAccounts.Enabled = false;


        }

        private void ValidateTransactionPermissions()
        {
            if (!Helper.HasPermission("Transaction > Obligation Request"))
                toolStripButtonObligation.Enabled = false;

            if (!Helper.HasPermission("Transaction > Issue Check"))
                checkIssuanceToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Transaction > Bank Deposits"))
                bankDepositToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Transaction > Issue Receipt"))
                issueRecieptsToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Transaction > RCD Approval"))
                liquidatorsRCDToolStripMenuItem.Enabled = false;

            //if (!Helper.HasPermission("Transaction Payment Portal"))
            //    MenuPaymentPortal.Enabled = false;

            if (!Helper.HasPermission("Transaction > Assessment Posting"))
                assessmentPostingToolStripMenuItem.Enabled = false;

            //if (!IsUserCollector())
            //    toolStripMenuPaymentPostings.Enabled = false;

        }

        private void ValidateManagePermissions()
        {
            if (!Helper.HasPermission("Manage > Allotment Classes"))
                menuAllotmentClasses.Enabled = false;

            if (!Helper.HasPermission("Manage > Budget Appropriations"))
                toolStripButtonBudgetAppropriations.Enabled = false;

            if (!Helper.HasPermission("Manage > Allotment Releases"))
                toolStripButtonAllotmentRelease.Enabled = false;

            if (!Helper.HasPermission("Manage > Chart of Accounts"))
                menuChartOfAccounts.Enabled = false;

            if (!Helper.HasPermission("Manage > Function/Program/Project"))
                menuFunctionProgramProject.Enabled = false;

            if (!Helper.HasPermission("Manage > Collecting Officer"))
                menuCollectingOfficer.Enabled = false;

            if (!Helper.HasPermission("Manage > Funds"))
                menuFunds.Enabled = false;

            if (!Helper.HasPermission("Manage > Journals"))
                menuJournals.Enabled = false;

            if (!Helper.HasPermission("Manage > Users") && !Helper.HasPermission("Manage Roles"))
                menuUsers.Enabled = false;

            if (!Helper.HasPermission("Manage > Users"))
                menuUserList.Enabled = false;

            if (!Helper.HasPermission("Manage > Roles"))
                menuRoles.Enabled = false;

            if (!Helper.HasPermission("Manage > Banks"))
                menuBanks.Enabled = false;

            if (!Helper.HasPermission("Manage > Accountable Forms"))
                menuAccForm.Enabled = false;

            if (!Helper.HasPermission("Manage > Disbursing Officer"))
                menuDisbursingOfficer.Enabled = false;

            if (!Helper.HasPermission("Manage > Receipts"))
                menuReceipts.Enabled = false;

            if (!Helper.HasPermission("Transaction > Issue Check"))
                checkIssuanceToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Transaction > Generate RCD"))
                liquidatorsRCDToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Manage > Signatories"))
                signatoriesToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Manage > Taxpayers"))
                menuTaxPayers.Enabled = false;

            if (!Helper.HasPermission("Manage > Returned Receipts"))
                returnedReceiptsToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Manage > Barangays"))
                barangaysToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Manage > Database Synchronization"))
                menuDatabaseSynchronization.Enabled = false;

            if (!Helper.HasPermission("Manage > Business Categories"))
                businessCategoriesToolStripMenuItem.Enabled = false;

            if (!Helper.HasPermission("Manage > Business Add-on Charges"))
                businessAddOnToolStripMenuItem.Enabled = false;

            if (Helper.LoggedInUserData()["role_name"] != "System Administrator")
            {
                discountToolStripMenuItem.Enabled = false;
                penaltyToolStripMenuItem.Enabled = false;
                taxRateToolStripMenuItem.Enabled = false;
            }
        }

        private void ValidateAccountingControlPermissions()
        {
            #region Journal Entry Voucher

            if (Helper.HasPermission("Transaction > JEV") || Helper.HasPermission("Report > JEVs"))
                tabControlAccounting.TabPages.Add(tabPageJournalEntryVoucher);

            if (!Helper.HasPermission("Transaction > JEV"))
                ucjevDashboard1.btnAddJEV.Enabled = false;

            #endregion

            #region Journals

            if (Helper.HasPermission("Report > General Journal") || Helper.HasPermission("Report > Cash Receipts Journal") || Helper.HasPermission("Report > Procurement Received Journal") || Helper.HasPermission("Report > Cash Disbursements Journal") || Helper.HasPermission("Report > Check Disbursements Journal") || Helper.HasPermission("Report > Authority to Debit Account Disbursements Journal"))
                tabControlAccounting.TabPages.Add(tabPageJournals);


            if (!Helper.HasPermission("Report > General Journal"))
                ucJournalsDashboard1.lnkGeneralJournal.Enabled = false;

            if (!Helper.HasPermission("Report > Cash Receipts Journal"))
                ucJournalsDashboard1.lnkCashReceiptJournal.Enabled = false;

            if (!Helper.HasPermission("Report > Procurement Received Journal"))
                ucJournalsDashboard1.lnkProcurementReceivedJournal.Enabled = false;

            if (!Helper.HasPermission("Report > Cash Disbursements Journal"))
                ucJournalsDashboard1.lnkCashDisbursementJournal.Enabled = false;

            if (!Helper.HasPermission("Report > Check Disbursements Journal"))
                ucJournalsDashboard1.lnkCheckDisbursementsJournal.Enabled = false;

            if (!Helper.HasPermission("Report > Authority to Debit Account Disbursements Journal"))
                ucJournalsDashboard1.lnkADAdisbursementsJournal.Enabled = false;

            #endregion

            #region Ledgers

            if (Helper.HasPermission("Report > Transaction Log"))
                tabControlLedgers.TabPages.Add(tabPageTransactionLog);

            if (Helper.HasPermission("Report > Subsidiary Ledger"))
                tabControlLedgers.TabPages.Add(tabPageSubsidiaryLedger);

            if (Helper.HasPermission("Report > General Ledger"))
                tabControlLedgers.TabPages.Add(tabPageGeneralLedger);

            if (Helper.HasPermission("Report > General Ledger") || Helper.HasPermission("Report > Subsidiary Ledger"))
                tabControlAccounting.TabPages.Add(tabPageLedgers);

            #endregion

            #region Trial Balance

            if (Helper.HasPermission("Report > Pre Trial Balance") || Helper.HasPermission("Report > Post Trial Balance"))
                tabControlAccounting.TabPages.Add(tabPageTrialBalance);


            if (Helper.HasPermission("Report > Post Trial Balance"))
                tabControlTrialBalance.TabPages.Add(tabPagePostTrial);


            if (Helper.HasPermission("Report > Pre Trial Balance"))
                tabControlTrialBalance.TabPages.Add(tabPagePreTrial);

            #endregion

            #region Financial Statements

            if (Helper.HasPermission("Report > Statement of Changes in Net Assets Equity") || Helper.HasPermission("Report > Statement of Financial Performance"))
                tabControlAccounting.TabPages.Add(tabPageFinancialStatements);

            if (Helper.HasPermission("Report > Statement of Comparison of Budget and Actual Amounts"))
                tabControlFinancialStatements.TabPages.Add(tabPageSCBAA);

            if (Helper.HasPermission("Report > Statement of Cash Flows"))
                tabControlFinancialStatements.TabPages.Add(tabPageSCF);

            if (Helper.HasPermission("Report > Statement of Changes in Net Assets Equity"))
                tabControlFinancialStatements.TabPages.Add(tabPageSCNAE);

            if (Helper.HasPermission("Report > Statement of Financial Performance"))
                tabControlFinancialStatements.TabPages.Add(tabPageSFPerformance);

            if (Helper.HasPermission("Report > Statement of Financial Position"))
                tabControlFinancialStatements.TabPages.Add(tabPageSFPosition);
            #endregion
        }

        #endregion

        private void menuJournals_Click(object sender, EventArgs e)
        {
            _ = new frmJournals().ShowDialog();
        }

        private void menuFunds_Click(object sender, EventArgs e)
        {
            _ = new frmFunds().ShowDialog();
        }

        private void menuChartOfAccounts_Click(object sender, EventArgs e)
        {
            _ = new frmChartOfAccounts().ShowDialog();
        }

        private void menuAllotmentClasses_Click(object sender, EventArgs e)
        {
            _ = new frmAllotmentClasses().ShowDialog();
        }

        private void menuRoles_Click(object sender, EventArgs e)
        {
            _ = new frmRoles().ShowDialog();
        }

        private void menuUserList_Click(object sender, EventArgs e)
        {
            _ = new frmUsers().ShowDialog();
        }

        private void menuFunctionProgramProject_Click(object sender, EventArgs e)
        {
            _ = new frmFunctionProgramProject().ShowDialog();
        }

        private void menuBanks_Click(object sender, EventArgs e)
        {
            _ = new frmBanks().ShowDialog();
        }


        private void menuAccForm_Click(object sender, EventArgs e)
        {
            _ = new frmAccountable().ShowDialog();
        }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            Close();
            loginForm.Show();
        }

        private void menuExitApp_Click(object sender, EventArgs e)
        {
            loginForm.Close();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginForm.Show();
        }

        private void amortiaztionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmAmortization().ShowDialog();
        }

        private void signatoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmSignatories().ShowDialog();
        }

        #region Budget Module

        private void toolStripButtonBudgetAppropriations_Click(object sender, EventArgs e)
        {
            _ = new frmBudgetAppropriations().ShowDialog();
        }

        private void toolStripButtonAllotmentRelease_Click(object sender, EventArgs e)
        {
            _ = new frmAllotmentReleaseMain().ShowDialog();
        }

        private void toolStripButtonObligation_Click(object sender, EventArgs e)
        {
            _ = new frmObligationRequestMain().ShowDialog();
        }

        #region SAAOB and SAAOBB report

        private void sAAOBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmSAAOB().ShowDialog();
        }

        private void sAAOBBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmSAAOBB().ShowDialog();
        }

        #endregion

        #endregion

        #region Accounting Module

        private void radJournalEntryVoucher_CheckedChanged(object sender, EventArgs e)
        {
            tabControlAccounting.SelectedTab = tabPageJournalEntryVoucher;
        }

        private void radJournals_CheckedChanged(object sender, EventArgs e)
        {
            tabControlAccounting.SelectedTab = tabPageJournals;
        }

        private void radLedgers_CheckedChanged(object sender, EventArgs e)
        {
            tabControlAccounting.SelectedTab = tabPageLedgers;
        }

        private void radTrialBalance_CheckedChanged(object sender, EventArgs e)
        {
            tabControlAccounting.SelectedTab = tabPageTrialBalance;
        }

        private void radFinancialStatements_CheckedChanged(object sender, EventArgs e)
        {
            tabControlAccounting.SelectedTab = tabPageFinancialStatements;
        }

        //Reports   

        #region Ledger Reports

        private void radioGeneralLedger_CheckedChanged(object sender, EventArgs e)
        {
            tabControlLedgers.SelectedTab = tabPageGeneralLedger;
        }

        private void radioSubsidiaryLedger_CheckedChanged(object sender, EventArgs e)
        {
            tabControlLedgers.SelectedTab = tabPageSubsidiaryLedger;
        }

        private void radioTransactionLog_CheckedChanged(object sender, EventArgs e)
        {
            tabControlLedgers.SelectedTab = tabPageTransactionLog;
        }

        #endregion

        #region Trial Balance Reports

        private void radioPreTB_CheckedChanged(object sender, EventArgs e)
        {
            tabControlTrialBalance.SelectedTab = tabPagePreTrial;
        }

        private void radioPostTB_CheckedChanged(object sender, EventArgs e)
        {
            tabControlTrialBalance.SelectedTab = tabPagePostTrial;
        }

        #endregion

        #region Financial Statement Reports

        private void radSFPosition_CheckedChanged(object sender, EventArgs e)
        {
            tabControlFinancialStatements.SelectedTab = tabPageSFPosition;
        }

        private void radSFPerformance_CheckedChanged(object sender, EventArgs e)
        {
            tabControlFinancialStatements.SelectedTab = tabPageSFPerformance;
        }

        private void radSCNAE_CheckedChanged(object sender, EventArgs e)
        {
            tabControlFinancialStatements.SelectedTab = tabPageSCNAE;
        }

        private void radSCF_CheckedChanged(object sender, EventArgs e)
        {
            tabControlFinancialStatements.SelectedTab = tabPageSCF;
        }

        private void radSCBAA_CheckedChanged(object sender, EventArgs e)
        {
            tabControlFinancialStatements.SelectedTab = tabPageSCBAA;
        }

        #endregion


        #endregion

        #region Treasury

        private void menuCollectingOfficer_Click(object sender, EventArgs e)
        {
            _ = new frmCollectingOfficer().ShowDialog();
        }

        private void MenuDisbursingOffice_Click(object sender, EventArgs e)
        {
            _ = new frmDisbursingOfficer().ShowDialog();
        }

        private void menureceipts_Click(object sender, EventArgs e)
        {
            _ = new frmReceipts().ShowDialog();
        }

        private void issueRecieptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmReceiptsIssued().ShowDialog();
        }

        private void reportOfCheckIssuedRCIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmRCIReport().ShowDialog();
        }

        private void reportOfCollectionsDepositsRCDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmSearch(new frmRCD()).ShowDialog();
        }

        private void abstractOfGeneralCollectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new AbstractOfGeneralCollection().ShowDialog();
        }

        private void bankCashbookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmCashbook().ShowDialog();
        }

        private void consolidatedReportOfAccountabilityForAccountableFormsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmConsolidatedReceipts().ShowDialog();
        }

        private void dailyCashPositionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmDailyCash().ShowDialog();
        }

        private void toolStripMenuItemListOfDelinquentAccounts_Click(object sender, EventArgs e)
        {
            _ = new frmListOfRealPropertyTaxDelinquenciesReport().ShowDialog();
        }

        private void realPropertyTaxAccountRegisterRPTARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmRealPropertyTaxAccountRegisterReport().ShowDialog();
        }

        private void realPropertyTaxStatementOfAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmRealPropertyTaxStatementOfAccount().ShowDialog();
        }

        private void consolidatedRealPropertyTaxDeliquencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmCertifiedListOfTaxDelinquences().ShowDialog();
        }

        private void returnedReceiptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmReturnedReceipts().ShowDialog();
        }

        private void discountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmRptDiscounts(this).ShowDialog();
        }

        private void penaltyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmRptPenalties(this).ShowDialog();
        }

        private void taxRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmRptTaxRates(this).ShowDialog();
        }

        private void CheckIssuanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmRCI().ShowDialog();
        }

        private void bankDepositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmBankDeposits().ShowDialog();
        }

        private void collectorsRCDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmCollectorsRCD().ShowDialog();
        }

        private void liquidatorsRCDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmRCD().ShowDialog();
        }

        private void assessmentPostingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmAssessmentPosting().ShowDialog();
        }

        #endregion

        private void menuDatabaseSynchronization_Click(object sender, EventArgs e)
        {
            _ = new frmDatabaseSynchronization().ShowDialog();
        }

        private void menuTaxPayers_Click(object sender, EventArgs e)
        {
            _ = new frmTaxpayers().ShowDialog();
        }

        private void barangaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmBarangay().ShowDialog();
        }

        private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmPayments(this).ShowDialog();
        }

        private void toolStripButtonRpt_Click(object sender, EventArgs e)
        {
            _ = new frmRealProperties().ShowDialog();
        }

        private void businessCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmBusinessCategories().ShowDialog();
        }

        private void businessAddOnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmBusinessAddOnCharges().ShowDialog();
        }
    }
}
