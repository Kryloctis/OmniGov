using ACC.Data;
using LFS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LFS.Views.Transactions.ObligationRequest
{
    public partial class ucObligations : UserControl
    {
        private bool isEdit;
        private int oblgtnRqstId;
        private int fundId;

        public ucObligations()
        {
            InitializeComponent();
        }

        internal void OnLoad(bool isEdit, int? oblgtnRqstId = null)
        {
            Helper.DatagridEditableRowStyle(dgvEntries, true);
            dgvEntries.RowTemplate.Height = 30;

            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
            LoadFPP();
            LoadAlltmntClss();
            LoadFunds();
            //GetTotalObligations();

            if (isEdit)
            {
                this.oblgtnRqstId = oblgtnRqstId.Value;
            }
            InitializeEntriesTbl();
            dgvEntries.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            ToggleEntriesButtons(dgvEntries, tlStrpBtnEntrRemove);
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
            if (isEdit)
            {
                isEdit = false;
                oblgtnRqstId = 0;
            }

            LoadFPP();
            LoadFunds();
            cmbxFPP.SelectedValue = 0;
            cmbxFPP.Text = string.Empty;
            mskTxtOblgtnNo.Text = string.Empty;
            dtDateRequest.Value = DateTime.Now;
            txtReferenceNo.Text = string.Empty;
            txtPayee.Text = string.Empty;
            txtExplanation.Text = string.Empty;
            dgvEntries.Rows.Clear();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(cmbxFPP),
                errorProvider1.GetError(txtReferenceNo),
                errorProvider1.GetError(txtPayee),
                errorProvider1.GetError(txtExplanation),
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private void SetControlsReadOnly(Control parent, bool isReadOnly)
        {
            foreach (var c in parent.Controls.Cast<Control>()
                         .Where(c => c is ComboBox || c is DateTimePicker || c is TextBoxBase || c is LinkLabel))
            {
                if (c is TextBoxBase tb)
                {
                    tb.ReadOnly = isReadOnly;
                    continue;
                }

                c.Enabled = !isReadOnly;
            }

            dgvEntries.SelectionChanged -= dgvEntries_SelectionChanged;
        }

        internal void SetFieldsReadOnly(bool isReadOnly)
        {
            var parents = new Control[]
            {
                splitContainer2.Panel1,
                panel2,
            };

            foreach (var p in parents)
                SetControlsReadOnly(p, isReadOnly);

            tlStrpBtnEntrAdd.Enabled = !isReadOnly;
            tlStrpBtnEntrRemove.Enabled = !isReadOnly;
            txtExplanation.ReadOnly = isReadOnly;
            dgvEntries.ReadOnly = isReadOnly;
        }

        private decimal GetTotalObligations()
        {
            decimal totalObligation = 0;

            foreach (DataGridViewRow row in dgvEntries.Rows)
                totalObligation += Convert.ToDecimal(row.Cells["obligation_amount"].Value);

            return totalObligation;
        }

        private void dgvEntries_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadAlltmntClss()
        {
            var dtAlltmntClss = AccFactory.AllotmentClassesRepository().GetRecords();

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

        private DataTable DtFpp()
        {
            DataTable dtFPP;

            if (string.IsNullOrWhiteSpace(cmbxFPP.Text))
                dtFPP = AccFactory.FunctionProgramProjectRepository().GetViewRecords();
            else
                dtFPP = AccFactory.FunctionProgramProjectRepository().GetRecordsByCodeName(cmbxFPP.Text.Trim());

            return dtFPP;
        }

        private void LoadFPP()
        {
            cmbxFPP.DroppedDown = false;

            var dt = DtFpp();
            if (dt.Rows.Count == 0) return;

            var fppDict = dt
                .AsEnumerable()
                .ToDictionary(
                    r => r.Field<UInt32>("id"),
                    r => $"{r.Field<string>("fpp_code")} - {r.Field<string>("fpp_name")}"
                );

            cmbxFPP.DataSource = new BindingSource(fppDict, null);
            cmbxFPP.DisplayMember = "value";
            cmbxFPP.ValueMember = "key";
            cmbxFPP.DropDownHeight = 200;
        }

        private void cmbxFPP_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cmbxFPP.Text))
                {
                    cmbxFPP.TextChanged -= new EventHandler(cmbxFPP_TextChanged);
                    LoadFPP();
                    cmbxFPP.SelectedIndex = -1;
                    cmbxFPP.TextChanged += new EventHandler(cmbxFPP_TextChanged);
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxFPP_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1 && cmbxFPP.FindStringExact(cmbxFPP.Text) == -1 && !string.IsNullOrEmpty(cmbxFPP.Text))
                {
                    LoadFPP();
                    cmbxFPP.DroppedDown = true;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadFunds()
        {
            var dtFunds = AccFactory.FundsRepository().GetRecords();
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

        private string GenerateObligationRequestNoTemplate()
        {
            string fundCode = AccFactory.FundsRepository().GetRecordByID(fundId)["fund_code"];

            string obligationNoTemplate = $"{dtDateRequest.Value.ToString("MM")}-{dtDateRequest.Value.ToString("yy")}-{fundCode}";

            return obligationNoTemplate;
        }

        private void dtDateRequest_ValueChanged(object sender, EventArgs e)
        {
        }

        internal string GetFormErrorsAdd()
        {
            var errorArray = new string[]
            {
                errorProvider1.GetError(cmbxFPP)
            };

            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private bool Validation()
        {
            if (ShowErrorFPPNameNotExist() || Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxFPP, "FPP"))
            {
                Helper.MessageBoxError(GetFormErrorsAdd());
                return false;
            }
            else
            {
                Helper.ClearErrorComboBox(errorProvider1, cmbxFPP);
                return true;
            }
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

        private void cmbxFPP_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cmbxFPP.Text))
                    e.Cancel = Helper.ShowErrorComboBoxEmpty(errorProvider1, cmbxFPP, "FPP.");
                else
                    e.Cancel = ShowErrorFPPNameNotExist();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxFPP_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(errorProvider1, cmbxFPP);
        }

        private void txtPayee_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(errorProvider1, txtPayee, "Payee.");
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtPayee_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(errorProvider1, txtPayee);
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
                    Name = "sub_fpp",
                    ValueMember = "id",
                    DisplayMember = "others_fpp",
                    DataSource = DtSubFpp(),
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
                    DefaultCellStyle = {Format = "N2",
                                        NullValue = 0m},
                },
            };

            return dtColumns;
        }

        private void tlStrpBtnEntrAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //string jrnlType = cmbxJournal.Text;
                //var validateRow = RowsValidated(dgAccounts, jrnlType);

                //if (!validateRow.isValidated)
                //{
                //    var errMssg = AccFactory.CreateErrors(validateRow.errors).GenerateErrorMessage();
                //    Helper.MessageBoxError(errMssg);
                //    return;
                //}

                int r = dgvEntries.Rows.Add();
                dgvEntries.Rows[r].Cells["sub_fpp"].Value = 0;
                dgvEntries.CurrentCell = dgvEntries.Rows[r].Cells["sub_fpp"];
                dgvEntries.BeginEdit(true);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void tlStrpBtnEntrRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int count = dgvEntries.SelectedRows.Count;
                if (count == 0) return;

                string msg = $"Are you sure you want to remove {(count == 1 ? "the entry" : $"{count} accounting entries")}?";

                if (MessageBox.Show(msg, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dgvRow in dgvEntries.SelectedRows)
                    {
                        dgvEntries.Rows.RemoveAt(dgvRow.Index);
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void cmbxFPP_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                dgvEntries.Rows.Clear();
                DataGridViewComboBoxColumn dgvColumn = (DataGridViewComboBoxColumn)dgvEntries.Columns["sub_fpp"];
                dgvColumn.DataSource = null;
                dgvColumn.DataSource = DtSubFpp();
                dgvColumn.ValueMember = "id";
                dgvColumn.DisplayMember = "others_fpp";
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgvEntries_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvEntries.IsCurrentCellDirty)
                    dgvEntries.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private DataTable DtSubFpp()
        {
            bool fppValid = int.TryParse(cmbxFPP.SelectedValue.ToString(), out int fppId);
            var dtSubFpp = AccFactory.SubFPPRepository().GetRecordsByFppId(fppId);
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
            var dbDtAllotmentRelease = AccFactory.AllotmentReleaseRepository().GetViewRecords(fppId, othersFppId == 0 ? null : othersFppId, alltmntClssId, searchKey);

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
            var dtAccs = AccFactory.AllotmentReleaseRepository().GetViewRecords(alltmntRlsId);

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

        private void PopulateAllotmentReleaseCell(int rowIndex, DataGridView dataGridView)
        {
            // Build DataSource
            var othersFppId = (int)dataGridView.Rows[rowIndex].Cells["sub_fpp"].Value;
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

        private void dgvEntries_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                string col = dgvEntries.Columns[e.ColumnIndex].Name;

                if (col == "sub_fpp")
                    PopulateAllotmentReleaseCell(e.RowIndex, dgvEntries);

                if (col == "aro_no")
                    PopulateAccountsCell(e.RowIndex, dgvEntries);

                if (col == "account")
                    GetUnobligatedBalance(e.RowIndex, dgvEntries);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgvEntries_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (dgvEntries.Columns[e.ColumnIndex].Name == "amount")
            {
                // Replace invalid value with zero
                dgvEntries.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0m;

                e.ThrowException = false;
                e.Cancel = true;
            }
        }

        private void dgvEntries_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEntries.Columns[e.ColumnIndex].Name == "amount")
            {
                var cell = dgvEntries.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell.Value == null || !decimal.TryParse(cell.Value.ToString(), out var result))
                {
                    cell.Value = 0m;
                }
                else
                {
                    cell.Value = result;
                }
            }
        }
    }
}