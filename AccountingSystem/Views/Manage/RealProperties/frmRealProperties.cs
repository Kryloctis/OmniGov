using ACC.Domain.Models;
using AccountingSystem.Views.Manage.TaxPayers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RealProperties
{
    public partial class frmRealProperties : Form
    {
        internal int realPropertiesID;
        internal int taxpayerID;

        public frmRealProperties()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgRealProperties);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddRealProperties(this).ShowDialog();
        }

        private void frmRealProperties_Load(object sender, EventArgs e)
        {
            LoadAllProperties();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxShowCanclled.Checked)
                ShowCancelledProperties();
            else
                LoadAllProperties();

        }

        private void ShowCancelledProperties()
        {

            try
            {
                string searchValue = txtSearch.Text.Trim();
                var dtRealProperties = new DataTable();

                if (searchValue.Length < 2)
                    dtRealProperties = AccFactory.RealPropertiesRepository().GetCancelledProperties();
                else
                    dtRealProperties = AccFactory.RealPropertiesRepository().GetCancelledRecordsBySearch(searchValue);

                HelperLoadRecords.RealPropertiesDatagridView(dgRealProperties, dtRealProperties);
                dgRealProperties.CurrentCell = dgRealProperties.FirstDisplayedCell;
                toolStripStatusLabelRecordCount.Text = dgRealProperties.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadAllProperties()
        {
            try
            {
                string searchValue = txtSearch.Text.Trim();
                var dtRealProperties = new DataTable();

                if (searchValue.Length < 2)
                    dtRealProperties = AccFactory.RealPropertiesRepository().GetRecords();
                else
                    dtRealProperties = AccFactory.RealPropertiesRepository().GetRecordsBySearch(searchValue);

                HelperLoadRecords.RealPropertiesDatagridView(dgRealProperties, dtRealProperties);
                dgRealProperties.CurrentCell = dgRealProperties.FirstDisplayedCell;
                toolStripStatusLabelRecordCount.Text = dgRealProperties.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }


        private void dgRealProperties_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgRealProperties.Columns.Count < 1)
                    return;

                byte createdByIndex = (byte)dgRealProperties.Columns["created_at"].Index;
                byte updatedByIndex = (byte)dgRealProperties.Columns["updated_at"].Index;

                var indexes = new byte[] { createdByIndex, updatedByIndex };
                EnableDisableToolStripButtons(dgRealProperties, btnEdit, btnDelete);
                Helper.ShowRecordTimestamp(dgRealProperties, indexes, toolStripStatusLabelCreatedAt, toolStripStatusLabelUpdatedAt);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        public static void EnableDisableToolStripButtons(DataGridView dgv, ToolStripButton tsBtnEdit, ToolStripButton tsBtnDelete)
        {
            int SelectedRows = dgv.SelectedRows.Count;
            if (SelectedRows == 1)
            {
                tsBtnEdit.Enabled = true;
                tsBtnDelete.Enabled = true;
            }
            else if (SelectedRows > 1)
            {
                tsBtnEdit.Enabled = false;
                tsBtnDelete.Enabled = true;
            }
            else
            {
                tsBtnEdit.Enabled = false;
                tsBtnDelete.Enabled = false;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Helper.MessageBoxConfirmDelete(dgRealProperties.SelectedRows.Count))
            {
                try
                {
                    var realPropertiesRepository = AccFactory.RealPropertiesRepository();
                    var realPropertiesModels = new List<RealPropertiesModel>();

                    foreach (DataGridViewRow row in dgRealProperties.SelectedRows)
                    {
                        int realPropertiesID = int.Parse(row.Cells[0].Value.ToString());

                        var receiptIsUsed = AccFactory.ReceiptsIssuedRepository().ReceiptHasIssuance(realPropertiesID);

                        if (!receiptIsUsed)
                            realPropertiesModels.Add(new RealPropertiesModel() { Id = realPropertiesID });
                    }
                    _ = realPropertiesRepository.Delete(realPropertiesModels);
                    LoadAllProperties();

                    Helper.MessageBoxSuccess("Real properties has been deleted.");
                }
                catch (Exception)
                {
                    Helper.MessageBoxError("Cannot delete properties.");
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = dgRealProperties.CurrentCell.RowIndex;
            realPropertiesID = Convert.ToInt32(dgRealProperties.Rows[rowIndex].Cells["real_properties_id"].Value);
            taxpayerID = Convert.ToInt32(dgRealProperties.Rows[rowIndex].Cells["real_taxpayers_id"].Value);
            _ = new frmEditRealProperties(this).ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadAllProperties();
        }
    }
}