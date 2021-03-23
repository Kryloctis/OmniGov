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
    public partial class frmAllotmentRelease : Form
    {
        internal int budgetAppropriationID;
        internal int fppID;
        internal int? othersFPPID;
        internal int allotmentClassesID;
        internal int generalLedgerAccID;


        public frmAllotmentRelease()
        {
            InitializeComponent();
            btnAdd.Click += new EventHandler(btnAdd_Click);
            txtSearch.TextChanged += new EventHandler(txtSearch_TextChanged);
        }

        private void LocalShowRecordStatus(DataGridView dataGridView, byte[] index, ToolStripStatusLabel  lblDateIssued, ToolStripStatusLabel lblCreatedAt, ToolStripStatusLabel lblUpdatedAt)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                lblDateIssued.Text = dataGridView.SelectedCells[index[0]].Value.ToString();
                lblCreatedAt.Text = dataGridView.SelectedCells[index[1]].Value.ToString();
                lblUpdatedAt.Text = dataGridView.SelectedCells[index[2]].Value.ToString();
            }
            else
            {
                lblDateIssued.Text = string.Empty;
                lblCreatedAt.Text = string.Empty;
                lblUpdatedAt.Text = string.Empty;
            }
        }

        internal void LoadAllotmentReleaseRecords() 
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                var allotmentReleaseNum = txtSearch.Text.Trim();
                DataTable GetRecordsByBudgetAppropriationID = Factory.AllotmentReleaseRepository().GetRecordsByBudgetAppropriationID(budgetAppropriationID, allotmentReleaseNum);

                HelperLoadRecords.dgAllotmentRelease(GetRecordsByBudgetAppropriationID, dgAllotmentRelease, budgetAppropriationID);
            }
            else 
            {
                DataTable GetRecordsByBudgetAppropriationID = Factory.AllotmentReleaseRepository().GetRecordsByBudgetAppropriationID(budgetAppropriationID);

                HelperLoadRecords.dgAllotmentRelease(GetRecordsByBudgetAppropriationID, dgAllotmentRelease, budgetAppropriationID);
            }
         
            lblRecordCount.Text = dgAllotmentRelease.Rows.Count.ToString();

            //Show Total Value 
            txtTotalAllotmentRelease.Text = (from DataGridViewRow row in dgAllotmentRelease.Rows
                             where !String.IsNullOrEmpty(row.Cells[5].FormattedValue.ToString())
                             select Convert.ToDecimal(row.Cells[5].FormattedValue)).Sum().ToString("N2");
        }

        private void btnAdd_Click(object sender, EventArgs e) 
        {
            var frmAllotmentReleaseAddForm = new frmAllotmentReleaseAdd(this);

            var uc = frmAllotmentReleaseAddForm.ucAllotmentRelease1;

            uc.budgetAppropriationID = budgetAppropriationID;
            uc.fppID = fppID;
            uc.othersFPPID = othersFPPID;
            uc.allotmentClassesID = allotmentClassesID;
            uc.generalLedgerAccID = generalLedgerAccID;

            frmAllotmentReleaseAddForm.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) 
        {
            LoadAllotmentReleaseRecords();
        } 

        private void frmAllotmentRelease_Load(object sender, EventArgs e)
        {
            HelperLoadRecords.LoadBudgetAppropriationDetailsLabels(
              budgetAppropriationID,
              fppID, othersFPPID,
              allotmentClassesID,
              generalLedgerAccID,
              lblFPPCode,
              lblFPP,
              lblOtherFPP,
              lblAccountCode,
              lblAllotmentClass,
              lblGenLedgerAcc,
              lblYear,
              lblAmount);

            LoadAllotmentReleaseRecords();
        }

        private void dgAllotmentRelease_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 4, 6, 7 };
            LocalShowRecordStatus(dgAllotmentRelease, columnIndexTimestamp, lblDateIssued ,lblCreatedAt, lblUpdatedAt);
        }
    }
}
