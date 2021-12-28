using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.ObligationRequest
{
    public partial class frmObligationRequestSearch : Form
    {
        private frmObligationRequestMain _frmObligationRequestMain;
        private ucObligationRequestMain _ucObligationRequestMain;

        public frmObligationRequestSearch(frmObligationRequestMain frmObligationRequestMain)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);

            _frmObligationRequestMain = frmObligationRequestMain;
            _ucObligationRequestMain = _frmObligationRequestMain.ucObligationRequestMain1;
            btnSelect.Enabled = false;
            cmbxStatus.SelectedIndex = 0;
            Helper.DatagridFullRowSelectStyle(dgObligationRequests, true);
        }

        private DataTable ObligationRequestsDatatable()
        {
            var dataTable = new DataTable();

            string ObligationRequestStatus(bool isApproved, bool isDisapproved, bool isCancelled)
            {
                if (isCancelled)
                    return "Cancelled";
                else if (isApproved)
                    return "Approved";
                else if (isDisapproved)
                    return "Disapproved";
                else
                    return "Pending";
            }

            dataTable.Columns.Add("id");
            dataTable.Columns.Add("obligation_no");
            dataTable.Columns.Add("payee");
            dataTable.Columns.Add("explanation");
            dataTable.Columns.Add("reference_no");
            dataTable.Columns.Add("date_requested");
            dataTable.Columns.Add("created_at");
            dataTable.Columns.Add("created_by_id");
            dataTable.Columns.Add("created_by_full_name");
            dataTable.Columns.Add("updated_at");
            dataTable.Columns.Add("updated_by_id");
            dataTable.Columns.Add("updated_by_full_name");
            dataTable.Columns.Add("status");

            string searchTxt = txtSearch.Text.Trim();
            string filterStatus = cmbxStatus.Text.Trim().ToLower();
            var dtObligationRequests = Factory.ObligationRequestRepository().GetViewRecordsBySearchAndStatus(searchTxt, filterStatus);


            foreach (DataRow row in dtObligationRequests.Rows)
            {
                var id = row["obligation_request_id"].ToString();
                var obligationNo = row["obligation_no"].ToString();
                var payee = row["payee"].ToString();
                var explanation = row["explanation"].ToString();
                var referenceNo = row["reference_no"].ToString();
                bool isApproved = Convert.ToBoolean(row["is_approved"]);
                bool isDisapproved = Convert.ToBoolean(row["is_disapproved"]);
                bool isCancelled = Convert.ToBoolean(row["is_cancelled"]);
                var status = ObligationRequestStatus(isApproved, isDisapproved, isCancelled);
                var dateRequested = row["date_requested"].ToString();
                var createdAt = row["created_at"].ToString();
                var createdById = row["created_by_id"].ToString();
                var createdByFullName = row["created_by_full_name"].ToString();
                var updatedAt = row["updated_at"].ToString();
                var updatedById = row["updated_by_id"].ToString();
                var updatedByFullName = row["updated_by_full_name"].ToString();

                var item = new object[] { id, obligationNo, payee, explanation, referenceNo, dateRequested, createdAt, createdById, createdByFullName, updatedAt, updatedById, updatedByFullName, status };

                dataTable.Rows.Add(item);
            }

            return dataTable;
        }

        private void LoadStatusColors()
        {
            foreach (DataGridViewRow row in dgObligationRequests.Rows)
            {
                var status = row.Cells["status"].Value;

                switch (status.ToString().ToLower())
                {
                    case "approved":
                        row.Cells["status"].Style.BackColor = Helper.StatusColor("Approved");
                        row.Cells["status"].Style.SelectionBackColor = Helper.StatusColor("Approved");
                        break;

                    case "disapproved":
                        row.Cells["status"].Style.BackColor = Helper.StatusColor("Disapproved");
                        row.Cells["status"].Style.SelectionBackColor = Helper.StatusColor("Disapproved");
                        break;

                    case "cancelled":
                        row.Cells["status"].Style.BackColor = Helper.StatusColor("Cancelled");
                        row.Cells["status"].Style.SelectionBackColor = Helper.StatusColor("Cancelled");
                        break;

                    case "pending":
                        row.Cells["status"].Style.BackColor = Helper.StatusColor("Pending");
                        row.Cells["status"].Style.SelectionBackColor = Helper.StatusColor("Pending");
                        break;

                    default:
                        row.Cells["status"].Style.BackColor = DefaultBackColor;
                        row.Cells["status"].Style.SelectionBackColor = DefaultBackColor;
                        break;
                }
            }
        }

        private void LoadObligationRequests()
        {
            try
            {
                HelperLoadRecords.ObligationRequestDatagridView(ObligationRequestsDatatable(), dgObligationRequests);
                LoadStatusColors();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void dgObligationRequests_SelectionChanged(object sender, EventArgs e)
        {
            if (dgObligationRequests.SelectedRows.Count == 1)
                btnSelect.Enabled = true;
            else
                btnSelect.Enabled = false;
        }

        private void LoadSelected()
        {
            _ucObligationRequestMain.isEdit = true;
            int rowIndex = dgObligationRequests.CurrentCell.RowIndex;
            int obligationRequestId = Convert.ToInt32(dgObligationRequests.Rows[rowIndex].Cells["id"].Value);
            _ucObligationRequestMain.obligationRequestId = obligationRequestId;
            _frmObligationRequestMain.ResetControls();
            _frmObligationRequestMain.LoadSearched();
            _ucObligationRequestMain.EnableDisableComponents(false);
            _frmObligationRequestMain.GetObligationStatus();
            _frmObligationRequestMain.btnSave.Text = "Update";

            Helper.ClearErrorComboBox(_ucObligationRequestMain.epFPP, _ucObligationRequestMain.cmbxFPP);
            Helper.ClearMaskedTextboxError(_ucObligationRequestMain.epObligationNo, _ucObligationRequestMain.mskTxtObligationNoTemplate);
            Helper.ClearMaskedTextboxError(_ucObligationRequestMain.epObligationRequest, _ucObligationRequestMain.mskTxtObligationNoTemplate);
            Helper.ClearErrorTextBox(_ucObligationRequestMain.epPayee, _ucObligationRequestMain.txtPayee);
            Helper.ClearErrorTextBox(_ucObligationRequestMain.epReferenceNo, _ucObligationRequestMain.txtReferenceNo);
            Helper.ClearErrorTextBox(_ucObligationRequestMain.epExplanation, _ucObligationRequestMain.txtExplanation);

            Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            LoadSelected();
        }

        private void dgObligationRequests_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            LoadSelected();
        }

        private void frmObligationRequestSearch_Load(object sender, EventArgs e)
        {
            LoadObligationRequests();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadObligationRequests();
        }

        private void dgObligationRequests_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void cmbxStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadObligationRequests();
        }
    }
}
