using ACC.Domain.Models;
using AccountingSystem.Views.Manage.BudgetAppropriations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.AllotmentRelease
{
    public partial class frmAllotmentReleaseMain : Form
    {
        internal ucAllotmentReleaseMain uc;

        public frmAllotmentReleaseMain()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucAllotmentReleaseMain1;
        }

        private bool SaveData() 
        {
            try
            {
                var uc = ucAllotmentReleaseMain1;
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

        private void UnsavedWorkPrompt()
        {
            var message = "Are you sure? Unsaved data will not be saved.";

            if (MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                uc.ResetForm();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Allotment release has been saved.");
                uc.ResetForm();
            }
        }

        private void BtnNew_Click(object sender, EventArgs e) 
        {
            if (!uc.panel1.Enabled)
            {
                UnsavedWorkPrompt();
            }
        }
    }
}
