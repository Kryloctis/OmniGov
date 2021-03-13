using ACC.Domain.Models;
using AccountingSystem;
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
        public frmBudgetAppropriationsAdd(frmBudgetAppropriations frmBudgetAppropriations)
        {
            InitializeComponent();
            _frmBudgetAppropriations = frmBudgetAppropriations;
        }

        private void LoadComboboxes()
        {
            var uc = ucBudgetAppropriations1;
            uc.LoadFPPRecords();
            uc.LoadOtherFPPRecords();
            uc.LoadAllotmentClassRecords();
            uc.LoadGeneralLedgerAccounts();
            uc.ResetForm();
        }

        private bool SaveData() 
        {
            try
            {
                var uc = ucBudgetAppropriations1;
                int? othersFPPId;

                if (!uc.ValidateChildren())
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
                    FunctionProgramProjectId = Convert.ToInt32(uc.cmbxFPP.SelectedValue),
                    OthersFPPId = othersFPPId,
                    AllotmentClassesId = Convert.ToInt32(uc.cmbxAllotmentClass.SelectedValue),
                    GeneralLedgerAccountsId = Convert.ToInt32(uc.cmbxLedgerAccount.SelectedValue),
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
                _frmBudgetAppropriations.LoadRecords();
                Helper.MessageBoxSuccess("Budget Appropriation has been saved."); 
            }
        }

        private void frmBudgetAppropriationsAdd_Load(object sender, EventArgs e)
        {
            LoadComboboxes();
        }
    }
}
