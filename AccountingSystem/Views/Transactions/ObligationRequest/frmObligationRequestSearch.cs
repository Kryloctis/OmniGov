using ACC.Domain.Interfaces;
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
    public partial class frmObligationRequestSearch : Form
    {
        private frmObligationRequestMain _frmObligationRequestMain;
        private ucObligationRequestMain _ucObligationRequestMain;

        public frmObligationRequestSearch(frmObligationRequestMain frmObligationRequestMain)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _frmObligationRequestMain = frmObligationRequestMain;
            _ucObligationRequestMain = _frmObligationRequestMain.ucObligationRequestMain1;
        }


        internal string GetFormErrors()
        {
            var errorArray = new string[1];
            errorArray[0] = mskTxtObligationNo.Tag.ToString();

            IError _errors = Factory.CreateErrors(errorArray);
            return _errors.GenerateErrorMessage();
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                Helper.MessageBoxError(GetFormErrors());
            }
            else
            {
                _ucObligationRequestMain.LoadSearched();
                _frmObligationRequestMain.btnNew.Enabled = false;
                _frmObligationRequestMain.btnCancel.Enabled = true;
                _frmObligationRequestMain.btnDelete.Enabled = true;
                _ucObligationRequestMain.cmbxFPP.Enabled = false;
                _ucObligationRequestMain.cmbxSubFPP.Enabled = false;
                _ucObligationRequestMain.flowLayoutPanelFunds.Enabled = false;
                _ucObligationRequestMain.flowLayoutPanelAllotmentClass.Enabled = false;
                _ucObligationRequestMain.dtDateRequest.Enabled = false;

                _frmObligationRequestMain.btnSave.Text = "&Update";
                Close();
            }
        }


        private bool ObligationEmpty()
        {
            try
            {
                if (!mskTxtObligationNo.MaskCompleted)
                {
                    mskTxtObligationNo.Tag = "Please enter Obligation No.";
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private bool ObligationNoNotExist()
        {
            try
            {
                bool obligationNoExist = Factory.ObligationRequestRepository().ObligationRequestNoExist(mskTxtObligationNo.Text);

                if (!obligationNoExist)
                {
                    mskTxtObligationNo.Tag = "Obligation No. you entered doesn't exist on you record";
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        }

        private void mskTxtObligationNo_Validating(object sender, CancelEventArgs e)
        {
            if (!mskTxtObligationNo.MaskCompleted)
                e.Cancel = ObligationEmpty();
            else
                e.Cancel = ObligationNoNotExist();
        }
    }
}
