using AccountingSystem.Views.Manage.AccountableForm;
using AccountingSystem.Views.Manage.AllotmentClasses;
using AccountingSystem.Views.Manage.AllotmentRelease;
using AccountingSystem.Views.Manage.Banks;
using AccountingSystem.Views.Manage.BudgetAppropriations;
using AccountingSystem.Views.Manage.ChartOfAccounts;
using AccountingSystem.Views.Manage.CollectingOfficer;
using AccountingSystem.Views.Manage.DisbursingOfficer;
using AccountingSystem.Views.Manage.FunctionProgramProject;
using AccountingSystem.Views.Manage.Funds;
using AccountingSystem.Views.Manage.Journals;
using AccountingSystem.Views.Manage.Receipts;
using AccountingSystem.Views.Manage.Users.List;
using AccountingSystem.Views.Manage.Users.Roles;
using AccountingSystem.Views.Reports.Cashbook;
using AccountingSystem.Views.Reports.ConsolidatedReceipts;
using AccountingSystem.Views.Reports.DailyCashReport;
using AccountingSystem.Views.Reports.Financial_Statements;
using AccountingSystem.Views.Reports.JEV;
using AccountingSystem.Views.Reports.Journals;
using AccountingSystem.Views.Reports.Ledgers;
using AccountingSystem.Views.Reports.PaymentCollection;
using AccountingSystem.Views.Reports.RCD;
using AccountingSystem.Views.Reports.RCI;
using AccountingSystem.Views.Reports.SAAOB;
using AccountingSystem.Views.Reports.SAAOBB;
using AccountingSystem.Views.Reports.TrialBalance;
using AccountingSystem.Views.Transactions.BankDeposits;
using AccountingSystem.Views.Transactions.JEV;
using AccountingSystem.Views.Transactions.ObligationRequest;
using AccountingSystem.Views.Transactions.PaymentCollection;
using AccountingSystem.Views.Transactions.RCI;
using AccountingSystem.Views.Transactions.ReceiptsIssued;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem
{
    public partial class MainForm : Form
    {
        private Dictionary<string, string> userDict;
        private LoginForm loginForm;

        public MainForm(LoginForm _loginForm)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            userDict = Helper.LoggedInUserData();
            loginForm = _loginForm;
        }

        #region DASHBOARD


        #region ACCOUNTING DASHBOARD

        private void LoadAccountingDashboard()
        {
            ucAccountingDashboard1.userDict = userDict;
        }

        #endregion

        #endregion

        private void LoadLoggedInUser()
        {
            lblUserFullName.Text = $"Welcome {userDict["first_name"]} {userDict["mid_initial"]} {userDict["last_name"]}";
            lblUserRole.Text = userDict["role_name"];
        }

        private void ValidatePermissions()
        {
            if (!Helper.HasPermission("Manage Allotment Classes"))
                menuAllotmentClasses.Visible = false;

            if (!Helper.HasPermission("Manage Budget Appropriations"))
                btnBudgetAppropriations.Visible = false;

            if (!Helper.HasPermission("Manage Allotment Releases"))
                btnAllotmentRelease.Visible = false;

            if (!Helper.HasPermission("Manage Chart of Accounts"))
                menuChartOfAccounts.Visible = false;

            if (!Helper.HasPermission("Manage Function/Program/Project"))
                menuFunctionProgramProject.Visible = false;

            if (!Helper.HasPermission("Manage Collecting Officer"))
                menuCollectingOfficer.Visible = false;

            if (!Helper.HasPermission("Manage Funds"))
                menuFunds.Visible = false;

            if (!Helper.HasPermission("Manage Journals"))
                menuJournals.Visible = false;

            if (!Helper.HasPermission("Manage Users") && !Helper.HasPermission("Manage Roles"))
                menuUsers.Visible = false;

            if (!Helper.HasPermission("Manage Users"))
                menuUserList.Visible = false;

            if (!Helper.HasPermission("Manage Roles"))
                menuRoles.Visible = false;

            if (!Helper.HasPermission("Transaction JEV"))
            {
                btnJournalEntry.Visible = false;
                menuJEV.Visible = false;
            }

            if (!Helper.HasPermission("Transaction Obligation Request"))
                btnObligationRequest.Visible = false;

            if (!Helper.HasPermission("Report General Journal"))
                menuReportGJ.Visible = false;

            if (!Helper.HasPermission("Report Cash Receipts Journal"))
                menuReportCRJ.Visible = false;

            if (!Helper.HasPermission("Report Procurement Received Journal"))
                menuReportPRJ.Visible = false;

            if (!Helper.HasPermission("Report Cash Disbursements Journal"))
                menuReportCDJ.Visible = false;

            if (!Helper.HasPermission("Report Check Disbursements Journal"))
                menuReportCkDJ.Visible = false;

            if (!Helper.HasPermission("Report Authority to Debit Account Disbursements Journal"))
                menuReportADADJ.Visible = false;

            if (!Helper.HasPermission("Report General Journal") && !Helper.HasPermission("Report Cash Receipts Journal") && !Helper.HasPermission("Report Procurement Received Journal") && !Helper.HasPermission("Report Cash Disbursements Journal") && !Helper.HasPermission("Report Check Disbursements Journal") && !Helper.HasPermission("Report Authority to Debit Account Disbursements Journal"))
                menuJournalsReport.Visible = false;

            if (!Helper.HasPermission("Report General Ledger"))
                menuLedgersReport.Visible = false;

            if (!Helper.HasPermission("Report Subsidiary Ledger"))
                menuLedgersReport.Visible = false;

            if (!Helper.HasPermission("Report General Ledger") && !Helper.HasPermission("Report Subsidiary Ledger"))
                menuLedgersReport.Visible = false;

            if (!Helper.HasPermission("Manage Banks"))
                menuBanks.Visible = false;

            if (!Helper.HasPermission("Manage Disbursing Officer"))
                menuDisbursingOfficer.Visible = false;

            if (!Helper.HasPermission("Transaction Issue Check"))
            {
                btnIssueCheck.Visible = false;
                menuIssueCheck.Visible = false;
            }

            if (!Helper.HasPermission("Manage Accountable Forms"))
                menuAccForm.Visible = false;

            if (!Helper.HasPermission("Transaction Bank Deposits"))
            {
                menuDeposits.Visible = false;
                btnBankDeposit.Visible = false;
            }

            if (!Helper.HasPermission("Report SAAOB"))
                menuSAAOB.Visible = false;

            if (!Helper.HasPermission("Report SAAOBB"))
                menuSAAOBB.Visible = false;

            if (!Helper.HasPermission("Transaction Payments"))
            {
                btnPaymentCollection.Visible = false;
                menuPayments.Visible = false;
            }

            if (!Helper.HasPermission("Manage Receipts"))
                menuReceipts.Visible = false;

            if (!Helper.HasPermission("Transaction Issue Receipt"))
                menuIssueReceipts.Visible = false;

            if (!Helper.HasPermission("Transaction Generate RCD"))
            {
                menuGenerateRCD.Visible = false;
                btnGenerateRCD.Visible = false;
            }

            if (!Helper.HasPermission("Report of Checks Issued"))
                menuprintRCI.Visible = false;

            if (!Helper.HasPermission("Report of Collections and Deposits"))
                menuprintPC.Visible = false;

            if (!Helper.HasPermission("Reports of General Collections"))
                menuprintGC.Visible = false;

            if (!Helper.HasPermission("Report JEVs"))
                menuJEVS.Visible = false;

            if (!Helper.HasPermission("Report Bank Cashbook"))
                menuBankCashBook.Visible = false;

            if (!Helper.HasPermission("Budget Dashboard"))
            {
                radBtnBudget.Visible = false;
                tabControl1.TabPages.Remove(tabBudgetDashboard);
            }

            if (!Helper.HasPermission("Accounting Dashboard"))
            {
                radBtnAccounting.Visible = false;
                tabControl1.TabPages.Remove(tabAccountingDashboard);
            }

            if (!Helper.HasPermission("Report Trial Balance"))
            {
                menuTrialBalance.Visible = false;
            }

            if (!Helper.HasPermission("Report Financial Statements"))
            {
                financialStatementsToolStripMenuItem.Visible = false;
            }
        }

        private void radBtnBudget_CheckedChanged(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabBudgetDashboard;
        }

        private void radBtnAccounting_CheckedChanged(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabAccountingDashboard;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadLoggedInUser();
            LoadAccountingDashboard();
            ValidatePermissions();
        }

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

        private void menuJEV_Click(object sender, EventArgs e)
        {
            _ = new frmJEV().ShowDialog();
        }

        private void menuFunctionProgramProject_Click(object sender, EventArgs e)
        {
            _ = new frmFunctionProgramProject().ShowDialog();
        }

        private void menuCollectingOfficer_Click(object sender, EventArgs e)
        {
            _ = new frmCollectingOfficer().ShowDialog();
        }


        private void MenuReportGeneralJournal_Click(object sender, EventArgs e)
        {
            _ = new frmGeneralJournal().ShowDialog();
        }

        private void MenuReportCashDisbursementsJournal_Click(object sender, EventArgs e)
        {
            _ = new frmCashDisbursementJournalReport().ShowDialog();
        }

        private void MenuReportCheckDisbursementsJournal_Click(object sender, EventArgs e)
        {
            _ = new frmCheckDisbursementsJournalReport().ShowDialog();
        }

        private void MenuObligationRequest_Click(object sender, EventArgs e)
        {
            _ = new frmObligationRequestMain().ShowDialog();
        }

        private void MenuReportCashReceiptsJournal_Click(object sender, EventArgs e)
        {
            _ = new frmCashReceiptsJournalReport().ShowDialog();
        }
        private void MenuReportProcurementsReceivedJournal_Click(object sender, EventArgs e)
        {
            _ = new frmProcurementsReceivedJournalReport().ShowDialog();

        }

        private void MenuReportADADisbursementsJournal_Click(object sender, EventArgs e)
        {
            _ = new frmADADisbursementsJournalReport().ShowDialog();
        }



        private void MenuGeneralLedgerReport_Click(object sender, EventArgs e)
        {
            _ = new frmGeneralLedgerReport().ShowDialog();
        }

        private void menuBanks_Click(object sender, EventArgs e)
        {
            _ = new frmBanks().ShowDialog();
        }

        private void menuRCI_Click(object sender, EventArgs e)
        {
            _ = new frmRCI().ShowDialog();
        }

        private void menuprintRCI_Click(object sender, EventArgs e)
        {
            _ = new frmRCIReport().ShowDialog();
        }

        private void BtnJournalEntry_Click(object sender, EventArgs e)
        {
            _ = new frmJEV().ShowDialog();
        }

        private void BtnObligationRequest_Click(object sender, EventArgs e)
        {
            _ = new frmObligationRequestMain().ShowDialog();
        }

        private void MenuDisbursingOffice_Click(object sender, EventArgs e)
        {
            _ = new frmDisbursingOfficer().ShowDialog();
        }

        private void BtnRCI_Click(object sender, EventArgs e)
        {
            _ = new frmRCI().ShowDialog();
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
        private void menuprintPC_Click(object sender, EventArgs e)
        {
            _ = new frmGCList().ShowDialog();
        }

        private void menuPayments_Click(object sender, EventArgs e)
        {
            _ = new frmPaymentCollection().ShowDialog();
        }

        private void menuDeposits_Click(object sender, EventArgs e)
        {
            _ = new frmBankDeposits().ShowDialog();
        }

        private void menuSubsidiaryLedgerReport_Click(object sender, EventArgs e)
        {
            _ = new frmSubsidiaryLedgerReport().ShowDialog();
        }

        private void btnBudgetAppropriations_Click(object sender, EventArgs e)
        {
            _ = new frmBudgetAppropriations().ShowDialog();
        }

        private void btnAllotmentRelease_Click(object sender, EventArgs e)
        {
            _ = new frmAllotmentReleaseMain().ShowDialog();
        }

        private void menuprintGC_Click(object sender, EventArgs e)
        {
            _ = new frmPCReport().ShowDialog();
        }

        private void menureceipts_Click(object sender, EventArgs e)
        {
            _ = new frmAccForms().ShowDialog();
        }

        private void menureceiptsissued_Click(object sender, EventArgs e)
        {
            _ = new frmReceipts().ShowDialog();
        }

        private void menucashbook_Click(object sender, EventArgs e)
        {
            _ = new frmCashbook().ShowDialog();
        }

        private void menuJEVS_Click_1(object sender, EventArgs e)
        {
            _ = new frmJEVReport(0, null, 0).ShowDialog();
        }
        private void btnPaymentCollection_Click(object sender, EventArgs e)
        {
            _ = new frmPaymentCollection().ShowDialog();
        }

        private void menuGenerateRCD_Click(object sender, EventArgs e)
        {
            _ = new frmRCD().ShowDialog();
        }

        private void btnGenerateRCD_Click(object sender, EventArgs e)
        {
            _ = new frmRCD().ShowDialog();
        }

        private void btnBankDeposit_Click(object sender, EventArgs e)
        {
            _ = new frmBankDeposits().ShowDialog();
        }

        private void menuReceiptsConsolidated_Click(object sender, EventArgs e)
        {
            _ = new frmConsolidatedReceipts().ShowDialog();
        }

        private void menuTrialBalance_Click(object sender, EventArgs e)
        {
            _ = new frmTrialBalance().ShowDialog();
        }

        private void menuDailyCash_Click(object sender, EventArgs e)
        {
            _ = new frmDailyCash().ShowDialog();
        }

        #region BUDGET REPORTS

        private void MenuSAAOB_Click(object sender, EventArgs e)
        {
            _ = new frmSAAOB().ShowDialog();
        }
        private void MenuSAAOBB_Click(object sender, EventArgs e)
        {
            _ = new frmSAAOBB().ShowDialog();
        }

        #endregion

        #region FINANCIAL STATEMENTS
        private void statementOfFinancialPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmStatementOfFinancialPosition().ShowDialog();
        }

        private void statementOfFinancialPerformanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmStatementOfFinancialPerformance().ShowDialog();
        }

        private void statementOfChangesInNetAssetsEquityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmStatementOfChangesInNetAssetsEquity().ShowDialog();
        }

        private void statementOfCashFlowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmStatementOfCashFlows().ShowDialog();
        }

        private void statementOfComparisonOfBudgetAndActualAmountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmStatementOfComparisonOfBudgetAndActualAmounts().ShowDialog();
        }

        #endregion

        private void menuLedgersReport_Click(object sender, EventArgs e)
        {
            _ = new frmLedger().ShowDialog();
        }
    }
}
