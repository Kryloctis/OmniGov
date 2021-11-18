using ACC.Domain.Models;
using AccountingSystem.Views.Transactions.ReceiptsIssued;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Receipts
{
    public partial class frmReceipts : Form
    {
        public frmReceipts()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgreceipts, true);
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
                HelperLoadRecords.ReceiptsDatagridView(dtreceipts, dgreceipts);

                lblRecordCount.Text = dgreceipts.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtsearch.Text = string.Empty;
            LoadRecords();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if(txtsearch.Text.Length > 0)
            {
                try
                {
                    var rcRepository = Factory.ReceiptsRepository();
                    var dtreceipts = rcRepository.GetRecordsBySearch(txtsearch.Text.Trim());
                    HelperLoadRecords.ReceiptsDatagridView(dtreceipts, dgreceipts);

                    lblRecordCount.Text = dgreceipts.Rows.Count.ToString();
                }
                catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            }
            else
            {
                LoadRecords();
            }
        }

        private void dgreceipts_SelectionChanged(object sender, EventArgs e)
        {
            if(dgreceipts.SelectedRows.Count > 0)
            {
                Helper.EnableDisableToolStripButtons(dgreceipts, btnEdit, btnDelete);
                int id = int.Parse(dgreceipts.CurrentRow.Cells[0].Value.ToString());
                var rRepository = Factory.ReceiptsRepository();
                var rcRepository = Factory.ReceiptsIssuedRepository();
                bool isconsumed = rRepository.ReceiptConsumed(id);                
                bool issued = rRepository.AllowEdit(id);
                btnEdit.Enabled = issued ? false:true;
                btnDelete.Enabled = issued ? false : true;
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
            if(dgreceipts.SelectedRows.Count > 0)
            {
                int id = int.Parse(dgreceipts.CurrentRow.Cells[0].Value.ToString());
                _ = new frmReceiptsEdit(this, id).ShowDialog();                
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgreceipts.SelectedRows.Count > 0)
            {                
                try
                {
                    if (Helper.MessageBoxConfirmDelete(dgreceipts.SelectedRows.Count))
                    {
                        var rcRepository = Factory.ReceiptsRepository();
                        var rcModel = new List<ReceiptsModel>();
                        foreach (DataGridViewRow row in dgreceipts.SelectedRows)
                        {
                            int id = int.Parse(row.Cells[0].Value.ToString());
                            if (!rcRepository.ReceiptsIssued(id))
                            {
                                rcModel.Add(new ReceiptsModel() { Id = id });
                            }
                        }
                        _ = rcRepository.Delete(rcModel);
                        LoadRecords();
                    }
                }
                catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            }
        }


        private void dgreceipts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.PerformClick();
        }
    }
}
