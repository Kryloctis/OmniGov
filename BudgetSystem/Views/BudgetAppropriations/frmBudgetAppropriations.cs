using AccountingSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetSystem.Views.BudgetAppropriations
{
    public partial class frmBudgetAppropriations : Form
    {
        public frmBudgetAppropriations()
        {
            InitializeComponent();
        }

        private void frmBudgetAppropriations_Load(object sender, EventArgs e)
        {
        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e) 
        {
            var frmBudgetAppropriationsAdd = new frmBudgetAppropriationsAdd();
            frmBudgetAppropriationsAdd.ShowDialog();
        }
    }
}
