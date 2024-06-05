using AccountingSystem.Views.Reports.Ltom;
using System;
using System.Windows.Forms;
using AccountingSystem.Views.Reports.Rcd;
using AccountingSystem.Views.Reports.Saaob;
using AccountingSystem.Views.Reports.Saaobb;

namespace AccountingSystem.Views.Dashboard.Reports
{
    public partial class ucReports : UserControl
    {
        public ucReports()
        {
            InitializeComponent();
        }

        internal void OnLoad()
        {
            ValidatedPermissions();
        }

        private void ValidatedPermissions()
        {
            if (!Helper.HasPermission("Report > Report of Collections and Deposits"))
                btnRcd.Enabled = false;

            if (!Helper.HasPermission("Report > SAAOB"))
                btnSaaob.Enabled = false;
            
            if(!Helper.HasPermission("Report > SAAOBB"))
                btnSaaobb.Enabled = false;
        }

        private void btnLtom17and19_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmLtom17to19().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnRcd_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmRcd().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnLtom20_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmLtom20().ShowDialog();
            }
            catch (Exception ex)
            { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSaaob_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmSaaob().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnSaaobb_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmSaaobb().ShowDialog();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}