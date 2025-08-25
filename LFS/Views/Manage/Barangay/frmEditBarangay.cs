using ACC.Data;
using LFS.Helpers;
using System;
using System.Windows.Forms;

namespace LFS.Views.Manage.Barangay
{
    public partial class frmEditBarangay : Form
    {
        private int barangayId;
        private frmBarangay frmBarangay;
        private ucBarangay uc;

        public frmEditBarangay(int barangayId, frmBarangay frmBarangay)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucBarangay1;
            this.barangayId = barangayId;
            this.barangayId = barangayId;
            this.frmBarangay = frmBarangay;
        }

        private bool UpdateData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var barangayModel = uc.BarangayModel();
            barangayModel.Id = barangayId;

            return AccFactory.BarangayRepository().Update(barangayModel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateData())
                {
                    Helper.MessageBoxSuccess("Barangay has been updated.");
                    frmBarangay.LoadRecords();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmEditBarangay_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(true, barangayId);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmEditBarangay_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Control)
                {
                    if (UpdateData())
                    {
                        Helper.MessageBoxSuccess("Barangay has been updated.");
                        frmBarangay.LoadRecords();
                        Close();
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}