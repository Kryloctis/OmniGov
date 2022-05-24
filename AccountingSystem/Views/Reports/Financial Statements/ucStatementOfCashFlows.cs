using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Financial_Statements
{
    public partial class ucStatementOfCashFlows : UserControl
    {
        private readonly ReportViewer reportViewer;

        public ucStatementOfCashFlows()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }

        private DataTable SCFDatatable()
        {
            var dataTable = new dsLFS.dtStatementOfCashFlowsDataTable();

            var records = new object[]
            {
                1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27
            };


            dataTable.Rows.Add(records);

            return dataTable;
        }

        private void ParseSignatory(Dictionary<string, string> dictSignatory, ref string signatoryName, ref string signatoryTitle)
        {
            if (dictSignatory.Count > 0)
            {
                signatoryName = dictSignatory["signatories_full_name"];
                signatoryTitle = dictSignatory["signatories_title"];
            }
        }

        private void LoadReport(LocalReport localReport)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var dictSignatory = Helper.GetSignatoryDataBy_Reference_DocumentName("Certified Correct", "Statement of Cash Flows");
                string certifiedCorrectSignatory = string.Empty;
                string certifiedCorrectSignatoryTitle = string.Empty;
                ParseSignatory(dictSignatory, ref certifiedCorrectSignatory, ref certifiedCorrectSignatoryTitle);

                int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
                DateTime date = dtPickerDate.Value;

                localReport.ReportPath = $"{Application.StartupPath}\\Reports\\statement_of_cash_flows.rdlc";
                localReport.DataSources.Clear();
                localReport.DataSources.Add(new ReportDataSource("dtStatementOfCashFlows", SCFDatatable()));

                var dictFund = Factory.FundsRepository().GetRecordByID(fundId);
                var parameters = new[] {
                    new ReportParameter("paramCertifiedCorrectSignatory", ""),
                    new ReportParameter("paramCertifiedCorrectSignatoryTitle", ""),
                    new ReportParameter("paramFund", dictFund["fund_name"]),
                    new ReportParameter("paramDate", date.ToString("MMMM dd, yyyy")),
                };

                localReport.SetParameters(parameters);

                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;
                reportViewer.RefreshReport();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadFunds()
        {
            try
            {
                var dtFunds = Factory.FundsRepository().GetRecords();

                HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "fund_name", "id");

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void ucStatementOfCashFlows_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadFunds();
            }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }
    }
}
