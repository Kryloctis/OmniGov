using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Signatories
{
    public partial class frmAddSignatories : Form
    {
        private ucSignatories uc;

        public frmAddSignatories()
        {
            InitializeComponent();
            uc = ucSignatories1;
        }

        private bool SaveData()
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
            if (SaveData())
                Helper.MessageBoxSuccess("Validated");
        }
    }
}
