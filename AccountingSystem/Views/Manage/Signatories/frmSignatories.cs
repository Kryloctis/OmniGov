using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Signatories
{
    public partial class frmSignatories : Form
    {
        public frmSignatories()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private DataTable SignatoriesDatatable()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("id");
            dataTable.Columns.Add("name");
            dataTable.Columns.Add("title");
            dataTable.Columns.Add("created_at");
            dataTable.Columns.Add("updated_at");

            try
            {
                var dictUserLoggedIn = Helper.LoggedInUserData();
                var dtSignatories = AccFactory.SignatoriesHasReferencesRepository().GetRecordsByOffice(dictUserLoggedIn["office"]);

                foreach (DataRow row in dtSignatories.Rows)
                {
                    int signatoryId = Convert.ToInt32(row["signatories_id"]);
                    string prefix = row["signatories_prefix"].ToString();
                    string firstName = row["signatories_first_name"].ToString();
                    char middleInitial = Convert.ToChar(row["signatories_middle_initial"]);
                    string lastName = row["signatories_last_name"].ToString();
                    string suffix = row["signatories_suffix"].ToString();
                    string title = row["signatories_title"].ToString();
                    string createdAt = row["signatories_created_at"].ToString();
                    string updatedAt = row["signatories_updated_at"].ToString();
                    string signatoryName = $"{(string.IsNullOrEmpty(prefix) ? string.Empty : $"{prefix}.")} {firstName} {middleInitial}. {lastName} {(string.IsNullOrEmpty(suffix) ? string.Empty : $", {suffix}")}";

                    var item = new dynamic[] { signatoryId, signatoryName, title, createdAt, updatedAt };

                    dataTable.Rows.Add(item);
                }

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }

            return dataTable;
        }

        internal void LoadSignatories()
        {
            try
            {
                HelperLoadRecords.SignatoriesDatagridView(SignatoriesDatatable(), dgSignatories);
                lblRecordCount.Text = dgSignatories.Rows.Count.ToString();
                Helper.ShowRecordTimestamp(dgSignatories, new byte[] { 3, 4 }, lblCreatedAt, lblUpdatedAt);
                dgSignatories.CurrentCell = dgSignatories.FirstDisplayedCell;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        internal void LoadReferencedDocuments()
        {
            try
            {
                listDocuments.Items.Clear();

                if (dgSignatories.SelectedRows.Count == 1)
                {
                    int signatoriesId = Convert.ToInt32(dgSignatories.Rows[dgSignatories.CurrentCell.RowIndex].Cells["id"].Value);

                    var dtReferencedDocuments = AccFactory.SignatoriesHasReferencesRepository().GetDocumentRecordsBySignatoryId(signatoriesId);
                    foreach (DataRow row in dtReferencedDocuments.Rows)
                    {
                        listDocuments.Items.Add(row["documents_name"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            _ = new frmAddSignatories(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            int signatoriesId = Convert.ToInt32(dgSignatories.Rows[dgSignatories.CurrentRow.Index].Cells["id"].Value);

            var _frmEditSignatories = new frmEditSignatories(this);
            _frmEditSignatories.uc.signatoriesId = signatoriesId;
            _frmEditSignatories.ShowDialog();
        }

        private void EnableDisableButtons()
        {
            Helper.EnableDisableToolStripButtons(dgSignatories, btnEdit, btnDelete);
        }

        private void dgSignatories_SelectionChanged(object sender, System.EventArgs e)
        {
            EnableDisableButtons();
            LoadReferencedDocuments();
        }

        private void frmSignatories_Load(object sender, System.EventArgs e)
        {
            Helper.DatagridFullRowSelectStyle(dgSignatories, true);
            LoadSignatories();
            EnableDisableButtons();          
        }

        private void DeleteRealignment()
        {
            try
            {
                int selectedRowCount = 0;

                foreach (DataGridViewRow row in dgSignatories.SelectedRows)
                {
                    if (row.Cells[0].Value != null)
                        selectedRowCount += 1;
                }

                if (selectedRowCount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedRowCount))
                    {
                        var signatoriesModelList = new List<SignatoriesModel>();

                        foreach (DataGridViewRow row in dgSignatories.SelectedRows)
                        {
                            if (row.Cells[0].Value != null)
                            {
                                ushort signatoriesId = (ushort)Convert.ToInt16(row.Cells["id"].Value);

                                var signatoriesModel = new SignatoriesModel()
                                {
                                    Id = signatoriesId
                                };

                                signatoriesModelList.Add(signatoriesModel);
                            }
                        }

                        _ = AccFactory.SignatoriesRepository().Delete(signatoriesModelList);
                        LoadSignatories();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteRealignment();
        }
    }
}
