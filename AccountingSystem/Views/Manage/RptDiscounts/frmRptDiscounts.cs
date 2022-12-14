using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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

        private string MonthToName(int month)
        {
            switch (month)
            {
                case 1:
                    return "January";

                case 2:
                    return "February";

                case 3:
                    return "March";

                case 4:
                    return "April";

                case 5:
                    return "May";

                case 6:
                    return "June";

                case 7:
                    return "July";

                case 8:
                    return "August";

                case 9:
                    return "September";

                case 10:
                    return "October";

                case 11:
                    return "November";

                case 12:
                    return "December";

                default:
                    return string.Empty;
            }
        }

        private DataTable DataTableDiscounts()
        {
            DataTable dtRptDiscounts;
            var dataTable = new DataTable();
            dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns.Add("month", typeof(int));
            dataTable.Columns.Add("month_name", typeof(string));
            dataTable.Columns.Add("description", typeof(string));
            dataTable.Columns.Add("rate", typeof(decimal));
            dataTable.Columns.Add("is_advance", typeof(Image));

            string searchText = txtSearch.Text.Trim();

            if (searchText.Length < 2)
                dtRptDiscounts = AccFactory.RptDiscountRepository().GetRecords();
            else
                dtRptDiscounts = AccFactory.RptDiscountRepository().GetRecordsBySearch(searchText);

            foreach (DataRow row in dtRptDiscounts.Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                int month = Convert.ToInt32(row["month"]);
                string montName = MonthToName(month);
                string description = row["description"].ToString();
                decimal rate = Convert.ToDecimal(row["rate"]);
                bool isAdvance = Convert.ToBoolean(row["is_advance"]);
                Image isAdvanceImg = isAdvance ? Properties.Resources.ok14px : null;

                dataTable.Rows.Add(id, month, montName, description, rate, isAdvanceImg);
            }

            return dataTable;
        }

        internal void LoadDiscounts()
        {
            try
            {
                HelperLoadRecords.DiscountsDatagridView(dataGridView1, DataTableDiscounts());
                lblRecordCount.Text = dataGridView1.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
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

            _ = new frmEditRptDiscount(rptDiscountId, this).ShowDialog();
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
                    return AccFactory.RptDiscountRepository().Delete(rptDiscountsModelList);
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDiscounts();
        }
    }
}