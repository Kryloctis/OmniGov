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
    public partial class frmEditBusinessAdOnCharges : Form
    {
        private int _businessAddOnChargesID;
        private frmBusinessAdOnCharges _frmBusinessAdOnCharges;
       
        public frmEditBusinessAdOnCharges()
        {
            InitializeComponent();
        }

        public frmEditBusinessAdOnCharges(int businessAddOnChargesID, frmBusinessAdOnCharges frmBusinessAdOnCharges)
        {
           _businessAddOnChargesID = businessAddOnChargesID;
           _frmBusinessAdOnCharges = frmBusinessAdOnCharges;
        }




    }
}
