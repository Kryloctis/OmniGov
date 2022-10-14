using ACC.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            LoadSelectedBarangay();
        }

        private void LoadSelectedBarangay()
        {
            var dictBarangay = AccFactory.BarangayRepository().GetRecordByID(_barangayId);

            uc.txtCode.Text = dictBarangay["code"];
            uc.txtBarangay.Text = dictBarangay["name"];

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UpdateBarangay())
            {
                Helper.MessageBoxSuccess("Barangay has been updated.");
                _frmBarangay.LoadRecords();
                Close();
            }
        }

        private bool UpdateBarangay()
        {
            try
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
            catch (Exception)
            {

                throw;
            }
        }
    }
}
