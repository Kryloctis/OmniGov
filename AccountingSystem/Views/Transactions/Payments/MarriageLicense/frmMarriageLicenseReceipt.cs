using AccountingSystem.Properties;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.MarriageLicense
{
    public partial class frmMarriageLicenseReceipt : Form
    {
        private ReportViewer reportViewerReceipt;

        public frmMarriageLicenseReceipt()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            reportViewerPreview.ShowFindControls = false;
            reportViewerPreview.ShowExportButton = false;
            reportViewerPreview.ShowPrintButton = false;
            reportViewerPreview.ShowDocumentMapButton = false;
            reportViewerPreview.ShowStopButton = false;
            reportViewerPreview.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewerPreview);

            reportViewerReceipt = new ReportViewer();
            reportViewerReceipt.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewerReceipt);
        }

        internal class AF54Parameters
        {
            internal string Municipality { get; set; }
            internal string Province { get; set; }
            internal string GroomName { get; set; }
            internal string GroomAge { get; set; }
            internal string GroomMonths { get; set; }
            internal string BrideName { get; set; }
            internal string BrideAge { get; set; }
            internal string BrideMonths { get; set; }
            internal DateTime DateIssued { get; set; }
            internal string RegistryNo { get; set; }
            internal string GroomResidence { get; set; }
            internal string BrideResidence { get; set; }
        }

        internal async void OnLoad(AF54Parameters AF54Parameters)
        {
            await LoadReceiptAsync(AF54Parameters);
        }

        private async Task LoadReceiptAsync(AF54Parameters parameters)
        {
            await Task.Run(() =>
            {
                var localReportPreview = reportViewerPreview.LocalReport;
                var localReportReceipt = reportViewerReceipt.LocalReport;
                localReportPreview.EnableExternalImages = true;
                var backgroundImage = new Bitmap(Resources.AF54);

                var reportParameters = new List<ReportParameter>
                {
                    new ReportParameter("paramMunicipality", parameters.Municipality),
                    new ReportParameter("paramProvince", parameters.Province),
                    new ReportParameter("paramGroomName", parameters.GroomName),
                    new ReportParameter("paramGroomAge", parameters.GroomAge),
                    new ReportParameter("paramGroomMonths", parameters.GroomMonths),
                    new ReportParameter("paramBrideName", parameters.BrideName),
                    new ReportParameter("paramBrideAge", parameters.BrideAge),
                    new ReportParameter("paramBrideMonths", parameters.BrideMonths),
                    new ReportParameter("paramDateIssued", parameters.DateIssued.ToString()),
                    new ReportParameter("paramRegistryNo", parameters.RegistryNo),
                    new ReportParameter("paramGroomResidence", parameters.GroomResidence),
                    new ReportParameter("paramBrideResidence", parameters.BrideResidence),
                    new ReportParameter("paramBackground", Convert.ToBase64String(Helper.ImageToByteArray(backgroundImage)))
                };

                localReportPreview.ReportPath = $"{Application.StartupPath}\\Receipts\\AF54.rdlc";
                localReportPreview.SetParameters(reportParameters);

                localReportReceipt.ReportPath = $"{Application.StartupPath}\\Receipts\\AF54.rdlc";
                reportParameters.RemoveAll(param => param.Name == "paramBackground");
                localReportReceipt.SetParameters(reportParameters);
            });

            reportViewerPreview.RefreshReport();
            reportViewerPreview.ZoomPercent = 100;
            reportViewerPreview.SetDisplayMode(DisplayMode.PrintLayout);

            reportViewerReceipt.RefreshReport();
            reportViewerReceipt.ZoomPercent = 100;
            reportViewerReceipt.SetDisplayMode(DisplayMode.PrintLayout);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                reportViewerReceipt.PrintDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}