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
                var receiptIssuedRepository = Factory.ReceiptsIssuedRepository();
                var receiptIssuedDt = receiptIssuedRepository.GetRecords();

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
            if(txtsearch.Text.Length > 0)
            {
                try
                {
                    var receiptIssuedRepository = Factory.ReceiptsIssuedRepository();
                    var receiptIssuedDt = receiptIssuedRepository.GetRecordsBySearch(txtsearch.Text.Trim());

                    HelperLoadRecords.ReceiptsIssuedDatagridView(receiptIssuedDt, dgReceiptIssued);

                    lblRecordCount.Text = dgReceiptIssued.Rows.Count.ToString();
                }
                catch (Exception ex) 
                { 
                    Helper.MessageBoxError(ex.Message); 
                }
            }
            else
            {
                LoadRecords();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtsearch.Text = string.Empty;
            LoadRecords();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmReceiptsIssuedAdd(this, 0).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {              
            if (Helper.MessageBoxConfirmDelete(dgReceiptIssued.SelectedRows.Count))
            {
                try
                {
                    var receiptIssuedRepo = Factory.ReceiptsIssuedRepository();
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
            if (dgReceiptIssued.SelectedRows.Count > 0)
            {
                Helper.EnableDisableToolStripButtons(dgReceiptIssued, btnEdit, btnDelete);
              
                btnEdit.Enabled = string.IsNullOrEmpty(dgReceiptIssued.CurrentRow.Cells[7].Value.ToString());
                btnDelete.Enabled = string.IsNullOrEmpty(dgReceiptIssued.CurrentRow.Cells[7].Value.ToString());
                btnReturn.Enabled = !dgReceiptIssued.CurrentRow.Cells[8].Value.ToString().Equals("Yes");
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgReceiptIssued.SelectedRows.Count > 0)
            {
                int id = int.Parse(dgReceiptIssued.CurrentRow.Cells[0].Value.ToString());
                _ = new frmReceiptsIssuedEdit(this, id).ShowDialog();
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if(dgReceiptIssued.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgReceiptIssued.CurrentRow.Cells[0].Value.ToString());
                int receiptNumberFrom = Convert.ToInt32(string.IsNullOrEmpty(dgReceiptIssued.CurrentRow.Cells[7].Value.ToString()) ? dgReceiptIssued.CurrentRow.Cells[3].Value.ToString() : (dgReceiptIssued.CurrentRow.Cells[7].Value).ToString()) + 1;

                int receiptNumberTo = Convert.ToInt32(string.IsNullOrEmpty(dgReceiptIssued.CurrentRow.Cells[4].Value.ToString()) ? 0 : dgReceiptIssued.CurrentRow.Cells[4].Value.ToString());

               
                _ = new frmReturnReceipts(this, id, receiptNumberFrom, receiptNumberTo).ShowDialog();
            }
        }
    }
}
