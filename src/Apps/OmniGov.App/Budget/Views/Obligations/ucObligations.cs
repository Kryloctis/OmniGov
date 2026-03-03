using OmniGov.App.Budget.Helpers;
using OmniGov.App.Helpers;
using OmniGov.Budget.Data.Factories;
using OmniGov.Budget.Domain.Entities;
using OmniGov.Core.Factories;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Text;
using static OmniGov.App.Helpers.Helper;

namespace OmniGov.App.Budget.Views.Obligations
{
    public partial class ucObligations : UserControl
    {
        private bool isEdit;
        private int oblgtnRqstId;
        private int fundId;

        public ucObligations()
        {
            InitializeComponent();
            //Don't recommend putting any code here since it will be triggered on design stage of user control that causes ERRORS!
        }

        private void OnLoad()
        {
            DatagridEditableRowStyle(dgvEntries, true);
            dgvEntries.RowTemplate.Height = 30;
            tbControlDetailsEntries.SelectedTab = tbPgDetails;

            this.AutoValidate = AutoValidate.EnableAllowFocusChange;

            LoadFPP();
            LoadAlltmntClss();
            LoadFunds();

            InitializeEntriesTbl();
            dgvEntries.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);

            ToggleEntriesButtons(dgvEntries, tlStrpBtnEntrRemove);
        }

        internal void LoadCrudMode(bool isEdit, int? oblgtnRqstId = null)
        {
            this.isEdit = isEdit;
            OnLoad();
            if (isEdit)
            {
                this.oblgtnRqstId = oblgtnRqstId.Value;
                var exemptCtrls = new List<Control>() { txtExplanation };
                SetControlsReadOnly(true, panel3, exemptCtrls);
                LoadSelectedRecord(oblgtnRqstId.Value);
                txtRemarks.Enabled = true;
            }
            else
            {
                ResetForm();
            }
        }

        internal void LoadViewMode(int oblgtnRqstId)
        {
            this.oblgtnRqstId = oblgtnRqstId;
            OnLoad();
            SetControlsReadOnly(true, tbControlDetailsEntries, null);
            LoadSelectedRecord(oblgtnRqstId);
        }

        internal void LoadReviewMode(int oblgtnRqstId)
        {
            this.oblgtnRqstId = oblgtnRqstId;
            var exemptCtrls = new List<Control>() { txtRemarks };
            OnLoad();
            SetControlsReadOnly(true, tbControlDetailsEntries, exemptCtrls);
            LoadSelectedRecord(oblgtnRqstId);
        }

        //Models
        internal (ObligationRequestModel oblgtnRqstModel, List<ObligationAccountModel> oblgtnAccsModel) ObligationRequestModels()
        {
            var oblgtnRqst = new ObligationRequestModel()
            {
                Id = this.oblgtnRqstId,
                FppId = Convert.ToInt32(cmbxFPP.SelectedValue),
                AllotmentClassId = Convert.ToInt32(cmbxAlltmntClss.SelectedValue),
                FundId = Convert.ToInt32(cmbxFund.SelectedValue),
                Explanation = txtExplanation.Text.Trim(),
                DateRequested = dtDateRequest.Value,
                Payee = txtPayee.Text.Trim(),
                ReferenceNo = txtReferenceNo.Text.Trim(),
                CreatedBy = UserHelper.loggedUser.Id,
                UpdatedBy = UserHelper.loggedUser.Id,
                ObligationStatus = ObligationRequestModel.Status.pending,
                Remarks = txtRemarks.Text.Trim()
            };

            oblgtnRqst.TransactionNo = isEdit ? mskTxtTransNo.Text.Replace("-", "") : string.Empty;

            var oblgtnAccs = new List<ObligationAccountModel>();

            foreach (DataGridViewRow dataGridViewRow in dgvEntries.Rows)
            {
                if (dataGridViewRow.IsNewRow) continue;

                var oblgtnAccModel = new ObligationAccountModel()
                {
                    AllotmentAccountId = Convert.ToInt32(dataGridViewRow.Cells["account"].Value),
                    Amount = Convert.ToDecimal(dataGridViewRow.Cells["amount"].Value),
                };

                oblgtnAccs.Add(oblgtnAccModel);
            }

            return (oblgtnRqst, oblgtnAccs);
        }

