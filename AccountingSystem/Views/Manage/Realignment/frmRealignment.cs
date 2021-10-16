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

namespace AccountingSystem.Views.Manage.Realignment
{
    public partial class frmRealignment : Form
    {

        internal string budgetAppropriationId;
        internal string budgetAppropriationAccount;
        internal string budgetAppropriationAmount;

        public frmRealignment()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void frmRealignment_Load(object sender, EventArgs e)
        {
            this.Text = $"{this.Text} > {budgetAppropriationAccount.Trim()}";
            LoadBudgetRealignments();
            TotalRealignmentDisplay();
        }

        private void ToggleEditDeleteVisibility(bool visibility)
        {
            btnDelete.Visible = visibility;
            btnEdit.Visible = visibility;
        }

        private void TotalRealignmentDisplay()
        {
            string totalRealignment;

            if (tabControl1.SelectedTab == tabControl1.Controls[0])
            {
                totalRealignment = (from DataGridViewRow row in dgRealignmentFrom.Rows
                        where !String.IsNullOrEmpty(row.Cells["amount"].FormattedValue.ToString())
                        select Convert.ToDecimal(row.Cells["amount"].FormattedValue)).Sum().ToString("N2");

                ToggleEditDeleteVisibility(false);
            }
            else
            {
                totalRealignment = (from DataGridViewRow row in dgRealignmentTo.Rows
                        where !String.IsNullOrEmpty(row.Cells["amount"].FormattedValue.ToString())
                        select Convert.ToDecimal(row.Cells["amount"].FormattedValue)).Sum().ToString("N2");

                ToggleEditDeleteVisibility(true);
            }

            txtTotalRealignmentAppropriation.Text = totalRealignment;
        }

        internal void LoadBudgetRealignments()
        {
            //REALIGNMENT TO DIFFERENT ACCOUNT
            var dtBudgetRealignmentTo = Factory.BudgetRealignmentRepository().GetRealignmentToByAppropriationId(int.Parse(budgetAppropriationId));
            HelperLoadRecords.BudgetRealignmentToDatagridView(dtBudgetRealignmentTo, dgRealignmentTo);

            //REALIGNMENT TO THIS ACCOUNT
            var dtBudgetRealignmentFrom = Factory.BudgetRealignmentRepository().GetRealignmentFromByAppropriationId(int.Parse(budgetAppropriationId));
            HelperLoadRecords.BudgetRealignmentFromDatagridView(dtBudgetRealignmentFrom, dgRealignmentFrom);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frmRealignmentAdd  = new frmRealignmentAdd(this);
            frmRealignmentAdd._budgetAppropriationAmount = budgetAppropriationAmount;
            frmRealignmentAdd._budgetAppropriationId = budgetAppropriationId;
            frmRealignmentAdd.ShowDialog();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TotalRealignmentDisplay();
        }

        private void dgRealignmentFrom_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dgRealignmentFrom, btnEdit, btnDelete);
        }

        private void dgRealignmentTo_SelectionChanged(object sender, EventArgs e)
        {

            Helper.EnableDisableToolStripButtons(dgRealignmentTo, btnEdit, btnDelete);
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

                foreach (DataGridViewRow row in dgRealignmentTo.SelectedRows)
                {
                    if (row.Cells[0].Value != null)
                        selectedRowCount += 1;
                }

                if (selectedRowCount > 0)
                {
                    if (Helper.MessageBoxConfirmDelete(selectedRowCount))
                    {
                        var budgetRealignmentModelList = new List<BudgetRealignmentModel>();

                        foreach (DataGridViewRow row in dgRealignmentTo.SelectedRows)
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
            int rowIndex = dgRealignmentTo.CurrentCell.RowIndex;

            budgetAppropriationAmount = dgRealignmentTo.Rows[rowIndex].Cells["amount"].Value.ToString();

            var frmRealignmentEdit = new frmRealignmentEdit(this)
            {
                _budgetAppropriationAmount = budgetAppropriationAmount,
                _budgetAppropriationId = budgetAppropriationId
            };

            frmRealignmentEdit.ShowDialog();
        }
    }
}
