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
            Helper.DatagridFullRowSelectStyle(dgReceiptIssued, true );
        }

        private void frmReceipts_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        internal void LoadRecords() 
        {
            try
            {

                var dateIssued = dtpDateIssued.Value.ToString("yyyy-MM-dd");
                var searchText = txtsearch.Text.Trim();
                var receiptIssuedDt = new DataTable();
                var receiptIssuedRepository = AccFactory.ReceiptsIssuedRepository();

                if (cbAll.Checked)
                    receiptIssuedDt = receiptIssuedRepository.GetRecordsBySearch(searchText);
                else
                    receiptIssuedDt = receiptIssuedRepository.GetRecordsBySearch(dateIssued, searchText);

                HelperLoadRecords.ReceiptsIssuedDatagridView(receiptIssuedDt, dgReceiptIssued);
                lblRecordCount.Text = dgReceiptIssued.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message); 
            }
        }


        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            
            LoadRecords();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmReceiptsIssuedAdd(this).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {              
            if (Helper.MessageBoxConfirmDelete(dgReceiptIssued.SelectedRows.Count))
            {
                try
                {
                    var receiptIssuedRepo = AccFactory.ReceiptsIssuedRepository();
                    var receiptModel = new List<ReceiptsIssuedModel>();

                    foreach (DataGridViewRow row in dgReceiptIssued.SelectedRows)
                    {
                        int receiptIssuedId = int.Parse(row.Cells[0].Value.ToString());
                        if (row.Cells[7].Value.ToString().Equals(string.Empty))
                        {
                            receiptModel.Add(new ReceiptsIssuedModel() { Id = receiptIssuedId });
                        }
                    }
                    _ = receiptIssuedRepo.Delete(receiptModel);
                    LoadRecords();
                }
                catch (Exception ex) { 
                    Helper.MessageBoxError(ex.Message); 
                }
            }
        }
        
        private void dgissue_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgReceiptIssued, btnEdit, btnDelete);

            if (dgReceiptIssued.SelectedRows.Count > 0)
            {
                btnEdit.Enabled = string.IsNullOrEmpty(dgReceiptIssued.CurrentRow.Cells[7].Value.ToString());
                btnDelete.Enabled = string.IsNullOrEmpty(dgReceiptIssued.CurrentRow.Cells[7].Value.ToString());
                btnReturn.Enabled = !dgReceiptIssued.CurrentRow.Cells[8].Value.ToString().Equals("Yes") && dgReceiptIssued.SelectedRows.Count == 1;
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnReturn.Enabled = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgReceiptIssued.SelectedRows.Count != 0)
            {
                int id = int.Parse(dgReceiptIssued.CurrentRow.Cells[0].Value.ToString());
                _ = new frmReceiptsIssuedEdit(this, id).ShowDialog();
            }
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

        private void cbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAll.Checked)
                dtpDateIssued.Enabled = false;
            else
                dtpDateIssued.Enabled = true;

            LoadRecords();
        }

    }
}
    