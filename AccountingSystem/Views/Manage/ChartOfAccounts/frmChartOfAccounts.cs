using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.ChartOfAccounts
{
    public partial class frmChartOfAccounts : Form
    {

        public frmChartOfAccounts()
        {
            InitializeComponent();
        }

        internal void LoadRecords()
        {
            try
            {
                var generalLedgerAccountsRepo = Factory.GeneralLedgerAccountsRepository();
                var dtAccounts = generalLedgerAccountsRepo.GetViewRecords();
                HelperLoadRecords.GeneralLedgerAccountsDatagridView(dtAccounts, dgGeneralLedgerAccounts);

                lblRecordCount.Text = generalLedgerAccountsRepo.CountRecords().ToString();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }


        private void frmChartOfAccounts_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            Helper.DatagridDefaultStyle(dgGeneralLedgerAccounts);
            toolStrip1.Visible = false;
            LoadRecords();
        }

        private void dgGeneralLedgerAccounts_SelectionChanged(object sender, EventArgs e)
        {
            int[] columnIndexTimestamp = { 3, 4 };
            Helper.ShowRecordTimestamp(dgGeneralLedgerAccounts, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgGeneralLedgerAccounts, btnEdit, btnDelete);
        }
    }
}
