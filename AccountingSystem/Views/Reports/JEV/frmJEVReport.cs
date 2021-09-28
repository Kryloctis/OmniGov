using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data;
using System.Collections.Generic;
using AccountingSystem.Views.Transactions.JEV;

namespace AccountingSystem.Views.Reports.JEV
{
    public partial class frmJEVReport : Form
    {
        private ReportViewer reportViewer;
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
            Helper.LoadFormIcon(this);
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
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
                    journalDict = Factory.CashDisbursementsJournalRepository().GetViewRecordByJevID(_jevId);
                    paramCheckDate = Convert.ToDateTime(journalDict["date_paid"]).ToString("MM/dd/yy");
                    paramCheckNo = "";
                    paramORNo = "";
                    paramDVNo = journalDict["dv_no"];
                    paramOfficer = journalDict["full_name"];

                    SetJournalData("Date Paid:", "", "", "DV No. ", "Disburse officer: ");
                   
                    return;
                case 5:
                    journalDict = Factory.CheckDisbursementsJournalRepository().GetRecordByJevID(_jevId);
                   
                    paramCheckDate = Convert.ToDateTime(journalDict["check_date"]).ToString("MM/dd/yy"); 
                    paramCheckNo = journalDict["check_no"];
                    paramORNo = journalDict["rci_no"];
                    paramDVNo = journalDict["dv_no"];

                    SetJournalData("Check Date: ", "Check No: ", "RCI No. : ", "DV No. :", "");
                    return;

                case 6:
                    journalDict = Factory.ADADisbursementsJournalRepository().GetViewRecordByJevID(_jevId);
                    SetJournalData("", "", "ADA No. :", "DV No. :", "");
                    return;
                default:
                    break;
            }
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                if (_jevId != 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    var data = Factory.JEVRepository().GetRecordByID(_jevId);

                    var lguDetails = Helper.LGUDetails();
                    var signatory = "MARY MAGDALYN T. REGANION, CPA";
                    var preparedByData = Helper.LoggedInUserData();
                    var preparedByFullName = $"{preparedByData["first_name"]} {preparedByData["mid_initial"]} {preparedByData["last_name"]}";
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
                    new ReportParameter("paramPreparedBy",preparedByFullName),
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

                    reportViewer.RefreshReport();

                    Cursor.Current = Cursors.Default;
                }
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

        private void frmJEVReport_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                Helper.DatagridFullRowSelectStyle(dgJEV, true);

                if (_jevId != 0)
                {
                    leftPanel.Visible = false;
                    LoadReport(reportViewer.LocalReport);
                }
                else
                {
                    LoadData();
                }
            }
        }

        private void LoadData()
        {
            LoadJournals();

            foreach (var item in Helper.MonthsDatasource().Values)
                cbMonths.Items.Add(item);
            cbMonths.SelectedIndex = DateTime.Now.Month - 1;

            LoadJEVList();
            LoadSelectedJEV();
        }

        private void LoadJEVList()
        {
            cbMonths.SelectedIndexChanged -= new EventHandler(cbMonths_SelectedIndexChanged);
            cmbJournal.SelectedIndexChanged -= new EventHandler(cbJournal_SelectedIndexChanged);
            nudYear.ValueChanged -= new EventHandler(nudYear_ValueChanged);
            dgJEV.SelectionChanged -= new EventHandler(dgJEV_SelectionChanged);

            var searchText = txtSearch.Text.Trim();
            var month = (sbyte)(cbMonths.SelectedIndex + 1);
            var year = (ushort)nudYear.Value;
            var journalId = (byte)(cmbJournal.SelectedIndex + 1);

            var dtJEV = Factory.JEVRepository().GetRecordsByJEVNoAndDate(searchText, month, year, journalId);
            HelperLoadRecords.JEVREportDataGridView(dtJEV, dgJEV);

            cbMonths.SelectedIndexChanged += new EventHandler(cbMonths_SelectedIndexChanged);
            cmbJournal.SelectedIndexChanged += new EventHandler(cbJournal_SelectedIndexChanged);
            nudYear.ValueChanged += new EventHandler(nudYear_ValueChanged);
            dgJEV.SelectionChanged += new EventHandler(dgJEV_SelectionChanged);
        }



        private void LoadSelectedJEV() 
        {
            if (dgJEV.SelectedRows.Count != 0 && leftPanel.Visible)
            {
                int selectedIndex = dgJEV.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgJEV.Rows[selectedIndex];

                _jevNo = Convert.ToString(selectedRow.Cells["jev_no"].Value);
                _jevId = Convert.ToInt32(selectedRow.Cells["id"].Value);
                _journalId = Convert.ToByte(selectedRow.Cells["journals_id"].Value);

                LoadReport(reportViewer.LocalReport);
                reportViewer.RefreshReport();
            }
        }

        private void LoadJournals()
        {
            cmbJournal.DataSource = Factory.JournalsRepository().GetRecords();
            cmbJournal.ValueMember = "id";
            cmbJournal.DisplayMember = "journal_name";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadJEVList();
        }

        private void cbMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadJEVList();
            LoadSelectedJEV();
        }

        private void cbJournal_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadJEVList();
        }

        private void nudYear_ValueChanged(object sender, EventArgs e)
        {
            LoadJEVList();
        }

        private void dgJEV_SelectionChanged(object sender, EventArgs e)
        {
            LoadSelectedJEV();
        }

    
    }
}
