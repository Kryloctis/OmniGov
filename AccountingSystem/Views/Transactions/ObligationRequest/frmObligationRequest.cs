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

                if (!uc.ValidateChildren() || uc.fppId == 0) 
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false; 
                }

                var user = Helper.GetLoggedInUser();
                var obligationModel = new ObligationRequestModel
                {
                    ID = uc.obligationId,
                    FundID = uc.fundId,
                    FPPId = uc.fppId,
                    OtherFPPId = uc.othersFPPId,
                    AllotmentClassesID = uc.allotmentClassId,
                    GenLedgerAccID = uc.accountId,
                    ObligationNo = uc.mkTxtObligationNum.Text,
                    ObligationAmount = uc.nudAmount.Value,
                    year = uc.year,
                    CreatedBy = 1,
                    UpdatedBy = 1
                };

                if (uc.isEdit == false)
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
                if (uc.isEdit == false)
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
                var message = $"Are you sure you want to delete Obligation No. {uc.obligationNo} record?";

                if (MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) 
                {
                    var obligationRequestModelList = new List<ObligationRequestModel>();
                    var obligationRequestModel = new ObligationRequestModel()
                    {
                        ID = uc.obligationId
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
        }
    }
}
