using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Barangay
{
    public partial class frmAddBarangay : Form
    {
        internal readonly frmBarangay _frmBarangay;
        internal readonly ucBarangay uc;

        public frmAddBarangay(frmBarangay frmBarangay)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            _frmBarangay = frmBarangay;
            uc = ucBarangay1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveData())
                {
                    Helper.MessageBoxSuccess("Barangay has been saved.");
                    _frmBarangay.LoadRecords();
                    uc.ResetForm();
                }
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

            var barangayCode = uc.txtCode.Text.Trim();
            var barangayName = uc.txtName.Text.Trim();

            var barangayModel = new BarangayModel()
            {
                Code = barangayCode,
                Name = barangayName,
                MunicipalityID = 1
            };

            return AccFactory.BarangayRepository().Insert(barangayModel);
        }

        private void frmAddBarangay_Load(object sender, EventArgs e)
        {
            try
            {
                uc.isEdit = false;
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }
    }
}