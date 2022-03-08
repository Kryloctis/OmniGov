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
            LoadRecords();
            LoadCollectors();
            LoadCurrentCollector();
        }

        private void LoadCurrentCollector()
        {
            try
            {
                if (cmdCollector.Items.Count > 0)
                {
                    var uRepository = Factory.UsersRepository();
                    if (uRepository.LinkedCollector(Helper.UserId))
                    {
                        var colRepository = Factory.CollectingOfficerRepository();
                        var data = colRepository.GetRecordByUserID(Helper.UserId);
                        cmdCollector.SelectedValue = data["id"];
                        cmdCollector.Enabled = false;

                    }
                    else 
                    {
                        cmdCollector.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal void LoadCollectors()
        {
            try
            {
                var collectingOfficerRepository = Factory.CollectingOfficerRepository();
                var collectingOfficerHasJORepo = Factory.CollectingOfficerHasJobOrdersRepository();

                DataTable dtCollectors = new();
                var dtJOCollectors = collectingOfficerHasJORepo.GetRecords();
                var dtRegularCollectors = collectingOfficerRepository.GetRecords();

                dtRegularCollectors.Merge(dtJOCollectors);
                dtCollectors = dtRegularCollectors;

                cmdCollector.DataSource = dtCollectors;
                cmdCollector.ValueMember = "id";
                cmdCollector.DisplayMember = "fullname";
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmPaymentCollectionAdd(this).ShowDialog();
        }

        internal void LoadRecords()
        {
            try
            {
                string date = dtpDate.Value.ToString("yyyy-MM-dd");
                int collectorId = Convert.ToInt32(cmdCollector.SelectedValue);
                string searchKey = txtSearch.Text.Trim();

                var paymentCollectionRepo = Factory.PaymentCollectionRepository();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgpayments.SelectedRows.Count != 0) 
            {
                var dgRowIndex = dgpayments.SelectedCells[0].Value.ToString();
                int paymentCollectionId = int.Parse(dgRowIndex);

                _ = new frmPaymentCollectionEdit(this, paymentCollectionId).ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRowCount = dgpayments.SelectedRows.Count;
                var confirmDelete = Helper.MessageBoxConfirmDelete(selectedRowCount);

                if (confirmDelete)
                {
                    var paymentCollectionModelList = new List<PaymentCollectionModel>();

                    foreach (DataGridViewRow row in dgpayments.SelectedRows)
                    {
                        int pcId = Convert.ToInt32(row.Cells[0].Value.ToString());
                        paymentCollectionModelList.Add(new PaymentCollectionModel() { Id = pcId });

                        var paymentCollectionRepo = Factory.PaymentCollectionRepository();
                        if (paymentCollectionRepo.Delete(paymentCollectionModelList))
                        {
                            LoadRecords();
                            lblRecordCount.Text = dgpayments.Rows.Count.ToString();
                        }
                    }
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
            if(dgpayments.SelectedRows.Count > 0)
            {
                int id = int.Parse(dgpayments.CurrentRow.Cells[0].Value.ToString());
                Helper.EnableDisableToolStripButtons(dgpayments, btnEdit, btnDelete);

                var crRepository = Factory.CollectorReportRepository();

                btnEdit.Enabled = crRepository.HasReported(id) ? false : true;
                btnDelete.Enabled = crRepository.HasReported(id) ? false : true;
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            dtpDate.Value = DateTime.Now;
        }

    }
}
