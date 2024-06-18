using AccountingSystem.Views.Transactions.Biddings.BiddingReports;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Ltom
{
    public partial class frmLtom28 : Form
    {
        private ucPublicAuctionRegistrationForm ucPublicAuctionRegistrationForm;

        public frmLtom28()
        {
            InitializeComponent();
            ucPublicAuctionRegistrationForm = ucPublicAuctionRegistrationForm1;
        }

        private void ucPublicAuctionRegistrationForm1_Load(object sender, EventArgs e)
        {

        }

        private void frmLtom28_Load(object sender, EventArgs e)
        {
            ucPublicAuctionRegistrationForm.OnLoad();
        }
    }
}
