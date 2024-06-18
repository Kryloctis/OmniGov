using ACC.Data;
using ACC.Domain.Models;
using AccountingSystem.Views.Manage.TaxPayers;
using AccountingSystem.Views.Transactions.Payments;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.Biddings
{
    public partial class frmBiddings : Form
    {
        private ucTaxPayers ucTaxPayers;
        private ucBiddings ucBiddings;
        private ucPayment ucPayment;

        public frmBiddings()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgBiddings, true);

            ucBiddings = ucBiddings1;
            ucPayment = ucPayment1;
            ucTaxPayers = ucTaxPayers1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageForm);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageList);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRowCount = dgBiddings.SelectedRows.Count;
                if (DeleteBiddings(dgBiddings))
                {
                    Helper.MessageBoxSuccess($"{selectedRowCount} records has been deleted.");
                    LoadBid();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool DeleteBiddings(DataGridView dataGridView)
        {
            var models = new List<BidModel>();
            var selectedRow = dataGridView.SelectedRows;

            if (Helper.MessageBoxConfirmDelete(selectedRow.Count))
            {
                foreach (DataGridViewRow rowItem in selectedRow)
                {
                    var model = new BidModel() { Id = Convert.ToInt32(rowItem.Cells["id"].Value) };
                    models.Add(model);
                }

                return AccFactory.BidRepository().Delete(models);
            }

            return false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageForm);
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            TabPageController(tabPagePayment);
        }

        private void btnPaymentBack_Click(object sender, EventArgs e)
        {
            TabPageController(tabPageForm);
        }

        private decimal ComputeAmountDue()
        {
            decimal bidAmount = ucBiddings.nudBidAmount.Value;
            decimal otherDuesToBeDeterminedLater = 0;

            decimal amountDue = bidAmount + otherDuesToBeDeterminedLater;

            return amountDue;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ucBiddings.ValidateInput() && ucTaxPayers.ValidateChildren())
            {
                TabPageController(tabPagePayment);
                decimal totalAmountPayable = ComputeAmountDue();
                ucPayment1.OnLoad(Helper.userId, string.Empty, totalAmountPayable);
            }
        }

        private void frmBiddings_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRowFilter();
                ucTaxPayers.LoadTaxPayersType();
                ucBiddings.OnLoad();
                LoadBid();
                Helper.EnableDisableToolStripButtons(dgBiddings, btnEdit, btnDelete);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadBid()
        {
            if (!backgroundWorker1.IsBusy)
            {
                string searchKey = txtSearch.Text.Trim();
                int rowFilter = Convert.ToInt32(cmbxRowFilter.SelectedValue);
                DateTime date = dtpBiddingDate.Value;
                progressBar1.Value = 0;
                backgroundWorker1.RunWorkerAsync((searchKey, rowFilter, date));
            }
        }

        private void LoadRowFilter()
        {
            HelperLoadRecords.ComboboxRowLimitFilter(cmbxRowFilter);
        }

        private void TabPageController(TabPage tabPageRoute)
        {
            try
            {
                Text = $"Transaction > {tabPageRoute.Text} ";
                tabControl1.SelectedTab = tabPageRoute;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void ResetForm()
        {
            TabPageController(tabPageList);
            LoadBid();
        }

        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (ConfirmPayment())
                {
                    Helper.MessageBoxSuccess("Payment has been saved, initiating the printing of the receipt...");
                    ResetForm();
                    return;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool ConfirmPayment()
        {
            var biddersModel = new BiddersModel()
            {
                AuctionId = Convert.ToInt32(ucBiddings.cmbxAuctionSchedule.SelectedValue),
                BidderNo = ucBiddings.txtAssignedBidderNo.Text,
                CreatedBy = Helper.userId
            };

            var bidModel = new BidModel()
            {
                RptAuctionId = Convert.ToInt32(ucBiddings.cmbxProperty.SelectedValue),
                OrdinanceNo = ucBiddings.txtOrdinanceNo.Text,
                Date = ucBiddings.dtpDate.Value,
                BidAmount = Convert.ToDecimal(ucBiddings.nudBidAmount.Value),
                CreatedBy = Helper.userId
            };

            return AccFactory.PaymentCollectionsRepository().InsertWithBiddingPayment(ucPayment.PaymentCollectionsModel(), null, ucTaxPayers.TaxpayersModel(), bidModel, biddersModel);
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
                    HelperLoadRecords.DgBidders(dgBiddings, dataTable);
                    return;
                }

                HelperLoadRecords.DgBidders(dgBiddings, dataTable);
                dgBiddings.CurrentCell = dgBiddings.FirstDisplayedCell;
                lblRowCount.Text = dataTable.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                var parameters = ((string searchKey, int rowFilter, DateTime date))e.Argument;
                //var dtDb = AccFactory.BiddersRepository().GetViewRecords();
                var dtDb = AccFactory.BidRepository().GetViewRecords();
                int totalProgressCount = dtDb.Rows.Count;
                int progressCount = 0;
                var dataTable = new DataTable();

                var a = dtDb.Rows.Count;
                var dataColumns = new List<DataColumn>()
                {
                    new DataColumn("id", typeof(int)),
                    new DataColumn("taxpayers_id", typeof(int)),
                    new DataColumn("auction_id", typeof(int)),
                    new DataColumn("name", typeof(string)),
                    new DataColumn("bidder_no", typeof(string)),
                    new DataColumn("ordinance_no", typeof(string)),
                    new DataColumn("date", typeof(DateTime)),
                    new DataColumn("bid_amount", typeof(decimal)),
                };

                dataTable.Columns.AddRange(dataColumns.ToArray());

                foreach (DataRow row in dtDb.Rows)
                {
                    var newRow = dataTable.NewRow();

                    newRow["id"] = row["id"];   //bid id
                    newRow["taxpayers_id"] = row["taxpayers_id"];
                    newRow["auction_id"] = row["auction_id"];
                    newRow["name"] = row["name"];
                    newRow["bidder_no"] = row["bidder_no"];
                    newRow["ordinance_no"] = row["ordinance_no"];
                    newRow["date"] = row["date"];
                    newRow["bid_amount"] = row["bid_amount"];

                    dataTable.Rows.Add(newRow);
                    progressCount++;
                    Helper.ProgressCounter(backgroundWorker1, totalProgressCount, progressCount);
                }

                e.Result = dataTable;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadBid();
        }

        private void dgBiddings_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Helper.EnableDisableToolStripButtons(dgBiddings, btnEdit, btnDelete);

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}
