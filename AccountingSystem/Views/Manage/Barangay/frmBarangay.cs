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
    public partial class frmBarangay : Form
    {
        public frmBarangay()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgBarangay, true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddBarangay(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _ = new frmEditBarangay().ShowDialog();
        }

        private void frmBarangay_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        internal void LoadRecords()
        {
            try
            {
                var dtBarangay = AccFactory.BarangayRepository().GetRecords();
                HelperLoadRecords.BarangaysDatagridView(dgBarangay, dtBarangay);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
