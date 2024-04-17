using DocumentFormat.OpenXml.Office2010.CustomUI;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Reports.RCD
{
    public partial class frmRcd : Form
    {
        public frmRcd()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedTab = tabPageList;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedTab = tabPageForm;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedTab = tabPageForm;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedTab = tabPagePrint;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            try
            {
                tabControl1.SelectedTab = tabPageList;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}