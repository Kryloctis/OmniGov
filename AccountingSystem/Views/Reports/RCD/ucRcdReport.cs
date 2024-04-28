using ACC.Data;
using ACC.Domain.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RCD
{
    public partial class ucRcdReport : UserControl
    {
        private int rcdId;

        public ucRcdReport()
        {
            InitializeComponent();
            panel1.Controls.Add(reportViewer1);
        }

        internal void OnLoad(int rcdId)
        {
            this.rcdId = rcdId;
            LoadReport();
        }

        private void LoadReport()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync(rcdId);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int rcdId = (int)e.Argument;

                var rcdModel = new RcdModel() { Id = rcdId };
                var rcdCollectionsModel = new RcdCollectionsModel() { RcdModel = rcdModel };
                var rcdDepositsModel = new RcdDepositsModel() { RcdModel = rcdModel };

                var dbRcdCollections = AccFactory.PaymentCollectionsRepository().GetViewConsolidatedRcdRecords(rcdCollectionsModel);
                var dtRcdCollections = new DataTable();
                var rcdCollectionsColumns = new DataColumn[]
                {
                    new DataColumn("acc_form", typeof(string)),
                    new DataColumn("receipt_from", typeof(string)),
                    new DataColumn("receipt_to", typeof(string)),
                    new DataColumn("amount", typeof(decimal)),
                };
                dtRcdCollections.Columns.AddRange(rcdCollectionsColumns);

                var dbRcdDeposits = AccFactory.BankDepositsRepository().GetViewRcdRecord(rcdDepositsModel);
                var dtRcdDeposits = new DataTable();
                var rcdDepositsColumns = new DataColumn[]
                {
                    new DataColumn("acc_bank", typeof(string)),
                    new DataColumn("reference", typeof(string)),
                    new DataColumn("amount", typeof(decimal)),
                };
                dtRcdDeposits.Columns.AddRange(rcdDepositsColumns);

                int totalProgressCount = dbRcdCollections.Rows.Count + dbRcdDeposits.Rows.Count;
                int progressCount = 0;

                foreach (DataRow dataRow in dbRcdCollections.Rows)
                {
                    var newRow = dtRcdCollections.NewRow();

                    newRow["acc_form"] = $"{dataRow["acc_form_no"]}- {dataRow["acc_form_desc"]}";
                    newRow["receipt_from"] = dataRow["receipt_from"];
                    newRow["receipt_to"] = dataRow["receipt_to"];
                    newRow["amount"] = dataRow["total_amount"];

                    dtRcdCollections.Rows.Add(newRow);
                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                }

                foreach (DataRow dataRow in dbRcdDeposits.Rows)
                {
                    var newRow = dtRcdDeposits.NewRow();

                    newRow["acc_bank"] = $"{dataRow["account_no"]}-{dataRow["bank_name"]}";
                    newRow["reference"] = dataRow["reference"];
                    newRow["amount"] = dataRow["amount"];

                    dtRcdDeposits.Rows.Add(newRow);
                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                }

                e.Result = (dtRcdCollections, dtRcdDeposits);
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
                if (e.Result is not (DataTable dtRcdCollections, DataTable dtRcdDeposits))
                {
                    progressBar1.Value = 100;
                    return;
                }

                if (dtRcdCollections.Rows.Count < 1 && dtRcdDeposits.Rows.Count < 1)
                    progressBar1.Value = 100;

                var report = reportViewer1.LocalReport;
                report.ReportPath = $"{Application.StartupPath}Reports\\rcd.rdlc";
                report.DataSources.Clear();

                var dictRcd = AccFactory.RcdRepository().GetViewRecord(rcdId);

                var reportParameters = new ReportParameter[]
                {
                    new ReportParameter("paramLguName", Helper.LGUDetails()["lgu_name"]),
                    new ReportParameter("paramVerfSig", string.Empty),
                    new ReportParameter("paramReportNo", dictRcd["report_no"]),
                    new ReportParameter("paramDate", dictRcd["date"]),
                    new ReportParameter("paramAccOfficer", Helper.GetUserDataById(Convert.ToInt32(dictRcd["created_by_id"]))["user_full_name"]),
                    new ReportParameter("paramFund", dictRcd["fund_name"])
                };

                report.DataSources.Add(new ReportDataSource("dtRcdCollections", dtRcdCollections));
                report.DataSources.Add(new ReportDataSource("dtRcdDeposits", dtRcdDeposits));
                report.DataSources.Add(new ReportDataSource("dtRcdSummary", new DataTable()));
                report.DataSources.Add(new ReportDataSource("dtRcdAccEntries", new DataTable()));
                report.DataSources.Add(new ReportDataSource("dtRcdChecks", new DataTable()));
                report.SetParameters(reportParameters);
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.PageWidth;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}