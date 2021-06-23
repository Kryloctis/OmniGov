using MySql.Data.MySqlClient;
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
    public partial class frmAllotmentReleaseSearch : Form
    {
        private frmAllotmentReleaseMain _frmAllotmentReleaseMain;

        public frmAllotmentReleaseSearch(frmAllotmentReleaseMain frmAllotmentReleaseMain)
        {
            InitializeComponent();
            _frmAllotmentReleaseMain = frmAllotmentReleaseMain;
        }

        private bool AllotmentReleaseNoExist() 
        {
            try
            {
                string allotmentReleaseNo = mskAllotmentReleaseNo.Text;
                bool allotmentReleaseNoExist = Factory.AllotmentReleaseRepository().AllotmentReleaseNoExist(allotmentReleaseNo);

                if (allotmentReleaseNoExist)
                {
                    _frmAllotmentReleaseMain.uc.LoadSearched(allotmentReleaseNo);
                    return true;
                }
                else 
                {
                    Helper.MessageBoxError("ARO No. doesn't exist");
                    return false;
                }
            }
            catch (MySqlException ex) 
            {
                Helper.MessageBoxError(ex.Message);
            }
            catch (Exception ex)
            {
                Helper.MessageBoxError(ex.Message);
            }
            return false;
        
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (AllotmentReleaseNoExist())
            {
                _frmAllotmentReleaseMain.btnSave.Text = "Update";
                _frmAllotmentReleaseMain.btnDelete.Enabled = true;
                _frmAllotmentReleaseMain.btnCancel.Enabled = true;
                Close();
            }
        }
    }
}
