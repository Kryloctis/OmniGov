using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Barangay
{
    public partial class frmEditBarangay : Form
    {
        private int _barangayId;
        private frmBarangay _frmBarangay;
        private ucBarangay uc;

        public frmEditBarangay(int barangayId, frmBarangay frmBarangay)
        {
            InitializeComponent();
            uc = ucBarangay1;

            _barangayId = barangayId;
            _frmBarangay = frmBarangay;
        }

        private void frmEditBarangay_Load(object sender, EventArgs e)
        {
            try
            {
                LoadSelectedBarangay();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadSelectedBarangay()
        {
            var dictBarangay = AccFactory.BarangayRepository().GetRecordByID(_barangayId);

            uc.txtCode.Text = dictBarangay["code"];
            uc.txtBarangay.Text = dictBarangay["name"];
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (UpdateBarangay())
                {
                    Helper.MessageBoxSuccess("Barangay has been updated.");
                    _frmBarangay.LoadRecords();
                    Close();
                }
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private bool UpdateBarangay()
        {
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var barangayCode = uc.txtCode.Text.Trim();
            var barangayName = uc.txtBarangay.Text.Trim();

            var barangayModel = new BarangayModel()
            {
                Id = _barangayId,
                Code = barangayCode,
                Name = barangayName
            };

            return AccFactory.BarangayRepository().Update(barangayModel);
        }
    }
}