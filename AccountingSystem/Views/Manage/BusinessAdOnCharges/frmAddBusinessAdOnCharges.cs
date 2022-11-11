using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.BusinessAdOnCharges
{
    public partial class frmAddBusinessAdOnCharges : Form
    {
        private frmBusinessAdOnCharges _frmBusinessAdOnCharges;

        public frmAddBusinessAdOnCharges(frmBusinessAdOnCharges frmBusinessAdOnCharges)
        {
            InitializeComponent();
            frmBusinessAdOnCharges = frmBusinessAdOnCharges;
        }
    }
}
