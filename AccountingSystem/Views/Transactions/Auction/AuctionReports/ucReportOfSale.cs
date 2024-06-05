using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Auction
{
    public partial class ucReportOfSale : UserControl
    {

        private int auctionId;

        public ucReportOfSale()
        {
            InitializeComponent();
            panel1.Controls.Add(reportViewer1);
        }

        internal void OnLoad(int auctionId)
        {
            this.auctionId = auctionId;
            LoadReport();
        }

        private void LoadReport()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync(auctionId);
            }
        }


        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

        }
    }
}
