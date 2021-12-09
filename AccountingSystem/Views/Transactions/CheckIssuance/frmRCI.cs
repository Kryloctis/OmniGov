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

namespace AccountingSystem.Views.Transactions.RCI
{
    public partial class frmRCI : Form
    {
        public frmRCI()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgRCI, true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmRCIAdd(this).ShowDialog();
        }

        private void frmRCI_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        internal void LoadRecords()
        {
            try
            {
                var rciRepository = Factory.RCIRepository();
                var dtRCI = rciRepository.GetRecords();
                HelperLoadRecords.RCIDatagridView(dtRCI, dgRCI);

                lblRecordCount.Text = rciRepository.CountRecords().ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgRCI.Rows.Count > 0 && dgRCI.SelectedRows.Count > 0)
            {
                int rciId = int.Parse(dgRCI.SelectedCells[0].Value.ToString());
                _ = new frmRCIEdit(this, rciId).ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedrowscount = dgRCI.SelectedRows.Count;
            try
            {
                if (selectedrowscount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedrowscount))
                    {
                        var rciModelList = new List<RCIModel>();
                        foreach (DataGridViewRow row in dgRCI.SelectedRows)
                        {
                            int rciId = Convert.ToInt16(row.Cells[0].Value.ToString());
                            rciModelList.Add(new RCIModel() { Id = rciId });
                        }

                        var rciRepository = Factory.RCIRepository();
                        _ = rciRepository.Delete(rciModelList);
                        LoadRecords();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (txtsearch.Text.Length > 0)
            {
                try
                {
                    string searchkey = Convert.ToString(txtsearch.Text.Trim());
                    var dtRCI = Factory.RCIRepository().GetRecordsBySearch(searchkey);
                    HelperLoadRecords.BanksDatagridView(dtRCI, dgRCI);

                    lblRecordCount.Text = dgRCI.Rows.Count.ToString();
                }
                catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            }
            else
            {
                LoadRecords();
            }
        }

        private void dgRCI_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 13, 14 };
            Helper.ShowRecordTimestamp(dgRCI, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgRCI, btnEdit, btnDelete);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRecords();
        }
    }
}
