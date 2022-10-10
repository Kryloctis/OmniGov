using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.PaymentPortal
{
    public partial class frmPaymentPortal : Form
    {
        public frmPaymentPortal()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
