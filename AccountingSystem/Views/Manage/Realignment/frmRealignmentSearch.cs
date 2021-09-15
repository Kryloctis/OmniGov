using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Realignment
{
    public partial class frmRealignmentSearch : Form
    {
        public frmRealignmentSearch()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void frmRealignmentSearch_Load(object sender, EventArgs e)
        {
            LoadRealignment();
            Helper.DatagridFullRowSelectStyle(dgRealignment, true);
        }

        private void LoadRealignment()
        {
            string searchTxt = txtSearch.Text;
            short month = Convert.ToInt16(cbMonth.SelectedIndex + 1);
            short year = Convert.ToInt16(nudYear.Value);


            //DataTable dtRealignment = Factory.BudgetRealignmentRepository().FilterRecords(searchTxt, month, year);
            //HelperLoadRecords.RealignmentDatagridView(dtRealignment, dgRealignment);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
