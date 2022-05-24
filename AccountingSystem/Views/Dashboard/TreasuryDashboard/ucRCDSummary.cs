using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                LoadRCDCounters();
            }
 
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
