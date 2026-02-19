using Budget.Data.Factories;
using OmniGov.App.Helpers;
using OmniGov.Core.Factories;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace OmniGov.App.Budget.Views.AllotmentRelease.Old
{
    public partial class frmAllotmentReleaseSearch : Form
    {
        private frmAllotmentReleaseMain _frmAllotmentReleaseMain;

        public frmAllotmentReleaseSearch(frmAllotmentReleaseMain frmAllotmentReleaseMain)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _frmAllotmentReleaseMain = frmAllotmentReleaseMain;
            btnSelect.Enabled = false;
        }

        private void LoadFunds()
        {
            try
            {
                var dtFunds = Factory.FundsRepository().GetRecords();
                HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "id", "fund_name");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void LoadAllotmentClasses()
        {
            try
            {
                var dtFunds = Factory.AllotmentClassesRepository().GetRecords();
                HelperLoadRecords.AllotmentClasssesCombobox(dtFunds, cmbxAllotmentClasses, "allotment_code", "id");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private DataTable AllotmentReleaseDatatable()
        {
            var dataTable = new DataTable();

            try
            {
                var continuingColumn = new DataColumn();
                continuingColumn.DataType = typeof(Image);
                continuingColumn.ColumnName = "continuing";

                string searchTxt = txtSearch.Text.Trim();
                dataTable.Columns.Add("allotment_release_id");
                dataTable.Columns.Add("full_aro_no");
                dataTable.Columns.Add("date_issued");
                dataTable.Columns.Add("purpose");
                dataTable.Columns.Add("total_allotment_release");
                dataTable.Columns.Add(continuingColumn);

                int fundId = Convert.ToInt32(cmbxFunds.SelectedValue);
                int allotmentClassId = Convert.ToInt32(cmbxAllotmentClasses.SelectedValue);
                var dateIssued = dtDateIssued.Value;

                var dtAllotmentReleaseSearch = BudgetFactory.AllotmentReleaseRepository().GetViewRecordsBySearch(fundId, allotmentClassId, dateIssued, searchTxt);

                foreach (DataRow row in dtAllotmentReleaseSearch.Rows)
                {
                    int rowAllotmentReleaseId = Convert.ToInt32(row["allotment_release_id"]);
                    string rowFullAroNo = row["full_aro_no"].ToString();
                    DateTime rowDateIssued = Convert.ToDateTime(row["date_issued"]);
                    string rowPurpose = row["purpose"].ToString();
                    bool rowIsContinuing = Convert.ToBoolean(row["continuing"]);
                    string rowTotalAllotmentRelease = BudgetFactory.AllotmentReleaseRepository().GetTotalAllotmentReleaseById(rowAllotmentReleaseId).ToString("N2");

                    var item = new dynamic[] { rowAllotmentReleaseId, rowFullAroNo, rowDateIssued.ToString("MMM dd, yyyy"), rowPurpose, rowTotalAllotmentRelease, rowIsContinuing ? Properties.Resources.ok14px : null };

                    if (rowDateIssued.Year == dateIssued.Year || rowIsContinuing)
                        dataTable.Rows.Add(item);
                }

                return dataTable;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return dataTable;
        }

        private void LoadAllotmentRelease()
        {
            HelperLoadRecords.SearchAllotmentReleaseDatagridView(AllotmentReleaseDatatable(), dgAllotmentRelease);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadAllotmentRelease();
        }

        private void frmAllotmentReleaseSearch_Load(object sender, EventArgs e)
        {
            Helper.DatagridFullRowSelectStyle(dgAllotmentRelease, true);
            LoadFunds();
            LoadAllotmentClasses();
            LoadAllotmentRelease();
        }

        private void dgAllotmentRelease_SelectionChanged(object sender, EventArgs e)
        {
            if (dgAllotmentRelease.SelectedRows.Count == 1)
                btnSelect.Enabled = true;
            else
                btnSelect.Enabled = false;
        }

        private void LoadSearched()
        {
            var ucMain = _frmAllotmentReleaseMain.ucAllotmentReleaseMain1;
            int rowIndex = dgAllotmentRelease.CurrentCell.RowIndex;
            int allotmentReleaseId = Convert.ToInt32(dgAllotmentRelease.Rows[rowIndex].Cells["allotment_release_id"].Value);

            ucMain.allotmentReleaseId = allotmentReleaseId;
            _frmAllotmentReleaseMain.LoadSelected();
            ucMain.DisplayTotalAllotmentRelease();
            ucMain.ClearErrors();
            Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            LoadSearched();
        }

        private void cmbxFunds_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadAllotmentRelease();
        }

        private void cmbxAllotmentClasses_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadAllotmentRelease();
        }

        private void dtDateIssued_ValueChanged(object sender, EventArgs e)
        {
            LoadAllotmentRelease();
        }

        private void dgAllotmentRelease_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
                LoadSearched();
        }
    }
}