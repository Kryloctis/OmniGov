using ACC.Data;
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
            var dtFunds = AccFactory.FundsRepository().GetRecords();
            HelperLoadRecords.FundsDatagridView(dtFunds, dgFunds);

            lblRecordCount.Text = dgFunds.Rows.Count.ToString();
        }

        private void frmFunds_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            Helper.DatagridFullRowSelectStyle(dgFunds, true);
            dgFunds.ShowCellToolTips = false;
            LoadRecords();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmFundAdd(this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgFunds.Rows.Count > 0)
                {
                    int fundId = int.Parse(dgFunds.SelectedCells[0].Value.ToString());
                    _ = new frmFundEdit(this, fundId).ShowDialog();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool DeleteData()
        {
            int selectedRowsCount = dgFunds.SelectedRows.Count;
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

                    return AccFactory.FundsRepository().Delete(fundsModelList);
                }
            }
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteData())
                    LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgFunds_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                byte[] columnIndexTimestamp = { 3, 4 };
                Helper.ShowRecordTimestamp(dgFunds, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
                Helper.EnableDisableToolStripButtons(dgFunds, btnEdit, btnDelete);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void toolStripTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = toolStripTextBoxSearch.Text.Trim();

                if (searchText.Length > 0)
                {
                    var dtFunds = AccFactory.FundsRepository().GetRecordsBySearch(searchText);
                    HelperLoadRecords.FundsDatagridView(dtFunds, dgFunds);

                    lblRecordCount.Text = dgFunds.Rows.Count.ToString();
                }
                else
                    LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}