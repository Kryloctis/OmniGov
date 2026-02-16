using LFS.DataSets;
using LFS.Helpers;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Treasury.Data;

namespace LFS.Views.Reports.Ltoms
{
    public partial class frmLtom31 : Form
    {
        private int auctionId;

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
            DataTable dtAuctionSchedule = TreasuryFactory.AuctionRepository().GetAuctionSchedule();
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

                // Define tasks and their progress weights
                var tasks = new Dictionary<string, int>
                {
                    { "Fetch LGU Details", 10 },
                    { "Initialize Parameters", 30 },
                    { "Set Parameter Values", 40 }
                };

                var dtLTOM31 = new dsTreasury.dtSoldRptDataTable();
                var dtSoldRpt = TreasuryFactory.BidRepository().GetSoldRpt(auctionId);
                int totalProgressCount = tasks.Sum(t => t.Value) + dtSoldRpt.Rows.Count;
                int progressCount = 0;

                progressCount += tasks["Fetch LGU Details"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                List<ReportParameter> reportParameters1 = new List<ReportParameter>();
                progressCount += tasks["Initialize Parameters"];
                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                reportParameters1.Add(new ReportParameter("paramLgu", ServerHelper.selectedServer.MunicipalityName));
                progressCount += tasks["Set Parameter Values"];

                Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);

                foreach (DataRow dataRow in dtSoldRpt.Rows)
                {
                    var newRow = dtLTOM31.NewRow();

                    newRow["arp_no"] = dataRow["complete_arp_no"];
                    newRow["assessed_value"] = Convert.ToDecimal(dataRow["assessed_value"]);
                    newRow["sold_amount"] = Convert.ToDecimal(dataRow["bid_amount"]);
                    newRow["sold_to"] = dataRow["name"];
                    newRow["sold_to_contact"] = dataRow["contact_info"];
                    newRow["sold_to_address"] = dataRow["address"];

                    progressCount++;
                    dtLTOM31.Rows.Add(newRow);
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                }

                e.Result = dtLTOM31;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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
                report.ReportPath = $"{Application.StartupPath}Reports\\Ltoms\\Ltom31ReportOfSale.rdlc";
                report.DataSources.Clear();

                var report2 = reportViewer2.LocalReport;
                report2.ReportPath = $"{Application.StartupPath}Reports\\Ltoms\\ListOfSoldRptAtAuction.rdlc";
                report2.DataSources.Clear();

                var reportParameters = new ReportParameter[]
                {
                    new ReportParameter("paramLGU", ServerHelper.selectedServer.MunicipalityName),
                };

                report.DataSources.Add(new ReportDataSource(dataTable.TableName, dataTable));
                report.SetParameters(reportParameters);

                report2.SetParameters(reportParameters);
                report2.DataSources.Add(new ReportDataSource("dsSoldRpt", dataTable));

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
    }
}