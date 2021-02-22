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

        internal void LoadAccountGroup()
        {
            try
            {
                var dtAccountGroup = Factory.AccountGroupRepository().GetRecords();
                HelperLoadRecords.AccountGroupDatagridView(dtAccountGroup, dgAccountGroup);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadGeneralLedgers()
        {
            try
            {
                var generalLedgerAccountsRepo = Factory.GeneralLedgerAccountsRepository();
                var dtAccounts = generalLedgerAccountsRepo.GetViewRecords();
                HelperLoadRecords.GeneralLedgerAccountsDatagridView(dtAccounts, dgGeneralLedgerAccounts);
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
            Helper.DatagridDefaultStyle(dgAccountGroup);
            LoadAccountGroup();
            LoadGeneralLedgers();
        }

        private void dgGeneralLedgerAccounts_SelectionChanged(object sender, EventArgs e)
        {
            int[] columnIndexTimestamp = { 3, 4 };
            Helper.ShowRecordTimestamp(dgGeneralLedgerAccounts, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabAccountGroup"])
            {
                MessageBox.Show("Account group");
            }
        }
    }
}
