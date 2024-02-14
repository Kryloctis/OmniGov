using Microsoft.Reporting.WinForms;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Payments.BurialPermit
{
    public partial class frmBurialPermitReceipt : Form
    {
        public frmBurialPermitReceipt()
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

        internal class AF58Parameters
        {
            internal string Municipality { get; set; }
            internal DateTime TransactionDate { get; set; }
            internal string RemainName { get; set; }
            internal string RemainSex { get; set; }
            internal string RemainNationality { get; set; }
            internal int RemainAge { get; set; }
            internal DateTime DeathDate { get; set; }
            internal string CauseOfDeath { get; set; }
            internal string Cemetery { get; set; }
            internal string Disinterment { get; set; }
            internal bool IsInfectious { get; set; }
            internal bool IsEmbalmed { get; set; }
            internal string Disposition { get; set; }
            internal bool IsInter { get; set; }
            internal bool IsDisinter { get; set; }
            internal bool IsRemove { get; set; }
            internal decimal TotalPayment { get; set; }
            internal string MunicipalFeeNo { get; set; }
            internal string MunicipalFeeDate { get; set; }
            internal string MunicipalFeeAmount { get; set; }
            internal string CollectingOfficerName { get; set; }
        }

        private async Task LoadReceiptAsync(AF58Parameters parameters)
        {
            await Task.Run(() =>
            {
                var localReport = reportViewer1.LocalReport;
                localReport.EnableExternalImages = true;
                string isInfectious = parameters.IsInfectious ? "Infectious" : "Non-Infectious";
                string isEmbalmed = parameters.IsEmbalmed ? "Embalmed" : "None";

                var reportParameters = new ReportParameter[]
                {
                    new ReportParameter("paramMunicipality", parameters.Municipality),
                    new ReportParameter("paramTransactionDate", parameters.TransactionDate.ToString()),
                    new ReportParameter("paramRemainName", parameters.RemainName),
                    new ReportParameter("paramRemainSex", parameters.RemainSex),
                    new ReportParameter("paramRemainNationality", parameters.RemainNationality),
                    new ReportParameter("paramRemainAge", parameters.RemainAge.ToString()),
                    new ReportParameter("paramRemainDeathDate", parameters.DeathDate.ToString()),
                    new ReportParameter("paramCauseOfDeath", parameters.CauseOfDeath.ToString()),
                    new ReportParameter("paramCemetery", parameters.Cemetery),
                    new ReportParameter("paramDisinterment", parameters.Disinterment),
                    new ReportParameter("paramIsInfectious", isInfectious),
                    new ReportParameter("paramIsEmbalmed", isEmbalmed),
                    new ReportParameter("paramDisposition", parameters.Disposition),
                    new ReportParameter("paramIsInter", parameters.IsInter.ToString()),
                    new ReportParameter("paramIsDisinter", parameters.IsDisinter.ToString()),
                    new ReportParameter("paramIsRemove", parameters.IsRemove.ToString()),
                    new ReportParameter("paramTotalPayment", parameters.TotalPayment.ToString()),
                    new ReportParameter("paramMunicipalFeeNo", parameters.MunicipalFeeNo),
                    new ReportParameter("paramMunicipalFeeDate", parameters.MunicipalFeeDate),
                    new ReportParameter("paramMunicipalFeeAmount", parameters.MunicipalFeeAmount),
                    new ReportParameter("paramCollectingOfficerName", parameters.CollectingOfficerName)
                };

                localReport.ReportPath = $"{Application.StartupPath}\\Receipts\\AF58.rdlc";
                localReport.SetParameters(reportParameters);
            });

            reportViewer1.RefreshReport();
            reportViewer1.ZoomPercent = 100;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
        }

        internal async void OnLoad(AF58Parameters parameters)
        {
            await LoadReceiptAsync(parameters);
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