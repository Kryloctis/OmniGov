using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.ReceiptsIssued
{
    public partial class frmReceiptsIssued : Form
    {
        public frmReceiptsIssued()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgReceiptIssued, false);
        }

        private void frmReceipts_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        internal void LoadRecords()
        {
            try
            {
                DateTime dateIssued = dtpDateIssued.Value;
                string searchText = txtsearch.Text.Trim();

                DataTable dtReceiptIssued = new();
                var receiptIssuedRepository = AccFactory.ReceiptsIssuedRepository();

                dtReceiptIssued = receiptIssuedRepository.GetRecordsBySearch(dateIssued, searchText);

                HelperLoadRecords.ReceiptsIssuedDatagridView(dtReceiptIssued, dgReceiptIssued);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            int textSearchLength = txtsearch.Text.Length;
            if (textSearchLength > 3 || textSearchLength == 0)
                LoadRecords();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmReceiptsIssuedAdd(this).ShowDialog();
        }

        private bool DeleteRecords()
        {
            int selectedRowsCount = dgReceiptIssued.SelectedRows.Count;

            if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
            {
                var receiptModelList = new List<ReceiptsIssuedModel>();

                foreach (DataGridViewRow row in dgReceiptIssued.SelectedRows)
                {
                    int receiptIssuedId = Convert.ToInt32(row.Cells["id"].Value);
                    receiptModelList.Add(new ReceiptsIssuedModel() { Id = receiptIssuedId });
                }

                return AccFactory.ReceiptsIssuedRepository().Delete(receiptModelList);
            }
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteRecords())
                {
                    LoadRecords();
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void ShowRecordTimeStamp(DataGridView dataGridView)
        {
            if (dataGridView.SelectedRows.Count == 1 && dataGridView.CurrentRow.Cells["id"].Value != null)
            {
                int rowIndex = dataGridView.CurrentCell.RowIndex;

                //var createdAt = dataGridView.Rows[rowIndex].Cells["created_at"].Value.ToString();
                //var updatedAt = dataGridView.Rows[rowIndex].Cells["updated_at"].Value.ToString();

                //lblCreatedAt.Text = createdAt;
                //lblUpdatedAt.Text = updatedAt;
            }
        }

        private void dgissue_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgReceiptIssued, btnEdit, btnDelete);
            ShowRecordTimeStamp(dgReceiptIssued);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int receiptIssuedID = Convert.ToInt32(dgReceiptIssued.CurrentRow.Cells["id"].Value);
            _ = new frmReceiptsIssuedEdit(this, receiptIssuedID).ShowDialog();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            int issuanceId = Convert.ToInt32(dgReceiptIssued.CurrentRow.Cells["id"].Value);
            int lastIssued = string.IsNullOrEmpty(dgReceiptIssued.CurrentRow.Cells["last_issued"].Value.ToString()) ? 0 : Convert.ToInt32(dgReceiptIssued.CurrentRow.Cells["last_issued"].Value);

            int issuedSerialNoFrom = string.IsNullOrEmpty(dgReceiptIssued.CurrentRow.Cells["serial_number_from"].ToString()) ? 0 : Convert.ToInt32(dgReceiptIssued.CurrentRow.Cells["serial_number_from"].Value);

            int returnSerialNoFrom = lastIssued == 0 ? issuedSerialNoFrom : lastIssued + 1;
            int returnSerialNoTo = string.IsNullOrEmpty(dgReceiptIssued.CurrentRow.Cells["serial_number_to"].ToString()) ? 0 : Convert.ToInt32(dgReceiptIssued.CurrentRow.Cells["serial_number_to"].Value);

            _ = new frmReturnReceipts(this, issuanceId, returnSerialNoFrom, returnSerialNoTo).ShowDialog();
        }

        private void dtpEndingDate_ValueChanged(object sender, EventArgs e)
        {
            LoadRecords();
        }

    }
}