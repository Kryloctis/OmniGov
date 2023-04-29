using ACC.Domain.Interfaces;
using AccountingSystem.Views.Reports.CollectorsRCD;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RCDCollector
{
    public partial class ucCollectorsRCD : UserControl
    {
        internal int reportId;
        internal byte fundId;
        internal ushort collectorId;
        internal ushort jobOrderId;
        internal bool isSaveFunction = true;

        public ucCollectorsRCD()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgPayments, true);
        }

        internal void ResetForm()
        {
            reportId = 0;
            fundId = 0;
            collectorId = 0;
            jobOrderId = 0;
            isSaveFunction = true;

            btnClear.Enabled = false;
            txtTotal.Text = "0.00";
            txtReport.Text = string.Empty;
            dtRCDDate.Value = DateTime.Now;
            dgPayments.Rows.Clear();
            dgPayments.Refresh();
        }

        internal string GetFormErrors()
        {
            var errorArray = new string[]
            {
                epReportNo.GetError(txtReport),
                epCollector.GetError(cmbCollector),
                epPayments.GetError(dgPayments)
            };
            return AccFactory.CreateErrors(errorArray).GenerateErrorMessage();
        }

        private void OnLoad()
        {
            if (!DesignMode)
            {
                LoadFunds();
                LoadCollectors();
                SelectCurrentLoggedInCollector();
            }
        }

        private void ucRCDCollector_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private DataColumn[] DataColumnsCollector()
        {
            return new DataColumn[]
            {
                new DataColumn(Name = "id", typeof(int)),
                new DataColumn(Name = "full_name", typeof(string))
            };
        }

        private DataTable DataTableCollector()
        {
            DataTable dtCollector = new DataTable();
            DataTable dataTable;
            dtCollector.Columns.AddRange(DataColumnsCollector());

            if (cbJOCollector.Checked)

                dataTable = AccFactory.CollectingOfficerHasJobOrdersRepository().GetRecords();
            else
                dataTable = AccFactory.CollectingOfficerRepository().GetRecords();

            foreach (DataRow row in dataTable.Rows)
            {
                var newRow = dtCollector.NewRow();
                int Id = Convert.ToInt32(row["id"]);
                string prefix = row["prefix"].ToString();
                string firstName = row["first_name"].ToString();
                string middleInitial = row["mid_initial"].ToString();
                string lastName = row["last_name"].ToString();
                string suffix = row["suffix"].ToString();
                string fullName = Helper.GenerateFullName(prefix, firstName, middleInitial, lastName, suffix);

                newRow["id"] = Id;
                newRow["full_name"] = fullName;
                dtCollector.Rows.Add(newRow);
            }
            return dtCollector;
        }

        private void LoadCollectors()
        {
            HelperLoadRecords.CollectingOfficerComboBox(DataTableCollector(), cmbCollector, "full_name", "id");
            collectorId = Convert.ToUInt16(cmbCollector.SelectedValue);
        }

        private void SelectCurrentLoggedInCollector()
        {
            try
            {
                var usersRepo = AccFactory.UsersRepository();

                if (usersRepo.LinkedCollector(Helper.UserId))
                {
                    cbJOCollector.Enabled = false;
                    cmbCollector.Enabled = false;
                    cmbCollector.SelectedValue = AccFactory.CollectingOfficerRepository().GetRecordByUserID(Helper.UserId)["id"];
                    return;
                }
                else if (usersRepo.LinkedJobOrder(Helper.UserId))
                {
                    cbJOCollector.Checked = true;
                    cbJOCollector.Enabled = false;
                    cmbCollector.Enabled = false;
                    cmbCollector.SelectedValue = AccFactory.JobOrderRepository().GetRecordByUserID(Helper.UserId)["id"];
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal void LoadFunds()
        {
            var funds = AccFactory.FundsRepository().GetRecords();

            foreach (DataRow fund in funds.Rows)
            {
                var radFund = new RadioButton
                {
                    Text = fund["fund_name"].ToString(),
                    Tag = fund["id"],
                    AutoSize = true,
                    Appearance = Appearance.Button,
                    TextImageRelation = TextImageRelation.ImageBeforeText
                };

                if (fund["fund_name"].ToString() == "General Fund")
                {
                    radFund.Checked = true;
                    fundId = Convert.ToByte(fund["id"]);
                    if (radFund.Checked)
                        radFund.Image = Properties.Resources.ok14px;
                    else
                        radFund.Image = null;
                }

                flowLayoutPanelFunds.Controls.Add(radFund);

                radFund.Click += (s, e) =>
                {
                    var radFund = s as RadioButton;
                    fundId = Convert.ToByte(radFund.Tag);
                };
                radFund.CheckedChanged += (s, e) =>
                {
                    var radFund = s as RadioButton;
                    if (radFund.Checked)
                        radFund.Image = Properties.Resources.ok14px;
                    else
                        radFund.Image = null;
                };
            }
        }

        internal void TotalCollections()
        {
            string TotalCollections;

            TotalCollections = (from DataGridViewRow row in dgPayments.Rows
                                where !String.IsNullOrEmpty(row.Cells["amount"].FormattedValue.ToString())
                                select Convert.ToDecimal(row.Cells["amount"].FormattedValue)).Sum().ToString("N2");

            txtTotal.Text = TotalCollections;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            collectorId = (ushort)Convert.ToInt32(cmbCollector.SelectedValue);
            _ = new frmCollectorsRCDLoad(fundId, collectorId, this).ShowDialog();
        }

        internal void ActionPerformIsSave(bool isSave)
        {
            isSaveFunction = isSave;
        }

        private void cmbCollector_SelectionChangeCommitted(object sender, EventArgs e)
        {
            collectorId = (ushort)Convert.ToSByte(cmbCollector.SelectedValue);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dgPayments.SelectedRows)
            {
                dgPayments.Rows.RemoveAt(item.Index);
            }

            TotalCollections();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            dgPayments.Rows.Clear();
            btnClear.Enabled = false;

            TotalCollections();
        }

        private void dgPayments_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRowCount = dgPayments.SelectedRows.Count;
            var rowCount = dgPayments.Rows.Count;

            btnRemove.Enabled = selectedRowCount != 0;
            btnClear.Enabled = rowCount > 0;

            TotalCollections();
        }

        #region Validation

        private void txtReport_Validating(object sender, CancelEventArgs e)
        {
            string reportNo = txtReport.Text.Trim();
            bool reportNoExist;

            if (string.IsNullOrEmpty(reportNo))
            {
                e.Cancel = Helper.ShowErrorTextBoxEmpty(epReportNo, txtReport, "Report No.");
                return;
            }

            if (isSaveFunction)
                reportNoExist = AccFactory.CollectorReportRepository().ReportNumberExist(reportNo);
            else
                reportNoExist = AccFactory.CollectorReportRepository().ReportNumberExist(reportId, reportNo);

            if (reportNoExist)
            {
                epReportNo.SetError(txtReport, "Report number already existed.");
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void txtReport_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorTextBox(epReportNo, txtReport);
        }

        private void dgPayments_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorDatagridView(epPayments, dgPayments, "Payments.");
        }

        private void dgPayments_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorDatagridView(epPayments, dgPayments);
        }

        private void cmbCollector_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = Helper.ShowErrorComboBoxEmpty(epCollector, cmbCollector, "Collector.");
        }

        private void cmbCollector_Validated(object sender, EventArgs e)
        {
            Helper.ClearErrorComboBox(epCollector, cmbCollector);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void cbJOCollector_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LoadCollectors();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }

    #endregion Validation
}