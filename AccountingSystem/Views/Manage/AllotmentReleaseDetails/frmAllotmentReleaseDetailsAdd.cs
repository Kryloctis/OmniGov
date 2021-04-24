using ACC.Domain.Models;
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

namespace AccountingSystem.Views.Manage.AllotmentRelease
{
    public partial class frmAllotmentReleaseAddDetails : Form
    {
        private frmAllotmentReleaseDetails _frmAllotmentRelease;
        private frmBudgetAppropriations _frmBudgetAppropriations;
        public frmAllotmentReleaseAddDetails(frmAllotmentReleaseDetails frmAllotmentRelease, frmBudgetAppropriations frmBudgetAppropriations)
        {
            InitializeComponent();
            _frmAllotmentRelease = frmAllotmentRelease;
            _frmBudgetAppropriations = frmBudgetAppropriations;
        }

        private void LoadBudgetAppropriationRecords()
        {
            var uc = ucAllotmentRelease1;
            _frmBudgetAppropriations.LoadBudgetAppropriationRecords();

            foreach (DataGridViewRow row in _frmBudgetAppropriations.dgBudgetAppropriations.Rows)
            {
                if (Convert.ToInt32(row.Cells["budget_appropriations_id"].Value) == uc.budgetAppropriationID)
                {
                    _frmBudgetAppropriations.dgBudgetAppropriations.CurrentCell = _frmBudgetAppropriations.dgBudgetAppropriations.Rows[row.Index].Cells["account_code"];
                }
            }

        }

        private bool SaveData() 
        {
            try
            {
                var uc = ucAllotmentRelease1;

                //Validation
                if (!uc.ValidateChildren() || uc.AllotmentReleaseExist()) 
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                string aroNo = $"{uc.mskTxtSeriesNo.Text}-{uc.mskTxtYear.Text}";

                // proceed to insert
                var allotmentReleaseModel = new AllotmentReleaseModel()
                {
                    BudgetAppropriationsID = uc.budgetAppropriationID,
                    ARONumber = aroNo,
                    Purpose = uc.txtPurpose.Text.Trim(),
                    DateIssued = uc.dtDateIssued.Value,
                    amount = uc.nudAmount.Value,
                };

                return Factory.AllotmentReleaseRepository().Insert(allotmentReleaseModel);

            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData()) 
            {
                var uc = ucAllotmentRelease1;
                uc.ResetForm();
                Helper.MessageBoxSuccess("Allotment Release has been saved.");
                _frmAllotmentRelease.LoadAppropriationDetails();
                _frmAllotmentRelease.LoadAllotmentReleaseRecords();
                LoadBudgetAppropriationRecords();


            }
        }
    }
}
