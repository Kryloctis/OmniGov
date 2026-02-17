using LFS.Helpers;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LFS.Views.Transactions.Payments.BurialPermit
{
    public partial class ucPrintReceipt : UserControl
    {
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

        private Task LoadReceiptAsync(string reportPath, Dictionary<string, string> dictParameters, ReportDataSource reportDataSource)
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

                if (reportDataSource is not null)
                {
                    localReportReceipt.DataSources.Clear();
                    localReportReceipt.DataSources.Add(reportDataSource);
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

        private async Task MotherTask(string reportPath, Dictionary<string, string> reportParameters, ReportDataSource reportDataSource)
        {
            await LoadReceiptAsync(reportPath, reportParameters, reportDataSource);
            lblStatus.Text = "Receipt is all set!";
            reportViewerPrint.RefreshReport();

            var localReport = reportViewerPrint.LocalReport;
            await PopulatePrinterComboBox(cmbxPrinter, localReport);
        }

        internal async void Onload(string reportPath, Dictionary<string, string> reportParameters, ReportDataSource reportDataSource = null)
        {
            await MotherTask(reportPath, reportParameters, reportDataSource);
        }

        public void PrintReport(ReportViewer reportViewer, string printerName)
        {
            var localReport = reportViewer.LocalReport;
            int dpi = 300;

            // Create a PrintDocument and set the printer name
            using (PrintDocument printDoc = new PrintDocument())
            {
                printDoc.PrinterSettings.PrinterName = printerName;

                // Ensure the printer exists
                if (!printDoc.PrinterSettings.IsValid)
                {
                    throw new Exception($"The printer '{printerName}' is not valid.");
                }

                // Get the report page settings from the LocalReport
                ReportPageSettings reportPageSettings = localReport.GetDefaultPageSettings();

                // Apply these settings to the PrintDocument's DefaultPageSettings
                printDoc.DefaultPageSettings.PaperSize = reportPageSettings.PaperSize;
                printDoc.DefaultPageSettings.Margins = reportPageSettings.Margins;
                printDoc.DefaultPageSettings.Landscape = reportPageSettings.IsLandscape;
                string deviceInfo = $@"
                <DeviceInfo>
                    <OutputFormat>PNG</OutputFormat>
                    <DpiX>{600}</DpiX>
                    <DpiY>{600}</DpiY>
                </DeviceInfo>";

                // Render the report content onto the print page
                byte[] renderedBytes = localReport.Render(
                    format: "Image",
                    deviceInfo,
                    out string mimeType,
                    out string encoding,
                    out string fileNameExtension,
                    out string[] streams,
                    out Warning[] warnings);

                // Use float or double for dimensions with decimals
                float widthInInches = reportPageSettings.PaperSize.Width / 100.0f;
                float heightInInches = reportPageSettings.PaperSize.Height / 100.0f;

                // Convert dimensions to pixels
                int width = (int)(widthInInches * dpi);
                int height = (int)(heightInInches * dpi);
                using (var stream = new MemoryStream(renderedBytes))
                {
                    using (Bitmap bitmap = new Bitmap(width, height))
                    {
                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            graphics.DrawImage(Image.FromStream(stream), 0, 0, width, height);

                            // Flip the image upside down
                            bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        }

                        // Handle the PrintPage event to print the image
                        printDoc.PrintPage += (sender, e) =>
                        {
                            // Draw the image on the page
                            e.Graphics.DrawImage(bitmap, e.PageBounds);
                        };
                        printDoc.Print();
                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string printerName = cmbxPrinter.Text;
            PrintReport(reportViewerPrint, printerName);
            try
            {
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.StackTrace); }
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
