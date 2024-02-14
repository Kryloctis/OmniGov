using Microsoft.Reporting.WinForms;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AccountingSystem.Views.Transactions.Payments.BurialPermit.frmBurialPermitReceipt;

namespace AccountingSystem.Views.Transactions.Payments.MarriageLicense
{
    public partial class frmMarriageLicenseReceipt : Form
    {
        public frmMarriageLicenseReceipt()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            panel1.Controls.Add(reportViewer1);
            reportViewer1.Dock = DockStyle.Fill;
            reportViewer1.ZoomPercent = 100;
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ShowPrintButton = false;
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
        }

        internal async void OnLoad(AF54Parameters AF54Parameters)
        {
            await LoadReceiptAsync(AF54Parameters);
        }

        private async Task LoadReceiptAsync(AF54Parameters parameters)
        {
            await Task.Run(() =>
            {
                var localReport = reportViewer1.LocalReport;
                localReport.EnableExternalImages = true;

                var reportParameters = new ReportParameter[]
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
                    new ReportParameter("paramGroomResidence", parameters.GroomResidence)
                };

                localReport.ReportPath = $"{Application.StartupPath}\\Receipts\\AF54.rdlc";
                localReport.SetParameters(reportParameters);
            });

            reportViewer1.RefreshReport();
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