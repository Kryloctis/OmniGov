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

namespace AccountingSystem.Views.Manage.RptDiscount
{
    public partial class frmRptDiscounts : Form
    {
        private readonly MainForm _mainForm;

        public frmRptDiscounts(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dataGridView1, true);
        }

        internal void LoadDiscounts()
        {
            string searchText = txtSearch.Text.Trim();

            if (searchText.Length < 2)
            {
                var dt = Factory.rptDiscountRepository().GetRecords();
                HelperLoadRecords.DiscountsDatagridView(dataGridView1, dt);
            }
            else
            {
                var dt = Factory.rptDiscountRepository().GetRecordsBySearch(searchText);
                HelperLoadRecords.DiscountsDatagridView(dataGridView1, dt);
            }
        }

        private void frmRptDiscount_Load(object sender, EventArgs e)
        {
            LoadDiscounts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddRptDiscount(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _ = new frmEditRptDiscounts(this).ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDiscounts();
        }
    }
}
