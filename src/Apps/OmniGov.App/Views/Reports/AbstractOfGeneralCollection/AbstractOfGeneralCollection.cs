using Microsoft.Reporting.WinForms;
using OmniGov.App.Helpers;
using OmniGov.Core.Factories;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OmniGov.App.Views.Reports.AbstractOfGeneralCollection
{
    public partial class AbstractOfGeneralCollection : Form
    {
        private readonly ReportViewer reportViewer = new ReportViewer();

        public AbstractOfGeneralCollection()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }

        private void LoadReport(LocalReport report)
        {
            Cursor = Cursors.WaitCursor;

            string collectionFrom = dtpFrom.Value.ToString("yyyy-MM-dd");
            string collectionTo = dtpTo.Value.ToString("yyyy-MM-dd");

            var certifiedCorrectSignatory = string.Empty;
            var certifiedCorrectSignatoryTitle = string.Empty;

            var dictCertifiedCorrect = Factory.SignatoriesHasReferencesRepository().GetSigntryByRefDoc("Certified Correct", "Report of General Collections ");
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

            string lguName = $"{ServerHelper.selectedServer.MunicipalityName} - {ServerHelper.selectedServer.ProvinceName}";

            var parameters = new ReportParameter[]
            {
                new("paramLGUName", lguName),
                new("paramCertifiedCorrectSignatory", certifiedCorrectSignatory),
                new("paramCertifiedCorrectSignatoryTitle", certifiedCorrectSignatoryTitle)
            };

            report.ReportPath = $"{Application.StartupPath}Reports\\abstract-of-general-collection.rdlc";
            report.DataSources.Clear();
            report.SetParameters(parameters);
            report.Refresh();

            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();

            Cursor = Cursors.Default;
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            try
            {
                LoadReport(reportViewer.LocalReport);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}