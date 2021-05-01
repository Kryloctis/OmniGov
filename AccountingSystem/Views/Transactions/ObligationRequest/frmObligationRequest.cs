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

namespace AccountingSystem.Views.Transactions.ObligationRequest
{
    public partial class frmObligationRequest : Form
    {
  
        public frmObligationRequest()
        {
            InitializeComponent();
            btnSave.Click += new EventHandler(btnSave_Click);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            btnSearch.Click += new EventHandler(btnSearch_Click);
        }

        private bool SaveData() 
        {
            try
            {
                var uc = ucObligationRequest1;
                int fundID = Convert.ToInt32(uc.cmbxFunds.SelectedValue);
                int fppID = Convert.ToInt32(uc.cmbxFPP.SelectedValue);
                int? othersFPPID = string.IsNullOrEmpty(uc.cmbxOthersFPP.Text.Trim()) ? null : Convert.ToInt32(uc.cmbxOthersFPP.SelectedValue);
                int allotmentClassID = Convert.ToInt32(uc.cmbxAllotmentClasses.SelectedValue);
                int accountID = Convert.ToInt32(uc.cmbxAccount.SelectedValue);
                string obligationNo =$"{uc.mskObligationSeriesNo.Text}-{uc.mskTxtTemplateNo.Text}";
                decimal obligationAmount = uc.nudAmount.Value;
                DateTime dateIssued = uc.dtPickerDateIssued.Value;
                bool obligationExist = Factory.ObligationRequestRepository().ObligationRequestExist(fundID, fppID, othersFPPID, allotmentClassID, accountID, dateIssued, obligationNo);

                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }
                else if (obligationExist) 
                {
                    Helper.MessageBoxError("Obligation Request is Already been recorded.");
                    return false;
                }

                var user = Helper.GetLoggedInUser();
                var obligationModel = new ObligationRequestModel
                {
                    ID = uc.obligationID,
                    FundID = fundID,
                    FPPId = fppID,
                    OtherFPPId = othersFPPID,
                    AllotmentClassesID = allotmentClassID,
                    GenLedgerAccID = accountID,
                    ObligationNo = obligationNo,
                    ObligationAmount = obligationAmount,
                    DateRequested = dateIssued,
                    CreatedBy = 1,
                    UpdatedBy = 1
                };

                if (uc.obligationID == 0)
                    return Factory.ObligationRequestRepository().Insert(obligationModel);
                else
                    return Factory.ObligationRequestRepository().Update(obligationModel);
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
                var uc = ucObligationRequest1;
                if (uc.obligationID == 0)
                {
                    uc.ResetFields();
                    Helper.MessageBoxSuccess("Obligation Request has been saved.");
                }
                else
                {
                    btnCancel.Enabled = false;
                    btnDelete.Enabled = false;
                    btnSave.Text = "Save";
                    uc.ResetForm();
                    Helper.MessageBoxSuccess("Obligation Request has been updated.");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var uc = ucObligationRequest1;

            btnCancel.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Text = "Save";

            uc.ResetForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var uc = ucObligationRequest1;
                var message = $"Are you sure you want to delete Obligation No. record?";

                if (MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) 
                {
                    var obligationRequestModelList = new List<ObligationRequestModel>();
                    var obligationRequestModel = new ObligationRequestModel()
                    {
                        ID = uc.obligationID
                    };
                    obligationRequestModelList.Add(obligationRequestModel);

                    _ = Factory.ObligationRequestRepository().Delete(obligationRequestModelList);
                    uc.ResetForm();
                    btnCancel.Enabled = false;
                    btnDelete.Enabled = false;
                    btnSave.Text = "Save";
                }
            }
            catch (Exception ex) 
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) 
        {
            _ = new frmSearchObligationRequest(this).ShowDialog();
        }

        private void frmObligationRequest_Load(object sender, EventArgs e)
        {
            var uc = ucObligationRequest1;
            Helper.LoadFormIcon(this);

            uc.LoadComboboxes();
        }
    }
}
