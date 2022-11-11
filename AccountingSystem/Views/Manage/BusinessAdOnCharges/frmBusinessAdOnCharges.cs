using AccountingSystem.Views.Manage.BusinessCategories;
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
    public partial class frmBusinessAdOnCharges : Form
    {
        public frmBusinessAdOnCharges()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgBusinessCategories, true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddBusinessAdOnCharges(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int businessAddOnChargesID = Convert.ToInt32(dgBusinessCategories.SelectedRows[0].Cells[0].Value);

            _ = new frmEditBusinessAdOnCharges(businessAddOnChargesID, this).ShowDialog();
        }
    }
}
