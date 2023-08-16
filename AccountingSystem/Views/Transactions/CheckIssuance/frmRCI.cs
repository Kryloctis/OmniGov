using ACC.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
            LoadRecords();
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
                new DataColumn("cheque_date", typeof(string)),
                new DataColumn("bank_account_no", typeof(string)),
                new DataColumn("bank_name", typeof(string)),
                new DataColumn("fund_code", typeof(int)),
                new DataColumn("fund_name", typeof(string)),
                new DataColumn("dv_no", typeof(string)),
                new DataColumn("payee", typeof(string)),
                new DataColumn("nature_of_payment", typeof(string)),
                new DataColumn("obligation_no", typeof(string)),
                new DataColumn("date_entry", typeof(string)),
                new DataColumn("fpp_code", typeof(string)),
                new DataColumn("total_deductions", typeof(decimal)),
                new DataColumn("amount", typeof(decimal)),
                new DataColumn("created_at", typeof(string)),
                new DataColumn("updated_at", typeof(string)),
            };
            return dataColumn;
        }

        internal void LoadRecords()
        {
            DataTable dtRCI = new DataTable();
            int rowCount = 0;
            int recordsCount = 0;

            dtRCI.Columns.AddRange(RCIDataColumns());

            var dtRCIFromDB = AccFactory.RCIRepository().GetViewRecords();
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
                string checkDate = row["cheque_date"].ToString();
                string bankAccountNo = row["bank_account_no"].ToString();
                string bankName = row["bank_name"].ToString();
                string fundName = row["fund_name"].ToString();
                string fundCode = row["fund_code"].ToString();
                string dvNo = row["dv_no"].ToString();
                string payee = row["payee"].ToString();
                string natureOfPayment = row["nature_of_payment"].ToString();
                string obligationNo = row["obligation_no"].ToString();
                string fppCode = row["fpp_code"].ToString();
                decimal totalDeduction = Convert.ToDecimal(row["total_deductions"]);
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
                newRow["fund_code"] = fundCode;
                newRow["fund_name"] = fundName;
                newRow["dv_no"] = dvNo;
                newRow["payee"] = payee;
                newRow["nature_of_payment"] = natureOfPayment;
                newRow["obligation_no"] = obligationNo;
                newRow["fpp_code"] = fppCode;
                newRow["total_deductions"] = totalDeduction;
                newRow["amount"] = amount;
                newRow["created_at"] = createdAt;
                newRow["updated_at"] = udpatedAt;

            }

            HelperLoadRecords.RCIDatagridView(dtRCI, dgRCI);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int rciID = int.Parse(dgRCI.SelectedCells[0].Value.ToString());
            _ = new frmRCIEdit(this, rciID).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedrowscount = dgRCI.SelectedRows.Count;
            try
            {
                if (selectedrowscount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedrowscount))
                    {
                        var rciModelList = new List<RCIModel>();
                        foreach (DataGridViewRow row in dgRCI.SelectedRows)
                        {
                            int rciId = Convert.ToInt16(row.Cells[0].Value.ToString());
                            rciModelList.Add(new RCIModel() { Id = rciId });
                        }

                        var rciRepository = AccFactory.RCIRepository();
                        _ = rciRepository.Delete(rciModelList);
                        LoadRecords();
                    }
                }
            }
            catch (MySqlException Mysqlex)
            {
                switch (Mysqlex.Number)
                {
                    case 1451:
                        Helper.MessageBoxError($"Cannot delete selected records. It is referenced by atleast one record.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void dgRCI_SelectionChanged(object sender, EventArgs e)
        {
            ShowTimeStamp();
            Helper.EnableDisableToolStripButtons(dgRCI, btnEdit, btnDelete);
        }

        private void ShowTimeStamp()
        {
            if (dgRCI.SelectedRows.Count == 0) return;

            var createdAtIndex = Convert.ToByte(dgRCI.SelectedRows[0].Cells["created_at"].ColumnIndex - 1);
            var updatedAtIndex = Convert.ToByte(dgRCI.SelectedRows[0].Cells["updated_at"].ColumnIndex - 1);

            byte[] columnIndexTimestamp = { createdAtIndex, updatedAtIndex };
            Helper.ShowRecordTimestamp(dgRCI, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }
    }
}