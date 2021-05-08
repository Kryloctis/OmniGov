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
        internal int budgetAppropriationId;
        internal int fppId;
        internal int? othersFPPId;
        internal int allotmentClassId;
        internal int generalLedgerAccountsId;
        private frmBudgetAppropriations _frmBudgetAppropriations;

        public frmAllotmentReleaseDetails(frmBudgetAppropriations frmBudgetAppropriations)
        {
            InitializeComponent();
            _frmBudgetAppropriations = frmBudgetAppropriations;
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            txtSearch.TextChanged += new EventHandler(txtSearch_TextChanged);
            Helper.LoadFormIcon(this);
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
                DataTable GetRecordsByBudgetAppropriationID = Factory.AllotmentReleaseRepository().GetRecordsByBudgetAppropriationID(budgetAppropriationId, allotmentReleaseNum);

                HelperLoadRecords.AllotmentReleaseDgV(GetRecordsByBudgetAppropriationID, dgAllotmentRelease, budgetAppropriationId);
            }
            else 
            {
                DataTable GetRecordsByBudgetAppropriationID = Factory.AllotmentReleaseRepository().GetRecordsByBudgetAppropriationID(budgetAppropriationId);

                HelperLoadRecords.AllotmentReleaseDgV(GetRecordsByBudgetAppropriationID, dgAllotmentRelease, budgetAppropriationId);
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
                int budgetAppropriationId = Convert.ToInt32(BudgetAppropriationInfo()["id"]);
                int fundId = Convert.ToInt32(BudgetAppropriationInfo()["funds_id"]);
                string fppCode = BudgetAppropriationInfo()["fpp_code"].ToString();
                string fppName = BudgetAppropriationInfo()["fpp_name"].ToString();
                string otherFPPName = string.IsNullOrEmpty(BudgetAppropriationInfo()["others_fpp_name"]) ? "-" : BudgetAppropriationInfo()["others_fpp_name"];
                int accountId = Convert.ToInt32(BudgetAppropriationInfo()["general_ledger_accounts_id"]);
                string accountCode = BudgetAppropriationInfo()["account_code"].ToString();
                int allotmentClassId = Convert.ToInt32(BudgetAppropriationInfo()["allotment_class_id"]);
                string allotmentClassCode = BudgetAppropriationInfo()["allotment_class_code"].ToString();
                string ledgerName = BudgetAppropriationInfo()["allotment_class_name"].ToString();
                DateTime dateEntry = Convert.ToDateTime(BudgetAppropriationInfo()["date_entry"]);
                short year = Convert.ToInt16(BudgetAppropriationInfo()["year"]);
                decimal appropriation = Convert.ToDecimal(BudgetAppropriationInfo()["amount"]);
                decimal totalSupplementalAppropriationAmount = Factory.SupplementalAppropriationsRepository().GetTotalSupplementalAmountById(budgetAppropriationId);

                decimal totalAllotmentRelease = Factory.AllotmentReleaseRepository().GetViewTotalAllotmentReleaseAmountByYear(budgetAppropriationId, fundId, fppId, othersFPPId, allotmentClassId, accountId);

                decimal totalAppropriationAmount = appropriation + totalSupplementalAppropriationAmount;
                decimal totalAppropriationBalance = totalAppropriationAmount - totalAllotmentRelease;

                lblFPPCode.Text = fppCode;
                lblFPP.Text = fppName;
                lblOtherFPP.Text = otherFPPName;
                lblAccountCode.Text = accountCode;
                lblAllotmentClass.Text = allotmentClassCode;
                lblGenLedgerAcc.Text = ledgerName;
                lblDateEntry.Text = dateEntry.ToString("MMM-dd-yyyy");
                lblYear.Text = year.ToString();
                lblAmount.Text = totalAppropriationAmount.ToString("N2");
                lblAppropriationBalance.Text = totalAppropriationBalance.ToString("N2");
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private Dictionary<string, string> BudgetAppropriationInfo()
        {
            var budgetAppropriation = Factory.BudgetAppropriationsRepository().GetViewRecordByIDs(budgetAppropriationId, fppId, othersFPPId, allotmentClassId, generalLedgerAccountsId);
            return budgetAppropriation;
        }

        private void btnAdd_Click(object sender, EventArgs e) 
        {
            var frmAllotmentReleaseAddForm = new frmAllotmentReleaseAddDetails(this, _frmBudgetAppropriations);
            var uc = frmAllotmentReleaseAddForm.ucAllotmentRelease1;

            DateTime dateEntry = Convert.ToDateTime(BudgetAppropriationInfo()["date_entry"]);
            short year = Convert.ToInt16(BudgetAppropriationInfo()["year"]);
          
            uc.budgetAppropriationID = budgetAppropriationId;
            uc.dateEntry = dateEntry;
            uc.year = year;

            frmAllotmentReleaseAddForm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e) 
        {
            var frmAllotmentReleaseEditForm = new frmAllotmentReleaseDetailsEdit(this, _frmBudgetAppropriations);
            var uc = frmAllotmentReleaseEditForm.ucAllotmentRelease1;
            DateTime dateEntry = Convert.ToDateTime(BudgetAppropriationInfo()["date_entry"]);
            short year = Convert.ToInt16(BudgetAppropriationInfo()["year"]);

            uc.year = year;
            uc.dateEntry = dateEntry;
            uc.allotmentReleaseID = Convert.ToInt32(dgAllotmentRelease.SelectedCells[0].Value);
            uc.budgetAppropriationID = budgetAppropriationId;
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
