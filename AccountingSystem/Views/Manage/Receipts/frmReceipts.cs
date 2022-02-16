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
        }

        internal void LoadRecords()
        {
            try
            {
                var rcRepository = Factory.ReceiptsRepository();
                var dtreceipts = rcRepository.GetRecords();

                HelperLoadRecords.ReceiptsDatagridView(dtreceipts, dgReceipts);
            }
            catch (Exception ex) 
            { 
                Helper.MessageBoxError(ex.Message); 
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtsearch.Text = string.Empty;
            LoadRecords();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var rcRepository = Factory.ReceiptsRepository();
                var dtreceipts = rcRepository.GetRecordsBySearch(txtsearch.Text.Trim());
                HelperLoadRecords.ReceiptsDatagridView(dtreceipts, dgReceipts);

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
            if(dgReceipts.SelectedRows.Count > 0)
            {
                Helper.EnableDisableToolStripButtons(dgReceipts, btnEdit, btnDelete);

                int id = int.Parse(dgReceipts.CurrentRow.Cells[0].Value.ToString());
                var rRepository = Factory.ReceiptsRepository();

                
                var rcRepository = Factory.ReceiptsIssuedRepository();
                bool isconsumed = rRepository.ReceiptConsumed(id);                
                bool issued = rRepository.AllowEdit(id);

                //btnEdit.Enabled = issued ? false : true;
                //btnDelete.Enabled = issued ? false : true;

                SetToolStripStatusData();
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmReceiptsAdd(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgReceipts.SelectedRows.Count > 0)
            {
                int receiptId = int.Parse(dgReceipts.CurrentRow.Cells[0].Value.ToString());
                _ = new frmReceiptsEdit(this, receiptId).ShowDialog();                
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Helper.MessageBoxConfirmDelete(dgReceipts.SelectedRows.Count))
                {
                    var receiptsRepository = Factory.ReceiptsRepository();
                    var receiptModel = new List<ReceiptsModel>();

                    foreach (DataGridViewRow row in dgReceipts.SelectedRows)
                    {
                        int id = int.Parse(row.Cells[0].Value.ToString());

                        if (!receiptsRepository.ReceiptsIssued(id))
                            receiptModel.Add(new ReceiptsModel() { Id = id });
                        
                    }
                    _ = receiptsRepository.Delete(receiptModel);

                    LoadRecords();
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message); 
            }
        }

    }
}