        /// <summary>
        /// Loads the selected record.
        /// </summary>
        /// <param name="oblgtnRqstId">The oblgtn RQST identifier.</param>
        private void LoadSelectedRecord(int oblgtnRqstId)
        {
            var dictOblgtnRqst = BudgetFactory.ObligationRequestRepository().GetViewRecordById(oblgtnRqstId);
            Enum.TryParse<ObligationRequestModel.Status>(dictOblgtnRqst["status"], out var status);
            int.TryParse(dictOblgtnRqst["fpp_id"], out int fppId);

            //Load Fields
            mskTxtTransNo.Text = BudgetHelper.GenTransactionNo(dictOblgtnRqst["transaction_no"]);
            cmbxFPP.SelectedValue = fppId;
            cmbxFund.SelectedValue = dictOblgtnRqst["funds_id"];
            cmbxAlltmntClss.SelectedValue = dictOblgtnRqst["allotment_class_id"];
            txtPayee.Text = dictOblgtnRqst["payee"];
            dtDateRequest.Value = Convert.ToDateTime(dictOblgtnRqst["date_requested"]);
            txtReferenceNo.Text = dictOblgtnRqst["reference_no"];
            txtExplanation.Text = dictOblgtnRqst["explanation"];
            txtRemarks.Text = dictOblgtnRqst["remarks"];
            mskTxtOblgtnNo.Text = dictOblgtnRqst["obligation_no"];

            //Load Status
            SetStatus(status);

            //Load Obligation Entries
            LoadOblgtnEntries(oblgtnRqstId, dgvEntries);
        }

        private void LoadOblgtnEntries(int oblgtnRqstId, DataGridView dgv)
        {
            var dtOblgtnAccs = BudgetFactory.ObligationRequestRepository().GetViewRecordsById(oblgtnRqstId);
            dgv.Rows.Clear();

            foreach (DataRow dtRow in dtOblgtnAccs.Rows)
            {
                int rowIndex = dgv.Rows.Add();
                dgv.Rows[rowIndex].Cells["others_fpp"].Value = dtRow.IsNull("others_fpp_id") ? 0 : Convert.ToInt32(dtRow["others_fpp_id"]);

                // Triggering cascades manually to ensure IDs match
                PopulateAllotmentReleaseCell(rowIndex, dgv);
                dgv.Rows[rowIndex].Cells["aro_no"].Value = Convert.ToInt32(dtRow["allotment_release_id"]);

                PopulateAccountsCell(rowIndex, dgv);
                dgv.Rows[rowIndex].Cells["account"].Value = Convert.ToInt32(dtRow["allotment_account_id"]);

                dgv.Rows[rowIndex].Cells["amount"].Value = Convert.ToDecimal(dtRow["amount"]);
                GetUnobligatedBalance(rowIndex, dgv);
            }
        }

        private void ToggleEntriesButtons(DataGridView dgv, ToolStripButton btnRemove)
        {
            int SelectedRows = dgv.SelectedRows.Count;

            if (SelectedRows == 1 || SelectedRows > 1)
            {
                btnRemove.Enabled = true;
                btnRemove.Text = "Remove (" + SelectedRows + ")";
            }
            else
            {
                btnRemove.Enabled = false;
                btnRemove.Text = "Remove";
            }
        }

        internal void ResetForm()
        {
            this.oblgtnRqstId = 0;
            this.isEdit = false;

            LoadFPP();
            LoadFunds();

            if (cmbxFPP.Items.Count > 0) cmbxFPP.SelectedIndex = 0;

            mskTxtOblgtnNo.Text = string.Empty;
            dtDateRequest.Value = DateTime.Now;
            txtReferenceNo.Text = string.Empty;
            txtPayee.Text = string.Empty;
            txtExplanation.Text = string.Empty;
            dgvEntries.Rows.Clear();
            errorProvider1.Clear();
            mskTxtOblgtnNo.Clear();
            txtRemarks.Clear();
            txtRemarks.Enabled = false;

            //Reset Status
            SetStatus(ObligationRequestModel.Status.draft);
        }

