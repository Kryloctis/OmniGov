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
            WindowState = FormWindowState.Normal;
            Helper.LoadFormIcon(this);
            Helper.DatagridDefaultStyle(dgpayments);
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

                lblRecordCount.Text = pcRepository.CountRecords().ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgpayments.Rows.Count > 0 && dgpayments.SelectedRows.Count > 0)
            {
                int Id = int.Parse(dgpayments.SelectedCells[0].Value.ToString());
                _ = new frmPaymentCollectionEdit(this, Id).ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedrowscount = dgpayments.SelectedRows.Count;
            try
            {
                if (selectedrowscount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedrowscount))
                    {
                        var pcModelList = new List<PaymentCollectionModel>();
                        foreach (DataGridViewRow row in dgpayments.SelectedRows)
                        {
                            int pcId = Convert.ToInt16(row.Cells[0].Value.ToString());
                            pcModelList.Add(new PaymentCollectionModel() { Id = pcId });
                        }

                        var pcRepository = Factory.PaymentCollectionRepository();
                        _ = pcRepository.Delete(pcModelList);
                        LoadRecords();
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
            byte[] columnIndexData = { 11,12,13,14 };
            Helper.ShowRecordTimestamp(dgpayments, columnIndexData, lblCreatedAt, lblUpdatedAt,lblCreatedBy,lblUpdatedBy);
            Helper.EnableDisableToolStripButtons(dgpayments, btnEdit, btnDelete);
        }
    }
}
