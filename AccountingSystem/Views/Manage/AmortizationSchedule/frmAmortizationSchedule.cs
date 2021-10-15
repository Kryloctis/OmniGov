using AccountingSystem.Views.Manage.AmortizationSchedule;
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
    public partial class frmAmortizationSchedule : Form
    {
        public frmAmortizationSchedule()
        {
            InitializeComponent();
            Helper.LoadFormIcon(this);
        }

        private void LoadDatagridFormat() 
        {
            dgAmortizationSched.Columns.Add("id", "ID");
            dgAmortizationSched.Columns.Add("amortization_id", "Ammortization ID");
            dgAmortizationSched.Columns.Add("date", "Date");
            dgAmortizationSched.Columns.Add("principal_amount", "Principal");
            dgAmortizationSched.Columns.Add("interest_amount", "Interest");
            dgAmortizationSched.Columns.Add("grt_amount", "GRT");

            dgAmortizationSched.Columns["id"].Visible = false;
            dgAmortizationSched.Columns["amortization_id"].Visible = false;
            dgAmortizationSched.Columns["principal_amount"].DefaultCellStyle.Format = "0.00##";
            dgAmortizationSched.Columns["interest_amount"].DefaultCellStyle.Format = "0.00##";
            dgAmortizationSched.Columns["grt_amount"].DefaultCellStyle.Format = "0.00##";

            Helper.DatagridFullRowSelectStyle(dgAmortizationSched, true);
        }

        private void frmAmortizationSchedule_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadDatagridFormat();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ = new frmAddAmortizationSchedule().ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _ = new frmEditAmortizationSchedule().ShowDialog();
        }

        private void dgAmortizationSched_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            foreach (DataGridViewColumn column in dgAmortizationSched.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
