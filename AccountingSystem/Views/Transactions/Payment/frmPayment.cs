using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.PaymentPortal
{
    public partial class frmPayment : Form
    {
        public frmPayment()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
