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

        }

        private void ucRCDDashboard_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadMonths();
                LoadFunds();
                LoadRCDCounters();
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
            var dtFunds = Factory.FundsRepository().GetRecords();
            DataRow dr = dtFunds.NewRow();
            dr["id"] = 0;
            dr["fund_name"] = "All";
            dtFunds.Rows.InsertAt(dr, 0);

            HelperLoadRecords.FundsComboBox(dtFunds, cmbFunds, "fund_name", "id");
        }

        private void LoadRCDCounters()
        {
           
            var rcdApprovedCount = Factory.CollectorReportRepository().GetApprovedRCDCount();
            var rcdPendingCount = Factory.CollectorReportRepository().GetPendingRCDCount();
            var rcdDisapprovedCount = Factory.CollectorReportRepository().GetDisapprovedRCDCount();
            var rcdCancelledCount = Factory.CollectorReportRepository().GetCancelledRCDCount();
            var rcdCount = (rcdApprovedCount + rcdPendingCount + rcdDisapprovedCount + rcdCancelledCount);


            lblRCDCounter.Text = rcdCount.ToString();
            lblApprovedRCDCounter.Text = rcdApprovedCount.ToString();
            lblPendingRCDCounter.Text = rcdPendingCount.ToString();
            lblDisapprovedRCDCounter.Text = rcdDisapprovedCount.ToString();
            lblCancelledRCDCounter.Text = rcdCancelledCount.ToString();
        }
    }
}
