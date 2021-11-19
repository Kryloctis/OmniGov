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

        public frmCollectorsRCDLoad(byte fundId, ushort collectorId, ucCollectorsRCD uc)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgPreview, true);


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

            var dtPaymentCollection = Factory.PaymentCollectionRepository().GetRecordByLedger(parameter);
            HelperLoadRecords.CollectionDataGridView(dtPaymentCollection, dgPreview);
        }

        private void EnableDisableLocalControls()
        {
            buttonSelectAccess = dgPreview.Rows.Count != 0;
            btnSelectCollections.Enabled = buttonSelectAccess;
        }

        private void btnSelectCollections_Click(object sender, EventArgs e)
        {

            DataTable dtPaymentCollection = new();

            dtPaymentCollection.Columns.Add("Payment Collection ID");
            dtPaymentCollection.Columns.Add("Fund Id");
            dtPaymentCollection.Columns.Add("Fund");
            dtPaymentCollection.Columns.Add("Accountable Form ID");
            dtPaymentCollection.Columns.Add("Accountable Form");
            dtPaymentCollection.Columns.Add( "Abstract Of General Collection ID");
            dtPaymentCollection.Columns.Add("Abstract Of General Collection");
            dtPaymentCollection.Columns.Add("Payee");
            dtPaymentCollection.Columns.Add("Receipt No.");
            dtPaymentCollection.Columns.Add("Quantity");
            dtPaymentCollection.Columns.Add("Payment Date");
            dtPaymentCollection.Columns.Add("Amount");
            dtPaymentCollection.Columns.Add("Created at");
            dtPaymentCollection.Columns.Add("Created by");
            dtPaymentCollection.Columns.Add("Updated at");
            dtPaymentCollection.Columns.Add("Updated by");

            foreach (DataGridViewRow row in dgPreview.Rows)
            {
                string paymentCollectionId = row.Cells["payment_collection_id"].Value.ToString();
                string fundId = row.Cells["fund_id"].Value.ToString();
                string fund = row.Cells["fund"].Value.ToString();
                string accountableFormId = row.Cells["accountable_form_id"].Value.ToString();
                string accountableForm = row.Cells["accountable_form"].Value.ToString();
                string abstractOfGeneralCollectionId = row.Cells["abstract_of_general_collection_id"].Value.ToString();
                string abstractOfGeneralCollection = row.Cells["abstract_of_general_collection"].Value.ToString();
                string payee = row.Cells["payee"].Value.ToString();
                string receiptNo = row.Cells["receipt_no"].Value.ToString();
                string quantity = row.Cells["quantity"].Value.ToString();
                string paymentDate = row.Cells["payment_date"].Value.ToString();
                string amount = row.Cells["amount"].Value.ToString();
                string createdAt = row.Cells["created_at"].Value.ToString();
                string createdBy = row.Cells["created_by"].Value.ToString();
                string updatedAt = row.Cells["updated_at"].Value.ToString();
                string updatedBy = row.Cells["updated_by"].Value.ToString();


                object[] columns = {
                    paymentCollectionId,
                    fundId,
                    fund,
                    accountableFormId,
                    accountableForm,
                    abstractOfGeneralCollectionId,
                    abstractOfGeneralCollection,
                    payee,
                    receiptNo,
                    quantity,
                    paymentDate,
                    amount,
                    createdAt,
                    createdBy,
                    updatedAt,
                    updatedBy,
                };


                dtPaymentCollection.Rows.Add(columns);
            }

            _uc.dgvpayments.DataSource = dtPaymentCollection;

        }
        private void dgPreview_SelectionChanged(object sender, EventArgs e)
        {

        }

    }
}
