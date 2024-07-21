using ACC.Data;
using ACC.Domain.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Ltom
{
    public partial class frmLtom31 : Form
    {
        int auctionId;

        public frmLtom31()
        {
            InitializeComponent();
            panel1.Controls.Add(reportViewer1);
            panel2.Controls.Add(reportViewer2);
        }

        private void ToogleRunButton(bool isGenerated)
        {
            btnRunReport.Text = isGenerated ? "Run Report" : "Generating Report...";
            btnRunReport.Enabled = isGenerated;
        }
        private void btnRunReport_Click(object sender, System.EventArgs e)
        {
            try
            {
                ToogleRunButton(false);
                int auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
                if (cmbxAuctionSchedule.SelectedIndex == -1)
                    return;

                LoadReport();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }

        }
        private void LoadReport()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
                ToogleRunButton(false);
                auctionId = Convert.ToInt32(cmbxAuctionSchedule.SelectedValue);
                backgroundWorker1.RunWorkerAsync(auctionId);
            }
        }

        private void LoadAuctionSchedule()
        {
            DataTable dtAuctionSchedule = AccFactory.AuctionRepository().GetAuctionSchedule();
            HelperLoadRecords.AuctionScheduleCombobox(dtAuctionSchedule, cmbxAuctionSchedule, "date", "id");
        }

        private void OnLoad()
        {
            LoadAuctionSchedule();
        }

        private void frmLtom31_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex)
            {
                Helper.ErrorMessage(ex.Message);
            }
        }


        private DataTable ReportData()
        {
            return new DataTable();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int auctionId = (int)e.Argument;
                var rptAuctionModel = new RptAuctionModel() { AuctionId = auctionId };

                int totalProgressCount = 0;
                int progressCount = 0;


                progressCount++;
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                e.Result = ReportData();
            }

            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                    return;
                if (e.Result is not DataTable dataTable)
                    return;

                if (dataTable.Rows.Count < 1)
                    progressBar1.Value = 100;


                var report = reportViewer1.LocalReport;
                report.ReportPath = $"{Application.StartupPath}Reports\\LTOM\\Ltom31ReportOfSale.rdlc";
                report.DataSources.Clear();

                var report2 = reportViewer2.LocalReport;
                report2.ReportPath = $"{Application.StartupPath}Reports\\LTOM\\ListOfSoldRptAtAuction.rdlc";
                report2.DataSources.Clear();


                var dtAuction = AccFactory.AuctionRepository().GetRecordById(auctionId);

                string lguName = Helper.LGUDetails()["lgu_name"];
                string location = dtAuction["location"];
                string date = dtAuction["start_date"];


                var reportParameters = new ReportParameter[]
                {
                    new ReportParameter("paramLGU", lguName),
                    new ReportParameter("paramDateOfPublicAuction", date)
                };

                report.DataSources.Add(new ReportDataSource(dataTable.TableName, dataTable));
                report.SetParameters(reportParameters);

                report2.SetParameters(reportParameters);

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.RefreshReport();


                reportViewer2.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer2.ZoomMode = ZoomMode.PageWidth;
                reportViewer2.ZoomPercent = 100;
                reportViewer2.RefreshReport();

                ToogleRunButton(true);

            }

            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
