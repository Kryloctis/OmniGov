using AccountingSystem.Views.Transactions.RCI;
using System;
using System.Data;
using System.Windows.Forms;

namespace AccountingSystem.Views.Transactions.CheckIssuance.Obligations
{
    public partial class frmObligations : Form
    {
        private readonly ucRCI _uc;

        DataTable dtObligations = new();


        public frmObligations(ucRCI uc)
        {
            InitializeComponent();
            Helper.DatagridFullRowSelectStyle(dgObligation);
            _uc = uc;
        }

        private void frmObligations_Load(object sender, EventArgs e)
        {
            HelperLoadRecords.RCIObligationDatagridview(_uc.dtObligations, dgObligation);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _uc.dtObligations.Rows.Add(txtObno.Text.Trim());
            HelperLoadRecords.RCIObligationDatagridview(_uc.dtObligations, dgObligation);
            txtObno.Text = string.Empty;
        }

        private void txtObno_TextChanged(object sender, EventArgs e)
        {
            bool isTextBoxEmpty = !String.IsNullOrEmpty(txtObno.Text.Trim());
            btnAddObligations.Enabled = isTextBoxEmpty;
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

            btnRemoveObligations.Enabled = hasRowSelected;
            btnConfirmObligation.Enabled = hasRowSelected;
        }

        private void btnConfirmObligation_Click(object sender, EventArgs e)
        {
            if (Helper.MessageBoxConfirmCancel("Confirm obligations that has been set?"))
            {
                _uc.SetObligationLabel();
                this.Close();
            }
        }
    }
}
