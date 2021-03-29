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

namespace AccountingSystem.Views.Manage.AllotmentRelease
{
    public partial class frmAllotmentReleaseEdit : Form
    {
        private frmAllotmentRelease _frmAllotmentRelease;
        public frmAllotmentReleaseEdit(frmAllotmentRelease frmAllotmentRelease)
        {
            InitializeComponent();
            _frmAllotmentRelease = frmAllotmentRelease;
        }

        private void LoadSelectedRecord() 
        {
            try
            {
                var uc = ucAllotmentRelease1;
                var selectedAllotmentRelease = Factory.AllotmentReleaseRepository().GetRecordByID(uc.allotmentReleaseID);

                // Set Values
                uc.txtAllotmentReleaseNo.Text = selectedAllotmentRelease["aro_no"];
                uc.txtPurpose.Text = selectedAllotmentRelease["purpose"];
                uc.dtDateIssued.Value = Convert.ToDateTime(selectedAllotmentRelease["date_issued"]);
                uc.nudAmount.Value = Convert.ToDecimal(selectedAllotmentRelease["amount"]);

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
                var uc = ucAllotmentRelease1;

                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }

                // proceed to insert
                var allotmentReleaseModel = new AllotmentReleaseModel()
                {
                    ID = uc.allotmentReleaseID,
                    BudgetAppropriationsID = uc.budgetAppropriationID,
                    ARONumber = uc.txtAllotmentReleaseNo.Text.Trim(),
                    Purpose = uc.txtPurpose.Text.Trim(),
                    DateIssued = uc.dtDateIssued.Value,
                    amount = uc.nudAmount.Value,
                };


                return Factory.AllotmentReleaseRepository().Update(allotmentReleaseModel);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void frmAllotmentReleaseEdit_Load(object sender, EventArgs e)
        {
            LoadSelectedRecord();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData()) 
            {
                var uc = ucAllotmentRelease1;
                uc.ResetForm();
                Helper.MessageBoxSuccess("Allotment Release has been updated");
                _frmAllotmentRelease.LoadAppropriationDetails();
                _frmAllotmentRelease.LoadAllotmentReleaseRecords();
                Close();
            }
        }
    }
}
