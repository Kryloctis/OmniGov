using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RptPenalties
{
    public partial class frmRptPenalties : Form
    {
        private readonly MainForm _mainForm;
        public frmRptPenalties(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            Helper.LoadFormIcon(this);
            Helper.DatagridDefaultStyle(dataGridView1, true);
        }

        internal void LoadPenalties() 
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
        }
    }
}
