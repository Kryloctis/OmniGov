using ACC.Domain.Models;
using AccountingSystem.Views.Manage.BudgetAppropriations;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Realignment
{
    public partial class frmRealignmentAdd : Form
    {
        ucRealignment uc;
        internal string _budgetAppropriationId;
        internal string _budgetAppropriationAmount;
        internal frmRealignment _frmRealignment;

        public frmRealignmentAdd(frmRealignment frmRealignment)
        {
            InitializeComponent();
            uc = ucRealignment1;
            _frmRealignment = frmRealignment;
            uc.txtBudgetId.Text  = frmRealignment.budgetAppropriationId;
        }

        private void frmRealignmentAdd_Load(object sender, EventArgs e)
        {
            uc.nudAppropriationBalance.Value = Convert.ToDecimal(_budgetAppropriationAmount);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                if (SaveRealignmentAccounts())
                {
                    _frmRealignment.LoadBudgetRealignments();
                    Helper.MessageBoxSuccess("Budget Realignment has been saved.");
                    uc.ResetForm();
                }
            }
        }

       

        internal bool FormValidations()
        {
            // validate form
            if (uc.dgBudgetRealignment.Rows.Count == 0)
            {
                Helper.MessageBoxError("Please add account/s for realignment");
                return false;
            }

            return true;
        }

        private bool SaveData()
        {
            try
            {
                if (!FormValidations())
                    return false;

                var budgetRealignmentModel = new BudgetRealignmentModel()
                { 
                    BudgetAppropriationId = int.Parse(_budgetAppropriationId),
                    DateEntry = uc.dtDateIssued.Value,
                    Remarks = uc.txtRemarks.Text.Trim(),
                    Amount = uc.nudAmount.Value
                };

                return Factory.BudgetRealignmentRepository().Insert(budgetRealignmentModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool SaveRealignmentAccounts()
        {
            try
            {
                foreach (DataGridViewRow item in uc.dgBudgetRealignment.Rows)
                {
                    string budgetAppropriationId = item.Cells["budgetAppropriationId"].Value.ToString();
                    string account = item.Cells["realignmentAccount"].Value.ToString();
                    decimal amount = Convert.ToDecimal(item.Cells["realignmentAmount"].Value.ToString());

                    var budgetRealignmentModel = new BudgetRealignmentModel()
                    {
                        BudgetAppropriationId = int.Parse(budgetAppropriationId),
                        FromBudgetAppropriationId = GetLastInsertedId(),
                        Amount = amount
                    };

                    Factory.BudgetRealignmentRepository().InsertRealignment(budgetRealignmentModel);
                }

                return true;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private ushort GetLastInsertedId()
        {
            return Factory.BudgetRealignmentRepository().GetLastInsertedID();
        }
    }
}
