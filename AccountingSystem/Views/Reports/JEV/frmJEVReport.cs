using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data;
using System.Collections.Generic;

namespace AccountingSystem.Views.Reports.JEV
{
    public partial class frmJEVReport : Form
    {
        private readonly ReportViewer reportViewer;
        Dictionary<string, string> journalDict;

        private int _jevId;
        private string _jevNo;
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


        public frmJEVReport(int jevId, string jevNo, byte journalId)
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);

            _jevId = jevId;
            _jevNo = jevNo;
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
                    journalDict = Factory.GeneralJournalRepository().GetViewRecordByJevID(_jevId);
                    paramCheckDate = "";
                    paramOfficer = "";
                    paramCheckNo = journalDict["check_no"];
                    paramORNo = journalDict["or_no"];
                    paramDVNo = journalDict["dv_no"];
                    SetJournalData("", "Check No. :", "OR No. :", "DV No. :", "");
                    return;
                case 2:
                    journalDict = Factory.CashReceiptsJournalRepository().GetViewRecordByJevID(_jevId);
                    paramCheckNo = "";
                    paramCheckDate = Convert.ToDateTime(journalDict["or_date"]).ToString("MM/dd/yy");
                    paramORNo = journalDict["or_no"];
                    paramDVNo = journalDict["rcd_no"];
                    paramOfficer = journalDict["full_name"];
                    SetJournalData("OR Date ", "", "OR No. ", "RCD No. ", "Collecting Officer ");
                    return;
                case 3:
                    SetJournalData("Date of Entry ", "", "", "", "");
                    return;
                case 4:
                    journalDict = Factory.CashDisbursementsJournalRepository().GetViewRecordByJevID(_jevId);
                    paramORNo = "";
                    paramCheckDate = Convert.ToDateTime(journalDict["check_date"]).ToString("MM/dd/yy");
                    paramCheckNo = journalDict["check_no"];
                    paramDVNo = journalDict["dv_no"];
                    paramOfficer = journalDict["full_name"];

                    SetJournalData("Date Paid ", "", "", "DV No. ", "Disburse officer ");
                   
                    return;
                case 5:
                    journalDict = Factory.CheckDisbursementsJournalRepository().GetRecordByJevID(_jevId);
                    //SetJournalData("Date of Entry ", "Check Date ", "Check No ", "RCI No. ", "DV No. ");
                    SetJournalData("Check Date ", "Check No ", "RCI No. ", "DV No.", "");

                    paramORNo = "";
                    paramCheckDate = Convert.ToDateTime(journalDict["check_date"]).ToString("MM/dd/yy"); 
                    paramCheckNo = journalDict["check_no"];
                    paramORNo = journalDict["rci_no"];
                    paramDVNo = journalDict["dv_no"];
                    return;

                case 6:
                    journalDict = Factory.ADADisbursementsJournalRepository().GetViewRecordByJevID(_jevId);
                    SetJournalData("Date of Entry ", "", "ADA No. ", "DV No. ", "");
                    return;
                default:
                    break;
            }
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                var data = Factory.JEVRepository().GetRecordByJEV(_jevNo);

                var lguDetails = Helper.LGUDetails();
                var signatory = "MARY MAGDALYN T. REGANION, CPA";
                var preparedBy = "JOHN CENA";
                var full_jev = $"{data["fund_code"]}-{Convert.ToDateTime(data["date_entry"]).Year}-{Convert.ToDateTime(data["date_entry"]).Month}-{data["jev_no"]}";

                SetJournalCustomFields();

                var parameters = new[] {
                    new ReportParameter("paramLGU",  lguDetails["lgu_name"]),
                    new ReportParameter("paramFund", data["fund_name"]),
                    new ReportParameter("paramJournalType", data["journal_name"]),
                    new ReportParameter("paramJEVNo", full_jev),
                    new ReportParameter("paramJEVDate", Convert.ToDateTime(data["date_entry"]).ToString("MM/dd/yy")),
                    new ReportParameter("paramPayee", data["payee"]),
                    new ReportParameter("paramExplanation", data["explanation"]),
                    new ReportParameter("paramPreparedBy",preparedBy),
                    new ReportParameter("paramCertifiedBy", signatory),
                    new ReportParameter("paramDateEntry", Convert.ToDateTime(data["date_entry"]).ToString("MM/dd/yy")),

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


            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private DataTable DataTableJournalEntryVoucherAccount()
        {
            var dtJEVAccounts = new dsLFS.dtJournalVoucherDataTable();
            var dtJEVAccountsFromDB = Factory.JEVAccountsRepository().GetViewRecordsByJevId(_jevId);

            byte i = 0;

            foreach (DataRow item in dtJEVAccountsFromDB.Rows)
            {
                DataRow row = dtJEVAccounts.NewRow();

                row["fpp"] = item["fpp_code"];
                row["account_and_explanation"] = item["ledger_name"];
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

        private void frmJEVReport_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
            Helper.DatagridDefaultStyle(dgJEV);

            if (_jevId != 0)
            {
                leftPanel.Visible = false;
                panel1.Dock = DockStyle.Fill;
            }
            
            foreach (var item in Helper.MonthsDatasource().Values)
                cbMonths.Items.Add(item);

            LoadJEVReport(textBox1.Text.Trim(), (sbyte)DateTime.Now.Month);

            if (_jevId != 0)
            {
                LoadReport(reportViewer.LocalReport);
                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;
                reportViewer.RefreshReport();
            }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadJEVReport(textBox1.Text.Trim(), (sbyte)(cbMonths.SelectedIndex+1));
        }

        private void dgJEV_SelectionChanged(object sender, EventArgs e)
        {
            if (dgJEV.SelectedCells.Count > 0)
            {
                int selectedIndex = dgJEV.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgJEV.Rows[selectedIndex];

                _jevNo = Convert.ToString(selectedRow.Cells["jev_no"].Value);
                _jevId = Convert.ToInt32(selectedRow.Cells["id"].Value  );
                _journalId = Convert.ToByte(selectedRow.Cells["journals_id"].Value);

                LoadReport(reportViewer.LocalReport);
                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomMode = ZoomMode.Percent;
                reportViewer.ZoomPercent = 100;
                reportViewer.RefreshReport();
            }
        }

        private void cbMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadJEVReport(textBox1.Text.Trim(), (sbyte)(cbMonths.SelectedIndex+1));
        }

        private void LoadJEVReport(string txtSearch, sbyte monthIndex) {
            var dtJEV = Factory.JEVRepository().GetRecordsByJEVNoAndDate(txtSearch, monthIndex);
            HelperLoadRecords.JEVREportDataGridView(dtJEV, dgJEV);
        }
    }
}
