using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.OtherPaymentRates
{
    public partial class frmOtherPaymentRates : Form
    {
        public frmOtherPaymentRates()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgOtherPaymentRates, false);
        }

        private void frmOtherPaymentRates_Load(object sender, EventArgs e)
        {
            LoadOtherPaymentRates();
        }

        internal void LoadOtherPaymentRates()
        {
            try
            {
                var dtOtherPaymentRates = new DataTable();
                dtOtherPaymentRates = AccFactory.OtherPaymentRatesRepository().GetRecords();
                HelperLoadRecords.OtherPaymentRatesDatagridView(dgOtherPaymentRates, dtOtherPaymentRates);

            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgOtherPaymentRates_SelectionChanged(object sender, EventArgs e)
        {
            if (dgOtherPaymentRates.Columns.Count < 1)
                return;

            byte createdByIndex = (byte)dgOtherPaymentRates.Columns["created_at"].Index;
            byte updatedByIndex = (byte)dgOtherPaymentRates.Columns["updated_at"].Index;

            var indexes = new byte[] { createdByIndex, updatedByIndex };
            Helper.EnableDisableToolStripButtons(dgOtherPaymentRates, btnEdit, btnDelete);
            Helper.ShowRecordTimestamp(dgOtherPaymentRates, indexes, toolStripStatusLabelCreatedAt, toolStripStatusLabelUpdatedAt);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddOtherPaymentRates(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = dgOtherPaymentRates.CurrentCell.RowIndex;
            int otherPaymentRatesID = Convert.ToInt32(dgOtherPaymentRates.Rows[rowIndex].Cells["id"].Value);

            _ = new frmEditOtherPaymentRates(this, otherPaymentRatesID).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgOtherPaymentRates.SelectedRows.Count;
            try
            {
                if (selectedRowsCount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                    {
                        var otherPaymentRatesModelList = new List<OtherPaymentRatesModel>();
                        foreach (DataGridViewRow row in dgOtherPaymentRates.SelectedRows)
                        {
                            int otherPaymentRatesID = Convert.ToInt16(row.Cells[0].Value.ToString());
                            otherPaymentRatesModelList.Add(new OtherPaymentRatesModel() { Id = otherPaymentRatesID });
                        }

                        var otherPaymentRatesRepository = AccFactory.OtherPaymentRatesRepository();
                        _ = otherPaymentRatesRepository.Delete(otherPaymentRatesModelList);
                        LoadOtherPaymentRates();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

    }
}
