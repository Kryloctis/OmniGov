using ACC.Domain.Models;
using AccountingSystem;
using BudgetSystem.Views.Manage.BudgetAppropriations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetSystem.Views.BudgetAppropriations
{
    public partial class frmBudgetAppropriations : Form
    {
        public frmBudgetAppropriations()
        {
            InitializeComponent();
        }

        internal void LoadRecords() 
        {
            DataTable dtBudgetAppropriations;
            try
            {
                if (txtStripSearch.Text.Length > 3)
                {
                    dtBudgetAppropriations = Factory.BudgetAppropriationsRepository().GetViewRecords();
                }
                else
                {
                    dtBudgetAppropriations = Factory.BudgetAppropriationsRepository().GetViewRecords();
                }

                HelperLoadRecords.BudgetAppropriationsDataGridView(dtBudgetAppropriations, dgBudgetAppropriations);
                lblRecordCount.Text = dtBudgetAppropriations.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void frmBudgetAppropriations_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e) 
        {
            var frmBudgetAppropriationsAdd = new frmBudgetAppropriationsAdd(this);
            frmBudgetAppropriationsAdd.ShowDialog();
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e) 
        {
            var frmBudgetAppropriationEdit = new frmBudgetAppropriationsEdit(this);

            var uc = frmBudgetAppropriationEdit.ucBudgetAppropriations1;
            var budgetAppId = dgBudgetAppropriations.SelectedCells[0].Value;
            var fppId = dgBudgetAppropriations.SelectedCells[1].Value;
            var dgothersFPPId = dgBudgetAppropriations.SelectedCells[4].Value;
            int? othersFPPId;
            var allotmentClassesId = dgBudgetAppropriations.SelectedCells[6].Value;
            var genLedgerAccId = dgBudgetAppropriations.SelectedCells[9].Value;


            if (string.IsNullOrEmpty(dgothersFPPId.ToString()))
                othersFPPId = null;
            else
                othersFPPId = Convert.ToInt32(dgothersFPPId);

            uc.budgetAppropriationId = Convert.ToInt32(budgetAppId);
            uc.fppId = Convert.ToInt32(fppId);
            uc.othersFPPId = othersFPPId;
            uc.allotmentClassesId = Convert.ToInt32(allotmentClassesId);
            uc.generalLedgerAccId = Convert.ToInt32(genLedgerAccId);


            frmBudgetAppropriationEdit.ShowDialog();
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            int selectedRowsCount = dgBudgetAppropriations.SelectedRows.Count;

            var budgetAppropriationsModelList = new List<BudgetAppropriationsModel>();

            try
            {
                if (selectedRowsCount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedRowsCount))
                    {
                        foreach (DataGridViewRow row in dgBudgetAppropriations.SelectedRows)
                        {
                            int budgetAppID = int.Parse(row.Cells[0].Value.ToString());
                            var budgetAppropriationsModel = new BudgetAppropriationsModel()
                            {
                                ID = budgetAppID
                            };

                            budgetAppropriationsModelList.Add(budgetAppropriationsModel);
                        }

                        _ = Factory.BudgetAppropriationsRepository().Delete(budgetAppropriationsModelList);
                        LoadRecords();
                    }
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void dgBudgetAppropriations_SelectionChanged(object sender, EventArgs e)
        {
            byte[] columnIndexTimestamp = { 15, 16 };
            Helper.ShowRecordTimestamp(dgBudgetAppropriations, columnIndexTimestamp, lblCreatedAt, lblUpdatedAt);
            Helper.EnableDisableToolStripButtons(dgBudgetAppropriations, toolStripButtonEdit, toolStripButtonDelete);
        }
    }
}
