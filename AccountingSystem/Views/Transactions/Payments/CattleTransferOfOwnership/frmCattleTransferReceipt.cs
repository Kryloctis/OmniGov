using AccountingSystem.Properties;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.CattleTransferOfOwnership
{
    public partial class frmCattleTransferReceipt : Form
    {
        private ReportViewer reportViewerPrint;

        public frmCattleTransferReceipt()
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

            reportViewerPrint = new ReportViewer();
            reportViewerPrint.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewerPrint);
        }

        internal class AF52Parameters
        {
            internal string Province { get; set; }
            internal string Municipality { get; set; }
            internal DateTime TransactionDate { get; set; }
            internal string OldOwnerName { get; set; }
            internal string OldOwnerAddress { get; set; }
            internal string OldOwnerMunicipality { get; set; }
            internal string OldOwnerProvince { get; set; }
            internal string NewOwnerName { get; set; }
            internal string NewOwnerAddress { get; set; }
            internal string NewOwnerMunicipality { get; set; }
            internal string NewOwnerProvince { get; set; }
            internal string CattleName { get; set; }
            internal decimal CattlePrice { get; set; }
            internal string CattlePriceWords { get; set; }
            internal string CattleSex { get; set; }
            internal int CattleAge { get; set; }
            internal int CattleYears { get; set; }
            internal string MunicipalSecretaryName { get; set; }
            internal string MunicipalMayor { get; set; }
            internal DateTime CurrentDate { get; set; }
        }

        internal async void OnLoad(AF52Parameters aF52Parameters)
        {
            await LoadReceiptAsync(aF52Parameters);
        }

        private async Task LoadReceiptAsync(AF52Parameters aF52Parameters)
        {
            await Task.Run(() =>
            {
                var localReportPreview = reportViewerPreview.LocalReport;
                var localReportPrint = reportViewerPrint.LocalReport;

                localReportPreview.EnableExternalImages = true;
                var backgroundImage = new Bitmap(Resources.AF52);

                var reportParameters = new List<ReportParameter>
                {
                    new ReportParameter("paramMunicipal", aF52Parameters.Municipality),
                    new ReportParameter("paramProvince", aF52Parameters.Province),
                    new ReportParameter("paramTransactionDate", aF52Parameters.TransactionDate.ToString()),
                    new ReportParameter("paramOldOwnerName", aF52Parameters.OldOwnerName),
                    new ReportParameter("paramOldOwnerAddress", aF52Parameters.OldOwnerAddress),
                    new ReportParameter("paramOldOwnerMunicipality", aF52Parameters.OldOwnerMunicipality),
                    new ReportParameter("paramOldOwnerProvince", aF52Parameters.OldOwnerProvince),
                    new ReportParameter("paramNewOwnerName", aF52Parameters.NewOwnerName),
                    new ReportParameter("paramNewOwnerAddress", aF52Parameters.NewOwnerAddress),
                    new ReportParameter("paramNewOwnerMunicipality", aF52Parameters.NewOwnerMunicipality),
                    new ReportParameter("paramNewOwnerProvince", aF52Parameters.NewOwnerProvince),
                    new ReportParameter("paramCattlePrice", aF52Parameters.CattlePrice.ToString()),
                    new ReportParameter("paramCattlePriceWords", aF52Parameters.CattlePriceWords),
                    new ReportParameter("paramCattleName", aF52Parameters.CattleName),
                    new ReportParameter("paramCattleSex", aF52Parameters.CattleSex),
                    new ReportParameter("paramCattleAge", aF52Parameters.CattleAge.ToString()),
                    new ReportParameter("paramCattleYears", aF52Parameters.CattleYears.ToString()),
                    new ReportParameter("paramMunicipalMayorName", aF52Parameters.MunicipalMayor),
                    new ReportParameter("paramMunicipalSecretaryName", aF52Parameters.MunicipalSecretaryName),
                    new ReportParameter("paramCurrentDate", aF52Parameters.CurrentDate.ToString()),
                    new ReportParameter("paramBackground", Convert.ToBase64String(Helper.ImageToByteArray(backgroundImage)))
                };

                localReportPreview.ReportPath = $"{Application.StartupPath}\\Receipts\\AF52.rdlc";
                localReportPreview.SetParameters(reportParameters);

                localReportPrint.ReportPath = $"{Application.StartupPath}\\Receipts\\AF52.rdlc";
                reportParameters.RemoveAll(param => param.Name == "paramBackground");
                localReportPrint.SetParameters(reportParameters);
            });

            reportViewerPreview.RefreshReport();
            reportViewerPreview.ZoomPercent = 100;
            reportViewerPreview.SetDisplayMode(DisplayMode.PrintLayout);

            reportViewerPrint.RefreshReport();
            reportViewerPrint.ZoomPercent = 100;
            reportViewerPrint.SetDisplayMode(DisplayMode.PrintLayout);
        }

        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            try
            {
                reportViewerPrint.PrintDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}