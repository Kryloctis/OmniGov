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
        Dictionary<int, string> forprint = new Dictionary<int, string>();
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

        internal void LoadRecords()
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

                if (!Convert.ToBoolean(dgrcd.CurrentRow.Cells[e.ColumnIndex].Value))
                {
                    dgrcd.CurrentRow.Cells[e.ColumnIndex].Value = true;
                    if (!forprint.ContainsKey(Convert.ToInt16(dgrcd.CurrentRow.Cells[0].Value)))
                    {
                        forprint.Add(Convert.ToInt16(dgrcd.CurrentRow.Cells[0].Value), dgrcd.CurrentRow.Cells[1].Value.ToString());
                    }
                }    
                else
                {
                    dgrcd.CurrentRow.Cells[e.ColumnIndex].Value = false;
                    forprint.Remove(Convert.ToInt16(dgrcd.CurrentRow.Cells[0].Value));
                }
                btnPrint.Enabled = forprint.Count > 0 ? true : false;
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
            if(forprint.Count > 0)
            {
                string id = string.Join(",", forprint.Select(x => String.Format("'{0}'",x.Key)).ToArray());
                _ = new frmPCReport(id).ShowDialog();
            }
            else{
                Helper.MessageBoxError("Please select reports to print!");
            }
        }

        private void dgrcd_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach(DataGridViewRow row in dgrcd.Rows)
            {
                
                if (Convert.ToBoolean(row.Cells[5].Value))
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
           
        }
    }
}
