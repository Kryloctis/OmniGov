using ACC.Data;
using ACC.Domain.Models;
using LFS.Helpers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LFS.Views.Manage.AccountableForm
{
    public partial class frmFaceValue : Form
    {
        internal int accountableFormId;
        internal int faceValueId;

        public frmFaceValue(int accountableFormId)
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgfacevalue);
            this.accountableFormId = accountableFormId;
        }

        private void frmFaceValue_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            try
            {
                if (accountableFormId != 0)
                {
                    var facevaluerepo = AccFactory.FaceValueRepository();
                    var dtFaceValue = facevaluerepo.GetRecordsByAccountableFormId(accountableFormId);

                    HelperLoadRecords.FaceValueDatagridView(dtFaceValue, dgfacevalue);
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void dgfacevalue_SelectionChanged(object sender, EventArgs e)
        {
            if (dgfacevalue.Rows.Count > 0 && dgfacevalue.SelectedRows.Count > 0)
            {
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }

            byte[] columnIndexTimestamp = { 4, 5 };
            Helper.ShowRecordTimestamp(dgfacevalue, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgfacevalue.SelectedRows.Count > 0)
            {
                int Id = int.Parse(dgfacevalue.SelectedCells[0].Value.ToString());
                try
                {
                    var facevaluerepo = AccFactory.FaceValueRepository();
                    var faceval = facevaluerepo.GetRecordByID(Id);
                    faceValueId = int.Parse(faceval["id"]);
                    dtdate.Value = Convert.ToDateTime(faceval["date"]);
                    txtamount.Value = decimal.Parse(faceval["amount"]);
                }
                catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgfacevalue.SelectedRows.Count > 0)
            {
                if (Helper.MessageBoxConfirmDelete(dgfacevalue.SelectedRows.Count))
                {
                    var facemodel = new List<FaceValueModel>();
                    var facevaluerepo = AccFactory.FaceValueRepository();
                    foreach (DataGridViewRow row in dgfacevalue.SelectedRows)
                    {
                        int fid = int.Parse(row.Cells[0].Value.ToString());
                        facemodel.Add(new FaceValueModel() { id = fid });
                    }
                    if (facevaluerepo.Delete(facemodel))
                    {
                        LoadList();
                    }
                }
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (faceValueId != 0)
                SaveFaceValue();
            else
                UpdateFaceValue();
        }

        private void UpdateFaceValue()
        {
            if (txtamount.Value == 0)
            {
                errorProvider.SetError(txtamount, "Please set face value amount.");
                txtamount.Focus();
            }

            try
            {
                var facemodel = new FaceValueModel()
                {
                    accountable_forms_id = accountableFormId,
                    facedate = dtdate.Value,
                    facevalue = txtamount.Value
                };
                var facevaluerepo = AccFactory.FaceValueRepository();
                if (facevaluerepo.Insert(facemodel))
                    faceValueId = 0;
                dtdate.Value = DateTime.Now;
                txtamount.Value = 0;
                LoadList();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void SaveFaceValue()
        {
            if (txtamount.Value == 0)
            {
                errorProvider.SetError(txtamount, "Please set face value amount.");
                txtamount.Focus();
                return;
            }

            try
            {
                var facemodel = new FaceValueModel()
                {
                    id = faceValueId,
                    accountable_forms_id = accountableFormId,
                    facedate = dtdate.Value,
                    facevalue = txtamount.Value,
                };

                var facevaluerepo = AccFactory.FaceValueRepository();
                if (facevaluerepo.Update(facemodel))
                    faceValueId = 0;
                dtdate.Value = DateTime.Now;
                txtamount.Value = 0;
                LoadList();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }
    }
}