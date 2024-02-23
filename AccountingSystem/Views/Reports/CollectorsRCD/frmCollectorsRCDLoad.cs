using ACC.Data;
using AccountingSystem.Views.Reports.RCDCollector;
using System;
using System.Data;
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                LoadCollections();
                EnableDisableLocalControls();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadCollections()
        {
            var collectionFrom = Convert.ToDateTime(dtfrom.SelectionRange.Start.ToShortDateString());
            var collectionTo = Convert.ToDateTime(dtto.SelectionRange.Start.ToShortDateString());
            var isCollectorJO = _uc.cbJOCollector.Checked;

            var parameter = new object[]
            {
                _collectorId,
                _fundId,
                collectionFrom,
                collectionTo,
                isCollectorJO
            };

            dtPaymentCollection = AccFactory.PaymentCollectionsRepository().GetRecordByLedger(parameter);
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
                var paymentCollectionId = Convert.ToInt32(item["payment_collections_id"].ToString());
                var isPaymentCollectionHasReport = AccFactory.CollectorReportRepository().HasGenerated(paymentCollectionId);

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
            try
            {
                //HelperLoadRecords.PaymentCollectionReportDatagrid(dtPaymentCollection, _uc.dgPayments);
                _uc.TotalCollections();
                Close();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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