using ACC.Domain.Models;
using System;
using System.Collections.Generic;
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

        internal void LoadSignatories()
        {
            try
            {
                var dtSignatories = Factory.SignatoriesRepository().GetRecords();

                HelperLoadRecords.SignatoriesDatagridView(dtSignatories, dgSignatories);
                lblRecordCount.Text = dgSignatories.Rows.Count.ToString();
                Helper.ShowRecordTimestamp(dgSignatories, new byte[] { 3, 4 }, lblCreatedAt, lblUpdatedAt);
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

        private void dtSignatories_SelectionChanged(object sender, System.EventArgs e)
        {
            EnableDisableButtons();
        }

        private void frmSignatories_Load(object sender, System.EventArgs e)
        {
            EnableDisableButtons();
            LoadSignatories();
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

                        _ = Factory.SignatoriesRepository().Delete(signatoriesModelList);
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
