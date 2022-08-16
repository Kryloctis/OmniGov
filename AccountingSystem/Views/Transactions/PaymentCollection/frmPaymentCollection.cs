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
            LoadPaymentCollections();
        }


        internal void SelectCurrentLoggedInCollector()
        {
            var usersRepo = AccFactory.UsersRepository();

            if (usersRepo.LinkedCollector(Helper.UserId))
            {
                cbCollectorTypeJO.Enabled = false;
                cmbCollector.Enabled = false;
                cmbCollector.SelectedValue = AccFactory.CollectingOfficerRepository().GetRecordByUserID(Helper.UserId)["id"];
                return;
            }
            else if (usersRepo.LinkedJobOrder(Helper.UserId))
            {
                cbCollectorTypeJO.Checked = true;
                cbCollectorTypeJO.Enabled = false;
                cmbCollector.Enabled = false;
                cmbCollector.SelectedValue = AccFactory.JobOrderRepository().GetRecordByUserID(Helper.UserId)["id"];
            }
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


                HelperLoadRecords.CollectingOfficerComboBox(dtCollector, cmbCollector, "fullname", "id");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadPaymentCollections()
        {
            try
            {
                string date = dtpDate.Value.ToString("yyyy-MM-dd");
                int collectingOfficerID = Convert.ToInt32(cmbCollector.SelectedValue);
                string searchKey = txtSearch.Text.Trim();
                bool isJobOrder = cbCollectorTypeJO.Checked;

                var paymentCollectionRepo = AccFactory.PaymentCollectionsRepository();
                var dtpayments  = paymentCollectionRepo.FilterRecords(date, collectingOfficerID, isJobOrder, searchKey);

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
                    var GeneralPaymentsModelList = new List<GeneralPaymentsModel>();

              
                    foreach (DataGridViewRow row in dgpayments.SelectedRows)
                    {
                        int paymentCollectionId = Convert.ToInt32(row.Cells[0].Value.ToString());
                        paymentCollectionModelList.Add(new PaymentCollectionsModel() { Id = paymentCollectionId });
                        GeneralPaymentsModelList.Add(new GeneralPaymentsModel() { PaymentCollectionId = paymentCollectionId });

                        AccFactory.GeneralPaymentRepository().Delete(GeneralPaymentsModelList);
                        var paymentCollectionRepo = AccFactory.PaymentCollectionsRepository().Delete(paymentCollectionModelList);
                    }

                    Helper.MessageBoxSuccess("Payment Collection Deleted.");
                    LoadPaymentCollections();
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError("Record cannot be deleted.");
            }

        }

        private void cmdCollector_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadPaymentCollections();
        }
        private void dtpdate_ValueChanged(object sender, EventArgs e)
        {
            LoadPaymentCollections();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 3 || txtSearch.Text.Length == 0)
                LoadPaymentCollections();
        }

        private void dgpayments_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgpayments, btnEdit, btnDelete);
        }
        private void cbCollectorType_CheckedChanged(object sender, EventArgs e)
        {
            LoadCollectors();
            LoadPaymentCollections();
        }



        #endregion

     
    }
}
