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
    public partial class frmReceipts : Form
    {
        public frmReceipts()
        {
            InitializeComponent();
            WindowState = FormWindowState.Normal;
            Helper.LoadFormIcon(this);
            Helper.DatagridDefaultStyle(dgissue);
        }

        private void frmReceipts_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        internal void LoadRecords()
        {
            try
            {
                var riRepository = Factory.ReceiptsIssuedRepository();
                var dtri = riRepository.GetRecords();
                HelperLoadRecords.ReceiptsIssuedDatagridView(dtri,dgissue);

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
                    var riRepository = Factory.ReceiptsIssuedRepository();
                    var dtri = riRepository.GetRecordsBySearch(txtsearch.Text.Trim());
                    HelperLoadRecords.ReceiptsIssuedDatagridView(dtri, dgissue);

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
                btnEdit.Enabled = dgissue.CurrentRow.Cells[8].Value.ToString().Equals("YES") ? false : true;
                btnDelete.Enabled = dgissue.CurrentRow.Cells[8].Value.ToString().Equals("YES") ? false : true;
                btnReturn.Enabled = dgissue.CurrentRow.Cells[8].Value.ToString().Equals("YES") ? false : true;
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
            _ = new frmReceiptsAdd(this,0).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgissue.SelectedRows.Count > 0)
            {
                int id = int.Parse(dgissue.CurrentRow.Cells[0].Value.ToString());
                if (Helper.MessageBoxConfirmDelete(dgissue.SelectedRows.Count))
                {
                    try
                    {
                        var riRepository = Factory.ReceiptsIssuedRepository();
                        var riModel = new List<ReceiptsIssuedModel>();
                        riModel.Add(new ReceiptsIssuedModel() { Id = id });
                        if (riRepository.Delete(riModel))
                        {
                            LoadRecords();
                        }
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
                _ = new frmReceiptsEdit(this, id).ShowDialog();
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
                _ = new frmReturn(this, id).ShowDialog();
            }
        }

        private void dgissue_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           //btnEdit.PerformClick();
        }
    }
}
