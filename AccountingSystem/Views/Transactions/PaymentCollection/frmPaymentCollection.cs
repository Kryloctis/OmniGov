using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmPaymentCollectionAdd(this).ShowDialog();
        }
        internal void LoadRecords()
        {
            try
            {
                var pcRepository = Factory.PaymentCollectionRepository();
                var dtpayments = pcRepository.GetRecords();

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
            lblTotalAmount.Text = totalCollections.ToString("N2");
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
            int selectedRowCount = dgpayments.SelectedRows.Count;
            try
            {
                var confirmDelete = Helper.MessageBoxConfirmDelete(selectedRowCount);
                if (confirmDelete)
                {
                    var paymentCollectionModelList = new List<PaymentCollectionModel>();

                    foreach (DataGridViewRow row in dgpayments.SelectedRows)
                    {
                        int pcId = Convert.ToInt32(row.Cells[0].Value.ToString());
                        paymentCollectionModelList.Add(new PaymentCollectionModel() { Id = pcId });

                        var pcRepository = Factory.PaymentCollectionRepository();
                        if (pcRepository.Delete(paymentCollectionModelList))
                        {
                            dgpayments.Rows.RemoveAt(dgpayments.CurrentRow.Index);
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

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (txtsearch.Text.Length > 0)
            {
                try
                {
                    string searchkey = Convert.ToString(txtsearch.Text.Trim());
                    var dtpayments = Factory.PaymentCollectionRepository().GetRecordsBySearch(searchkey);
                    HelperLoadRecords.PaymentDatagridView(dtpayments, dgpayments);

                    lblRecordCount.Text = dgpayments.Rows.Count.ToString();
                }
                catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            }
            else
            {
                LoadRecords();
            }
        }

        private void dgpayments_SelectionChanged(object sender, EventArgs e)
        {
            if(dgpayments.SelectedRows.Count > 0)
            {
                int id = int.Parse(dgpayments.CurrentRow.Cells[0].Value.ToString());
                byte[] columnIndexData = { 11, 12, 13, 14 };
                //Helper.ShowRecordTimestamp(dgpayments, columnIndexData, lblCreatedAt, lblUpdatedAt, lblCreatedBy, lblUpdatedBy);
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
            txtsearch.Text = string.Empty;
            dtpdate.Value = DateTime.Now;
            LoadRecords();
        }

        private void dtpdate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string date = String.Format("{0:yyyy-MM-dd}", dtpdate.Value);
                var dtpayments = Factory.PaymentCollectionRepository().GetRecords(date);
                HelperLoadRecords.PaymentDatagridView(dtpayments, dgpayments);

                lblRecordCount.Text = dgpayments.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

    }
}
