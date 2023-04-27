using AccountingSystem.Views.Dashboard;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.JEV
{
    public partial class frmJEVList : Form
    {
        private string _journalName;
        private string _fundName;
        private byte _month;
        private short _year;
        internal ucJEVDashboard _ucJEVDashboard;

        public frmJEVList(string journalName, string fundName, byte month, short year, ucJEVDashboard ucJEVDashboard)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _journalName = journalName;
            _fundName = fundName;
            _month = month;
            _year = year;
            _ucJEVDashboard = ucJEVDashboard;
            Helper.DatagridFullRowSelectStyle(dgJEV, true);
        }

        private void frmJEVList_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadJournals();
                LoadMonths();
                LoadJEVList();
                LoadFunds();
                nudYear.Value = _year == 0 ? DateTime.Now.Year : _year;
            }
        }

        private DataTable DatatableJournals()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("id");
            dataTable.Columns.Add("journal_name");

            try
            {
                var dtJournals = AccFactory.JournalsRepository().GetRecords();
                dataTable = new DataView(dtJournals).ToTable(false, "id", "journal_name");
                DataRow dr = dataTable.NewRow();
                dr["id"] = "0";
                dr["journal_name"] = "All";
                dataTable.Rows.InsertAt(dr, 0);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return dataTable;
        }

        internal void LoadFunds()
        {
            var dtFunds = AccFactory.FundsRepository().GetRecords();
            DataRow dr = dtFunds.NewRow();
            dr["id"] = 0;
            dr["fund_name"] = "All";
            dtFunds.Rows.InsertAt(dr, 0);

            HelperLoadRecords.FundsComboBox(dtFunds, cmbxFunds, "fund_name", "id");

            int index = cmbxFunds.FindString(_fundName);
            cmbxFunds.SelectedIndex = index;
        }

        private void LoadJournals()
        {
            HelperLoadRecords.ComboboxJournals(DatatableJournals(), cmbxJournals, "id", "journal_name");
            if (_journalName != string.Empty)
            {
                int index = cmbxJournals.FindString(_journalName);
                cmbxJournals.SelectedIndex = index;
            }
        }

        private void LoadSelected()
        {
            Cursor = Cursors.WaitCursor;
            int rowIndex = dgJEV.CurrentCell.RowIndex;
            string jevNo = dgJEV.Rows[rowIndex].Cells["jev_no"].Value.ToString();
            int jevId = Convert.ToInt32(dgJEV.Rows[rowIndex].Cells["id"].Value);
            int createdById = Convert.ToInt32(dgJEV.Rows[rowIndex].Cells["created_by_id"].Value);

            var frmJev = new frmJEV(true, this, _ucJEVDashboard);
            var ucFrmJev = frmJev.ucjev1;
            ucFrmJev.jevNo = jevNo;
            ucFrmJev.jevId = jevId;
            frmJev.createdById = createdById;
            frmJev.ShowDialog();   
            Cursor = Cursors.Default;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            LoadSelected();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadJEVList();
        }

        private void LoadMonths()
        {
            foreach (var item in Helper.MonthsDatasource().Values)
                cbMonth.Items.Add(item);
            cbMonth.SelectedIndex = _month == 0 ? DateTime.Now.Month - 1 : _month;
        }

        private void EnableDisableButtons()
        {
            if (dgJEV.SelectedRows.Count == 1)
            {
                btnSelect.Enabled = true;
            }
            else
                btnSelect.Enabled = false;
        }

        private string GetJevStatus(byte isApproved, byte isDisapproved, byte isCancelled)
        {
            if (isApproved == 0 && isDisapproved == 0 && isCancelled == 0)
                return "Pending";

            if (isApproved == 1 && isDisapproved == 0 && isCancelled == 0)
                return "Approved";

            if (isApproved == 0 && isDisapproved == 1 && isCancelled == 0)
                return "Disapproved";

            if (isCancelled == 1)
                return "Cancelled";

            return string.Empty;
        }

        private void LoadStatusColors()
        {
            foreach (DataGridViewRow row in dgJEV.Rows)
            {
                string status = row.Cells["status"].Value.ToString();
                row.Cells["status"].Style.BackColor = Helper.StatusColor(status);
                row.Cells["status"].Style.SelectionBackColor = Helper.StatusColor(status);
                row.Cells["status"].Style.Format.ToUpper();
            }
        }

        internal void LoadJEVList()
        {
            try
            {
                HelperLoadRecords.JEVDatagridView(dgJEV);
                dgJEV.Rows.Clear();

                string jevStatus = cmbxJevStatus.Text.ToLower();
                string searchTxt = txtSearch.Text;
                short month = Convert.ToInt16(cbMonth.SelectedIndex + 1);

                var dataTable = AccFactory.JEVRepository().GetViewRecords_By_Status_JournalName_Search_Month_Year(jevStatus, searchTxt, _journalName, _fundName, month, _year);

                foreach (DataRow row in dataTable.Rows)
                {
                    byte isApproved = Convert.ToByte(row["is_approved"]);
                    byte isDisapproved = Convert.ToByte(row["is_disapproved"]);
                    byte isCancelled = Convert.ToByte(row["is_cancelled"]);

                    int rowId = Convert.ToInt32(row["id"]);
                    DateTime rowDateEntry = Convert.ToDateTime(row["date_entry"].ToString());
                    string rowJevNo = row["jev_no"].ToString();
                    string rowFullJEVNo = row["full_jev_no"].ToString();
                    int rowFundId = Convert.ToInt32(row["funds_id"]);
                    string rowFundName = row["fund_name"].ToString();
                    int rowJournalId = Convert.ToInt32(row["journals_id"]);
                    string rowJournalName = row["journal_name"].ToString();
                    string rowRefNo = row["ref_no"].ToString();
                    string rowPayee = row["payee"].ToString();
                    string rowExplanation = row["explanation"].ToString();
                    string rowCreatedAt = row["created_at"].ToString();
                    string rowCreatedById = row["created_by"].ToString();
                    var dictUserCreatedBy = AccFactory.UsersRepository().GetUserByID(Convert.ToByte(rowCreatedById));
                    var rowCreatedByName = string.IsNullOrEmpty(rowCreatedById) ? string.Empty : Helper.GetUserDataById(Convert.ToInt32(rowCreatedById))["user_full_name"];
                    string rowUpdatedAt = row["updated_at"].ToString();
                    string rowUpdatedById = row["updated_by"].ToString();
                    string rowUpdatedByName = string.IsNullOrEmpty(rowUpdatedById) ? string.Empty : Helper.GetUserDataById(Convert.ToInt32(rowUpdatedById))["user_full_name"]; ;

                    string rowStatus = GetJevStatus(isApproved, isDisapproved, isCancelled);

                    int rowIndex = dgJEV.Rows.Add();
                    DataGridViewRow rowItem = dgJEV.Rows[rowIndex];
                    rowItem.Cells["id"].Value = rowId;

                    rowItem.Cells["date_entry"].Value = rowDateEntry;
                    rowItem.Cells["jev_no"].Value = rowJevNo;
                    rowItem.Cells["full_jev_no"].Value = rowFullJEVNo;
                    rowItem.Cells["funds_id"].Value = rowFundId;
                    rowItem.Cells["fund_name"].Value = rowFundName;
                    rowItem.Cells["journals_id"].Value = rowJournalId;
                    rowItem.Cells["journal_name"].Value = rowJournalName;
                    rowItem.Cells["ref_no"].Value = rowRefNo;
                    rowItem.Cells["payee"].Value = rowPayee;
                    rowItem.Cells["explanation"].Value = rowExplanation;
                    rowItem.Cells["created_at"].Value = rowCreatedAt;
                    rowItem.Cells["created_by_id"].Value = rowCreatedById;
                    rowItem.Cells["created_by_name"].Value = rowCreatedByName;
                    rowItem.Cells["updated_at"].Value = rowUpdatedAt;
                    rowItem.Cells["updated_by_id"].Value = rowUpdatedById;
                    rowItem.Cells["updated_by_name"].Value = rowUpdatedByName;
                    rowItem.Cells["status"].Value = rowStatus;
                }

                dgJEV.CurrentCell = dgJEV.FirstDisplayedCell;
                LoadStatusColors();
                EnableDisableButtons();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgJEV_SelectionChanged(object sender, EventArgs e)
        {
            EnableDisableButtons();
        }

        private void cmbxJevStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadJEVList();
        }

        private void cmbxJournals_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadJEVList();
        }

        private void cmbxFunds_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadJEVList();
        }

        private void cbMonth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadJEVList();
        }

        private void nudYear_ValueChanged(object sender, EventArgs e)
        {
            LoadJEVList();
        }

        private void dgJEV_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            foreach (DataGridViewColumn column in dgJEV.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void dgJEV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            LoadSelected();
        }
    }
}