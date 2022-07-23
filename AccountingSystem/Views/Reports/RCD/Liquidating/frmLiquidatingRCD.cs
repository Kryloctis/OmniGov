using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RCD.Liquidating
{
    public partial class frmLiquidatingRCD : Form
    {
        private readonly ReportViewer reportViewer = new();
        private readonly string _reportNumber;

        public frmLiquidatingRCD(string reportNumber)
        {
            InitializeComponent();

            reportViewer.Dock = DockStyle.Fill;
            panelReport.Controls.Add(reportViewer);
            Helper.LoadFormIcon(this);

            _reportNumber = reportNumber;
        }

        private void frmLiquidatingRCD_Load(object sender, EventArgs e)
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
                Cursor = Cursors.WaitCursor;
                string accountableOfficer = AccFactory.UsersRepository().GetCollectorNameByUserId(Helper.UserId);
                string verificationSignatory = string.Empty;
                string verificationSignatoryTitle = string.Empty;

                var dictVerification = AccFactory.SignatoriesHasReferencesRepository().GetSignatoryBy_Reference_DocumentName("Verification and Acknowledgement", "Report of Collections and Deposits");
                static void ParseSignatory(Dictionary<string, string> dictSignatory, ref string signatory, ref string signatoryTitle)
                {
                    if (dictSignatory.Count > 0)
                    {
                        string prefix = dictSignatory["signatories_prefix"].ToString();
                        string firstName = dictSignatory["signatories_first_name"].ToString();
                        char middleInitial = Convert.ToChar(dictSignatory["signatories_middle_initial"]);
                        string lastName = dictSignatory["signatories_last_name"].ToString();
                        string suffix = dictSignatory["signatories_suffix"].ToString();

                        string signatoryName = $"{(string.IsNullOrEmpty(prefix) ? string.Empty : $"{prefix}.")} {firstName} {middleInitial}. {lastName}{(string.IsNullOrEmpty(suffix) ? string.Empty : $", {suffix}")}";

                        signatory = signatoryName;
                        signatoryTitle = dictSignatory["signatories_title"];
                    }
                }

                ParseSignatory(dictVerification, ref verificationSignatory, ref verificationSignatoryTitle);

                var lguDetails = Helper.LGUDetails();
                var totalChecksAmount = 0;


                var parameters = new[]
                {
                    new ReportParameter("paramLGUName", value:lguDetails["lgu_name"]),
                    new ReportParameter("paramAccountableOfficer", value:accountableOfficer),
                    new ReportParameter("paramVerificationSignatory", verificationSignatory),
                    new ReportParameter("paramSummaryDate", DateTime.Now.ToString()),
                    new ReportParameter("paramDate", DateTime.Now.ToString()),
                    new ReportParameter("paramTotalCheck", value:totalChecksAmount.ToString())
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
            //DataTable dt = Factory.ReceiptsIssuedRepository().GetAccountabilityForAccountableForms();

            //if (dt.Rows.Count != 0)
            //{
            //    foreach (DataRow item in dt.Rows)
            //    {
            //        DataRow row = dtFromDataSource.NewRow();
            //        row["accountable_form"] = item["accountable_forms"];
            //        row["beginning_bal_quantity"] = item["quantity"];
            //        row["beginning_bal_serial_from"] = item["serial_no_from"];
            //        row["beginning_bal_serial_to"] = item["serial_no_to"];
            //        row["issue_quantity"] = item["issue_quantity"];
            //        row["issue_serial_from"] = item["issuefrom"];
            //        row["issue_serial_to"] = item["issueto"];
            //        row["ending_bal_quantity"] = item["ending_balance_quantity"];
            //        row["ending_bal_serial_from"] = item["ending_balance_serial_from"];
            //        row["ending_bal_serial_to"] = item["ending_balance_serial_to"];
            //        dtFromDataSource.Rows.Add(row);
            //    }
            //}

            return dtFromDataSource;
        }
        private DataTable RemittanceAndDeposits()
        {
            DataTable dtFromDataSource = new dsLFS.dtRemittanceDepositsDataTable();
            DataTable dt = AccFactory.GeneralCollectionsDepositsRepository().GetCollectionsDepositsByRCDNo(_reportNumber);

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
            DataTable dt = AccFactory.CollectorReportRepository().GetCollectorsReportByReportNo(_reportNumber);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    string collectingOfficer = $"{item["collecting_officers_first_name"]} {item["collecting_officers_mid_initial"]}. {item["collecting_officers_last_name"]}";

                    if (!string.IsNullOrEmpty(item["job_orders_id"].ToString()))
                        collectingOfficer = $"{item["job_orders_first_name"]} {item["job_orders_mid_initial"]}. {item["job_orders_last_name"]}";

                    DataRow row = dtFromDataSource.NewRow();
                    row["name_of_accountable_officer"] = collectingOfficer;
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
            DataTable dt = AccFactory.CollectorReportPaymentsRepository().GetCollectorsReportByReportNo(_reportNumber);

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
            DataTable dt = AccFactory.GeneralCollectionsRepository().GetRecordsByRCDNo(_reportNumber);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DataRow row = dtFromDataSource.NewRow();
                    row["report_no"] = item["rcd_no"];
                    row["date"] = item["rcd_date"];
                    row["officer"] = item["user"];
                    row["fund"] = "General Fund";
                    dtFromDataSource.Rows.Add(row);
                }
            }

            return dtFromDataSource;
        }

        private DataTable DataTableForms(int id)
        {
            var dtPC = new dsLFS.dtRCDFormsDataTable();
            var dt = AccFactory.GeneralCollectionsRepository().GetRecordByForms(Convert.ToInt32(_reportNumber));
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
            var dt = AccFactory.GeneralCollectionsPaymentsRepository().GetCollectionPaymentByRCDNo("RCD-002");

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
            var dt = AccFactory.GeneralCollectionsRepository().GetRecordByDeposits(2);
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
            var dt = AccFactory.GeneralCollectionsRepository().GetRecordByReceipts(id);
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