        private void SetStatus(ObligationRequestModel.Status status)
        {
            string _status = status.ToString();

            lblStatus.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_status);
            lblStatIndctr.ForeColor = StatusColor(_status);
        }

        internal string GetFormErrors()
        {
            dgvEntries.EndEdit();
            var errorList = new List<string>();

            // Collect errors from ErrorProvider
            foreach (Control ctrl in new Control[] { cmbxFPP, cmbxFund, cmbxAlltmntClss, txtPayee })
            {
                string err = errorProvider1.GetError(ctrl);
                if (!string.IsNullOrWhiteSpace(err)) errorList.Add(err);
            }

            if (dgvEntries.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
                errorList.Add("At least one obligation entry is required.");

            // Collect errors from DataGridView
            var rowVal = RowsValidated(dgvEntries);
            if (!rowVal.isValidated)
            {
                foreach (var err in rowVal.errors)
                {
                    if (!string.IsNullOrWhiteSpace(err)) errorList.Add(err);
                }
            }

            if (errorList.Count == 0)
                return null;

            return Factory.CreateErrors(errorList.ToArray()).GenerateErrorMessage();
        }

        internal bool Approve() => SetAuditStatus(ObligationRequestModel.Status.approved, txtRemarks.Text.Trim());

        internal bool Disapprove() => SetAuditStatus(ObligationRequestModel.Status.disapproved, txtRemarks.Text.Trim());

        internal bool Cancel() => SetAuditStatus(ObligationRequestModel.Status.cancelled, txtRemarks.Text.Trim());

        private bool SetAuditStatus(ObligationRequestModel.Status status, string remarks)
        {
            return BudgetFactory.ObligationRequestRepository().SetStatus(oblgtnRqstId, status, remarks);
        }

        private void SetControlsReadOnly(bool isReadOnly, Control parent, List<Control> exemptCtrls = null)
        {
            foreach (Control item in parent.Controls)
            {
                bool isExempt = exemptCtrls?.Contains(item) == true;

                switch (item)
                {
                    case TextBoxBase tb:
                        tb.ReadOnly = isReadOnly && !isExempt;
                        break;

                    case ComboBox or DateTimePicker or LinkLabel or DataGridView or ToolStrip:
                        item.Enabled = !isReadOnly || isExempt;
                        break;
                }

                //Using recursive action to child containers
                if (item.HasChildren)
                    SetControlsReadOnly(isReadOnly, item, exemptCtrls);
            }
        }

        private void LoadFPP()
        {
            var dtFpp = Factory.FunctionProgramProjectRepository().GetViewRecords();
            var dataTable = new DataTable();
            dataTable.Columns.Add("id", typeof(uint));
            dataTable.Columns.Add("fpp_code_name", typeof(string));

            dtFpp.AsEnumerable()
                 .ToList()
                 .ForEach(row =>
                            dataTable.Rows.Add(
                                row.Field<uint>("id"),
                                $"{row.Field<string>("fpp_code")} - {row.Field<string>("fpp_name")}"
                                )
                            );

            HelperLoadRecords.FppCombobox(dataTable, cmbxFPP, "fpp_code_name", "id");
        }

        private void LoadOthersFpp(DataGridViewComboBoxColumn dgvCmbxColumn)
        {
            dgvCmbxColumn.DataSource = null;
            dgvCmbxColumn.DataSource = DtOthersFpp();
            dgvCmbxColumn.ValueMember = "id";
            dgvCmbxColumn.DisplayMember = "others_fpp";
        }

        private void LoadFunds()
        {
            var dtFunds = Factory.FundsRepository().GetRecords();
            var dataTable = new DataTable();
            dataTable.Columns.Add("id", typeof(byte));
            dataTable.Columns.Add("fund", typeof(string));

            dtFunds
                .AsEnumerable()
                .ToList()
                .ForEach(row =>
                    dataTable.Rows.Add(
                        row.Field<byte>("id"),
                        $"{row.Field<string>("fund_code")} - {row.Field<string>("fund_name")}"
                    )
                );

            HelperLoadRecords.FundsComboBox(dataTable, cmbxFund, "id", "fund");
        }

        private void LoadAlltmntClss()
        {
            var dtAlltmntClss = Factory.AllotmentClassesRepository().GetRecords();

            var dataTable = new DataTable();
            dataTable.Columns.Add("id", typeof(byte));
            dataTable.Columns.Add("alltmntClss", typeof(string));

            dtAlltmntClss
                .AsEnumerable()
                .ToList()
                .ForEach(row =>
                    dataTable.Rows.Add(
                        row.Field<byte>("id"),
                        $"{row.Field<string>("allotment_code")} - {row.Field<string>("allotment_name")}"
                    )
                );

            cmbxAlltmntClss.DataSource = dataTable;
            cmbxAlltmntClss.ValueMember = "id";
            cmbxAlltmntClss.DisplayMember = "alltmntClss";
        }

        private bool ShowErrorFPPNameNotExist()
        {
            string fppName = cmbxFPP.Text;

            if (cmbxFPP.FindStringExact(fppName) < 0 && !string.IsNullOrEmpty(fppName))
            {
                errorProvider1.SetError(cmbxFPP, "FPP you entered doesn't exist on your record.");
                return true;
            }
            else { return false; }
        }

        private void PopulateAllotmentReleaseCell(int rowIndex, DataGridView dataGridView)
        {
            // Build DataSource
            var othersFppId = (int)dataGridView.Rows[rowIndex].Cells["others_fpp"].Value;
            var dtAlltmntRlease = DtAllotmentRelease(string.Empty, othersFppId);
            var cell = (DataGridViewComboBoxCell)dataGridView.Rows[rowIndex].Cells["aro_no"];
            cell.DataSource = dtAlltmntRlease;

            // Safely assign existing value (or fallback)
            var currentValue = cell.Value;

            if (currentValue != null &&
                dtAlltmntRlease.AsEnumerable().Any(r => r.Field<int>("id") == Convert.ToInt32(currentValue)))
            {
                // keep original
                return;
            }

            // fallback to N/A
            cell.Value = 0;
        }

        private void PopulateAccountsCell(int rowIndex, DataGridView dataGridView)
        {
            // Build DataSource
            var alltmntRlsId = (int)dataGridView.Rows[rowIndex].Cells["aro_no"].Value;
            var dtAlltmntRlease = DtAllotmentAccounts(string.Empty, alltmntRlsId);
            var cell = (DataGridViewComboBoxCell)dataGridView.Rows[rowIndex].Cells["account"];
            cell.DataSource = dtAlltmntRlease;

            // Safely assign existing value (or fallback)
            var currentValue = cell.Value;

            if (currentValue != null &&
                dtAlltmntRlease.AsEnumerable().Any(r => r.Field<int>("id") == Convert.ToInt32(currentValue)))
            {
                // keep original
                return;
            }

            // fallback to N/A
            cell.Value = 0;
        }

        private void GetUnobligatedBalance(int rowIndex, DataGridView dataGridView)
        {
            // Build DataSource
            var cell = (DataGridViewComboBoxCell)dataGridView.Rows[rowIndex].Cells["account"];
            var cellUnobligatedBal = (DataGridViewTextBoxCell)dataGridView.Rows[rowIndex].Cells["unoblgtd_bal"];

            var currentCellVal = cell.Value;
            if (currentCellVal is not DBNull)
            {
                var dtSrcCellAlltmntAccs = (DataTable)cell.DataSource;
                var cellAlltmnAccs = dtSrcCellAlltmntAccs
                                    .AsEnumerable()
                                    .Where(x => x.Field<int>("id") == Convert.ToInt32(currentCellVal))
                                    .Select(row => row["amount"])
                                    .FirstOrDefault();
                decimal alltmntAmount = cellAlltmnAccs is DBNull ? 0 : Convert.ToDecimal(cellAlltmnAccs);

                cellUnobligatedBal.Value = alltmntAmount;
            }
            else
                cellUnobligatedBal.Value = 0.00m;
        }

        private decimal GetTotalObligations(DataGridViewRowCollection dataGridViewRowCollection)
        {
            decimal totalObligation = 0;

            foreach (DataGridViewRow row in dataGridViewRowCollection)
                totalObligation += Convert.ToDecimal(row.Cells["amount"].Value);

            return totalObligation;
        }

        private void InitializeEntriesTbl()
        {
            var dgColumns = DgvColumns();

            if (dgvEntries.Columns.Count != dgColumns.Count)
            {
                dgvEntries.Columns.Clear();
                dgvEntries.Columns.AddRange(dgColumns.ToArray());
            }
        }

        private List<DataGridViewColumn> DgvColumns()
        {
            var dtColumns = new List<DataGridViewColumn>
            {
                new DataGridViewComboBoxColumn ()
                {
                    HeaderText = "Sub FPP",
                    Name = "others_fpp",
                    ValueMember = "id",
                    DisplayMember = "others_fpp",
                    DataSource = DtOthersFpp(),
                    FlatStyle = FlatStyle.Flat,
                    MinimumWidth = 120,
                },

                new DataGridViewComboBoxColumn ()
                {
                    HeaderText = "ARO No.",
                    Name = "aro_no",
                    ValueMember = "id",
                    DisplayMember = "aro_no",
                    FlatStyle = FlatStyle.Flat,
                    MinimumWidth = 80,
                },

                new DataGridViewComboBoxColumn()
                {
                    HeaderText = "Account",
                    Name = "account",
                    ValueMember = "id",
                    DisplayMember = "account",
                    FlatStyle = FlatStyle.Flat,
                    MinimumWidth = 200
                },

                new DataGridViewTextBoxColumn ()
                {
                    HeaderText = "Unobligated Bal.",
                    Name = "unoblgtd_bal",
                    MinimumWidth = 100,
                    ReadOnly = true,
                    ValueType = typeof(decimal),
                    DefaultCellStyle = {Format = "N2",
                                        NullValue = "0.00"}
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Amount",
                    Name = "amount",
                    MinimumWidth = 200,
                    ValueType = typeof(decimal),
                    DefaultCellStyle = {Format = "N2",
                                        NullValue = 0m},
                },
            };

            return dtColumns;
        }

        private DataTable DtOthersFpp()
        {
            if (cmbxFPP.SelectedValue == null) return new DataTable();

            bool fppValid = int.TryParse(cmbxFPP.SelectedValue.ToString(), out int fppId);
            var dtSubFpp = Factory.SubFPPRepository().GetRecordsByFppId(fppId);
            var dt = new DataTable();
            var dtColmns = new DataColumn[]
            {
                new DataColumn(Name = "id", typeof(int)),
                new DataColumn(Name = "others_fpp", typeof(string)),
            };

            dt.Columns.AddRange(dtColmns);
            dt.Rows.Add(0, "N/A");

            foreach (DataRow dr in dtSubFpp.Rows)
                dt.Rows.Add(dr["id"], $"{dr["others_fpp_code"]}{dr["name"]}");

            return dt;
        }

        private DataTable DtAllotmentRelease(string searchKey, int othersFppId)
        {
            bool fppValid = int.TryParse(cmbxFPP.SelectedValue.ToString(), out int fppId);
            bool alltmntClssValid = int.TryParse(cmbxAlltmntClss.SelectedValue.ToString(), out int alltmntClssId);
            bool fundValid = int.TryParse(cmbxFund.SelectedValue.ToString(), out int fundId);
            var dbDtAllotmentRelease = BudgetFactory.AllotmentReleaseRepository().GetViewRecords(fppId, othersFppId == 0 ? null : othersFppId, alltmntClssId, searchKey);

            var dtAllotmntRelease = dbDtAllotmentRelease.AsEnumerable().GroupBy(x => x.Field<UInt32>("allotment_release_id")).ToList();

            var dataTable = new DataTable();
            dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns.Add("aro_no", typeof(string));

            dataTable.Rows.Add(0, "Select...");
            foreach (var row in dtAllotmntRelease)
            {
                dataTable.Rows.Add(
                        row.First().Field<UInt32>("allotment_release_id"),
                        row.First().Field<string>("full_aro_no")
                    );
            }

            return dataTable;
        }

        private DataTable DtAllotmentAccounts(string searchKey, int alltmntRlsId)
        {
            var dtAccs = BudgetFactory.AllotmentReleaseRepository().GetViewRecords(alltmntRlsId);

            var dataTable = new DataTable();
            var dataColumns = new DataColumn[]
            {
                new DataColumn(Name = "id", typeof(int)),
                new DataColumn(Name = "account", typeof(string)),
                new DataColumn(Name = "amount", typeof(decimal)),
            };
            dataTable.Columns.AddRange(dataColumns);

            dataTable.Rows.Add(0, "Select...");
            foreach (DataRow dtRow in dtAccs.Rows)
                dataTable.Rows.Add(dtRow["allotment_account_id"],
                                $"{dtRow["account_code"]}-{dtRow["ledger_name"]}",
                                dtRow["amount"]);
            return dataTable;
        }

        private void cmbxFPP_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dgvColumn = (DataGridViewComboBoxColumn)dgvEntries.Columns["others_fpp"];
            dgvEntries.Rows.Clear();
            if (dgvColumn is not null) LoadOthersFpp(dgvColumn);
        }

        private void dgvEntries_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string col = dgvEntries.Columns[e.ColumnIndex].Name;

            if (col == "others_fpp")
                PopulateAllotmentReleaseCell(e.RowIndex, dgvEntries);

            if (col == "aro_no")
                PopulateAccountsCell(e.RowIndex, dgvEntries);

            if (col == "account")
                GetUnobligatedBalance(e.RowIndex, dgvEntries);

            var cellAmount = dgvEntries.Rows[e.RowIndex].Cells["amount"];
            var cellBalance = dgvEntries.Rows[e.RowIndex].Cells["unoblgtd_bal"];

            //If input is not numeric it resets to 0
            if (cellAmount.Value == null || !decimal.TryParse(cellAmount.Value.ToString(), out var result))
            {
                cellAmount.Value = 0m;
            }
            else
            {
                if (decimal.TryParse(cellBalance.Value?.ToString(), out var balance))
                {
                    if (result > balance)
                    {
                        dgvEntries.CellValueChanged -= dgvEntries_CellValueChanged;
                        cellAmount.Value = balance;
                        dgvEntries.CellValueChanged += dgvEntries_CellValueChanged;
                    }
                }
            }

            lblTotalOblgtn.Text = $"Total: {GetTotalObligations(dgvEntries.Rows).ToString("N2")}";
        }

        private (bool isValidated, string[] errors) RowsValidated(DataGridView dgv)
        {
            var errors = new List<string>();
            bool hasErrors = false;

            foreach (DataGridViewRow dgvRow in dgv.Rows)
            {
                if (dgvRow.IsNewRow) continue;

                var rowErrors = new List<string>();
                foreach (DataGridViewCell cell in dgvRow.Cells)
                {
                    string err = ValidateCell(cell, cell.Value);
                    if (!string.IsNullOrEmpty(err))
                    {
                        rowErrors.Add(err);
                        hasErrors = true;
                    }
                }

                if (rowErrors.Any())
                {
                    var sb = new StringBuilder();
                    sb.AppendLine($"Errors on row {dgvRow.Index + 1}:");
                    foreach (var err in rowErrors)
                        sb.AppendLine($"    - {err}");

                    errors.Add(sb.ToString());
                }
            }

            return (!hasErrors, errors.ToArray());
        }

        private string ValidateCell(DataGridViewCell cell, object formattedValue)
        {
            string col = cell.OwningColumn.Name;
            string val = formattedValue?.ToString()?.Trim() ?? "";

            switch (col)
            {
                case "aro_no":
                    return (cell.Value == null || cell.Value.ToString() == "0") ? "Select ARO No." : "";

                case "account":
                    return (cell.Value == null || cell.Value.ToString() == "0") ? "Select Account" : "";

                case "amount":
                    if (!decimal.TryParse(val, out var amt) || amt <= 0m)
                        return "Amount must be greater than 0";

                    return "";

                default:
                    return "";
            }
        }

        private void dgvEntries_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var g = (DataGridView)sender;
            if (g.Rows[e.RowIndex].IsNewRow) return;

            var cell = g.Rows[e.RowIndex].Cells[e.ColumnIndex];
            string err = ValidateCell(cell, e.FormattedValue);
            cell.ErrorText = err;
        }

        private void dgvEntries_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvEntries.CurrentCell?.OwningColumn?.Name == "amount" && e.Control is TextBox tb)
            {
                tb.KeyPress -= Tb_KeyPress;
                tb.KeyPress += Tb_KeyPress;
            }
        }

        private void Tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (char.IsControl(e.KeyChar)) return;

            bool isDigit = char.IsDigit(e.KeyChar);
            bool isDecimal = e.KeyChar == '.' && !tb.Text.Contains('.');

            e.Handled = !(isDigit || isDecimal);
        }

        private void dgvEntries_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception is ArgumentException)
            {
                e.ThrowException = false;
                e.Cancel = true;
            }

            if (dgvEntries.Columns[e.ColumnIndex].Name == "amount")
            {
                dgvEntries.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0m;
                e.ThrowException = false;
                e.Cancel = true;
            }
        }

        private void tlStrpBtnEntrAdd_Click(object sender, EventArgs e)
        {
            var validateRow = RowsValidated(dgvEntries);

            if (!validateRow.isValidated)
            {
                var errMssg = Factory.CreateErrors(validateRow.errors).GenerateErrorMessage();
                Helper.MessageBoxError(errMssg);
                return;
            }

            int r = dgvEntries.Rows.Add();
            dgvEntries.Rows[r].Cells["others_fpp"].Value = 0;
            dgvEntries.CurrentCell = dgvEntries.Rows[r].Cells["others_fpp"];
            dgvEntries.BeginEdit(true);
        }

        private void tlStrpBtnEntrRemove_Click(object sender, EventArgs e)
        {
            int count = dgvEntries.SelectedRows.Count;
            if (count == 0) return;

            string msg = $"Are you sure you want to remove {(count == 1 ? "the entry" : $"{count} accounting entries")}?";

            if (MessageBox.Show(msg, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                foreach (DataGridViewRow dgvRow in dgvEntries.SelectedRows)
                {
                    if (!dgvRow.IsNewRow)
                        dgvEntries.Rows.Remove(dgvRow);
                }

                lblTotalOblgtn.Text = $"Total: {GetTotalObligations(dgvEntries.Rows).ToString("N2")}";
            }
        }

        private void dgvEntries_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvEntries.IsCurrentCellDirty)
                dgvEntries.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvEntries_SelectionChanged(object sender, EventArgs e)
        {
            ToggleEntriesButtons(dgvEntries, tlStrpBtnEntrRemove);
        }

        private void cmbxFPP_Validating(object sender, CancelEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string label = cmb.Name.Replace("cmbx", "");

            if (string.IsNullOrEmpty(cmb.Text))
                e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmb, label + ".");
            else if (cmb == cmbxFPP)
                e.Cancel = ShowErrorFPPNameNotExist();
        }

        private void cmbxFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, (ComboBox)sender);
        }

        private void txtPayee_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtPayee, "Payee.");
        }

        private void txtPayee_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtPayee);
        }
    }
}