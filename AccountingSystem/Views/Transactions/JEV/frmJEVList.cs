using AccountingSystem.Views.Dashboard;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.JEV
{
    public partial class frmJEVList : Form
    {
        private string _journalName;
        private byte _month;
        private int _year;
        internal ucJEVDashboard _ucJEVDashboard;

        public frmJEVList(string journalName, byte month, int year, ucJEVDashboard ucJEVDashboard)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _journalName = journalName;
            _month = month;
            _year = year;
            _ucJEVDashboard = ucJEVDashboard;
        }

        private void frmJEVList_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                Helper.DatagridFullRowSelectStyle(dgJEV);
                LoadJournals();
                LoadMonths();
                LoadJEVList();
                nudYear.Value = _year == 0? DateTime.Now.Year:_year;
            }
        }

        private void LoadJournals()
        {
            var dtJournals = Factory.JournalsRepository().GetRecords();
            HelperLoadRecords.ComboboxJournals(dtJournals, cmbxJournals, "id", "journal_name");
            if (_journalName != string.Empty)
            {
                int index = cmbxJournals.FindString(_journalName);
                cmbxJournals.SelectedIndex = index;
            }

        }

        private void LoadSelected()
        {
            int rowIndex = dgJEV.CurrentCell.RowIndex;
            string jevNo = dgJEV.Rows[rowIndex].Cells["jev_no"].Value.ToString();
            int jevId = Convert.ToInt32(dgJEV.Rows[rowIndex].Cells["id"].Value);

            var newFrmJev = new frmJEV(this, _ucJEVDashboard);
            var ucFrmJev = newFrmJev.ucjev1;
            ucFrmJev.jevNo = jevNo;
            ucFrmJev.jevId = jevId;
            newFrmJev.ShowDialog();

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
            cbMonth.SelectedIndex = _month == 0? DateTime.Now.Month - 1 : _month;
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
                return  "Pending";

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
                string journalName = cmbxJournals.Text.Trim();
                string searchTxt = txtSearch.Text;
                short month = Convert.ToInt16(cbMonth.SelectedIndex + 1);
                short year = Convert.ToInt16(nudYear.Value);

                var dtJEV = Factory.JEVRepository().FilterRecords(jevStatus, searchTxt, journalName, month, year);


                foreach (DataRow row in dtJEV.Rows)
                {
                    byte isApproved = Convert.ToByte(row["is_approved"]);
                    byte isDisapproved = Convert.ToByte(row["is_disapproved"]);
                    byte isCancelled = Convert.ToByte(row["is_cancelled"]);



                    int id = Convert.ToInt32(row["id"]);
                    int fundId = Convert.ToInt32(row["funds_id"]);
                    int journalsId = Convert.ToInt32(row["journals_id"]);
                    string jevNo = row["jev_no"].ToString();
                    string fullJEVNo = row["full_jev_no"].ToString();
                    DateTime dateEntry = Convert.ToDateTime(row["date_entry"].ToString());
                    string refNo = row["ref_no"].ToString();
                    string payee = row["payee"].ToString();
                    string explanation = row["explanation"].ToString();
                    string fundCode = row["fund_code"].ToString();
                    string createdAt = row["created_at"].ToString();
                    string createdById = row["created_by"].ToString();
                    var dictUserCreatedBy = Factory.UsersRepository().GetUserByID(Convert.ToByte(createdById));
                    var createdByName = $"{dictUserCreatedBy["first_name"]} {dictUserCreatedBy["mid_initial"]} {dictUserCreatedBy["last_name"]}";
                    string updatedAt = row["updated_at"].ToString();
                    string updatedById = row["updated_by"].ToString();
                    //var dictUserUpdatedBy = Factory.UsersRepository().GetUserByID(Convert.ToByte(updatedById));
                    string updatedByName = string.Empty;

                    string status = GetJevStatus(isApproved, isDisapproved, isCancelled);

                    dgJEV.Rows.Add(new object[] { id, fundId, journalsId, jevNo, fullJEVNo, dateEntry, refNo, payee, explanation, fundCode, createdAt, createdById, createdByName, updatedAt, updatedById, updatedByName, status });

                }

                LoadStatusColors();

                dgJEV.ClearSelection();
                EnableDisableButtons();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.StackTrace);
            }
        }

        private void dgJEV_SelectionChanged(object sender, EventArgs e)
        {
            EnableDisableButtons();
        }

        private void dgJEV_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            LoadSelected();
        }

        private void cmbxJevStatus_SelectionChangeCommitted(object sender, EventArgs e)
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

        private void cmbxJournals_SelectionChangeCommitted(object sender, EventArgs e)
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
    }
}
