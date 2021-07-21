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

namespace AccountingSystem.Views.Reports.TrialBalance
{
    public partial class frmPreClosingTrialBalance : Form
    {

        private readonly ReportViewer reportViewer;
        private byte fundId;
        private short year;

        public frmPreClosingTrialBalance()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panelReport.Controls.Add(reportViewer);
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
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

                var lguDict = Helper.LGUDetails();
                report.ReportPath = $"{Application.StartupPath}\\Reports\\pre-trial-balance.rdlc";
                report.DataSources.Clear();

                report.DataSources.Add(new ReportDataSource("dtPreTrialBalance", DataTablePreTrialBalance()));

                var signatory = "MARY MAGDALYN T. REGANION, CPA";
                var fundName = cmbFund.Text.ToUpper();
                var asOfDate = dtAsOf.Value.ToString("MMMM dd, yyyyy");

                var parameters = new[] {
                    new ReportParameter("paramLGUName", lguDict["lgu_name"]),
                    new ReportParameter("paramFund", fundName),
                    new ReportParameter("paramSignatory", signatory),
                    new ReportParameter("paramAsOf", asOfDate),
                  };
                report.SetParameters(parameters);

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private DataTable DataTablePreTrialBalance()
        {


            var dtPreTrialBalance = new dsLFS.dtPreTrialBalanceDataTable();
            var dtPreTrialBalanceFromDB = Factory.GeneralLedgerAccountsRepository().GetAllViewRecords();

            fundId = Convert.ToByte(cmbFund.SelectedValue);
            year = Convert.ToInt16(dtAsOf.Value.Year);

            foreach (DataRow item in dtPreTrialBalanceFromDB.Rows)
            {

                DataRow row = dtPreTrialBalance.NewRow();
                row["account_title"] = item["ledger_name"];
                row["account_code"] = item["account_code"];


                var beginningBalanceRepository = Factory.BeginningBalancesRepository();

                var subsidiaryDebitBeginningBalance = beginningBalanceRepository.GetDebitSumOfSubsidiaryLedger(fundId, (ushort)item["general_ledger_accounts_id"], year);
                var subsidiaryCreditBeginningBalance = beginningBalanceRepository.GetCreditSumOfSubsidiaryLedger(fundId, (ushort)item["general_ledger_accounts_id"], year);

                var accountBeginningBalance = Math.Max(subsidiaryDebitBeginningBalance, subsidiaryCreditBeginningBalance) - Math.Min(subsidiaryDebitBeginningBalance, subsidiaryCreditBeginningBalance);

                var isDebitColumn = subsidiaryDebitBeginningBalance > subsidiaryCreditBeginningBalance ? true : false;

                if (isDebitColumn)
                    row["debit"] = accountBeginningBalance.ToString("N2");
                else
                   row["credit"] = accountBeginningBalance.ToString("N2");
              
                dtPreTrialBalance.Rows.Add(row);
            }

            return dtPreTrialBalance;
        }

        private void LoadFunds()
        {
            var dtFunds = Factory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbFund, "fund_name", "id");
        }

        private void frmTrialBalance_Load(object sender, EventArgs e)
        {
            LoadFunds();
        }
    }
}
