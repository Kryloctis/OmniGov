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
            LoadRecords();
        }
        private DataColumn[] OtherPaymentRatesColumns()
        {
            var dataColumns = new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("tax_type_id", typeof(int)),
                new DataColumn("description", typeof(string)),
                new DataColumn("amount", typeof(decimal)),
                new DataColumn("starting_year", typeof(string)),
                new DataColumn("is_rate_editable", typeof(bool)),
                new DataColumn("created_by", typeof(int)),
                new DataColumn("created_at", typeof(object)),
                new DataColumn("updated_by", typeof(int)),
                new DataColumn("updated_at", typeof(object)),
            };

            return dataColumns;
        }

        internal void LoadRecords()
        {
            try
            {
                string searchText = txtSearch.Text.Trim();
                var dtOtherPaymentRates = new DataTable();
                var dtOtherPaymentRatesFromDB = new DataTable();

                dtOtherPaymentRates.Columns.AddRange(OtherPaymentRatesColumns());

                if (searchText.Length > 2)
                    dtOtherPaymentRatesFromDB = AccFactory.OtherPaymentRatesRepository().GetRecordsBySearch(searchText);
                else
                    dtOtherPaymentRatesFromDB = AccFactory.OtherPaymentRatesRepository().GetRecords();

                foreach (DataRow row in dtOtherPaymentRatesFromDB.Rows)
                {
                    var newRow = dtOtherPaymentRates.NewRow();
                    int id = Convert.ToInt32(row["id"]);
                    int taxTypeId = Convert.ToInt32(row["tax_type_id"]);
                    string description = row["description"].ToString();
                    decimal amount = row.IsNull("amount") ? 0 : Convert.ToDecimal(row["amount"]);
                    int startingYear = row.IsNull("starting_year") ? 0 : Convert.ToInt32(row["starting_year"]);
                    bool isEditableRate = Convert.ToBoolean(row["is_rate_editable"]);
                    int createdBy = Convert.ToInt32(row["created_by"]);
                    object createdAt = row["created_at"].ToString();
                    int updateBy = row.IsNull("updated_by") ? 0 : Convert.ToInt32(row["updated_by"]);
                    object updateAt = row["updated_at"].ToString();

                    newRow["id"] = id;
                    newRow["tax_type_id"] = taxTypeId;
                    newRow["description"] = description;
                    newRow["amount"] = amount;
                    newRow["starting_year"] = startingYear;
                    newRow["is_rate_editable"] = isEditableRate;
                    newRow["created_by"] = createdBy;
                    newRow["created_at"] = createdAt;
                    newRow["updated_by"] = updateBy;
                    newRow["updated_at"] = updateAt;

                    HelperLoadRecords.OtherPaymentRatesDatagridView(dgOtherPaymentRates, dtOtherPaymentRates);
                    dtOtherPaymentRates.Rows.Add(newRow);
                }
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
                        LoadRecords();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRecords();
        }
    }
}
