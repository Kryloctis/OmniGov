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
                return true;
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

                Helper.MessageBoxSuccess("Obligation Request has been saved.");
            }
        }

        private void frmObligationRequest_Load(object sender, EventArgs e)
        {
        }
    }
}
