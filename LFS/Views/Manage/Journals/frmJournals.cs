using ACC.Data;
using ACC.Domain.Models;
using LFS.Views.Manage.Journals.DefaultAccounts;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LFS.Views.Manage.Journals
{
    public partial class frmJournals : Form
    {
        public frmJournals()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void UserVerification()
        {
            var dictLoggedInUser = Helper.LoggedInUserData();
            if (dictLoggedInUser["role_name"] != "System Administrator")
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        internal void LoadRecords()
        {
            HelperLoadRecords.JournalsDatagridView(dgJournals);
            lblRecordCount.Text = dgJournals.Rows.Count.ToString();
        }

        private void frmJournals_Load(object sender, EventArgs e)
        {
            try
            {
                OnLoad();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void OnLoad()
        {
            UserVerification();
            Helper.DatagridFullRowSelectStyle(dgJournals, true);
            LoadRecords();
        }

        private void dgJournals_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                byte[] columnIndexTimestamp = { 3, 4 };
                Helper.ShowRecordTimestamp(dgJournals, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
                Helper.EnableDisableToolStripButtons(dgJournals, btnEdit, btnDelete);
                int journalId = Convert.ToInt32(dgJournals.CurrentRow.Cells["id"].Value);
                if (journalId == 1) btnDefaultAccounts.Enabled = false;
                else btnDefaultAccounts.Enabled = true;
                UserVerification();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmJournalsAdd(this).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int journalId = int.Parse(dgJournals.SelectedCells[0].Value.ToString());
                _ = new frmJournalsEdit(this, journalId).ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool DeleteData()
        {
            int selectedRowsCount = dgJournals.SelectedRows.Count;
            if (selectedRowsCount > 0)
            {
                if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                {
                    var journalsModelList = new List<JournalsModel>();
                    foreach (DataGridViewRow row in dgJournals.SelectedRows)
                    {
                        int journalId = Convert.ToInt16(row.Cells[0].Value.ToString());
                        journalsModelList.Add(new JournalsModel() { Id = journalId });
                    }

                    return AccFactory.JournalsRepository().Delete(journalsModelList);
                }
            }
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteData())
                    LoadRecords();
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 1451:
                        Helper.MessageBoxError($"Cannot delete record. Journal was referenced.");
                        break;
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void showDefaultAccounts()
        {
            var frmJournalDefaultAccounts = new frmDefaultAccounts();
            int journalId = Convert.ToInt32(dgJournals.CurrentRow.Cells["id"].Value);
            frmJournalDefaultAccounts.journalId = journalId;
            frmJournalDefaultAccounts.ShowDialog();
        }

        private void btnDefaultAccounts_Click(object sender, EventArgs e)
        {
            try
            {
                showDefaultAccounts();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}