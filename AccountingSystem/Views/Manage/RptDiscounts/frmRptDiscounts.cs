using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Dashboard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        internal void LoadDiscounts()
        {
            if (!backgroundWorker1.IsBusy)
            {
                pbLoadRecords.Value = 0;
                string searchText = txtSearch.Text.Trim();
                backgroundWorker1.RunWorkerAsync(searchText);
            }
        }

        private void frmRptDiscount_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDiscounts();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmAddRptDiscount(this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ShowEditRptDiscounts()
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            int rptDiscountId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["id"].Value);

            _ = new frmEditRptDiscount(rptDiscountId, this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ShowEditRptDiscounts();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool Delete(out int deletedCount)
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

            deletedCount = 0;
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int deletedRecordCount;

                if (Delete(out deletedRecordCount))
                {
                    Helper.MessageBoxSuccess($"{deletedRecordCount} record/s has been deleted.");
                    LoadDiscounts();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDiscounts();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private DataColumn[] DiscountsDataColumns()
        {
            return new DataColumn[]
            {
                new DataColumn(Name = "id", typeof(int)),
                new DataColumn(Name = "month", typeof(int)),
                new DataColumn(Name = "month_name", typeof(string)),
                new DataColumn(Name = "description", typeof(string)),
                new DataColumn(Name = "rate", typeof(decimal)),
                new DataColumn(Name = "is_advance", typeof(bool))
            };
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string searchText = e.Argument as string;

                DataTable dtRptDiscounts = AccFactory.RptDiscountRepository().GetRecordsBySearch(searchText);
                var dataTable = new DataTable();
                dataTable.Columns.AddRange(DiscountsDataColumns());

                if (dtRptDiscounts.Rows.Count < 1)
                {
                    e.Result = dataTable;
                    backgroundWorker1.ReportProgress(100);
                    return;
                }

                int totalProgressCount = dtRptDiscounts.Rows.Count;
                int progressCount = 0;

                foreach (DataRow row in dtRptDiscounts.Rows)
                {
                    var newRow = dataTable.NewRow();
                    int id = Convert.ToInt32(row["id"]);
                    int month = Convert.ToInt32(row["month"]);
                    string monthName = MonthToName(month);
                    string description = row["description"].ToString();
                    decimal rate = Convert.ToDecimal(row["rate"]);
                    bool isAdvance = Convert.ToBoolean(row["is_advance"]);

                    newRow["id"] = id;
                    newRow["month"] = month;
                    newRow["month_name"] = monthName;
                    newRow["description"] = description;
                    newRow["rate"] = rate;
                    newRow["is_advance"] = isAdvance;
                    dataTable.Rows.Add(newRow);

                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                }

                e.Result = dataTable;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is not DataTable dataTable)
                return;

            HelperLoadRecords.DiscountsDatagridView(dataGridView1, dataTable);
            lblRecordCount.Text = dataGridView1.Rows.Count.ToString();
            dataGridView1.CurrentCell = dataGridView1.FirstDisplayedCell;
            Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
        }
    }
}