using AccountingSystem.Properties;
using DocumentFormat.OpenXml.Wordprocessing;
using Google.Protobuf.WellKnownTypes;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.Reporting.WinForms;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.BurialPermit
{
    public partial class ucPrintReceipt : UserControl
    {
        private LocalReport LocalReport;

        public ucPrintReceipt()
        {
            InitializeComponent();
            reportViewerPrint.Dock = DockStyle.Fill;
            reportViewerPrint.ZoomMode = ZoomMode.FullPage;
            reportViewerPrint.SetDisplayMode(DisplayMode.PrintLayout);
            panel1.Controls.Add(reportViewerPrint);
            reportViewerPrint.Visible = false;
        }

        private Task PopulatePrinterComboBox(ComboBox comboBox, LocalReport localReport)
        {
            comboBox.DataSource = null;
            TogglePrintComponents(false, "Searching for valid Printer/s...");

            return Task.Run(() =>
            {
                var localReportSize = localReport.GetDefaultPageSettings().PaperSize;
                var printers = PrinterSettings.InstalledPrinters.Cast<string>()
                 .Where(printerName =>
                 {
                     var printerSettings = new PrinterSettings { PrinterName = printerName };

                     if (!printerSettings.IsValid)
                         return false;

                     return printerSettings.PaperSizes.Cast<PaperSize>().Any(paperSize =>
                         paperSize.Width == localReportSize.Width && paperSize.Height == localReportSize.Height);
                 })
                 .ToList();

                Invoke(new MethodInvoker(() =>
                {
                    comboBox.DataSource = printers;
                    bool hasPrinter = cmbxPrinter.Items.Count > 0;
                    var message = !hasPrinter
                       ? "No valid printers found..."
                       : $"You are all set!\nFound {cmbxPrinter.Items.Count} valid printer/s";
                    TogglePrintComponents(true, message);
                }));
            });
        }

        private Task LoadReceiptAsync(string reportPath, Dictionary<string, string> dictParameters)
        {
            TogglePrintComponents(false, "Preparing...");

            return Task.Run(() =>
            {
                var localReportReceipt = reportViewerPrint.LocalReport;
                var reportParameters = new List<ReportParameter>();
                foreach (var item in dictParameters)
                {
                    var reportParameter = new ReportParameter(item.Key, item.Value);
                    reportParameters.Add(reportParameter);
                }

                localReportReceipt.ReportPath = reportPath;
                localReportReceipt.SetParameters(reportParameters);
            });
        }

        private void TogglePrintComponents(bool isTrue, string status)
        {
            lblStatus.Text = status;
            btnPrintReceipt.Enabled = isTrue;
            cmbxPrinter.Enabled = isTrue;
        }

        private async Task MotherTask(string reportPath, Dictionary<string, string> reportParameters)
        {
            await LoadReceiptAsync(reportPath, reportParameters);
            lblStatus.Text = "Receipt is all set!";
            reportViewerPrint.RefreshReport();

            var localReport = reportViewerPrint.LocalReport;
            await PopulatePrinterComboBox(cmbxPrinter, localReport);
        }

        internal async void Onload(string reportPath, Dictionary<string, string> reportParameters)
        {
            await MotherTask(reportPath, reportParameters);
        }

        public static void PrintReport(ReportViewer reportViewer, string printerName)
        {
            // Create a PrintDocument and set the printer name
            PrintDocument printDoc = new PrintDocument
            {
                PrinterSettings = { PrinterName = printerName }
            };

            // Ensure the printer exists
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception($"The printer '{printerName}' is not valid.");
            }

            // Get the report page settings from the LocalReport
            ReportPageSettings reportPageSettings = reportViewer.LocalReport.GetDefaultPageSettings();

            // Apply these settings to the PrintDocument's DefaultPageSettings
            printDoc.DefaultPageSettings.PaperSize = reportPageSettings.PaperSize;
            printDoc.DefaultPageSettings.Margins = reportPageSettings.Margins;
            printDoc.DefaultPageSettings.Landscape = reportPageSettings.IsLandscape;

            // Set the PrintPage event handler
            printDoc.PrintPage += (sender, e) =>
            {
                // Render the report content onto the print page
                byte[] bytes = reportViewer.LocalReport.Render(
                    format: "Image",
                    deviceInfo: "<DeviceInfo><OutputFormat>EMF</OutputFormat></DeviceInfo>",
                    out string mimeType,
                    out string encoding,
                    out string fileNameExtension,
                    out string[] streams,
                    out Warning[] warnings);

                // Load the image into a Metafile and draw it
                using (var stream = new MemoryStream(bytes))
                using (var metafile = new System.Drawing.Imaging.Metafile(stream))
                {
                    e.Graphics.DrawImage(metafile, e.PageBounds);
                }
            };

            printDoc.Print();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string printerName = cmbxPrinter.Text;
                PrintReport(reportViewerPrint, printerName);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private async void lnkLblRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                var localReport = reportViewerPrint.LocalReport;
                await PopulatePrinterComboBox(cmbxPrinter, localReport);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}