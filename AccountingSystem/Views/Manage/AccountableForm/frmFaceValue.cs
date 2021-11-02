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
        internal byte fdefault = 0;
        bool is_default = false;

        public frmFaceValue(int _id)
        {
            InitializeComponent();
            Helper.DatagridDefaultStyle(dgfacevalue);
            id = _id;
        }

        private void frmFaceValue_Load(object sender, EventArgs e)
        {
            LoadYear();
            LoadList();
        }

        private void LoadList()
        {
            try
            {
                if(id > 0)
                {
                    var facevaluerepo = Factory.FaceValueRepository();
                    var dtfacevalue = facevaluerepo.GetRecords(id);
                    HelperLoadRecords.FaceValueDatagridView(dtfacevalue, dgfacevalue);

                    foreach (DataGridViewRow r in dgfacevalue.Rows)
                    {
                        int df = int.Parse(r.Cells[4].Value.ToString());
                        if(df > 0)
                        {
                            r.DefaultCellStyle.BackColor = Color.Green;
                        }
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadYear()
        {
            try
            {
                for(int i = DateTime.Now.Year; i > 1950; i--)
                {
                    cmbyear.Items.Add(i);
                    
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            faceid = 0;
            fdefault = 0;
            cmbyear.SelectedIndex = -1;
            txtamount.Value = 0;
            LoadList();
        }

        private void dgfacevalue_SelectionChanged(object sender, EventArgs e)
        {
            if (dgfacevalue.Rows.Count > 0 && dgfacevalue.SelectedRows.Count > 0)
            {
                btnSet.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnSet.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if(dgfacevalue.SelectedRows.Count > 0)
            {
                int Id = int.Parse(dgfacevalue.SelectedCells[0].Value.ToString());
                try
                {

                    var facevaluerepo = Factory.FaceValueRepository();
                    _ = facevaluerepo.SetDefault(Id);
                    LoadList();
                }
                catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            }
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
                    cmbyear.SelectedIndex= cmbyear.FindStringExact(faceval["faceyear"]);
                    txtamount.Value = decimal.Parse(faceval["facevalue"]);
                    fdefault = byte.Parse(faceval["facedefault"]);
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
            if(dgfacevalue.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgfacevalue.Rows)
                {
                    int fid = int.Parse(row.Cells[4].Value.ToString());
                    if(fid > 0)
                    {
                        is_default = true;
                    }                   
                }

                if (is_default)
                {
                    e.Cancel = false;
                }
                else
                {                   
                    e.Cancel = true;
                    Helper.MessageBoxError("Please select default face value!");
                }
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if(faceid > 0)
            {
                if (cmbyear.SelectedIndex == -1)
                {
                    errorProvider.SetError(cmbyear, "Please select face value year!");
                    cmbyear.Focus();
                }
                else if (txtamount.Value <= 0)
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
                            faceyear = int.Parse(cmbyear.SelectedItem.ToString()),
                            facevalue = txtamount.Value,
                            facedefault = fdefault
                        };
                        var facevaluerepo = Factory.FaceValueRepository();
                        if (facevaluerepo.YearExist(facemodel.accountable_forms_id, facemodel.faceyear))
                        {
                            Helper.MessageBoxError("Face year already exists!");
                            cmbyear.Focus();
                        }
                        else
                        {
                            if (facevaluerepo.Update(facemodel))
                                faceid = 0;
                                fdefault = 0;
                                cmbyear.SelectedIndex = -1;
                                txtamount.Value = 0;
                                LoadList();
                        }
                    }
                    catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
                }
            }
            else
            {
                if (cmbyear.SelectedIndex == -1)
                {
                    errorProvider.SetError(cmbyear, "Please select face value year!");
                    cmbyear.Focus();
                }
                else if (txtamount.Value <= 0)
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
                            faceyear = int.Parse(cmbyear.SelectedItem.ToString()),
                            facevalue = txtamount.Value
                        };
                        var facevaluerepo = Factory.FaceValueRepository();
                        if (facevaluerepo.YearExist(facemodel.accountable_forms_id, facemodel.faceyear))
                        {
                            Helper.MessageBoxError("Face year already exists!");
                            cmbyear.Focus();
                        }
                        else
                        {
                            if (facevaluerepo.Insert(facemodel))
                                faceid = 0;
                                fdefault = 0;
                                cmbyear.SelectedIndex = -1;
                                txtamount.Value = 0;
                                LoadList();
                        }
                    }
                    catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
                }
            }
            
        }
    }
}
