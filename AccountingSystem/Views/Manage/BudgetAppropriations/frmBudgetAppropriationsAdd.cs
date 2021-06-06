using ACC.Domain.Models;
using AccountingSystem;
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

namespace BudgetSystem.Views.BudgetAppropriations
{
    public partial class frmBudgetAppropriationsAdd : Form
    {
        
        private frmBudgetAppropriations _frmBudgetAppropriations;
        private ucBudgetAppropriations uc;

        public frmBudgetAppropriationsAdd(frmBudgetAppropriations frmBudgetAppropriationsNew)
        {
            InitializeComponent();
            _frmBudgetAppropriations = frmBudgetAppropriationsNew;
            uc = ucBudgetAppropriations1;
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

                // proceed to insert
                var budgetAppropriationsModel = new BudgetAppropriationsModel()
                {
                    FundsId = uc.fundId,
                    FunctionProgramProjectId = uc.fppId,
                    OthersFPPId = uc.cmbxOthersFPP.SelectedValue == null ? null : Convert.ToInt32(uc.cmbxOthersFPP.SelectedValue),
                    AllotmentClassesId = uc.allotmentClassId,
                    GeneralLedgerAccountsId = Convert.ToInt32(uc.cmbxLedgerAccount.SelectedValue),
                    Year = uc.year,
                    DateEntry = uc.dtDateEntry.Value,
                    Amount = uc.nudAmount.Value,
                    Continuing = uc.chckbxContinuing.Checked
                };

                return Factory.BudgetAppropriationsRepository().Insert(budgetAppropriationsModel);
            }
            catch (Exception ex) 
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //If Save data is successful
            if (SaveData()) 
            {
                int allotmentClassID = uc.allotmentClassId;
                int fundID = uc.fundId;

                _frmBudgetAppropriations.cmbxAllotmentClass.SelectedValue = allotmentClassID;
                _frmBudgetAppropriations.cmbxFunds.SelectedValue = fundID;

                //Reset User Control Form
                uc.cmbxLedgerAccount.SelectedIndex = -1;
                uc.nudAmount.Value = 0;

                Helper.MessageBoxSuccess("Budget Appropriation has been saved.");
                _frmBudgetAppropriations.LoadBudgetAppropriationRecords();
            }
        }
    }
}
