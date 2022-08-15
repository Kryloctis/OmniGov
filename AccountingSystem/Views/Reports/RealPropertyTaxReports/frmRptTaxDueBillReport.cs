using AccountingSystem.Views.Transactions.PaymentPosting;
using AccountingSystem.Views.Transactions.PropertyPayment.Models;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AccountingSystem.Views.Transactions.PaymentPostings.RPT_PaymentPosting.frmPropertyTaxDue;

namespace AccountingSystem.Views.Reports.RealPropertyTaxReports
{
    public partial class frmRptTaxDueBillReport : Form
    {
        private ReportViewer reportViewer;
        private readonly DataTable _dtRPTDueBill;
        private readonly rptPropertyPaymentTaxPayerInfoModel _rptPropertyPaymentTaxPayerInfoModel;

        public frmRptTaxDueBillReport(DataTable dtRPTDueBill, rptPropertyPaymentTaxPayerInfoModel paymentTaxPayerInfoModel)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            reportViewer = new ReportViewer();
            panel1.Controls.Add(reportViewer);
            reportViewer.Dock = DockStyle.Fill;
            _rptPropertyPaymentTaxPayerInfoModel = paymentTaxPayerInfoModel;
            _dtRPTDueBill = dtRPTDueBill;
        }

        private void LoadReport(LocalReport report) 
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var lguDetails = Helper.LGUDetails();
                var dictPenalty = AccFactory.RptPenaltiesRepository().GetRecordByDescription("RPT monthly penalty");
                string penaltyRate = dictPenalty.Values.Count < 1 ? "0" : dictPenalty["rate"];

                var parameters = new[]
                {
                    new ReportParameter("paramMunicipality",  lguDetails["lgu_name"]),
                    new ReportParameter("paramProvince", lguDetails["lgu_province"]),
                    new ReportParameter("paramTaxPayerName", _rptPropertyPaymentTaxPayerInfoModel.TaxPayerName),
                    new ReportParameter("paramAddress", _rptPropertyPaymentTaxPayerInfoModel.Address),
                    new ReportParameter("paramTin", _rptPropertyPaymentTaxPayerInfoModel.TIN),
                    new ReportParameter("paramPreparedBy", Helper.LoggedInUserData()["user_full_name"]), 
                    new ReportParameter("paramCurrentDate", Helper.GetCurrentDate().ToString()),
                    new ReportParameter("paramPenaltyRate", penaltyRate)
                };

                report.ReportPath = $"{Application.StartupPath}\\Reports\\real-property-tax-due-bill.rdlc";
                report.DataSources.Clear();

                report.DataSources.Add(new ReportDataSource("dtRPTDueBill", _dtRPTDueBill));
                report.SetParameters(parameters);

                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.PageWidth;
                reportViewer.ZoomPercent = 100;

                reportViewer.RefreshReport();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.StackTrace);
                Cursor.Current = Cursors.Default;
            }
        }

        private void frmRptTaxDueBillReport_Load(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }
    }
}
