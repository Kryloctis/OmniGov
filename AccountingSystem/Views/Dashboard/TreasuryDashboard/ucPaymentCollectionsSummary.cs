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
    public partial class ucPaymentCollectionsSummary : UserControl
    {
        public ucPaymentCollectionsSummary()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgCollectorsCollection);
        }

        private void ucPaymentCollectionsSummary_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadColllectorsCollectionSummary();
            }
        }

        private void LoadColllectorsCollectionSummary()
        {
            var collectorsCollectionDT = Factory.PaymentCollectionRepository().GetCollectionsPerCollector();
            HelperLoadRecords.PaymentSummaryDatagridView(collectorsCollectionDT, dgCollectorsCollection);
        }

    }
}
