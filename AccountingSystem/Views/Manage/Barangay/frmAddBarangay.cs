using ACC.Domain.Models;
using DocumentFormat.OpenXml.Wordprocessing;
using ACC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Barangay
{
    public partial class frmAddBarangay : Form
    {
        internal readonly ucBarangay uc;
        internal readonly frmBarangay _frmBarangay;

        public frmAddBarangay(frmBarangay frmBarangay)
        {
            InitializeComponent();
            _frmBarangay = frmBarangay;
            uc = ucBarangay1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
            {
                Helper.MessageBoxSuccess("Barangay has been saved.");
                _frmBarangay.LoadRecords();
                uc.ResetForm();
            }
        }

        private bool SaveData()
        {
            var uc = ucBarangay1;
            if (!uc.ValidateChildren())
            {
                Helper.MessageBoxError(uc.GetFormErrors());
                return false;
            }

            var barangayCode = uc.txtCode.Text.Trim();
            var barangayName = uc.txtBarangay.Text.Trim();


            var barangayModel = new BarangayModel() {
                Code = barangayCode,
                Name = barangayName,
                MunicipalityID = 1
            };

            var barangayRepository = AccFactory.BarangayRepository();

            return barangayRepository.Insert(barangayModel);

        }
    }
}
