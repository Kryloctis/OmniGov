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
    public partial class frmPostClosingTrialBalance : Form
    {
        private readonly ReportViewer reportViewer;
        private byte fundId;
        private short year;
        private ushort generalLedgerId;
        private decimal permanentAccountLesserValue;
        private bool isDebitColumnBigger;
        private decimal beginningBalance;

        public frmPostClosingTrialBalance()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panelReport.Controls.Add(reportViewer);
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            cbHideZeroBalance.Enabled = true;
            LoadReport(reportViewer.LocalReport);
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }


        private void LoadFunds()
        {
            var dtFunds = Factory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsComboBox(dtFunds, cmbFund, "fund_name", "id");
        }

        private void frmPostClosingTrialBalance_Load(object sender, EventArgs e)
        {
            LoadFunds();
        }

        private void LoadReport(LocalReport report)
        {
            try
            {

                var lguDict = Helper.LGUDetails();
                report.ReportPath = $"{Application.StartupPath}\\Reports\\post-trial-balance.rdlc";
                report.DataSources.Clear();

                report.DataSources.Add(new ReportDataSource("dtPreTrialBalance", DataTablePostTrialBalance()));

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
        private void RecordsFilter(LocalReport report, byte hideZeroBalance)
        {
            var parameters = new[] {
                    new ReportParameter("paramHideZeroBalance", hideZeroBalance.ToString())
            };

            reportViewer.LocalReport.SetParameters(parameters);
            reportViewer.RefreshReport();
        }

        private DataTable DataTablePostTrialBalance()
        {
            fundId = Convert.ToByte(cmbFund.SelectedValue);
            year = Convert.ToInt16(dtAsOf.Value.Year);

            var dtPreTrialBalance = new dsLFS.dtPreTrialBalanceDataTable();
            var dtPreTrialBalanceFromDB = Factory.GeneralLedgerAccountsRepository().GetAllViewRecords();


            foreach (DataRow item in dtPreTrialBalanceFromDB.Rows)
            {
                generalLedgerId = (ushort)item["general_ledger_accounts_id"];

                var account_group_type = item["account_group_code"].ToString();

                if (account_group_type == "3" || account_group_type == "4" || account_group_type == "5")
                    break;

                DataRow row = dtPreTrialBalance.NewRow();
                row["account_title"] = item["ledger_name"];
                row["account_code"] = item["account_code"];

                ProcessDebitCreditValues(item, row);

                dtPreTrialBalance.Rows.Add(row);
            }

            GovernmentEquityRow(fundId, year, generalLedgerId, dtPreTrialBalanceFromDB, dtPreTrialBalance);

            return dtPreTrialBalance;
        }

        private void ProcessDebitCreditValues(DataRow item, DataRow row)
        {
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
        }

        private void GovernmentEquityRow(byte fundId, short year, ushort generalLedgerId, DataTable dtGovernmentFromDB, DataTable dtGovernmentEquity)
        {
            GetSumOfPermanentAccounts();
            var governmentEquityBeginningBalance = Factory.BeginningBalancesRepository().GetGovernmentEquityBalance(fundId, 331, year);

            DataRow row = dtGovernmentEquity.NewRow();
            row["account_title"] = "Government Equity";
            row["account_code"] = "3-01-01-010";

            var govEquityBeginningBalance = GetSumOfTemporaryAccounts() - governmentEquityBeginningBalance;
           
            //For column assignment, If value is less than zero, then credit else debit.
            if (govEquityBeginningBalance > 0)
                row["debit"] = Math.Abs(govEquityBeginningBalance);
            else
                row["credit"] = Math.Abs(govEquityBeginningBalance);

            dtGovernmentEquity.Rows.Add(row);
        }

        private decimal GetSumOfPermanentAccounts()
        {
            var beginningBalanceRepository = Factory.BeginningBalancesRepository();
            var amount = beginningBalanceRepository.GetDebitAndCreditOfPermanentAccounts(1);

            var total_debit = Convert.ToDecimal(amount["debit"]);
            var total_credit = Convert.ToDecimal(amount["credit"]);

            _ = total_debit + total_credit;

            permanentAccountLesserValue = Math.Min(total_debit, total_credit);

            if (total_debit > total_credit) {
                isDebitColumnBigger = true;
                return total_debit;
            }
            else {
                isDebitColumnBigger = false;
                return total_credit;
            }
        }

        private decimal GetSumOfTemporaryAccounts()
        {

            var beginningBalanceRepository = Factory.BeginningBalancesRepository();
            var amount = beginningBalanceRepository.GetDebitAndCreditOfTemporaryAccounts(fundId);

            var total_debit = Convert.ToDecimal(amount["debit"]);
            var total_credit = Convert.ToDecimal(amount["credit"]);

            if (total_debit > total_credit)
                return _ =  total_debit - total_credit;
            else
                return _ = total_credit - total_debit;

        }

        private void cbHideZeroBalance_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHideZeroBalance.Checked)
                RecordsFilter(reportViewer.LocalReport, 1);
            else
                RecordsFilter(reportViewer.LocalReport, 0);
        }
    }
}
