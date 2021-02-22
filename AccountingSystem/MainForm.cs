using System;
using System.Windows.Forms;
using AccountingSystem.Views.Manage.Journals;
using AccountingSystem.Views.Manage.Funds;
using AccountingSystem.Views.Manage.ChartOfAccounts;

using AccountingSystem.Views.Manage.AllotmentClasses;
namespace AccountingSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
