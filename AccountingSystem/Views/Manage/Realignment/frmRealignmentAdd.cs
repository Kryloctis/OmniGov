using ACC.Domain.Models;
using System;
using System.Windows.Forms;
using AccountingSystem.Views.Manage.BudgetAppropriations;

namespace AccountingSystem.Views.Manage.Realignment
{
    public partial class frmRealignmentAdd : Form
    {
        ucRealignment uc;
        internal string _budgetAppropriationId;
        internal string _budgetAppropriationAmount;
        internal frmRealignment _frmRealignment;
        internal frmBudgetAppropriations _frmBudgetAppropriations;

        public frmRealignmentAdd(frmRealignment frmRealignment, frmBudgetAppropriations frmBudgetAppropriation)
        {
            InitializeComponent();
            uc = ucRealignment1;
            _frmRealignment = frmRealignment;
            _frmBudgetAppropriations = frmBudgetAppropriation;
            uc.budgetId  = Convert.ToInt32(frmRealignment.budgetAppropriationId);
        }

        private void frmRealignmentAdd_Load(object sender, EventArgs e)
        {

            uc.txtAppropriationBalance.Text = Convert.ToDecimal(_budgetAppropriationAmount).ToString("N2");

            decimal appropriation = Convert.ToDecimal(uc.txtAppropriationBalance.Text);

            uc.nudAmount.Maximum = appropriation;
            uc.nudAmount.Value = appropriation;
            uc.ComputeTotalRealignment();

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (SaveData())
            {
                if (SaveRealignmentAccounts())
                {
                    _frmRealignment.LoadBudgetRealignments();
                    _frmBudgetAppropriations.LoadBudgetAppropriationRecords();

                    Helper.MessageBoxSuccess("Budget Realignment has been saved.");
                    uc.ResetForm();
                }
            }
        }


        private bool SaveData()
        {
            try
            {

                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }


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
                    string account = item.Cells["account"].Value.ToString();
                    decimal amount = Convert.ToDecimal(item.Cells["amount"].Value.ToString());


                    var budgetRealignmentModel = new BudgetRealignmentModel()
                    {
                        ToBudgetAppropriationId = int.Parse(budgetAppropriationId),
                        RealignmentId = GetLastInsertedId(),
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
