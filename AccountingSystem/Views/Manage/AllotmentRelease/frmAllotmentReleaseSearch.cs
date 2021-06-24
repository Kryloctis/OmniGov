using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AllotmentRelease
{
    public partial class frmAllotmentReleaseSearch : Form
    {
        private frmAllotmentReleaseMain _frmAllotmentReleaseMain;

        public frmAllotmentReleaseSearch(frmAllotmentReleaseMain frmAllotmentReleaseMain)
        {
            InitializeComponent();
            _frmAllotmentReleaseMain = frmAllotmentReleaseMain;
            btnSelect.Enabled = false;
        }


        private void LoadAllotmentRelease() 
        {
            string searchTxt = txtSearch.Text.Trim();
            var dtAllotmentReleaseSearch = Factory.AllotmentReleaseRepository().GetRecordsBySearch(searchTxt);
            dgAllotmentRelease.DataSource = dtAllotmentReleaseSearch;

            dgAllotmentRelease.Columns["aro_no"].HeaderText = "ARO No.";
            dgAllotmentRelease.Columns["purpose"].HeaderText = "Purpose";
            dgAllotmentRelease.Columns["id"].Visible = false;
            dgAllotmentRelease.Columns["date_issued"].Visible = false;
            dgAllotmentRelease.Columns["created_at"].Visible = false;
            dgAllotmentRelease.Columns["updated_at"].Visible = false;   
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadAllotmentRelease();
        }

        private void frmAllotmentReleaseSearch_Load(object sender, EventArgs e)
        {
            Helper.DatagridDefaultStyle(dgAllotmentRelease, true);
        }

        private void ApplySelected() 
        {
            int rowIndex = dgAllotmentRelease.CurrentCell.RowIndex;
            int allotmentReleaseId = Convert.ToInt32(dgAllotmentRelease.Rows[rowIndex].Cells["id"].Value);

            _frmAllotmentReleaseMain.ucAllotmentReleaseMain1.allotmentReleaseId = allotmentReleaseId;
            _frmAllotmentReleaseMain.ucAllotmentReleaseMain1.LoadSelected();
            _frmAllotmentReleaseMain.ucAllotmentReleaseMain1.DisplayTotalAllotmentRelease();
            Close();
        }


        private void btnSelect_Click(object sender, EventArgs e)
        {
            ApplySelected();
        }

        private void dgAllotmentRelease_SelectionChanged(object sender, EventArgs e)
        {
            if (dgAllotmentRelease.SelectedRows.Count == 1)
                btnSelect.Enabled = true;
            else
                btnSelect.Enabled = false;
        }

        private void dgAllotmentRelease_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ApplySelected();    
        }
    }
}
