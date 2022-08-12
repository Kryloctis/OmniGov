using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Dashboard.TreasuryDashboard
{
    public partial class ucRCDSummary : UserControl
    {
        public ucRCDSummary()
        {
            InitializeComponent();

            Helper.DatagridFullRowSelectStyle(dgCollectorsCollection);
            Helper.DatagridFullRowSelectStyle(dgBankDeposit);
        }

        private void ucRCDDashboard_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadMonths();
                LoadFunds();
                LoadDashboardData();
            }

        }

        private void LoadMonths()
        {
            foreach (var item in Helper.MonthsDatasource().Values)
                cbMonth.Items.Add(item);
            cbMonth.SelectedIndex = DateTime.Now.Month - 1;
            Dock = DockStyle.Fill;
        }

        internal void LoadFunds()
        {
            var dtFunds = AccFactory.FundsRepository().GetRecords();
            DataRow dr = dtFunds.NewRow();
            dr["id"] = 0;
            dr["fund_name"] = "All";
            dtFunds.Rows.InsertAt(dr, 0);

            HelperLoadRecords.FundsComboBox(dtFunds, cmbFunds, "fund_name", "id");
        }

        private void LoadRCDCounters()
        {
            int fundName = Convert.ToInt32(cmbFunds.SelectedValue);
            short month = Convert.ToInt16(cbMonth.SelectedIndex + 1);
            short year = Convert.ToInt16(nudYear.Value);

            var rcdApprovedCount = AccFactory.CollectorReportRepository().GetApprovedRCDCount(fundName, month, year);
            var rcdPendingCount = AccFactory.CollectorReportRepository().GetPendingRCDCount(fundName, month, year);
            var rcdDisapprovedCount = AccFactory.CollectorReportRepository().GetDisapprovedRCDCount(fundName, month, year);
            var rcdCancelledCount = AccFactory.CollectorReportRepository().GetCancelledRCDCount(fundName, month, year);
            var rcdCount = (rcdApprovedCount + rcdPendingCount + rcdDisapprovedCount + rcdCancelledCount);

            lblRCDCounter.Text = rcdCount.ToString();
            lblApprovedRCDCounter.Text = rcdApprovedCount.ToString();
            lblPendingRCDCounter.Text = rcdPendingCount.ToString();
            lblDisapprovedRCDCounter.Text = rcdDisapprovedCount.ToString();
            lblCancelledRCDCounter.Text = rcdCancelledCount.ToString();
        }

        private void LoadDashboardData()
        {
            LoadRCDCounters();
            LoadBanksDepositsSummary();
            LoadColllectorsCollectionSummary();
        }

        private void btnRefreshCounter_Click(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        private void cmbFunds_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDashboardData();
        }

        private void nudYear_ValueChanged(object sender, EventArgs e)
        {
            LoadDashboardData();
        }


        #region Bank Deposit Summary
        private void LoadBanksDepositsSummary()
        {
            var bankDepositSummaryDT = AccFactory.BankDepositsRepository().GetBankDepositsSummary();
            HelperLoadRecords.BanksDepositsSummaryDatagridView(bankDepositSummaryDT, dgBankDeposit);
        }

        #endregion

        #region Payment Collection Summary

        private void LoadColllectorsCollectionSummary()
        {
            var collectorsCollectionDT = AccFactory.PaymentCollectionsRepository().GetCollectionsPerCollector();
            HelperLoadRecords.PaymentSummaryDatagridView(collectorsCollectionDT, dgCollectorsCollection);
        }

        #endregion

        private void cmbFunds_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadDashboardData();
        }
    }
}
