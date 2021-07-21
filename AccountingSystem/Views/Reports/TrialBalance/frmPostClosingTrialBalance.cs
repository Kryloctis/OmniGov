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
        private decimal smallerColumnValue;
        private bool isDebitColumnBigger;

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

        private DataTable DataTablePostTrialBalance()
        {

            var dtPreTrialBalance = new dsLFS.dtPreTrialBalanceDataTable();
            var dtPreTrialBalanceFromDB = Factory.GeneralLedgerAccountsRepository().GetAllViewRecords();

            fundId = Convert.ToByte(cmbFund.SelectedValue);
            year = Convert.ToInt16(dtAsOf.Value.Year);



            foreach (DataRow item in dtPreTrialBalanceFromDB.Rows)
            {
                var account_group_type = item["account_group_code"].ToString();

                if (account_group_type == "3" || account_group_type == "4" || account_group_type == "5")
                    break;

                DataRow row = dtPreTrialBalance.NewRow();
                row["account_title"] = item["ledger_name"];
                row["account_code"] = item["account_code"];


                var beginningBalanceRepository = Factory.BeginningBalancesRepository();

                var subsidiaryDebitBeginningBalance = beginningBalanceRepository.GetDebitSumOfSubsidiaryLedger(fundId, (ushort)item["general_ledger_accounts_id"], year);
                var subsidiaryCreditBeginningBalance = beginningBalanceRepository.GetCreditSumOfSubsidiaryLedger(fundId, (ushort)item["general_ledger_accounts_id"], year);

                var accountBeginningBalance = Math.Max(subsidiaryDebitBeginningBalance, subsidiaryCreditBeginningBalance) - Math.Min(subsidiaryDebitBeginningBalance, subsidiaryCreditBeginningBalance);


                var accountTransactionsTotalAmount = Factory.JEVAccountsRepository().GetJEVSumByGeneralLedgerId(fundId, (ushort)item["general_ledger_accounts_id"], year);

                var accountAdjustedBalance = accountBeginningBalance - accountTransactionsTotalAmount;


                var isDebitColumn = subsidiaryDebitBeginningBalance > subsidiaryCreditBeginningBalance;

                if (isDebitColumn)
                    row["debit"] = Math.Abs(accountAdjustedBalance).ToString("N2");
                else
                    row["credit"] = Math.Abs(accountAdjustedBalance).ToString("N2");

                dtPreTrialBalance.Rows.Add(row);
            }


            #region GovernmentEquityRow
            DataRow row1 = dtPreTrialBalance.NewRow();
            row1["account_title"] = "Government Equity";
            row1["account_code"] = "3-01-01-010";


            var amount = GetSumOfPermanentAccounts();
            smallerColumnValue = smallerColumnValue + GetSumOfTemporaryAccounts();

            if (isDebitColumnBigger)
                row1["debit"] = Math.Abs(amount - smallerColumnValue).ToString("N2");
            else
                row1["credit"] = Math.Abs(amount - smallerColumnValue).ToString("N2");

            dtPreTrialBalance.Rows.Add(row1);
            #endregion

            return dtPreTrialBalance;
        }

        private decimal GetSumOfPermanentAccounts()
        {

            var beginningBalanceRepository = Factory.BeginningBalancesRepository();
            var amount = beginningBalanceRepository.GetDebitAndCreditOfPermanentAccounts(1);

            var total_debit = Convert.ToDecimal(amount["debit"]);
            var total_credit = Convert.ToDecimal(amount["credit"]);
            _ = total_debit + total_credit;

            smallerColumnValue = Math.Min(total_debit, total_credit);

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
            var amount = beginningBalanceRepository.GetDebitAndCreditOfTemporaryAccounts(1);

            var total_debit = Convert.ToDecimal(amount["debit"]);
            var total_credit = Convert.ToDecimal(amount["credit"]);

            if (total_debit > total_credit)
                return _ =  total_debit - total_credit;
            else
                return _ = total_credit - total_debit;
        }

    }
}
