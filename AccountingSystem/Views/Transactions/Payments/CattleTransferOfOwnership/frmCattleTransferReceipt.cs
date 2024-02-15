using Microsoft.Reporting.WinForms;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.CattleTransferOfOwnership
{
    public partial class frmCattleTransferReceipt : Form
    {
        public frmCattleTransferReceipt()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            reportViewer1.ShowFindControls = false;
            reportViewer1.ShowExportButton = false;
            reportViewer1.ShowPrintButton = false;
            reportViewer1.ShowDocumentMapButton = false;
            reportViewer1.ShowStopButton = false;
            reportViewer1.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer1);
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
                var localReport = reportViewer1.LocalReport;
                localReport.EnableExternalImages = true;

                var reportParameters = new ReportParameter[]
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
                    new ReportParameter("paramCurrentDate", aF52Parameters.CurrentDate.ToString())
                };

                localReport.ReportPath = $"{Application.StartupPath}\\Receipts\\AF52.rdlc";
                localReport.SetParameters(reportParameters);
            });

            reportViewer1.RefreshReport();
            reportViewer1.ZoomPercent = 100;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
        }

        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            try
            {
                reportViewer1.PrintDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}