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
                    FundsId = Convert.ToInt32(uc.cmbxTypeOfFund.SelectedValue),
                    FunctionProgramProjectId = uc.fppId,
                    OthersFPPId = uc.cmbxOthersFPP.SelectedValue == null ? null : Convert.ToInt32(uc.cmbxOthersFPP.SelectedValue),
                    AllotmentClassesId = Convert.ToInt32(uc.cmbxAllotmentClass.SelectedValue),
                    GeneralLedgerAccountsId = Convert.ToInt32(uc.cmbxLedgerAccount.SelectedValue),
                    Year = Convert.ToInt16(uc.nudYear.Value),
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
                int allotmentClassID = Convert.ToInt32(uc.cmbxAllotmentClass.SelectedValue);
                int fundID = Convert.ToInt32(uc.cmbxTypeOfFund.SelectedValue);
                short year = Convert.ToInt16(uc.nudYear.Value);

                _frmBudgetAppropriations.cmbxAllotmentClass.ComboBox.SelectedValue = allotmentClassID;
                _frmBudgetAppropriations.cmbxFundType.ComboBox.SelectedValue = fundID;
                _frmBudgetAppropriations.cmbxYear.ComboBox.SelectedValue = year;

                //Reset User Control Form
                uc.cmbxLedgerAccount.SelectedIndex = -1;
                uc.nudAmount.Value = 0;

                Helper.MessageBoxSuccess("Budget Appropriation has been saved.");
                _frmBudgetAppropriations.LoadBudgetAppropriationRecords();
            }
        }
    }
}
