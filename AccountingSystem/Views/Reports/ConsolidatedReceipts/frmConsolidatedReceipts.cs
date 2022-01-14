using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.ConsolidatedReceipts
{
    public partial class frmConsolidatedReceipts : Form
    {
        private readonly ReportViewer reportViewer = new ReportViewer();
        public frmConsolidatedReceipts()
        {
            InitializeComponent();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
            Helper.LoadFormIcon(this);
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }

        private void frmConsolidatedReceipts_Load(object sender, EventArgs e)
        {

        }

        private DataTable DataTableReceipts(string date)
        {

            var dtRC = new dsLFS.dtReceiptsConsolidatedDataTable();
            var dt = Factory.GeneralCollectionsRepository().GetRecordByReceiptsConsolidated(date);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DataRow row = dtRC.NewRow();
                    row["form"] = item["form"];
                    row["receiptfrom"] = item["receiptsfrom"];
                    row["receiptto"] = item["receiptsto"];
                    row["issuefrom"] = item["issuefrom"];
                    row["issueto"] = item["issueto"];
                    row["usedfrom"] = item["ifrom"];
                    row["usedto"] = item["ito"];
                    row["officers"] = item["officers"];
                    dtRC.Rows.Add(row);
                }
            }

            return dtRC;
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                var lguDetails = Helper.LGUDetails();
                var date = String.Format("{0:yyyy-MM-dd}", dtto.Value);

                string certifiedCorrectSignatory = string.Empty;
                string certifiedCorrectSignatoryTitle = string.Empty;
                string treasurer = string.Empty;
                string treasurerTitle = string.Empty;

                var dictCertifiedCorrect = Factory.SignatoriesHasReferencesRepository().GetSignatoryByReferenceAndDocumentName("Certified Correct", "Consolidated Report of Accountability for Accountable Forms");

                var dictTreasurer = Factory.SignatoriesHasReferencesRepository().GetSignatoryByReferenceAndDocumentName("Treasurer", "Consolidated Report of Accountability for Accountable Forms");

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

                ParseSignatory(dictCertifiedCorrect, ref certifiedCorrectSignatory, ref certifiedCorrectSignatoryTitle);
                ParseSignatory(dictTreasurer, ref treasurer, ref treasurerTitle);

                var parameters = new[] {
                            new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                            new ReportParameter("paramCertifiedCorrectSignatory", certifiedCorrectSignatory),
                            new ReportParameter("paramCertifiedCorrectSignatoryTitle", certifiedCorrectSignatoryTitle),
                            new ReportParameter("paramTreasurer", treasurer),
                            new ReportParameter("paramPreparedBySignatory", "sample"),
                            new ReportParameter("paramPreparedBySignatoryTitle", "sample")
                    };
                report.ReportPath = $"{Application.StartupPath}Reports\\consolidated-receipts.rdlc";
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("dtReceiptsConsolidated", DataTableReceipts(date)));

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
                Helper.MessageBoxError(ex.StackTrace);
            }

        }
    }
}
