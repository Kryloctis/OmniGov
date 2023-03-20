using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.DailyCashReport
{
    public partial class frmDailyCash : Form
    {
        private readonly ReportViewer reportViewer = new ReportViewer();

        public frmDailyCash()
        {
            InitializeComponent();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
            Helper.LoadFormIcon(this);
        }

        private void btnretrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }

        private DataTable DataTableCash(string fund, string date)
        {
            var dtcash = new dsLFS.dtCashreportDataTable();
            var dtdata = AccFactory.FundsRepository().GetRecordsPrintCashposition(date);
            if (dtdata.Rows.Count > 0)
            {
                var rows = dtdata.Select($"fund LIKE '%{fund}%'");
                decimal beginning = 0;
                decimal end = 0;
                foreach (DataRow item in rows)
                {
                    DataRow row = dtcash.NewRow();
                    row["date"] = Convert.ToDateTime(date);
                    row["details"] = "Beginning Balance";
                    row["balance"] = item["beginning"];
                    beginning = decimal.Parse(item["beginning"].ToString());
                    dtcash.Rows.Add(row);
                }
                foreach (DataRow item in rows)
                {
                    DataRow row = dtcash.NewRow();
                    row["date"] = Convert.ToDateTime(date);
                    row["details"] = "Collections";
                    row["collection"] = item["collection"];
                    dtcash.Rows.Add(row);
                }
                foreach (DataRow item in rows)
                {
                    DataRow row = dtcash.NewRow();
                    row["date"] = Convert.ToDateTime(date);
                    row["details"] = "Deposits";
                    row["deposit"] = item["deposited"];
                    end = decimal.Parse(item["deposited"].ToString());
                    dtcash.Rows.Add(row);
                }
                foreach (DataRow item in rows)
                {
                    DataRow row = dtcash.NewRow();
                    row["date"] = Convert.ToDateTime(date);
                    row["details"] = "Ending Balance";
                    row["balance"] = beginning + end;
                    dtcash.Rows.Add(row);
                }
            }
            return dtcash;
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

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


                string date = String.Format("{0:yyyy-MM-dd}", dtdate.Value);
                var lguDetails = Helper.LGUDetails();
                var parameters = new[] {
                            new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                            new ReportParameter("paramDate", String.Format("{0:MMMM dd, yyyy}", dtdate.Value)),
                            new ReportParameter("paramMayor", notedSignatory),
                            new ReportParameter("paramLGUProvince", "BUUG, ZAMBONGA SIBUGAY"),
                            new ReportParameter("paramCertifiedCorrectSignatory", certifiedCorrectSignatory),
                            new ReportParameter("paramCertifiedCorrectSignatoryTitle", certifiedCorrectSignatoryTitle),
                            new ReportParameter("paramPreparedBySignatory", Helper.LoggedInUserData()["user_full_name"]),
                            new ReportParameter("paramPreparedBySignatoryTitle", preparedBySignatoryTitle),
                            new ReportParameter("paramNotedSignatory", notedSignatory),
                            new ReportParameter("paramNotedSignatoryTitle", notedSignatoryTitle)
                    };
                report.ReportPath = $"{Application.StartupPath}Reports\\daily-cash-position-report.rdlc";
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("dtCashreport", DataTableCash("General", date)));
                report.DataSources.Add(new ReportDataSource("dtCashreport1", DataTableCash("Special", date)));
                report.DataSources.Add(new ReportDataSource("dtCashreport2", DataTableCash("Trust", date)));
                report.SetParameters(parameters);
                report.Refresh();

                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;
                reportViewer.RefreshReport();

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }
    }
}