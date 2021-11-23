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
    public partial class frmRCD2 : Form
    {
        public Dictionary<int, string> rcdgenerate = new Dictionary<int, string>();
        private string rcds = string.Empty;
        public frmRCD2(string id)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgrcd, true);
            rcds = id;
        }

        private void frmRCD_Load(object sender, EventArgs e)
        {
            LoadFunds();
            LoadRecords();
            var uRepository = Factory.UsersRepository();
            dgrcd.Columns[7].Visible = uRepository.GetUserRole(Helper.UserId) == "Liquidating Officer" ? true : false;
        }
        private void LoadFunds()
        {
            try
            {
                var fundrepo = Factory.FundsRepository();
                var dtfunds = fundrepo.GetRecords();
                cmbfunds.DataSource = dtfunds;
                cmbfunds.ValueMember = "id";
                cmbfunds.DisplayMember = "fund_name";
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        public void LoadRecords()
        {
            try
            {
                int approved = cmbstatus.SelectedIndex != -1 && cmbstatus.SelectedItem.Equals("Approved") ? 1 : 0;
                string status = cmbstatus.SelectedIndex != -1 && (cmbstatus.SelectedItem.Equals("Pending") || cmbstatus.SelectedItem.Equals("Cancelled")) ? cmbstatus.SelectedItem.ToString().ToUpper() : string.Empty;
                int fundid = cmbfunds.SelectedValue != null ? int.Parse(cmbfunds.SelectedValue.ToString()):0;

                var colrepo = Factory.CollectorReportRepository();
                var dtrcd = rcds.Length > 0 ? colrepo.GetRecords(rcds) : colrepo.GetRecords(approved, status, fundid, string.Empty);
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
                            int rcdId = int.Parse(row.Cells[0].Value.ToString());
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
                try
                {
                    int id = int.Parse(dgrcd.CurrentRow.Cells[0].Value.ToString());
                    bool isapproved = Convert.ToBoolean(dgrcd.CurrentRow.Cells[6].Value);
                    var gcpRepository = Factory.GeneralCollectionsPaymentsRepository();
                    var uRepository = Factory.UsersRepository();
                    btnGenerate.Visible = uRepository.GetUserRole(Helper.UserId) == "Liquidating Officer" ? true : false;
                    btnGenerate.Enabled = gcpRepository.IdExist(id) ? false : true;

                }
                catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            }
           
            
        }

        private void dgrcd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgrcd.SelectedRows.Count > 0)
            {
                int id = int.Parse(dgrcd.CurrentRow.Cells[0].Value.ToString());
                _ = new frmRCDEdit(this, id).ShowDialog();
            }
                
            
        }

        private void dgrcd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == 7)
            {
                bool isapproved = Convert.ToBoolean(dgrcd.CurrentRow.Cells[6].Value);
                var gcpRepository = Factory.GeneralCollectionsPaymentsRepository();
                bool isgenerated = gcpRepository.IdExist(int.Parse(dgrcd.CurrentRow.Cells[0].Value.ToString()));
                if (isapproved && !isgenerated)
                {
                    if (!Convert.ToBoolean(dgrcd.CurrentRow.Cells[e.ColumnIndex].Value))
                    {
                        dgrcd.CurrentRow.Cells[e.ColumnIndex].Value = true;
                        if (!rcdgenerate.ContainsKey(int.Parse(dgrcd.CurrentRow.Cells[0].Value.ToString())))
                        {
                            rcdgenerate.Add(int.Parse(dgrcd.CurrentRow.Cells[0].Value.ToString()), dgrcd.CurrentRow.Cells[1].Value.ToString());
                        }
                    }
                    else
                    {
                        dgrcd.CurrentRow.Cells[e.ColumnIndex].Value = false;
                        rcdgenerate.Remove(int.Parse(dgrcd.CurrentRow.Cells[0].Value.ToString()));
                    }
                    btnGenerate.Enabled = rcdgenerate.Count > 0 ? true : false;
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            if(dgrcd.SelectedRows.Count > 0)
            {
                bool isapproved = Convert.ToBoolean(dgrcd.CurrentRow.Cells[6].Value);
                try
                {
                    if (Helper.MessageBoxConfirmRCDApproved(isapproved))
                    {
                        //var rcdRepository = Factory.CollectorReportRepository();
                        //var rcdModel = new CollectorReportModel()
                        //{
                        //    Id = int.Parse(dgrcd.CurrentRow.Cells[0].Value.ToString()),
                        //    IsApproved = isapproved ? 0 : 1,
                        //};
                        //if (rcdRepository.Approved(rcdModel))
                        //{
                        //    LoadRecords();
                        //}
                    }
                }
                catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
            }
        }

        private void cmbstatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            rcds = string.Empty;
            LoadRecords();
        }

        private void cmbfunds_SelectionChangeCommitted(object sender, EventArgs e)
        {
            rcds = string.Empty;
            LoadRecords();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (rcdgenerate.Count > 0)
            {
                //string id = string.Join(",", rcdgenerate.Select(x => String.Format("'{0}'",x.Key)).ToArray());
                //_ = new frmPCReport(id).ShowDialog();
                _ = new frmGC(rcdgenerate, this).ShowDialog();
            }
            else
            {
                Helper.MessageBoxError("Please select reports to Generate RCD!");
            }
        }
    }
}
