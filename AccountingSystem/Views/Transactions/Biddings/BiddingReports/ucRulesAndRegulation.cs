using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Helper.ProgressCounter(backgroundWorker1, 100, 100);

            var tasks = new Dictionary<string, int>
            {
                { "Initialize Parameters", 100 },
            };

            int totalProgressCount = tasks.Sum(t => t.Value);
            int progressCount = 0;

            List<ReportParameter> reportParameters = new List<ReportParameter>();
            progressCount += tasks["Initialize Parameters"];

            reportParameters.Add(new ReportParameter("paramLGU", "asd"));
            e.Result = reportParameters;
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {

                if (e.Cancelled)
                {
                    reportViewer1.Clear();
                    progressBar1.Value = 100;
                    return;
                }

                var parameters = (List<ReportParameter>)e.Result;
                reportViewer1.Clear();
                var localReport = reportViewer1.LocalReport;
                localReport.ReportPath = $"{Application.StartupPath}Reports\\Ltom\\ltom-28-rules-and-regulation-of-public-auction.rdlc";
                localReport.SetParameters(parameters);
                localReport.Refresh();

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.FullPage;
                reportViewer1.Refresh();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
