using ACC.Data;
using ACC.Domain.Models;
using System;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Barangay
{
    public partial class frmEditBarangay : Form
    {
        private int barangayId;
        private frmBarangay _frmBarangay;
        private ucBarangay uc;

        public frmEditBarangay(int barangayId, frmBarangay frmBarangay)
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            uc = ucBarangay1;
            uc.barangayId = barangayId;
            this.barangayId = barangayId;
            _frmBarangay = frmBarangay;
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

        private void frmEditBarangay_Load(object sender, EventArgs e)
        {
            try
            {
                uc.isEdit = true;
                LoadSelectedBarangay();
            }
            catch (Exception ex) { Helper.MessageBoxError(ex.Message); }
        }

        private void LoadSelectedBarangay()
        {
            var dictBarangay = AccFactory.BarangayRepository().GetRecordByID(barangayId);

            uc.txtCode.Text = dictBarangay["code"];
            uc.txtName.Text = dictBarangay["name"];
        }

        private bool UpdateBarangay()
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
                Id = barangayId,
                Code = barangayCode,
                Name = barangayName
            };

            return AccFactory.BarangayRepository().Update(barangayModel);
        }
    }
}