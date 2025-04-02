using ACC.Data;
using LFS;
using Microsoft.Reporting.WinForms;
using Org.BouncyCastle.Pqc.Crypto.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ZstdSharp.Unsafe;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LFS.Views.Reports.DailyCashPositionReport
{
    public partial class frmDailyCash : Form
    {
        public frmDailyCash()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            reportViewer1.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer1);
        }

        private void btnretrieve_Click(object sender, EventArgs e)
        {
            try
            {
                LoadReport();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ToogleRunButton(bool isGenerated)
        {
            btnRunReport.Text = isGenerated ? "Run Report" : "Generating Report...";
            btnRunReport.Enabled = isGenerated;
        }

        private void LoadReport()
        {
            if (!backgroundWorker1.IsBusy)
            {
                progressBar1.Value = 0;
                var date = dtdate.Value;
                ToogleRunButton(false);
                backgroundWorker1.RunWorkerAsync(date);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var date = (DateTime)e.Argument;
                var dtGeneralCash = new dsLFS.dtCashreportDataTable().Clone();
                var dtSpecialCash = new dsLFS.dtCashreportDataTable().Clone();
                var dtTrustCash = new dsLFS.dtCashreportDataTable().Clone();

                var dtdata = AccFactory.FundsRepository().GetRecordsPrintCashposition(date);

                var fundType = new string[] { "General Fund", "Special Education Fund", "Trust Fund" };
                decimal beginning = 0;
                decimal end = 0;

                int totalProgressCount = 0;
                int progressCount = 0;

                foreach (string fund in fundType)
                {
                    var rows = dtdata.AsEnumerable().Where(row => row.Field<string>("fund_name") == fund).ToList();
                    totalProgressCount += rows.Count;
                    DataTable dataTable = new DataTable();

                    switch (fund)
                    {
                        case "General Fund":
                            dataTable = dtGeneralCash;
                            break;

                        case "Special Education Fund":
                            dataTable = dtSpecialCash;
                            break;

                        case "Trust Fund":
                            dataTable = dtTrustCash;
                            break;

                        default:
                            dataTable = null;
                            break;
                    }

                    foreach (DataRow item in rows)
                    {
                        DataRow row = dataTable.NewRow();
                        row["date"] = Convert.ToDateTime(date);
                        row["details"] = "Beginning Balance";
                        row["balance"] = item["beginning"];
                        beginning = decimal.Parse(item["beginning"].ToString());
                        dataTable.Rows.Add(row);
                        progressCount++;
                        Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                    }

                    foreach (DataRow item in rows)
                    {
                        DataRow row = dataTable.NewRow();
                        row["date"] = Convert.ToDateTime(date);
                        row["details"] = "Collections";
                        row["collection"] = item["collection"];
                        dataTable.Rows.Add(row);
                        progressCount++;
                        Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                    }

                    foreach (DataRow item in rows)
                    {
                        DataRow row = dataTable.NewRow();
                        row["date"] = Convert.ToDateTime(date);
                        row["details"] = "Deposits";
                        row["deposit"] = item["deposited"];
                        end = decimal.Parse(item["deposited"].ToString());
                        dataTable.Rows.Add(row);
                        progressCount++;
                        Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                    }

                    foreach (DataRow item in rows)
                    {
                        DataRow row = dataTable.NewRow();
                        row["date"] = Convert.ToDateTime(date);
                        row["details"] = "Ending Balance";
                        row["balance"] = beginning + end;
                        dataTable.Rows.Add(row);
                        progressCount++;
                        Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                    }
                    e.Result = (dtGeneralCash, dtSpecialCash, dtTrustCash);
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                var localReport = reportViewer1.LocalReport;

                if (e.Result is not (DataTable dtGeneralCash, DataTable dtSpecialCash, DataTable dtTrustCash))
                {
                    progressBar1.Value = 100;
                    return;
                }

                if (dtGeneralCash.Rows.Count < 1 && dtSpecialCash.Rows.Count < 1 && dtTrustCash.Rows.Count < 1)
                    progressBar1.Value = 100;

                static void ParseSignatory(Dictionary<string, string> dictSignatory, ref string signatory, ref string signatoryTitle)
                {
                    if (dictSignatory.Count > 0)
                    {
                        string prefix = dictSignatory["signatories_prefix"].ToString();
                        string firstName = dictSignatory["signatories_first_name"].ToString();
                        char middleInitial = Convert.ToChar(dictSignatory["signatories_middle_initial"]);
                        string lastName = dictSignatory["signatories_last_name"].ToString();
                        string suffix = dictSignatory["signatories_suffix"].ToString();

                        string signatoryName = $"{(string.IsNullOrEmpty(prefix) ? string.Empty : $"{prefix}.")} {firstName} {middleInitial}. {lastName}{(string.IsNullOrEmpty(suffix) ? string.Empty : $", {suffix}")}";

                        signatory = signatoryName;
                        signatoryTitle = dictSignatory["signatories_title"];
                    }
                }

                var dictCertifiedCorrectSignatory = AccFactory.SignatoriesHasReferencesRepository().GetSignatoryBy_Reference_DocumentName("Certified Correct", "Daily Cash Position Report");
                string certifiedCorrectSignatory = string.Empty;
                string certifiedCorrectSignatoryTitle = string.Empty;
                ParseSignatory(dictCertifiedCorrectSignatory, ref certifiedCorrectSignatory, ref certifiedCorrectSignatoryTitle);

                var dictNotedSignatory = AccFactory.SignatoriesHasReferencesRepository().GetSignatoryBy_Reference_DocumentName("Noted", "Daily Cash Position Report");
                string notedSignatory = string.Empty;
                string notedSignatoryTitle = string.Empty;
                ParseSignatory(dictNotedSignatory, ref notedSignatory, ref notedSignatoryTitle);

                var dictPreparedBySignatory = AccFactory.SignatoriesHasReferencesRepository().GetSignatoryBy_Reference_DocumentName("Prepared By", "Daily Cash Position Report");

                string preparedBySignatory = string.Empty;
                string preparedBySignatoryTitle = string.Empty;

                ParseSignatory(dictPreparedBySignatory, ref preparedBySignatory, ref preparedBySignatoryTitle);

                var lguDetails = Helper.LGUDetails();
                var parameters = new[]
                {
                    new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                    new ReportParameter("paramDate", dtdate.Value.ToString("MMMM dd, yyyy")),
                    new ReportParameter("paramMayor", notedSignatory),
                    new ReportParameter("paramLGUProvince", "BUUG, ZAMBONGA SIBUGAY"),
                    new ReportParameter("paramCertifiedCorrectSignatory", certifiedCorrectSignatory),
                    new ReportParameter("paramCertifiedCorrectSignatoryTitle", certifiedCorrectSignatoryTitle),
                    new ReportParameter("paramPreparedBySignatory", Helper.LoggedInUserData()["user_full_name"]),
                    new ReportParameter("paramPreparedBySignatoryTitle", preparedBySignatoryTitle),
                    new ReportParameter("paramNotedSignatory", notedSignatory),
                    new ReportParameter("paramNotedSignatoryTitle", notedSignatoryTitle)
                };

                localReport.ReportPath = $"{Application.StartupPath}Reports\\daily-cash-position-report.rdlc";
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("dtCashreport", dtGeneralCash));
                localReport.DataSources.Add(new ReportDataSource("dtCashreport1", dtSpecialCash));
                localReport.DataSources.Add(new ReportDataSource("dtCashreport2", dtTrustCash));
                localReport.SetParameters(parameters);
                localReport.Refresh();

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.FullPage;
                reportViewer1.RefreshReport();
                ToogleRunButton(true);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}