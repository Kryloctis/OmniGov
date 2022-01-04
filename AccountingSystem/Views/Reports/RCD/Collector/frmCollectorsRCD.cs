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

namespace AccountingSystem.Views.Reports.PaymentCollection
{
    public partial class frmCollectorsRCD : Form
    {
        private readonly ReportViewer reportViewer = new();
        private readonly string _reportNumber;
        public frmCollectorsRCD(string reportNumber)
        {
            InitializeComponent();

            reportViewer.Dock = DockStyle.Fill;
            panelReport.Controls.Add(reportViewer);
            Helper.LoadFormIcon(this);

            _reportNumber = reportNumber;
        }

        private void frmCDReport_Load(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                string accountableOfficer = "ARCHIE S. SALE";
                string treasurer = "ENSIGN S. UBA";
                var totalCashAmount = 5000;
                var totalChecksAmount = 5000;
                var totamAmount = 5000;
                var lguDetails = Helper.LGUDetails();

                var parameters = new[]
                {
                    new ReportParameter("paramLGUName", value:lguDetails["lgu_name"]),
                    new ReportParameter("paramAccountableOfficer", value:accountableOfficer),
                    new ReportParameter("paramTreasurer", value:treasurer),
                    new ReportParameter("paramSummaryDate", DateTime.Now.ToString()),
                    new ReportParameter("paramDate", DateTime.Now.ToString()),
                    new ReportParameter("paramTotalCash", value:totalCashAmount.ToString()),
                    new ReportParameter("paramTotalCheck", value:totalChecksAmount.ToString()),
                    new ReportParameter("paramTotal", value:totamAmount.ToString())
                };

                report.ReportPath = $"{Application.StartupPath}Reports\\rcd.rdlc";
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("dtRCDDetails", ReportDetails()));
                report.DataSources.Add(new ReportDataSource("dtCollections", CollectionDetails()));
                report.DataSources.Add(new ReportDataSource("dtCollectorsReports", CollectorsReports()));
                report.DataSources.Add(new ReportDataSource("dtRemittanceDeposits", RemittanceAndDeposits()));
                report.DataSources.Add(new ReportDataSource("dtAccountabilityForAccountableForms", AccountabilityForAccountableForms()));

                report.SetParameters(parameters);
                report.Refresh();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private DataTable AccountabilityForAccountableForms()
        {
            DataTable dtFromDataSource = new dsLFS.dtAccountabilityForAccountableFormsDataTable();
            DataTable dt = Factory.ReceiptsIssuedRepository().GetAccountabilityForAccountableForms();

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DataRow row = dtFromDataSource.NewRow();
                    row["accountable_form"] = item["accountable_forms"];
                    row["beginning_bal_quantity"] = item["quantity"];
                    row["beginning_bal_serial_from"] = item["serial_no_from"];
                    row["beginning_bal_serial_to"] = item["serial_no_to"];
                    row["issue_quantity"] = item["issue_quantity"];
                    row["issue_serial_from"] = item["issuefrom"];
                    row["issue_serial_to"] = item["issueto"];
                    row["ending_bal_quantity"] = item["ending_balance_quantity"];
                    row["ending_bal_serial_from"] = item["ending_balance_serial_from"];
                    row["ending_bal_serial_to"] = item["ending_balance_serial_to"];
                    dtFromDataSource.Rows.Add(row);
                }
            }

