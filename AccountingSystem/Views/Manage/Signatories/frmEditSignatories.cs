using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Signatories
{
    public partial class frmEditSignatories : Form
    {
        private ucSignatories uc;

        public frmEditSignatories()
        {
            InitializeComponent();
            uc = ucSignatories1;
        }

        private bool UpdateData()
        {
            try
            {
                if (!uc.ValidateChildren())
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
            if (UpdateData())
                Helper.MessageBoxSuccess("Validated");
        }
    }
}
