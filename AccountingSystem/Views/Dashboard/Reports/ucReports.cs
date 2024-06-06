using AccountingSystem.Views.Reports.Ltom;
using AccountingSystem.Views.Reports.Rcd;
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

        private void btnLtom20_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmLtom20().ShowDialog();
            }
            catch (Exception ex)
            { Helper.MessageBoxError(ex.Message); }
        }

        private void btnLtom23_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmLtom23().ShowDialog();
            }
            catch (Exception ex)
            { Helper.MessageBoxError(ex.Message); }
        }

        private void btnLtom24_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmLtom24().ShowDialog();
            }
            catch (Exception ex)
            { Helper.MessageBoxError(ex.Message); }

        }

        private void btnLtom29_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmLtom29().ShowDialog();
            }
            catch (Exception ex)
            { Helper.MessageBoxError(ex.Message); }
        }

        private void btnLtom30_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmLtom30().ShowDialog();
            }
            catch (Exception ex)
            { Helper.MessageBoxError(ex.Message); }
        }

        private void btnLtom31_Click(object sender, EventArgs e)
        {
            try
            {
                _ = new frmLtom31().ShowDialog();
            }
            catch (Exception ex)
            { Helper.MessageBoxError(ex.Message); }
        }

    }
}