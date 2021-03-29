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
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
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

                HelperLoadRecords.AllotmentReleaseDgV(GetRecordsByBudgetAppropriationID, dgAllotmentRelease, budgetAppropriationID);
            }
            else 
            {
                DataTable GetRecordsByBudgetAppropriationID = Factory.AllotmentReleaseRepository().GetRecordsByBudgetAppropriationID(budgetAppropriationID);

                HelperLoadRecords.AllotmentReleaseDgV(GetRecordsByBudgetAppropriationID, dgAllotmentRelease, budgetAppropriationID);
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
            frmAllotmentReleaseAddForm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e) 
        {
            var frmAllotmentReleaseEditForm = new frmAllotmentReleaseEdit(this);
            var uc = frmAllotmentReleaseEditForm.ucAllotmentRelease1;

            uc.allotmentReleaseID = Convert.ToInt32(dgAllotmentRelease.SelectedCells[0].Value);
            frmAllotmentReleaseEditForm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e) 
        {
            int selectedRowsCount = dgAllotmentRelease.SelectedRows.Count;

            var allotmentModelList = new List<AllotmentReleaseModel>();

            try
            {
                if (selectedRowsCount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                    {
                        foreach (DataGridViewRow row in dgAllotmentRelease.SelectedRows)
                        {
                            int allotmentReleaseID = int.Parse(row.Cells[0].Value.ToString());
                            var allotmentReleaseModel = new AllotmentReleaseModel()
                            {
                                ID = allotmentReleaseID
                            };

                            allotmentModelList.Add(allotmentReleaseModel);
                        }

                        _ = Factory.AllotmentReleaseRepository().Delete(allotmentModelList);
                        LoadAllotmentReleaseRecords();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
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
            Helper.EnableDisableToolStripButtons(dgAllotmentRelease, btnEdit, btnDelete);
        }
    }
}
