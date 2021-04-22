using ACC.Domain.Models;
using AccountingSystem.Views.Manage.BudgetAppropriations;
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
    public partial class frmAllotmentReleaseDetails : Form
    {
        internal int budgetAppropriationID = 0;
        internal int fppID = 0;
        internal int? othersFPPID = null;
        internal int allotmentClassesID = 0;
        internal int generalLedgerAccID = 0;
        private frmBudgetAppropriations _frmBudgetAppropriations;

        public frmAllotmentReleaseDetails(frmBudgetAppropriations frmBudgetAppropriations)
        {
            InitializeComponent();
            _frmBudgetAppropriations = frmBudgetAppropriations;
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            txtSearch.TextChanged += new EventHandler(txtSearch_TextChanged);
        }

        private Dictionary<string, string> BudgetAppropriationInfo()
        {
            var budgetAppropriation = Factory.BudgetAppropriationsRepository().GetViewRecordByIDs(budgetAppropriationID, fppID, othersFPPID, allotmentClassesID, generalLedgerAccID);
            return budgetAppropriation;
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
                             where !String.IsNullOrEmpty(row.Cells["amount"].FormattedValue.ToString())
                             select Convert.ToDecimal(row.Cells["amount"].FormattedValue)).Sum().ToString("N2");
        }

        internal void LoadAppropriationDetails() 
        {
            try
            {
                string fppCode = BudgetAppropriationInfo()["fpp_code"].ToString();
                string fppName = BudgetAppropriationInfo()["fpp_name"].ToString();
                string otherFPPName = string.IsNullOrEmpty(BudgetAppropriationInfo()["others_fpp_name"]) ? "-" : BudgetAppropriationInfo()["others_fpp_name"];
                string accountCode = BudgetAppropriationInfo()["account_code"].ToString();
                string allotmentClassCode = BudgetAppropriationInfo()["allotment_code"].ToString();
                string ledgerName = BudgetAppropriationInfo()["ledger_name"].ToString();
                short year = Convert.ToInt16(BudgetAppropriationInfo()["year"]);
                decimal amount = Convert.ToDecimal(BudgetAppropriationInfo()["appropriation"]);
                decimal appropriationBalance = Convert.ToDecimal(BudgetAppropriationInfo()["appropriation_balance"]);

                lblFPPCode.Text = fppCode;
                lblFPP.Text = fppName;
                lblOtherFPP.Text = otherFPPName;
                lblAccountCode.Text = accountCode;
                lblAllotmentClass.Text = allotmentClassCode;
                lblGenLedgerAcc.Text = ledgerName;
                lblYear.Text = year.ToString();
                lblAmount.Text = amount.ToString("N2");
                lblAppropriationBalance.Text = appropriationBalance.ToString("N2");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }


        private void btnAdd_Click(object sender, EventArgs e) 
        {
            var frmAllotmentReleaseAddForm = new frmAllotmentReleaseAddDetails(this, _frmBudgetAppropriations);
            var uc = frmAllotmentReleaseAddForm.ucAllotmentRelease1;

            DateTime dateEntry = Convert.ToDateTime(BudgetAppropriationInfo()["date_entry"]);

            uc.dateEntry = dateEntry;
            uc.budgetAppropriationID = budgetAppropriationID;
            frmAllotmentReleaseAddForm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e) 
        {
            var frmAllotmentReleaseEditForm = new frmAllotmentReleaseDetailsEdit(this, _frmBudgetAppropriations);
            var uc = frmAllotmentReleaseEditForm.ucAllotmentRelease1;
            DateTime dateEntry = Convert.ToDateTime(BudgetAppropriationInfo()["date_entry"]);

            uc.dateEntry = dateEntry;
            uc.allotmentReleaseID = Convert.ToInt32(dgAllotmentRelease.SelectedCells[0].Value);
            uc.budgetAppropriationID = budgetAppropriationID;
            uc.currentAllotmentReleaseAmount = Convert.ToDecimal(dgAllotmentRelease.SelectedCells[5].Value);
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
                        LoadAppropriationDetails();
                        _frmBudgetAppropriations.LoadBudgetAppropriationRecords();
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
            LoadAppropriationDetails();
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
