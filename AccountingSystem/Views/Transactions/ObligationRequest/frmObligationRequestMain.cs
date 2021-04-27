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
    public partial class frmObligationRequestMain : Form
    {
        private ucObligationRequestMain uc;

        public frmObligationRequestMain()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            btnSave.Click += new EventHandler(BtnSave_Click);
            uc = ucObligationRequestMain1;
        }   

        private void frmObligationRequestMain_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnCancel.Enabled = false;
        }

        private bool SaveObligationRequest() 
        {
            try
            {
                if (!uc.ValidateChildren()) 
                {
                    Helper.MessageBoxError(uc.GetFormErrors());
                    return false;
                }
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return true;
        }

        private void BtnSave_Click(object sender, EventArgs e) 
        {
            if (SaveObligationRequest()) 
            {
                Helper.MessageBoxSuccess("Obligation Request has been saved.");
            }
            
        }
    }
}