            return dtFromDataSource;
        }
        private DataTable RemittanceAndDeposits()
        {
            DataTable dtFromDataSource = new dsLFS.dtRemittanceDepositsDataTable();
            DataTable dt = Factory.GeneralCollectionsDepositsRepository().GetCollectionsDepositsByRCDNo(_reportNumber);
            //DataTable dt = Factory.GeneralCollectionsRepository().GetRecordsByRCDNo(_reportNumber);
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DataRow row = dtFromDataSource.NewRow();
                    row["bankname"] = item["bank_name"];
                    row["reference"] = item["rcd_no"];
                    row["amount"] = item["amount"];
                    dtFromDataSource.Rows.Add(row);
                }
            }
                
            return dtFromDataSource;
        }
        private DataTable CollectorsReports()
        {
            DataTable dtFromDataSource = new dsLFS.dtCollectorsReportsDataTable();
            DataTable dt = Factory.CollectorReportRepository().GetCollectorsReportByReportNo(_reportNumber);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DataRow row = dtFromDataSource.NewRow();
                    row["name_of_accountable_officer"] = item["collecting_officer"];
                    row["report_no"] = item["report_no"];
                    row["amount"] = item["amount"];
                    dtFromDataSource.Rows.Add(row);
                }
            }

            return dtFromDataSource;
        }

        private DataTable CollectionDetails()
        {
            DataTable dtFromDataSource = new dsLFS.dtCollectionsDataTable();
            DataTable dt = Factory.CollectorReportPaymentsRepository().GetCollectorsReportByReportNo(_reportNumber);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DataRow row = dtFromDataSource.NewRow();
                    row["type_of_form"] = item["accountable_forms"];
                    row["serial_no_from"] = item["serial_no_from"];
                    row["serial_no_to"] = item["serial_no_to"];
                    row["amount"] = item["amount"];
                    dtFromDataSource.Rows.Add(row);
                }
            }

            return dtFromDataSource;
        }

        private DataTable ReportDetails()
        {
            DataTable dtFromDataSource = new dsLFS.dtRCDDetailsDataTable();
            DataTable dt = Factory.CollectorReportRepository().GetRecordsByReportNumber(_reportNumber);

            if (dt.Rows.Count != 0) 
            {
                foreach (DataRow item in dt.Rows)
                {
                    DataRow row = dtFromDataSource.NewRow();
                    row["report_no"] = item["report_no"];
                    row["date"] = item["date"];
                    row["officer"] = item["collecting_officer"];
                    row["fund"] = item["fund_name"];
                    dtFromDataSource.Rows.Add(row);
                }
            }
            
            return dtFromDataSource;
        }

        private DataTable DataTableForms(int id)
        {
            var dtPC = new dsLFS.dtRCDFormsDataTable();
            var dt = Factory.GeneralCollectionsRepository().GetRecordByForms(Convert.ToInt32(_reportNumber));
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DataRow row = dtPC.NewRow();
                    row["rcdid"] = item["id"];
                    row["accforms"] = String.Format("{0} - {1}", item["acc_form_no"], item["acc_form_desc"]);
                    row["orfrom"] = item["orfrom"];
                    row["orto"] = item["orto"];
                    row["amount"] = item["total"];
                    dtPC.Rows.Add(row);
                }
            }
            return dtPC;
        }

        private DataTable DataTableCollections(int rcdNo)
        {
            var dtPC = new dsLFS.dtRCDCollectionsDataTable();
            var dt = Factory.GeneralCollectionsPaymentsRepository().GetCollectionPaymentByRCDNo("RCD-002");

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DataRow row = dtPC.NewRow();
                    row["rcdid"] = item["id"];
                    row["collectorname"] = item["collecting_officer"];
                    row["reportno"] = item["report_no"];
                    row["amount"] = item["amount"];
                    dtPC.Rows.Add(row);
                }
            }

            return dtPC;
        }

        private DataTable DataTableDeposits(int id)
        {
            var dtPC = new dsLFS.dtRemittanceDepositsDataTable();
            var dt = Factory.GeneralCollectionsRepository().GetRecordByDeposits(2);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DataRow row = dtPC.NewRow();
                    //row["rcdid"] = item["id"];
                    row["bankname"] = String.Format("{0} - {1}", item["bank_name"], item["account_no"]);
                    row["reference"] = item["reference"];
                    row["amount"] = item["amount"];
                    dtPC.Rows.Add(row);
                }
            }

            return dtPC;
        }

        private DataTable DataTableReceipts(int id)
        {

            var dtRC = new dsLFS.dtReceiptsDataTable();
            var dt = Factory.GeneralCollectionsRepository().GetRecordByReceipts(id);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DataRow row = dtRC.NewRow();
                    row["form"] = item["form"];
                    row["receiptfrom"] = item["receiptsfrom"];
                    row["receiptto"] = item["receiptsto"];
                    row["issuefrom"] = item["issuefrom"];
                    row["issueto"] = item["issueto"];
                    row["usedfrom"] = item["ifrom"];
                    row["usedto"] = item["ito"];
                    dtRC.Rows.Add(row);
                }
            }

            return dtRC;
        }


    }
}
