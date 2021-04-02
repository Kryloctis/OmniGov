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
    public partial class frmSearchObligationRequest : Form
    {
        private frmObligationRequest _frmObligationRequest;
        public frmSearchObligationRequest(frmObligationRequest frmObligationRequest)
        {
            InitializeComponent();
            _frmObligationRequest = frmObligationRequest;
        }

        private void LoadSelectedObligationInfo() 
        {
            try
            {

                var uc = _frmObligationRequest.ucObligationRequest1;

                uc.ResetForm();
                uc.lnklblAllotmentRelease.Enabled = false;
                _frmObligationRequest.btnCancel.Enabled = true;
                _frmObligationRequest.btnDelete.Enabled = true;
                _frmObligationRequest.btnSave.Text = "Update";
                uc.obligationNo = mkTxtObligationNum.Text.Trim();
                uc.LoadSearchRecord();
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Factory.ObligationRequestRepository().ObligationNumExist(mkTxtObligationNum.Text))
            {
                LoadSelectedObligationInfo();
                Close();
            }
            else
                Helper.MessageBoxError("Obligation No. Doesn't exist.");
        }

        private void mkTxtObligationNum_TextChanged(object sender, EventArgs e)
        {
            if (mkTxtObligationNum.MaskCompleted)
                btnOk.Enabled = true;
            else
                btnOk.Enabled = false;
        }
    }
}
