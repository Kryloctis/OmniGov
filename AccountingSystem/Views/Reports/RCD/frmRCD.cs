using ACC.Domain.Models;
using AccountingSystem.Views.Reports.PaymentCollection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RCD
{
    public partial class frmRCD : Form
    {
        public Dictionary<int, string> rcdgenerate = new Dictionary<int, string>();
        public frmRCD()
        {
            InitializeComponent();
            WindowState = FormWindowState.Normal;
            Helper.LoadFormIcon(this);
            Helper.DatagridDefaultStyle(dgrcd);
        }

        private void frmRCD_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        public void LoadRecords()
        {
            try
            {
                var rcdRepository = Factory.CollectorReportRepository();
                var dtrcd = rcdRepository.GetRecords();
                HelperLoadRecords.CollectorReportDatagridView(dtrcd, dgrcd);

                lblRecordCount.Text = dgrcd.Rows.Count.ToString();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmRCDAdd(this).ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedrowscount = dgrcd.SelectedRows.Count;
            try
            {
                if (selectedrowscount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedrowscount))
                    {
                        var rcdModelList = new List<CollectorReportModel>();
                        foreach (DataGridViewRow row in dgrcd.SelectedRows)
                        {
                            int rcdId = Convert.ToInt16(row.Cells[0].Value.ToString());
                            rcdModelList.Add(new CollectorReportModel() { Id = rcdId });
                        }

                        var rcdRepository = Factory.CollectorReportRepository();
                        _ = rcdRepository.Delete(rcdModelList);
                        LoadRecords();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgrcd.Rows.Count > 0 && dgrcd.SelectedRows.Count > 0)
            {
                int Id = int.Parse(dgrcd.SelectedCells[0].Value.ToString());
                _ = new frmRCDEdit(this, Id).ShowDialog();
            }
        }
        private void dgrcd_SelectionChanged(object sender, EventArgs e)
        {   
            if(dgrcd.SelectedRows.Count > 0)
            {
                Helper.EnableDisableToolStripButtons(dgrcd, btnEdit, btnDelete);
                try
                {
                    int id = int.Parse(dgrcd.CurrentRow.Cells[0].Value.ToString());
                    var gcpRepository = Factory.GeneralCollectionsPaymentsRepository();
                    btnDelete.Enabled = gcpRepository.IdExist(id) ? false : true;
                }
                catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            }
           
            
        }

        private void dgrcd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.PerformClick();
        }

        private void dgrcd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == 6)
            {
                bool isapproved = Convert.ToBoolean(dgrcd.CurrentRow.Cells[5].Value);
                var gcpRepository = Factory.GeneralCollectionsPaymentsRepository();
                bool isgenerated = gcpRepository.IdExist(int.Parse(dgrcd.CurrentRow.Cells[0].Value.ToString()));
                if (isapproved && !isgenerated)
                {
                    if (!Convert.ToBoolean(dgrcd.CurrentRow.Cells[e.ColumnIndex].Value))
                    {
                        dgrcd.CurrentRow.Cells[e.ColumnIndex].Value = true;
                        if (!rcdgenerate.ContainsKey(Convert.ToInt16(dgrcd.CurrentRow.Cells[0].Value)))
                        {
                            rcdgenerate.Add(Convert.ToInt16(dgrcd.CurrentRow.Cells[0].Value), dgrcd.CurrentRow.Cells[1].Value.ToString());
                        }
                    }
                    else
                    {
                        dgrcd.CurrentRow.Cells[e.ColumnIndex].Value = false;
                        rcdgenerate.Remove(Convert.ToInt16(dgrcd.CurrentRow.Cells[0].Value));
                    }
                    btnRCD.Enabled = rcdgenerate.Count > 0 ? true : false;
                }
                else
                {                    
                   dgrcd.CurrentRow.Cells[e.ColumnIndex].Value = false;
                }
              
            }
            
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (txtsearch.Text.Length > 0)
            {
                try
                {
                    string searchkey = Convert.ToString(txtsearch.Text.Trim());
                    var dtrcd = Factory.CollectorReportRepository().GetRecordsBySearch(searchkey);
                    HelperLoadRecords.CollectorReportDatagridView(dtrcd, dgrcd);

                    lblRecordCount.Text = dgrcd.Rows.Count.ToString();
                }
                catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            }
            else
            {
                LoadRecords();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(rcdgenerate.Count > 0)
            {
                //string id = string.Join(",", rcdgenerate.Select(x => String.Format("'{0}'",x.Key)).ToArray());
                //_ = new frmPCReport(id).ShowDialog();
                _ = new frmGC(rcdgenerate, this).ShowDialog();               
                
            }
            else{
                Helper.MessageBoxError("Please select reports to Generate RCD!");
            }
        }
    }
}
