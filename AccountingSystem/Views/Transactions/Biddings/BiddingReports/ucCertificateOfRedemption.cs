using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Biddings.BiddingReports
{
    public partial class ucCertificateOfRedemption : UserControl
    {
        public ucCertificateOfRedemption()
        {
            InitializeComponent();
            panel1.Controls.Add(reportViewer1);
        }
    }
}
