using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Auction
{
    public partial class frmAuction : Form
    {
        private readonly ucAuctionEvents ucAuctionEvents;
        private readonly ucCertificateOfSale ucCertificateOfSale;
        private readonly ucDeclarationOfForfeitureOfDelinquentProperty ucDeclarationOfForfeitureOfDelinquentProperty;
        private readonly ucNoticeOfAuctionSaleOfDelinquentRealProperties ucNoticeOfAuctionSaleOfDelinquentRealProperties;
        private readonly ucNoticeOfsale ucNoticeOfsale;
        private readonly ucReportOfSale ucReportOfSale;
        private readonly ucRptScheduling ucRptScheduling;

        public frmAuction()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgAuctionList, true);
            Helper.DatagridFullRowSelectStyle(dgRptSchedule, true);

            ucAuctionEvents = ucAuctionEvents2;
            ucRptScheduling = ucRptScheduling2;

            ucNoticeOfAuctionSaleOfDelinquentRealProperties = ucNoticeOfAuctionSaleOfDelinquentRealProperties1;
            ucNoticeOfsale = ucNoticeOfsale1;
            ucCertificateOfSale = ucCertificateOfSale1;
            ucDeclarationOfForfeitureOfDelinquentProperty = ucDeclarationOfForfeitureOfDelinquentProperty1;
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((string searchKey, int rowFilter, DateTime date))e.Argument;
                var dtDb = AccFactory.AuctionRepository().GetRecords();
                int totalProgressCount = dtDb.Rows.Count;
                int progressCount = 0;
                var dataTable = new DataTable();

                var a = dtDb.Rows.Count;
                var dataColumns = new List<DataColumn>()
                {
                    new DataColumn("id", typeof(int)),
                    new DataColumn("start_date", typeof(DateTime)),
                    new DataColumn("end_date", typeof(DateTime)),
                    new DataColumn("location", typeof(string)),
                    new DataColumn("created_at", typeof(DateTime)),
                };

                dataTable.Columns.AddRange(dataColumns.ToArray());

                foreach (DataRow row in dtDb.Rows)
                {
                    var newRow = dataTable.NewRow();

                    newRow["id"] = row["id"];
                    newRow["start_date"] = row["start_date"];
                    newRow["end_date"] = row["end_date"];
                    newRow["location"] = row["location"];
                    newRow["created_at"] = row["created_at"];

                    dataTable.Rows.Add(newRow);
                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                }

                e.Result = dataTable;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result is not DataTable dataTable)
                {
                    progressBar1.Value = 100;
                    return;
                }

                lblRowCount.Text = dataTable.Rows.Count.ToString();

                if (dataTable.Rows.Count < 1)
                {
                    progressBar1.Value = 100;
                    HelperLoadRecords.DgAuction(dgAuctionList, dataTable);
                    return;
                }

                HelperLoadRecords.DgAuction(dgAuctionList, dataTable);
                dgAuctionList.CurrentCell = dgAuctionList.FirstDisplayedCell;
                lblRowCount.Text = dataTable.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            TabPageController(tabPageAuctionForm);
            ucAuctionEvents.OnLoad(false, null);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageListOfAuction);
        }
        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            try
            {
                int selectedRowCount = dgAuctionList.SelectedRows.Count;
                if (DeleteAuctionRecords(dgAuctionList))
                {
                    Helper.MessageBoxSuccess($"{selectedRowCount} records has been deleted.");
                    LoadAuction();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            TabPageController(tabPageAuctionForm);
            int index = dgAuctionList.CurrentCell.RowIndex;
            int auctionId = Convert.ToInt32(dgAuctionList.Rows[index].Cells["id"].Value);
            ucAuctionEvents.OnLoad(true, auctionId);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveAuction();
        }

        private void cmbxRowFilter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                LoadAuction();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool DeleteAuctionRecords(DataGridView dataGridView)
        {
            var models = new List<AuctionModel>();
            var selectedRow = dataGridView.SelectedRows;

            if (Helper.MessageBoxConfirmDelete(selectedRow.Count))
            {
                foreach (DataGridViewRow rowItem in selectedRow)
                {
                    var model = new AuctionModel() { Id = Convert.ToInt32(rowItem.Cells["id"].Value) };
                    models.Add(model);
                }

                return AccFactory.AuctionRepository().Delete(models);
            }

            return false;
        }

        private bool DeleteRptScheduleRecords(DataGridView dataGridView)
        {
            var models = new List<RptAuctionModel>();
            var selectedRow = dataGridView.SelectedRows;

            if (Helper.MessageBoxConfirmDelete(selectedRow.Count))
            {
                foreach (DataGridViewRow rowItem in selectedRow)
                {
                    var model = new RptAuctionModel() { Id = Convert.ToInt32(rowItem.Cells["rpt_auction_id"].Value) };
                    models.Add(model);
                }

                return AccFactory.RptAuctionRepository().Delete(models);
            }

            return false;
        }

        private void dgAuctionList_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Helper.EnableDisableToolStripButtons(dgAuctionList, btnEdit, btnDelete);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmAuction_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                if (tabControl1.SelectedTab == tabPageAuctionForm)
                    SaveAuction();
                else if (tabControl1.SelectedTab == tabPageRptScheduleForm)
                    SaveRptAuctionSchedule();
            }
        }

        private void frmAuction_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRowFilter();
                LoadAuction();
                LoadRptSchedule();

                EnableDisableReportItem();
                Helper.EnableDisableToolStripButtons(dgAuctionList, btnEdit, btnDelete);
                Helper.EnableDisableToolStripButtons(dgRptSchedule, btnEditScheduledProperty, btnDeleteScheduledProperty);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadRptSchedule()
        {
            if (!backgroundWorker2.IsBusy)
            {
                string searchKey = txtSearch.Text.Trim();
                int rowFilter = Convert.ToInt32(cmbxSchedulePropertyRowFilter.SelectedValue);
                DateTime date = dtpRptSchedule.Value;
                progressBar1.Value = 0;
                backgroundWorker2.RunWorkerAsync((searchKey, date, rowFilter));
            }
        }

        private void LoadAuction()
        {
            if (!backgroundWorker1.IsBusy)
            {
                string searchKey = txtSearch.Text.Trim();
                int rowFilter = Convert.ToInt32(cmbxRowFilter.SelectedValue);
                DateTime date = dtpAuctionSchedule.Value;
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync((searchKey, rowFilter, date));
            }
        }

        private void LoadRowFilter()
        {
            HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowFilter);
            HelperLoadRecords.ComboboxRowLimitFilter(cmbxSchedulePropertyRowFilter);
        }

        private void lTOM23ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageNoticeOfAuctionSaleOfDelinquentRealProperties);

            int index = dgAuctionList.CurrentCell.RowIndex;
            int auctionId = Convert.ToInt32(dgAuctionList.Rows[index].Cells["id"].Value);
            ucNoticeOfAuctionSaleOfDelinquentRealProperties.OnLoad(auctionId);
        }

        private void lTOM24ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageNoticeOfSale);

            int index = dgAuctionList.CurrentCell.RowIndex;
            int auctionId = Convert.ToInt32(dgAuctionList.Rows[index].Cells["id"].Value);
            int taxpayerId = Convert.ToInt32(dgRptSchedule.Rows[index].Cells["taxpayers_id"].Value);

            ucNoticeOfsale.OnLoad(auctionId, taxpayerId);

        }

        private void lTOM29ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageCertificateOfSale);

            int index = dgAuctionList.CurrentCell.RowIndex;
            int taxpayerId = Convert.ToInt32(dgRptSchedule.Rows[index].Cells["taxpayers_id"].Value);
            int auctionId = Convert.ToInt32(dgRptSchedule.Rows[index].Cells["auction_id"].Value);

            ucCertificateOfSale.OnLoad(taxpayerId, auctionId);
        }

        private void lTOM31ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageReportOfSale);
        }

        private void lTOMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageDeclaractionOfForfeitureOfDelinquentProeperty);

            int index = dgRptSchedule.CurrentCell.RowIndex;
            int auctionId = Convert.ToInt32(dgRptSchedule.Rows[index].Cells["auction_id"].Value);
            int taxpayerId = Convert.ToInt32(dgRptSchedule.Rows[index].Cells["taxpayers_id"].Value);
            ucDeclarationOfForfeitureOfDelinquentProperty.OnLoad(auctionId, taxpayerId);
        }

        private void SaveAuction()
        {
            try
            {
                bool isEdit = false;

                if (ucAuctionEvents.Save(ref isEdit))
                {
                    if (isEdit)
                        Helper.MessageBoxSuccess("Auction has been updated.");
                    else
                        Helper.MessageBoxSuccess("Auction has been saved.");

                    tabControl1.SelectedTab = tabPageListOfAuction;
                    LoadAuction();
                    ucAuctionEvents.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }


        private void TabPageController(TabPage tabPageRoute)
        {
            try
            {
                if (tabControlReportsViewer.TabPages.Contains(tabPageRoute))
                {
                    tabControl1.SelectedTab = tabPagePrint;
                    tabControlReportsViewer.SelectedTab = tabPageRoute;
                }
                else
                    tabControl1.SelectedTab = tabPageRoute;


                Text = $"Transactions > {tabPageRoute.Text} ";

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageListOfAuction);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageListOfRptSchedule);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                TabPageController(tabPageRptScheduleForm);
                ucRptScheduling.OnLoad(false, null);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                TabPageController(tabPageRptScheduleForm);

                int index = dgRptSchedule.CurrentCell.RowIndex;
                int rptScheduleId = Convert.ToInt32(dgRptSchedule.Rows[index].Cells["rpt_auction_id"].Value);
                ucRptScheduling.OnLoad(true, rptScheduleId);
            }

            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {

            TabPageController(tabPageListOfRptSchedule);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageListOfRptSchedule);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                LoadAuction();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }


        #region Rpt Auction Schedule

        private void btnSaveRptAuctionSchedule_Click(object sender, EventArgs e)
        {
            SaveRptAuctionSchedule();
        }

        private void SaveRptAuctionSchedule()
        {
            try
            {
                bool isEdit = false;

                if (ucRptScheduling.Save(ref isEdit))
                {
                    if (isEdit)
                        Helper.MessageBoxSuccess("Rpt Schedule has been updated.");
                    else
                        Helper.MessageBoxSuccess("Rpt Schedule  has been saved.");

                    LoadRptSchedule();
                    TabPageController(tabPageListOfRptSchedule);
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((string searchKey, DateTime date, int rowFilter))e.Argument;
                var dtDb = AccFactory.RptAuctionRepository().GetViewRecords(parameters.searchKey, parameters.date, parameters.rowFilter);
                int totalProgressCount = dtDb.Rows.Count;
                int progressCount = 0;
                var dataTable = new DataTable();

                var dataColumns = new List<DataColumn>()
                {
                    new DataColumn("rpt_auction_id", typeof(int)),
                    new DataColumn("auction_id", typeof(int)),
                    new DataColumn("real_properties_id", typeof(int)),
                    new DataColumn("taxpayers_id", typeof(int)),
                    new DataColumn("start_date", typeof(DateTime)),
                    new DataColumn("end_date", typeof(DateTime)),
                    new DataColumn("location", typeof(string)),
                    new DataColumn("street", typeof(string)),
                    new DataColumn("complete_arp_no", typeof(string)),
                };

                dataTable.Columns.AddRange(dataColumns.ToArray());

                foreach (DataRow row in dtDb.Rows)
                {
                    var newRow = dataTable.NewRow();

                    newRow["rpt_auction_id"] = row["rpt_auction_id"];
                    newRow["auction_id"] = row["auction_id"];
                    newRow["real_properties_id"] = row["real_properties_id"];
                    newRow["taxpayers_id"] = row["taxpayers_id"];
                    newRow["start_date"] = row["start_date"];
                    newRow["end_date"] = row["end_date"];
                    newRow["location"] = row["location"];
                    newRow["street"] = row["street"];
                    newRow["complete_arp_no"] = row["complete_arp_no"];

                    dataTable.Rows.Add(newRow);
                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker2, totalProgressCount, progressCount);
                }

                e.Result = dataTable;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker2_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar2.Value = e.ProgressPercentage;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result is not DataTable dataTable)
                {
                    progressBar2.Value = 100;
                    return;
                }

                lblRowCount.Text = dataTable.Rows.Count.ToString();

                if (dataTable.Rows.Count < 1)
                {
                    progressBar2.Value = 100;
                    HelperLoadRecords.DgRptAuction(dgRptSchedule, dataTable);
                    return;
                }

                HelperLoadRecords.DgRptAuction(dgRptSchedule, dataTable);
                dgRptSchedule.CurrentCell = dgRptSchedule.FirstDisplayedCell;
                lblRowCount.Text = dataTable.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void EnableDisableReportItem()
        {
            bool enable = dgRptSchedule.Rows.Count != 0;

            lTOM24ToolStripMenuItem.Enabled = enable;
            lTOM29ToolStripMenuItem.Enabled = enable;
            lTOMToolStripMenuItem.Enabled = enable;

        }

        private void dgRptSchedule_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Helper.EnableDisableToolStripButtons(dgRptSchedule, btnEditScheduledProperty, btnDeleteScheduledProperty);
                EnableDisableReportItem();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnDeleteScheduledProperty_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRowCount = dgRptSchedule.SelectedRows.Count;
                if (DeleteRptScheduleRecords(dgRptSchedule))
                {
                    Helper.MessageBoxSuccess($"{selectedRowCount} records has been deleted.");
                    LoadRptSchedule();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSearchRptSched_Click(object sender, EventArgs e)
        {
            try
            {
                LoadRptSchedule();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        #endregion



    }
}
