using Microsoft.Reporting.WinForms;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AccountingSystem.Views.Transactions.Payments.MarriageLicense.frmMarriageLicenseReceipt;

namespace AccountingSystem.Views.Transactions.Payments.CattleOwnership
{
    public partial class frmCattleOwnershipReceipt : Form
    {
        public frmCattleOwnershipReceipt()
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

        internal class AF53Parameters
        {
            internal string Municipality { get; set; }
            internal string Province { get; set; }
            internal DateTime TransactionDate { get; set; }
            internal string OwnerName { get; set; }
            internal string OwnerMunicipality { get; set; }
            internal string OwnerProvince { get; set; }
            internal string CattleName { get; set; }
            internal string CattleSex { get; set; }
            internal int CattleAge { get; set; }
            internal string MunicipalTreasurerName { get; set; }
            internal string MunicipalSecretaryName { get; set; }
            internal string MunicipalMayor { get; set; }
        }

        internal async void OnLoad(AF53Parameters aF53Parameters)
        {
            await LoadReceiptAsync(aF53Parameters);
        }

        private async Task LoadReceiptAsync(AF53Parameters aF53Parameters)
        {
            await Task.Run(() =>
            {
                var localReport = reportViewer1.LocalReport;
                localReport.EnableExternalImages = true;

                var reportParameters = new ReportParameter[]
                {
                        new ReportParameter("paramMunicipality", aF53Parameters.Municipality),
                        new ReportParameter("paramProvince", aF53Parameters.Province),
                        new ReportParameter("paramTransactionDate", aF53Parameters.TransactionDate.ToString()),
                        new ReportParameter("paramOwnerName", aF53Parameters.OwnerName),
                        new ReportParameter("paramOwnerMunicipality", aF53Parameters.OwnerMunicipality),
                        new ReportParameter("paramOwnerProvince", aF53Parameters.OwnerProvince),
                        new ReportParameter("paramCattleName", aF53Parameters.CattleName),
                        new ReportParameter("paramCattleSex", aF53Parameters.CattleSex),
                        new ReportParameter("paramCattleAge", aF53Parameters.CattleAge.ToString()),
                        new ReportParameter("paramMunicipalTreasurerName", aF53Parameters.MunicipalTreasurerName),
                        new ReportParameter("paramMunicipalSecretaryName", aF53Parameters.MunicipalSecretaryName),
                        new ReportParameter("paramMunicipalMayor", aF53Parameters.MunicipalMayor)
                };

                localReport.ReportPath = $"{Application.StartupPath}\\Receipts\\AF53.rdlc";
                localReport.SetParameters(reportParameters);
            });

            reportViewer1.RefreshReport();
            reportViewer1.ZoomPercent = 100;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.PrintDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}