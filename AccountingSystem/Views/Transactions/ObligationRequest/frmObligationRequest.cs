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
        }

        private bool SaveData() 
        {
            try
            {
                var uc = ucObligationRequestNew1;

                if (!uc.ValidateChildren() || uc.fppId == 0) 
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false; 
                }

                var user = Helper.GetLoggedInUser();
                var obligationModel = new ObligationRequestModel
                {
                    FundID = uc.fundId,
                    FPPId = uc.fppId,
                    OtherFPPId = uc.othersFPPId,
                    AllotmentClassesID = uc.allotmentClassId,
                    GenLedgerAccID = uc.accountId,
                    ObligationNo = uc.mkTxtObligationNum.Text,
                    ObligationAmount = uc.nudAmount.Value,
                    CreatedBy = 1,
                };

                return Factory.ObligationRequestRepository().Insert(obligationModel);
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
                var uc = ucObligationRequestNew1;

                uc.ResetForm();
                Helper.MessageBoxSuccess("Obligation Request has been saved.");
            }
        }

        private void frmObligationRequest_Load(object sender, EventArgs e)
        {
        }
    }
}
