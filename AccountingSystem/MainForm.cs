using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AccountingSystem.Views.Manage.Journals;
using AccountingSystem.Views.Manage.Funds;
using AccountingSystem.Views.Manage.Banks;
using AccountingSystem.Views.Manage.ChartOfAccounts;
using AccountingSystem.Views.Manage.AllotmentClasses;
using AccountingSystem.Views.Manage.FunctionProgramProject;
using AccountingSystem.Views.Manage.CollectingOfficer;
using AccountingSystem.Views.Manage.Users.Roles;
using AccountingSystem.Views.Manage.Users.List;
using AccountingSystem.Views.Transactions.JEV;
using AccountingSystem.Views.Reports.Journals;
using AccountingSystem.Views.Manage.BudgetAppropriations;
using AccountingSystem.Views.Transactions.RCI;
using AccountingSystem.Views.Reports.SAAOB;
using AccountingSystem.Views.Reports.Ledgers;
using AccountingSystem.Views.Dashboard;
using AccountingSystem.Views.Reports.RCI;
using AccountingSystem.Views.Manage.DisbursingOfficer;
using AccountingSystem.Views.Manage.AccountableForm;
using AccountingSystem.Views.Transactions.ObligationRequest;

namespace AccountingSystem
{
    public partial class MainForm : Form
    {
        private Dictionary<string, string> userDict;
        private LoginForm loginForm;

        public MainForm(LoginForm _loginForm)
        {
            InitializeComponent();
            menuReportGJ.Click += new EventHandler(MenuReportGeneralJournal_Click);
            menuReportCDJ.Click += new EventHandler(MenuReportCashDisbursementsJournal_Click);
            menuReportCkDJ.Click += new EventHandler(MenuReportCheckDisbursementsJournal_Click);
            menuObligationRequest.Click += new EventHandler(MenuObligationRequest_Click);
            menuReportCRJ.Click += new EventHandler(MenuReportCashReceiptsJournal_Click);
            menuReportPRJ.Click += new EventHandler(MenuReportProcurementsReceivedJournal_Click);
            menuReportADADJ.Click += new EventHandler(MenuReportADADisbursementsJournal_Click);
            menuSAAOB.Click += new EventHandler(MenuSAAOB_Click);
            menuGeneralLedgerReport.Click += new EventHandler(MenuGeneralLedgerReport_Click);
            btnJournalEntry.Click += new EventHandler(BtnJournalEntry_Click);
            btnObligationRequest.Click += new EventHandler(BtnObligationRequest_Click);
            menuDisbursingOfficer.Click += new EventHandler(MenuDisbursingOffice_Click);
            btnRCI.Click += new EventHandler(BtnRCI_Click);
            menuLogout.Click += new EventHandler(menuLogout_Click);
            menuExitApp.Click += new EventHandler(menuExitApp_Click);

            userDict = Helper.LoggedInUserData();
            loginForm = _loginForm;
        }

        private void LoadLoggedInUser()
        {
            lblUserFullName.Text = $"Welcome {userDict["first_name"]} {userDict["mid_initial"]} {userDict["last_name"]}";
            lblUserRole.Text = userDict["role_name"];
        }

        private void ValidatePermissions()
        {
            if (!Helper.HasPermission("Manage Allotment Classes"))
                menuAllotmentClasses.Visible = false;

            if (!Helper.HasPermission("Manage Budget Appropriations") && !Helper.HasPermission("Manage Allotment Releases"))
                menuBudgetAppropriation.Visible = false;

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
                menuObligationRequest.Visible = false;
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

            if (!Helper.HasPermission("Report General Ledger"))
                menuGeneralLedgerReport.Visible = false;

            if (!Helper.HasPermission("Report Subsidiary Ledger"))
                menuSubsidiaryLedgerReport.Visible = false;

            if (!Helper.HasPermission("Report SAAOB"))
                menuSAAOB.Visible = false;

            if (!Helper.HasPermission("Manage Banks"))
                menuBanks.Visible = false;

            if (!Helper.HasPermission("Manage Disbursing Officer"))
                menuDisbursingOfficer.Visible = false;

            if (!Helper.HasPermission("Transaction RCI"))
            {
                btnRCI.Visible = false;
                menuRCI.Visible = false;
            }
                
        }

        private void LoadDashboard()
        {
            switch (userDict["office"])
            {
                case "Budget":
                case "Accounting":
                    panel1.Controls.Add(new UcAccountingDashboard(Helper.LoggedInUserData()));
                    break;
                case "Treasury":

                    break;
                case "Assessor":

                    break;
                default:
                    break;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            menuSubsidiaryLedgerReport.Enabled = false;
            LoadLoggedInUser();
            ValidatePermissions();
            LoadDashboard();
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

        private void menuBudgetAppropriation_Click(object sender, EventArgs e) 
        {
            _ = new frmBudgetAppropriations().ShowDialog();
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
            _ = new frmObligationRequest().ShowDialog();
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

        private void MenuSAAOB_Click(object sender, EventArgs e) 
        {
            _ = new frmSAAOB().ShowDialog();
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
            _ = new frmObligationRequest().ShowDialog();
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
    }
}
