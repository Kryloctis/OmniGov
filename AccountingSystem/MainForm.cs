using System;
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
using AccountingSystem.Views.Transactions.ObligationRequest;
using AccountingSystem.Views.Transactions.RCI;
using AccountingSystem.Views.Reports.SAAOB;
using AccountingSystem.Views.Reports.Ledgers;
using AccountingSystem.Views.Manage.AllotmentRelease;
using AccountingSystem.Views.Reports.RCI;

namespace AccountingSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
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
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            menuSubsidiaryLedgerReport.Enabled = false;
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

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
           var frmObligationRequest = new frmObligationRequest();
           frmObligationRequest.ShowDialog();
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
    }
}
