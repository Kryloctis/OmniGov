using AccountingSystem.Views.Reports.Ltom;
using AccountingSystem.Views.Reports.RCD;
using System;
using System.Windows.Forms;

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
    }
}