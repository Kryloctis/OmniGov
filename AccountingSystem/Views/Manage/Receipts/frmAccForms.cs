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
    public partial class frmAccForms : Form
    {
        public frmAccForms()
        {
            InitializeComponent();
            WindowState = FormWindowState.Normal;
            Helper.LoadFormIcon(this);
            Helper.DatagridDefaultStyle(dgreceipts);
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
                bool issued = rcRepository.HasIssued(id);
                btnEdit.Enabled = issued ? false:true;
                btnDelete.Enabled = issued ? false : true;
                btnissue.Enabled = issued && isconsumed ? false:true;
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnissue.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAccFormsAdd(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgreceipts.SelectedRows.Count > 0)
            {
                int id = int.Parse(dgreceipts.CurrentRow.Cells[0].Value.ToString());
                _ = new frmAccFromEdit(this, id).ShowDialog();                
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgreceipts.SelectedRows.Count > 0)
            {
                int id = int.Parse(dgreceipts.CurrentRow.Cells[0].Value.ToString());
                try
                {
                    if (Helper.MessageBoxConfirmDelete(dgreceipts.SelectedRows.Count))
                    {
                        var rcModel = new List<ReceiptsModel>();
                        rcModel.Add(new ReceiptsModel() { Id = id });
                        var rcRepository = Factory.ReceiptsRepository();
                        if (rcRepository.Delete(rcModel))
                        {
                            LoadRecords();
                        }
                    }
                }
                catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            }
        }

        private void btnissue_Click(object sender, EventArgs e)
        {
            if (dgreceipts.SelectedRows.Count > 0)
            {
                int id = int.Parse(dgreceipts.CurrentRow.Cells[0].Value.ToString());
                frmReceipts frmr = new frmReceipts();
                frmReceiptsAdd frmra = new frmReceiptsAdd(frmr, id);
                frmra.ShowDialog();
            }
        }

        private void dgreceipts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.PerformClick();
        }
    }
}
