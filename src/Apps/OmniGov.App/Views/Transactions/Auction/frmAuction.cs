using OmniGov.App.Helpers;

using OmniGov.Treasury.Data.Factories;

using OmniGov.Treasury.Domain.Entities;

using System.Data;

namespace OmniGov.App.Views.Transactions.Auction

{
    public partial class frmAuction : Form

    {
        private readonly ucAuctionEvents ucAuctionEvents;

        private readonly ucRptScheduling ucRptScheduling;

        public frmAuction()

        {
            InitializeComponent();

            Helper.LoadFormIcon(this);

            Helper.DatagridFullRowSelectStyle(dgAuctionList, true);

            Helper.DatagridFullRowSelectStyle(dgRptSchedule, true);

            ucAuctionEvents = ucAuctionEvents2;

            ucRptScheduling = ucRptScheduling2;
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)

        {
            var parameters = ((string searchKey, int rowFilter, DateTime date))e.Argument;
            var dtDb = TreasuryFactory.AuctionRepository().GetRecords();
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

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)

        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)

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

        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)

        {
            var parameters = ((string searchKey, DateTime date, int rowFilter))e.Argument;
            var dtDb = TreasuryFactory.RptAuctionRepository().GetViewRecords(parameters.searchKey, parameters.date, parameters.rowFilter);
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

        private void backgroundWorker2_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)

        {
            progressBar2.Value = e.ProgressPercentage;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)

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
            int selectedRowCount = dgAuctionList.SelectedRows.Count;
            if (DeleteAuctionRecords(dgAuctionList))
            {
                Helper.MessageBoxSuccess($"{selectedRowCount} records has been deleted.");
                LoadAuction();
            }
        }

        private void btnDeleteScheduledProperty_Click(object sender, EventArgs e)

        {
            int selectedRowCount = dgRptSchedule.SelectedRows.Count;
            if (DeleteRptScheduleRecords(dgRptSchedule))
            {
                Helper.MessageBoxSuccess($"{selectedRowCount} records has been deleted.");
                LoadRptSchedule();
            }
        }

        private void btnEdit_Click(object sender, System.EventArgs e)

        {
            TabPageController(tabPageAuctionForm);

            int index = dgAuctionList.CurrentCell.RowIndex;

            int auctionId = Convert.ToInt32(dgAuctionList.Rows[index].Cells["id"].Value);

            ucAuctionEvents.OnLoad(true, auctionId);
        }

        private void btnRptSchedules_Click(object sender, EventArgs e)

        {
            TabPageController(tabPageListOfRptSchedule);
        }

        private void btnSave_Click(object sender, EventArgs e)

        {
            SaveAuction();
        }

        private void btnSaveRptAuctionSchedule_Click(object sender, EventArgs e)

        {
            SaveRptAuctionSchedule();
        }

        private void btnSearch_Click(object sender, EventArgs e)

        {
            LoadAuction();
        }

        private void btnSearchRptSched_Click(object sender, EventArgs e)

        {
            LoadRptSchedule();
        }

        private void cmbxRowFilter_SelectionChangeCommitted(object sender, EventArgs e)

        {
            LoadAuction();
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

                return TreasuryFactory.AuctionRepository().Delete(models);
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

                return TreasuryFactory.RptAuctionRepository().Delete(models);
            }

            return false;
        }

        private void dgAuctionList_SelectionChanged(object sender, EventArgs e)

        {
            Helper.EnableDisableToolStripButtons(dgAuctionList, btnEdit, btnDelete);
            btnRptSchedules.Enabled = btnEdit.Enabled;
        }

        private void dgRptSchedule_SelectionChanged(object sender, EventArgs e)

        {
            Helper.EnableDisableToolStripButtons(dgRptSchedule, btnEditScheduledProperty, btnDeleteScheduledProperty);
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
            LoadRowFilter();
            LoadAuction();
            LoadRptSchedule();

            Helper.EnableDisableToolStripButtons(dgAuctionList, btnEdit, btnDelete);
            Helper.EnableDisableToolStripButtons(dgRptSchedule, btnEditScheduledProperty, btnDeleteScheduledProperty);
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

        private void SaveAuction()

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

        private void SaveRptAuctionSchedule()

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

        private void TabPageController(TabPage tabPageRoute)

        {
            tabControl1.SelectedTab = tabPageRoute;
            Text = $"Transactions > {tabPageRoute.Text} ";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)

        {
            TabPageController(tabPageListOfAuction);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)

        {
            TabPageController(tabPageRptScheduleForm);
            ucRptScheduling.OnLoad(false, null);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)

        {
            TabPageController(tabPageRptScheduleForm);

            int index = dgRptSchedule.CurrentCell.RowIndex;
            int rptScheduleId = Convert.ToInt32(dgRptSchedule.Rows[index].Cells["rpt_auction_id"].Value);
            ucRptScheduling.OnLoad(true, rptScheduleId);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)

        {
            TabPageController(tabPageListOfRptSchedule);
        }

        private void toolStripButton8_Click(object sender, EventArgs e)

        {
            TabPageController(tabPageListOfRptSchedule);
        }
    }
}