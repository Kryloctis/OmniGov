using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACC.Domain.Models;
using AccountingSystem.Views.Manage.BudgetAppropriations;

namespace AccountingSystem.Views.Manage.Realignment
{
    public partial class frmRealignment : Form
    {

        internal string budgetAppropriationId;
        internal string budgetAppropriationAccount;
        internal string budgetAppropriationAmount;
        internal string budgetRealignmentId;
        internal frmBudgetAppropriations _frmBudgetAppropriation;

        public frmRealignment()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void frmRealignment_Load(object sender, EventArgs e)
        {
            LoadBudgetRealignments();
        }

        private void TotalRealignmentDisplay()
        {
            string totalRealignment;

            totalRealignment = (from DataGridViewRow row in dgRealignment.Rows
                                where !String.IsNullOrEmpty(row.Cells["total_amount"].FormattedValue.ToString())
                                select Convert.ToDecimal(row.Cells["total_amount"].FormattedValue)).Sum().ToString("N2");

            txtTotalRealignmentAppropriation.Text = totalRealignment;
        }

        internal void LoadBudgetRealignments()
        {
            var dtBudgetRealignment = Factory.BudgetRealignmentRepository().GetBudgetRealignmentByAppropriationId(int.Parse(budgetAppropriationId));
            HelperLoadRecords.BudgetRealignmentDatagridView(dtBudgetRealignment, dgRealignment);

            TotalRealignmentDisplay();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (BudgetHasObligations()) {
                Helper.MessageBoxError("Failed to add realignment. Budget obligation exist.");
                return;
            }

            var frmRealignmentAdd = new frmRealignmentAdd(this, _frmBudgetAppropriation);
            frmRealignmentAdd._budgetAppropriationAmount = budgetAppropriationAmount;
            frmRealignmentAdd._budgetAppropriationId = budgetAppropriationId;
            frmRealignmentAdd.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteRealignment();
        }

        private  bool BudgetHasObligations()
        {
            var hasObligation = Factory.ObligationAccountRepository().CheckObligationRequestExistByBudgetAppropriationId(Convert.ToInt32(budgetAppropriationId));

            return hasObligation;
        }

        private void DeleteRealignment()
        {
            try
            {
                if (BudgetHasObligations()) {
                    Helper.MessageBoxError($"Cannot Delete Budget Realignment.");
                    return;
                }

                int selectedRowCount = 0;

                foreach (DataGridViewRow row in dgRealignment.SelectedRows)
                {
                    if (row.Cells[0].Value != null)
                        selectedRowCount += 1;
                }

                if (selectedRowCount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedRowCount))
                    {
                        var budgetRealignmentModelList = new List<BudgetRealignmentModel>();

                        foreach (DataGridViewRow row in dgRealignment.SelectedRows)
                        {
                            if (row.Cells[0].Value != null)
                            {
                                ushort budgetRealignmentId = (ushort)Convert.ToInt16(row.Cells[0].Value);

                                var budgetRealignmentModel = new BudgetRealignmentModel()
                                {
                                    ToBudgetAppropriationId = budgetRealignmentId
                                };

                                budgetRealignmentModelList.Add(budgetRealignmentModel);
                            }
                        }

                        _ = Factory.BudgetRealignmentRepository().Delete(budgetRealignmentModelList);
                        LoadBudgetRealignments();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            int rowIndex = dgRealignment.CurrentCell.RowIndex;
            budgetRealignmentId = dgRealignment.Rows[rowIndex].Cells["id"].Value.ToString();


            var frmRealignmentEdit = new frmRealignmentEdit(this)
            {
                _budgetAppropriationAmount = budgetAppropriationAmount,
                _budgetAppropriationId = budgetAppropriationId
            };

            frmRealignmentEdit.ShowDialog();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            int rowIndex = dgRealignment.CurrentCell.RowIndex;
            budgetRealignmentId = dgRealignment.Rows[rowIndex].Cells["id"].Value.ToString();


            var frmRealignmentEdit = new frmRealignmentEdit(this)
            {
                _budgetAppropriationAmount = budgetAppropriationAmount,
                _budgetAppropriationId = budgetAppropriationId
            };

            frmRealignmentEdit.ShowDialog();
        }

        private void dgRealignment_SelectionChanged(object sender, EventArgs e)
        { 
            Helper.EnableDisableToolStripButtons(dgRealignment, btnEdit, btnDelete);
        }


    }
}
