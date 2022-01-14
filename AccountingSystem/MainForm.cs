using AccountingSystem.Views.Manage.AccountableForm;
using AccountingSystem.Views.Manage.AllotmentClasses;
using AccountingSystem.Views.Manage.AllotmentRelease;
using AccountingSystem.Views.Manage.Amortization;
using AccountingSystem.Views.Manage.Banks;
using AccountingSystem.Views.Manage.BudgetAppropriations;
using AccountingSystem.Views.Manage.ChartOfAccounts;
using AccountingSystem.Views.Manage.CollectingOfficer;
using AccountingSystem.Views.Manage.DisbursingOfficer;
using AccountingSystem.Views.Manage.FunctionProgramProject;
using AccountingSystem.Views.Manage.Funds;
using AccountingSystem.Views.Manage.Journals;
using AccountingSystem.Views.Manage.Receipts;
using AccountingSystem.Views.Manage.ReturnedReceipts;
using AccountingSystem.Views.Manage.Signatories;
using AccountingSystem.Views.Manage.Users.List;
using AccountingSystem.Views.Manage.Users.Roles;
using AccountingSystem.Views.Reports.Cashbook;
using AccountingSystem.Views.Reports.ConsolidatedReceipts;
using AccountingSystem.Views.Reports.DailyCashReport;
using AccountingSystem.Views.Reports.GeneralCollection;
using AccountingSystem.Views.Reports.RCD;
using AccountingSystem.Views.Reports.RCI;
using AccountingSystem.Views.Reports.SAAOB;
using AccountingSystem.Views.Reports.SAAOBB;
using AccountingSystem.Views.Transactions.ObligationRequest;
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
            tabControlDashboard.TabPages.Clear();
            tabControlAccounting.TabPages.Clear();
            tabControlLedgers.TabPages.Clear();
            tabControlTrialBalance.TabPages.Clear();
            tabControlFinancialStatements.TabPages.Clear();
            userDict = Helper.LoggedInUserData();
            loginForm = _loginForm;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadLoggedInUser();
                ValidatePermissions();
            }
        }

        private void LoadLoggedInUser()
        {
            string prefix = userDict["prefix"];
            string suffix = userDict["suffix"];

            lblUserFullName.Text = $"Welcome: {(string.IsNullOrWhiteSpace(prefix) ? string.Empty : $"{prefix}.")} {userDict["first_name"]} {userDict["mid_initial"]}. {userDict["last_name"]} {(string.IsNullOrWhiteSpace(suffix) ? string.Empty : $", {suffix}")}";
            lblUserRole.Text = userDict["role_name"];
        }


        private void ValidatePermissions()
        {
            ValidateDashboadPermissions();

            ValidateManagePermissions();

            ValidateTransactionPermissions();

            ValidateReportPermissions();

            ValidateAccountingControlPermissions();
        }

        private void ValidateReportPermissions()
        {
            if (!Helper.HasPermission("Report of Checks Issued"))
                menuprintRCI.Visible = false;

            if (!Helper.HasPermission("Report of Collections and Deposits"))
                menuprintPC.Visible = false;

            if (!Helper.HasPermission("Reports of General Collections"))
                menuprintGC.Visible = false;

            if (!Helper.HasPermission("Report Bank Cashbook"))
                menuBankCashBook.Visible = false;

            if (!Helper.HasPermission("Report Consolidated Receipts"))
                menuReceiptsConsolidated.Visible = false;

            if (!Helper.HasPermission("Report Daily Cash Position"))
                menuDailyCash.Visible = false;

            if (!Helper.HasPermission("Report SAAOB"))
                menuSAAOB.Visible = false;

            if (!Helper.HasPermission("Report SAAOBB"))
                menuSAAOBB.Visible = false;
        }

        private void ValidateTransactionPermissions()
        {
            if (!Helper.HasPermission("Transaction Obligation Request"))
                btnObligationRequest.Visible = false;

            if (!Helper.HasPermission("Transaction Issue Check"))
                ucTreasuryDashboard1.btnIssueCheck.Enabled = false;

            if (!Helper.HasPermission("Transaction Bank Deposits"))
                ucTreasuryDashboard1.btnBankDeposit.Enabled = false;

            if (!Helper.HasPermission("Transaction Payments"))
                ucTreasuryDashboard1.btnPaymentCollection.Enabled = false;

            if (!Helper.HasPermission("Transaction Issue Receipt"))
                ucTreasuryDashboard1.btnIssueReceipt.Enabled = false;

        }

        private void ValidateManagePermissions()
        {
            if (!Helper.HasPermission("Manage Allotment Classes"))
                menuAllotmentClasses.Visible = false;

            if (!Helper.HasPermission("Manage Budget Appropriations"))
                btnBudgetAppropriations.Enabled = false;

            if (!Helper.HasPermission("Manage Allotment Releases"))
                btnAllotmentRelease.Enabled = false;

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

            if (!Helper.HasPermission("Manage Banks"))
                menuBanks.Visible = false;

            if (!Helper.HasPermission("Manage Disbursing Officer"))
                menuDisbursingOfficer.Visible = false;

            if (!Helper.HasPermission("Manage Receipts"))
                menuReceipts.Visible = false;

            if (!Helper.HasPermission("Transaction Issue Receipt"))
                ucTreasuryDashboard1.btnIssueReceipt.Enabled = false;

            if (!Helper.HasPermission("Transaction Generate RCD"))
                ucTreasuryDashboard1.btnRCD.Enabled = false;

            if (!Helper.HasPermission("Report of Checks Issued"))
                menuprintRCI.Visible = false;

            if (!Helper.HasPermission("Report of Collections and Deposits"))
                menuprintPC.Visible = false;

            if (!Helper.HasPermission("Reports of General Collections"))
                menuprintGC.Visible = false;

            if (!Helper.HasPermission("Report Bank Cashbook"))
                menuBankCashBook.Visible = false;

            if (!Helper.HasPermission("Report Consolidated Receipts"))
                menuReceiptsConsolidated.Visible = false;

            if (!Helper.HasPermission("Report Daily Cash Position"))
                menuDailyCash.Visible = false;

            if (!Helper.HasPermission("Report SAAOB"))
                menuSAAOB.Visible = false;

            if (!Helper.HasPermission("Report SAAOBB"))
                menuSAAOBB.Visible = false;

            if (!Helper.HasPermission("Manage Amortization"))
                amortiaztionToolStripMenuItem.Visible = false;

            if (!Helper.HasPermission("Manage Signatories"))
                signatoriesToolStripMenuItem.Visible = false;
        }

        private void ValidateAccountingControlPermissions()
        {
            #region Journal Entry Voucher

            if (Helper.HasPermission("Transaction JEV") || Helper.HasPermission("Report JEVs"))
            {
                radJournalEntryVoucher.Visible = true;
                tabControlAccounting.TabPages.Add(tabPageJournalEntryVoucher);
            }

            if (!Helper.HasPermission("Transaction JEV"))
            {
                ucjevDashboard1.btnAddJEV.Enabled = false;
            }

            #endregion

            #region Journals

            if (Helper.HasPermission("Report General Journal") || Helper.HasPermission("Report Cash Receipts Journal") || Helper.HasPermission("Report Procurement Received Journal") || Helper.HasPermission("Report Cash Disbursements Journal") || Helper.HasPermission("Report Check Disbursements Journal") || Helper.HasPermission("Report Authority to Debit Account Disbursements Journal"))
            {
                radJournals.Visible = true;
                tabControlAccounting.TabPages.Add(tabPageJournals);
            }


            if (!Helper.HasPermission("Report General Journal"))
                ucJournalsDashboard1.lnkGeneralJournal.Enabled = false;

            if (!Helper.HasPermission("Report Cash Receipts Journal"))
                ucJournalsDashboard1.lnkCashReceiptJournal.Enabled = false;

            if (!Helper.HasPermission("Report Procurement Received Journal"))
                ucJournalsDashboard1.lnkProcurementReceivedJournal.Enabled = false;

            if (!Helper.HasPermission("Report Cash Disbursements Journal"))
                ucJournalsDashboard1.lnkCashDisbursementJournal.Enabled = false;

            if (!Helper.HasPermission("Report Check Disbursements Journal"))
                ucJournalsDashboard1.lnkCheckDisbursementsJournal.Enabled = false;

            if (!Helper.HasPermission("Report Authority to Debit Account Disbursements Journal"))
                ucJournalsDashboard1.lnkADAdisbursementsJournal.Enabled = false;

            #endregion

            #region Ledgers

            if (Helper.HasPermission("Report General Ledger") || Helper.HasPermission("Report Subsidiary Ledger"))
            {
                radLedgers.Visible = true;
                tabControlAccounting.TabPages.Add(tabPageLedgers);
            }


            if (Helper.HasPermission("Report General Ledger"))
            {
                radioGeneralLedger.Enabled = true;
                tabControlLedgers.TabPages.Add(tabPageGeneralLedger);
            }

            if (Helper.HasPermission("Report Subsidiary Ledger"))
            {
                radioSubsidiaryLedger.Enabled = true;
                tabControlLedgers.TabPages.Add(tabPageSubsidiaryLedger);
            }


            if (Helper.HasPermission("Report General Ledger"))
                radioGeneralLedger.Checked = true;
            else if (Helper.HasPermission("Report Subsidiary Ledger"))
                radioSubsidiaryLedger.Checked = true;

            #endregion

            #region Trial Balance

            if (Helper.HasPermission("Report Pre Trial Balance") || Helper.HasPermission("Report Post Trial Balance"))
            {
                radTrialBalance.Visible = true;
                tabControlAccounting.TabPages.Add(tabPageTrialBalance);
            }


            if (Helper.HasPermission("Report Pre Trial Balance"))
            {
                radioPreTB.Enabled = true;
                tabControlTrialBalance.TabPages.Add(tabPagePreTrial);
            }

            if (Helper.HasPermission("Report Post Trial Balance"))
            {
                radioPostTB.Enabled = true;
                tabControlTrialBalance.TabPages.Add(tabPagePostTrial);
            }

            if (Helper.HasPermission("Report Pre Trial Balance"))
                radioPreTB.Checked = true;
            else if (Helper.HasPermission("Report Post Trial Balance"))
                radioPostTB.Checked = true;

            #endregion

            #region Financial Statements

            if (Helper.HasPermission("Report Statement of Changes in Net Assets Equity") || Helper.HasPermission("Report Statement of Financial Performance"))
            {
                radFinancialStatements.Visible = true;
                tabControlAccounting.TabPages.Add(tabPageFinancialStatements);
            }


            if (Helper.HasPermission("Report Statement of Financial Performance"))
            {
                radSFPerformance.Enabled = true;
                tabControlFinancialStatements.TabPages.Add(tabPageSFPerformance);
            }

            if (Helper.HasPermission("Report Statement of Changes in Net Assets Equity"))
            {
                radSCNAE.Enabled = true;
                tabControlFinancialStatements.TabPages.Add(tabPageSCNAE);
            }

            //if (Helper.HasPermission("Report Statement of Financial Position"))
            //{
            //    radSFPosition.Enabled = true;
            //    tabControlFinancialStatements.TabPages.Add(tabPageSFPosition);
            //}


            //if (Helper.HasPermission("Report Statement of Financial Position"))
            //    radSFPosition.Checked = true;
            //else 
            if (Helper.HasPermission("Report Statement of Financial Performance"))
                radSFPerformance.Checked = true;
            else if (Helper.HasPermission("Report Statement of Changes in Net Assets Equity"))
                radSCNAE.Checked = true;


            #endregion


            if (Helper.HasPermission("Transaction JEV") || Helper.HasPermission("Report JEVs"))
                radJournalEntryVoucher.Checked = true;
            else if (Helper.HasPermission("Report General Journal") || Helper.HasPermission("Report Cash Receipts Journal") || Helper.HasPermission("Report Procurement Received Journal") || Helper.HasPermission("Report Cash Disbursements Journal") || Helper.HasPermission("Report Check Disbursements Journal") || Helper.HasPermission("Report Authority to Debit Account Disbursements Journal"))
                radJournals.Checked = true;
            else if (Helper.HasPermission("Report General Ledger") || Helper.HasPermission("Report Subsidiary Ledger"))
                radLedgers.Checked = true;
            else if (Helper.HasPermission("Report Pre Trial Balance") || Helper.HasPermission("Report Post Trial Balance"))
                radTrialBalance.Checked = true;
            else if (Helper.HasPermission("Report Statement of Changes in Net Assets Equity") || Helper.HasPermission("Report Statement of Financial Performance"))
                radFinancialStatements.Checked = true;
        }

        private void ValidateDashboadPermissions()
        {
            #region Dashboard

            if (Helper.HasPermission("Budget Dashboard"))
            {
                radBtnBudget.Visible = true;
                tabControlDashboard.TabPages.Add(tabPageBudget);
            }

            if (Helper.HasPermission("Accounting Dashboard"))
            {
                radBtnAccounting.Visible = true;
                tabControlDashboard.TabPages.Add(tabPageAccounting);
            }

            if (Helper.HasPermission("Treasury Dashboard"))
            {
                radBtnTreasury.Visible = true;
                tabControlDashboard.TabPages.Add(tabPageTreasury);
            }


            if (Helper.HasPermission("Budget Dashboard"))
                radBtnBudget.Checked = true;
            else if (Helper.HasPermission("Accounting Dashboard"))
                radBtnAccounting.Checked = true;
            else if (Helper.HasPermission("Treasury Dashboard"))
                radBtnTreasury.Checked = true;


            #endregion
        }


        private void radBtnBudget_CheckedChanged(object sender, EventArgs e)
        {
            tabControlDashboard.SelectedTab = tabPageBudget;
        }

        private void radBtnAccounting_CheckedChanged(object sender, EventArgs e)
        {
            tabControlDashboard.SelectedTab = tabPageAccounting;
        }

        private void radBtnTreasury_CheckedChanged(object sender, EventArgs e)
        {
            tabControlDashboard.SelectedTab = tabPageTreasury;
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

        private void menuFunctionProgramProject_Click(object sender, EventArgs e)
        {
            _ = new frmFunctionProgramProject().ShowDialog();
        }

        private void menuCollectingOfficer_Click(object sender, EventArgs e)
        {
            _ = new frmCollectingOfficer().ShowDialog();
        }

        private void menuBanks_Click(object sender, EventArgs e)
        {
            _ = new frmBanks().ShowDialog();
        }

        private void menuprintRCI_Click(object sender, EventArgs e)
        {
            _ = new frmRCIReport().ShowDialog();
        }

        private void MenuDisbursingOffice_Click(object sender, EventArgs e)
        {
            _ = new frmDisbursingOfficer().ShowDialog();
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
            _ = new frmRCD().ShowDialog();
        }


        private void menureceipts_Click(object sender, EventArgs e)
        {
            _ = new frmReceipts().ShowDialog();
        }

        private void menucashbook_Click(object sender, EventArgs e)
        {
            _ = new frmCashbook().ShowDialog();
        }

        private void menuReceiptsConsolidated_Click(object sender, EventArgs e)
        {
            _ = new frmConsolidatedReceipts().ShowDialog();
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

        private void radioGeneralLedger_CheckedChanged(object sender, EventArgs e)
        {
            tabControlLedgers.SelectedTab = tabPageGeneralLedger;
        }

        private void radioSubsidiaryLedger_CheckedChanged(object sender, EventArgs e)
        {
            tabControlLedgers.SelectedTab = tabPageSubsidiaryLedger;
        }

        private void radioPreTB_CheckedChanged(object sender, EventArgs e)
        {
            tabControlTrialBalance.SelectedTab = tabPagePreTrial;
        }

        private void radioPostTB_CheckedChanged(object sender, EventArgs e)
        {
            tabControlTrialBalance.SelectedTab = tabPagePostTrial;
        }

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

        private void amortiaztionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmAmortization().ShowDialog();
        }


        #region BUDGET

        private void btnBudgetAppropriations_Click(object sender, EventArgs e)
        {
            _ = new frmBudgetAppropriations().ShowDialog();
        }

        private void btnAllotmentRelease_Click(object sender, EventArgs e)
        {
            _ = new frmAllotmentReleaseMain().ShowDialog();
        }

        private void btnObligationRequest_Click(object sender, EventArgs e)
        {
            _ = new frmObligationRequestMain().ShowDialog();
        }

        #endregion

        private void chkbxDetailed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbxDetailed.Checked)
                tabControlBudget.SelectedTab = tabPageBudgetDetailed;
            else
                tabControlBudget.SelectedTab = tabPageBudgetSummary;
        }

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

        private void signatoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ = new frmSignatories().ShowDialog();
        }

        private void menuprintGC_Click(object sender, EventArgs e)
        {
            _ = new frmReportOfGeneralCollection().ShowDialog();
        }

        private void menuReturnReceipts_Click(object sender, EventArgs e)
        {
            _ = new frmReturnedReceipts().ShowDialog();
        }
    }
}
