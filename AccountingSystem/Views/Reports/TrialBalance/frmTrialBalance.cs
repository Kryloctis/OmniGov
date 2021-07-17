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
    public partial class frmTrialBalance : Form
    {

        private readonly ReportViewer reportViewer;

        public frmTrialBalance()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
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

                report.DataSources.Add(new ReportDataSource("dsPreTrialBalance", DataTablePreTrialBalance()));

                //var parameters = new[] {
                //    new ReportParameter("paramLGUName", lguDict["lgu_name"]),
                //    new ReportParameter("paramFund", fundName),
                //    new ReportParameter("paramAccountName", generalLedgerDict["ledger_name"]),
                //    new ReportParameter("paramAccountCode", generalLedgerDict["account_code"]),
                //    new ReportParameter("paramBalanceDate", balanceDate),
                //    new ReportParameter("paramBalanceDebit", balanceDebit),
                //    new ReportParameter("paramBalanceCredit", balanceCredit),
                //    new ReportParameter("paramBalance", balance)
                //  };
                //report.SetParameters(parameters);

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

            foreach (DataRow item in dtPreTrialBalanceFromDB.Rows)
            {

                DataRow row = dtPreTrialBalance.NewRow();
                row["account_title"] = item["ledger_name"];
                row["account_code"] = item["account_code"];


                var beginningBalanceRepository = Factory.BeginningBalancesRepository();
                decimal generalLedgerBalance = beginningBalanceRepository.GetSumBalanceByGeneralLedgerId(1, (ushort)item["ïd"], 2021);
                var beginningBalanceDict = beginningBalanceRepository.GetRecordByFundsAndGeneralLedgerID(1, (ushort)item["ïd"], 2021);

                string debitCreditType = string.Empty;
                debitCreditType = HelperLoadRecords.ValidateDebitOrCreditType(beginningBalanceDict, debitCreditType);


                if (debitCreditType == "Debit")
                    row["debit"] = generalLedgerBalance;
                else
                    row["credit"] = generalLedgerBalance;

                dtPreTrialBalance.Rows.Add(row);
            }

            return dtPreTrialBalance;
        }
    }
}
