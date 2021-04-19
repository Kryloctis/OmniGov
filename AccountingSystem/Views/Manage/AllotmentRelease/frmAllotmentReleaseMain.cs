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
    public partial class frmAllotmentReleaseMain : Form
    {
        public frmAllotmentReleaseMain()
        {
            InitializeComponent();
            btnCancel.Enabled = false;
            btnDelete.Enabled = false;
            Helper.LoadFormIcon(this);

            btnSave.Click += new EventHandler(BtnSave_Click);
            btnNew.Click += new EventHandler(BtnNew_Click);
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Allotment release has been saved.");
            }
        }

        private void BtnNew_Click(object sender, EventArgs e) 
        {
            var uc = ucAllotmentReleaseMain1;
            if (!uc.panel1.Enabled) 
            {
                uc.panel1.Enabled = true;
                uc.mskSeriesNo.Text = string.Empty;
                uc.dtDateIssued.Value = DateTime.Now;
                uc.LoadFPPCombobox();
                uc.LoadFunds();
                uc.LoadAllotmentClasses();
            }         
        }
    }
}
