using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Journals
{
    public partial class ucCashReceiptsJournalReport : UserControl
    {
        private readonly ReportViewer reportViewer;

        public ucCashReceiptsJournalReport()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }

        private void LoadFunds()
        {
            cmbFunds.DataSource = Factory.FundsRepository().GetRecords();
            cmbFunds.ValueMember = "id";
            cmbFunds.DisplayMember = "fund_name";
        }

        private DataTable CashReceiptsJournalDataTable()
        {
            byte fundId = (byte)cmbFunds.SelectedValue;
            byte journalId = 2;
            var dateYearMonth = dtpMonth.Value;

            var dtCashReceiptsJournal = new dsLFS.CashReceiptsJournalDataTable();
            var dtCashReceiptsFromDB = Factory.JEVAccountsRepository().GetViewRecordsByFundJournalDate(fundId, journalId, dateYearMonth);

            int jevId;
            string jevNo;

            var cashReceiptsJournalRepository = Factory.CashReceiptsJournalRepository();
            foreach (DataRow item in dtCashReceiptsFromDB.Rows)
            {
                jevId = Convert.ToInt32(item["jev_id"]);
                jevNo = item["jev_no"].ToString();

                var cashReceiptsDict = cashReceiptsJournalRepository.GetViewRecordByJevID(jevId);
                DataRow row = dtCashReceiptsJournal.NewRow();
                row["date"] = item["date_entry"];
                row["rcd_no"] = cashReceiptsDict["rcd_no"];
                row["collecting_officer"] = cashReceiptsDict["full_name"];

                // if data is for collections columns
                if (!Convert.ToBoolean(item["is_deposit"]))
                {
                    row["collections_credit_account_code"] = item["account_code"];
                    if (Convert.ToBoolean(item["is_debit"]))
                    {
                        row["collections_debit_amount"] = item["amount"];
                    }
                    else
                    {
                        row["collections_credt_amount"] = item["amount"];
                    }
                }

                // if data is for deposits columns
                if (Convert.ToBoolean(item["is_deposit"]))
                {
                    row["deposit_debit_account_code"] = item["account_code"];
                    if (Convert.ToBoolean(item["is_debit"]))
                    {
                        row["deposit_debit_amount"] = item["amount"];

                    }
                    else
                    {
                        row["deposit_credit_amount"] = item["amount"];
                    }
                }



                dtCashReceiptsJournal.Rows.Add(row);
            }

            return dtCashReceiptsJournal;
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var lguDetails = Helper.LGUDetails();
                var fundName = cmbFunds.Text;
                var signatory = "MARY MAGDALYN T. REGANION, CPA";

                var parameters = new[] {
                    new ReportParameter("paramMonth", dtpMonth.Value.ToString()),
                    new ReportParameter("paramLGUName", lguDetails["lgu_name"]),
                    new ReportParameter("paramFund", fundName),
                    new ReportParameter("paramSignatory", signatory)
                };

                report.ReportPath = $"{Application.StartupPath}\\Reports\\cash-receipts-journal.rdlc";
                report.DataSources.Clear();

                report.DataSources.Add(new ReportDataSource("CashReceiptsJournal", CashReceiptsJournalDataTable()));
                report.SetParameters(parameters);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }

        private void ucCashReceiptsJournalReport_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadFunds();
            }
        }
    }
}