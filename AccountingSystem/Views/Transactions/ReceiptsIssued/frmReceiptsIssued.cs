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

namespace AccountingSystem.Views.Transactions.ReceiptsIssued
{
    public partial class frmReceiptsIssued : Form
    {
        public frmReceiptsIssued()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgissue, true );
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

                HelperLoadRecords.ReceiptsIssuedDatagridView(receiptIssuedDt, dgissue);

                lblRecordCount.Text = dgissue.Rows.Count.ToString();
            }   
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if(txtsearch.Text.Length > 0)
            {
                try
                {
                    var receiptIssuedRepository = Factory.ReceiptsIssuedRepository();
                    var receiptIssuedDt = receiptIssuedRepository.GetRecordsBySearch(txtsearch.Text.Trim());

                    HelperLoadRecords.ReceiptsIssuedDatagridView(receiptIssuedDt, dgissue);

                    lblRecordCount.Text = dgissue.Rows.Count.ToString();
                }
                catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
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

        private void dgissue_SelectionChanged(object sender, EventArgs e)
        {
            if(dgissue.SelectedRows.Count > 0)
            {
                Helper.EnableDisableToolStripButtons(dgissue, btnEdit, btnDelete);
                int id = int.Parse(dgissue.CurrentRow.Cells[0].Value.ToString());
                var riRepository = Factory.ReceiptsIssuedRepository();
                btnEdit.Enabled = dgissue.CurrentRow.Cells[7].Value.ToString().Equals("YES") ? false : true;
                btnDelete.Enabled = dgissue.CurrentRow.Cells[7].Value.ToString().Equals("YES") ? false : true;
                btnReturn.Enabled = dgissue.CurrentRow.Cells[7].Value.ToString().Equals("YES") ? false : true;
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnReturn.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmReceiptsIssuedAdd(this, 0).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgissue.SelectedRows.Count > 0)
            {                
                if (Helper.MessageBoxConfirmDelete(dgissue.SelectedRows.Count))
                {
                    try
                    {
                        var riRepository = Factory.ReceiptsIssuedRepository();
                        var riModel = new List<ReceiptsIssuedModel>();
                        foreach (DataGridViewRow row in dgissue.SelectedRows)
                        {
                            int id = int.Parse(row.Cells[0].Value.ToString());
                            if (row.Cells[7].Value.ToString().Equals(string.Empty))
                            {
                                riModel.Add(new ReceiptsIssuedModel() { Id = id });
                            }                                                 
                        }
                        _ = riRepository.Delete(riModel);
                        LoadRecords();
                    }
                    catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgissue.SelectedRows.Count > 0)
            {
                int id = int.Parse(dgissue.CurrentRow.Cells[0].Value.ToString());
                _ = new frmReceiptsIssuedEdit(this, id).ShowDialog();
            }
        }

        private void dgissue_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.PerformClick();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if(dgissue.SelectedRows.Count > 0)
            {
                int id = int.Parse(dgissue.CurrentRow.Cells[0].Value.ToString());
                _ = new frmReturnReceipts(this, id).ShowDialog();
            }
        }

        private void dgissue_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           //btnEdit.PerformClick();
        }
    }
}
