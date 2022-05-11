using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.Financial_Statements
{
    public partial class ucStatementOfFinancialPerformance : UserControl
    {
        private readonly ReportViewer reportViewer;

        public ucStatementOfFinancialPerformance()
        {
            InitializeComponent();
            reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            panel1.Controls.Add(reportViewer);
        }

        private void GetDebitCredit(byte fundsId, DateTime dateEntry, ushort generalLedgerId, out decimal balanceDebit, out decimal balanceCredit)
        {
            var dictBeginningBalance = Factory.BeginningBalancesRepository().GetSumBalances(fundsId, generalLedgerId, dateEntry);
            var dictTransaction = Factory.JEVAccountsRepository().GetSumTransactionsByGenLedgerId(fundsId, generalLedgerId, dateEntry);

            decimal totalBeginningAndTransDebit = dictBeginningBalance["beginning_balance_debit"] + dictTransaction["debit"];
            decimal totalBeginningAndTransCredit = dictBeginningBalance["beginning_balance_credit"] + dictTransaction["credit"];

            decimal beginningBalance = totalBeginningAndTransDebit - totalBeginningAndTransCredit;
            balanceDebit = totalBeginningAndTransDebit > totalBeginningAndTransCredit ? Math.Abs(beginningBalance) : 0;
            balanceCredit = totalBeginningAndTransDebit < totalBeginningAndTransCredit ? Math.Abs(beginningBalance) : 0;
        }

        private DataTable StatementOfFinancialPerformanceDatatable()
        {
            var dataSet = new dsLFS();
            var dtStatementOfFinancialPerformance = dataSet.dtStatementOfFinancialPerformance;
            byte fundsId = (byte)cmbxFunds.SelectedValue;
            var dateEnded = dtPickerDateEnds.Value;
            var previousYearEnded = new DateTime(year: dateEnded.Year - 1, month: 12, DateTime.DaysInMonth(dateEnded.Year, 12));

            try
            {
                var dtGeneralLedgerAccounts = Factory.GeneralLedgerAccountsRepository().GetViewRecords();
                foreach (DataRow row in dtGeneralLedgerAccounts.Rows)
                {
                    int accGrpId = Convert.ToInt32(row["account_group_id"]);
                    string accGrpCode = row["account_group_code"].ToString();
                    string accGrpName = row["account_group_name"].ToString();
                    int majAccGrpId = Convert.ToInt32(row["major_account_group_id"]);
                    string majAccGrpCode = row["maj_acc_group_code"].ToString();
                    string majAccGrpName = row["maj_acc_group_name"].ToString();
                    int subMajAccGrpId = Convert.ToInt32(row["sub_major_account_group_id"]);
                    string subMajAccGrpCode = row["sub_maj_acc_group_code"].ToString();
                    string subMajAccGrpName = row["sub_maj_acc_group_name"].ToString();
                    ushort genLedgAccId = Convert.ToUInt16(row["general_ledger_accounts_id"]);
                    string genLedgAccCode = row["account_code"].ToString();
                    string genLedgAccName = row["ledger_name"].ToString();

                    decimal balanceDebit;
                    decimal balanceCredit;
                    decimal previousBalanceDebit;
                    decimal previousBalanceCredit;

                    GetDebitCredit(fundsId, dateEnded, genLedgAccId, out balanceDebit, out balanceCredit);
                    GetDebitCredit(fundsId, previousYearEnded, genLedgAccId, out previousBalanceDebit, out previousBalanceCredit);

                    decimal currentAmount = balanceDebit - balanceCredit;
                    decimal previousAmount = previousBalanceDebit - previousBalanceCredit;

                    var items = new object[]
                    {
                    accGrpId,
                    accGrpCode,
                    accGrpName,
                    majAccGrpId,
                    majAccGrpCode,
                    majAccGrpName,
                    subMajAccGrpId,
                    subMajAccGrpCode,
                    subMajAccGrpName,
                    genLedgAccId,
                    genLedgAccCode,
                    genLedgAccName,
                    currentAmount,
                    previousAmount
                    };

                    dtStatementOfFinancialPerformance.Rows.Add(items);
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return dtStatementOfFinancialPerformance;
        }

        private void ParseSignatory(Dictionary<string, string> dictSignatory, ref string signatoryName, ref string signatoryTitle)
        {
            if (dictSignatory.Count > 0)
            {
                signatoryName = dictSignatory["signatories_full_name"];
                signatoryTitle = dictSignatory["signatories_title"];
            }
        }

        private void LoadReport(LocalReport report)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var dictSignatory = Helper.GetSignatoryDataBy_Reference_DocumentName("Certified Correct", "Statement of Financial Performance");
                string certifiedCorrectSignatory = string.Empty;
                string certifiedCorrectSignatoryTitle = string.Empty;
                ParseSignatory(dictSignatory, ref certifiedCorrectSignatory, ref certifiedCorrectSignatoryTitle);

                int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
                DateTime dateEnded = dtPickerDateEnds.Value;


                report.ReportPath = $"{Application.StartupPath}\\Reports\\statement-of-financial-performance.rdlc";
                report.DataSources.Clear();
                report.DataSources.Add(new ReportDataSource("dtStatementOfFinancialPerformance", StatementOfFinancialPerformanceDatatable()));

                var fundRepo = Factory.FundsRepository().GetRecordByID(fundId);
                var parameters = new[] {
                    new ReportParameter("paramCertifiedCorrectSignatory", certifiedCorrectSignatory),
                    new ReportParameter("paramCertifiedCorrectSignatoryTitle", certifiedCorrectSignatoryTitle),
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

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            LoadReport(reportViewer.LocalReport);
        }

        private void ucStatementOfFinancialPerformance_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadFunds();
            }
        }
    }
}
