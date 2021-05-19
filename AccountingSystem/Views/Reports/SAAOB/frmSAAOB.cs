using ACC.Domain.Interfaces;
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

namespace AccountingSystem.Views.Reports.SAAOB
{
    public partial class frmSAAOB : Form
    {

        private readonly ReportViewer reportViewer;

        public frmSAAOB()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel2.Controls.Add(reportViewer);
        }

        private void LoadFunds() 
        {
            try
            {
                var dtFunds = Factory.FundsRepository().GetRecords();

                HelperLoadRecords.FundsComboBox(dtFunds, cmbxFund, "fund_name", "id");

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private DataTable DatatableSAAOB() 
        {

            var dataSet = new dsLFS();
            DataTable dtSAAOB = dataSet.dtSAAOB;

            var dtBudgetAppropriations = Factory.BudgetAppropriationsRepository().GetViewRecords();



            foreach (DataRow item in dtBudgetAppropriations.Rows) 
            {
                var items = new object[]
                {
                     item["funds_id"], item["fund_code"], item["fpp_name"], null, null, null, null, null, item["fpp_id"], item["fpp_code"], item["fpp_name"], item["others_fpp_id"], item["others_fpp_name"], item["allotment_class_id"], item["allotment_class_code"], item["allotment_class_name"], item["account_code"], item["general_ledger_accounts_name"], item["year"], item["amount"], 

                };
                dtSAAOB.Rows.Add(items);
            }

            return dtSAAOB;
        }


        private bool LoadReport(LocalReport report) 
        {
            try
            {
                int fundId = Convert.ToInt32(cmbxFund.SelectedValue);
                DateTime AsOf = dtAsOf.Value;

                //var dtSAAOB = Factory.BudgetAppropriationsRepository().GetViewRecordsSAAOB(fppID, year);

                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;

                var fundRepo = Factory.FundsRepository().GetRecordByID(fundId);

                var parameters = new[] {

                    new ReportParameter("paramFundName", fundRepo["fund_name"]),
                    new ReportParameter("paramFundCode", fundRepo["fund_code"]),
                    new ReportParameter("paramDate", AsOf.ToString("MMM dd, yyyy"))
                };

                report.ReportPath = $"{Application.StartupPath}\\Reports\\status-of-appropriations-allotments-and-obligation.rdlc";
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("dtSAAOB", DatatableSAAOB()));
                report.SetParameters(parameters);

                reportViewer.RefreshReport();

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return true;
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }

        private void frmSAAOB_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            LoadFunds();
        }
    }
}
