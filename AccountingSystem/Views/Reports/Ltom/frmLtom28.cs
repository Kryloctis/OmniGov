using AccountingSystem.Views.Transactions.Biddings.BiddingReports;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Ltom
{
    public partial class frmLtom28 : Form
    {
        private ucRulesAndRegulation ucRulesAndRegulation;
        public frmLtom28()
        {
            InitializeComponent();
            ucRulesAndRegulation = ucRulesAndRegulation1;
        }

        private void frmLtom28_Load(object sender, EventArgs e)
        {
            ucRulesAndRegulation.OnLoad();
        }

        private void ucRulesAndRegulation1_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbxAuctionSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
