using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.GeneralCollection
{
    public partial class AbstractOfGeneralCollection : Form
    {
        private readonly ReportViewer reportViewer = new ReportViewer();

        public AbstractOfGeneralCollection()
        {
            InitializeComponent();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
            Helper.LoadFormIcon(this);
        }

        private DataTable DataTableAbstractOfGeneralCollection(string from, string to)
        {

            var dtPC = new dsLFS.dtPCDataTable();
            var dt = Factory.GeneralCollectionsRepository().GetRecordByGC(from, to);


            foreach (DataRow item in dt.Rows)
            {
                DataRow row = dtPC.NewRow();
                row["rcdid"] = item["id"];
                row["rcdno"] = item["rcd_no"];
                row["reportno"] = item["report_no"];
                row["account_code"] = item["account_code"];
                row["subsidiary"] = item["subsidiary"];
                row["payee"] = item["payee"];
                row["acc_form_desc"] = item["accform"];
                row["ledger_name"] = item["ledger_name"];
                row["payment_date"] = item["payment_date"];
                row["receipt_no"] = item["receipt_no"];
                row["amount"] = item["amount"];
                row["collector"] = item["collector"];
                dtPC.Rows.Add(row);
            }

            return dtPC;
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                string from = String.Format("{0:yyyy-MM-dd}", dtpMonth.Value);
                string to = String.Format("{0:yyyy-MM-dd}", dtto.Value);

                var lguDetails = Helper.LGUDetails();
                var certifiedCorrectSignatory = string.Empty;
                var certifiedCorrectSignatoryTitle = string.Empty;

                var dictCertifiedCorrect = Factory.SignatoriesHasReferencesRepository().GetSignatoryBy_Reference_DocumentName("Certified Correct", "Report of General Collections ");
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


                var parameters = new[]
                    {
                            new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                            new ReportParameter("paramCertifiedCorrectSignatory", certifiedCorrectSignatory),
                            new ReportParameter("paramCertifiedCorrectSignatoryTitle", certifiedCorrectSignatoryTitle)
                    };
                report.ReportPath = $"{Application.StartupPath}Reports\\abstract-of-general-collection.rdlc";
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("dtPC", DataTableAbstractOfGeneralCollection(from, to)));
                report.SetParameters(parameters);
                report.Refresh();

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }
    }
}
