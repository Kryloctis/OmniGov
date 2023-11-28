using ACC.Data;
using ACC.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.RCI
{
    public partial class frmRCI : Form
    {
        public frmRCI()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgRCI, false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmRCIAdd(this).ShowDialog();
        }

        private void frmRCI_Load(object sender, EventArgs e)
        {
            LoadRCI();
        }

        private DataColumn[] RCIDataColumns()
        {
            var dataColumn = new DataColumn[]
            {
                new DataColumn("id", typeof(int)),
                new DataColumn("cheques_id", typeof(int)),
                new DataColumn("bank_accounts_id", typeof(int)),
                new DataColumn("bank_id", typeof(int)),
                new DataColumn("fund_id", typeof(int)),
                new DataColumn("fpp_id", typeof(int)),
                new DataColumn("cheque_no", typeof(string)),
                new DataColumn("cheque_date", typeof(DateTime)),
                new DataColumn("bank_account_no", typeof(string)),
                new DataColumn("bank_name", typeof(string)),
                new DataColumn("fund", typeof(string)),
                new DataColumn("dv_no", typeof(string)),
                new DataColumn("payee", typeof(string)),
                new DataColumn("nature_of_payment", typeof(string)),
                new DataColumn("obligation_no", typeof(string)),
                new DataColumn("date_entry", typeof(string)),
                new DataColumn("fpp", typeof(string)),
                new DataColumn("total_deductions", typeof(decimal)),
                new DataColumn("amount", typeof(decimal)),
                new DataColumn("created_at", typeof(string)),
                new DataColumn("updated_at", typeof(string)),
            };
            return dataColumn;
        }

        private DataTable InitializeRciDataTable(string searchText)
        {
            DataTable dtRCI = new DataTable();
            DataTable dtRCIFromDB;

            int rowCount = 0;
            int recordsCount;
            dtRCI.Columns.AddRange(RCIDataColumns());

            if (searchText.Length > 2)
                dtRCIFromDB = AccFactory.RCIRepository().GetViewRecordsBySearch(searchText);
            else
                dtRCIFromDB = AccFactory.RCIRepository().GetViewRecords();

            recordsCount = dtRCIFromDB.Rows.Count;

            foreach (DataRow row in dtRCIFromDB.Rows)
            {
                var newRow = dtRCI.NewRow();

                int id = Convert.ToInt32(row["id"]);
                int checkId = Convert.ToInt32(row["cheques_id"]);
                int bankAccountId = Convert.ToInt32(row["bank_accounts_id"]);
                int bankId = Convert.ToInt32(row["bank_id"]);
                int fundId = Convert.ToInt32(row["fund_id"]);
                string dateEntry = row["date_entry"].ToString();
                int fppId = Convert.ToInt32(row["fpp_id"]);
                string checkNo = row["cheque_no"].ToString();
                DateTime checkDate = Convert.ToDateTime(row["cheque_date"]);
                string bankAccountNo = row["bank_account_no"].ToString();
                string bankName = row["bank_name"].ToString();
                string fundName = row["fund_name"].ToString();
                string fundCode = row["fund_code"].ToString();
                string dvNo = row["dv_no"].ToString();
                string payee = row["payee"].ToString();
                string natureOfPayment = row["nature_of_payment"].ToString();
                string obligationNo = row["obligation_no"].ToString();
                string fppCode = row["fpp_code"].ToString();
                string fppName = row["fpp_name"].ToString();
                decimal totalDeduction = row.IsNull("total_deductions") ? 0 : Convert.ToDecimal(row["total_deductions"]);
                decimal amount = Convert.ToDecimal(row["amount"]);
                string createdAt = row["created_at"].ToString();
                string udpatedAt = row["updated_at"].ToString();

                newRow["id"] = id;
                newRow["cheques_id"] = checkId;
                newRow["bank_accounts_id"] = bankAccountId;
                newRow["bank_id"] = bankId;
                newRow["fund_id"] = fundId;
                newRow["date_entry"] = dateEntry;
                newRow["fpp_id"] = fppId;
                newRow["cheque_no"] = checkNo;
                newRow["cheque_date"] = checkDate;
                newRow["bank_account_no"] = bankAccountNo;
                newRow["bank_name"] = bankName;
                newRow["fund"] = $"{fundCode} - {fundName}";
                newRow["dv_no"] = dvNo;
                newRow["payee"] = payee;
                newRow["nature_of_payment"] = natureOfPayment;
                newRow["obligation_no"] = obligationNo;
                newRow["fpp"] = $"{fppCode} - {fppName}";
                newRow["total_deductions"] = totalDeduction;
                newRow["amount"] = amount;
                newRow["created_at"] = createdAt;
                newRow["updated_at"] = udpatedAt;

                rowCount++;
                int progressPercentage = (rowCount * 100) / recordsCount;
                backgroundWorker1.ReportProgress(progressPercentage);

                dtRCI.Rows.Add(newRow);
            }
            return dtRCI;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int rciID = Convert.ToInt32(dgRCI.SelectedRows[0].Cells["id"].Value);
            _ = new frmRCIEdit(this, rciID).ShowDialog();
        }

        private void DeleteRCI()
        {
            int selectedRowsCount = dgRCI.SelectedRows.Count;
            try
            {
                if (selectedRowsCount == 0)
                    return;

                if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                {
                    var rciModelList = new List<RCIModel>();
                    foreach (DataGridViewRow row in dgRCI.SelectedRows)
                    {
                        int rciId = Convert.ToInt16(row.Cells["id"].Value.ToString());
                        rciModelList.Add(new RCIModel() { Id = rciId });
                    }

                    _ = AccFactory.RCIRepository().Delete(rciModelList);
                    LoadRCI();
                }
            }
            catch (MySqlException Mysqlex)
            {
                switch (Mysqlex.Number)
                {
                    case 1451:
                        Helper.MessageBoxError($"Cannot delete selected records. It has been used as referenced to different record.");
                        break;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteRCI();
        }

        private void dgRCI_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgRCI, btnEdit, btnDelete);
            SetToolStripStatusData();
        }

        private void SetToolStripStatusData()
        {
            if (dgRCI.SelectedRows.Count == 1)
            {
                var createdAtIndex = Convert.ToByte(dgRCI.SelectedRows[0].Cells["created_at"].ColumnIndex);
                var updatedAtIndex = Convert.ToByte(dgRCI.SelectedRows[0].Cells["updated_at"].ColumnIndex);

                byte[] columnIndexTimestamp = { createdAtIndex, updatedAtIndex };
                Helper.ShowRecordTimestamp(dgRCI, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
                lblRecordCount.Text = Helper.GetDatagridViewRecordCount(dgRCI).ToString();
                return;
            }

            lblRecordCount.Text = Helper.GetDatagridViewRecordCount(dgRCI).ToString();
            lblCreatedAt.Text = string.Empty;
            lblUpdatedAt.Text = string.Empty;
        }

        internal void LoadRCI()
        {
            try
            {
                if (!backgroundWorker1.IsBusy)
                {
                    pbLoadRecords.Value = 0;
                    string searchText = txtSearch.Text.Trim();
                    backgroundWorker1.RunWorkerAsync(searchText);
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRCI();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            string searchText = e.Argument as string;
            var dtRci = InitializeRciDataTable(searchText);

            Invoke((MethodInvoker)delegate
            {
                HelperLoadRecords.RCIDatagridView(dtRci, dgRCI);
            });
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pbLoadRecords.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            SetToolStripStatusData();
        }
    }
}