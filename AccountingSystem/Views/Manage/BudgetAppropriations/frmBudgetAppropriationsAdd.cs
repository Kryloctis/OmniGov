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
        private frmBudgetAppropriations _frmBudgetAppropriationsNew;
        public frmBudgetAppropriationsAdd(frmBudgetAppropriations frmBudgetAppropriationsNew)
        {
            InitializeComponent();
            _frmBudgetAppropriationsNew = frmBudgetAppropriationsNew;
        }

        private void LoadComboboxes()
        {
            var uc = ucBudgetAppropriations1;
            uc.LoadFPPRecords();
            uc.LoadOtherFPPRecords();
            uc.LoadAllotmentClassRecords();
            uc.LoadGeneralLedgerAccounts();
            uc.LoadTypeOfFund();
            uc.ResetForm();
            uc.nudYear.Value = DateTime.Now.Year;
        }

        private bool SaveData() 
        {
            try
            {
                var uc = ucBudgetAppropriations1;
                int? othersFPPId;

                if (uc.BudgetAppropriationsValidation() || !uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }


                if (uc.cmbxOthersFPP.SelectedValue == null)
                    othersFPPId = null;
                else
                    othersFPPId = Convert.ToInt32(uc.cmbxOthersFPP.SelectedValue);

                // proceed to insert
                var budgetAppropriationsModel = new BudgetAppropriationsModel()
                {
                    FundsId = Convert.ToInt32(uc.cmbxTypeOfFund.SelectedValue),
                    FunctionProgramProjectId = Convert.ToInt32(uc.cmbxFPP.SelectedValue),
                    OthersFPPId = othersFPPId,
                    AllotmentClassesId = Convert.ToInt32(uc.cmbxAllotmentClass.SelectedValue),
                    GeneralLedgerAccountsId = Convert.ToInt32(uc.cmbxLedgerAccount.SelectedValue),
                    Year = Convert.ToInt16(uc.nudYear.Value),
                    DateEntry = uc.dtDateEntry.Value,
                    amount = uc.nudAmount.Value
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
            var uc = ucBudgetAppropriations1;

            if (SaveData()) 
            {
                uc.ResetForm();
                _frmBudgetAppropriationsNew.LoadRecords();
                Helper.MessageBoxSuccess("Budget Appropriation has been saved."); 
            }
        }

        private void frmBudgetAppropriationsAdd_Load(object sender, EventArgs e)
        {
            LoadComboboxes();
        }
    }
}
