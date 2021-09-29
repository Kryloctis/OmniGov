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

namespace AccountingSystem.Views.Reports.Financial_Statements
{
    public partial class ucStatementOfChangesInNetAssetsquity : UserControl
    {
        private readonly ReportViewer reportViewer;

        public ucStatementOfChangesInNetAssetsquity()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }


        private DataTable StatementOfChangesInNetAssetsEquityDatatable()
        {

            var dataSet = new dsLFS();
            var dtStatementOfChangesInNetAssetsEquity = dataSet.dtStatementOfChangesInNetAssetsEquity;
            int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
            var dateEnded = dtPickerDateEnds.Value;
            var previousYearEnded = new DateTime(year: dateEnded.Year - 1, month: 12, DateTime.DaysInMonth(dateEnded.Year, 12));

            try
            {
                var dtJEVAccounts = Factory.JEVAccountsRepository().GetViewRecordsByLedgerAccounts();
                foreach (DataRow row in dtJEVAccounts.Rows)
                {

                    decimal currentAmount = Factory.JEVAccountsRepository().GetBalanceByFundAndAccountAndDateEntry(fundId, Convert.ToInt32(row["general_ledger_accounts_id"]), dateEnded);

                    var items = new object[]
                    {
                    row["account_group_id"],
                    row["account_group_code"],
                    row["account_group_name"],
                    row["maj_acc_group_id"],
                    row["maj_acc_group_code"],
                    row["maj_acc_group_name"],
                    row["sub_maj_acc_group_id"],
                    row["sub_maj_acc_group_code"],
                    row["sub_maj_acc_group_name"],
                    row["general_ledger_accounts_id"],
                    row["account_code"],
                    row["general_ledger_accounts_name"],
                    currentAmount,
                    Factory.JEVAccountsRepository().GetBalanceByFundAndAccountAndDateEntry(fundId, Convert.ToInt32(row["general_ledger_accounts_id"]), previousYearEnded)
                };
                    dtStatementOfChangesInNetAssetsEquity.Rows.Add(items);
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return dtStatementOfChangesInNetAssetsEquity;
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
                DateTime dateEnded = dtPickerDateEnds.Value;


                report.ReportPath = $"{Application.StartupPath}\\Reports\\statement-of-changes-in-net-assets-equity.rdlc";
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("dtStatementOfChangesInNetAssetsEquity", StatementOfChangesInNetAssetsEquityDatatable()));

                var fundRepo = Factory.FundsRepository().GetRecordByID(fundId);
                var parameters = new[] {
                    new ReportParameter("paramFund", fundRepo["fund_name"]),
                    new ReportParameter("paramDateEnded", dateEnded.ToString("MMMM dd, yyyy")),
                };
                report.SetParameters(parameters);

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

        private void ucStatementOfChangesInNetAssetsquity_Load(object sender, EventArgs e)
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
