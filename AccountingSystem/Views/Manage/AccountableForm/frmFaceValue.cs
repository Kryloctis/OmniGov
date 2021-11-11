using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AccountableForm
{
    public partial class frmFaceValue : Form
    {
        internal int id = 0;
        internal int faceid = 0;

        public frmFaceValue(int _id)
        {
            InitializeComponent();
            Helper.DatagridDefaultStyle(dgfacevalue);
            id = _id;
        }

        private void frmFaceValue_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            try
            {
                if (id > 0)
                {
                    var facevaluerepo = Factory.FaceValueRepository();
                    var dtfacevalue = facevaluerepo.GetRecords(id);
                    HelperLoadRecords.FaceValueDatagridView(dtfacevalue, dgfacevalue);
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }


        private void btnrefresh_Click(object sender, EventArgs e)
        {
            faceid = 0;
            dtdate.Value = DateTime.Now;
            txtamount.Value = 0;
            LoadList();
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

                    var facevaluerepo = Factory.FaceValueRepository();
                    var faceval = facevaluerepo.GetRecordByID(Id);
                    faceid = int.Parse(faceval["id"]);
                    dtdate.Value = Convert.ToDateTime(faceval["facedate"]);
                    txtamount.Value = decimal.Parse(faceval["facevalue"]);
                }
                catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgfacevalue.SelectedRows.Count > 0)
            {
                if (Helper.MessageBoxConfirmDelete(dgfacevalue.SelectedRows.Count))
                {
                    var facemodel = new List<FaceValueModel>();
                    var facevaluerepo = Factory.FaceValueRepository();
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

        private void frmFaceValue_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if(faceid > 0)
            {
                if (txtamount.Value <= 0)
                {
                    errorProvider.SetError(txtamount, "Please set face value amount!");
                    txtamount.Focus();
                }
                else
                {
                    try
                    {
                        var facemodel = new FaceValueModel()
                        {
                            id = faceid,
                            accountable_forms_id = id,
                            facedate = dtdate.Value,
                            facevalue = txtamount.Value,
                        };
                        var facevaluerepo = Factory.FaceValueRepository();
                        if (facevaluerepo.Update(facemodel))
                            faceid = 0;
                            dtdate.Value = DateTime.Now;
                            txtamount.Value = 0;
                            LoadList();
                    }
                    catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
                }
            }
            else
            {
                if (txtamount.Value <= 0)
                {
                    errorProvider.SetError(txtamount, "Please set face value amount!");
                    txtamount.Focus();
                }
                else
                {
                    try
                    {
                        var facemodel = new FaceValueModel()
                        {
                            accountable_forms_id = id,
                            facedate = dtdate.Value,
                            facevalue = txtamount.Value
                        };
                        var facevaluerepo = Factory.FaceValueRepository();
                        if (facevaluerepo.Insert(facemodel))
                            faceid = 0;
                            dtdate.Value = DateTime.Now;
                            txtamount.Value = 0;
                            LoadList();
                    }
                    catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
                }
            }
            
        }
    }
}
