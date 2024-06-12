using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Biddings
{
    public partial class frmBiddings : Form
    {
        public frmBiddings()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgBiddings, true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageForm);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageList);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageForm);
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            TabPageController(tabPagePayment);
        }

        private void btnPaymentBack_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageForm);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TabPageController(tabPagePayment);
        }

        private void frmBiddings_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
            LoadRowFilter();
            Helper.EnableDisableToolStripButtons(dgBiddings, btnEdit, btnDelete);
        }

        private void LoadRowFilter()
        {
            HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowFilter);
        }

        private void lTOM26ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPageController(tabPagePublicAuctionRegistrationForm);
        }

        private void lTOM26ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageListOfRegisteredBidders);
        }

        private void lTOM27ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageUndertakingAndWaiverOfBidders);
        }

        private void lTOM28ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageRulesAndRegulationOfPublicAuction);
        }

        private void TabPageController(TabPage tabPageRoute)
        {
            try
            {
                if (tabControlPrintPreview.TabPages.Contains(tabPageRoute))
                {
                    tabControl1.SelectedTab = tabPagePrint;
                    tabControlPrintPreview.SelectedTab = tabPageRoute;
                    Text = $"Transaction > Print > {tabPageRoute.Text} ";
                    return;
                }

                Text = $"Transaction > {tabPageRoute.Text} ";
                tabControl1.SelectedTab = tabPageRoute;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageList);
        }

    }
}
