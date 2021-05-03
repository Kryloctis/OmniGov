using ACC.Domain.Models;
using AccountingSystem;
using AccountingSystem.Views.Manage.BudgetAppropriations;
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
        public frmBudgetAppropriationsEdit(frmBudgetAppropriations frmBudgetAppropriationsNew)
        {
            InitializeComponent();
            _frmBudgetAppropriations = frmBudgetAppropriationsNew;
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
        }

        private void LoadSelected() 
        {
            try
            {
                var uc = ucBudgetAppropriations1;
                var selectedBudgetAppropriation = Factory.BudgetAppropriationsRepository().GetRecordByIDs(uc.budgetAppropriationId, uc.fppId, uc.othersFPPId, uc.allotmentClassesId, uc.generalLedgerAccId);

                // Set Values
                uc.cmbxTypeOfFund.SelectedValue = selectedBudgetAppropriation["funds_id"];
                uc.cmbxFPP.SelectedValue = selectedBudgetAppropriation["function_program_project_id"];
                //if others fpp was null
                if (string.IsNullOrEmpty(selectedBudgetAppropriation["others_fpp_id"])) 
                    uc.cmbxOthersFPP.SelectedIndex = -1;
                else
                    uc.cmbxOthersFPP.SelectedValue = Convert.ToInt32(selectedBudgetAppropriation["others_fpp_id"]);

                uc.cmbxAllotmentClass.SelectedValue = selectedBudgetAppropriation["allotment_classes_id"];
                uc.cmbxLedgerAccount.SelectedValue = selectedBudgetAppropriation["general_ledger_accounts_id"];
                uc.dtDateEntry.Value = Convert.ToDateTime(selectedBudgetAppropriation["date_entry"]);
                uc.nudYear.Value = Convert.ToDecimal(selectedBudgetAppropriation["year"]);
                uc.nudAmount.Value = Convert.ToDecimal(selectedBudgetAppropriation["amount"]);
                uc.chckbxContinuing.Checked = Convert.ToUInt16(selectedBudgetAppropriation["continuing"]) == 0 ? false : true;
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
                if (!uc.ValidateChildren() || !string.IsNullOrEmpty(uc.epBudgetAppropriation.GetError(uc.cmbxTypeOfFund))) 
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
                    FundsId = Convert.ToInt32(uc.cmbxTypeOfFund.SelectedValue),
                    FunctionProgramProjectId = Convert.ToInt32(uc.cmbxFPP.SelectedValue),
                    OthersFPPId = othersFPPId,
                    AllotmentClassesId = Convert.ToInt32(uc.cmbxAllotmentClass.SelectedValue),
                    GeneralLedgerAccountsId = Convert.ToInt32(uc.cmbxLedgerAccount.SelectedValue),
                    DateEntry = uc.dtDateEntry.Value,
                    Year = Convert.ToInt16(uc.nudYear.Value),
                    amount = uc.nudAmount.Value,
                    continuing = uc.chckbxContinuing.Checked
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

                //Initialze data references
                int fppID = Convert.ToInt32(uc.cmbxFPP.SelectedValue);
                int allotmentClassID = Convert.ToInt32(uc.cmbxAllotmentClass.SelectedValue);
                int fundID = Convert.ToInt32(uc.cmbxTypeOfFund.SelectedValue);
                short year = Convert.ToInt16(uc.nudYear.Value);

                _frmBudgetAppropriations.RecordLocator(fppID, allotmentClassID, fundID, year);
                _frmBudgetAppropriations.cmbxAllotmentClass.ComboBox.SelectedValue = allotmentClassID;
                _frmBudgetAppropriations.cmbxFundType.ComboBox.SelectedValue = fundID;
                _frmBudgetAppropriations.cmbxYear.ComboBox.SelectedValue = year;

                Helper.MessageBoxSuccess("Budget Appropriation update has been saved.");
                Close();

                //Reset User Control Form
                uc.ResetForm();
            }
        }
    }
}
