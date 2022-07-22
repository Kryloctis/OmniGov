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

namespace AccountingSystem.Views.Manage.RptDiscount
{
    public partial class frmRptDiscounts : Form
    {
        private readonly MainForm _mainForm;

        public frmRptDiscounts(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);
        }

        internal void LoadDiscounts()
        {
            string searchText = txtSearch.Text.Trim();

            if (searchText.Length < 2)
            {
                var dt = AccFactory.rptDiscountRepository().GetRecords();
                HelperLoadRecords.DiscountsDatagridView(dataGridView1, dt);
            }
            else
            {
                var dt = AccFactory.rptDiscountRepository().GetRecordsBySearch(searchText);
                HelperLoadRecords.DiscountsDatagridView(dataGridView1, dt);
            }
        }

        private void frmRptDiscount_Load(object sender, EventArgs e)
        {
            LoadDiscounts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddRptDiscount(this).ShowDialog();
        }

        private void ShowEditRptDiscounts() 
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            int rptDiscountId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["id"].Value);

            _ = new frmEditRptDiscounts(rptDiscountId, this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShowEditRptDiscounts();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDiscounts();
        }

        private bool Delete(out int deletedCount)
        {
            try
            {
                var rptDiscountsModelList = new List<RptDiscountsModel>();
                int rowCount = dataGridView1.SelectedRows.Count;

                if (Helper.MessageBoxConfirmDelete(rowCount))
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        int discountsId = Convert.ToInt32(row.Cells["id"].Value);
                        var model = new RptDiscountsModel() { Id = discountsId };
                        rptDiscountsModelList.Add(model);
                    }

                    deletedCount = rowCount;
                    return AccFactory.rptDiscountRepository().Delete(rptDiscountsModelList);
                }

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            deletedCount = 0;
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int deletedRecordCount;

            if (Delete(out deletedRecordCount))
            {
                Helper.MessageBoxSuccess($"{deletedRecordCount} record/s has been deleted.");
                LoadDiscounts();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }
    }
}
