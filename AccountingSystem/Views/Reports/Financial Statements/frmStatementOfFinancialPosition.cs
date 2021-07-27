using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Financial_Statements
{
    public partial class frmStatementOfFinancialPosition : Form
    {
        private readonly ReportViewer reportViewer;

        public frmStatementOfFinancialPosition()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
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

        private DataTable StatementOfFinancialPositionReport()
        {
            var dataSet = new dsLFS();
            var dtStatementOfFinancialPosition = dataSet.dtStatementOfFinancialPosition;
            int fundId = (int)cmbxFunds.SelectedValue;
            var dtAccountGroup = Factory.AccountGroupRepository().GetRecords();
            try
            {
                foreach (DataRow row in dtAccountGroup.Rows)
                {
                    if (Convert.ToInt32(row["id"]) == 1 || Convert.ToInt32(row["id"]) == 2)
                    {

                    }
                    else
                    {

                    }
                }
                var items = new object[]
                {

                };
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return null;
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
                DateTime AsOf = dtAsOf.Value;

                var fundRepo = Factory.FundsRepository().GetRecordByID(fundId);
                var parameters = new[] {
                    new ReportParameter("paramFundName", fundRepo["fund_name"]),
                    new ReportParameter("paramDate", AsOf.ToString("MMMM dd, yyyy")),
                };
                report.ReportPath = $"{Application.StartupPath}\\Reports\\statement-of-financial-position-report.rdlc";
                report.SetParameters(parameters);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.StackTrace);
            }
        }

        private void frmStatementOfFinancialPosition_Load(object sender, System.EventArgs e)
        {
            LoadFunds();
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }
    }
}
