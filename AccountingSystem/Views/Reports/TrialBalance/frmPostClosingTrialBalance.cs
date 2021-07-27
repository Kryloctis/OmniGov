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

        private static void ValidateDebitCreditRow(byte fundId, ushort generalLedgerId, short year, DataRow rows, DataRow items, DataTable dtPreTrialBalance)
        {
            var dtGeneralLedgerFromDB = Factory.JEVAccountsRepository().GetViewRecordsByFundAndGeneralLedger(fundId, generalLedgerId, year);

            foreach (DataRow item in dtGeneralLedgerFromDB.Rows)
            {

                DataRow row = dtPreTrialBalance.NewRow();
                row["debit"] = item["amount"];

                dtPreTrialBalance.Rows.Add(row);
            }

            //decimal amount = Convert.ToDecimal(item["amount"]);
            //if (Convert.ToBoolean(item["is_debit"]))
            //{
            //    row["debit_amount"] = item["amount"];
            //    row["credit_amount"] = 0;
            //    balance += amount;
            //}
            //else
            //{
            //    row["debit_amount"] = 0;
            //    row["credit_amount"] = item["amount"];
            //    balance -= amount;
            //}

            //row["balance"] = balance;
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

                var beginning_balance = Convert.ToDecimal(item["beginning_bal"]);

                var jevAccount = Factory.JEVAccountsRepository().GetJEVAmount(fundId, generalLedgerId, year);

                var assignToDebit = 0.0m;
                var assignToCredit = 0.0m;


                if (jevAccount.Rows.Count != 0)
                {
                    foreach (DataRow amountItem in jevAccount.Rows)
                    {
                        if (Convert.ToBoolean(amountItem["is_debit"]))
                        {
                            beginning_balance += Convert.ToDecimal(amountItem["amount"]);
                            assignToDebit += Convert.ToDecimal(amountItem["amount"]);
                        }
                        else
                        {
                            beginning_balance = Math.Abs(beginning_balance);
                            beginning_balance -= Convert.ToDecimal(amountItem["amount"]);
                            assignToCredit += Convert.ToDecimal(amountItem["amount"]);
                        }
                    }

                    if (assignToDebit > assignToCredit)
                        row["debit"] = Math.Abs(beginning_balance);
                    else
                        row["credit"] = Math.Abs(beginning_balance);
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

            GovernmentEquityRow(fundId, year, generalLedgerId, dtPreTrialBalanceFromDB, dtPreTrialBalance);

            return dtPreTrialBalance;
        }

        private void GovernmentEquityRow(byte fundId, short year, ushort generalLedgerId, DataTable dtGovernmentFromDB, DataTable dtGovernmentEquity)
        {
            var amount = 0.0m;

            foreach (DataRow item in dtGovernmentFromDB.Rows)
            {
                var account_code = item["account_group_code"].ToString();
                if (account_code == "3" || account_code == "4" || account_code == "5")
                {
                    amount += 0;
                }
            }
            GetSumOfPermanentAccounts();
            var governmentEquityBeginningBalance = Factory.BeginningBalancesRepository().GetGovernmentEquityBalance(fundId, 331, year);

            DataRow row = dtGovernmentEquity.NewRow();
            row["account_title"] = "Government Equity";
            row["account_code"] = "3-01-01-010";
            row["debit"] = governmentEquityBeginningBalance + GetSumOfTemporaryAccounts();


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

        


        private decimal GetTotalTransaction(byte fundId, ushort generalLedgerId, short year, decimal accountBeginningBalance)
        {
            var dtGeneralLedger = Factory.JEVAccountsRepository().GetViewRecordsByFundAndGeneralLedger(fundId, generalLedgerId, year);



            foreach (DataRow item in dtGeneralLedger.Rows)
            {
                if (Convert.ToBoolean(item["is_debit"]))
                    accountBeginningBalance += Convert.ToDecimal(item["amount"]);
                else
                    accountBeginningBalance -= Convert.ToDecimal(item["amount"]);
            }

            return accountBeginningBalance;
        }

    }
}
