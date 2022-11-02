using ACC.Domain.Models;
using AccountingSystem.Views.Manage.Receipts;
using AccountingSystem.Views.Manage.TaxPayers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RealProperties
{
    public partial class frmRealProperties : Form
    {
        public frmRealProperties()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgRealProperties, true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddRealProperties(this).ShowDialog();
        }

        private void frmRealProperties_Load(object sender, EventArgs e)
        {
            LoadProperties();
        }

        internal void LoadProperties()
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
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void dgRealProperties_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgRealProperties, btnEdit, btnDelete);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (Helper.MessageBoxConfirmDelete(dgRealProperties.SelectedRows.Count))
            {
                var realPropertiesRepository = AccFactory.RealPropertiesRepository();
                var realPropertiesModels = new List<RealPropertiesModel>();

                foreach (DataGridViewRow row in dgRealProperties.SelectedRows)
                {
                    int realPropertiesID = int.Parse(row.Cells[0].Value.ToString());

                    var receiptIsUsed = AccFactory.ReceiptsIssuedRepository().ReceiptIsUsed(realPropertiesID);

                    if (!receiptIsUsed)
                        realPropertiesModels.Add(new RealPropertiesModel() { Id = realPropertiesID });

                }
                _ = realPropertiesRepository.Delete(realPropertiesModels);


                LoadProperties();
                Helper.MessageBoxSuccess("Real properties has been deleted.");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = dgRealProperties.CurrentCell.RowIndex;
            var realPropertiesID = Convert.ToInt32(dgRealProperties.Rows[rowIndex].Cells["real_properties_id"].Value);
            var taxpayerID = Convert.ToInt32(dgRealProperties.Rows[rowIndex].Cells["real_taxpayers_id"].Value);
            _ = new frmEditRealProperties(realPropertiesID, taxpayerID).ShowDialog();
        }
    }
}
