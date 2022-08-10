using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.PaymentCollection
{
    public partial class frmPaymentCollection : Form
    {
        public frmPaymentCollection()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgpayments, true);
        }
        
        private void frmPaymentCollection_Load(object sender, EventArgs e)
        {
            LoadCollectors();
            SelectCurrentLoggedInCollector();
            LoadRecords();
        }

        private void SelectCurrentLoggedInCollector()
        {
            if (cmbCollector.Items.Count == 0) return;

            var usersRepo = AccFactory.UsersRepository();
            Dictionary<string, string> collectorDict = new();

            if (usersRepo.LinkedCollector(Helper.UserId))
            {
                cmbCollector.Enabled = false;
                cbCollectorTypeJO.Enabled = false;

                collectorDict = AccFactory.CollectingOfficerRepository().GetRecordByUserID(Helper.UserId);
                cmbCollector.SelectedValue = collectorDict["id"];
            }

            else if (usersRepo.LinkedJobOrder(Helper.UserId))
            {
                cmbCollector.Enabled = false;
                cbCollectorTypeJO.Enabled = false;
                cbCollectorTypeJO.Checked = true;

                collectorDict = AccFactory.JobOrderRepository().GetRecordByUserID(Helper.UserId);
                cmbCollector.SelectedValue = collectorDict["id"];
            }

            return;
        }

        internal void LoadCollectors()
        {
            try
            {
                DataTable dtCollector;
                var collectingOfficerRepository = AccFactory.CollectingOfficerRepository();
                var collectingOfficerHasJORepo = AccFactory.CollectingOfficerHasJobOrdersRepository();

                if (cbCollectorTypeJO.Checked)
                    dtCollector = collectingOfficerHasJORepo.GetRecords();
                else
                   dtCollector = collectingOfficerRepository.GetRecords();
               
                cmbCollector.DataSource = dtCollector;
                cmbCollector.ValueMember = "id";
                cmbCollector.DisplayMember = "fullname";
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadRecords()
        {
            try
            {
                string date = dtpDate.Value.ToString("yyyy-MM-dd");
                int collectorId = Convert.ToInt32(cmbCollector.SelectedValue);
                string searchKey = txtSearch.Text.Trim();

                var paymentCollectionRepo = AccFactory.PaymentCollectionsRepository();
                var dtpayments  = paymentCollectionRepo.GetRecordsByFilter(date, collectorId, searchKey);

                HelperLoadRecords.PaymentDatagridView(dtpayments, dgpayments);

                SetStatusStrip();
            }
            catch (Exception ex) 
            {
                Helper.MessageBoxError(ex.Message); 
            }
        }

        internal void SetStatusStrip()
        {
            decimal totalCollections = 0.0m;
            int paymentQuantity;

            foreach (DataGridViewRow row in dgpayments.Rows)
                totalCollections += Convert.ToDecimal(row.Cells["amount"].Value);

            paymentQuantity = (short)dgpayments.Rows.Count;
            lblRecordCount.Text = paymentQuantity.ToString();
            txtTotal.Text = totalCollections.ToString("N2");
        }


        #region Form Events
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmPaymentCollectionAdd(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgpayments.SelectedRows.Count == 0) return;

            var dgRowIndex = dgpayments.SelectedCells[0].Value.ToString();
            int paymentCollectionId = int.Parse(dgRowIndex);

            _ = new frmPaymentCollectionEdit(this, paymentCollectionId).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRowCount = dgpayments.SelectedRows.Count;

                if (Helper.MessageBoxConfirmDelete(selectedRowCount))
                {
                    var paymentCollectionModelList = new List<PaymentCollectionsModel>();

                    foreach (DataGridViewRow row in dgpayments.SelectedRows)
                    {
                        int paymentCollectionId = Convert.ToInt32(row.Cells[0].Value.ToString());
                        paymentCollectionModelList.Add(new PaymentCollectionsModel() { Id = paymentCollectionId });
                        var paymentCollectionRepo = AccFactory.PaymentCollectionsRepository().Delete(paymentCollectionModelList);
                    }

                    LoadRecords();
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

        }

        private void cmdCollector_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadRecords();
        }
        private void dtpdate_ValueChanged(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 3 || txtSearch.Text.Length == 0)
                LoadRecords();
        }

        private void dgpayments_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgpayments, btnEdit, btnDelete);

            //int paymentCollectionId = int.Parse(dgpayments.CurrentRow.Cells[0].Value.ToString());
            //btnEdit.Enabled = !Factory.CollectorReportRepository().HasReported(paymentCollectionId);
            //btnDelete.Enabled = !Factory.CollectorReportRepository().HasReported(paymentCollectionId);

        }
        private void cbCollectorType_CheckedChanged(object sender, EventArgs e)
        {
            LoadCollectors();
            LoadRecords();
        }


        #endregion


    }
}
