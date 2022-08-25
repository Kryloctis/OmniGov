using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
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

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private DataTable AccountabilityForAccountableForms()
        {
            DataTable dtFromDataSource = new dsLFS.dtAccountabilityForAccountableFormsDataTable();
            string collectorId = GetCollectorIdByReportNumber(_reportNumber);

            DataTable dt = AccFactory.ReceiptsIssuedRepository().GetAccountabilityForAccountableForms(collectorId);

            if (dt.Rows.Count == 0)
                return dt;


            foreach (DataRow item in dt.Rows)
            {
                DataRow row = dtFromDataSource.NewRow();
                var lastIssued = item["last_issued"];

                var accountableForm = item["accountable_forms"];
                var beginningQuantity = Convert.ToInt32(item["quantity"]);
                var receiptBeginningBalanceFrom = item["receipt_issued_from"];
                var receiptBeginningBalanceTo = item["receipt_issued_to"];

                var totalUsedByCollectingOfficer = (Convert.ToInt32(lastIssued) - Convert.ToInt32(receiptBeginningBalanceFrom)) + 1;

                //RECEIPTS ISSUED TO COLLECTING OFFICER.
                row["accountable_form"] = accountableForm;
                row["beginning_bal_quantity"] = beginningQuantity;
                row["beginning_bal_serial_from"] = receiptBeginningBalanceFrom;
                row["beginning_bal_serial_to"] = receiptBeginningBalanceTo;

                //RECEIPTS USED BY THE COLLECTING OFFICER.
                row["issue_quantity"] = totalUsedByCollectingOfficer;
                row["issue_serial_from"] = receiptBeginningBalanceFrom;
                row["issue_serial_to"] = lastIssued;

                //REMAINING RECEIPT AFTER CREATION OF REPORT.
                row["ending_bal_quantity"] = beginningQuantity - totalUsedByCollectingOfficer;
                row["ending_bal_serial_from"] = Convert.ToInt32(lastIssued) + 1;
                row["ending_bal_serial_to"] = receiptBeginningBalanceTo;


                dtFromDataSource.Rows.Add(row);
            }
            

            return dtFromDataSource;
        }

        private string GetCollectorIdByReportNumber(string reportNumber)
        {
            try
            {
                var collectorReportRepo = AccFactory.CollectorReportRepository();
                return collectorReportRepo.GetCollectorIdByReportNumber(reportNumber);
            }
            catch (Exception)
            {

                throw;
            }
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
            //DataTable dt = Factory.CollectorReportRepository().GetCollectorsReportByReportNo(_reportNumber);
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

                    var receiptNumberFrom = string.IsNullOrEmpty(item["report_number_from"].ToString()) ? string.Empty : Convert.ToInt32(item["report_number_from"]).ToString("D7");
                    var receiptNumberTo = string.IsNullOrEmpty(item["report_number_to"].ToString()) ? string.Empty : Convert.ToInt32(item["report_number_to"]).ToString("D7");


                    row["type_of_form"] = item["accountable_forms"];
                    row["serial_no_from"] = receiptNumberFrom;
                    row["serial_no_to"] = receiptNumberTo;
                    row["amount"] = item["amount"];
                    dtFromDataSource.Rows.Add(row);
                }
            }

            return dtFromDataSource;
        }

        private DataTable ReportDetails()
        {
            DataTable dtFromDataSource = new dsLFS.dtRCDDetailsDataTable();
            DataTable dt = AccFactory.CollectorReportRepository().GetRecordsByReportNumber(_reportNumber);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    string collectingOfficer = $"{item["collecting_officers_first_name"]} {item["collecting_officers_mid_initial"]}. {item["collecting_officers_last_name"]}";

                    if (!string.IsNullOrEmpty(item["job_orders_id"].ToString()))
                        collectingOfficer = $"{item["job_orders_first_name"]} {item["job_orders_mid_initial"]}. {item["job_orders_last_name"]} / {collectingOfficer}";
                   
                    DataRow row = dtFromDataSource.NewRow();
                    row["report_no"] = item["report_no"];
                    row["date"] = item["date"];
                    row["officer"] = collectingOfficer;
                    row["fund"] = item["fund_name"];
                    dtFromDataSource.Rows.Add(row);
                }
            }

            return dtFromDataSource;
        }


    }
}
