using OmniGov.App.Helpers;
using OmniGov.Core.Factories;

namespace OmniGov.App.Views.Manage.Barangay
{
    public partial class frmAddBarangay : Form
    {
        internal readonly frmBarangay frmBarangay;
        internal readonly ucBarangay uc;

        public frmAddBarangay(frmBarangay frmBarangay)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            this.frmBarangay = frmBarangay;
            uc = ucBarangay1;
        }

        private void frmAddBarangay_Load(object sender, EventArgs e)
        {
            try
            {
                uc.OnLoad(false, null);
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool SaveData()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            return Factory.BarangayRepository().Insert(uc.BarangayModel());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Barangay has been saved.");
                    frmBarangay.LoadRecords();
                    uc.ResetForm();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void frmAddBarangay_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.S && e.Control)
                {
                    if (SaveData())
                    {
                        Helper.MessageBoxSuccess("Barangay has been saved.");
                        frmBarangay.LoadRecords();
                        uc.ResetForm();
                    }
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}

