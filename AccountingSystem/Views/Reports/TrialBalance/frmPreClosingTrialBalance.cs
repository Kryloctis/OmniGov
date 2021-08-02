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
        private ushort generalLedgerId;

        public frmPreClosingTrialBalance()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
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
                var asOfDate = dtAsOf.Value.ToString("MMMM dd, yyyy");

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
            fundId = Convert.ToByte(cmbFund.SelectedValue);
            year = Convert.ToInt16(dtAsOf.Value.Year);

            var dtPreTrialBalance = new dsLFS.dtPreTrialBalanceDataTable();
            var dtPreTrialBalanceFromDB = Factory.GeneralLedgerAccountsRepository().GetAllViewRecords();

            foreach (DataRow item in dtPreTrialBalanceFromDB.Rows)
            {
                generalLedgerId = (ushort)item["general_ledger_accounts_id"];

                DataRow row = dtPreTrialBalance.NewRow();
                row["account_title"] = item["ledger_name"];
                row["account_code"] = item["account_code"];

                var debit_beginning_bal = Convert.ToDecimal(item["debit_beginning_bal"]);
                var credit_beginning_bal = Convert.ToDecimal(item["credit_beginning_bal"]);

                var beginning_balance = debit_beginning_bal - credit_beginning_bal;
                var jevAccount = Factory.JEVAccountsRepository().GetJEVAmount(fundId, generalLedgerId, year);

                if (jevAccount.Rows.Count != 0)
                {
                    var adjustedDebitbalance = 0.0m;
                    var adjustedCreditbalance = 0.0m;

                    foreach (DataRow items in jevAccount.Rows)
                    {
                        if (Convert.ToBoolean(items["is_debit"]))
                            adjustedDebitbalance = debit_beginning_bal + Convert.ToDecimal(items["amount"]);
                        else
                            adjustedCreditbalance = credit_beginning_bal + Convert.ToDecimal(items["amount"]);
                    }
                    var endingBalance = Math.Max(adjustedDebitbalance, adjustedCreditbalance) - Math.Min(adjustedDebitbalance, adjustedCreditbalance);

                    //ENDING BALANCE.
                    if (adjustedDebitbalance > adjustedCreditbalance)
                        row["debit"] = endingBalance;
                    else
                        row["credit"] = endingBalance;
                }

                else //IF NO JEV RECORDS
                {
                    if (beginning_balance > 0)
                        row["debit"] = Math.Abs(beginning_balance);
                    else
                        row["credit"] = Math.Abs(beginning_balance);
                }

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
