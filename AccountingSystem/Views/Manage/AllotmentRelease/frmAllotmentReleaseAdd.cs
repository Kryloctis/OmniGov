using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AllotmentRelease
{
    public partial class frmAllotmentReleaseAdd : Form
    {
        public frmAllotmentReleaseAdd()
        {
            InitializeComponent();
        }

        private void frmAllotmentReleaseAdd_Load(object sender, EventArgs e)
        {
            Helper.LoadFormIcon(this);
        }

        private bool AddAllotmentRelease() 
        {
            try
            {
                var uc = ucAllotmentRelease1;

                if (!uc.ValidateChildren() || !string.IsNullOrEmpty(uc.epAccount.GetError(uc.groupBox1))) 
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
            if (AddAllotmentRelease()) 
            {
                Close();
            }
        }
    }
}
