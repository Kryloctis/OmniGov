using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AccountableForm
{
    public partial class frmAccountable : Form
    {
        public frmAccountable()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgAccountableForm, true);
        }

        internal void LoadRecords()
        {
            string searchText = txtSearch.Text.Trim();
            DataTable dataTable;

            if (string.IsNullOrWhiteSpace(searchText) || searchText.Length < 2)
                dataTable = AccFactory.AccountableFormsRepository().GetRecords();
            else
                dataTable = AccFactory.AccountableFormsRepository().GetRecordsBySearch(searchText);

            HelperLoadRecords.AccFormDatagridView(dataTable, dgAccountableForm);

            lblRecordCount.Text = dgAccountableForm.Rows.Count.ToString();
        }

        private void frmAccountable_Load(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAccountableAdd(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int rowIndex = dgAccountableForm.CurrentRow.Index;
            int accountableFormId = Convert.ToInt32(dgAccountableForm.Rows[rowIndex].Cells["id"].Value.ToString());

            _ = new frmAccountableEdit(this, accountableFormId).ShowDialog();
        }

        private void DeleteData()
        {
            int selectedrowscount = dgAccountableForm.SelectedRows.Count;

            if (selectedrowscount > 0)
            {
                if (Helper.MessageBoxConfirmDelete(selectedrowscount))
                {
                    var accModelList = new List<AccountableModel>();
                    foreach (DataGridViewRow row in dgAccountableForm.SelectedRows)
                    {
                        int rowId = Convert.ToInt16(row.Cells["id"].Value.ToString());
                        accModelList.Add(new AccountableModel() { Id = rowId });
                    }

                    _ = AccFactory.AccountableFormsRepository().Delete(accModelList);
                    LoadRecords();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteData();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadRecords();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgAccountableForm_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgAccountableForm, btnEdit, btnDelete);
            int selectedRowCount = dgAccountableForm.SelectedRows.Count;

            if (selectedRowCount > 0 && selectedRowCount == 1)
                btnFaceValue.Enabled = true;
            else
                btnFaceValue.Enabled = false;
        }

        private void btnFaceValue_Click(object sender, EventArgs e)
        {
            int rowIndex = dgAccountableForm.CurrentRow.Index;
            int accountableFormId = Convert.ToInt32(dgAccountableForm.Rows[rowIndex].Cells["id"].Value);
            _ = new frmFaceValue(accountableFormId).ShowDialog();
            LoadRecords();
        }
    }
}