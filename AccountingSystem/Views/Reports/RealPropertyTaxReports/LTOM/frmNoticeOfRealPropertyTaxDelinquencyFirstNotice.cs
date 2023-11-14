using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RealPropertyTaxReports.LTOM
{
    public partial class frmNoticeOfRealPropertyTaxDelinquencyFirstNotice : Form
    {


        private readonly ReportViewer reportViewer;
        private DataTable dataTable;

        public frmNoticeOfRealPropertyTaxDelinquencyFirstNotice()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            reportViewer = new ReportViewer();
            panel2.Controls.Add(reportViewer);
            reportViewer.Dock = DockStyle.Fill;
        }

        private void btnRetrieve_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!backgroundWorker1.IsBusy)
                {
                    pbLoadRecords.Value = 0;
                    backgroundWorker1.RunWorkerAsync();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ParseSignatory(Dictionary<string, string> dictSignatory, ref string signatoryName, ref string signatoryTitle)
        {
            if (dictSignatory.Count > 0)
            {
                signatoryName = dictSignatory["signatories_full_name"];
                signatoryTitle = dictSignatory["signatories_title"];
            }
        }

        private bool LoadReport(LocalReport localReport)
        {
            try
            {
                string lguName = Helper.LGUDetails()["lgu_name"];
                var dictSignatory = Helper.GetSignatoryDataBy_Reference_DocumentName("Treasurer", "Notice of Delinquency in the Payment of Real Property Tax");

                string signatoryName = string.Empty;
                string signatoryTitle = string.Empty;
                ParseSignatory(dictSignatory, ref signatoryName, ref signatoryTitle);

                var reportParameters = new ReportParameter[]
                {
                    new ReportParameter("paramLGU", lguName),
                    new ReportParameter("paramSignatory", signatoryName),
                    new ReportParameter("paramSignatoryTitle", signatoryTitle)
                };

                localReport.ReportPath = $"{Application.StartupPath}\\Reports\\LTOMs\\ltom-17-notice-of-real-property-tax-delinquency-first-notice.rdlc";
                localReport.SetParameters(reportParameters);

                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("dsNoticeOfRealPropertyTaxDelinquencyFirstNotice", dataTable));

                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;
                reportViewer.RefreshReport();


                return true;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.StackTrace);
            }
            return false;
        }

        private void LoadReports()
        {
            try
            {
                dataTable = new dsLTOM.dtNoticeOfRealPropertyTaxDelinquencyFirstNoticeDataTable();


                var newRow = dataTable.NewRow();


                newRow["tax_year"] = 2023;
                newRow["basic_tax"] = 12512;
                newRow["basic_penalty"] = 125;
                newRow["sef_tax"] = 123631261;
                newRow["sef_penalty"] = 12351;
                newRow["total_amount"] = 9125214;


                dataTable.Rows.Add(newRow);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                LoadReports();
            });
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }
    }
}
