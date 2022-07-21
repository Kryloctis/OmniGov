using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.RptTaxRates
{
    public partial class frmRptTaxRates : Form
    {
        private readonly MainForm _mainForm;
        public frmRptTaxRates(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            Helper.LoadFormIcon(this);
        }

        private void LoadTaxRates() 
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void frmRptTaxRates_Load(object sender, EventArgs e)
        {
            Helper.EnableDisableToolStripButtons(dataGridView1, btnEdit, btnDelete);
        }
    }
}
