using LFS.Helpers;
using LFS.Views.Transactions.RCI;
using System;
using System.Windows.Forms;

namespace LFS.Views.Transactions.CheckIssuance.Obligations

{
    public partial class frmChckIssOblgtns : Form
    {
        private readonly ucRCI _uc;

        public frmChckIssOblgtns(ucRCI uc)
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
            _uc.dtObligations.Rows.Add(txtObno.Text.Trim(), dtpDateEntry.Value.ToString("MMMM-dd-yyyy"));
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
            foreach (DataGridViewRow row in dgObligation.SelectedRows)
                dgObligation.Rows.Remove(row);
        }

        private void dgObligation_SelectionChanged(object sender, EventArgs e)
        {
            bool hasRowSelected = Convert.ToBoolean(dgObligation.Rows.Count != 0);

            btnRemoveObligations.Enabled = hasRowSelected;
            btnConfirmObligation.Enabled = hasRowSelected;
        }

        private void btnConfirmObligation_Click(object sender, EventArgs e)
        {
            sbyte totalObligationNumberCount = (sbyte)dgObligation.Rows.Count;
            if (Helper.MessageBoxConfirmCancel($"Confirm {totalObligationNumberCount} obligation number/s ?"))
            {
                _uc.SetObligationLabel();
                this.Close();
            }
        }

        private void frmObligations_FormClosing(object sender, FormClosingEventArgs e)
        {
            _uc.SetObligationLabel();
        }
    }
}
