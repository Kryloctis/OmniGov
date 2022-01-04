using AccountingSystem.Views.Reports.RCDCollector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.CollectorsRCD
{
    public partial class frmCollectorsRCDLoad : Form
    {

        private readonly byte _fundId;
        private readonly ushort _collectorId;
        private readonly ucCollectorsRCD _uc;


        private bool buttonSelectAccess;
        private DataTable dtPaymentCollection;


        public frmCollectorsRCDLoad(byte fundId, ushort collectorId, ucCollectorsRCD uc)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            _fundId = fundId;
            _collectorId = collectorId;
            _uc = uc;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadCollections();
            EnableDisableLocalControls();
        }

        internal void LoadCollections()
        {
            var collectionFrom = Convert.ToDateTime(dtfrom.SelectionRange.Start.ToShortDateString());
            var collectionTo = Convert.ToDateTime(dtto.SelectionRange.Start.ToShortDateString());

            var parameter = new object[] {
                _collectorId,
                _fundId,
                collectionFrom,
                collectionTo
            };

            dtPaymentCollection = Factory.PaymentCollectionRepository().GetRecordByLedger(parameter);
            PaymentCollectionChecker();

            int collectionsCount = dtPaymentCollection.Rows.Count;
            txtCollectionsCount.Text = collectionsCount.ToString();

            if (dtPaymentCollection.Rows.Count == 0)
                Helper.MessageBoxSuccess("No records found. You might have already created a report of collections for the selected date range.\n\n\nPlease select another date.");

        }

        private void PaymentCollectionChecker()
        {
            foreach (DataRow item in dtPaymentCollection.Rows)
            {
                var paymentCollectionId = Convert.ToInt32(item["id"].ToString());
                var isPaymentCollectionHasReport = Factory.CollectorReportRepository().HasGenerated(paymentCollectionId);

                if (isPaymentCollectionHasReport)
                {
                    item.Delete();
                }
            }

            dtPaymentCollection.AcceptChanges();
        }

        private void EnableDisableLocalControls()
        {
            buttonSelectAccess = dtPaymentCollection.Rows.Count != 0;
            btnSelectCollections.Enabled = buttonSelectAccess;
        }

        private void btnSelectCollections_Click(object sender, EventArgs e)
        {
            HelperLoadRecords.PaymentCollectionReportDatagrid(dtPaymentCollection, _uc.dgPayments);
            _uc.TotalCollections();
            this.Close();
        }

        private void frmCollectorsRCDLoad_Load(object sender, EventArgs e)
        {

        }

        private void dtfrom_DateChanged(object sender, DateRangeEventArgs e)
        {
            lblCollectionsFrom.Text = dtfrom.SelectionRange.Start.ToShortDateString();
        }

        private void dtto_DateChanged(object sender, DateRangeEventArgs e)
        {
            lblCollectionsTo.Text = dtto.SelectionRange.Start.ToShortDateString();
        }
    }
}
