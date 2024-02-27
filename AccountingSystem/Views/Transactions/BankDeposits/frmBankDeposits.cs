using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.BankDeposits
{
    public partial class frmBankDeposits : Form
    {
        public frmBankDeposits()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgbankdeposits, true);
        }

        private void frmBankDeposits_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        internal void LoadRecords()
        {
            var depositsRepository = AccFactory.BankDepositsRepository();
            var dtdeposits = depositsRepository.GetRecords();
            HelperLoadRecords.DepositsDatagridView(dtdeposits, dgbankdeposits);

            lblRecordCount.Text = depositsRepository.CountRecords().ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedrowscount = dgbankdeposits.SelectedRows.Count;
            try
            {
                if (Helper.MessageBoxConfirmDelete(selectedrowscount))
                {
                    var bdModelList = new List<BankDepositsModel>();
                    foreach (DataGridViewRow row in dgbankdeposits.SelectedRows)
                    {
                        int bdId = Convert.ToInt16(row.Cells[0].Value.ToString());
                        bdModelList.Add(new BankDepositsModel() { Id = bdId });
                    }

                    var bdRepository = AccFactory.BankDepositsRepository();
                    _ = bdRepository.Delete(bdModelList);
                    LoadRecords();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgbankdeposits_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgbankdeposits.Columns.Count < 1)
                    return;

                byte createdByIndex = (byte)dgbankdeposits.Columns["created_at"].Index;
                byte updatedByIndex = (byte)dgbankdeposits.Columns["updated_at"].Index;

                var indexes = new byte[] { createdByIndex, updatedByIndex };
                EnableDisableToolStripButtons(dgbankdeposits, btnEdit, btnDelete);
                Helper.ShowRecordTimestamp(dgbankdeposits, indexes, toolStripStatusLabelCreatedAt, toolStripStatusLabelUpdatedAt);

                byte[] columnIndexData = { 6, 7, 8, 9 };
                Helper.ShowRecordTimestamp(dgbankdeposits, columnIndexData, lblCreatedAt, lblUpdatedAt);
                Helper.EnableDisableToolStripButtons(dgbankdeposits, btnEdit, btnDelete);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        public static void EnableDisableToolStripButtons(DataGridView dgv, ToolStripButton tsBtnEdit, ToolStripButton tsBtnDelete)
        {
            int SelectedRows = dgv.SelectedRows.Count;
            if (SelectedRows == 1)
            {
                tsBtnEdit.Enabled = true;
                tsBtnDelete.Enabled = true;
            }
            else if (SelectedRows > 1)
            {
                tsBtnEdit.Enabled = false;
                tsBtnDelete.Enabled = true;
            }
            else
            {
                tsBtnEdit.Enabled = false;
                tsBtnDelete.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmBankDepositsAdd(this, 0, string.Empty, 0).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int bankDepositID = int.Parse(dgbankdeposits.SelectedCells[0].Value.ToString());
                _ = new frmBankDepositsEdit(this, bankDepositID).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string searchkey = txtSearch.Text.Trim();

                if (searchkey.Length < 1)
                {
                    LoadRecords();
                    return;
                }

                var dtBankDeposits = AccFactory.BankDepositsRepository().GetRecordsBySearch(searchkey);
                HelperLoadRecords.DepositsDatagridView(dtBankDeposits, dgbankdeposits);
                lblRecordCount.Text = dgbankdeposits.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}