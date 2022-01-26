using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.CheckIssuance.Obligations
{
    public partial class frmObligations : Form
    {
        DataTable dtObligations = new();

        public frmObligations()
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgObligation);
        }

        private void frmObligations_Load(object sender, EventArgs e)
        {
            dtObligations.Columns.Add("Öbligation No.");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dtObligations.Rows.Add(txtObno.Text.Trim());
            HelperLoadRecords.RCIObligationDatagridview(dtObligations, dgObligation);
            txtObno.Text = string.Empty;
        }

        private void txtObno_TextChanged(object sender, EventArgs e)
        {
            bool isTextBoxEmpty = !String.IsNullOrEmpty(txtObno.Text.Trim());
            btnAdd.Enabled = isTextBoxEmpty;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            bool hasRowSelected = Convert.ToBoolean(dgObligation.Rows.Count != 0);
            
            if (hasRowSelected)
            {
                foreach (DataGridViewRow row in dgObligation.SelectedRows)
                    dgObligation.Rows.Remove(row);
            }
        }

        private void dgObligation_SelectionChanged(object sender, EventArgs e)
        {
            bool hasRowSelected = Convert.ToBoolean(dgObligation.Rows.Count != 0);
            btnRemove.Enabled = hasRowSelected; 
        }
    }
}
