using ACC.Domain.Models;
using AccountingSystem;
using BudgetSystem.Views.BudgetAppropriations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetSystem.Views.Manage.BudgetAppropriations
{
    public partial class frmBudgetAppropriationsEdit : Form
    {
        private frmBudgetAppropriations _frmBudgetAppropriations;
        public frmBudgetAppropriationsEdit(frmBudgetAppropriations frmBudgetAppropriations)
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

        private void LoadSelected() 
        {
            try
            {
                var uc = ucBudgetAppropriations1;
                var selectedBudgetAppropriation = Factory.BudgetAppropriationsRepository().GetRecordByIDs(uc.budgetAppropriationId, uc.fppId, uc.othersFPPId, uc.allotmentClassesId, uc.generalLedgerAccId);

                // Set Values
                uc.cmbxFPP.SelectedValue = selectedBudgetAppropriation["function_program_project_id"];
                //if others fpp was null
                if (string.IsNullOrEmpty(selectedBudgetAppropriation["others_fpp_id"])) 
                    uc.cmbxOthersFPP.SelectedIndex = -1;
                else
                    uc.cmbxOthersFPP.SelectedValue = Convert.ToInt32(selectedBudgetAppropriation["others_fpp_id"]);
                uc.cmbxAllotmentClass.SelectedValue = selectedBudgetAppropriation["allotment_classes_id"];
                uc.cmbxLedgerAccount.SelectedValue = selectedBudgetAppropriation["general_ledger_accounts_id"];
                uc.nudAmount.Value = Convert.ToDecimal(selectedBudgetAppropriation["amount"]);

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private bool SaveData() 
        {
            try
            {
                var uc = ucBudgetAppropriations1;
                int? othersFPPId;

                //Check Validation
                if (!uc.ValidateChildren()) 
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                if (uc.cmbxOthersFPP.SelectedValue == null)
                    othersFPPId = null;
                else
                    othersFPPId = Convert.ToInt32(uc.cmbxOthersFPP.SelectedValue);


                var budgetAppModel = new BudgetAppropriationsModel()
                {
                    ID = uc.budgetAppropriationId,
                    FunctionProgramProjectId = Convert.ToInt32(uc.cmbxFPP.SelectedValue),
                    OthersFPPId = othersFPPId,
                    AllotmentClassesId = Convert.ToInt32(uc.cmbxAllotmentClass.SelectedValue),
                    GeneralLedgerAccountsId = Convert.ToInt32(uc.cmbxLedgerAccount.SelectedValue),
                    amount = uc.nudAmount.Value
                };

                return Factory.BudgetAppropriationsRepository().Update(budgetAppModel);
            }
            catch (Exception ex) 
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void frmBudgetAppropriationsEdit_Load(object sender, EventArgs e)
        {
            var uc = ucBudgetAppropriations1;
            LoadComboboxes();
            LoadSelected();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData()) 
            {
                var uc = ucBudgetAppropriations1;

                uc.ResetForm();
                Close(); 
                Helper.MessageBoxSuccess("Budget Appropriation update has been saved.");
                _frmBudgetAppropriations.LoadRecords();
            }
        }
    }
}
