using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingSystem.Views.Manage.Amortization
{
    public partial class frmAmortization : Form
    {
        public frmAmortization()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void LoadDatagridFormat() 
        {
            dgAmmortization.Columns.Add("bank_name", "Bank Name");
            dgAmmortization.Columns.Add("amortization_term", "Term");
            dgAmmortization.Columns.Add("interest", "Interest");
            dgAmmortization.Columns.Add("amount_released", "Amount Release");

            dgAmmortization.Columns["amount_released"].DefaultCellStyle.Format = "0.00##";
            dgAmmortization.Columns["interest"].DefaultCellStyle.Format = "0\\%";

            Helper.DatagridFullRowSelectStyle(dgAmmortization, true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddAmortization().ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _ = new frmEditAmortization().ShowDialog();
        }

        private void btnAmortizationSched_Click(object sender, EventArgs e)
        {
            _ = new frmAmortizationSchedule().ShowDialog();
        }

        private void frmAmortization_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadDatagridFormat();
            }
        }

        private void dgAmmortization_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            foreach (DataGridViewColumn column in dgAmmortization.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
