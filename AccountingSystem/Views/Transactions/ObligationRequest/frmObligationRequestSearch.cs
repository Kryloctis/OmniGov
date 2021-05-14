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
        public frmObligationRequestSearch()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private bool ValidatedObligationRequestNo() 
        {
            try
            {
                bool obligationRequestNoExist = Factory.ObligationRequestRepository().ObligationNumExist(mskTxtBoxObligationRequestNo.Text);

                if (!mskTxtBoxObligationRequestNo.MaskCompleted) 
                {
                    Helper.MessageBoxError("Please put an Obligation No.");
                    return false;
                }
                else if (!obligationRequestNoExist)
                {
                    Helper.MessageBoxError("Obligation No. you entered doesn't exist on your record.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidatedObligationRequestNo()) 
            {

                Close();
            }
        }
    }
}
