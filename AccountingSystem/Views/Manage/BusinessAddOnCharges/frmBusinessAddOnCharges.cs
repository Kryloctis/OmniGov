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
    public partial class frmBusinessAddOnCharges : Form
    {
        public frmBusinessAddOnCharges()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
            Helper.DatagridFullRowSelectStyle(dgBusinessCategories, true);
        }

        internal void LoadBusinessAddOnCharges()
        {
            try
            {
                var dt = new DataTable();
                var searchText = toolStripTextBoxSearch.Text.Trim();

                if (searchText.Length > 2)
                    dt = AccFactory.BusinessAddOnChargesRepository().GetRecordsBySearch(searchText);
                else
                    dt = AccFactory.BusinessAddOnChargesRepository().GetRecords();

                HelperLoadRecords.BusinessAdOnChargesDataGridView(dgBusinessCategories, dt);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddBusinessAddOnCharges(this).ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int businessAddOnChargesID = Convert.ToInt32(dgBusinessCategories.SelectedRows[0].Cells[0].Value);

            _ = new frmEditBusinessAddOnCharges(businessAddOnChargesID, this).ShowDialog();
        }
    }
}
