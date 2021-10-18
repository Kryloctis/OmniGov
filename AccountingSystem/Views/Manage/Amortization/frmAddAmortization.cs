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

namespace AccountingSystem.Views.Manage.Amortization
{
    public partial class frmAddAmortization : Form
    {
        private ucAmortization uc;
        private frmAmortization _frmAmortization;

        public frmAddAmortization(frmAmortization frmAmortization)
        {
            InitializeComponent();
            uc = ucAmortization1;
            uc.isEdit = false;
            _frmAmortization = frmAmortization;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (uc.SaveData())
            {
                Helper.MessageBoxSuccess("Amortization has been saved.");
                uc.ResetForm();
                _frmAmortization.LoadAmortizationRecords();
            }
        }
    }
}
