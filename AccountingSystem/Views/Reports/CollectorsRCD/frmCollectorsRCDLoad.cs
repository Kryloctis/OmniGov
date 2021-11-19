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

        private bool buttonSelectAccess;

        public frmCollectorsRCDLoad(byte fundId, ushort collectorId)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgPreview, true);

            _fundId = fundId;
            _collectorId = collectorId;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadCollections();
            EnableDisableLocalControls();
        }

        private void LoadCollections()
        {
            var collectionFrom = dtfrom.Value;
            var collectionTo = dtto.Value;

            var parameter = new object[] {
                _collectorId,
                _fundId,
                collectionFrom,
                collectionTo
            };

            var paymentCollectionRepository = Factory.PaymentCollectionRepository().GetRecordByLedger(parameter);
            HelperLoadRecords.CollectionDataGridView(paymentCollectionRepository, dgPreview);
        }

        private void EnableDisableLocalControls()
        {
            buttonSelectAccess = dgPreview.Rows.Count != 0;
            btnSelectCollections.Enabled = buttonSelectAccess;
        }

        private void btnSelectCollections_Click(object sender, EventArgs e)
        {

        }

        private void dgPreview_SelectionChanged(object sender, EventArgs e)
        {

        }

    }
}
