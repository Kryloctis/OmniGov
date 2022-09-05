using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RealProperties
{
    public partial class frmAddRealProperties : Form
    {
        private ucRealProperties uc;

        public frmAddRealProperties()
        {
            Helper.LoadFormIcon(this);
            InitializeComponent();
            uc = ucRealProperties1;
        }

        private bool Save()
        {
            try
            {
                if (!uc.ValidateChildren())
                {
                    Helper.MessageBoxError(uc.GetFormError());
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
            if (Save())
            {
                Helper.MessageBoxSuccess("Real Property has been saved.");
            }
        }
    }
}