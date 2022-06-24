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
            LoadRecords();
            SetToolStripStatusData();
        }

        internal void LoadRecords()
        {
            try
            {
                var dtReceipts = Factory.ReceiptsRepository().GetRecords();
                HelperLoadRecords.ReceiptsDatagridView(dtReceipts, dgReceipts);
            }
            catch (Exception ex) 
            { 
                Helper.MessageBoxError(ex.Message); 
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var dtReceipts = Factory.ReceiptsRepository().GetRecordsBySearch(txtSearch.Text.Trim());
                HelperLoadRecords.ReceiptsDatagridView(dtReceipts, dgReceipts);
                
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message); 
            }
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
            bool hasIssueance = Factory.ReceiptsIssuedRepository().ReceiptIsUsed(receiptId);
            
            btnDelete.Enabled = !hasIssueance;
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
                var receiptsRepository = Factory.ReceiptsRepository();
                var receiptModel = new List<ReceiptsModel>();

                foreach (DataGridViewRow row in dgReceipts.SelectedRows)
                {
                    int receiptId = int.Parse(row.Cells[0].Value.ToString());

                    var receiptIsUsed = Factory.ReceiptsIssuedRepository().ReceiptIsUsed(receiptId);

                    if (!receiptIsUsed)
                        receiptModel.Add(new ReceiptsModel() { Id = receiptId });
                        
                }
                _ = receiptsRepository.Delete(receiptModel);

                LoadRecords();
            }
        }

    }
}
