using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Biddings.BiddingReports
{
    public partial class ucRulesAndRegulation : UserControl
    {
        public ucRulesAndRegulation()
        {
            InitializeComponent();
            panel1.Controls.Add(reportViewer1);
        }


        internal void OnLoad()
        {
            LoadReport();
        }

        private void LoadReport()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

        }
    }
}
