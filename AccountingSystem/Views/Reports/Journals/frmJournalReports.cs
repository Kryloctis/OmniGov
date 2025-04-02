using LFS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Journals
{
    public partial class frmJournalReports : Form
    {
        private ucGenJrnlReport ucGenJrnlReport;
        private ucCashReceiptsJrnlReport ucCashReceiptsJournalReport;
        private ucProcurementReceivedJrnlReport ucProcurementReceivedJrnlReport;
        private ucCashDisbursementJrnlReport ucCashDisbursementJrnlReport;
        private ucCheckDisbursementsJrnlReport ucCheckDisbursementsJrnlReport;
        private ucAdadDisbursementJrnlReport ucAdadDisbursementJrnlReport;

        public frmJournalReports()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            ucGenJrnlReport = ucGenJrnlReport1;
            ucCashReceiptsJournalReport = ucCashReceiptsJournalReport1;
            ucProcurementReceivedJrnlReport = ucProcurementReceivedJrnlReport1;
            ucCashDisbursementJrnlReport = ucCashDisbursementJrnlReport1;
            ucCheckDisbursementsJrnlReport = ucCheckDisbursementsJrnlReport1;
            ucAdadDisbursementJrnlReport = ucAdadDisbursementJrnlReport1;
        }

        private void frmJournalReports_Load(object sender, EventArgs e)
        {
            try
            {
                ToggleContents(tabControlJournals);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tabControlJournals_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ToggleContents(tabControlJournals);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ToggleContents(TabControl tabControl)
        {
            switch (tabControl.SelectedTab.Name)
            {
                case "tabPageGenJrnl":
                    ucGenJrnlReport.OnLoad();
                    break;

                case "tabPageCashReceiptsJrnl":
                    ucCashReceiptsJournalReport.OnLoad();
                    break;

                case "tabPageCashDisbursementJrnl":
                    ucCashDisbursementJrnlReport.OnLoad();
                    break;

                case "tabPageChckDisbursementJrnl":
                    ucCheckDisbursementsJrnlReport.OnLoad();
                    break;

                case "tabPageProcReceivedJrnl":
                    ucProcurementReceivedJrnlReport.OnLoad();
                    break;

                case "tabPageAdaDisbursementJrnl":
                    ucAdadDisbursementJrnlReport.OnLoad();
                    break;
            }
        }
    }
}