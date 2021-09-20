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

namespace AccountingSystem.Views.Manage.Realignment
{
    public partial class frmRealignmentAdd : Form
    {
        ucRealignment uc;
        internal string _budgetAppropriationId;
        internal string _budgetAppropriationAmount;

        public frmRealignmentAdd()
        {
            InitializeComponent();
            uc = ucRealignment1;
        }

        private void frmRealignmentAdd_Load(object sender, EventArgs e)
        {
            uc.nudBudgetAppropriation.Value = Convert.ToDecimal(_budgetAppropriationAmount);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                if (SaveRealignmentAccounts())
                {
                    Helper.MessageBoxSuccess("Budget Realignment has been saved.");
                    //uc.ResetForm();
                }
            }
        }

        private bool SaveData()
        {
            try
            {
                //if (!uc.ValidateChildren())
                //{
                //    Helper.MessageBoxError(uc.GetFormErrors());
                //    return false;
                //}

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
                //if (!uc.ValidateChildren())
                //{
                //    Helper.MessageBoxError(uc.GetFormErrors());
                //    return false;
                //}

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
