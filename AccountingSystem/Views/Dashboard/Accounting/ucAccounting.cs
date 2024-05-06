using AccountingSystem.Views.Manage.ChartOfAccounts;
using AccountingSystem.Views.Manage.Journals;
using AccountingSystem.Views.Transactions.JEV;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Dashboard.Accounting
{
    public partial class ucAccounting : UserControl
    {
        public ucAccounting()
        {
            InitializeComponent();
        }

        private void chartOfAccountsTStrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmChartOfAccounts().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void journalsTStrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmJournals().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void journalEntryTStrpMnuItm_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmJev(false, null, ucJevDashboard1).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}