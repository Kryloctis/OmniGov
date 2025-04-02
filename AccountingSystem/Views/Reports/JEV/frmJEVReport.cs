using ACC.Data;
using LFS;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.JEV
{
    public partial class frmJEVReport : Form
    {
        private ReportViewer reportViewer;
        private Dictionary<string, string> journalDict;

        private int _jevId;
        private byte _journalId;

        internal string checkDate;
        internal string checkNo;
        internal string orNo;
        internal string dv;
        internal string officer;

        internal string paramCheckDate;
        internal string paramCheckNo;
        internal string paramORNo;
        internal string paramDVNo;
        internal string paramOfficer;

        public frmJEVReport(int jevId, byte journalId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            reportViewer = new ReportViewer();
            panel1.Controls.Add(reportViewer);
            reportViewer.Dock = DockStyle.Fill;
            _jevId = jevId;
            _journalId = journalId;
        }

        private void SetJournalData(string checkDate, string checkNo, string orNo, string dv, string officer)
        {
            this.checkDate = checkDate;
            this.checkNo = checkNo;
            this.orNo = orNo;
            this.dv = dv;
            this.officer = officer;
        }

        private void SetJournalCustomFields()
        {
            switch (_journalId)
            {
                case 1:
                    journalDict = AccFactory.GeneralJournalRepository().GetViewRecordByJevID(_jevId);
                    paramCheckDate = "";
                    paramOfficer = "";
                    paramCheckNo = journalDict["check_no"];
                    paramORNo = journalDict["or_no"];
                    paramDVNo = journalDict["dv_no"];
                    SetJournalData("", "Check No. :", "OR No. :", "DV No. :", "");
                    return;

                case 2:
                    journalDict = AccFactory.CashReceiptsJournalRepository().GetViewRecordByJevID(_jevId);

                    paramCheckDate = Convert.ToDateTime(journalDict["or_date"]).ToString("MM/dd/yy");
                    paramORNo = journalDict["or_no"];
                    paramCheckNo = "";
                    paramDVNo = journalDict["rcd_no"];
                    paramOfficer = journalDict["full_name"];
                    SetJournalData("OR Date :", "", "OR No. :", "RCD No. :", "Collecting Officer: ");
                    return;

                case 3:     //NO OTHER FIELDS ASIDE FROM DATE OF ENTRY
                    return;

                case 4:
                    journalDict = AccFactory.CashDisbursementsJournalRepository().GetViewRecordByJevID(_jevId);
                    paramCheckDate = Convert.ToDateTime(journalDict["date_paid"]).ToString("MM/dd/yy");
                    paramCheckNo = "";
                    paramORNo = "";
                    paramDVNo = journalDict["dv_no"];
                    paramOfficer = journalDict["full_name"];

                    SetJournalData("Date Paid:", "", "", "DV No. ", "Disburse officer: ");

                    return;

                case 5:
                    journalDict = AccFactory.CheckDisbursementsJournalRepository().GetRecordByJevID(_jevId);

                    paramCheckDate = Convert.ToDateTime(journalDict["check_date"]).ToString("MM/dd/yy");
                    paramCheckNo = journalDict["check_no"];
                    paramORNo = journalDict["rci_no"];
                    paramDVNo = journalDict["dv_no"];

                    SetJournalData("Check Date: ", "Check No: ", "RCI No. : ", "DV No. :", "");
                    return;

                case 6:
                    journalDict = AccFactory.ADADisbursementsJournalRepository().GetViewRecordByJevID(_jevId);
                    SetJournalData("", "", "ADA No. :", "DV No. :", "");
                    return;

                default:
                    break;
            }
        }

        private void ParseSignatory(Dictionary<string, string> dictSignatory, ref string signatoryName, ref string signatory_title)
        {
            if (dictSignatory.Count > 0)
            {
                signatoryName = dictSignatory["signatories_full_name"];
                signatory_title = dictSignatory["signatories_title"];
            }
        }

        private void LoadReport(LocalReport report)
        {
            if (_jevId != 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                Dictionary<string, string> data = AccFactory.JEVRepository().GetRecordByID(_jevId);

                var lguDetails = Helper.LGUDetails();

                string CertifiedBySignatory = string.Empty;
                string CertifiedBysignatoryTitle = string.Empty;

                Dictionary<string, string> dictSignatory = Helper.GetSignatoryDataBy_Reference_DocumentName("Certified Correct", "Journal Entry Voucher");
                ParseSignatory(dictSignatory, ref CertifiedBySignatory, ref CertifiedBysignatoryTitle);

                Dictionary<string, dynamic> preparedByData = Helper.LoggedInUserData();
                dynamic preparedByFullName = preparedByData["user_full_name"];

                string full_jev = $"{data["fund_code"]}-{Convert.ToDateTime(data["date_entry"]).Year}-{Convert.ToDateTime(data["date_entry"]).Month}-{data["jev_no"]}";

                Dictionary<string, string> dictJev = AccFactory.JEVRepository().GetRecordByID(_jevId);
                Dictionary<string, string> dictUser = AccFactory.UsersRepository().GetRecordByID(Convert.ToInt32(dictJev["created_by"]));

                SetJournalCustomFields();

                ReportParameter[] parameters = new[] {
                    new ReportParameter("paramLGU",  lguDetails["lgu_name"]),
                    new ReportParameter("paramFund", data["fund_name"]),
                    new ReportParameter("paramJournalType", data["journal_name"]),
                    new ReportParameter("paramJEVNo", full_jev),
                    new ReportParameter("paramJEVDate", Convert.ToDateTime(data["date_entry"]).ToString("MM/dd/yy")),
                    new ReportParameter("paramPayee", data["payee"]),
                    new ReportParameter("paramExplanation", data["explanation"]),
                    new ReportParameter("paramPreparedBy",dictJev["created_by_name"].ToUpper()),
                    new ReportParameter("paramPreparedByRole",dictUser["role_name"]),
                    new ReportParameter("paramCertifiedBySignatory", CertifiedBySignatory),
                    new ReportParameter("paramCertifiedBySignatoryTitle", CertifiedBysignatoryTitle),

                    //For fields label
                    new ReportParameter("paramAsTextCheckDate", checkDate),
                    new ReportParameter("paramAsTextCheckNo", checkNo),
                    new ReportParameter("paramAsTextOR", orNo),
                    new ReportParameter("paramAsTextDV", dv),
                    new ReportParameter("paramAsTextOfficer", officer),

                    //for fields values
                    new ReportParameter("paramCheckDate", paramCheckDate),
                    new ReportParameter("paramCheckNo", paramCheckNo),
                    new ReportParameter("paramORNumber", paramORNo),
                    new ReportParameter("paramDVNo", paramDVNo),
                    new ReportParameter("paramDisbursementOfficer", paramOfficer)
                };

                report.ReportPath = $"{Application.StartupPath}\\Reports\\journal-entry-voucher.rdlc";
                report.DataSources.Clear();

                report.DataSources.Add(new ReportDataSource("dtJournalVoucher", DataTableJournalEntryVoucherAccount()));
                report.SetParameters(parameters);

                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.PageWidth;
                reportViewer.ZoomPercent = 100;

                reportViewer.RefreshReport();

                Cursor.Current = Cursors.Default;
            }
        }

        private DataTable DataTableJournalEntryVoucherAccount()
        {
            var dtJEVAccounts = new dsLFS.dtJournalVoucherDataTable();
            var dtJEVAccountsFromDB = AccFactory.JEVAccountsRepository().GetViewRecordsByJevId(_jevId);

            byte i = 0;

            foreach (DataRow item in dtJEVAccountsFromDB.Rows)
            {
                DataRow row = dtJEVAccounts.NewRow();

                row["fpp"] = item["fpp_code"];
                row["account_and_explanation"] = item["general_ledger_accounts_name"];
                row["account_code"] = item["account_code"];

                if (Convert.ToBoolean(item["is_debit"]))
                    row["debit"] = item["amount"];
                else
                    row["credit"] = item["amount"];

                dtJEVAccounts.Rows.Add(row);

                i++;
            }
            return dtJEVAccounts;
        }

        private void OnLoad()
        {
            LoadReport(reportViewer.LocalReport);
        }

        private void frmJEVReport_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}