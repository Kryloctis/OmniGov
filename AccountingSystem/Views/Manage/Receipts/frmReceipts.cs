using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Receipts
{
    public partial class frmReceipts : Form
    {
        public frmReceipts()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgReceipts, true);
        }

        private void frmAccForms_Load(object sender, EventArgs e)
        {
            LoadRecordsBySearch();
            SetToolStripStatusData();
        }

        internal void LoadRecords()
        {
            try
            {
                var dtReceipts = AccFactory.ReceiptsRepository().GetRecords();
                HelperLoadRecords.ReceiptsDatagridView(dtReceipts, dgReceipts);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadRecordsBySearch()
        {
            try
            {
                var dateReceived = dtpReceivedDate.Value.ToString("yyyy-MM-dd");
                var searchKey = txtSearch.Text.Trim();

                var dtReceipts = AccFactory.ReceiptsRepository().GetRecordsByDateAndText(dateReceived, searchKey);
                HelperLoadRecords.ReceiptsDatagridView(dtReceipts, dgReceipts);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 3 || txtSearch.Text.Length == 0)
                LoadRecordsBySearch();

            return;
        }

        private void SetToolStripStatusData()
        {
            var quantity = (from DataGridViewRow row in dgReceipts.Rows
                            where !String.IsNullOrEmpty(row.Cells["quantity"].FormattedValue.ToString())
                            select Convert.ToDecimal(row.Cells["quantity"].FormattedValue)).Sum().ToString();

            lblRecordCount.Text = dgReceipts.Rows.Count.ToString();
            lblQuantity.Text = quantity;
        }

        private void dgreceipts_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgReceipts, btnEdit, btnDelete);

            int receiptId = Convert.ToInt32(dgReceipts.CurrentRow.Cells[0].Value);
            bool hasIssueance = AccFactory.ReceiptsIssuedRepository().ReceiptIsUsed(receiptId);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmReceiptsAdd(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int receiptId = int.Parse(dgReceipts.CurrentRow.Cells[0].Value.ToString());
            _ = new frmReceiptsEdit(this, receiptId).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Helper.MessageBoxConfirmDelete(dgReceipts.SelectedRows.Count))
            {
                var receiptsRepository = AccFactory.ReceiptsRepository();
                var receiptModel = new List<ReceiptsModel>();

                foreach (DataGridViewRow row in dgReceipts.SelectedRows)
                {
                    int receiptId = int.Parse(row.Cells[0].Value.ToString());

                    var receiptIsUsed = AccFactory.ReceiptsIssuedRepository().ReceiptIsUsed(receiptId);

                    if (!receiptIsUsed)
                        receiptModel.Add(new ReceiptsModel() { Id = receiptId });
                }
                _ = receiptsRepository.Delete(receiptModel);

                LoadRecordsBySearch();
                Helper.MessageBoxSuccess("Receipt successfullt deleted.");
            }
        }

        private void dtpReceivedDate_ValueChanged(object sender, EventArgs e)
        {
            LoadRecordsBySearch();
        }
    }
}