using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Funds
{
    public partial class frmFunds : Form
    {
        public frmFunds()
        {
            InitializeComponent();
            WindowState = FormWindowState.Normal;
            Helper.LoadFormIcon(this);
            Helper.DatagridDefaultStyle(dgFunds);
        }

        internal void LoadRecords()
        {
            try
            {
                var fundsRepository = AccFactory.FundsRepository();
                var dtFunds = fundsRepository.GetRecords();
                HelperLoadRecords.FundsDatagridView(dtFunds, dgFunds);

                lblRecordCount.Text = dgFunds.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmFunds_Load(object sender, EventArgs e)
        {
            Helper.DatagridFullRowSelectStyle(dgFunds, true);
            dgFunds.ShowCellToolTips = false;
            LoadRecords();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmFundAdd(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgFunds.Rows.Count > 0)
            {
                int fundId = int.Parse(dgFunds.SelectedCells[0].Value.ToString());
                _ = new frmFundEdit(this, fundId).ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgFunds.SelectedRows.Count;
            try
            {
                if (selectedRowsCount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                    {
                        var fundsModelList = new List<FundsModel>();
                        foreach (DataGridViewRow row in dgFunds.SelectedRows)
                        {
                            int fundId = Convert.ToInt16(row.Cells[0].Value.ToString());
                            fundsModelList.Add(new FundsModel() { Id = fundId });
                        }

                        var fundsRepository = AccFactory.FundsRepository();
                        _ = fundsRepository.Delete(fundsModelList);
                        LoadRecords();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void dgFunds_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 3, 4 };
            Helper.ShowRecordTimestamp(dgFunds, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgFunds, btnEdit, btnDelete);
        }

        private void toolStripTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = toolStripTextBoxSearch.Text.Trim();

            if (searchText.Length > 0)
            {
                try
                {
                    var dtFunds = AccFactory.FundsRepository().GetRecordsBySearch(searchText);
                    HelperLoadRecords.FundsDatagridView(dtFunds, dgFunds);

                    lblRecordCount.Text = dgFunds.Rows.Count.ToString();
                }
                catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            }
            else
            {
                LoadRecords();
            }
        }
    }
}